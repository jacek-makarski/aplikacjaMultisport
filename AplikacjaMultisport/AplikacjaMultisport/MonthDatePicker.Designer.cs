namespace AppMultisport {
    partial class MonthDatePicker {
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
            this.comboBoxMonth = new System.Windows.Forms.ComboBox();
            this.spinBoxYear = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.spinBoxYear)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBoxMonth
            // 
            this.comboBoxMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxMonth.FormattingEnabled = true;
            this.comboBoxMonth.Items.AddRange(new object[] {
            "styczeń",
            "luty",
            "marzec",
            "kwiecień",
            "maj",
            "czerwiec",
            "lipiec",
            "sierpień",
            "wrzesień",
            "październik",
            "listopad",
            "grudzień"});
            this.comboBoxMonth.Location = new System.Drawing.Point(3, 3);
            this.comboBoxMonth.MaxDropDownItems = 12;
            this.comboBoxMonth.Name = "comboBoxMonth";
            this.comboBoxMonth.Size = new System.Drawing.Size(121, 21);
            this.comboBoxMonth.TabIndex = 0;
            // 
            // spinBoxYear
            // 
            this.spinBoxYear.Location = new System.Drawing.Point(130, 4);
            this.spinBoxYear.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.spinBoxYear.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spinBoxYear.Name = "spinBoxYear";
            this.spinBoxYear.Size = new System.Drawing.Size(47, 20);
            this.spinBoxYear.TabIndex = 1;
            this.spinBoxYear.Value = new decimal(new int[] {
            2017,
            0,
            0,
            0});
            // 
            // MonthDatePicker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.spinBoxYear);
            this.Controls.Add(this.comboBoxMonth);
            this.MaximumSize = new System.Drawing.Size(180, 27);
            this.MinimumSize = new System.Drawing.Size(180, 27);
            this.Name = "MonthDatePicker";
            this.Size = new System.Drawing.Size(180, 27);
            ((System.ComponentModel.ISupportInitialize)(this.spinBoxYear)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxMonth;
        private System.Windows.Forms.NumericUpDown spinBoxYear;
    }
}
