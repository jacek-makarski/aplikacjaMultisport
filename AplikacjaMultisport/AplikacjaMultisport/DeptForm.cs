using System;
using System.Windows.Forms;

namespace AppMultisport {

    public partial class DeptForm : Form {

        private void buttonDone_Click(object sender, EventArgs e) {
            DAO.ApplyDeptUpdate(deptEdit1.PreparedUpdate);
        }

        public DeptForm() {
            InitializeComponent();
        }

        private void DeptForm_FormClosing(object sender, FormClosingEventArgs e) {
            if (DialogResult == DialogResult.Cancel) {
                if (deptEdit1.PreparedUpdate.Changes) {
                    if (MessageBox.Show("Wprowadzone zmiany nie zostaną zapisane. Czy na pewno anulować edycję działów?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No) {
                        e.Cancel = true;
                    }
                }
            }
        }
    }
}
