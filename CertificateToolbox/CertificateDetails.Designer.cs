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
      this.KeyUsage = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.key_usages = new System.Windows.Forms.DataGridView();
      this.SubjectAlternativeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.subject_alternative_names = new System.Windows.Forms.DataGridView();
      this.is_ca = new System.Windows.Forms.CheckBox();
      this.not_before = new System.Windows.Forms.DateTimePicker();
      this.install_store = new System.Windows.Forms.CheckBox();
      this.subject = new System.Windows.Forms.TextBox();
      this.store_name = new System.Windows.Forms.ComboBox();
      this.serial = new System.Windows.Forms.TextBox();
      this.thumbprint = new System.Windows.Forms.TextBox();
      this.remove = new System.Windows.Forms.Button();
      this.copy = new System.Windows.Forms.Button();
      this.store_location = new System.Windows.Forms.ComboBox();
      this.has_ocsp_responder = new System.Windows.Forms.CheckBox();
      this.include_ocsp_cert = new System.Windows.Forms.CheckBox();
      this.is_recreate_required = new System.Windows.Forms.CheckBox();
      this.crl = new CertificateToolbox.RevocationEndpoint();
      this.ocsp = new CertificateToolbox.RevocationEndpoint();
      this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
      this.install_store_groupBox1 = new System.Windows.Forms.GroupBox();
      this.Thumbprint_groupBox2 = new System.Windows.Forms.GroupBox();
      this.SerialNumbergroupBox1 = new System.Windows.Forms.GroupBox();
      this.SubjectDistinguishedNamegroupBox1 = new System.Windows.Forms.GroupBox();
      this.NotBeforegroupBox1 = new System.Windows.Forms.GroupBox();
      this.notafter_groupBox1 = new System.Windows.Forms.GroupBox();
      this.CA_groupBox1 = new System.Windows.Forms.GroupBox();
      ((System.ComponentModel.ISupportInitialize)(this.key_usages)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.subject_alternative_names)).BeginInit();
      this.tableLayoutPanel1.SuspendLayout();
      this.install_store_groupBox1.SuspendLayout();
      this.Thumbprint_groupBox2.SuspendLayout();
      this.SerialNumbergroupBox1.SuspendLayout();
      this.SubjectDistinguishedNamegroupBox1.SuspendLayout();
      this.NotBeforegroupBox1.SuspendLayout();
      this.notafter_groupBox1.SuspendLayout();
      this.CA_groupBox1.SuspendLayout();
      this.SuspendLayout();
      // 
      // not_after
      // 
      this.not_after.Dock = System.Windows.Forms.DockStyle.Fill;
      this.not_after.Location = new System.Drawing.Point(3, 19);
      this.not_after.Margin = new System.Windows.Forms.Padding(4);
      this.not_after.Name = "not_after";
      this.not_after.Size = new System.Drawing.Size(0, 23);
      this.not_after.TabIndex = 53;
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
      this.tableLayoutPanel1.SetColumnSpan(this.key_usages, 3);
      this.key_usages.Location = new System.Drawing.Point(4, 464);
      this.key_usages.Margin = new System.Windows.Forms.Padding(4);
      this.key_usages.Name = "key_usages";
      this.key_usages.Size = new System.Drawing.Size(191, 143);
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
      this.tableLayoutPanel1.SetColumnSpan(this.subject_alternative_names, 3);
      this.subject_alternative_names.Location = new System.Drawing.Point(4, 404);
      this.subject_alternative_names.Margin = new System.Windows.Forms.Padding(4);
      this.subject_alternative_names.Name = "subject_alternative_names";
      this.subject_alternative_names.Size = new System.Drawing.Size(191, 52);
      this.subject_alternative_names.TabIndex = 55;
      // 
      // is_ca
      // 
      this.is_ca.AutoSize = true;
      this.is_ca.Checked = true;
      this.is_ca.CheckState = System.Windows.Forms.CheckState.Checked;
      this.is_ca.Location = new System.Drawing.Point(7, 23);
      this.is_ca.Margin = new System.Windows.Forms.Padding(4);
      this.is_ca.Name = "is_ca";
      this.is_ca.Size = new System.Drawing.Size(144, 19);
      this.is_ca.TabIndex = 54;
      this.is_ca.Text = "Is Certificate Authority";
      this.is_ca.UseVisualStyleBackColor = true;
      this.is_ca.CheckedChanged += new System.EventHandler(this.is_ca_CheckedChanged);
      // 
      // not_before
      // 
      this.not_before.Dock = System.Windows.Forms.DockStyle.Fill;
      this.not_before.Location = new System.Drawing.Point(3, 19);
      this.not_before.Margin = new System.Windows.Forms.Padding(4);
      this.not_before.Name = "not_before";
      this.not_before.Size = new System.Drawing.Size(183, 23);
      this.not_before.TabIndex = 52;
      // 
      // install_store
      // 
      this.install_store.AutoSize = true;
      this.install_store.Checked = true;
      this.install_store.CheckState = System.Windows.Forms.CheckState.Checked;
      this.install_store.Dock = System.Windows.Forms.DockStyle.Top;
      this.install_store.Location = new System.Drawing.Point(3, 19);
      this.install_store.Margin = new System.Windows.Forms.Padding(4);
      this.install_store.Name = "install_store";
      this.install_store.Size = new System.Drawing.Size(107, 19);
      this.install_store.TabIndex = 61;
      this.install_store.Text = "Install in Store";
      this.install_store.UseVisualStyleBackColor = true;
      // 
      // subject
      // 
      this.subject.Dock = System.Windows.Forms.DockStyle.Fill;
      this.subject.Location = new System.Drawing.Point(3, 19);
      this.subject.Margin = new System.Windows.Forms.Padding(4);
      this.subject.Name = "subject";
      this.subject.Size = new System.Drawing.Size(183, 23);
      this.subject.TabIndex = 51;
      // 
      // store_name
      // 
      this.store_name.Dock = System.Windows.Forms.DockStyle.Top;
      this.store_name.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.store_name.FormattingEnabled = true;
      this.store_name.Location = new System.Drawing.Point(3, 61);
      this.store_name.Margin = new System.Windows.Forms.Padding(4);
      this.store_name.Name = "store_name";
      this.store_name.Size = new System.Drawing.Size(107, 23);
      this.store_name.TabIndex = 49;
      // 
      // serial
      // 
      this.serial.Dock = System.Windows.Forms.DockStyle.Fill;
      this.serial.Location = new System.Drawing.Point(3, 19);
      this.serial.Margin = new System.Windows.Forms.Padding(4);
      this.serial.Name = "serial";
      this.serial.Size = new System.Drawing.Size(107, 23);
      this.serial.TabIndex = 50;
      // 
      // thumbprint
      // 
      this.thumbprint.Dock = System.Windows.Forms.DockStyle.Fill;
      this.thumbprint.Location = new System.Drawing.Point(3, 19);
      this.thumbprint.Margin = new System.Windows.Forms.Padding(4);
      this.thumbprint.Name = "thumbprint";
      this.thumbprint.ReadOnly = true;
      this.thumbprint.Size = new System.Drawing.Size(107, 23);
      this.thumbprint.TabIndex = 66;
      // 
      // remove
      // 
      this.remove.Location = new System.Drawing.Point(123, 4);
      this.remove.Margin = new System.Windows.Forms.Padding(4);
      this.remove.Name = "remove";
      this.remove.Size = new System.Drawing.Size(51, 26);
      this.remove.TabIndex = 68;
      this.remove.Text = "X";
      this.remove.UseVisualStyleBackColor = true;
      this.remove.Click += new System.EventHandler(this.remove_Click);
      // 
      // copy
      // 
      this.copy.Location = new System.Drawing.Point(123, 104);
      this.copy.Margin = new System.Windows.Forms.Padding(4);
      this.copy.Name = "copy";
      this.copy.Size = new System.Drawing.Size(51, 26);
      this.copy.TabIndex = 68;
      this.copy.Text = "Copy";
      this.copy.UseVisualStyleBackColor = true;
      this.copy.Click += new System.EventHandler(this.copy_Click);
      // 
      // store_location
      // 
      this.store_location.Dock = System.Windows.Forms.DockStyle.Top;
      this.store_location.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.store_location.FormattingEnabled = true;
      this.store_location.Location = new System.Drawing.Point(3, 38);
      this.store_location.Margin = new System.Windows.Forms.Padding(4);
      this.store_location.Name = "store_location";
      this.store_location.Size = new System.Drawing.Size(107, 23);
      this.store_location.TabIndex = 70;
      // 
      // has_ocsp_responder
      // 
      this.has_ocsp_responder.AutoSize = true;
      this.has_ocsp_responder.Location = new System.Drawing.Point(0, 0);
      this.has_ocsp_responder.Margin = new System.Windows.Forms.Padding(4);
      this.has_ocsp_responder.Name = "has_ocsp_responder";
      this.has_ocsp_responder.Size = new System.Drawing.Size(135, 19);
      this.has_ocsp_responder.TabIndex = 71;
      this.has_ocsp_responder.Text = "Has OCSP responder";
      this.has_ocsp_responder.UseVisualStyleBackColor = true;
      // 
      // include_ocsp_cert
      // 
      this.include_ocsp_cert.AutoSize = true;
      this.include_ocsp_cert.Location = new System.Drawing.Point(0, 0);
      this.include_ocsp_cert.Margin = new System.Windows.Forms.Padding(4);
      this.include_ocsp_cert.Name = "include_ocsp_cert";
      this.include_ocsp_cert.Size = new System.Drawing.Size(151, 19);
      this.include_ocsp_cert.TabIndex = 72;
      this.include_ocsp_cert.Text = "Include cert in response";
      this.include_ocsp_cert.UseVisualStyleBackColor = true;
      // 
      // is_recreate_required
      // 
      this.is_recreate_required.AutoSize = true;
      this.is_recreate_required.Checked = true;
      this.is_recreate_required.CheckState = System.Windows.Forms.CheckState.Checked;
      this.is_recreate_required.Location = new System.Drawing.Point(123, 164);
      this.is_recreate_required.Margin = new System.Windows.Forms.Padding(4);
      this.is_recreate_required.Name = "is_recreate_required";
      this.is_recreate_required.Size = new System.Drawing.Size(68, 19);
      this.is_recreate_required.TabIndex = 74;
      this.is_recreate_required.Text = "Recreate";
      this.is_recreate_required.UseVisualStyleBackColor = true;
      // 
      // crl
      // 
      this.tableLayoutPanel1.SetColumnSpan(this.crl, 3);
      this.crl.ContentType = "application/pkix-crl";
      this.crl.GetResponse = null;
      this.crl.Location = new System.Drawing.Point(5, 787);
      this.crl.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
      this.crl.Name = "crl";
      this.crl.RevocationType = "CRL";
      this.crl.Size = new System.Drawing.Size(189, 154);
      this.crl.TabIndex = 69;
      // 
      // ocsp
      // 
      this.tableLayoutPanel1.SetColumnSpan(this.ocsp, 3);
      this.ocsp.ContentType = "application/ocsp-response";
      this.ocsp.GetResponse = null;
      this.ocsp.Location = new System.Drawing.Point(5, 615);
      this.ocsp.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
      this.ocsp.Name = "ocsp";
      this.ocsp.RevocationType = "OCSP";
      this.ocsp.Size = new System.Drawing.Size(189, 164);
      this.ocsp.TabIndex = 69;
      // 
      // tableLayoutPanel1
      // 
      this.tableLayoutPanel1.AutoSize = true;
      this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.tableLayoutPanel1.ColumnCount = 4;
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60.86956F));
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 39.13044F));
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 4F));
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
      this.tableLayoutPanel1.Controls.Add(this.install_store_groupBox1, 0, 0);
      this.tableLayoutPanel1.Controls.Add(this.remove, 1, 0);
      this.tableLayoutPanel1.Controls.Add(this.Thumbprint_groupBox2, 0, 1);
      this.tableLayoutPanel1.Controls.Add(this.copy, 1, 1);
      this.tableLayoutPanel1.Controls.Add(this.SerialNumbergroupBox1, 0, 2);
      this.tableLayoutPanel1.Controls.Add(this.SubjectDistinguishedNamegroupBox1, 0, 3);
      this.tableLayoutPanel1.Controls.Add(this.NotBeforegroupBox1, 0, 4);
      this.tableLayoutPanel1.Controls.Add(this.notafter_groupBox1, 2, 5);
      this.tableLayoutPanel1.Controls.Add(this.CA_groupBox1, 2, 0);
      this.tableLayoutPanel1.Controls.Add(this.key_usages, 0, 13);
      this.tableLayoutPanel1.Controls.Add(this.ocsp, 0, 14);
      this.tableLayoutPanel1.Controls.Add(this.crl, 0, 15);
      this.tableLayoutPanel1.Controls.Add(this.subject_alternative_names, 0, 6);
      this.tableLayoutPanel1.Controls.Add(this.is_recreate_required, 1, 2);
      this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
      this.tableLayoutPanel1.Name = "tableLayoutPanel1";
      this.tableLayoutPanel1.RowCount = 16;
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      this.tableLayoutPanel1.Size = new System.Drawing.Size(400, 1038);
      this.tableLayoutPanel1.TabIndex = 75;
      // 
      // install_store_groupBox1
      // 
      this.install_store_groupBox1.AutoSize = true;
      this.install_store_groupBox1.Controls.Add(this.store_name);
      this.install_store_groupBox1.Controls.Add(this.store_location);
      this.install_store_groupBox1.Controls.Add(this.install_store);
      this.install_store_groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.install_store_groupBox1.Location = new System.Drawing.Point(3, 3);
      this.install_store_groupBox1.Name = "install_store_groupBox1";
      this.install_store_groupBox1.Size = new System.Drawing.Size(113, 94);
      this.install_store_groupBox1.TabIndex = 75;
      this.install_store_groupBox1.TabStop = false;
      this.install_store_groupBox1.Text = "Install in Store";
      // 
      // Thumbprint_groupBox2
      // 
      this.Thumbprint_groupBox2.AutoSize = true;
      this.Thumbprint_groupBox2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.Thumbprint_groupBox2.Controls.Add(this.thumbprint);
      this.Thumbprint_groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
      this.Thumbprint_groupBox2.Location = new System.Drawing.Point(3, 103);
      this.Thumbprint_groupBox2.Name = "Thumbprint_groupBox2";
      this.Thumbprint_groupBox2.Size = new System.Drawing.Size(113, 54);
      this.Thumbprint_groupBox2.TabIndex = 76;
      this.Thumbprint_groupBox2.TabStop = false;
      this.Thumbprint_groupBox2.Text = "Thumbprint";
      // 
      // SerialNumbergroupBox1
      // 
      this.SerialNumbergroupBox1.AutoSize = true;
      this.SerialNumbergroupBox1.Controls.Add(this.serial);
      this.SerialNumbergroupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.SerialNumbergroupBox1.Location = new System.Drawing.Point(3, 163);
      this.SerialNumbergroupBox1.Name = "SerialNumbergroupBox1";
      this.SerialNumbergroupBox1.Size = new System.Drawing.Size(113, 54);
      this.SerialNumbergroupBox1.TabIndex = 77;
      this.SerialNumbergroupBox1.TabStop = false;
      this.SerialNumbergroupBox1.Text = "Serial Number";
      // 
      // SubjectDistinguishedNamegroupBox1
      // 
      this.tableLayoutPanel1.SetColumnSpan(this.SubjectDistinguishedNamegroupBox1, 2);
      this.SubjectDistinguishedNamegroupBox1.Controls.Add(this.subject);
      this.SubjectDistinguishedNamegroupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.SubjectDistinguishedNamegroupBox1.Location = new System.Drawing.Point(3, 223);
      this.SubjectDistinguishedNamegroupBox1.Name = "SubjectDistinguishedNamegroupBox1";
      this.SubjectDistinguishedNamegroupBox1.Size = new System.Drawing.Size(189, 54);
      this.SubjectDistinguishedNamegroupBox1.TabIndex = 78;
      this.SubjectDistinguishedNamegroupBox1.TabStop = false;
      this.SubjectDistinguishedNamegroupBox1.Text = "Subject Distinguished Name";
      // 
      // NotBeforegroupBox1
      // 
      this.tableLayoutPanel1.SetColumnSpan(this.NotBeforegroupBox1, 2);
      this.NotBeforegroupBox1.Controls.Add(this.not_before);
      this.NotBeforegroupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.NotBeforegroupBox1.Location = new System.Drawing.Point(3, 283);
      this.NotBeforegroupBox1.Name = "NotBeforegroupBox1";
      this.NotBeforegroupBox1.Size = new System.Drawing.Size(189, 54);
      this.NotBeforegroupBox1.TabIndex = 79;
      this.NotBeforegroupBox1.TabStop = false;
      this.NotBeforegroupBox1.Text = "Not Before";
      // 
      // notafter_groupBox1
      // 
      this.notafter_groupBox1.Controls.Add(this.not_after);
      this.notafter_groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.notafter_groupBox1.Location = new System.Drawing.Point(198, 343);
      this.notafter_groupBox1.Name = "notafter_groupBox1";
      this.notafter_groupBox1.Size = new System.Drawing.Size(1, 54);
      this.notafter_groupBox1.TabIndex = 80;
      this.notafter_groupBox1.TabStop = false;
      this.notafter_groupBox1.Text = "Not After";
      // 
      // CA_groupBox1
      // 
      this.CA_groupBox1.Controls.Add(this.is_ca);
      this.CA_groupBox1.Controls.Add(this.has_ocsp_responder);
      this.CA_groupBox1.Controls.Add(this.include_ocsp_cert);
      this.CA_groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.CA_groupBox1.Location = new System.Drawing.Point(198, 3);
      this.CA_groupBox1.Name = "CA_groupBox1";
      this.CA_groupBox1.Size = new System.Drawing.Size(1, 94);
      this.CA_groupBox1.TabIndex = 81;
      this.CA_groupBox1.TabStop = false;
      this.CA_groupBox1.Text = "CA";
      // 
      // CertificateDetails
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.tableLayoutPanel1);
      this.Margin = new System.Windows.Forms.Padding(4);
      this.Name = "CertificateDetails";
      this.Size = new System.Drawing.Size(400, 1038);
      ((System.ComponentModel.ISupportInitialize)(this.key_usages)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.subject_alternative_names)).EndInit();
      this.tableLayoutPanel1.ResumeLayout(false);
      this.tableLayoutPanel1.PerformLayout();
      this.install_store_groupBox1.ResumeLayout(false);
      this.install_store_groupBox1.PerformLayout();
      this.Thumbprint_groupBox2.ResumeLayout(false);
      this.Thumbprint_groupBox2.PerformLayout();
      this.SerialNumbergroupBox1.ResumeLayout(false);
      this.SerialNumbergroupBox1.PerformLayout();
      this.SubjectDistinguishedNamegroupBox1.ResumeLayout(false);
      this.SubjectDistinguishedNamegroupBox1.PerformLayout();
      this.NotBeforegroupBox1.ResumeLayout(false);
      this.notafter_groupBox1.ResumeLayout(false);
      this.CA_groupBox1.ResumeLayout(false);
      this.CA_groupBox1.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker not_after;
        private System.Windows.Forms.DataGridViewTextBoxColumn KeyUsage;
        private System.Windows.Forms.DataGridView key_usages;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubjectAlternativeName;
        private System.Windows.Forms.DataGridView subject_alternative_names;
        private System.Windows.Forms.CheckBox is_ca;
        private System.Windows.Forms.DateTimePicker not_before;
        private System.Windows.Forms.CheckBox install_store;
        private System.Windows.Forms.TextBox subject;
        private System.Windows.Forms.ComboBox store_name;
        private System.Windows.Forms.TextBox serial;
        private System.Windows.Forms.TextBox thumbprint;
        private System.Windows.Forms.Button remove;
        private System.Windows.Forms.Button copy;
        private RevocationEndpoint ocsp;
        private RevocationEndpoint crl;
        private System.Windows.Forms.ComboBox store_location;
        private System.Windows.Forms.CheckBox has_ocsp_responder;
        private System.Windows.Forms.CheckBox include_ocsp_cert;
        private System.Windows.Forms.CheckBox is_recreate_required;
        private TableLayoutPanel tableLayoutPanel1;
    private GroupBox install_store_groupBox1;
    private GroupBox Thumbprint_groupBox2;
    private GroupBox SerialNumbergroupBox1;
    private GroupBox SubjectDistinguishedNamegroupBox1;
    private GroupBox NotBeforegroupBox1;
    private GroupBox notafter_groupBox1;
    private GroupBox CA_groupBox1;
  }
}
