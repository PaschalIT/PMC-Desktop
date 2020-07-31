using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.DirectoryServices;
using System.IO;
using System.Text.RegularExpressions;

namespace PMC_Desktop {
    public partial class formPMC : Form {
        public static User CurrentUser = new User ();

        public formPMC () {
            InitializeComponent ();
        }

        private void formPMC_Load (object sender, EventArgs e) {
            foreach (TextBox control in tabUserManagement.Controls.OfType<TextBox> ()) {
                control.ReadOnly = true;
                control.BackColor = SystemColors.ControlLightLight;
                control.ForeColor = SystemColors.WindowText;
                control.BorderStyle = BorderStyle.FixedSingle;
                control.Cursor = Cursors.Arrow;
            }
            label1.Text = "PMC v";
            //if (ApplicationDeployment.IsNetworkDeployed) {
            //    label1.Text += string.Format ("{0}", ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString ());
            //} else {
            //    label1.Text += "Debug";
            //}
            string path = @"\\WFS01V\Groups\IT\Development\PMC_Desktop\Application Files\";
            DirectoryInfo folder = new DirectoryInfo (path).GetDirectories ().OrderByDescending (d => d.LastWriteTimeUtc).First ();
            string[] items = folder.Name.Split ('_');
            label1.Text += $"{items[1]}.{items[2]}.{items[3]}.{items[4]}";
            itemFileCurrentUser.Text = $"Current User: {Environment.UserName}";
            Text = $"PMC - {Environment.UserName}";
            listUMUserHistory.DataSource = PMCUserAccessHistory ();
            listUMUserHistory.SelectedIndex = -1;
        }

        private void checkUMTerminatedUsers_CheckedChanged (object sender, EventArgs e) {
            comboUMUserSelect.DataSource = ADS.PopulateUserList (checkUMTerminatedUsers.Checked);
            comboUMUserSelect.SelectedIndex = -1;
        }

        private void comboUMUserSelect_SelectedIndexChanged (object sender, EventArgs e) {
            if (comboUMUserSelect.SelectedIndex > -1 && comboUMUserSelect.Text != "") {
                LoadUserProperties ();
            } else if (comboUMUserSelect.SelectedIndex == -1 || comboUMUserSelect.Text == "") {
                ClearUM ();
            }
        }

        /// <summary>
        /// Loads user properties for the currently selected user.  Sets User Management display values as appropriate.
        /// </summary>
        private void LoadUserProperties () {
            CurrentUser.SetUser (comboUMUserSelect.SelectedItem.ToString (), checkUMTerminatedUsers.Checked);
            textUMDisplayName.Text = CurrentUser.Name;
            textUMUsername.Text = CurrentUser.Username;
            textUMEmail.Text = CurrentUser.Email;
            textUMDepartment.Text = CurrentUser.Department;
            textUMTitle.Text = CurrentUser.Title;
            textUMManager.Text = CurrentUser.Manager;
            buttonUMEnableUser.Text = (textUMEnabled.Text = CurrentUser.Enabled) == "True" ? "Disable" : "Enable";
            textUMEnabled.BackColor = textUMEnabled.Text == "True" ? Color.PaleGreen : Color.LightCoral;
            textUMLastLogon.Text = CurrentUser.LastLogon;
            textUMEmployeeID.Text = CurrentUser.EmployeeID;
            EnableAdminButtons ((textUMEmployeeNumber.Text = CurrentUser.EmployeeNumber).Length == 6);
            textUMPassLastChanged.Text = CurrentUser.PassLastChanged;
            textUMPassExpiration.Text = CurrentUser.PassExpiration;
            textUMFailedLogonNum.Text = CurrentUser.FailedLogonNum;
            textUMFailedLogonNum.BackColor = CurrentUser.userTools.IsAccountLockedOut () ? Color.LightCoral : SystemColors.Window;
            textUMFailedLogonTime.Text = CurrentUser.FailedLogonTime;
            textUMDateOfHire.Text = CurrentUser.DateOfHire;
            textUMDateOfTermination.Text = CurrentUser.DateOfTermination;
            textUMLastModified.Text = CurrentUser.LastModified;
            listUMDirectReports.DataSource = CurrentUser.DirectReports.Count > 0 ? CurrentUser.DirectReports.Select (user => Regex.IsMatch (user.DistinguishedName, "Terminated") ? $"Term - {user.Name}" : user.Name).ToList () : new List<string> { "N/A" };
            listUMDirectReports.SelectedIndex = -1;
            listUMUserHistory.DataSource = PMCUserAccessHistory (CurrentUser.Username);
            listUMUserHistory.SelectedIndex = -1;
        }

        /// <summary>
        /// Enables or disables Admin-level button controls based on boolean input value.
        /// </summary>
        /// <param name="input">If true, Admin-level button controls will be enabled.  Defaults to false.</param>
        private void EnableAdminButtons (bool input = false) {
            buttonUMEnableUser.Enabled = input;
            buttonUMResetPassword.Enabled = input;
            buttonUMUnlockAccount.Enabled = input;
            buttonUMShowEmployeeNumber.Enabled = input;
            buttonUMEditUser.Enabled = input;
        }

        /// <summary>
        /// Clears listUMDirectReports and all TextBox controls.  Also makes a call to EnableAdminButtons ().
        /// </summary>
        private void ClearUM () {
            foreach (Control control in tabUserManagement.Controls.OfType<TextBox> ()) {
                control.Text = null;
            }
            listUMDirectReports.DataSource = new List<string> {
                "N/A"
            };
            listUMDirectReports.SelectedIndex = -1;
            textUMEnabled.BackColor = SystemColors.ControlLightLight;
            EnableAdminButtons ();
        }

        private void formPMC_Shown (object sender, EventArgs e) {
            Refresh ();
            Plexiglass cover = new Plexiglass (this);
            formProgress progress = new formProgress (this);
            cover.Show ();
            cover.Refresh ();
            progress.Show ();
            progress.Refresh ();
            ADS.UpdateUsernameLists (progress);
            listUMUserHistory.DataSource = PMCUserAccessHistory ();
            listUMUserHistory.SelectedIndex = -1;
            comboUMUserSelect.DataSource = ADS.PopulateUserList (checkUMTerminatedUsers.Checked);
            comboUMUserSelect.SelectedIndex = -1;
            progress.Close ();
            cover.Close ();
            Refresh ();
        }

        private void buttonUMShowEmployeeNumber_Click (object sender, EventArgs e) {
            if (buttonUMShowEmployeeNumber.Text == "Show") {
                textUMEmployeeNumber.UseSystemPasswordChar = false;
                buttonUMShowEmployeeNumber.Text = "Hide";
            } else {
                textUMEmployeeNumber.UseSystemPasswordChar = true;
                buttonUMShowEmployeeNumber.Text = "Show";
            }
        }

        private void buttonUMReloadUserList_Click (object sender, EventArgs e) {
            Plexiglass cover = new Plexiglass (this);
            formProgress progress = new formProgress (this);
            cover.Show ();
            cover.Refresh ();
            progress.Show ();
            progress.Refresh ();
            ADS.UpdateUsernameLists (progress);
            listUMUserHistory.DataSource = PMCUserAccessHistory ();
            comboUMUserSelect.DataSource = ADS.PopulateUserList (checkUMTerminatedUsers.Checked);
            comboUMUserSelect.SelectedIndex = -1;
            cover.Close ();
            progress.Close ();
        }

        private void buttonUMUnlockAccount_Click (object sender, EventArgs e) {
            if (CurrentUser != null) {
                if (CurrentUser.userTools.IsAccountLockedOut ()) {
                    try {
                        CurrentUser.userTools.UnlockAccount ();
                        MessageBox.Show ("User account unlocked.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadUserProperties ();
                    } catch {
                        MessageBox.Show ("Could not unlock user account.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                } else {
                    MessageBox.Show ("User account not locked.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void buttonUMResetPassword_Click (object sender, EventArgs e) {
            if (CurrentUser != null) {
                using (InputBox inputBox = new InputBox ("Please provide new password.", "Reset Password")) {
                    if (inputBox.ShowDialog () == DialogResult.OK) {
                        try {
                            CurrentUser.userTools.SetPassword (inputBox.Result);
                            MessageBox.Show ("User password set successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadUserProperties ();
                        } catch (Exception ex) when (ex.InnerException.Message.Contains ("password complexity")) {
                            MessageBox.Show ("Could not set user password.  Verify new password meets length, complexity, and history requirements.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        } catch (Exception ex) when (ex.InnerException.Message.Contains ("Access is denied")) {
                            MessageBox.Show ("Could not set user password.  Verify current logon has proper permissions to make this change.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        } catch (Exception ex) {
                            MessageBox.Show ($"Could not set user password.  Unknown error.\r\n\r\n{ex.InnerException.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void formPMC_KeyDown (object sender, System.Windows.Forms.KeyEventArgs e) {
            if (e.Control) {
                if (e.Shift) {
                    switch (e.KeyCode) {
                        case Keys.R:
                            itemFileReloadPMC.PerformClick ();
                            break;
                    }
                }
                switch (e.KeyCode) {
                    case Keys.Oemtilde:
                        itemFileChangeLoggedInUser.PerformClick ();
                        break;
                    case Keys.R:
                        buttonUMReloadUserList.PerformClick ();
                        break;
                    case Keys.Q:
                        itemFileClose.PerformClick ();
                        break;
                    case Keys.N:
                        itemFileOpenNewPMC.PerformClick ();
                        break;
                }
            } else if (e.Alt) {
                switch (e.KeyCode) {
                    case Keys.R:
                        buttonUMResetPassword.PerformClick ();
                        break;
                    case Keys.U:
                        buttonUMUnlockAccount.PerformClick ();
                        break;
                    case Keys.E:
                        buttonUMEnableUser.PerformClick ();
                        break;
                    case Keys.S:
                        buttonUMShowEmployeeNumber.PerformClick ();
                        break;
                }
            } else if (e.KeyCode == Keys.Escape) {
                if (FindFocusedControl (this) == comboUMUserSelect) {
                    comboUMUserSelect.DroppedDown = false;
                    comboUMUserSelect.Text = textUMUsername.Text;
                    //e.Handled = true;
                }
                ActiveControl = labelUMUserSelect;
            }
        }

        /// <summary>
        /// Performs a recursive search through the provided control and its child controls until the primary focused control is located and returned.
        /// </summary>
        /// <param name="control">The control from which to start the search.  FindFocusedControl will search through this control and its children.</param>
        /// <returns>Returns the primary focused control.</returns>
        public static Control FindFocusedControl (Control control) {
            return (control is ContainerControl container
                ? FindFocusedControl (container.ActiveControl)
                : control);
        }

        private void itemFileChangeLoggedInUser_Click (object sender, EventArgs e) {
            if (ADS.ChangeLogon ()) {
                itemFileCurrentUser.Text = $"Current User: {ADS.cred.UserName}";
                Text = $"PMC - {ADS.cred.UserName}";
                buttonUMReloadUserList.PerformClick ();
            }
        }

        private void resetUserPasswordToolStripMenuItem_Click (object sender, EventArgs e) {
            if (CurrentUser != null) {
                buttonUMResetPassword.PerformClick ();
            }
        }

        private void unlockUserAccountToolStripMenuItem_Click (object sender, EventArgs e) {
            if (CurrentUser != null) {
                buttonUMUnlockAccount.PerformClick ();
            }
        }

        private void buttonUMEnableUser_Click (object sender, EventArgs e) {
            if (CurrentUser.Enabled == "True") {
                CurrentUser.userTools.Enabled = false;
                CurrentUser.userTools.Save ();
                buttonUMEnableUser.Text = "Enable";
            } else {
                CurrentUser.userTools.Enabled = true;
                CurrentUser.userTools.Save ();
                buttonUMEnableUser.Text = "Disable";
            }
            LoadUserProperties ();
        }

        private void itemFileOpenNewPMC_Click (object sender, EventArgs e) {
            if (File.Exists (@"C:\Paschal\Scripts\Launch_PMC-Desktop.ps1")) {
                string cmd = @"C:\Paschal\Scripts\Launch_PMC-Desktop.ps1";

                try {
                    var process = System.Diagnostics.Process.Start (@"C:\Windows\System32\WindowsPowershell\v1.0\powershell.exe", cmd);
                    process.WaitForExit ();
                } catch (Exception ex) {
                    MessageBox.Show ($"Could not launch PMC.\r\n\r\n{ex.InnerException.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void itemFileClose_Click (object sender, EventArgs e) {
            Close ();
        }

        private void itemFileReloadPMC_Click (object sender, EventArgs e) {
            itemFileOpenNewPMC.PerformClick ();
            itemFileClose.PerformClick ();
        }

        private void itemChangelog_Click (object sender, EventArgs e) {
            using (Changelog change = new Changelog ()) {
                change.ShowDialog ();
            }
        }

        private void listUMDirectReports_MouseDoubleClick (object sender, System.Windows.Forms.MouseEventArgs e) {
            string name;
            if (listUMDirectReports.IndexFromPoint (e.Location) == listUMDirectReports.SelectedIndex && listUMDirectReports.SelectedItem.ToString () != "N/A" && listUMDirectReports.SelectedIndex.ToString () != "") {
                name = listUMDirectReports.SelectedItem.ToString ().Replace ("Not found - ", "").Replace ("Term - ", "");
                if (listUMDirectReports.SelectedItem.ToString ().Contains ("Not found")) {
                    MessageBox.Show ("User not found in Active or Terminated user lists.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                } else if (listUMDirectReports.SelectedItem.ToString ().Contains ("Term")) {
                    checkUMTerminatedUsers.Checked = true;
                }

                try {
                    SearchResult res = ADS.GetSingleUser (name);

                    if (res == null) {
                        res = ADS.GetTerminatedUser (name);
                    }
                    if (res == null) {
                        res = ADS.GetEXUser (name);
                    }
                    if (res != null) {
                        List<string> temp = ADS.PopulateUserList (checkUMTerminatedUsers.Checked);
                        temp.Add (res.Properties["samaccountname"][0].ToString ());
                        comboUMUserSelect.DataSource = temp;
                    }

                    comboUMUserSelect.Text = res.Properties["samaccountname"][0].ToString ();
                    ActiveControl = labelUMUserSelect;
                } catch (Exception ex) {
                    MessageBox.Show ($"Could not resolve user identity.  Please select through main user dropdown.\r\n\r\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void textUMManager_MouseDoubleClick (object sender, System.Windows.Forms.MouseEventArgs e) {
            if (textUMManager.Text != "N/A") {
                string name = textUMManager.Text.Replace ("Not found - ", "").Replace ("Term - ", "");
                if (textUMManager.Text != null && textUMManager.Text != "") {
                    if (textUMManager.Text.Contains ("Not found")) {
                        MessageBox.Show ("User not found in Active or Terminated user lists.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    } else if (textUMManager.Text.Contains ("Term")) {
                        checkUMTerminatedUsers.Checked = true;
                    }
                    Refresh ();

                    try {
                        SearchResult res = ADS.GetSingleUser (name);

                        if (res == null) {
                            res = ADS.GetTerminatedUser (name);
                        }
                        if (res == null) {
                            res = ADS.GetEXUser (name);
                        }
                        if (res != null) {
                            List<string> temp = ADS.PopulateUserList (checkUMTerminatedUsers.Checked);
                            temp.Add (res.Properties["samaccountname"][0].ToString ());
                            comboUMUserSelect.DataSource = temp;
                        }

                        comboUMUserSelect.Text = res.Properties["samaccountname"][0].ToString ();
                        ActiveControl = labelUMUserSelect;
                    } catch (Exception ex) {
                        MessageBox.Show ($"Could not resolve user identity.  Please select through main user dropdown.\r\n\r\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        /// <summary>
        /// Gets the contents of the current user's PMC History file and inserts the current username at the top.
        /// </summary>
        public List<string> PMCUserAccessHistory (string username) {
            string curruser;
            List<string> temp;
            try {
                curruser = ADS.cred.UserName;
            } catch {
                curruser = Environment.UserName;
            }
            temp = new List<string> (File.ReadAllLines ($@"C:\Users\{curruser.Replace ("-adm", "")}\AppData\Roaming\Paschal\RecentUserList.pmc"));
            temp.Remove (username);
            temp.Insert (0, username);
            if (!File.Exists ($@"C:\Users\{curruser.Replace ("-adm", "")}\AppData\Roaming\Paschal\RecentUserList.pmc")) {
                File.Create ($@"C:\Users\{curruser.Replace ("-adm", "")}\AppData\Roaming\Paschal\RecentUserList.pmc");
            }
            File.WriteAllLines ($@"C:\Users\{curruser.Replace ("-adm", "")}\AppData\Roaming\Paschal\RecentUserList.pmc", temp);

            return temp;
        }

        /// <summary>
        /// Accepts a List of string values and writes it to the current user's PMC History file.
        /// </summary>
        /// <param name="list"></param>
        public void PMCUserAccessHistory (List<string> list) {
            string curruser;
            try {
                curruser = ADS.cred.UserName;
            } catch {
                curruser = Environment.UserName;
            }
            if (!File.Exists ($@"C:\Users\{curruser.Replace ("-adm", "")}\AppData\Roaming\Paschal\RecentUserList.pmc")) {
                File.Create ($@"C:\Users\{curruser.Replace ("-adm", "")}\AppData\Roaming\Paschal\RecentUserList.pmc");
            }
            File.WriteAllLines ($@"C:\Users\{curruser.Replace ("-adm", "")}\AppData\Roaming\Paschal\RecentUserList.pmc", list);
        }

        /// <summary>
        /// Retrieves the current user's PMC History file.
        /// </summary>
        /// <returns></returns>
        public List<string> PMCUserAccessHistory () {
            string curruser;
            try {
                curruser = ADS.cred.UserName;
            } catch {
                curruser = Environment.UserName;
            }
            if (!File.Exists ($@"C:\Users\{curruser.Replace ("-adm", "")}\AppData\Roaming\Paschal\RecentUserList.pmc")) {
                File.Create ($@"C:\Users\{curruser.Replace ("-adm", "")}\AppData\Roaming\Paschal\RecentUserList.pmc");
            }

            return new List<string> (File.ReadAllLines ($@"C:\Users\{curruser.Replace ("-adm", "")}\AppData\Roaming\Paschal\RecentUserList.pmc"));
        }

        private void listUMUserHistory_MouseDoubleClick (object sender, System.Windows.Forms.MouseEventArgs e) {
            if (listUMUserHistory.IndexFromPoint (e.Location) == listUMUserHistory.SelectedIndex) {
                if (!comboUMUserSelect.Items.Contains (listUMUserHistory.SelectedItem.ToString ())) {
                    if (checkUMTerminatedUsers.Checked) {
                        MessageBox.Show ("Could not find user in currently loaded lists of Active or Terminated users.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    } else {
                        checkUMTerminatedUsers.Checked = true;
                        if (!comboUMUserSelect.Items.Contains (listUMUserHistory.SelectedItem.ToString ())) {
                            SearchResult test = ADS.GetEXUser (listUMUserHistory.SelectedItem.ToString ());
                            if (test != null) {
                                List<string> temp = ADS.PopulateUserList (checkUMTerminatedUsers.Checked);
                                temp.Add (test.Properties["samaccountname"][0].ToString ());
                                comboUMUserSelect.DataSource = temp;
                            } else {
                                MessageBox.Show ("Could not find user in currently loaded lists of Active or Terminated users.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                checkUMTerminatedUsers.Checked = false;
                                return;
                            }
                        }
                    }
                }
                comboUMUserSelect.Text = listUMUserHistory.SelectedItem.ToString ();
                listUMUserHistory.SelectedIndex = -1;
                ActiveControl = labelUMUserSelect;
            }
        }

        private void listUMUserHistory_DataSourceChanged (object sender, EventArgs e) {
            listUMUserHistory.SelectedIndex = -1;
        }

        private void listUMDirectReports_DataSourceChanged (object sender, EventArgs e) {
            listUMDirectReports.SelectedIndex = -1;
        }

        private void buttonUMClearUserHistory_Click (object sender, EventArgs e) {
            PMCUserAccessHistory (new List<string> ());
            listUMUserHistory.DataSource = PMCUserAccessHistory ();
        }

        private void buttonUMEditUser_Click (object sender, EventArgs e) {
            Plexiglass cover = new Plexiglass (this);
            formEditUser edit = new formEditUser (CurrentUser);
            cover.Show ();
            edit.ShowDialog ();

            cover.Close ();
        }
    }
}
