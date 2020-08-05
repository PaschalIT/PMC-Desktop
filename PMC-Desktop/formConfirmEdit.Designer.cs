namespace PMC_Desktop {
    partial class formConfirmEdit {
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
            this.dataCETable = new System.Windows.Forms.DataGridView();
            this.Property = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.New = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Previous = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonCEConfirm = new System.Windows.Forms.Button();
            this.buttonCEBack = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataCETable)).BeginInit();
            this.SuspendLayout();
            // 
            // dataCETable
            // 
            this.dataCETable.AllowUserToAddRows = false;
            this.dataCETable.AllowUserToDeleteRows = false;
            this.dataCETable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataCETable.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataCETable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataCETable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Property,
            this.New,
            this.Previous});
            this.dataCETable.Location = new System.Drawing.Point(12, 12);
            this.dataCETable.Name = "dataCETable";
            this.dataCETable.RowHeadersVisible = false;
            this.dataCETable.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dataCETable.RowTemplate.ReadOnly = true;
            this.dataCETable.Size = new System.Drawing.Size(360, 353);
            this.dataCETable.TabIndex = 0;
            // 
            // Property
            // 
            this.Property.HeaderText = "Property";
            this.Property.Name = "Property";
            this.Property.ReadOnly = true;
            // 
            // New
            // 
            this.New.HeaderText = "New";
            this.New.Name = "New";
            this.New.ReadOnly = true;
            // 
            // Previous
            // 
            this.Previous.HeaderText = "Previous";
            this.Previous.Name = "Previous";
            this.Previous.ReadOnly = true;
            // 
            // buttonCEConfirm
            // 
            this.buttonCEConfirm.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonCEConfirm.Location = new System.Drawing.Point(282, 368);
            this.buttonCEConfirm.Margin = new System.Windows.Forms.Padding(0);
            this.buttonCEConfirm.Name = "buttonCEConfirm";
            this.buttonCEConfirm.Size = new System.Drawing.Size(90, 34);
            this.buttonCEConfirm.TabIndex = 1;
            this.buttonCEConfirm.Text = "Confirm";
            this.buttonCEConfirm.UseVisualStyleBackColor = true;
            // 
            // buttonCEBack
            // 
            this.buttonCEBack.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCEBack.Location = new System.Drawing.Point(12, 368);
            this.buttonCEBack.Margin = new System.Windows.Forms.Padding(0);
            this.buttonCEBack.Name = "buttonCEBack";
            this.buttonCEBack.Size = new System.Drawing.Size(90, 34);
            this.buttonCEBack.TabIndex = 2;
            this.buttonCEBack.Text = "Back";
            this.buttonCEBack.UseVisualStyleBackColor = true;
            // 
            // formConfirmEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 411);
            this.Controls.Add(this.buttonCEBack);
            this.Controls.Add(this.buttonCEConfirm);
            this.Controls.Add(this.dataCETable);
            this.Name = "formConfirmEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "formConfirmEdit";
            ((System.ComponentModel.ISupportInitialize)(this.dataCETable)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataCETable;
        private System.Windows.Forms.DataGridViewTextBoxColumn Property;
        private System.Windows.Forms.DataGridViewTextBoxColumn New;
        private System.Windows.Forms.DataGridViewTextBoxColumn Previous;
        private System.Windows.Forms.Button buttonCEConfirm;
        private System.Windows.Forms.Button buttonCEBack;
    }
}