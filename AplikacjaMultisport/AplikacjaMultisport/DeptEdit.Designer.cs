namespace AppMultisport {
    partial class DeptEdit {
        /// <summary> 
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod wygenerowany przez Projektanta składników

        /// <summary> 
        /// Wymagana metoda obsługi projektanta — nie należy modyfikować 
        /// zawartość tej metody z edytorem kodu.
        /// </summary>
        private void InitializeComponent() {
            this.listBoxDepts = new System.Windows.Forms.ListBox();
            this.buttonAddDept = new System.Windows.Forms.Button();
            this.labelDeptName = new System.Windows.Forms.Label();
            this.textBoxDeptName = new System.Windows.Forms.TextBox();
            this.buttonUp = new System.Windows.Forms.Button();
            this.buttonDown = new System.Windows.Forms.Button();
            this.buttonRemove = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBoxDepts
            // 
            this.listBoxDepts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxDepts.HorizontalScrollbar = true;
            this.listBoxDepts.IntegralHeight = false;
            this.listBoxDepts.Location = new System.Drawing.Point(4, 3);
            this.listBoxDepts.Name = "listBoxDepts";
            this.listBoxDepts.Size = new System.Drawing.Size(120, 123);
            this.listBoxDepts.TabIndex = 0;
            this.listBoxDepts.SelectedIndexChanged += new System.EventHandler(this.listBoxDepts_SelectedIndexChanged);
            // 
            // buttonAddDept
            // 
            this.buttonAddDept.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAddDept.Location = new System.Drawing.Point(4, 132);
            this.buttonAddDept.Name = "buttonAddDept";
            this.buttonAddDept.Size = new System.Drawing.Size(120, 23);
            this.buttonAddDept.TabIndex = 1;
            this.buttonAddDept.Text = "Dodaj dział";
            this.buttonAddDept.UseVisualStyleBackColor = true;
            this.buttonAddDept.Click += new System.EventHandler(this.buttonAddDept_Click);
            // 
            // labelDeptName
            // 
            this.labelDeptName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelDeptName.AutoSize = true;
            this.labelDeptName.Location = new System.Drawing.Point(127, 3);
            this.labelDeptName.Name = "labelDeptName";
            this.labelDeptName.Size = new System.Drawing.Size(72, 13);
            this.labelDeptName.TabIndex = 2;
            this.labelDeptName.Text = "Nazwa działu";
            // 
            // textBoxDeptName
            // 
            this.textBoxDeptName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxDeptName.Location = new System.Drawing.Point(130, 19);
            this.textBoxDeptName.Name = "textBoxDeptName";
            this.textBoxDeptName.Size = new System.Drawing.Size(120, 20);
            this.textBoxDeptName.TabIndex = 3;
            this.textBoxDeptName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxDeptName_KeyDown);
            this.textBoxDeptName.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxDeptName_Validating);
            this.textBoxDeptName.Validated += new System.EventHandler(this.textBoxDeptName_Validated);
            // 
            // buttonUp
            // 
            this.buttonUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonUp.Location = new System.Drawing.Point(151, 45);
            this.buttonUp.Name = "buttonUp";
            this.buttonUp.Size = new System.Drawing.Size(75, 23);
            this.buttonUp.TabIndex = 4;
            this.buttonUp.Text = "W górę";
            this.buttonUp.UseVisualStyleBackColor = true;
            this.buttonUp.Click += new System.EventHandler(this.buttonUp_Click);
            // 
            // buttonDown
            // 
            this.buttonDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDown.Location = new System.Drawing.Point(151, 74);
            this.buttonDown.Name = "buttonDown";
            this.buttonDown.Size = new System.Drawing.Size(75, 23);
            this.buttonDown.TabIndex = 5;
            this.buttonDown.Text = "W dół";
            this.buttonDown.UseVisualStyleBackColor = true;
            this.buttonDown.Click += new System.EventHandler(this.buttonDown_Click);
            // 
            // buttonRemove
            // 
            this.buttonRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonRemove.Location = new System.Drawing.Point(151, 119);
            this.buttonRemove.Name = "buttonRemove";
            this.buttonRemove.Size = new System.Drawing.Size(75, 23);
            this.buttonRemove.TabIndex = 6;
            this.buttonRemove.Text = "Usuń";
            this.buttonRemove.UseVisualStyleBackColor = true;
            this.buttonRemove.Click += new System.EventHandler(this.buttonRemove_Click);
            // 
            // DeptEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonRemove);
            this.Controls.Add(this.buttonDown);
            this.Controls.Add(this.buttonUp);
            this.Controls.Add(this.textBoxDeptName);
            this.Controls.Add(this.labelDeptName);
            this.Controls.Add(this.buttonAddDept);
            this.Controls.Add(this.listBoxDepts);
            this.MinimumSize = new System.Drawing.Size(255, 158);
            this.Name = "DeptEdit";
            this.Size = new System.Drawing.Size(255, 158);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxDepts;
        private System.Windows.Forms.Button buttonAddDept;
        private System.Windows.Forms.Label labelDeptName;
        private System.Windows.Forms.TextBox textBoxDeptName;
        private System.Windows.Forms.Button buttonUp;
        private System.Windows.Forms.Button buttonDown;
        private System.Windows.Forms.Button buttonRemove;
    }
}
