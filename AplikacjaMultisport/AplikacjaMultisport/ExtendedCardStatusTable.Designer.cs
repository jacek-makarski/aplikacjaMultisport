namespace AppMultisport {
    partial class ExtendedCardStatusTable {
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.EmployeeID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FirstName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Department = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Retired = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.CurrentCard = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PlannedCard = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.EmployeeID,
            this.LastName,
            this.FirstName,
            this.Department,
            this.Retired,
            this.CurrentCard,
            this.PlannedCard});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(559, 227);
            this.dataGridView1.TabIndex = 0;
            // 
            // EmployeeID
            // 
            this.EmployeeID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.EmployeeID.HeaderText = "ID Pracownika";
            this.EmployeeID.Name = "EmployeeID";
            this.EmployeeID.ReadOnly = true;
            this.EmployeeID.Width = 102;
            // 
            // LastName
            // 
            this.LastName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.LastName.HeaderText = "Nazwisko";
            this.LastName.Name = "LastName";
            this.LastName.ReadOnly = true;
            this.LastName.Width = 78;
            // 
            // FirstName
            // 
            this.FirstName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.FirstName.HeaderText = "Imię";
            this.FirstName.Name = "FirstName";
            this.FirstName.ReadOnly = true;
            this.FirstName.Width = 51;
            // 
            // Department
            // 
            this.Department.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Department.HeaderText = "Dział";
            this.Department.Name = "Department";
            this.Department.ReadOnly = true;
            this.Department.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Department.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Department.Width = 38;
            // 
            // Retired
            // 
            this.Retired.HeaderText = "Emerytowany";
            this.Retired.Name = "Retired";
            this.Retired.ReadOnly = true;
            // 
            // CurrentCard
            // 
            this.CurrentCard.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.CurrentCard.HeaderText = "Stan karty";
            this.CurrentCard.Name = "CurrentCard";
            this.CurrentCard.ReadOnly = true;
            this.CurrentCard.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.CurrentCard.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.CurrentCard.Width = 61;
            // 
            // PlannedCard
            // 
            this.PlannedCard.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.PlannedCard.HeaderText = "Planowana zmiana";
            this.PlannedCard.Name = "PlannedCard";
            this.PlannedCard.ReadOnly = true;
            this.PlannedCard.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.PlannedCard.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PlannedCard.Width = 92;
            // 
            // ExtendedCardStatusTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataGridView1);
            this.Name = "ExtendedCardStatusTable";
            this.Size = new System.Drawing.Size(559, 227);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn EmployeeID;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastName;
        private System.Windows.Forms.DataGridViewTextBoxColumn FirstName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Department;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Retired;
        private System.Windows.Forms.DataGridViewTextBoxColumn CurrentCard;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlannedCard;
    }
}
