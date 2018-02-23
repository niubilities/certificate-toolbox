using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;
using Org.BouncyCastle.Math;

namespace CertificateToolbox
{
    public partial class CertificateDetails : UserControl
    {
        public X509Certificate2 Certificate { get; set; }
        public CertificateDetails Issuer { get; set; }

        private readonly CrlServer crlServer;

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

            ocsp_result.DataSource = Enum.GetValues(typeof(RevocationStatus));
            crl_result.DataSource = Enum.GetValues(typeof(RevocationStatus));

            crlServer = new CrlServer
            {
                CrlUrl = crl_url.Text,
                GetStatus = () =>
                {
                    RevocationStatus result = RevocationStatus.Valid;
                    Invoke(new MethodInvoker(delegate { result = GetCrlStatus(); }));
                    return result;
                },
                GetCrl = ()=>
                {
                    byte[] result = null;
                    Invoke(new MethodInvoker(delegate { result = GetCrl(); }));
                    return result;
                }
            };
        }

        private RevocationStatus GetCrlStatus()
        {
            return (RevocationStatus)crl_result.SelectedItem;
        }

        private BigInteger GetSerialNumber()
        {
            return new BigInteger(serial.Text);
        }

        private byte[] GetCrl()
        {
            var generator = new Generator
            {
                Issuer = Issuer == null ? Certificate : Issuer.Certificate,
                SerialNumber = GetSerialNumber(),
            };
            return generator.GetCrl(GetCrlStatus());
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
            crlServer.Stop();

            RemoveExistingCertificate();

            ClearThumbprint();

            Certificate = GenerateCertificate();

            if (install_store.Checked)
            {
                InstallNewCertificate();
            }

            UpdateThumbprint();

            crlServer.Start();

            return Certificate;
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

        private void InstallNewCertificate()
        {
            var store = new X509Store((StoreName)store_name.SelectedItem, StoreLocation.LocalMachine);
            store.Open(OpenFlags.ReadWrite);
            store.Add(Certificate);
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

        private void ClearThumbprint()
        {
            thumbprint.Clear();
            Refresh();
        }

        private void UpdateThumbprint()
        {
            thumbprint.Text = Certificate.Thumbprint;
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

        public event Action<CertificateDetails> RemoveRequested;

        private void remove_Click(object sender, EventArgs e)
        {
            RemoveExistingCertificate();
            crlServer.Stop();
            RemoveRequested?.Invoke(this);
        }

        private void copy_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(thumbprint.Text);
        }
    }
}
