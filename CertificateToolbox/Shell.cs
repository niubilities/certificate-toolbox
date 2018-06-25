using System;
using System.IO;
using System.Windows.Forms;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Org.BouncyCastle.Math;

namespace CertificateToolbox
{
    public partial class Shell : Form
    {
        private BigInteger serialNumber = BigInteger.Zero;

        public Shell()
        {
            InitializeComponent();
        }
        
        public CertificateDetails LastCert
        {
            get { return layout.Controls.Cast<CertificateDetails>().LastOrDefault(); }
        }

        private void save_Click(object sender, EventArgs e)
        {
            save.Enabled = false;

            LastCert?.Generate();

            save.Enabled = true;
        }
        
        private void add_Click(object sender, EventArgs e)
        {
            serialNumber = serialNumber.Add(BigInteger.One);
            var newCert = new CertificateDetails(serialNumber, LastCert);
            newCert.RemoveRequested += Remove;
            layout.Controls.Add(newCert);
        }

        private void Remove(CertificateDetails sender)
        {
            layout.Controls.Remove(sender);

            for (int i = layout.Controls.Count - 1; i > 0; i--)
            {
                ((CertificateDetails)layout.Controls[i]).Issuer = (CertificateDetails)layout.Controls[i - 1];
            }

            if (layout.Controls.Count > 0)
            {
                ((CertificateDetails)layout.Controls[0]).Issuer = null;
            }
        }

        private void Shell_FormClosing(object sender, FormClosingEventArgs e)
        {
            for (int i = layout.Controls.Count - 1; i >= 0; i--)
            {
                ((CertificateDetails)layout.Controls[i]).RemoveExistingCertificate();
            }
        }

        private void clear_cache_Click(object sender, EventArgs e)
        {
            CryptNetCache.Clear();
        }

        private void export_Click(object sender, EventArgs e)
        {
            foreach (CertificateDetails details in layout.Controls)
            {
                Export(details.Certificate);
                Export(details.OcspResponder);
            }
        }

        private void Export(X509Certificate2 certificate)
        {
            if (certificate != null)
            {
                if (is_pfx.Checked)
                {
                    ExportPfx(certificate);
                }

                if (is_pem.Checked)
                {
                    ExportPem(certificate);
                }
            }
        }

        private void ExportPfx(X509Certificate2 certificate)
        {
            var pfxBytes = certificate.Export(X509ContentType.Pfx);
            var commonName = certificate.GetNameInfo(X509NameType.SimpleName, false);
            File.WriteAllBytes(".\\" + commonName + ".pfx", pfxBytes);
        }

        private void ExportPem(X509Certificate2 certificate)
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("-----BEGIN CERTIFICATE-----");
            builder.AppendLine(Convert.ToBase64String(certificate.Export(X509ContentType.Cert), Base64FormattingOptions.InsertLineBreaks));
            builder.AppendLine("-----END CERTIFICATE-----");
            var commonName = certificate.GetNameInfo(X509NameType.SimpleName, false);
            File.WriteAllText(".\\" + commonName + ".pem", builder.ToString());
        }
    }
}
