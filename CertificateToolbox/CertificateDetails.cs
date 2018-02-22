using System;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;
using Org.BouncyCastle.Crypto.Prng;
using Org.BouncyCastle.Math;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.Utilities;

namespace CertificateToolbox
{
    public partial class CertificateDetails : UserControl
    {
        public Control Issuer { get; set; }

        public CertificateDetails()
        {
            InitializeComponent();

            not_before.Value = DateTime.UtcNow.AddDays(-1);
            not_after.Value = DateTime.UtcNow.AddYears(100);
        }

        public X509Certificate2 Generate()
        {
            var generator = new Generator
            {
                SerialNumber = BigIntegers.CreateRandomInRange(BigInteger.One, BigInteger.ValueOf(Int64.MaxValue), new SecureRandom(new CryptoApiRandomGenerator())),
                SubjectName = subject.Text,
                NotBefore = not_before.Value,
                NotAfter = not_after.Value,
                IsCertificateAuthority = true,
                Issuer = ((CertificateDetails)Issuer)?.Generate()
            };

            var certificate = generator.Generate();

            var store = new X509Store(StoreName.Root, StoreLocation.LocalMachine);
            store.Open(OpenFlags.ReadWrite);
            store.Add(certificate);
            store.Close();

            return certificate;
        }
    }
}
