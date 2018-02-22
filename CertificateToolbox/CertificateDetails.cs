using System;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;
using Org.BouncyCastle.Math;

namespace CertificateToolbox
{
    public partial class CertificateDetails : UserControl
    {
        public CertificateDetails Issuer { get; set; }

        public CertificateDetails()
        {
            InitializeComponent();
        }

        public CertificateDetails(int serialNumber, CertificateDetails issuer)
        {
            InitializeComponent();

            Issuer = issuer;

            serial.Text = serialNumber.ToString();
            subject.Text = "CN=Mihai" + serialNumber;

            store_location.DataSource = Enum.GetValues(typeof(StoreLocation));
            store_name.DataSource = Enum.GetValues(typeof(StoreName));

            store_location.SelectedItem = StoreLocation.LocalMachine;
            store_name.SelectedItem = StoreName.Root;

            not_before.Value = DateTime.UtcNow.AddDays(-1);
            not_after.Value = DateTime.UtcNow.AddYears(100);
        }

        public X509Certificate2 Generate()
        {
            var generator = new Generator
            {
                SerialNumber = new BigInteger(serial.Text),
                SubjectName = subject.Text,
                NotBefore = not_before.Value,
                NotAfter = not_after.Value,
                IsCertificateAuthority = true,
                Issuer = Issuer?.Generate()
            };

            var certificate = generator.Generate();

            if (install_store.Checked)
            {
                var store = new X509Store((StoreName)store_name.SelectedItem, (StoreLocation)store_location.SelectedItem);
                store.Open(OpenFlags.ReadWrite);
                store.Add(certificate);
                store.Close();
            }

            return certificate;
        }
    }
}
