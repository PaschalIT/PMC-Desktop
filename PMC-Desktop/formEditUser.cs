using System;
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
        private static User ManagerObj = new User ();
        private static bool isFirstLoad = true;

        public formEditUser (User user) {
            InitializeComponent ();

            LoadUserInfo (user);
        }

        public void LoadUserInfo (User user) {
            isFirstLoad = true;
            UserObj = user;
            Text = $"Editing: {user.userTools.DisplayName}";
            textEUFirstName.Text = user.userTools.GivenName;
            textEUMiddleName.Text = user.userTools.MiddleName ?? "";
            textEULastName.Text = user.userTools.Surname;

            comboEUDepartment.SelectedIndex = comboEUDepartment.Items.IndexOf (user.Department);

            textEUTitle.Text = UserObj.Title;

            ManagerObj.SetUser (UserObj.Manager, true);
            textEUManager.Text = ManagerObj.Username;
            labelEUManagerName.Text = ManagerObj.Name;

            PropertyValueCollection temp = user.UserObject.Properties["proxyaddresses"];
            List<string> proxyAddresses = new List<string> ();
            foreach (var item in temp) {
                proxyAddresses.Add (item.ToString ());
            }
            string primary = proxyAddresses.FirstOrDefault (item => item.Contains ("SMTP:"));
            proxyAddresses.Remove (primary);
            proxyAddresses.Insert (0, primary);

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
                UserObj.userTools.EmailAddress = comboEUPrimaryEmailAddress.Text;
                List<string> list = new List<string> ();
                foreach (object item in UserObj.UserObject.Properties["proxyaddresses"]) {
                    list.Add (item.ToString ());
                }
                string changeToSecondary = list.First (i => Regex.IsMatch (i, "SMTP"));
                list.Remove (changeToSecondary);
                string changeToPrimary = list.First (i => Regex.IsMatch (i, comboEUPrimaryEmailAddress.Text));
                list.Remove (changeToPrimary);
                changeToSecondary = changeToSecondary.Replace ("SMTP", "smtp");
                changeToPrimary = changeToPrimary.Replace ("smtp", "SMTP");
                list.Insert (0, changeToSecondary);
                list.Insert (0, changeToPrimary);
                UserObj.UserObject.Properties["proxyaddresses"].Clear ();
                UserObj.UserObject.Properties["proxyaddresses"].AddRange (list.ToArray ());
                LoadUserInfo (UserObj);
            }
        }

        private void buttonEUApplyChanges_Click (object sender, EventArgs e) {

        }
    }
}
