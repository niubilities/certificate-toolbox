namespace CertificateToolbox
{
    partial class RevocationEndpoint
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.result = new System.Windows.Forms.ComboBox();
            this.url = new System.Windows.Forms.TextBox();
            this.include = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.result);
            this.groupBox2.Controls.Add(this.url);
            this.groupBox2.Controls.Add(this.include);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(282, 95);
            this.groupBox2.TabIndex = 63;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Type";
            // 
            // result
            // 
            this.result.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.result.FormattingEnabled = true;
            this.result.Location = new System.Drawing.Point(55, 54);
            this.result.Name = "result";
            this.result.Size = new System.Drawing.Size(143, 21);
            this.result.TabIndex = 65;
            this.result.SelectedIndexChanged += new System.EventHandler(this.result_SelectedIndexChanged);
            // 
            // url
            // 
            this.url.Location = new System.Drawing.Point(14, 19);
            this.url.Name = "url";
            this.url.ReadOnly = true;
            this.url.Size = new System.Drawing.Size(184, 20);
            this.url.TabIndex = 0;
            // 
            // include
            // 
            this.include.AutoSize = true;
            this.include.Checked = true;
            this.include.CheckState = System.Windows.Forms.CheckState.Checked;
            this.include.Location = new System.Drawing.Point(204, 21);
            this.include.Name = "include";
            this.include.Size = new System.Drawing.Size(61, 17);
            this.include.TabIndex = 1;
            this.include.Text = "Include";
            this.include.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 57);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 13);
            this.label5.TabIndex = 64;
            this.label5.Text = "Result";
            // 
            // RevocationEndpoint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox2);
            this.Name = "RevocationEndpoint";
            this.Size = new System.Drawing.Size(292, 104);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox result;
        private System.Windows.Forms.TextBox url;
        private System.Windows.Forms.CheckBox include;
        private System.Windows.Forms.Label label5;
    }
}
