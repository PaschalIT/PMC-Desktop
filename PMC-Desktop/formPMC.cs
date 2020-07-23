using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.DirectoryServices;
using System.Runtime.InteropServices;
using System.Deployment.Application;
using System.IO;
using System.DirectoryServices.AccountManagement;
using IPrompt;

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
        }

        private void checkUMTerminatedUsers_CheckedChanged (object sender, EventArgs e) {
            comboUMUserSelect.DataSource = ADS.PopulateUserList (checkUMTerminatedUsers.Checked);
            comboUMUserSelect.SelectedIndex = -1;
        }

        private void comboUMUserSelect_SelectedIndexChanged (object sender, EventArgs e) {
            if (comboUMUserSelect.SelectedIndex > -1) {
                LoadUserProperties ();
            } else if (comboUMUserSelect.SelectedIndex == -1) {
                ClearUM ();
            }
        }

        private void LoadUserProperties () {
            CurrentUser.SetUser (comboUMUserSelect.SelectedItem.ToString (), checkUMTerminatedUsers.Checked);
            textUMDisplayName.Text = CurrentUser.Name;
            textUMUsername.Text = CurrentUser.Username;
            textUMEmail.Text = CurrentUser.Email;
            textUMDepartment.Text = CurrentUser.Department;
            textUMTitle.Text = CurrentUser.Title;
            textUMManager.Text = CurrentUser.Manager;
            buttonUMEnableUser.Text = (textUMEnabled.Text = CurrentUser.Enabled) == "True" ? "Disable" : "Enable";
            textUMLastLogon.Text = CurrentUser.LastLogon;
            textUMEmployeeID.Text = CurrentUser.EmployeeID;
            EnableAdminButtons ((textUMEmployeeNumber.Text = CurrentUser.EmployeeNumber).Length == 6);
            textUMPassLastChanged.Text = CurrentUser.PassLastChanged;
            textUMPassExpiration.Text = CurrentUser.PassExpiration;
            textUMFailedLogonNum.Text = CurrentUser.FailedLogonNum;
            textUMFailedLogonTime.Text = CurrentUser.FailedLogonTime;
            textUMDateOfHire.Text = CurrentUser.DateOfHire;
            textUMDateOfTermination.Text = CurrentUser.DateOfTermination;
            textUMLastModified.Text = CurrentUser.LastModified;
            listUMDirectReports.DataSource = CurrentUser.DirectReports;
        }

        private void EnableAdminButtons (bool input = false) {
            buttonUMEnableUser.Enabled = input;
            buttonUMResetPassword.Enabled = input;
            buttonUMUnlockAccount.Enabled = input;
            buttonUMShowEmployeeNumber.Enabled = input;
        }

        private void ClearUM () {
            foreach (Control control in tabUserManagement.Controls.OfType<TextBox> ()) {
                control.Text = null;
            }
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
            comboUMUserSelect.DataSource = ADS.PopulateUserList (checkUMTerminatedUsers.Checked);
            comboUMUserSelect.SelectedIndex = -1;
            cover.Close ();
            progress.Close ();
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
                using (InputBox inputBox = new InputBox ()) {
                    if (inputBox.ShowDialog () == DialogResult.OK) {
                        try {
                            CurrentUser.userTools.SetPassword (inputBox.newPass);
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

        private void formPMC_KeyDown (object sender, KeyEventArgs e) {
            if (e.Control) {
                switch (e.KeyCode) {
                    case Keys.Oemtilde:
                        if (ADS.ChangeLogon ()) {
                            buttonUMReloadUserList.PerformClick ();
                        }
                        break;
                    case Keys.R:
                        buttonUMReloadUserList.PerformClick ();
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
                }
            }
        }

        private void itemComChangeLoggedInUser_Click (object sender, EventArgs e) {
            if (ADS.ChangeLogon ()) {
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

        private void openNewPMCToolStripMenuItem_Click (object sender, EventArgs e) {

        }
    }
}
