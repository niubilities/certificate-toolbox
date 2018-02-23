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
            layout.Controls.Add(newCert);
        }
    }
}
