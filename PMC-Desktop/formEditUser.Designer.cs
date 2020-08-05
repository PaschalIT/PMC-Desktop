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
            this.components = new System.ComponentModel.Container();
            this.buttonEUApplyChanges = new System.Windows.Forms.Button();
            this.labelEUFirstName = new System.Windows.Forms.Label();
            this.labelEUPrimaryEmailAddress = new System.Windows.Forms.Label();
            this.textEUFirstName = new System.Windows.Forms.TextBox();
            this.comboEUPrimaryEmailAddress = new System.Windows.Forms.ComboBox();
            this.listEUProxyAddresses = new System.Windows.Forms.ListBox();
            this.labelEUProxyAddresses = new System.Windows.Forms.Label();
            this.buttonEUAddNewEmail = new System.Windows.Forms.Button();
            this.textEUMiddleName = new System.Windows.Forms.TextBox();
            this.textEULastName = new System.Windows.Forms.TextBox();
            this.labelEUMiddleName = new System.Windows.Forms.Label();
            this.labelEULastName = new System.Windows.Forms.Label();
            this.labelEUDepartment = new System.Windows.Forms.Label();
            this.comboEUDepartment = new System.Windows.Forms.ComboBox();
            this.labelEUTitle = new System.Windows.Forms.Label();
            this.textEUTitle = new System.Windows.Forms.TextBox();
            this.labelEUManager = new System.Windows.Forms.Label();
            this.textEUManager = new System.Windows.Forms.TextBox();
            this.labelEUManagerName = new System.Windows.Forms.Label();
            this.labelEUUserEmailNotEnabled = new System.Windows.Forms.Label();
            this.buttonEUCancel = new System.Windows.Forms.Button();
            this.labelEUDisplayName = new System.Windows.Forms.Label();
            this.textEUDisplayName = new System.Windows.Forms.TextBox();
            this.errorEUNotify = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorEUNotify)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonEUApplyChanges
            // 
            this.buttonEUApplyChanges.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonEUApplyChanges.Location = new System.Drawing.Point(315, 373);
            this.buttonEUApplyChanges.Name = "buttonEUApplyChanges";
            this.buttonEUApplyChanges.Size = new System.Drawing.Size(88, 34);
            this.buttonEUApplyChanges.TabIndex = 1;
            this.buttonEUApplyChanges.Text = "Apply Changes";
            this.buttonEUApplyChanges.UseVisualStyleBackColor = true;
            this.buttonEUApplyChanges.Click += new System.EventHandler(this.buttonEUApplyChanges_Click);
            // 
            // labelEUFirstName
            // 
            this.labelEUFirstName.AutoSize = true;
            this.labelEUFirstName.Location = new System.Drawing.Point(16, 31);
            this.labelEUFirstName.Name = "labelEUFirstName";
            this.labelEUFirstName.Size = new System.Drawing.Size(57, 13);
            this.labelEUFirstName.TabIndex = 2;
            this.labelEUFirstName.Text = "First Name";
            // 
            // labelEUPrimaryEmailAddress
            // 
            this.labelEUPrimaryEmailAddress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelEUPrimaryEmailAddress.AutoSize = true;
            this.labelEUPrimaryEmailAddress.Location = new System.Drawing.Point(16, 245);
            this.labelEUPrimaryEmailAddress.Name = "labelEUPrimaryEmailAddress";
            this.labelEUPrimaryEmailAddress.Size = new System.Drawing.Size(110, 13);
            this.labelEUPrimaryEmailAddress.TabIndex = 3;
            this.labelEUPrimaryEmailAddress.Text = "Primary Email Address";
            // 
            // textEUFirstName
            // 
            this.textEUFirstName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textEUFirstName.Location = new System.Drawing.Point(19, 47);
            this.textEUFirstName.Name = "textEUFirstName";
            this.textEUFirstName.Size = new System.Drawing.Size(130, 20);
            this.textEUFirstName.TabIndex = 4;
            this.textEUFirstName.TextChanged += new System.EventHandler(this.textEUFirstName_TextChanged);
            // 
            // comboEUPrimaryEmailAddress
            // 
            this.comboEUPrimaryEmailAddress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.comboEUPrimaryEmailAddress.FormattingEnabled = true;
            this.comboEUPrimaryEmailAddress.Location = new System.Drawing.Point(173, 242);
            this.comboEUPrimaryEmailAddress.Name = "comboEUPrimaryEmailAddress";
            this.comboEUPrimaryEmailAddress.Size = new System.Drawing.Size(230, 21);
            this.comboEUPrimaryEmailAddress.TabIndex = 5;
            this.comboEUPrimaryEmailAddress.SelectedIndexChanged += new System.EventHandler(this.comboEUPrimaryEmailAddress_SelectedIndexChanged);
            // 
            // listEUProxyAddresses
            // 
            this.listEUProxyAddresses.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.listEUProxyAddresses.FormattingEnabled = true;
            this.listEUProxyAddresses.Location = new System.Drawing.Point(173, 269);
            this.listEUProxyAddresses.Name = "listEUProxyAddresses";
            this.listEUProxyAddresses.Size = new System.Drawing.Size(230, 95);
            this.listEUProxyAddresses.TabIndex = 6;
            // 
            // labelEUProxyAddresses
            // 
            this.labelEUProxyAddresses.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelEUProxyAddresses.AutoSize = true;
            this.labelEUProxyAddresses.Location = new System.Drawing.Point(19, 269);
            this.labelEUProxyAddresses.Name = "labelEUProxyAddresses";
            this.labelEUProxyAddresses.Size = new System.Drawing.Size(133, 13);
            this.labelEUProxyAddresses.TabIndex = 7;
            this.labelEUProxyAddresses.Text = "Additional Email Addresses";
            // 
            // buttonEUAddNewEmail
            // 
            this.buttonEUAddNewEmail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonEUAddNewEmail.Location = new System.Drawing.Point(77, 288);
            this.buttonEUAddNewEmail.Name = "buttonEUAddNewEmail";
            this.buttonEUAddNewEmail.Size = new System.Drawing.Size(75, 23);
            this.buttonEUAddNewEmail.TabIndex = 8;
            this.buttonEUAddNewEmail.Text = "Add New";
            this.buttonEUAddNewEmail.UseVisualStyleBackColor = true;
            this.buttonEUAddNewEmail.Click += new System.EventHandler(this.buttonEUAddNewEmail_Click);
            // 
            // textEUMiddleName
            // 
            this.textEUMiddleName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textEUMiddleName.Location = new System.Drawing.Point(155, 47);
            this.textEUMiddleName.Name = "textEUMiddleName";
            this.textEUMiddleName.Size = new System.Drawing.Size(107, 20);
            this.textEUMiddleName.TabIndex = 9;
            this.textEUMiddleName.TextChanged += new System.EventHandler(this.textEUMiddleName_TextChanged);
            // 
            // textEULastName
            // 
            this.textEULastName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textEULastName.Location = new System.Drawing.Point(268, 47);
            this.textEULastName.Name = "textEULastName";
            this.textEULastName.Size = new System.Drawing.Size(135, 20);
            this.textEULastName.TabIndex = 10;
            this.textEULastName.TextChanged += new System.EventHandler(this.textEULastName_TextChanged);
            // 
            // labelEUMiddleName
            // 
            this.labelEUMiddleName.AutoSize = true;
            this.labelEUMiddleName.Location = new System.Drawing.Point(152, 31);
            this.labelEUMiddleName.Name = "labelEUMiddleName";
            this.labelEUMiddleName.Size = new System.Drawing.Size(98, 13);
            this.labelEUMiddleName.TabIndex = 11;
            this.labelEUMiddleName.Text = "Middle Name/Initial";
            // 
            // labelEULastName
            // 
            this.labelEULastName.AutoSize = true;
            this.labelEULastName.Location = new System.Drawing.Point(265, 31);
            this.labelEULastName.Name = "labelEULastName";
            this.labelEULastName.Size = new System.Drawing.Size(58, 13);
            this.labelEULastName.TabIndex = 12;
            this.labelEULastName.Text = "Last Name";
            // 
            // labelEUDepartment
            // 
            this.labelEUDepartment.AutoSize = true;
            this.labelEUDepartment.Location = new System.Drawing.Point(19, 113);
            this.labelEUDepartment.Name = "labelEUDepartment";
            this.labelEUDepartment.Size = new System.Drawing.Size(62, 13);
            this.labelEUDepartment.TabIndex = 13;
            this.labelEUDepartment.Text = "Department";
            // 
            // comboEUDepartment
            // 
            this.comboEUDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboEUDepartment.FormattingEnabled = true;
            this.comboEUDepartment.Items.AddRange(new object[] {
            "Accounting",
            "Administration",
            "CSR",
            "Electrical",
            "HR",
            "HVAC_Install",
            "HVAC_Service",
            "IT",
            "Marketing",
            "Plumbing",
            "Sales",
            "Warehouse"});
            this.comboEUDepartment.Location = new System.Drawing.Point(19, 129);
            this.comboEUDepartment.Name = "comboEUDepartment";
            this.comboEUDepartment.Size = new System.Drawing.Size(243, 21);
            this.comboEUDepartment.TabIndex = 14;
            this.comboEUDepartment.SelectedIndexChanged += new System.EventHandler(this.comboEUDepartment_SelectedIndexChanged);
            // 
            // labelEUTitle
            // 
            this.labelEUTitle.AutoSize = true;
            this.labelEUTitle.Location = new System.Drawing.Point(19, 153);
            this.labelEUTitle.Name = "labelEUTitle";
            this.labelEUTitle.Size = new System.Drawing.Size(27, 13);
            this.labelEUTitle.TabIndex = 15;
            this.labelEUTitle.Text = "Title";
            // 
            // textEUTitle
            // 
            this.textEUTitle.Location = new System.Drawing.Point(19, 169);
            this.textEUTitle.Name = "textEUTitle";
            this.textEUTitle.Size = new System.Drawing.Size(243, 20);
            this.textEUTitle.TabIndex = 16;
            this.textEUTitle.TextChanged += new System.EventHandler(this.textEUTitle_TextChanged);
            // 
            // labelEUManager
            // 
            this.labelEUManager.AutoSize = true;
            this.labelEUManager.Location = new System.Drawing.Point(19, 192);
            this.labelEUManager.Name = "labelEUManager";
            this.labelEUManager.Size = new System.Drawing.Size(49, 13);
            this.labelEUManager.TabIndex = 17;
            this.labelEUManager.Text = "Manager";
            // 
            // textEUManager
            // 
            this.textEUManager.Location = new System.Drawing.Point(19, 209);
            this.textEUManager.Name = "textEUManager";
            this.textEUManager.Size = new System.Drawing.Size(243, 20);
            this.textEUManager.TabIndex = 18;
            this.textEUManager.TextChanged += new System.EventHandler(this.textEUManager_TextChanged);
            // 
            // labelEUManagerName
            // 
            this.labelEUManagerName.AutoSize = true;
            this.labelEUManagerName.Location = new System.Drawing.Point(268, 212);
            this.labelEUManagerName.Name = "labelEUManagerName";
            this.labelEUManagerName.Size = new System.Drawing.Size(0, 13);
            this.labelEUManagerName.TabIndex = 19;
            // 
            // labelEUUserEmailNotEnabled
            // 
            this.labelEUUserEmailNotEnabled.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelEUUserEmailNotEnabled.AutoSize = true;
            this.labelEUUserEmailNotEnabled.BackColor = System.Drawing.Color.Transparent;
            this.labelEUUserEmailNotEnabled.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelEUUserEmailNotEnabled.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEUUserEmailNotEnabled.Location = new System.Drawing.Point(15, 241);
            this.labelEUUserEmailNotEnabled.Name = "labelEUUserEmailNotEnabled";
            this.labelEUUserEmailNotEnabled.Size = new System.Drawing.Size(388, 41);
            this.labelEUUserEmailNotEnabled.TabIndex = 20;
            this.labelEUUserEmailNotEnabled.Text = "User Email Not Enabled";
            this.labelEUUserEmailNotEnabled.Visible = false;
            // 
            // buttonEUCancel
            // 
            this.buttonEUCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonEUCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonEUCancel.Location = new System.Drawing.Point(221, 373);
            this.buttonEUCancel.Name = "buttonEUCancel";
            this.buttonEUCancel.Size = new System.Drawing.Size(88, 34);
            this.buttonEUCancel.TabIndex = 21;
            this.buttonEUCancel.Text = "Cancel";
            this.buttonEUCancel.UseVisualStyleBackColor = true;
            // 
            // labelEUDisplayName
            // 
            this.labelEUDisplayName.AutoSize = true;
            this.labelEUDisplayName.Location = new System.Drawing.Point(19, 74);
            this.labelEUDisplayName.Name = "labelEUDisplayName";
            this.labelEUDisplayName.Size = new System.Drawing.Size(72, 13);
            this.labelEUDisplayName.TabIndex = 22;
            this.labelEUDisplayName.Text = "Display Name";
            // 
            // textEUDisplayName
            // 
            this.textEUDisplayName.Location = new System.Drawing.Point(19, 90);
            this.textEUDisplayName.Name = "textEUDisplayName";
            this.textEUDisplayName.Size = new System.Drawing.Size(243, 20);
            this.textEUDisplayName.TabIndex = 23;
            this.textEUDisplayName.TextChanged += new System.EventHandler(this.textEUDisplayName_TextChanged);
            // 
            // errorEUNotify
            // 
            this.errorEUNotify.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorEUNotify.ContainerControl = this;
            // 
            // formEditUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonEUCancel;
            this.ClientSize = new System.Drawing.Size(415, 419);
            this.Controls.Add(this.textEUDisplayName);
            this.Controls.Add(this.labelEUDisplayName);
            this.Controls.Add(this.buttonEUCancel);
            this.Controls.Add(this.labelEUManagerName);
            this.Controls.Add(this.textEUManager);
            this.Controls.Add(this.labelEUManager);
            this.Controls.Add(this.textEUTitle);
            this.Controls.Add(this.labelEUTitle);
            this.Controls.Add(this.comboEUDepartment);
            this.Controls.Add(this.labelEUDepartment);
            this.Controls.Add(this.labelEULastName);
            this.Controls.Add(this.labelEUMiddleName);
            this.Controls.Add(this.textEULastName);
            this.Controls.Add(this.textEUMiddleName);
            this.Controls.Add(this.buttonEUAddNewEmail);
            this.Controls.Add(this.labelEUProxyAddresses);
            this.Controls.Add(this.listEUProxyAddresses);
            this.Controls.Add(this.comboEUPrimaryEmailAddress);
            this.Controls.Add(this.textEUFirstName);
            this.Controls.Add(this.labelEUPrimaryEmailAddress);
            this.Controls.Add(this.labelEUFirstName);
            this.Controls.Add(this.buttonEUApplyChanges);
            this.Controls.Add(this.labelEUUserEmailNotEnabled);
            this.Name = "formEditUser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "EditUser";
            ((System.ComponentModel.ISupportInitialize)(this.errorEUNotify)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonEUApplyChanges;
        private System.Windows.Forms.Label labelEUFirstName;
        private System.Windows.Forms.Label labelEUPrimaryEmailAddress;
        private System.Windows.Forms.TextBox textEUFirstName;
        private System.Windows.Forms.ComboBox comboEUPrimaryEmailAddress;
        private System.Windows.Forms.ListBox listEUProxyAddresses;
        private System.Windows.Forms.Label labelEUProxyAddresses;
        private System.Windows.Forms.Button buttonEUAddNewEmail;
        private System.Windows.Forms.TextBox textEUMiddleName;
        private System.Windows.Forms.TextBox textEULastName;
        private System.Windows.Forms.Label labelEUMiddleName;
        private System.Windows.Forms.Label labelEULastName;
        private System.Windows.Forms.Label labelEUDepartment;
        private System.Windows.Forms.ComboBox comboEUDepartment;
        private System.Windows.Forms.Label labelEUTitle;
        private System.Windows.Forms.TextBox textEUTitle;
        private System.Windows.Forms.Label labelEUManager;
        private System.Windows.Forms.TextBox textEUManager;
        private System.Windows.Forms.Label labelEUManagerName;
        private System.Windows.Forms.Label labelEUUserEmailNotEnabled;
        private System.Windows.Forms.Button buttonEUCancel;
        private System.Windows.Forms.Label labelEUDisplayName;
        private System.Windows.Forms.TextBox textEUDisplayName;
        private System.Windows.Forms.ErrorProvider errorEUNotify;
    }
}