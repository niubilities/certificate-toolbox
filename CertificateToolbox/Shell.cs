using System;
using System.Windows.Forms;
using System.Linq;

namespace CertificateToolbox
{
    public partial class Shell : Form
    {
        private int serialNumber = 1;

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
            var newCert = new CertificateDetails(serialNumber++, LastCert);
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

            ((CertificateDetails)layout.Controls[0]).Issuer = null;
        }
    }
}
