namespace CertificateToolbox
{
    partial class CertificateDetails
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.not_after = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.not_before = new System.Windows.Forms.DateTimePicker();
            this.subject = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // not_after
            // 
            this.not_after.Location = new System.Drawing.Point(36, 166);
            this.not_after.Name = "not_after";
            this.not_after.Size = new System.Drawing.Size(222, 20);
            this.not_after.TabIndex = 68;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(35, 150);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 71;
            this.label3.Text = "Not After";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 70;
            this.label2.Text = "Not Before";
            // 
            // not_before
            // 
            this.not_before.Location = new System.Drawing.Point(38, 115);
            this.not_before.Name = "not_before";
            this.not_before.Size = new System.Drawing.Size(220, 20);
            this.not_before.TabIndex = 67;
            // 
            // subject
            // 
            this.subject.Location = new System.Drawing.Point(38, 64);
            this.subject.Name = "subject";
            this.subject.Size = new System.Drawing.Size(220, 20);
            this.subject.TabIndex = 66;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 13);
            this.label1.TabIndex = 69;
            this.label1.Text = "Subject Distinguished Name";
            // 
            // CertificateDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.not_after);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.not_before);
            this.Controls.Add(this.subject);
            this.Controls.Add(this.label1);
            this.Name = "CertificateDetails";
            this.Size = new System.Drawing.Size(292, 235);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker not_after;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker not_before;
        private System.Windows.Forms.TextBox subject;
        private System.Windows.Forms.Label label1;
    }
}
