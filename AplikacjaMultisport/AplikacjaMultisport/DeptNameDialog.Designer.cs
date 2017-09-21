namespace AppMultisport {
    partial class DeptNameDialog {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOK = new System.Windows.Forms.Button();
            this.textBoxDeptName = new System.Windows.Forms.TextBox();
            this.labelDeptName = new System.Windows.Forms.Label();
            this.textBoxDeptShortName = new System.Windows.Forms.TextBox();
            this.labelDeptShortName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(217, 69);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 3;
            this.buttonCancel.Text = "Anuluj";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // buttonOK
            // 
            this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Enabled = false;
            this.buttonOK.Location = new System.Drawing.Point(136, 69);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 4;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            // 
            // textBoxDeptName
            // 
            this.textBoxDeptName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxDeptName.Location = new System.Drawing.Point(91, 12);
            this.textBoxDeptName.Name = "textBoxDeptName";
            this.textBoxDeptName.Size = new System.Drawing.Size(200, 20);
            this.textBoxDeptName.TabIndex = 1;
            this.textBoxDeptName.TextChanged += new System.EventHandler(this.textBoxDeptName_TextChanged);
            // 
            // labelDeptName
            // 
            this.labelDeptName.AutoSize = true;
            this.labelDeptName.Location = new System.Drawing.Point(13, 15);
            this.labelDeptName.Name = "labelDeptName";
            this.labelDeptName.Size = new System.Drawing.Size(72, 13);
            this.labelDeptName.TabIndex = 6;
            this.labelDeptName.Text = "Nazwa działu";
            // 
            // textBoxDeptShortName
            // 
            this.textBoxDeptShortName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxDeptShortName.Location = new System.Drawing.Point(201, 38);
            this.textBoxDeptShortName.Name = "textBoxDeptShortName";
            this.textBoxDeptShortName.Size = new System.Drawing.Size(90, 20);
            this.textBoxDeptShortName.TabIndex = 2;
            // 
            // labelDeptShortName
            // 
            this.labelDeptShortName.AutoSize = true;
            this.labelDeptShortName.Location = new System.Drawing.Point(13, 41);
            this.labelDeptShortName.Name = "labelDeptShortName";
            this.labelDeptShortName.Size = new System.Drawing.Size(182, 13);
            this.labelDeptShortName.TabIndex = 8;
            this.labelDeptShortName.Text = "Skrócona nazwa działu (opcjonalnie)";
            // 
            // DeptNameDialog
            // 
            this.AcceptButton = this.buttonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(304, 104);
            this.Controls.Add(this.labelDeptShortName);
            this.Controls.Add(this.textBoxDeptShortName);
            this.Controls.Add(this.labelDeptName);
            this.Controls.Add(this.textBoxDeptName);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.buttonCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DeptNameDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Określ nazwę działu";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DeptNameDialog_FormClosing);
            this.Shown += new System.EventHandler(this.DeptNameDialog_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.TextBox textBoxDeptName;
        private System.Windows.Forms.Label labelDeptName;
        private System.Windows.Forms.TextBox textBoxDeptShortName;
        private System.Windows.Forms.Label labelDeptShortName;
    }
}