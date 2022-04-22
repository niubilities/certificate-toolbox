namespace CertificateToolbox
{
    using System.Security.Cryptography.X509Certificates;
    using System.Text;
    using Org.BouncyCastle.Math;

    public partial class Shell : Form
    {
        private BigInteger _serialNumber = BigInteger.Zero;

        public Shell()
        {
            InitializeComponent();
        }

        public CertificateDetails? LastCert => layout.Controls.Cast<CertificateDetails>().LastOrDefault();

        private void add_Click(object sender, EventArgs e)
        {
            _serialNumber = _serialNumber.Add(BigInteger.One);
            var newCert = new CertificateDetails(_serialNumber, LastCert);
            newCert.RemoveRequested += Remove;
            layout.Controls.Add(newCert);
        }

        private void clear_cache_Click(object sender, EventArgs e)
        {
            CryptNetCache.Clear();
        }

        private void Export(X509Certificate2 certificate)
        {
            if (certificate != null)
            {
                if (is_pfx.Checked) ExportPfx(certificate);

                if (is_pem.Checked) ExportPem(certificate);
            }
        }

        private void export_Click(object sender, EventArgs e)
        {
            foreach (CertificateDetails details in layout.Controls)
            {
                Export(details.Certificate);
                Export(details.OcspResponder);
            }

            //var er = layout.Controls.GetEnumerator();
            //while (er != null && er.MoveNext())
            //{
            //    Export((er.Current as CertificateDetails)?.Certificate);
            //    Export((er.Current as CertificateDetails)?.OcspResponder);
            //}
        }

        private void ExportPem(X509Certificate2 certificate)
        {
            var builder = new StringBuilder();
            builder.AppendLine("-----BEGIN CERTIFICATE-----");

            builder.AppendLine(
                Convert.ToBase64String(
                    certificate.Export(X509ContentType.Cert),
                    Base64FormattingOptions.InsertLineBreaks));

            builder.AppendLine("-----END CERTIFICATE-----");
            var commonName = certificate.GetNameInfo(X509NameType.SimpleName, false);
            File.WriteAllText(".\\" + commonName + ".pem", builder.ToString());
        }

        private void ExportPfx(X509Certificate2 certificate)
        {
            var pfxBytes = certificate.Export(X509ContentType.Pfx);
            var commonName = certificate.GetNameInfo(X509NameType.SimpleName, false);
            File.WriteAllBytes(".\\" + commonName + ".pfx", pfxBytes);
        }

        private void Remove(CertificateDetails sender)
        {
            layout.Controls.Remove(sender);

            for (var i = layout.Controls.Count - 1; i > 0; i--)
                ((CertificateDetails)layout.Controls[i]).Issuer = (CertificateDetails)layout.Controls[i - 1];

            ((CertificateDetails)layout.Controls[0]).Issuer = layout.Controls.Count switch
            {
                > 0 => null,
                _ => ((CertificateDetails)layout.Controls[0]).Issuer
            };
        }

        private void save_Click(object sender, EventArgs e)
        {
            save.Enabled = false;

            LastCert?.Generate();

            save.Enabled = true;
        }

        private void Shell_FormClosing(object sender, FormClosingEventArgs e)
        {
            for (var i = layout.Controls.Count - 1; i >= 0; i--)
                ((CertificateDetails)layout.Controls[i]).RemoveExistingCertificate();
        }
    }
}