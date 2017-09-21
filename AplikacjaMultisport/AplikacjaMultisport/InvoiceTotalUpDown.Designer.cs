namespace AppMultisport {
    partial class InvoiceTotalUpDown {
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
            this.numericUpDownTotal = new System.Windows.Forms.NumericUpDown();
            this.labelTotal = new System.Windows.Forms.Label();
            this.labelSummary = new System.Windows.Forms.Label();
            this.labelSocialBenefitsFund = new System.Windows.Forms.Label();
            this.textBoxSocialBenefitsFund = new System.Windows.Forms.TextBox();
            this.textBoxSummary = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTotal)).BeginInit();
            this.SuspendLayout();
            // 
            // numericUpDownTotal
            // 
            this.numericUpDownTotal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.numericUpDownTotal.DecimalPlaces = 2;
            this.numericUpDownTotal.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numericUpDownTotal.Location = new System.Drawing.Point(127, 55);
            this.numericUpDownTotal.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numericUpDownTotal.Name = "numericUpDownTotal";
            this.numericUpDownTotal.Size = new System.Drawing.Size(90, 20);
            this.numericUpDownTotal.TabIndex = 4;
            this.numericUpDownTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDownTotal.ThousandsSeparator = true;
            this.numericUpDownTotal.ValueChanged += new System.EventHandler(this.numericUpDownTotal_ValueChanged);
            // 
            // labelTotal
            // 
            this.labelTotal.AutoSize = true;
            this.labelTotal.Location = new System.Drawing.Point(46, 57);
            this.labelTotal.Name = "labelTotal";
            this.labelTotal.Size = new System.Drawing.Size(75, 13);
            this.labelTotal.TabIndex = 5;
            this.labelTotal.Text = "Kwota faktury:";
            // 
            // labelSummary
            // 
            this.labelSummary.AutoSize = true;
            this.labelSummary.Location = new System.Drawing.Point(0, 6);
            this.labelSummary.Name = "labelSummary";
            this.labelSummary.Size = new System.Drawing.Size(121, 13);
            this.labelSummary.TabIndex = 6;
            this.labelSummary.Text = "Podsumowanie ogółem:";
            // 
            // labelSocialBenefitsFund
            // 
            this.labelSocialBenefitsFund.AutoSize = true;
            this.labelSocialBenefitsFund.Location = new System.Drawing.Point(84, 32);
            this.labelSocialBenefitsFund.Name = "labelSocialBenefitsFund";
            this.labelSocialBenefitsFund.Size = new System.Drawing.Size(37, 13);
            this.labelSocialBenefitsFund.TabIndex = 7;
            this.labelSocialBenefitsFund.Text = "ZFSŚ:";
            // 
            // textBoxSocialBenefitsFund
            // 
            this.textBoxSocialBenefitsFund.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxSocialBenefitsFund.Location = new System.Drawing.Point(127, 29);
            this.textBoxSocialBenefitsFund.Name = "textBoxSocialBenefitsFund";
            this.textBoxSocialBenefitsFund.ReadOnly = true;
            this.textBoxSocialBenefitsFund.Size = new System.Drawing.Size(75, 20);
            this.textBoxSocialBenefitsFund.TabIndex = 9;
            this.textBoxSocialBenefitsFund.Text = "0,00";
            this.textBoxSocialBenefitsFund.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBoxSummary
            // 
            this.textBoxSummary.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxSummary.Location = new System.Drawing.Point(127, 3);
            this.textBoxSummary.Name = "textBoxSummary";
            this.textBoxSummary.ReadOnly = true;
            this.textBoxSummary.Size = new System.Drawing.Size(75, 20);
            this.textBoxSummary.TabIndex = 10;
            this.textBoxSummary.Text = "0,00";
            this.textBoxSummary.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // InvoiceTotalUpDown
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.textBoxSummary);
            this.Controls.Add(this.textBoxSocialBenefitsFund);
            this.Controls.Add(this.labelSocialBenefitsFund);
            this.Controls.Add(this.labelSummary);
            this.Controls.Add(this.labelTotal);
            this.Controls.Add(this.numericUpDownTotal);
            this.MaximumSize = new System.Drawing.Size(0, 78);
            this.MinimumSize = new System.Drawing.Size(220, 78);
            this.Name = "InvoiceTotalUpDown";
            this.Size = new System.Drawing.Size(220, 78);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTotal)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numericUpDownTotal;
        private System.Windows.Forms.Label labelTotal;
        private System.Windows.Forms.Label labelSummary;
        private System.Windows.Forms.Label labelSocialBenefitsFund;
        private System.Windows.Forms.TextBox textBoxSocialBenefitsFund;
        private System.Windows.Forms.TextBox textBoxSummary;
    }
}
