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
    public partial class InputBox : Form {
        public InputBox () {
            InitializeComponent ();
        }

        public InputBox (string Prompt, string Caption) {
            InitializeComponent ();
            labelPrompt.Text = Prompt;
            Text = Caption;
        }

        public string newPass {
            get {
                return textInput.Text;
            }
        }
    }
}
