namespace PMC_Desktop {
    partial class EmailBox {
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
            this.textEBEmailAlias = new System.Windows.Forms.TextBox();
            this.comboEBEmailDomain = new System.Windows.Forms.ComboBox();
            this.labelEBPrompt = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textEBEmailAlias
            // 
            this.textEBEmailAlias.Location = new System.Drawing.Point(12, 58);
            this.textEBEmailAlias.Name = "textEBEmailAlias";
            this.textEBEmailAlias.Size = new System.Drawing.Size(194, 20);
            this.textEBEmailAlias.TabIndex = 0;
            // 
            // comboEBEmailDomain
            // 
            this.comboEBEmailDomain.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboEBEmailDomain.FormattingEnabled = true;
            this.comboEBEmailDomain.Items.AddRange(new object[] {
            "@gopaschal.com",
            "@paschalcorp.com"});
            this.comboEBEmailDomain.Location = new System.Drawing.Point(212, 58);
            this.comboEBEmailDomain.Name = "comboEBEmailDomain";
            this.comboEBEmailDomain.Size = new System.Drawing.Size(160, 21);
            this.comboEBEmailDomain.TabIndex = 1;
            // 
            // labelEBPrompt
            // 
            this.labelEBPrompt.AutoSize = true;
            this.labelEBPrompt.Location = new System.Drawing.Point(12, 39);
            this.labelEBPrompt.Name = "labelEBPrompt";
            this.labelEBPrompt.Size = new System.Drawing.Size(160, 13);
            this.labelEBPrompt.TabIndex = 2;
            this.labelEBPrompt.Text = "Provide new email address alias:";
            // 
            // EmailBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 136);
            this.Controls.Add(this.labelEBPrompt);
            this.Controls.Add(this.comboEBEmailDomain);
            this.Controls.Add(this.textEBEmailAlias);
            this.Name = "EmailBox";
            this.Text = "Input Email Address";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textEBEmailAlias;
        private System.Windows.Forms.ComboBox comboEBEmailDomain;
        private System.Windows.Forms.Label labelEBPrompt;
    }
}