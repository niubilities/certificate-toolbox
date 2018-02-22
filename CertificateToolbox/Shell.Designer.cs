namespace CertificateToolbox
{
    partial class Shell
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.certificateDetails3 = new CertificateToolbox.CertificateDetails();
            this.certificateDetails2 = new CertificateToolbox.CertificateDetails();
            this.certificateDetails1 = new CertificateToolbox.CertificateDetails();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1111, 535);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 66;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // certificateDetails3
            // 
            this.certificateDetails3.Issuer = this.certificateDetails2;
            this.certificateDetails3.Location = new System.Drawing.Point(677, 14);
            this.certificateDetails3.Name = "certificateDetails3";
            this.certificateDetails3.Size = new System.Drawing.Size(292, 235);
            this.certificateDetails3.TabIndex = 67;
            // 
            // certificateDetails2
            // 
            this.certificateDetails2.Issuer = this.certificateDetails1;
            this.certificateDetails2.Location = new System.Drawing.Point(350, 14);
            this.certificateDetails2.Name = "certificateDetails2";
            this.certificateDetails2.Size = new System.Drawing.Size(292, 235);
            this.certificateDetails2.TabIndex = 67;
            // 
            // certificateDetails1
            // 
            this.certificateDetails1.Issuer = null;
            this.certificateDetails1.Location = new System.Drawing.Point(22, 14);
            this.certificateDetails1.Name = "certificateDetails1";
            this.certificateDetails1.Size = new System.Drawing.Size(292, 235);
            this.certificateDetails1.TabIndex = 67;
            // 
            // Shell
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1248, 605);
            this.Controls.Add(this.certificateDetails3);
            this.Controls.Add(this.certificateDetails2);
            this.Controls.Add(this.certificateDetails1);
            this.Controls.Add(this.button1);
            this.Name = "Shell";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private CertificateDetails certificateDetails1;
        private CertificateDetails certificateDetails2;
        private CertificateDetails certificateDetails3;
    }
}

