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

            string path = @"\\WFS01V\Groups\IT\Development\PMC_Desktop\Application Files\";
            DirectoryInfo folder = new DirectoryInfo (path).GetDirectories ().OrderByDescending (d => d.LastWriteTimeUtc).First ();

            webBrowser1.DocumentText = Markdown.ToHtml (File.ReadAllText ($"{folder.FullName}\\Resources\\CHANGELOG.md"));
        }
    }
}
