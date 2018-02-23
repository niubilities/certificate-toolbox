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
            this.KeyUsage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.key_usages = new System.Windows.Forms.DataGridView();
            this.SubjectAlternativeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.subject_alternative_names = new System.Windows.Forms.DataGridView();
            this.is_ca = new System.Windows.Forms.CheckBox();
            this.crl_revoked = new System.Windows.Forms.RadioButton();
            this.crl_valid = new System.Windows.Forms.RadioButton();
            this.crl_url = new System.Windows.Forms.TextBox();
            this.include_crl = new System.Windows.Forms.CheckBox();
            this.ocsp_unknown = new System.Windows.Forms.RadioButton();
            this.ocsp_revoked = new System.Windows.Forms.RadioButton();
            this.crl_unknown = new System.Windows.Forms.RadioButton();
            this.ocsp_valid = new System.Windows.Forms.RadioButton();
            this.not_before = new System.Windows.Forms.DateTimePicker();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ocsp_url = new System.Windows.Forms.TextBox();
            this.include_ocsp = new System.Windows.Forms.CheckBox();
            this.install_store = new System.Windows.Forms.CheckBox();
            this.subject = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.store_name = new System.Windows.Forms.ComboBox();
            this.store_location = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.serial = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.thumbprint = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.key_usages)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.subject_alternative_names)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // not_after
            // 
            this.not_after.Location = new System.Drawing.Point(17, 316);
            this.not_after.Name = "not_after";
            this.not_after.Size = new System.Drawing.Size(222, 20);
            this.not_after.TabIndex = 53;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 300);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 65;
            this.label3.Text = "Not After";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 249);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 64;
            this.label2.Text = "Not Before";
            // 
            // KeyUsage
            // 
            this.KeyUsage.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.KeyUsage.HeaderText = "Key Usage";
            this.KeyUsage.Name = "KeyUsage";
            this.KeyUsage.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // key_usages
            // 
            this.key_usages.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.key_usages.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.KeyUsage});
            this.key_usages.Location = new System.Drawing.Point(19, 530);
            this.key_usages.Name = "key_usages";
            this.key_usages.Size = new System.Drawing.Size(265, 124);
            this.key_usages.TabIndex = 56;
            // 
            // SubjectAlternativeName
            // 
            this.SubjectAlternativeName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.SubjectAlternativeName.HeaderText = "Subject Alternative Name";
            this.SubjectAlternativeName.Name = "SubjectAlternativeName";
            // 
            // subject_alternative_names
            // 
            this.subject_alternative_names.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.subject_alternative_names.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SubjectAlternativeName});
            this.subject_alternative_names.Location = new System.Drawing.Point(19, 400);
            this.subject_alternative_names.Name = "subject_alternative_names";
            this.subject_alternative_names.Size = new System.Drawing.Size(265, 124);
            this.subject_alternative_names.TabIndex = 55;
            // 
            // is_ca
            // 
            this.is_ca.AutoSize = true;
            this.is_ca.Checked = true;
            this.is_ca.CheckState = System.Windows.Forms.CheckState.Checked;
            this.is_ca.Location = new System.Drawing.Point(19, 366);
            this.is_ca.Name = "is_ca";
            this.is_ca.Size = new System.Drawing.Size(128, 17);
            this.is_ca.TabIndex = 54;
            this.is_ca.Text = "Is Certificate Authority";
            this.is_ca.UseVisualStyleBackColor = true;
            this.is_ca.CheckedChanged += new System.EventHandler(this.is_ca_CheckedChanged);
            // 
            // crl_revoked
            // 
            this.crl_revoked.AutoSize = true;
            this.crl_revoked.Location = new System.Drawing.Point(88, 55);
            this.crl_revoked.Name = "crl_revoked";
            this.crl_revoked.Size = new System.Drawing.Size(69, 17);
            this.crl_revoked.TabIndex = 3;
            this.crl_revoked.TabStop = true;
            this.crl_revoked.Text = "Revoked";
            this.crl_revoked.UseVisualStyleBackColor = true;
            // 
            // crl_valid
            // 
            this.crl_valid.AutoSize = true;
            this.crl_valid.Checked = true;
            this.crl_valid.Location = new System.Drawing.Point(14, 55);
            this.crl_valid.Name = "crl_valid";
            this.crl_valid.Size = new System.Drawing.Size(48, 17);
            this.crl_valid.TabIndex = 2;
            this.crl_valid.TabStop = true;
            this.crl_valid.Text = "Valid";
            this.crl_valid.UseVisualStyleBackColor = true;
            // 
            // crl_url
            // 
            this.crl_url.Location = new System.Drawing.Point(14, 19);
            this.crl_url.Name = "crl_url";
            this.crl_url.ReadOnly = true;
            this.crl_url.Size = new System.Drawing.Size(184, 20);
            this.crl_url.TabIndex = 0;
            this.crl_url.Text = "http://EESSIDEV04:8081/ca.crl";
            // 
            // include_crl
            // 
            this.include_crl.AutoSize = true;
            this.include_crl.Location = new System.Drawing.Point(204, 21);
            this.include_crl.Name = "include_crl";
            this.include_crl.Size = new System.Drawing.Size(61, 17);
            this.include_crl.TabIndex = 1;
            this.include_crl.Text = "Include";
            this.include_crl.UseVisualStyleBackColor = true;
            // 
            // ocsp_unknown
            // 
            this.ocsp_unknown.AutoSize = true;
            this.ocsp_unknown.Location = new System.Drawing.Point(182, 54);
            this.ocsp_unknown.Name = "ocsp_unknown";
            this.ocsp_unknown.Size = new System.Drawing.Size(71, 17);
            this.ocsp_unknown.TabIndex = 4;
            this.ocsp_unknown.TabStop = true;
            this.ocsp_unknown.Text = "Unknown";
            this.ocsp_unknown.UseVisualStyleBackColor = true;
            // 
            // ocsp_revoked
            // 
            this.ocsp_revoked.AutoSize = true;
            this.ocsp_revoked.Location = new System.Drawing.Point(88, 55);
            this.ocsp_revoked.Name = "ocsp_revoked";
            this.ocsp_revoked.Size = new System.Drawing.Size(69, 17);
            this.ocsp_revoked.TabIndex = 3;
            this.ocsp_revoked.TabStop = true;
            this.ocsp_revoked.Text = "Revoked";
            this.ocsp_revoked.UseVisualStyleBackColor = true;
            // 
            // crl_unknown
            // 
            this.crl_unknown.AutoSize = true;
            this.crl_unknown.Location = new System.Drawing.Point(182, 54);
            this.crl_unknown.Name = "crl_unknown";
            this.crl_unknown.Size = new System.Drawing.Size(71, 17);
            this.crl_unknown.TabIndex = 4;
            this.crl_unknown.TabStop = true;
            this.crl_unknown.Text = "Unknown";
            this.crl_unknown.UseVisualStyleBackColor = true;
            // 
            // ocsp_valid
            // 
            this.ocsp_valid.AutoSize = true;
            this.ocsp_valid.Checked = true;
            this.ocsp_valid.Location = new System.Drawing.Point(14, 55);
            this.ocsp_valid.Name = "ocsp_valid";
            this.ocsp_valid.Size = new System.Drawing.Size(48, 17);
            this.ocsp_valid.TabIndex = 2;
            this.ocsp_valid.TabStop = true;
            this.ocsp_valid.Text = "Valid";
            this.ocsp_valid.UseVisualStyleBackColor = true;
            // 
            // not_before
            // 
            this.not_before.Location = new System.Drawing.Point(19, 265);
            this.not_before.Name = "not_before";
            this.not_before.Size = new System.Drawing.Size(220, 20);
            this.not_before.TabIndex = 52;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ocsp_unknown);
            this.groupBox2.Controls.Add(this.ocsp_revoked);
            this.groupBox2.Controls.Add(this.ocsp_valid);
            this.groupBox2.Controls.Add(this.ocsp_url);
            this.groupBox2.Controls.Add(this.include_ocsp);
            this.groupBox2.Location = new System.Drawing.Point(19, 682);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(282, 95);
            this.groupBox2.TabIndex = 62;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "OCSP";
            // 
            // ocsp_url
            // 
            this.ocsp_url.Location = new System.Drawing.Point(14, 19);
            this.ocsp_url.Name = "ocsp_url";
            this.ocsp_url.ReadOnly = true;
            this.ocsp_url.Size = new System.Drawing.Size(184, 20);
            this.ocsp_url.TabIndex = 0;
            this.ocsp_url.Text = "http://EESSIDEV04:8081/ca.ocsp";
            // 
            // include_ocsp
            // 
            this.include_ocsp.AutoSize = true;
            this.include_ocsp.Location = new System.Drawing.Point(204, 21);
            this.include_ocsp.Name = "include_ocsp";
            this.include_ocsp.Size = new System.Drawing.Size(61, 17);
            this.include_ocsp.TabIndex = 1;
            this.include_ocsp.Text = "Include";
            this.include_ocsp.UseVisualStyleBackColor = true;
            // 
            // install_store
            // 
            this.install_store.AutoSize = true;
            this.install_store.Checked = true;
            this.install_store.CheckState = System.Windows.Forms.CheckState.Checked;
            this.install_store.Location = new System.Drawing.Point(19, 12);
            this.install_store.Name = "install_store";
            this.install_store.Size = new System.Drawing.Size(142, 17);
            this.install_store.TabIndex = 61;
            this.install_store.Text = "Install in Certificate Store";
            this.install_store.UseVisualStyleBackColor = true;
            // 
            // subject
            // 
            this.subject.Location = new System.Drawing.Point(19, 214);
            this.subject.Name = "subject";
            this.subject.Size = new System.Drawing.Size(220, 20);
            this.subject.TabIndex = 51;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 198);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 13);
            this.label1.TabIndex = 57;
            this.label1.Text = "Subject Distinguished Name";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.crl_unknown);
            this.groupBox1.Controls.Add(this.crl_revoked);
            this.groupBox1.Controls.Add(this.crl_valid);
            this.groupBox1.Controls.Add(this.crl_url);
            this.groupBox1.Controls.Add(this.include_crl);
            this.groupBox1.Location = new System.Drawing.Point(19, 783);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(282, 95);
            this.groupBox1.TabIndex = 63;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "CRL";
            // 
            // store_name
            // 
            this.store_name.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.store_name.FormattingEnabled = true;
            this.store_name.Location = new System.Drawing.Point(108, 71);
            this.store_name.Name = "store_name";
            this.store_name.Size = new System.Drawing.Size(121, 21);
            this.store_name.TabIndex = 49;
            // 
            // store_location
            // 
            this.store_location.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.store_location.FormattingEnabled = true;
            this.store_location.Location = new System.Drawing.Point(108, 44);
            this.store_location.Name = "store_location";
            this.store_location.Size = new System.Drawing.Size(121, 21);
            this.store_location.TabIndex = 48;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(26, 47);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(76, 13);
            this.label14.TabIndex = 59;
            this.label14.Text = "Store Location";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(26, 74);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(63, 13);
            this.label13.TabIndex = 60;
            this.label13.Text = "Store Name";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(16, 149);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(73, 13);
            this.label10.TabIndex = 58;
            this.label10.Text = "Serial Number";
            // 
            // serial
            // 
            this.serial.Location = new System.Drawing.Point(19, 165);
            this.serial.Name = "serial";
            this.serial.Size = new System.Drawing.Size(220, 20);
            this.serial.TabIndex = 50;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 108);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 67;
            this.label4.Text = "Thumbprint";
            // 
            // thumbprint
            // 
            this.thumbprint.Location = new System.Drawing.Point(19, 124);
            this.thumbprint.Name = "thumbprint";
            this.thumbprint.ReadOnly = true;
            this.thumbprint.Size = new System.Drawing.Size(220, 20);
            this.thumbprint.TabIndex = 66;
            // 
            // CertificateDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label4);
            this.Controls.Add(this.thumbprint);
            this.Controls.Add(this.not_after);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.key_usages);
            this.Controls.Add(this.subject_alternative_names);
            this.Controls.Add(this.is_ca);
            this.Controls.Add(this.not_before);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.install_store);
            this.Controls.Add(this.subject);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.store_name);
            this.Controls.Add(this.store_location);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.serial);
            this.Name = "CertificateDetails";
            this.Size = new System.Drawing.Size(323, 892);
            ((System.ComponentModel.ISupportInitialize)(this.key_usages)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.subject_alternative_names)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker not_after;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn KeyUsage;
        private System.Windows.Forms.DataGridView key_usages;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubjectAlternativeName;
        private System.Windows.Forms.DataGridView subject_alternative_names;
        private System.Windows.Forms.CheckBox is_ca;
        private System.Windows.Forms.RadioButton crl_revoked;
        private System.Windows.Forms.RadioButton crl_valid;
        private System.Windows.Forms.TextBox crl_url;
        private System.Windows.Forms.CheckBox include_crl;
        private System.Windows.Forms.RadioButton ocsp_unknown;
        private System.Windows.Forms.RadioButton ocsp_revoked;
        private System.Windows.Forms.RadioButton crl_unknown;
        private System.Windows.Forms.RadioButton ocsp_valid;
        private System.Windows.Forms.DateTimePicker not_before;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox ocsp_url;
        private System.Windows.Forms.CheckBox include_ocsp;
        private System.Windows.Forms.CheckBox install_store;
        private System.Windows.Forms.TextBox subject;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox store_name;
        private System.Windows.Forms.ComboBox store_location;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox serial;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox thumbprint;
    }
}
