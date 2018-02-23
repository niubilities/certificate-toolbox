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

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;

            LastCert?.Generate();

            button1.Enabled = true;
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            var newCert = new CertificateDetails(serialNumber++, LastCert);
            layout.Controls.Add(newCert);
        }
    }
}
