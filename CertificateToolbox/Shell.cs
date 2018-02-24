using System;
using System.Windows.Forms;
using System.Linq;
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
        
        public CertificateDetails LastCert => layout.Controls.Cast<CertificateDetails>().LastOrDefault();

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
    }
}
