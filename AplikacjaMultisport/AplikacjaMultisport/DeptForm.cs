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

    }
}
