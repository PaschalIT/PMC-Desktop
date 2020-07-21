namespace PMC_Desktop {
    partial class formPMC {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formPMC));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabUserManagement = new System.Windows.Forms.TabPage();
            this.buttonUMReloadUserList = new System.Windows.Forms.Button();
            this.buttonUMShowEmployeeNumber = new System.Windows.Forms.Button();
            this.listUMUserHistory = new System.Windows.Forms.ListBox();
            this.labelUMUserHistory = new System.Windows.Forms.Label();
            this.buttonUMClearUserHistory = new System.Windows.Forms.Button();
            this.labelUMLastModified = new System.Windows.Forms.Label();
            this.labelUMDateOfTermination = new System.Windows.Forms.Label();
            this.labelUMDateOfHire = new System.Windows.Forms.Label();
            this.labelUMFailedLogons = new System.Windows.Forms.Label();
            this.labelUMPassExpiration = new System.Windows.Forms.Label();
            this.labelUMPassLastChanged = new System.Windows.Forms.Label();
            this.labelUMEmployeeNumber = new System.Windows.Forms.Label();
            this.labelUMEmployeeID = new System.Windows.Forms.Label();
            this.labelUMLastLogon = new System.Windows.Forms.Label();
            this.labelUMEnabled = new System.Windows.Forms.Label();
            this.listUMDirectReports = new System.Windows.Forms.ListBox();
            this.labelUMDirectReports = new System.Windows.Forms.Label();
            this.labelUMManager = new System.Windows.Forms.Label();
            this.labelUMTitle = new System.Windows.Forms.Label();
            this.labelUMDepartment = new System.Windows.Forms.Label();
            this.labelUMEmail = new System.Windows.Forms.Label();
            this.labelUMUsername = new System.Windows.Forms.Label();
            this.labelUMDisplayName = new System.Windows.Forms.Label();
            this.textUMLastModified = new System.Windows.Forms.TextBox();
            this.textUMDateOfTermination = new System.Windows.Forms.TextBox();
            this.textUMDateOfHire = new System.Windows.Forms.TextBox();
            this.textUMFailedLogonNum = new System.Windows.Forms.TextBox();
            this.textUMFailedLogonTime = new System.Windows.Forms.TextBox();
            this.textUMPassExpiration = new System.Windows.Forms.TextBox();
            this.textUMPassLastChanged = new System.Windows.Forms.TextBox();
            this.textUMEmployeeNumber = new System.Windows.Forms.TextBox();
            this.textUMEmployeeID = new System.Windows.Forms.TextBox();
            this.textUMLastLogon = new System.Windows.Forms.TextBox();
            this.textUMEnabled = new System.Windows.Forms.TextBox();
            this.textUMManager = new System.Windows.Forms.TextBox();
            this.textUMTitle = new System.Windows.Forms.TextBox();
            this.textUMDepartment = new System.Windows.Forms.TextBox();
            this.textUMEmail = new System.Windows.Forms.TextBox();
            this.textUMUsername = new System.Windows.Forms.TextBox();
            this.checkUMTerminatedUsers = new System.Windows.Forms.CheckBox();
            this.textUMDisplayName = new System.Windows.Forms.TextBox();
            this.labelUMUserSelect = new System.Windows.Forms.Label();
            this.comboUMUserSelect = new System.Windows.Forms.ComboBox();
            this.tabControl1.SuspendLayout();
            this.tabUserManagement.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabUserManagement);
            this.tabControl1.Location = new System.Drawing.Point(8, 8);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(865, 567);
            this.tabControl1.TabIndex = 0;
            // 
            // tabUserManagement
            // 
            this.tabUserManagement.BackgroundImage = global::PMC_Desktop.Properties.Resources.Paschal_P_30;
            this.tabUserManagement.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.tabUserManagement.Controls.Add(this.buttonUMReloadUserList);
            this.tabUserManagement.Controls.Add(this.buttonUMShowEmployeeNumber);
            this.tabUserManagement.Controls.Add(this.listUMUserHistory);
            this.tabUserManagement.Controls.Add(this.labelUMUserHistory);
            this.tabUserManagement.Controls.Add(this.buttonUMClearUserHistory);
            this.tabUserManagement.Controls.Add(this.labelUMLastModified);
            this.tabUserManagement.Controls.Add(this.labelUMDateOfTermination);
            this.tabUserManagement.Controls.Add(this.labelUMDateOfHire);
            this.tabUserManagement.Controls.Add(this.labelUMFailedLogons);
            this.tabUserManagement.Controls.Add(this.labelUMPassExpiration);
            this.tabUserManagement.Controls.Add(this.labelUMPassLastChanged);
            this.tabUserManagement.Controls.Add(this.labelUMEmployeeNumber);
            this.tabUserManagement.Controls.Add(this.labelUMEmployeeID);
            this.tabUserManagement.Controls.Add(this.labelUMLastLogon);
            this.tabUserManagement.Controls.Add(this.labelUMEnabled);
            this.tabUserManagement.Controls.Add(this.listUMDirectReports);
            this.tabUserManagement.Controls.Add(this.labelUMDirectReports);
            this.tabUserManagement.Controls.Add(this.labelUMManager);
            this.tabUserManagement.Controls.Add(this.labelUMTitle);
            this.tabUserManagement.Controls.Add(this.labelUMDepartment);
            this.tabUserManagement.Controls.Add(this.labelUMEmail);
            this.tabUserManagement.Controls.Add(this.labelUMUsername);
            this.tabUserManagement.Controls.Add(this.labelUMDisplayName);
            this.tabUserManagement.Controls.Add(this.textUMLastModified);
            this.tabUserManagement.Controls.Add(this.textUMDateOfTermination);
            this.tabUserManagement.Controls.Add(this.textUMDateOfHire);
            this.tabUserManagement.Controls.Add(this.textUMFailedLogonNum);
            this.tabUserManagement.Controls.Add(this.textUMFailedLogonTime);
            this.tabUserManagement.Controls.Add(this.textUMPassExpiration);
            this.tabUserManagement.Controls.Add(this.textUMPassLastChanged);
            this.tabUserManagement.Controls.Add(this.textUMEmployeeNumber);
            this.tabUserManagement.Controls.Add(this.textUMEmployeeID);
            this.tabUserManagement.Controls.Add(this.textUMLastLogon);
            this.tabUserManagement.Controls.Add(this.textUMEnabled);
            this.tabUserManagement.Controls.Add(this.textUMManager);
            this.tabUserManagement.Controls.Add(this.textUMTitle);
            this.tabUserManagement.Controls.Add(this.textUMDepartment);
            this.tabUserManagement.Controls.Add(this.textUMEmail);
            this.tabUserManagement.Controls.Add(this.textUMUsername);
            this.tabUserManagement.Controls.Add(this.checkUMTerminatedUsers);
            this.tabUserManagement.Controls.Add(this.textUMDisplayName);
            this.tabUserManagement.Controls.Add(this.labelUMUserSelect);
            this.tabUserManagement.Controls.Add(this.comboUMUserSelect);
            this.tabUserManagement.Location = new System.Drawing.Point(4, 22);
            this.tabUserManagement.Margin = new System.Windows.Forms.Padding(2);
            this.tabUserManagement.Name = "tabUserManagement";
            this.tabUserManagement.Padding = new System.Windows.Forms.Padding(2);
            this.tabUserManagement.Size = new System.Drawing.Size(857, 541);
            this.tabUserManagement.TabIndex = 0;
            this.tabUserManagement.Text = "User Management";
            this.tabUserManagement.UseVisualStyleBackColor = true;
            // 
            // buttonUMReloadUserList
            // 
            this.buttonUMReloadUserList.Location = new System.Drawing.Point(466, 4);
            this.buttonUMReloadUserList.Name = "buttonUMReloadUserList";
            this.buttonUMReloadUserList.Size = new System.Drawing.Size(97, 23);
            this.buttonUMReloadUserList.TabIndex = 43;
            this.buttonUMReloadUserList.Text = "Reload User List";
            this.buttonUMReloadUserList.UseVisualStyleBackColor = true;
            this.buttonUMReloadUserList.Click += new System.EventHandler(this.buttonUMReloadUserList_Click);
            // 
            // buttonUMShowEmployeeNumber
            // 
            this.buttonUMShowEmployeeNumber.Location = new System.Drawing.Point(786, 132);
            this.buttonUMShowEmployeeNumber.Name = "buttonUMShowEmployeeNumber";
            this.buttonUMShowEmployeeNumber.Size = new System.Drawing.Size(66, 22);
            this.buttonUMShowEmployeeNumber.TabIndex = 42;
            this.buttonUMShowEmployeeNumber.Text = "Show";
            this.buttonUMShowEmployeeNumber.UseVisualStyleBackColor = true;
            this.buttonUMShowEmployeeNumber.Click += new System.EventHandler(this.buttonUMShowEmployeeNumber_Click);
            // 
            // listUMUserHistory
            // 
            this.listUMUserHistory.FormattingEnabled = true;
            this.listUMUserHistory.Location = new System.Drawing.Point(5, 55);
            this.listUMUserHistory.Name = "listUMUserHistory";
            this.listUMUserHistory.Size = new System.Drawing.Size(113, 446);
            this.listUMUserHistory.TabIndex = 41;
            // 
            // labelUMUserHistory
            // 
            this.labelUMUserHistory.AutoSize = true;
            this.labelUMUserHistory.Location = new System.Drawing.Point(5, 39);
            this.labelUMUserHistory.Name = "labelUMUserHistory";
            this.labelUMUserHistory.Size = new System.Drawing.Size(64, 13);
            this.labelUMUserHistory.TabIndex = 40;
            this.labelUMUserHistory.Text = "User History";
            // 
            // buttonUMClearUserHistory
            // 
            this.buttonUMClearUserHistory.Location = new System.Drawing.Point(5, 508);
            this.buttonUMClearUserHistory.Name = "buttonUMClearUserHistory";
            this.buttonUMClearUserHistory.Size = new System.Drawing.Size(113, 28);
            this.buttonUMClearUserHistory.TabIndex = 39;
            this.buttonUMClearUserHistory.Text = "Clear History";
            this.buttonUMClearUserHistory.UseVisualStyleBackColor = true;
            // 
            // labelUMLastModified
            // 
            this.labelUMLastModified.AutoSize = true;
            this.labelUMLastModified.Location = new System.Drawing.Point(470, 292);
            this.labelUMLastModified.Name = "labelUMLastModified";
            this.labelUMLastModified.Size = new System.Drawing.Size(70, 13);
            this.labelUMLastModified.TabIndex = 37;
            this.labelUMLastModified.Text = "Last Modified";
            // 
            // labelUMDateOfTermination
            // 
            this.labelUMDateOfTermination.AutoSize = true;
            this.labelUMDateOfTermination.Location = new System.Drawing.Point(470, 266);
            this.labelUMDateOfTermination.Name = "labelUMDateOfTermination";
            this.labelUMDateOfTermination.Size = new System.Drawing.Size(100, 13);
            this.labelUMDateOfTermination.TabIndex = 36;
            this.labelUMDateOfTermination.Text = "Date of Termination";
            // 
            // labelUMDateOfHire
            // 
            this.labelUMDateOfHire.AutoSize = true;
            this.labelUMDateOfHire.Location = new System.Drawing.Point(470, 240);
            this.labelUMDateOfHire.Name = "labelUMDateOfHire";
            this.labelUMDateOfHire.Size = new System.Drawing.Size(64, 13);
            this.labelUMDateOfHire.TabIndex = 35;
            this.labelUMDateOfHire.Text = "Date of Hire";
            // 
            // labelUMFailedLogons
            // 
            this.labelUMFailedLogons.AutoSize = true;
            this.labelUMFailedLogons.Location = new System.Drawing.Point(470, 214);
            this.labelUMFailedLogons.Name = "labelUMFailedLogons";
            this.labelUMFailedLogons.Size = new System.Drawing.Size(73, 13);
            this.labelUMFailedLogons.TabIndex = 34;
            this.labelUMFailedLogons.Text = "Failed Logons";
            // 
            // labelUMPassExpiration
            // 
            this.labelUMPassExpiration.AutoSize = true;
            this.labelUMPassExpiration.Location = new System.Drawing.Point(470, 188);
            this.labelUMPassExpiration.Name = "labelUMPassExpiration";
            this.labelUMPassExpiration.Size = new System.Drawing.Size(79, 13);
            this.labelUMPassExpiration.TabIndex = 33;
            this.labelUMPassExpiration.Text = "Pass Expiration";
            // 
            // labelUMPassLastChanged
            // 
            this.labelUMPassLastChanged.AutoSize = true;
            this.labelUMPassLastChanged.Location = new System.Drawing.Point(470, 162);
            this.labelUMPassLastChanged.Name = "labelUMPassLastChanged";
            this.labelUMPassLastChanged.Size = new System.Drawing.Size(99, 13);
            this.labelUMPassLastChanged.TabIndex = 32;
            this.labelUMPassLastChanged.Text = "Pass Last Changed";
            // 
            // labelUMEmployeeNumber
            // 
            this.labelUMEmployeeNumber.AutoSize = true;
            this.labelUMEmployeeNumber.Location = new System.Drawing.Point(470, 136);
            this.labelUMEmployeeNumber.Name = "labelUMEmployeeNumber";
            this.labelUMEmployeeNumber.Size = new System.Drawing.Size(93, 13);
            this.labelUMEmployeeNumber.TabIndex = 31;
            this.labelUMEmployeeNumber.Text = "Employee Number";
            // 
            // labelUMEmployeeID
            // 
            this.labelUMEmployeeID.AutoSize = true;
            this.labelUMEmployeeID.Location = new System.Drawing.Point(470, 110);
            this.labelUMEmployeeID.Name = "labelUMEmployeeID";
            this.labelUMEmployeeID.Size = new System.Drawing.Size(67, 13);
            this.labelUMEmployeeID.TabIndex = 30;
            this.labelUMEmployeeID.Text = "Employee ID";
            // 
            // labelUMLastLogon
            // 
            this.labelUMLastLogon.AutoSize = true;
            this.labelUMLastLogon.Location = new System.Drawing.Point(470, 84);
            this.labelUMLastLogon.Name = "labelUMLastLogon";
            this.labelUMLastLogon.Size = new System.Drawing.Size(60, 13);
            this.labelUMLastLogon.TabIndex = 29;
            this.labelUMLastLogon.Text = "Last Logon";
            // 
            // labelUMEnabled
            // 
            this.labelUMEnabled.AutoSize = true;
            this.labelUMEnabled.Location = new System.Drawing.Point(470, 58);
            this.labelUMEnabled.Name = "labelUMEnabled";
            this.labelUMEnabled.Size = new System.Drawing.Size(46, 13);
            this.labelUMEnabled.TabIndex = 28;
            this.labelUMEnabled.Text = "Enabled";
            // 
            // listUMDirectReports
            // 
            this.listUMDirectReports.FormattingEnabled = true;
            this.listUMDirectReports.Location = new System.Drawing.Point(210, 211);
            this.listUMDirectReports.Name = "listUMDirectReports";
            this.listUMDirectReports.Size = new System.Drawing.Size(200, 186);
            this.listUMDirectReports.TabIndex = 27;
            // 
            // labelUMDirectReports
            // 
            this.labelUMDirectReports.AutoSize = true;
            this.labelUMDirectReports.Location = new System.Drawing.Point(124, 214);
            this.labelUMDirectReports.Name = "labelUMDirectReports";
            this.labelUMDirectReports.Size = new System.Drawing.Size(75, 13);
            this.labelUMDirectReports.TabIndex = 26;
            this.labelUMDirectReports.Text = "Direct Reports";
            // 
            // labelUMManager
            // 
            this.labelUMManager.AutoSize = true;
            this.labelUMManager.Location = new System.Drawing.Point(124, 188);
            this.labelUMManager.Name = "labelUMManager";
            this.labelUMManager.Size = new System.Drawing.Size(49, 13);
            this.labelUMManager.TabIndex = 25;
            this.labelUMManager.Text = "Manager";
            // 
            // labelUMTitle
            // 
            this.labelUMTitle.AutoSize = true;
            this.labelUMTitle.Location = new System.Drawing.Point(124, 162);
            this.labelUMTitle.Name = "labelUMTitle";
            this.labelUMTitle.Size = new System.Drawing.Size(27, 13);
            this.labelUMTitle.TabIndex = 24;
            this.labelUMTitle.Text = "Title";
            // 
            // labelUMDepartment
            // 
            this.labelUMDepartment.AutoSize = true;
            this.labelUMDepartment.Location = new System.Drawing.Point(124, 136);
            this.labelUMDepartment.Name = "labelUMDepartment";
            this.labelUMDepartment.Size = new System.Drawing.Size(62, 13);
            this.labelUMDepartment.TabIndex = 23;
            this.labelUMDepartment.Text = "Department";
            // 
            // labelUMEmail
            // 
            this.labelUMEmail.AutoSize = true;
            this.labelUMEmail.Location = new System.Drawing.Point(124, 110);
            this.labelUMEmail.Name = "labelUMEmail";
            this.labelUMEmail.Size = new System.Drawing.Size(32, 13);
            this.labelUMEmail.TabIndex = 22;
            this.labelUMEmail.Text = "Email";
            // 
            // labelUMUsername
            // 
            this.labelUMUsername.AutoSize = true;
            this.labelUMUsername.Location = new System.Drawing.Point(124, 84);
            this.labelUMUsername.Name = "labelUMUsername";
            this.labelUMUsername.Size = new System.Drawing.Size(55, 13);
            this.labelUMUsername.TabIndex = 21;
            this.labelUMUsername.Text = "Username";
            // 
            // labelUMDisplayName
            // 
            this.labelUMDisplayName.AutoSize = true;
            this.labelUMDisplayName.Location = new System.Drawing.Point(124, 57);
            this.labelUMDisplayName.Name = "labelUMDisplayName";
            this.labelUMDisplayName.Size = new System.Drawing.Size(35, 13);
            this.labelUMDisplayName.TabIndex = 20;
            this.labelUMDisplayName.Text = "Name";
            // 
            // textUMLastModified
            // 
            this.textUMLastModified.Location = new System.Drawing.Point(580, 289);
            this.textUMLastModified.Name = "textUMLastModified";
            this.textUMLastModified.Size = new System.Drawing.Size(200, 20);
            this.textUMLastModified.TabIndex = 19;
            // 
            // textUMDateOfTermination
            // 
            this.textUMDateOfTermination.Location = new System.Drawing.Point(580, 263);
            this.textUMDateOfTermination.Name = "textUMDateOfTermination";
            this.textUMDateOfTermination.Size = new System.Drawing.Size(200, 20);
            this.textUMDateOfTermination.TabIndex = 18;
            // 
            // textUMDateOfHire
            // 
            this.textUMDateOfHire.Location = new System.Drawing.Point(580, 237);
            this.textUMDateOfHire.Name = "textUMDateOfHire";
            this.textUMDateOfHire.Size = new System.Drawing.Size(200, 20);
            this.textUMDateOfHire.TabIndex = 17;
            // 
            // textUMFailedLogonNum
            // 
            this.textUMFailedLogonNum.Location = new System.Drawing.Point(580, 211);
            this.textUMFailedLogonNum.Name = "textUMFailedLogonNum";
            this.textUMFailedLogonNum.Size = new System.Drawing.Size(23, 20);
            this.textUMFailedLogonNum.TabIndex = 16;
            // 
            // textUMFailedLogonTime
            // 
            this.textUMFailedLogonTime.Location = new System.Drawing.Point(609, 211);
            this.textUMFailedLogonTime.Name = "textUMFailedLogonTime";
            this.textUMFailedLogonTime.Size = new System.Drawing.Size(171, 20);
            this.textUMFailedLogonTime.TabIndex = 15;
            // 
            // textUMPassExpiration
            // 
            this.textUMPassExpiration.Location = new System.Drawing.Point(580, 185);
            this.textUMPassExpiration.Name = "textUMPassExpiration";
            this.textUMPassExpiration.Size = new System.Drawing.Size(200, 20);
            this.textUMPassExpiration.TabIndex = 14;
            // 
            // textUMPassLastChanged
            // 
            this.textUMPassLastChanged.Location = new System.Drawing.Point(580, 159);
            this.textUMPassLastChanged.Name = "textUMPassLastChanged";
            this.textUMPassLastChanged.Size = new System.Drawing.Size(200, 20);
            this.textUMPassLastChanged.TabIndex = 13;
            // 
            // textUMEmployeeNumber
            // 
            this.textUMEmployeeNumber.Location = new System.Drawing.Point(580, 133);
            this.textUMEmployeeNumber.Name = "textUMEmployeeNumber";
            this.textUMEmployeeNumber.Size = new System.Drawing.Size(200, 20);
            this.textUMEmployeeNumber.TabIndex = 12;
            this.textUMEmployeeNumber.UseSystemPasswordChar = true;
            // 
            // textUMEmployeeID
            // 
            this.textUMEmployeeID.Location = new System.Drawing.Point(580, 107);
            this.textUMEmployeeID.Name = "textUMEmployeeID";
            this.textUMEmployeeID.Size = new System.Drawing.Size(200, 20);
            this.textUMEmployeeID.TabIndex = 11;
            // 
            // textUMLastLogon
            // 
            this.textUMLastLogon.Location = new System.Drawing.Point(580, 81);
            this.textUMLastLogon.Name = "textUMLastLogon";
            this.textUMLastLogon.Size = new System.Drawing.Size(200, 20);
            this.textUMLastLogon.TabIndex = 10;
            // 
            // textUMEnabled
            // 
            this.textUMEnabled.Location = new System.Drawing.Point(580, 55);
            this.textUMEnabled.Name = "textUMEnabled";
            this.textUMEnabled.Size = new System.Drawing.Size(200, 20);
            this.textUMEnabled.TabIndex = 9;
            // 
            // textUMManager
            // 
            this.textUMManager.Location = new System.Drawing.Point(210, 185);
            this.textUMManager.Name = "textUMManager";
            this.textUMManager.Size = new System.Drawing.Size(200, 20);
            this.textUMManager.TabIndex = 8;
            // 
            // textUMTitle
            // 
            this.textUMTitle.Location = new System.Drawing.Point(210, 159);
            this.textUMTitle.Name = "textUMTitle";
            this.textUMTitle.Size = new System.Drawing.Size(200, 20);
            this.textUMTitle.TabIndex = 7;
            // 
            // textUMDepartment
            // 
            this.textUMDepartment.Location = new System.Drawing.Point(210, 133);
            this.textUMDepartment.Name = "textUMDepartment";
            this.textUMDepartment.Size = new System.Drawing.Size(200, 20);
            this.textUMDepartment.TabIndex = 6;
            // 
            // textUMEmail
            // 
            this.textUMEmail.Location = new System.Drawing.Point(210, 107);
            this.textUMEmail.Name = "textUMEmail";
            this.textUMEmail.Size = new System.Drawing.Size(200, 20);
            this.textUMEmail.TabIndex = 5;
            // 
            // textUMUsername
            // 
            this.textUMUsername.Location = new System.Drawing.Point(210, 81);
            this.textUMUsername.Name = "textUMUsername";
            this.textUMUsername.Size = new System.Drawing.Size(200, 20);
            this.textUMUsername.TabIndex = 4;
            // 
            // checkUMTerminatedUsers
            // 
            this.checkUMTerminatedUsers.AutoSize = true;
            this.checkUMTerminatedUsers.Location = new System.Drawing.Point(210, 32);
            this.checkUMTerminatedUsers.Name = "checkUMTerminatedUsers";
            this.checkUMTerminatedUsers.Size = new System.Drawing.Size(147, 17);
            this.checkUMTerminatedUsers.TabIndex = 3;
            this.checkUMTerminatedUsers.Text = "Include Terminated Users";
            this.checkUMTerminatedUsers.UseVisualStyleBackColor = true;
            this.checkUMTerminatedUsers.CheckedChanged += new System.EventHandler(this.checkUMTerminatedUsers_CheckedChanged);
            // 
            // textUMDisplayName
            // 
            this.textUMDisplayName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textUMDisplayName.Location = new System.Drawing.Point(210, 55);
            this.textUMDisplayName.Name = "textUMDisplayName";
            this.textUMDisplayName.Size = new System.Drawing.Size(200, 20);
            this.textUMDisplayName.TabIndex = 2;
            // 
            // labelUMUserSelect
            // 
            this.labelUMUserSelect.AutoSize = true;
            this.labelUMUserSelect.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUMUserSelect.Location = new System.Drawing.Point(124, 5);
            this.labelUMUserSelect.Name = "labelUMUserSelect";
            this.labelUMUserSelect.Size = new System.Drawing.Size(80, 15);
            this.labelUMUserSelect.TabIndex = 1;
            this.labelUMUserSelect.Text = "Select a User";
            // 
            // comboUMUserSelect
            // 
            this.comboUMUserSelect.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboUMUserSelect.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboUMUserSelect.FormattingEnabled = true;
            this.comboUMUserSelect.Location = new System.Drawing.Point(210, 5);
            this.comboUMUserSelect.Name = "comboUMUserSelect";
            this.comboUMUserSelect.Size = new System.Drawing.Size(250, 21);
            this.comboUMUserSelect.TabIndex = 0;
            this.comboUMUserSelect.SelectedIndexChanged += new System.EventHandler(this.comboUMUserSelect_SelectedIndexChanged);
            // 
            // formPMC
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(884, 586);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximumSize = new System.Drawing.Size(900, 5000);
            this.MinimumSize = new System.Drawing.Size(900, 550);
            this.Name = "formPMC";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PMC";
            this.Load += new System.EventHandler(this.formPMC_Load);
            this.Shown += new System.EventHandler(this.formPMC_Shown);
            this.tabControl1.ResumeLayout(false);
            this.tabUserManagement.ResumeLayout(false);
            this.tabUserManagement.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabUserManagement;
        private System.Windows.Forms.ComboBox comboUMUserSelect;
        private System.Windows.Forms.Label labelUMUserSelect;
        private System.Windows.Forms.TextBox textUMDisplayName;
        private System.Windows.Forms.CheckBox checkUMTerminatedUsers;
        private System.Windows.Forms.TextBox textUMDepartment;
        private System.Windows.Forms.TextBox textUMEmail;
        private System.Windows.Forms.TextBox textUMUsername;
        private System.Windows.Forms.TextBox textUMTitle;
        private System.Windows.Forms.TextBox textUMLastModified;
        private System.Windows.Forms.TextBox textUMDateOfTermination;
        private System.Windows.Forms.TextBox textUMDateOfHire;
        private System.Windows.Forms.TextBox textUMFailedLogonNum;
        private System.Windows.Forms.TextBox textUMFailedLogonTime;
        private System.Windows.Forms.TextBox textUMPassExpiration;
        private System.Windows.Forms.TextBox textUMPassLastChanged;
        private System.Windows.Forms.TextBox textUMEmployeeNumber;
        private System.Windows.Forms.TextBox textUMEmployeeID;
        private System.Windows.Forms.TextBox textUMLastLogon;
        private System.Windows.Forms.TextBox textUMEnabled;
        private System.Windows.Forms.TextBox textUMManager;
        private System.Windows.Forms.Button buttonUMShowEmployeeNumber;
        private System.Windows.Forms.ListBox listUMUserHistory;
        private System.Windows.Forms.Label labelUMUserHistory;
        private System.Windows.Forms.Button buttonUMClearUserHistory;
        private System.Windows.Forms.Label labelUMLastModified;
        private System.Windows.Forms.Label labelUMDateOfTermination;
        private System.Windows.Forms.Label labelUMDateOfHire;
        private System.Windows.Forms.Label labelUMFailedLogons;
        private System.Windows.Forms.Label labelUMPassExpiration;
        private System.Windows.Forms.Label labelUMPassLastChanged;
        private System.Windows.Forms.Label labelUMEmployeeNumber;
        private System.Windows.Forms.Label labelUMEmployeeID;
        private System.Windows.Forms.Label labelUMLastLogon;
        private System.Windows.Forms.Label labelUMEnabled;
        private System.Windows.Forms.ListBox listUMDirectReports;
        private System.Windows.Forms.Label labelUMDirectReports;
        private System.Windows.Forms.Label labelUMManager;
        private System.Windows.Forms.Label labelUMTitle;
        private System.Windows.Forms.Label labelUMDepartment;
        private System.Windows.Forms.Label labelUMEmail;
        private System.Windows.Forms.Label labelUMUsername;
        private System.Windows.Forms.Label labelUMDisplayName;
        private System.Windows.Forms.Button buttonUMReloadUserList;
    }
}

