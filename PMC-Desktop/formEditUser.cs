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
        public formEditUser (User user) {
            InitializeComponent ();

            LoadUserInfo (user);
        }

        public void LoadUserInfo (User user) {
            Text = $"Editing: {user.userTools.DisplayName}";
            textEUName.Text = user.userTools.DisplayName;
            ResultPropertyValueCollection temp = user.UserObject.Properties["proxyaddresses"];
            List<string> proxyAddresses = new List<string> ();
            foreach (var item in temp) {
                proxyAddresses.Add (item.ToString ());
            }
            //string primary = proxyAddresses.FirstOrDefault (item => {
            //    if (item.Contains ("SMTP:")) {
            //        proxyAddresses.Remove (item);
            //        proxyAddresses.
            //        return true;
            //    } else {
            //        return false;
            //    }
            //});
            //primary = primary.Substring (5);

            string primary = proxyAddresses.FirstOrDefault (item => item.Contains ("SMTP:"));
            proxyAddresses.Remove (primary);
            proxyAddresses.Insert (0, primary);

            proxyAddresses.ForEach (item => comboEUPrimaryEmailAddress.Items.Add (item.Substring (5)));
            comboEUPrimaryEmailAddress.SelectedIndex = 0;
        }
    }
}
