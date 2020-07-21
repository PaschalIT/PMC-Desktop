namespace PMC_Desktop {
    partial class formProgress {
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
            this.circProgressLoading.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.circProgressLoading.ForeColor = System.Drawing.Color.Black;
            this.circProgressLoading.InnerColor = System.Drawing.Color.Transparent;
            this.circProgressLoading.InnerMargin = 0;
            this.circProgressLoading.InnerWidth = -1;
            this.circProgressLoading.Location = new System.Drawing.Point(282, 133);
            this.circProgressLoading.MarqueeAnimationSpeed = 2000;
            this.circProgressLoading.Name = "circProgressLoading";
            this.circProgressLoading.OuterColor = System.Drawing.Color.LightGray;
            this.circProgressLoading.OuterMargin = -26;
            this.circProgressLoading.OuterWidth = 30;
            this.circProgressLoading.ProgressColor = System.Drawing.Color.Cyan;
            this.circProgressLoading.ProgressWidth = 26;
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
            this.circProgressLoading.TabIndex = 1;
            this.circProgressLoading.TextMargin = new System.Windows.Forms.Padding(8, -15, 0, 0);
            // 
            // formProgress
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(884, 586);
            this.Controls.Add(this.circProgressLoading);
            this.Name = "formProgress";
            this.Text = "formProgress";
            this.TransparencyKey = System.Drawing.Color.Silver;
            this.ResumeLayout(false);

        }

        #endregion

        private CircularProgressBar.CircularProgressBar circProgressLoading;
    }
}