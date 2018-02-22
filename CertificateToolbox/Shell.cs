using System;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;
using Org.BouncyCastle.Math;
using System.Linq;

namespace CertificateToolbox
{
    public partial class Shell : Form
    {
        public Shell()
        {
            InitializeComponent();
        }

        public CertificateDetails LastCert => layout.Controls.Cast<CertificateDetails>().LastOrDefault();

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;

            LastCert.Generate();

            button1.Enabled = true;
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            var newCert = new CertificateDetails {Issuer = LastCert};
            layout.Controls.Add(newCert);
        }
    }
}
