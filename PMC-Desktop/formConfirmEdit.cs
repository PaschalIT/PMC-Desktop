using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PMC_Desktop {
    public partial class formConfirmEdit : Form {
        public formConfirmEdit (User newUser, User prevUser) {
            InitializeComponent ();

            dataCETable.Rows.Add ("First Name", newUser.userTools.GivenName, prevUser.userTools.GivenName);
            dataCETable.Rows.Add ("Middle Name", newUser.userTools.MiddleName, prevUser.userTools.MiddleName);
            dataCETable.Rows.Add ("Last Name", newUser.userTools.Surname, prevUser.userTools.Surname);
            dataCETable.Rows.Add ("Display Name", newUser.userTools.DisplayName, prevUser.userTools.DisplayName);

            foreach (DataGridViewRow row in dataCETable.Rows) {
                if (row.Cells[1].Value.ToString () != row.Cells[2].Value.ToString ()) {
                    row.Cells[1].Style.BackColor = Color.PaleGreen;
                    row.Cells[2].Style.BackColor = Color.LightCoral;
                } else {
                    row.Cells[1].Style.BackColor = SystemColors.Window;
                    row.Cells[2].Style.BackColor = SystemColors.Window;
                }
            }
        }
    }
}
