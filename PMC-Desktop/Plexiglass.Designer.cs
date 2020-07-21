namespace PMC_Desktop {
    partial class Plexiglass {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose (bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose ();
            }
            base.Dispose (disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent () {
            this.circProgressLoading = new CircularProgressBar.CircularProgressBar();
            this.SuspendLayout();
            // 
            // circProgressLoading
            // 
            this.circProgressLoading.AnimationFunction = WinFormAnimation.KnownAnimationFunctions.Liner;
            this.circProgressLoading.AnimationSpeed = 500;
            this.circProgressLoading.BackColor = System.Drawing.Color.Transparent;
            this.circProgressLoading.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.circProgressLoading.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.circProgressLoading.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.circProgressLoading.InnerMargin = 2;
            this.circProgressLoading.InnerWidth = -1;
            this.circProgressLoading.Location = new System.Drawing.Point(282, 133);
            this.circProgressLoading.MarqueeAnimationSpeed = 2000;
            this.circProgressLoading.Name = "circProgressLoading";
            this.circProgressLoading.OuterColor = System.Drawing.Color.Gray;
            this.circProgressLoading.OuterMargin = -25;
            this.circProgressLoading.OuterWidth = 26;
            this.circProgressLoading.ProgressColor = System.Drawing.Color.Cyan;
            this.circProgressLoading.ProgressWidth = 25;
            this.circProgressLoading.SecondaryFont = new System.Drawing.Font("Microsoft Sans Serif", 36F);
            this.circProgressLoading.Size = new System.Drawing.Size(320, 320);
            this.circProgressLoading.StartAngle = 270;
            this.circProgressLoading.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.circProgressLoading.SubscriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.circProgressLoading.SubscriptMargin = new System.Windows.Forms.Padding(10, -35, 0, 0);
            this.circProgressLoading.SubscriptText = "";
            this.circProgressLoading.SuperscriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.circProgressLoading.SuperscriptMargin = new System.Windows.Forms.Padding(10, 35, 0, 0);
            this.circProgressLoading.SuperscriptText = "";
            this.circProgressLoading.TabIndex = 0;
            this.circProgressLoading.TextMargin = new System.Windows.Forms.Padding(8, 8, 0, 0);
            // 
            // Plexiglass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 586);
            this.Controls.Add(this.circProgressLoading);
            this.Name = "Plexiglass";
            this.Text = "Plexiglass";
            this.ResumeLayout(false);

        }

        #endregion

        private CircularProgressBar.CircularProgressBar circProgressLoading;
    }
}