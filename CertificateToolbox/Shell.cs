using System;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;
using Org.BouncyCastle.Math;

namespace CertificateToolbox
{
    public partial class Shell : Form
    {
        public Shell()
        {
            InitializeComponent();

            not_before.Value = DateTime.UtcNow.AddDays(-1);
            not_after.Value = DateTime.UtcNow.AddYears(100);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;

            var generator = new Generator
            {
                SerialNumber = new BigInteger("1"),
                SubjectName = subject.Text,
                NotBefore = not_before.Value,
                NotAfter = not_after.Value,
                IsCertificateAuthority = true
            };

            var certificate = generator.Generate();

            var store = new X509Store(StoreName.Root, StoreLocation.LocalMachine);
            store.Open(OpenFlags.ReadWrite);
            store.Add(certificate);
            store.Close();

            button1.Enabled = true;
        }
    }
}
