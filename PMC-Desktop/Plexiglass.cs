﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PMC_Desktop {
    public partial class Plexiglass : Form {
        public Plexiglass (Form tocover) {
            InitializeComponent ();
            BackColor = Color.DarkGray;
            Opacity = 0.60;
            FormBorderStyle = FormBorderStyle.None;
            ControlBox = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.Manual;
            AutoScaleMode = AutoScaleMode.None;
            Location = tocover.PointToScreen (Point.Empty);
            ClientSize = tocover.ClientSize;
            tocover.LocationChanged += Cover_LocationChanged;
            tocover.ClientSizeChanged += Cover_ClientSizeChanged;
            Show (tocover);
            tocover.Focus ();

            if (Environment.OSVersion.Version.Major >= 6) {
                int value = 1;
                DwmSetWindowAttribute (tocover.Handle, DWMWA_TRANSITIONS_FORCEDISABLED, ref value, 4);
            }
        }

        private void Cover_LocationChanged (object sender, EventArgs e) {
            Location = Owner.PointToScreen (Point.Empty);
        }

        private void Cover_ClientSizeChanged (object sender, EventArgs e) {
            ClientSize = Owner.ClientSize;
        }

        protected override void OnFormClosing (FormClosingEventArgs e) {
            Owner.LocationChanged -= Cover_LocationChanged;
            Owner.ClientSizeChanged -= Cover_ClientSizeChanged;
            if (!Owner.IsDisposed && Environment.OSVersion.Version.Major >= 6) {
                int value = 1;
                DwmSetWindowAttribute (Owner.Handle, DWMWA_TRANSITIONS_FORCEDISABLED, ref value, 4);
            }
            base.OnFormClosing (e);
        }

        protected override void OnActivated (EventArgs e) {
            BeginInvoke (new Action (() => Owner.Activate ()));
        }

        private const int DWMWA_TRANSITIONS_FORCEDISABLED = 3;
        [DllImport ("dwmapi.dll")]
        private static extern int DwmSetWindowAttribute (IntPtr hWnd, int attr, ref int value, int attrLen);
    }
}
