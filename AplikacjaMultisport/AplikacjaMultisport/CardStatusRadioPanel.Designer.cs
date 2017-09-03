namespace AppMultisport {
    partial class CardStatusRadioPanel {
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
            this.groupBoxCard = new System.Windows.Forms.GroupBox();
            this.radioButtonMultiPlus = new System.Windows.Forms.RadioButton();
            this.radioButtonMultiActive = new System.Windows.Forms.RadioButton();
            this.radioButtonInactiveCard = new System.Windows.Forms.RadioButton();
            this.groupBoxCard.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxCard
            // 
            this.groupBoxCard.Controls.Add(this.radioButtonMultiPlus);
            this.groupBoxCard.Controls.Add(this.radioButtonMultiActive);
            this.groupBoxCard.Controls.Add(this.radioButtonInactiveCard);
            this.groupBoxCard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxCard.Location = new System.Drawing.Point(0, 0);
            this.groupBoxCard.Name = "groupBoxCard";
            this.groupBoxCard.Size = new System.Drawing.Size(200, 100);
            this.groupBoxCard.TabIndex = 1;
            this.groupBoxCard.TabStop = false;
            this.groupBoxCard.Text = "Status karty";
            // 
            // radioButtonMultiPlus
            // 
            this.radioButtonMultiPlus.AutoSize = true;
            this.radioButtonMultiPlus.Location = new System.Drawing.Point(36, 69);
            this.radioButtonMultiPlus.Name = "radioButtonMultiPlus";
            this.radioButtonMultiPlus.Size = new System.Drawing.Size(66, 17);
            this.radioButtonMultiPlus.TabIndex = 2;
            this.radioButtonMultiPlus.Text = "multiPlus";
            this.radioButtonMultiPlus.UseVisualStyleBackColor = true;
            // 
            // radioButtonMultiActive
            // 
            this.radioButtonMultiActive.AutoSize = true;
            this.radioButtonMultiActive.Location = new System.Drawing.Point(36, 46);
            this.radioButtonMultiActive.Name = "radioButtonMultiActive";
            this.radioButtonMultiActive.Size = new System.Drawing.Size(76, 17);
            this.radioButtonMultiActive.TabIndex = 1;
            this.radioButtonMultiActive.Text = "multiActive";
            this.radioButtonMultiActive.UseVisualStyleBackColor = true;
            // 
            // radioButtonInactiveCard
            // 
            this.radioButtonInactiveCard.AutoSize = true;
            this.radioButtonInactiveCard.Checked = true;
            this.radioButtonInactiveCard.Location = new System.Drawing.Point(36, 23);
            this.radioButtonInactiveCard.Name = "radioButtonInactiveCard";
            this.radioButtonInactiveCard.Size = new System.Drawing.Size(79, 17);
            this.radioButtonInactiveCard.TabIndex = 0;
            this.radioButtonInactiveCard.TabStop = true;
            this.radioButtonInactiveCard.Text = "nieaktywna";
            this.radioButtonInactiveCard.UseVisualStyleBackColor = true;
            // 
            // CardStatusRadioPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBoxCard);
            this.MaximumSize = new System.Drawing.Size(200, 100);
            this.MinimumSize = new System.Drawing.Size(200, 100);
            this.Name = "CardStatusRadioPanel";
            this.Size = new System.Drawing.Size(200, 100);
            this.groupBoxCard.ResumeLayout(false);
            this.groupBoxCard.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxCard;
        private System.Windows.Forms.RadioButton radioButtonMultiPlus;
        private System.Windows.Forms.RadioButton radioButtonMultiActive;
        private System.Windows.Forms.RadioButton radioButtonInactiveCard;
    }
}
