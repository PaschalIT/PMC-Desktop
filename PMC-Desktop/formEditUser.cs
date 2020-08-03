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
        private static User UserObj;
        private static bool isFirstLoad = true;

        public formEditUser (User user) {
            InitializeComponent ();

            LoadUserInfo (user);
        }

        public void LoadUserInfo (User user) {
            isFirstLoad = true;
            UserObj = user;
            Text = $"Editing: {user.userTools.DisplayName}";
            textEUName.Text = user.userTools.DisplayName;
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
            proxyAddresses.ForEach (item => {
                comboEUPrimaryEmailAddress.Items.Add (item.Substring (5));
                listEUProxyAddresses.Items.Add (item);
                });
            comboEUPrimaryEmailAddress.SelectedIndex = 0;

            isFirstLoad = false;
        }

        private void buttonEUAddNewEmail_Click (object sender, EventArgs e) {
            InputBox input = new InputBox ("Please input new email address.", "New Email Address");
            if (input.ShowDialog () == DialogResult.OK) {
                if (CheckNewEmail (listEUProxyAddresses.Items, input.Result)) {
                    UserObj.UserObject.Properties["proxyaddresses"].Add ($"smtp:{input.Result}");
                    UserObj.UserObject.CommitChanges ();
                    UserObj.UserObject.RefreshCache ();
                    LoadUserInfo (UserObj);
                }
            }
        }

        private bool CheckNewEmail (ListBox.ObjectCollection curr, string add) {
            foreach (string item in curr) {
                if (item.ToString ().Contains (add)) {
                    MessageBox.Show ("Email address already exists in user properties.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                } else if (!Regex.IsMatch (add, @"^[A-Za-z0-9._%+-]+@(gopaschal|paschalcorp)\.com")) {
                    MessageBox.Show ("Email address must be a properly formatted valid email address with the domain '@gopaschal.com' or '@paschalcorp.com'.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                UserObj.UserObject.CommitChanges ();
                UserObj.userTools.Save ();
                UserObj.SetUser (UserObj.Username, true);
                UserObj.UserObject.RefreshCache ();
                LoadUserInfo (UserObj);
            }
        }
    }
}
