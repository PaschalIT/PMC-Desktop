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

namespace PMC_Desktop {
    public partial class formPMC : Form {
        public static User CurrentUser = new User ();

        public formPMC () {
            InitializeComponent ();
        }

        private void formPMC_Load (object sender, EventArgs e) {
            ADS.UpdateUsernameLists ();
            comboUMUserSelect.DataSource = ADS.PopulateUserList (checkUMTerminatedUsers.Checked);
            comboUMUserSelect.SelectedIndex = -1;
            foreach (TextBox control in tabUserManagement.Controls.OfType<TextBox> ()) {
                control.ReadOnly = true;
                control.BackColor = SystemColors.ControlLightLight;
                control.ForeColor = Color.Black;
            }
        }

        private void checkUMTerminatedUsers_CheckedChanged (object sender, EventArgs e) {
            comboUMUserSelect.DataSource = ADS.PopulateUserList (checkUMTerminatedUsers.Checked);
            comboUMUserSelect.SelectedIndex = -1;
        }

        private void comboUMUserSelect_SelectedIndexChanged (object sender, EventArgs e) {
            if (comboUMUserSelect.SelectedIndex > -1) {
                CurrentUser.SetUser (comboUMUserSelect.SelectedItem.ToString (), checkUMTerminatedUsers.Checked);
                textUMDisplayName.Text = CurrentUser.Name;
                textUMUsername.Text = CurrentUser.Username;
                textUMEmail.Text = CurrentUser.Email;
                textUMDepartment.Text = CurrentUser.Department;
                textUMTitle.Text = CurrentUser.Title;
                textUMManager.Text = CurrentUser.Manager;
                textUMEnabled.Text = CurrentUser.Enabled;
                textUMLastLogon.Text = CurrentUser.LastLogon;
                textUMEmployeeID.Text = CurrentUser.EmployeeID;
                textUMEmployeeNumber.Text = CurrentUser.EmployeeNumber;
                textUMPassLastChanged.Text = CurrentUser.PassLastChanged;
                textUMPassExpiration.Text = CurrentUser.PassExpiration;
                textUMFailedLogonNum.Text = CurrentUser.FailedLogonNum;
                textUMFailedLogonTime.Text = CurrentUser.FailedLogonTime;
                textUMDateOfHire.Text = CurrentUser.DateOfHire;
                textUMDateOfTermination.Text = CurrentUser.DateOfTermination;
                textUMLastModified.Text = CurrentUser.LastModified;
                listUMDirectReports.DataSource = CurrentUser.DirectReports;
            } else if (comboUMUserSelect.SelectedIndex == -1) {
                ClearUM ();
            }
        }

        private void ClearUM () {
            foreach (Control control in tabUserManagement.Controls.OfType<TextBox> ()) {
                control.Text = null;
            }
        }
    }
}
