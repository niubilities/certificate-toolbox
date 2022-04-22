namespace CertificateToolbox
{
    using System.Security.Cryptography.X509Certificates;
    using Org.BouncyCastle.Asn1;
    using Org.BouncyCastle.Asn1.Ocsp;
    using Org.BouncyCastle.Asn1.X509;
    using Org.BouncyCastle.Crypto;
    using Org.BouncyCastle.Crypto.Operators;
    using Org.BouncyCastle.Crypto.Prng;
    using Org.BouncyCastle.Math;
    using Org.BouncyCastle.Ocsp;
    using Org.BouncyCastle.Pkcs;
    using Org.BouncyCastle.Security;
    using Org.BouncyCastle.X509;
    using Org.BouncyCastle.X509.Extension;
    using X509Certificate = Org.BouncyCastle.X509.X509Certificate;

    public class Generator
    {
        private readonly X509V3CertificateGenerator _certificateGenerator;

        private readonly Dictionary<string, KeyPurposeID> _extendedUsagesMap = new()
        {
            { "client", KeyPurposeID.IdKPClientAuth },
            { "server", KeyPurposeID.IdKPServerAuth },
            { "ocsp", KeyPurposeID.IdKPOcspSigning }
        };

        private readonly SecureRandom _random;
        private AsymmetricCipherKeyPair _issuerKeyPair;

        private string _issuerName;
        private BigInteger _issuerSerialNumber;
        private AsymmetricCipherKeyPair _subjectKeyPair;

        public Generator()
        {
            _random = new SecureRandom(new CryptoApiRandomGenerator());
            _certificateGenerator = new X509V3CertificateGenerator();
        }

        public string[] CrlEndpoints { get; set; }
        public bool IsCertificateAuthority { get; set; }
        public X509Certificate2? Issuer { get; set; }
        public DateTime NotAfter { get; set; }
        public DateTime NotBefore { get; set; }
        public string[] OcspEndpoints { get; set; }
        public BigInteger SerialNumber { get; set; }
        public string?[] SubjectAlternativeNames { get; set; }
        public string SubjectName { get; set; }
        public string?[] Usages { get; set; }

        public void AddCrlDistributionPoints()
        {
            var distributionPoints = new List<Asn1Encodable>();

            foreach (var endpoint in CrlEndpoints)
            {
                var generalName = new GeneralName(GeneralName.UniformResourceIdentifier, new DerIA5String(endpoint));
                var gns = new GeneralNames(generalName);
                var dpn = new DistributionPointName(gns);
                var distp = new DistributionPoint(dpn, null, null);
                distributionPoints.Add(distp);
            }

            var seq = new DerSequence(distributionPoints.ToArray());
            _certificateGenerator.AddExtension(X509Extensions.CrlDistributionPoints, false, seq);
        }

        public void AddOcspPoints()
        {
            var accessDescriptions = new List<Asn1Encodable>();

            foreach (var endpoint in OcspEndpoints)
            {
                var generalName = new GeneralName(GeneralName.UniformResourceIdentifier, new DerIA5String(endpoint));
                var accessDescription = new AccessDescription(X509ObjectIdentifiers.OcspAccessMethod, generalName);
                accessDescriptions.Add(accessDescription);
            }

            var seq = new DerSequence(accessDescriptions.ToArray());
            _certificateGenerator.AddExtension(X509Extensions.AuthorityInfoAccess, false, seq);
        }

        public X509Certificate2? Generate()
        {
            _subjectKeyPair = KeyRepository.Next();

            if (Issuer == null)
            {
                _issuerKeyPair = _subjectKeyPair;
                _issuerName = SubjectName;
                _issuerSerialNumber = SerialNumber;
            }
            else
            {
                _issuerName = Issuer.Subject;
                _issuerKeyPair = DotNetUtilities.GetKeyPair(Issuer.GetECDiffieHellmanPrivateKey());
                _issuerSerialNumber = new BigInteger(Issuer.GetSerialNumber());
            }

            _certificateGenerator.SetSerialNumber(SerialNumber);
            _certificateGenerator.SetIssuerDN(new X509Name(_issuerName));
            _certificateGenerator.SetSubjectDN(new X509Name(SubjectName));
            _certificateGenerator.SetNotBefore(NotBefore);
            _certificateGenerator.SetNotAfter(NotAfter);
            _certificateGenerator.SetPublicKey(_subjectKeyPair.Public);
            AddAuthorityKeyIdentifier();
            AddSubjectKeyIdentifier();
            AddBasicConstraints();
            AddKeyUsage();
            AddExtendedKeyUsage();
            AddSubjectAlternativeNames();
            AddOcspPoints();
            AddCrlDistributionPoints();
            ISignatureFactory factory = new Asn1SignatureFactory("SHA256WithRSA", _subjectKeyPair.Private);
            var certificate = _certificateGenerator.Generate(factory);

            return ConvertCertificate(certificate);
        }

        public byte[] GetCrl(RevocationStatus status)
        {
            if ((status == RevocationStatus.Unknown) | (Issuer == null)) return Array.Empty<byte>();

            var generator = new X509V2CrlGenerator();

            generator.SetIssuerDN(new X509Name(Issuer?.SubjectName.Name));
            generator.SetThisUpdate(DateTime.Now.AddDays(-1));
            generator.SetNextUpdate(DateTime.Now.AddDays(1));

            if (status == RevocationStatus.Revoked)
                generator.AddCrlEntry(SerialNumber, DateTime.Now.AddHours(-12), CrlReason.KeyCompromise);

            generator.AddExtension(
                X509Extensions.AuthorityKeyIdentifier,
                false,
                new AuthorityKeyIdentifierStructure(DotNetUtilities.FromX509Certificate(Issuer)));

            generator.AddExtension(X509Extensions.CrlNumber, false, new CrlNumber(new BigInteger(new byte[] { 0x01 })));

            //var crl = generator.Generate(DotNetUtilities.GetKeyPair(Issuer.PrivateKey).Private);
            ISignatureFactory factory = new Asn1SignatureFactory(
                "SHA256WithRSA",
                DotNetUtilities.GetKeyPair(Issuer?.GetECDiffieHellmanPrivateKey()).Private);

            var crl = generator.Generate(factory);

            return crl.GetEncoded();
        }

        public byte[] GetOcspResponse(RevocationStatus status, X509Certificate2? ocspResponder = null,
            bool includeResponderCertificateInResponse = true)
        {
            if (status == RevocationStatus.Unknown) return Array.Empty<byte>();

            ocspResponder = ocspResponder switch
            {
                null => Issuer,
                _ => ocspResponder
            };

            var issuerCert = DotNetUtilities.FromX509Certificate(Issuer);
            var responderCert = DotNetUtilities.FromX509Certificate(ocspResponder);
            var gen = new OCSPRespGenerator();

            var basicGen = new BasicOcspRespGenerator(responderCert.GetPublicKey());

            basicGen.AddResponse(
                new CertificateID(CertificateID.HashSha1, issuerCert, SerialNumber),
                status == RevocationStatus.Revoked
                    ? new RevokedStatus(DateTime.UtcNow, CrlReason.CessationOfOperation)
                    : CertificateStatus.Good);

            var certificates = includeResponderCertificateInResponse
                ? new[] { responderCert }
                : Array.Empty<X509Certificate>();

            var response = basicGen.Generate(
                basicGen.SignatureAlgNames.Cast<string>().First(),
                DotNetUtilities.GetKeyPair(ocspResponder?.GetECDiffieHellmanPrivateKey()).Private,
                certificates,
                DateTime.UtcNow);

            var actualResponse = gen.Generate(0, response);

            return actualResponse.GetEncoded();
        }

        private void AddAuthorityKeyIdentifier()
        {
            var authorityKeyIdentifierExtension = new AuthorityKeyIdentifier(
                SubjectPublicKeyInfoFactory.CreateSubjectPublicKeyInfo(_issuerKeyPair.Public),
                new GeneralNames(new GeneralName(new X509Name(_issuerName))),
                _issuerSerialNumber);

            _certificateGenerator.AddExtension(
                X509Extensions.AuthorityKeyIdentifier.Id,
                false,
                authorityKeyIdentifierExtension);
        }

        private void AddBasicConstraints()
        {
            _certificateGenerator.AddExtension(
                X509Extensions.BasicConstraints.Id,
                true,
                new BasicConstraints(IsCertificateAuthority));
        }

        private void AddExtendedKeyUsage()
        {
            if (Usages.Any())
            {
                var usages = Usages.Select(x => _extendedUsagesMap[x]);

                _certificateGenerator.AddExtension(
                    X509Extensions.ExtendedKeyUsage.Id,
                    false,
                    new ExtendedKeyUsage(usages));
            }

            if (Usages.Contains("ocsp"))
                _certificateGenerator.AddExtension(
                    OcspObjectIdentifiers.PkixOcspNocheck.Id,
                    false,
                    Array.Empty<byte>());
        }

        private void AddKeyUsage()
        {
            _certificateGenerator.AddExtension(
                X509Extensions.KeyUsage,
                false,
                new KeyUsage(
                    KeyUsage.DigitalSignature | KeyUsage.KeyCertSign | KeyUsage.CrlSign | KeyUsage.KeyEncipherment));
        }

        private void AddSubjectAlternativeNames()
        {
            // Note that you have to repeat the value from the "Subject Name" property.
            if (SubjectAlternativeNames != null && SubjectAlternativeNames.Any())
            {
                var subjectAlternativeNamesExtension = new DerSequence(
                    SubjectAlternativeNames.Select(name => new GeneralName(GeneralName.DnsName, name))
                        .ToArray<Asn1Encodable>());

                _certificateGenerator.AddExtension(
                    X509Extensions.SubjectAlternativeName.Id,
                    false,
                    subjectAlternativeNamesExtension);
            }
        }

        private void AddSubjectKeyIdentifier()
        {
            var subjectKeyIdentifierExtension = new SubjectKeyIdentifier(
                SubjectPublicKeyInfoFactory.CreateSubjectPublicKeyInfo(_subjectKeyPair.Public));

            _certificateGenerator.AddExtension(
                X509Extensions.SubjectKeyIdentifier.Id,
                false,
                subjectKeyIdentifierExtension);
        }

        private X509Certificate2? ConvertCertificate(X509Certificate certificate)
        {
            var store = new Pkcs12Store();
            var friendlyName = certificate.SubjectDN.ToString();
            var certificateEntry = new X509CertificateEntry(certificate);
            store.SetCertificateEntry(friendlyName, certificateEntry);

            store.SetKeyEntry(
                friendlyName,
                new AsymmetricKeyEntry(_subjectKeyPair.Private),
                new[] { certificateEntry });

            const string password = "1234";
            var stream = new MemoryStream();
            store.Save(stream, password.ToCharArray(), _random);

            return new X509Certificate2(
                stream.ToArray(),
                password,
                X509KeyStorageFlags.PersistKeySet | X509KeyStorageFlags.Exportable);
        }
    }
}