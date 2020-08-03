namespace PMC_Desktop {
    partial class formEditUser {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose (bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose ();
            }
            base.Dispose (disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent () {
            this.buttonEUClose = new System.Windows.Forms.Button();
            this.labelEUName = new System.Windows.Forms.Label();
            this.labelEUPrimaryEmailAddress = new System.Windows.Forms.Label();
            this.textEUName = new System.Windows.Forms.TextBox();
            this.comboEUPrimaryEmailAddress = new System.Windows.Forms.ComboBox();
            this.listEUProxyAddresses = new System.Windows.Forms.ListBox();
            this.labelEUProxyAddresses = new System.Windows.Forms.Label();
            this.buttonEUAddNewEmail = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonEUClose
            // 
            this.buttonEUClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonEUClose.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonEUClose.Location = new System.Drawing.Point(328, 415);
            this.buttonEUClose.Name = "buttonEUClose";
            this.buttonEUClose.Size = new System.Drawing.Size(75, 34);
            this.buttonEUClose.TabIndex = 1;
            this.buttonEUClose.Text = "Close";
            this.buttonEUClose.UseVisualStyleBackColor = true;
            // 
            // labelEUName
            // 
            this.labelEUName.AutoSize = true;
            this.labelEUName.Location = new System.Drawing.Point(16, 31);
            this.labelEUName.Name = "labelEUName";
            this.labelEUName.Size = new System.Drawing.Size(35, 13);
            this.labelEUName.TabIndex = 2;
            this.labelEUName.Text = "Name";
            // 
            // labelEUPrimaryEmailAddress
            // 
            this.labelEUPrimaryEmailAddress.AutoSize = true;
            this.labelEUPrimaryEmailAddress.Location = new System.Drawing.Point(16, 57);
            this.labelEUPrimaryEmailAddress.Name = "labelEUPrimaryEmailAddress";
            this.labelEUPrimaryEmailAddress.Size = new System.Drawing.Size(110, 13);
            this.labelEUPrimaryEmailAddress.TabIndex = 3;
            this.labelEUPrimaryEmailAddress.Text = "Primary Email Address";
            // 
            // textEUName
            // 
            this.textEUName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textEUName.Location = new System.Drawing.Point(173, 28);
            this.textEUName.Name = "textEUName";
            this.textEUName.Size = new System.Drawing.Size(230, 20);
            this.textEUName.TabIndex = 4;
            // 
            // comboEUPrimaryEmailAddress
            // 
            this.comboEUPrimaryEmailAddress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboEUPrimaryEmailAddress.FormattingEnabled = true;
            this.comboEUPrimaryEmailAddress.Location = new System.Drawing.Point(173, 54);
            this.comboEUPrimaryEmailAddress.Name = "comboEUPrimaryEmailAddress";
            this.comboEUPrimaryEmailAddress.Size = new System.Drawing.Size(230, 21);
            this.comboEUPrimaryEmailAddress.TabIndex = 5;
            this.comboEUPrimaryEmailAddress.SelectedIndexChanged += new System.EventHandler(this.comboEUPrimaryEmailAddress_SelectedIndexChanged);
            // 
            // listEUProxyAddresses
            // 
            this.listEUProxyAddresses.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.listEUProxyAddresses.FormattingEnabled = true;
            this.listEUProxyAddresses.Location = new System.Drawing.Point(173, 81);
            this.listEUProxyAddresses.Name = "listEUProxyAddresses";
            this.listEUProxyAddresses.Size = new System.Drawing.Size(230, 95);
            this.listEUProxyAddresses.TabIndex = 6;
            // 
            // labelEUProxyAddresses
            // 
            this.labelEUProxyAddresses.AutoSize = true;
            this.labelEUProxyAddresses.Location = new System.Drawing.Point(19, 81);
            this.labelEUProxyAddresses.Name = "labelEUProxyAddresses";
            this.labelEUProxyAddresses.Size = new System.Drawing.Size(133, 13);
            this.labelEUProxyAddresses.TabIndex = 7;
            this.labelEUProxyAddresses.Text = "Additional Email Addresses";
            // 
            // buttonEUAddNewEmail
            // 
            this.buttonEUAddNewEmail.Location = new System.Drawing.Point(77, 97);
            this.buttonEUAddNewEmail.Name = "buttonEUAddNewEmail";
            this.buttonEUAddNewEmail.Size = new System.Drawing.Size(75, 23);
            this.buttonEUAddNewEmail.TabIndex = 8;
            this.buttonEUAddNewEmail.Text = "Add New";
            this.buttonEUAddNewEmail.UseVisualStyleBackColor = true;
            this.buttonEUAddNewEmail.Click += new System.EventHandler(this.buttonEUAddNewEmail_Click);
            // 
            // formEditUser
            // 
            this.AcceptButton = this.buttonEUClose;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(415, 461);
            this.Controls.Add(this.buttonEUAddNewEmail);
            this.Controls.Add(this.labelEUProxyAddresses);
            this.Controls.Add(this.listEUProxyAddresses);
            this.Controls.Add(this.comboEUPrimaryEmailAddress);
            this.Controls.Add(this.textEUName);
            this.Controls.Add(this.labelEUPrimaryEmailAddress);
            this.Controls.Add(this.labelEUName);
            this.Controls.Add(this.buttonEUClose);
            this.Name = "formEditUser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "EditUser";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonEUClose;
        private System.Windows.Forms.Label labelEUName;
        private System.Windows.Forms.Label labelEUPrimaryEmailAddress;
        private System.Windows.Forms.TextBox textEUName;
        private System.Windows.Forms.ComboBox comboEUPrimaryEmailAddress;
        private System.Windows.Forms.ListBox listEUProxyAddresses;
        private System.Windows.Forms.Label labelEUProxyAddresses;
        private System.Windows.Forms.Button buttonEUAddNewEmail;
    }
}