using System;
using System.Linq;
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
            subject.Text = string.Format("CN={0} {1}", Environment.MachineName, serialNumber);

            store_name.DataSource = Enum.GetValues(typeof(StoreName));
            store_name.SelectedItem = StoreName.Root;

            not_before.Value = DateTime.UtcNow.AddDays(-1);
            not_after.Value = DateTime.UtcNow.AddYears(100);

            subject_alternative_names.ReadOnly = is_ca.Checked;
            key_usages.ReadOnly = is_ca.Checked;

            ocsp_url.Text = string.Format("http://{0}:{1}/ca.ocsp", Environment.MachineName, 8080 + serialNumber);
            crl_url.Text = string.Format("http://{0}:{1}/ca.crl", Environment.MachineName, 8180 + serialNumber);
        }

        public string SubjectAlternativeNames
        {
            get { return Serialize(subject_alternative_names.Rows); }
        }

        public string KeyUsages
        {
            get { return Serialize(key_usages.Rows);  }
        }

        private string Serialize(DataGridViewRowCollection rows)
        {
            var items = (from DataGridViewRow row in rows where row.Cells[0].Value != null select row.Cells[0].Value.ToString()).ToList();
            return items.Any() ? string.Join("#", items) : null;
        }

        public X509Certificate2 Generate()
        {
            RemoveExistingCertificate();

            UpdateThumbprint(string.Empty);

            var certificate = GenerateCertificate();

            if (install_store.Checked)
            {
                Install(certificate);
            }

            UpdateThumbprint(certificate.Thumbprint);

            return certificate;
        }

        private void RemoveExistingCertificate()
        {
            if (string.IsNullOrEmpty(thumbprint.Text)) return;

            foreach(StoreName storeName in Enum.GetValues(typeof(StoreName)))
            {
                var store = new X509Store(storeName, StoreLocation.LocalMachine);
                store.Open(OpenFlags.ReadWrite | OpenFlags.MaxAllowed);
                var certificates = store.Certificates.Find(X509FindType.FindByThumbprint, thumbprint.Text, false);
                if (certificates.Count == 1)
                {
                    store.Remove(certificates[0]);
                }
                store.Close();
            }
        }

        private void Install(X509Certificate2 certificate)
        {
            var store = new X509Store((StoreName)store_name.SelectedItem, StoreLocation.LocalMachine);
            store.Open(OpenFlags.ReadWrite);
            store.Add(certificate);
            store.Close();
        }

        private X509Certificate2 GenerateCertificate()
        {
            var generator = new Generator
            {
                SerialNumber = new BigInteger(serial.Text),
                SubjectName = subject.Text,
                NotBefore = not_before.Value,
                NotAfter = not_after.Value,
                IsCertificateAuthority = is_ca.Checked,
                Issuer = Issuer?.Generate(),
                SubjectAlternativeNames = SubjectAlternativeNames?.Split('#'),
                Usages = KeyUsages?.Split('#'),
                OcspEndpoint = include_ocsp.Checked ? ocsp_url.Text : null,
                CrlEndpoint = include_crl.Checked ? crl_url.Text : null,
            };

            return generator.Generate();
        }

        private void UpdateThumbprint(string value)
        {
            thumbprint.Text = value;
            Refresh();
        }

        private void is_ca_CheckedChanged(object sender, EventArgs e)
        {
            subject_alternative_names.ReadOnly = is_ca.Checked;
            key_usages.ReadOnly = is_ca.Checked;

            if (is_ca.Checked)
            {
                subject_alternative_names.Rows.Clear();
                key_usages.Rows.Clear();
            }
        }
    }
}
