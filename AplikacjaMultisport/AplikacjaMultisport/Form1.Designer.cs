namespace AppMultisport {
    partial class Form1 {
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
            this.components = new System.ComponentModel.Container();
            this.buttonFindEmployee = new System.Windows.Forms.Button();
            this.buttonDeleteEmployee = new System.Windows.Forms.Button();
            this.buttonConfirm = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.mainMenu = new System.Windows.Forms.MainMenu(this.components);
            this.menuReports = new System.Windows.Forms.MenuItem();
            this.menuItemGenerateCurrent = new System.Windows.Forms.MenuItem();
            this.menuItemGenerateForSelectedMonth = new System.Windows.Forms.MenuItem();
            this.menuData = new System.Windows.Forms.MenuItem();
            this.menuItemEditDepts = new System.Windows.Forms.MenuItem();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.employeeDataPanel1 = new AppMultisport.EmployeeDataPanel();
            this.cardStatusPanel1 = new AppMultisport.CardStatusRadioPanel();
            this.identityInput1 = new AppMultisport.IdentityInput();
            this.narrowDownPanel1 = new AppMultisport.NarrowDownPanel();
            this.SuspendLayout();
            // 
            // buttonFindEmployee
            // 
            this.buttonFindEmployee.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonFindEmployee.AutoSize = true;
            this.buttonFindEmployee.Location = new System.Drawing.Point(93, 149);
            this.buttonFindEmployee.Name = "buttonFindEmployee";
            this.buttonFindEmployee.Size = new System.Drawing.Size(98, 23);
            this.buttonFindEmployee.TabIndex = 1;
            this.buttonFindEmployee.Text = "Dalej";
            this.buttonFindEmployee.UseVisualStyleBackColor = true;
            this.buttonFindEmployee.Click += new System.EventHandler(this.buttonFindEmployee_Click);
            // 
            // buttonDeleteEmployee
            // 
            this.buttonDeleteEmployee.AutoSize = true;
            this.buttonDeleteEmployee.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonDeleteEmployee.CausesValidation = false;
            this.buttonDeleteEmployee.Enabled = false;
            this.buttonDeleteEmployee.Location = new System.Drawing.Point(22, 542);
            this.buttonDeleteEmployee.Name = "buttonDeleteEmployee";
            this.buttonDeleteEmployee.Size = new System.Drawing.Size(42, 23);
            this.buttonDeleteEmployee.TabIndex = 5;
            this.buttonDeleteEmployee.Text = "Usuń";
            this.buttonDeleteEmployee.UseVisualStyleBackColor = true;
            this.buttonDeleteEmployee.Visible = false;
            this.buttonDeleteEmployee.Click += new System.EventHandler(this.buttonDeleteEmployee_Click);
            // 
            // buttonConfirm
            // 
            this.buttonConfirm.Enabled = false;
            this.buttonConfirm.Location = new System.Drawing.Point(197, 542);
            this.buttonConfirm.Name = "buttonConfirm";
            this.buttonConfirm.Size = new System.Drawing.Size(75, 23);
            this.buttonConfirm.TabIndex = 6;
            this.buttonConfirm.Text = "Zatwierdź";
            this.buttonConfirm.UseVisualStyleBackColor = true;
            this.buttonConfirm.Click += new System.EventHandler(this.buttonConfirm_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.CausesValidation = false;
            this.buttonCancel.Enabled = false;
            this.buttonCancel.Location = new System.Drawing.Point(116, 542);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 7;
            this.buttonCancel.Text = "Anuluj";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // mainMenu
            // 
            this.mainMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuReports,
            this.menuData});
            // 
            // menuReports
            // 
            this.menuReports.Index = 0;
            this.menuReports.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemGenerateCurrent,
            this.menuItemGenerateForSelectedMonth});
            this.menuReports.Text = "Raporty";
            // 
            // menuItemGenerateCurrent
            // 
            this.menuItemGenerateCurrent.Index = 0;
            this.menuItemGenerateCurrent.Text = "Generuj bieżący raport...";
            this.menuItemGenerateCurrent.Click += new System.EventHandler(this.menuItemGenerateCurrent_Click);
            // 
            // menuItemGenerateForSelectedMonth
            // 
            this.menuItemGenerateForSelectedMonth.Index = 1;
            this.menuItemGenerateForSelectedMonth.Text = "Generuj raport na wybrany miesiąc...";
            this.menuItemGenerateForSelectedMonth.Click += new System.EventHandler(this.menuItemGenerateForSelectedMonth_Click);
            // 
            // menuData
            // 
            this.menuData.Index = 1;
            this.menuData.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemEditDepts});
            this.menuData.Text = "Dane";
            // 
            // menuItemEditDepts
            // 
            this.menuItemEditDepts.Index = 0;
            this.menuItemEditDepts.Text = "Działy...";
            this.menuItemEditDepts.Click += new System.EventHandler(this.menuItemEditDepts_Click);
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.DefaultExt = "xlsx";
            this.saveFileDialog.Filter = "Skoroszyt programu Excel|*.xlsx";
            this.saveFileDialog.Title = "Zapisywanie raportu";
            // 
            // employeeDataPanel1
            // 
            this.employeeDataPanel1.Enabled = false;
            this.employeeDataPanel1.Location = new System.Drawing.Point(22, 402);
            this.employeeDataPanel1.MaximumSize = new System.Drawing.Size(240, 125);
            this.employeeDataPanel1.MinimumSize = new System.Drawing.Size(240, 125);
            this.employeeDataPanel1.Name = "employeeDataPanel1";
            this.employeeDataPanel1.Size = new System.Drawing.Size(240, 125);
            this.employeeDataPanel1.TabIndex = 4;
            // 
            // cardStatusPanel1
            // 
            this.cardStatusPanel1.Enabled = false;
            this.cardStatusPanel1.Location = new System.Drawing.Point(40, 296);
            this.cardStatusPanel1.MaximumSize = new System.Drawing.Size(200, 100);
            this.cardStatusPanel1.MinimumSize = new System.Drawing.Size(0, 100);
            this.cardStatusPanel1.Name = "cardStatusPanel1";
            this.cardStatusPanel1.Size = new System.Drawing.Size(200, 100);
            this.cardStatusPanel1.TabIndex = 3;
            // 
            // identityInput1
            // 
            this.identityInput1.Location = new System.Drawing.Point(22, 12);
            this.identityInput1.MaximumSize = new System.Drawing.Size(0, 140);
            this.identityInput1.MinimumSize = new System.Drawing.Size(240, 140);
            this.identityInput1.Name = "identityInput1";
            this.identityInput1.Size = new System.Drawing.Size(240, 140);
            this.identityInput1.TabIndex = 0;
            // 
            // narrowDownPanel1
            // 
            this.narrowDownPanel1.Enabled = false;
            this.narrowDownPanel1.Location = new System.Drawing.Point(40, 187);
            this.narrowDownPanel1.MinimumSize = new System.Drawing.Size(200, 100);
            this.narrowDownPanel1.Name = "narrowDownPanel1";
            this.narrowDownPanel1.Size = new System.Drawing.Size(200, 103);
            this.narrowDownPanel1.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 577);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonConfirm);
            this.Controls.Add(this.buttonDeleteEmployee);
            this.Controls.Add(this.employeeDataPanel1);
            this.Controls.Add(this.cardStatusPanel1);
            this.Controls.Add(this.buttonFindEmployee);
            this.Controls.Add(this.identityInput1);
            this.Controls.Add(this.narrowDownPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Menu = this.mainMenu;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private IdentityInput identityInput1;
        private System.Windows.Forms.Button buttonFindEmployee;
        private NarrowDownPanel narrowDownPanel1;
        private CardStatusRadioPanel cardStatusPanel1;
        private EmployeeDataPanel employeeDataPanel1;
        private System.Windows.Forms.Button buttonDeleteEmployee;
        private System.Windows.Forms.Button buttonConfirm;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.MainMenu mainMenu;
        private System.Windows.Forms.MenuItem menuReports;
        private System.Windows.Forms.MenuItem menuItemGenerateCurrent;
        private System.Windows.Forms.MenuItem menuItemGenerateForSelectedMonth;
        private System.Windows.Forms.MenuItem menuData;
        private System.Windows.Forms.MenuItem menuItemEditDepts;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
    }
}

