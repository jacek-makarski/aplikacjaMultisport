namespace AppMultisport {
    partial class InvoiceTotalDialog {
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
            this.buttonOK = new System.Windows.Forms.Button();
            this.invoiceTotalUpDown1 = new AppMultisport.InvoiceTotalUpDown();
            this.buttonRevert = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonOK
            // 
            this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Location = new System.Drawing.Point(155, 104);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 0;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            // 
            // invoiceTotalUpDown1
            // 
            this.invoiceTotalUpDown1.InvoiceTotal = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.invoiceTotalUpDown1.Location = new System.Drawing.Point(12, 12);
            this.invoiceTotalUpDown1.MaximumSize = new System.Drawing.Size(0, 78);
            this.invoiceTotalUpDown1.MinimumSize = new System.Drawing.Size(220, 78);
            this.invoiceTotalUpDown1.Name = "invoiceTotalUpDown1";
            this.invoiceTotalUpDown1.Size = new System.Drawing.Size(220, 78);
            this.invoiceTotalUpDown1.Summary = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.invoiceTotalUpDown1.TabIndex = 2;
            // 
            // buttonRevert
            // 
            this.buttonRevert.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonRevert.Enabled = false;
            this.buttonRevert.Location = new System.Drawing.Point(74, 104);
            this.buttonRevert.Name = "buttonRevert";
            this.buttonRevert.Size = new System.Drawing.Size(75, 23);
            this.buttonRevert.TabIndex = 3;
            this.buttonRevert.Text = "Przywróć";
            this.buttonRevert.UseVisualStyleBackColor = true;
            this.buttonRevert.Click += new System.EventHandler(this.buttonRevert_Click);
            // 
            // InvoiceTotalDialog
            // 
            this.AcceptButton = this.buttonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(242, 139);
            this.ControlBox = false;
            this.Controls.Add(this.buttonRevert);
            this.Controls.Add(this.invoiceTotalUpDown1);
            this.Controls.Add(this.buttonOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InvoiceTotalDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kwota faktury";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonOK;
        private InvoiceTotalUpDown invoiceTotalUpDown1;
        private System.Windows.Forms.Button buttonRevert;
    }
}