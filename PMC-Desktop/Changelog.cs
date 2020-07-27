using Markdig;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PMC_Desktop {
    public partial class Changelog : Form {
        public Changelog () {
            InitializeComponent ();

            webBrowser1.DocumentText = Markdown.ToHtml (File.ReadAllText (@"..\..\CHANGELOG.md"));
        }
    }
}
