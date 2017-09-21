namespace AppMultisport {
    partial class EmployeeDataPanel {
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.PersonCheckboxGroup = new System.Windows.Forms.GroupBox();
            this.checkBoxRetirement = new System.Windows.Forms.CheckBox();
            this.comboBoxNewDept = new System.Windows.Forms.ComboBox();
            this.textBoxNewLastName = new System.Windows.Forms.TextBox();
            this.textBoxNewFirstName = new System.Windows.Forms.TextBox();
            this.checkBoxNewDept = new System.Windows.Forms.CheckBox();
            this.checkBoxLastName = new System.Windows.Forms.CheckBox();
            this.checkBoxFirstName = new System.Windows.Forms.CheckBox();
            this.PersonCheckboxGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // PersonCheckboxGroup
            // 
            this.PersonCheckboxGroup.Controls.Add(this.checkBoxRetirement);
            this.PersonCheckboxGroup.Controls.Add(this.comboBoxNewDept);
            this.PersonCheckboxGroup.Controls.Add(this.textBoxNewLastName);
            this.PersonCheckboxGroup.Controls.Add(this.textBoxNewFirstName);
            this.PersonCheckboxGroup.Controls.Add(this.checkBoxNewDept);
            this.PersonCheckboxGroup.Controls.Add(this.checkBoxLastName);
            this.PersonCheckboxGroup.Controls.Add(this.checkBoxFirstName);
            this.PersonCheckboxGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PersonCheckboxGroup.Location = new System.Drawing.Point(0, 0);
            this.PersonCheckboxGroup.Name = "PersonCheckboxGroup";
            this.PersonCheckboxGroup.Size = new System.Drawing.Size(240, 127);
            this.PersonCheckboxGroup.TabIndex = 14;
            this.PersonCheckboxGroup.TabStop = false;
            this.PersonCheckboxGroup.Text = "Zmiana danych osoby";
            // 
            // checkBoxRetirement
            // 
            this.checkBoxRetirement.AutoSize = true;
            this.checkBoxRetirement.Location = new System.Drawing.Point(21, 103);
            this.checkBoxRetirement.Name = "checkBoxRetirement";
            this.checkBoxRetirement.Size = new System.Drawing.Size(73, 17);
            this.checkBoxRetirement.TabIndex = 20;
            this.checkBoxRetirement.Text = "Emerytura";
            this.checkBoxRetirement.UseVisualStyleBackColor = true;
            // 
            // comboBoxNewDept
            // 
            this.comboBoxNewDept.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxNewDept.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxNewDept.Enabled = false;
            this.comboBoxNewDept.FormattingEnabled = true;
            this.comboBoxNewDept.Location = new System.Drawing.Point(99, 75);
            this.comboBoxNewDept.Name = "comboBoxNewDept";
            this.comboBoxNewDept.Size = new System.Drawing.Size(121, 21);
            this.comboBoxNewDept.TabIndex = 19;
            // 
            // textBoxNewLastName
            // 
            this.textBoxNewLastName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxNewLastName.Enabled = false;
            this.textBoxNewLastName.Location = new System.Drawing.Point(99, 49);
            this.textBoxNewLastName.Name = "textBoxNewLastName";
            this.textBoxNewLastName.Size = new System.Drawing.Size(121, 20);
            this.textBoxNewLastName.TabIndex = 18;
            this.textBoxNewLastName.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxNewLastName_Validating);
            // 
            // textBoxNewFirstName
            // 
            this.textBoxNewFirstName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxNewFirstName.Enabled = false;
            this.textBoxNewFirstName.Location = new System.Drawing.Point(99, 23);
            this.textBoxNewFirstName.Name = "textBoxNewFirstName";
            this.textBoxNewFirstName.Size = new System.Drawing.Size(121, 20);
            this.textBoxNewFirstName.TabIndex = 17;
            this.textBoxNewFirstName.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxNewFirstName_Validating);
            // 
            // checkBoxNewDept
            // 
            this.checkBoxNewDept.AutoSize = true;
            this.checkBoxNewDept.Location = new System.Drawing.Point(21, 77);
            this.checkBoxNewDept.Name = "checkBoxNewDept";
            this.checkBoxNewDept.Size = new System.Drawing.Size(51, 17);
            this.checkBoxNewDept.TabIndex = 16;
            this.checkBoxNewDept.Text = "Dział";
            this.checkBoxNewDept.UseVisualStyleBackColor = true;
            this.checkBoxNewDept.CheckedChanged += new System.EventHandler(this.checkBoxNewDept_CheckedChanged);
            // 
            // checkBoxLastName
            // 
            this.checkBoxLastName.AutoSize = true;
            this.checkBoxLastName.Location = new System.Drawing.Point(21, 51);
            this.checkBoxLastName.Name = "checkBoxLastName";
            this.checkBoxLastName.Size = new System.Drawing.Size(72, 17);
            this.checkBoxLastName.TabIndex = 15;
            this.checkBoxLastName.Text = "Nazwisko";
            this.checkBoxLastName.UseVisualStyleBackColor = true;
            this.checkBoxLastName.CheckedChanged += new System.EventHandler(this.checkBoxLastName_CheckedChanged);
            // 
            // checkBoxFirstName
            // 
            this.checkBoxFirstName.AutoSize = true;
            this.checkBoxFirstName.Location = new System.Drawing.Point(21, 25);
            this.checkBoxFirstName.Name = "checkBoxFirstName";
            this.checkBoxFirstName.Size = new System.Drawing.Size(45, 17);
            this.checkBoxFirstName.TabIndex = 14;
            this.checkBoxFirstName.Text = "Imię";
            this.checkBoxFirstName.UseVisualStyleBackColor = true;
            this.checkBoxFirstName.CheckedChanged += new System.EventHandler(this.checkBoxFirstName_CheckedChanged);
            // 
            // EmployeeDataPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.PersonCheckboxGroup);
            this.MaximumSize = new System.Drawing.Size(0, 127);
            this.MinimumSize = new System.Drawing.Size(240, 127);
            this.Name = "EmployeeDataPanel";
            this.Size = new System.Drawing.Size(240, 127);
            this.PersonCheckboxGroup.ResumeLayout(false);
            this.PersonCheckboxGroup.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox PersonCheckboxGroup;
        private System.Windows.Forms.ComboBox comboBoxNewDept;
        private System.Windows.Forms.TextBox textBoxNewLastName;
        private System.Windows.Forms.TextBox textBoxNewFirstName;
        private System.Windows.Forms.CheckBox checkBoxNewDept;
        private System.Windows.Forms.CheckBox checkBoxLastName;
        private System.Windows.Forms.CheckBox checkBoxFirstName;
        private System.Windows.Forms.CheckBox checkBoxRetirement;
    }
}
