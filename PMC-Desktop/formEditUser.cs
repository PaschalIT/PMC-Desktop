using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.DirectoryServices;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PMC_Desktop {
    public partial class formEditUser : Form {
        private static User UserObj = new User ();
        private static User UserPrev = new User ();
        private static User ManagerObj = new User ();
        private List<string> EmailList = new List<string> ();
        private static bool isFirstLoad = true;

        public formEditUser (User user) {
            InitializeComponent ();

            LoadUserInfo (user);
            UserPrev.SetUser (user.Username, true);
        }

        public void LoadUserInfo (User user) {
            isFirstLoad = true;
            UserObj = user;
            Text = $"Editing: {user.userTools.DisplayName}";

            textEUFirstName.Text = user.userTools.GivenName;
            textEUMiddleName.Text = user.userTools.MiddleName ?? "";
            textEULastName.Text = user.userTools.Surname;
            textEUDisplayName.Text = user.userTools.DisplayName;

            comboEUDepartment.SelectedIndex = comboEUDepartment.Items.IndexOf (user.Department);

            textEUTitle.Text = UserObj.Title;

            ManagerObj.SetUser (UserObj.Manager, true);
            textEUManager.Text = ManagerObj.Username;
            labelEUManagerName.Text = ManagerObj.Name;

            PropertyValueCollection temp = user.UserObject.Properties["proxyaddresses"];
            List<string> proxyAddresses = new List<string> ();
            if (EmailList.Count > 0) {
                proxyAddresses = EmailList;
            } else {
                foreach (var item in temp) {
                    proxyAddresses.Add (item.ToString ());
                }
                string primary = proxyAddresses.FirstOrDefault (item => item.Contains ("SMTP:"));
                proxyAddresses.Remove (primary);
                proxyAddresses.Insert (0, primary);
            }

            comboEUPrimaryEmailAddress.Items.Clear ();
            listEUProxyAddresses.Items.Clear ();

            try {
                if (proxyAddresses.Count > 0) {
                    proxyAddresses.ForEach (item => {
                        comboEUPrimaryEmailAddress.Items.Add (item.Substring (5));
                        listEUProxyAddresses.Items.Add (item);
                    });
                    comboEUPrimaryEmailAddress.SelectedIndex = 0;

                    comboEUPrimaryEmailAddress.Enabled = true;
                    listEUProxyAddresses.Enabled = true;
                    buttonEUAddNewEmail.Enabled = true;
                    labelEUUserEmailNotEnabled.Visible = false;
                }
            } catch {
                comboEUPrimaryEmailAddress.Enabled = false;
                listEUProxyAddresses.Enabled = false;
                buttonEUAddNewEmail.Enabled = false;
                labelEUUserEmailNotEnabled.Visible = true;
                labelEUUserEmailNotEnabled.BringToFront ();
            }

            isFirstLoad = false;
        }

        private void buttonEUAddNewEmail_Click (object sender, EventArgs e) {
            EmailBox input = new EmailBox ();
            if (input.ShowDialog () == DialogResult.OK) {
                string newemail = input.Result;
                if (CheckNewEmail (listEUProxyAddresses.Items, newemail)) {
                    UserObj.UserObject.Properties["proxyaddresses"].Add ($"smtp:{newemail}");
                    LoadUserInfo (UserObj);
                }
            }
        }

        private bool CheckNewEmail (ListBox.ObjectCollection curr, string add) {
            foreach (object item in curr) {
                if (item.ToString ().Contains (add)) {
                    return false;
                }
            }
            return true;
        }

        private void comboEUPrimaryEmailAddress_SelectedIndexChanged (object sender, EventArgs e) {
            if (!Regex.IsMatch (UserObj.Email, comboEUPrimaryEmailAddress.Text) && !isFirstLoad) {
                foreach (object item in UserObj.UserObject.Properties["proxyaddresses"]) {
                    EmailList.Add (item.ToString ());
                }
                string changeToSecondary = EmailList.First (i => Regex.IsMatch (i, "SMTP"));
                EmailList.Remove (changeToSecondary);
                string changeToPrimary = EmailList.First (i => Regex.IsMatch (i, comboEUPrimaryEmailAddress.Text));
                EmailList.Remove (changeToPrimary);
                changeToSecondary = changeToSecondary.Replace ("SMTP", "smtp");
                changeToPrimary = changeToPrimary.Replace ("smtp", "SMTP");
                EmailList.Insert (0, changeToSecondary);
                EmailList.Insert (0, changeToPrimary);
                LoadUserInfo (UserObj);
            }
        }

        private void buttonEUApplyChanges_Click (object sender, EventArgs e) {
            UserObj.userTools.GivenName = textEUFirstName.Text;
            UserObj.userTools.MiddleName = textEUMiddleName.Text;
            UserObj.userTools.Surname = textEULastName.Text;
            UserObj.userTools.DisplayName = textEUDisplayName.Text;

            formConfirmEdit confirm = new formConfirmEdit (UserObj, UserPrev);

            Visible = false;
            confirm.ShowDialog ();
            Visible = true;
        }

        private void textEUFirstName_TextChanged (object sender, EventArgs e) {
            if (textEUFirstName.Text != UserObj.userTools.GivenName) {
                EnableNotify (labelEUFirstName);
            } else {
                DisableNotify (labelEUFirstName);
            }
        }

        private void EnableNotify (Control control, string text = "Edited") {
            errorEUNotify.SetIconAlignment (control, ErrorIconAlignment.MiddleRight);
            errorEUNotify.SetError (control, text);
        }

        private void DisableNotify (Control control) {
            errorEUNotify.SetError (control, "");
        }

        private void textEUMiddleName_TextChanged (object sender, EventArgs e) {
            if (textEUMiddleName.Text != UserObj.userTools.MiddleName) {
                EnableNotify (labelEUMiddleName);
            } else {
                DisableNotify (labelEUMiddleName);
            }
        }

        private void textEULastName_TextChanged (object sender, EventArgs e) {
            if (textEULastName.Text != UserObj.userTools.Surname) {
                EnableNotify (labelEULastName);
            } else {
                DisableNotify (labelEULastName);
            }
        }

        private void textEUDisplayName_TextChanged (object sender, EventArgs e) {
            if (textEUDisplayName.Text != UserObj.userTools.DisplayName) {
                EnableNotify (labelEUDisplayName);
            } else {
                DisableNotify (labelEUDisplayName);
            }
        }

        private void comboEUDepartment_SelectedIndexChanged (object sender, EventArgs e) {
            if (comboEUDepartment.SelectedItem.ToString () != UserObj.Department) {
                EnableNotify (labelEUDepartment);
            } else {
                DisableNotify (labelEUDepartment);
            }
        }

        private void textEUTitle_TextChanged (object sender, EventArgs e) {
            if (textEUTitle.Text != UserObj.Title) {
                EnableNotify (labelEUTitle);
            } else {
                DisableNotify (labelEUTitle);
            }
        }

        private void textEUManager_TextChanged (object sender, EventArgs e) {
            var temp = ADS.GetSingleUser (textEUManager.Text);
            if (temp != null) {
                labelEUManagerName.Text = temp.Properties["displayname"][0].ToString ();
                if (temp.Properties["distinguishedname"][0].ToString () != UserObj.UserObject.Properties["manager"][0].ToString ()) {
                    EnableNotify (labelEUManager);
                } else {
                    DisableNotify (labelEUManager);
                }
            } else {
                labelEUManagerName.Text = "User not found!";
                EnableNotify (labelEUManager, "User not found!");
            }
        }
    }
}
