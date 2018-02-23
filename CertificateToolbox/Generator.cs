﻿using System;
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
using Org.BouncyCastle.X509;
using X509Certificate2 = System.Security.Cryptography.X509Certificates.X509Certificate2;
using X509KeyStorageFlags = System.Security.Cryptography.X509Certificates.X509KeyStorageFlags;

namespace CertificateToolbox
{
    public class Generator
    {
        public BigInteger SerialNumber { get; set; }
        public string SubjectName { get; set; }
        public DateTime NotBefore { get; set; }
        public DateTime NotAfter { get; set; }
        public X509Certificate2 Issuer { get; set; }
        public string[] SubjectAlternativeNames { get; set; }
        public string[] Usages { get; set; }
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
            random = new SecureRandom(new CryptoApiRandomGenerator());
            certificateGenerator = new X509V3CertificateGenerator();
        }

        public X509Certificate2 Generate()
        {
            subjectKeyPair = GenerateKeyPair(2048);
            
            if (Issuer == null)
            {
                issuerKeyPair = subjectKeyPair;
                issuerName = SubjectName;
                issuerSerialNumber = SerialNumber; 
            }
            else
            {
                issuerName = Issuer.Subject;
                issuerKeyPair = DotNetUtilities.GetKeyPair(Issuer.PrivateKey);
                issuerSerialNumber = new BigInteger(Issuer.GetSerialNumber());
            }
            
            certificateGenerator.SetSerialNumber(SerialNumber);
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
        
        private AsymmetricCipherKeyPair GenerateKeyPair(int bitLength)
        {
            var keyGenerationParameters = new KeyGenerationParameters(random, bitLength);

            var keyPairGenerator = new RsaKeyPairGenerator();
            keyPairGenerator.Init(keyGenerationParameters);
            return keyPairGenerator.GenerateKeyPair();
        }

        private void AddAuthorityKeyIdentifier()
        {
            var authorityKeyIdentifierExtension = new AuthorityKeyIdentifier(SubjectPublicKeyInfoFactory.CreateSubjectPublicKeyInfo(issuerKeyPair.Public), new GeneralNames(new GeneralName(new X509Name(issuerName))), issuerSerialNumber);
            certificateGenerator.AddExtension(X509Extensions.AuthorityKeyIdentifier.Id, false, authorityKeyIdentifierExtension);
        }
        
        private void AddSubjectAlternativeNames()
        {
            // Note that you have to repeat the value from the "Subject Name" property.
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
                var usages = Usages.Select(x => x == "client" ? KeyPurposeID.IdKPClientAuth : KeyPurposeID.IdKPServerAuth);
                certificateGenerator.AddExtension(X509Extensions.ExtendedKeyUsage.Id, false, new ExtendedKeyUsage(usages));
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
            var store = new Pkcs12Store();
            string friendlyName = certificate.SubjectDN.ToString();
            var certificateEntry = new X509CertificateEntry(certificate);
            store.SetCertificateEntry(friendlyName, certificateEntry);
            store.SetKeyEntry(friendlyName, new AsymmetricKeyEntry(subjectKeyPair.Private), new[] { certificateEntry });

            const string password = "1234";
            var stream = new MemoryStream();
            store.Save(stream, password.ToCharArray(), random);

            return new X509Certificate2(stream.ToArray(), password, X509KeyStorageFlags.PersistKeySet | X509KeyStorageFlags.Exportable);
        }
    }
}
