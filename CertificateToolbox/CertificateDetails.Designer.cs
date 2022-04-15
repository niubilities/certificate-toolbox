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
            this.notafter_lbl = new System.Windows.Forms.Label();
            this.notbefore_lbl = new System.Windows.Forms.Label();
            this.KeyUsage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.key_usages = new System.Windows.Forms.DataGridView();
            this.SubjectAlternativeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.subject_alternative_names = new System.Windows.Forms.DataGridView();
            this.is_ca = new System.Windows.Forms.CheckBox();
            this.not_before = new System.Windows.Forms.DateTimePicker();
            this.install_store = new System.Windows.Forms.CheckBox();
            this.subject = new System.Windows.Forms.TextBox();
            this.subject_lbl = new System.Windows.Forms.Label();
            this.store_name = new System.Windows.Forms.ComboBox();
            this.serial_lbl = new System.Windows.Forms.Label();
            this.serial = new System.Windows.Forms.TextBox();
            this.thumbprint_lbl = new System.Windows.Forms.Label();
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
            ((System.ComponentModel.ISupportInitialize)(this.key_usages)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.subject_alternative_names)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // not_after
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.not_after, 2);
            this.not_after.Location = new System.Drawing.Point(4, 274);
            this.not_after.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.not_after.Name = "not_after";
            this.not_after.Size = new System.Drawing.Size(258, 23);
            this.not_after.TabIndex = 53;
            // 
            // notafter_lbl
            // 
            this.notafter_lbl.AutoSize = true;
            this.notafter_lbl.Location = new System.Drawing.Point(4, 253);
            this.notafter_lbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.notafter_lbl.Name = "notafter_lbl";
            this.notafter_lbl.Size = new System.Drawing.Size(62, 17);
            this.notafter_lbl.TabIndex = 65;
            this.notafter_lbl.Text = "Not After";
            // 
            // notbefore_lbl
            // 
            this.notbefore_lbl.AutoSize = true;
            this.notbefore_lbl.Location = new System.Drawing.Point(4, 205);
            this.notbefore_lbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.notbefore_lbl.Name = "notbefore_lbl";
            this.notbefore_lbl.Size = new System.Drawing.Size(73, 17);
            this.notbefore_lbl.TabIndex = 64;
            this.notbefore_lbl.Text = "Not Before";
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
            this.key_usages.Location = new System.Drawing.Point(4, 504);
            this.key_usages.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.key_usages.Name = "key_usages";
            this.key_usages.Size = new System.Drawing.Size(309, 162);
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
            this.subject_alternative_names.Location = new System.Drawing.Point(4, 334);
            this.subject_alternative_names.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.subject_alternative_names.Name = "subject_alternative_names";
            this.subject_alternative_names.Size = new System.Drawing.Size(309, 162);
            this.subject_alternative_names.TabIndex = 55;
            // 
            // is_ca
            // 
            this.is_ca.AutoSize = true;
            this.is_ca.Checked = true;
            this.is_ca.CheckState = System.Windows.Forms.CheckState.Checked;
            this.is_ca.Location = new System.Drawing.Point(4, 305);
            this.is_ca.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.is_ca.Name = "is_ca";
            this.is_ca.Size = new System.Drawing.Size(105, 21);
            this.is_ca.TabIndex = 54;
            this.is_ca.Text = "Is Certificate Authority";
            this.is_ca.UseVisualStyleBackColor = true;
            this.is_ca.CheckedChanged += new System.EventHandler(this.is_ca_CheckedChanged);
            // 
            // not_before
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.not_before, 2);
            this.not_before.Location = new System.Drawing.Point(4, 226);
            this.not_before.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.not_before.Name = "not_before";
            this.not_before.Size = new System.Drawing.Size(256, 23);
            this.not_before.TabIndex = 52;
            // 
            // install_store
            // 
            this.install_store.AutoSize = true;
            this.install_store.Checked = true;
            this.install_store.CheckState = System.Windows.Forms.CheckState.Checked;
            this.install_store.Location = new System.Drawing.Point(4, 4);
            this.install_store.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.install_store.Name = "install_store";
            this.install_store.Size = new System.Drawing.Size(105, 21);
            this.install_store.TabIndex = 61;
            this.install_store.Text = "Install in Store";
            this.install_store.UseVisualStyleBackColor = true;
            // 
            // subject
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.subject, 2);
            this.subject.Location = new System.Drawing.Point(4, 178);
            this.subject.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.subject.Name = "subject";
            this.subject.Size = new System.Drawing.Size(256, 23);
            this.subject.TabIndex = 51;
            // 
            // subject_lbl
            // 
            this.subject_lbl.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.subject_lbl, 2);
            this.subject_lbl.Location = new System.Drawing.Point(4, 157);
            this.subject_lbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.subject_lbl.Name = "subject_lbl";
            this.subject_lbl.Size = new System.Drawing.Size(171, 17);
            this.subject_lbl.TabIndex = 57;
            this.subject_lbl.Text = "Subject Distinguished Name";
            // 
            // store_name
            // 
            this.store_name.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.store_name.FormattingEnabled = true;
            this.store_name.Location = new System.Drawing.Point(117, 42);
            this.store_name.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.store_name.Name = "store_name";
            this.store_name.Size = new System.Drawing.Size(140, 25);
            this.store_name.TabIndex = 49;
            // 
            // serial_lbl
            // 
            this.serial_lbl.AutoSize = true;
            this.serial_lbl.Location = new System.Drawing.Point(4, 109);
            this.serial_lbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.serial_lbl.Name = "serial_lbl";
            this.serial_lbl.Size = new System.Drawing.Size(92, 17);
            this.serial_lbl.TabIndex = 58;
            this.serial_lbl.Text = "Serial Number";
            // 
            // serial
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.serial, 2);
            this.serial.Location = new System.Drawing.Point(4, 130);
            this.serial.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.serial.Name = "serial";
            this.serial.Size = new System.Drawing.Size(256, 23);
            this.serial.TabIndex = 50;
            // 
            // thumbprint_lbl
            // 
            this.thumbprint_lbl.AutoSize = true;
            this.thumbprint_lbl.Location = new System.Drawing.Point(4, 38);
            this.thumbprint_lbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.thumbprint_lbl.Name = "thumbprint_lbl";
            this.thumbprint_lbl.Size = new System.Drawing.Size(75, 17);
            this.thumbprint_lbl.TabIndex = 67;
            this.thumbprint_lbl.Text = "Thumbprint";
            // 
            // thumbprint
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.thumbprint, 2);
            this.thumbprint.Location = new System.Drawing.Point(4, 75);
            this.thumbprint.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.thumbprint.Name = "thumbprint";
            this.thumbprint.ReadOnly = true;
            this.thumbprint.Size = new System.Drawing.Size(256, 23);
            this.thumbprint.TabIndex = 66;
            // 
            // remove
            // 
            this.remove.Location = new System.Drawing.Point(343, 4);
            this.remove.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.remove.Name = "remove";
            this.remove.Size = new System.Drawing.Size(51, 30);
            this.remove.TabIndex = 68;
            this.remove.Text = "X";
            this.remove.UseVisualStyleBackColor = true;
            this.remove.Click += new System.EventHandler(this.remove_Click);
            // 
            // copy
            // 
            this.copy.Location = new System.Drawing.Point(343, 75);
            this.copy.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.copy.Name = "copy";
            this.copy.Size = new System.Drawing.Size(51, 30);
            this.copy.TabIndex = 68;
            this.copy.Text = "Copy";
            this.copy.UseVisualStyleBackColor = true;
            this.copy.Click += new System.EventHandler(this.copy_Click);
            // 
            // store_location
            // 
            this.store_location.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.store_location.FormattingEnabled = true;
            this.store_location.Location = new System.Drawing.Point(117, 4);
            this.store_location.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.store_location.Name = "store_location";
            this.store_location.Size = new System.Drawing.Size(140, 25);
            this.store_location.TabIndex = 70;
            // 
            // has_ocsp_responder
            // 
            this.has_ocsp_responder.AutoSize = true;
            this.has_ocsp_responder.Location = new System.Drawing.Point(117, 305);
            this.has_ocsp_responder.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.has_ocsp_responder.Name = "has_ocsp_responder";
            this.has_ocsp_responder.Size = new System.Drawing.Size(150, 21);
            this.has_ocsp_responder.TabIndex = 71;
            this.has_ocsp_responder.Text = "Has OCSP responder";
            this.has_ocsp_responder.UseVisualStyleBackColor = true;
            // 
            // include_ocsp_cert
            // 
            this.include_ocsp_cert.AutoSize = true;
            this.include_ocsp_cert.Location = new System.Drawing.Point(343, 305);
            this.include_ocsp_cert.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.include_ocsp_cert.Name = "include_ocsp_cert";
            this.include_ocsp_cert.Size = new System.Drawing.Size(53, 21);
            this.include_ocsp_cert.TabIndex = 72;
            this.include_ocsp_cert.Text = "Include cert in response";
            this.include_ocsp_cert.UseVisualStyleBackColor = true;
            // 
            // is_recreate_required
            // 
            this.is_recreate_required.AutoSize = true;
            this.is_recreate_required.Checked = true;
            this.is_recreate_required.CheckState = System.Windows.Forms.CheckState.Checked;
            this.is_recreate_required.Location = new System.Drawing.Point(343, 178);
            this.is_recreate_required.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.is_recreate_required.Name = "is_recreate_required";
            this.is_recreate_required.Size = new System.Drawing.Size(53, 21);
            this.is_recreate_required.TabIndex = 74;
            this.is_recreate_required.Text = "Recreate";
            this.is_recreate_required.UseVisualStyleBackColor = true;
            // 
            // crl
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.crl, 3);
            this.crl.ContentType = "application/pkix-crl";
            this.crl.GetResponse = null;
            this.crl.Location = new System.Drawing.Point(5, 871);
            this.crl.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.crl.Name = "crl";
            this.crl.RevocationType = "CRL";
            this.crl.Size = new System.Drawing.Size(341, 174);
            this.crl.TabIndex = 69;
            // 
            // ocsp
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.ocsp, 3);
            this.ocsp.ContentType = "application/ocsp-response";
            this.ocsp.GetResponse = null;
            this.ocsp.Location = new System.Drawing.Point(5, 675);
            this.ocsp.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.ocsp.Name = "ocsp";
            this.ocsp.RevocationType = "OCSP";
            this.ocsp.Size = new System.Drawing.Size(341, 186);
            this.ocsp.TabIndex = 69;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 66.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.Controls.Add(this.install_store, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.store_name, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.store_location, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.remove, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.thumbprint_lbl, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.thumbprint, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.copy, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.serial_lbl, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.serial, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.subject_lbl, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.subject, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.is_recreate_required, 2, 6);
            this.tableLayoutPanel1.Controls.Add(this.notbefore_lbl, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.not_before, 0, 8);
            this.tableLayoutPanel1.Controls.Add(this.notafter_lbl, 0, 9);
            this.tableLayoutPanel1.Controls.Add(this.not_after, 0, 10);
            this.tableLayoutPanel1.Controls.Add(this.is_ca, 0, 11);
            this.tableLayoutPanel1.Controls.Add(this.has_ocsp_responder, 1, 11);
            this.tableLayoutPanel1.Controls.Add(this.include_ocsp_cert, 2, 11);
            this.tableLayoutPanel1.Controls.Add(this.subject_alternative_names, 0, 12);
            this.tableLayoutPanel1.Controls.Add(this.key_usages, 0, 13);
            this.tableLayoutPanel1.Controls.Add(this.ocsp, 0, 14);
            this.tableLayoutPanel1.Controls.Add(this.crl, 0, 15);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 16;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(400, 1176);
            this.tableLayoutPanel1.TabIndex = 75;
            // 
            // CertificateDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "CertificateDetails";
            this.Size = new System.Drawing.Size(400, 1176);
            ((System.ComponentModel.ISupportInitialize)(this.key_usages)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.subject_alternative_names)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker not_after;
        private System.Windows.Forms.Label notafter_lbl;
        private System.Windows.Forms.Label notbefore_lbl;
        private System.Windows.Forms.DataGridViewTextBoxColumn KeyUsage;
        private System.Windows.Forms.DataGridView key_usages;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubjectAlternativeName;
        private System.Windows.Forms.DataGridView subject_alternative_names;
        private System.Windows.Forms.CheckBox is_ca;
        private System.Windows.Forms.DateTimePicker not_before;
        private System.Windows.Forms.CheckBox install_store;
        private System.Windows.Forms.TextBox subject;
        private System.Windows.Forms.Label subject_lbl;
        private System.Windows.Forms.ComboBox store_name;
        private System.Windows.Forms.Label serial_lbl;
        private System.Windows.Forms.TextBox serial;
        private System.Windows.Forms.Label thumbprint_lbl;
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
    }
}
