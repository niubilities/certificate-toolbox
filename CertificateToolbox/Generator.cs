using System;
using System.IO;
using System.Linq;
using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Generators;
using Org.BouncyCastle.Crypto.Prng;
using Org.BouncyCastle.Math;
using Org.BouncyCastle.Pkcs;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.Utilities;
using Org.BouncyCastle.X509;
using X509Certificate2 = System.Security.Cryptography.X509Certificates.X509Certificate2;
using X509KeyStorageFlags = System.Security.Cryptography.X509Certificates.X509KeyStorageFlags;

namespace CertificateToolbox
{
    public class Generator
    {
        public string SubjectName { get; set; }
        public DateTime NotBefore { get; set; }
        public DateTime NotAfter { get; set; }
        public X509Certificate2 Issuer { get; set; }
        public string[] SubjectAlternativeNames { get; set; }
        public KeyPurposeID[] Usages { get; set; }
        public bool IsCertificateAuthority { get; set; }
        public string OcspEndpoint { get; set; }
        public string CrlEndpoint { get; set; }

        private readonly SecureRandom random;
        private readonly X509V3CertificateGenerator certificateGenerator;

        private string issuerName;
        private BigInteger issuerSerialNumber;
        private AsymmetricCipherKeyPair issuerKeyPair;
        private AsymmetricCipherKeyPair subjectKeyPair;
        
        public Generator()
        {
            // Since we're on Windows, we'll use the CryptoAPI one (on the assumption
            // that it might have access to better sources of entropy than the Bouncy Castle ones):
            random = new SecureRandom(new CryptoApiRandomGenerator());

            certificateGenerator = new X509V3CertificateGenerator();
        }

        public X509Certificate2 Generate()
        {
            var serialNumber = GenerateSerialNumber();
            subjectKeyPair = GenerateKeyPair(2048);
            
            if (Issuer == null)
            {
                issuerKeyPair = subjectKeyPair;
                issuerName = SubjectName;
                issuerSerialNumber = serialNumber; 
            }
            else
            {
                issuerName = Issuer.Subject;
                issuerKeyPair = DotNetUtilities.GetKeyPair(Issuer.PrivateKey);
                issuerSerialNumber = new BigInteger(Issuer.GetSerialNumber());
            }
            
            certificateGenerator.SetSerialNumber(serialNumber);
            certificateGenerator.SetSignatureAlgorithm("SHA256WithRSA");
            certificateGenerator.SetIssuerDN(new X509Name(issuerName));
            certificateGenerator.SetSubjectDN(new X509Name(SubjectName));
            certificateGenerator.SetNotBefore(NotBefore);
            certificateGenerator.SetNotAfter(NotAfter);
            certificateGenerator.SetPublicKey(subjectKeyPair.Public);
            AddAuthorityKeyIdentifier();
            AddSubjectKeyIdentifier();
            AddBasicConstraints();
            AddExtendedKeyUsage();
            AddSubjectAlternativeNames();
            AddOcspPoints();
            AddCrlDistributionPoints();

            var certificate = certificateGenerator.Generate(issuerKeyPair.Private);

            return ConvertCertificate(certificate);
        }

        /// <summary>
        /// The certificate needs a serial number. This is used for revocation,
        /// and usually should be an incrementing index (which makes it easier to revoke a range of certificates).
        /// Since we don't have anywhere to store the incrementing index, we can just use a random number.
        /// </summary>
        /// <returns></returns>
        private BigInteger GenerateSerialNumber()
        {
            return BigIntegers.CreateRandomInRange(BigInteger.One, BigInteger.ValueOf(Int64.MaxValue), random);
        }

        /// <summary>
        /// Generate a key pair.
        /// </summary>
        /// <param name="strength">The key length in bits. For RSA, 2048 bits should be considered the minimum acceptable these days.</param>
        /// <returns></returns>
        private AsymmetricCipherKeyPair GenerateKeyPair(int strength)
        {
            var keyGenerationParameters = new KeyGenerationParameters(random, strength);

            var keyPairGenerator = new RsaKeyPairGenerator();
            keyPairGenerator.Init(keyGenerationParameters);
            return keyPairGenerator.GenerateKeyPair();
        }

        /// <summary>
        /// Add the Authority Key Identifier. According to http://www.alvestrand.no/objectid/2.5.29.35.html, this
        /// identifies the public key to be used to verify the signature on this certificate.
        /// In a certificate chain, this corresponds to the "Subject Key Identifier" on the *issuer* certificate.
        /// The Bouncy Castle documentation, at http://www.bouncycastle.org/wiki/display/JA1/X.509+Public+Key+Certificate+and+Certification+Request+Generation,
        /// shows how to create this from the issuing certificate. Since we're creating a self-signed certificate, we have to do this slightly differently.
        /// </summary>
        private void AddAuthorityKeyIdentifier()
        {
            var authorityKeyIdentifierExtension = new AuthorityKeyIdentifier(SubjectPublicKeyInfoFactory.CreateSubjectPublicKeyInfo(issuerKeyPair.Public), new GeneralNames(new GeneralName(new X509Name(issuerName))), issuerSerialNumber);
            certificateGenerator.AddExtension(X509Extensions.AuthorityKeyIdentifier.Id, false, authorityKeyIdentifierExtension);
        }

        /// <summary>
        /// Add the "Subject Alternative Names" extension. Note that you have to repeat the value from the "Subject Name" property.
        /// </summary>
        private void AddSubjectAlternativeNames()
        {
            if (SubjectAlternativeNames != null && SubjectAlternativeNames.Any())
            {
                var subjectAlternativeNamesExtension = new DerSequence(SubjectAlternativeNames.Select(name => new GeneralName(GeneralName.DnsName, name)).ToArray<Asn1Encodable>());
                certificateGenerator.AddExtension(X509Extensions.SubjectAlternativeName.Id, false, subjectAlternativeNamesExtension);
            }
        }
        
        private void AddExtendedKeyUsage()
        {
            if (Usages != null && Usages.Any())
            {
                certificateGenerator.AddExtension(X509Extensions.ExtendedKeyUsage.Id, false, new ExtendedKeyUsage(Usages));
            }
        }
        
        private void AddBasicConstraints()
        {
            certificateGenerator.AddExtension(X509Extensions.BasicConstraints.Id, true, new BasicConstraints(IsCertificateAuthority));
        }
        
        private void AddSubjectKeyIdentifier()
        {
            var subjectKeyIdentifierExtension = new SubjectKeyIdentifier(SubjectPublicKeyInfoFactory.CreateSubjectPublicKeyInfo(subjectKeyPair.Public));
            certificateGenerator.AddExtension(X509Extensions.SubjectKeyIdentifier.Id, false, subjectKeyIdentifierExtension);
        }

        public void AddOcspPoints()
        {
            if (!string.IsNullOrEmpty(OcspEndpoint))
            {
                GeneralName generalName = new GeneralName(GeneralName.UniformResourceIdentifier, new DerIA5String(OcspEndpoint));
                var authorityInformationAccess = new AuthorityInformationAccess(new AccessDescription(X509ObjectIdentifiers.OcspAccessMethod, generalName));
                certificateGenerator.AddExtension(X509Extensions.AuthorityInfoAccess, false, authorityInformationAccess);
            }
        }

        public void AddCrlDistributionPoints()
        {
            if (!string.IsNullOrEmpty(CrlEndpoint))
            {
                var generalName = new GeneralName(GeneralName.UniformResourceIdentifier, new DerIA5String(CrlEndpoint));
                var gns = new GeneralNames(generalName);
                var dpn = new DistributionPointName(gns);
                var distp = new DistributionPoint(dpn, null, null);
                var seq = new DerSequence(distp);

                certificateGenerator.AddExtension(X509Extensions.CrlDistributionPoints, false, seq);
            }
        }

        private X509Certificate2 ConvertCertificate(X509Certificate certificate)
        {
            // Now to convert the Bouncy Castle certificate to a .NET certificate.
            // See http://web.archive.org/web/20100504192226/http://www.fkollmann.de/v2/post/Creating-certificates-using-BouncyCastle.aspx
            // ...but, basically, we create a PKCS12 store (a .PFX file) in memory, and add the public and private key to that.
            var store = new Pkcs12Store();

            // What Bouncy Castle calls "alias" is the same as what Windows terms the "friendly name".
            string friendlyName = certificate.SubjectDN.ToString();

            // Add the certificate.
            var certificateEntry = new X509CertificateEntry(certificate);
            store.SetCertificateEntry(friendlyName, certificateEntry);

            // Add the private key.
            store.SetKeyEntry(friendlyName, new AsymmetricKeyEntry(subjectKeyPair.Private), new[] { certificateEntry });

            // Convert it to an X509Certificate2 object by saving/loading it from a MemoryStream.
            // It needs a password. Since we'll remove this later, it doesn't particularly matter what we use.
            const string password = "password";
            var stream = new MemoryStream();
            store.Save(stream, password.ToCharArray(), random);

            var convertedCertificate = new X509Certificate2(stream.ToArray(), password, X509KeyStorageFlags.PersistKeySet | X509KeyStorageFlags.Exportable);
            return convertedCertificate;
        }
    }
}
