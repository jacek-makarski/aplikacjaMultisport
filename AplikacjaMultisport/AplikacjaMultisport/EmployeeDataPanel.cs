using System;
using System.Collections.Generic;
using System.Windows.Forms;

using System.Diagnostics;

namespace AppMultisport {
    public partial class EmployeeDataPanel : UserControl {

        public bool ChangingFirstName => checkBoxFirstName.Checked;
        public string NewFirstName => textBoxNewFirstName.Text;
        public bool ChangingLastName => checkBoxLastName.Checked;
        public string NewLastName => textBoxNewLastName.Text;
        public bool ChangingDept => checkBoxNewDept.Checked;
        public Dept NewDept => (Dept) comboBoxNewDept.SelectedItem;

        private void checkBoxFirstName_CheckedChanged(object sender, EventArgs e) {
            textBoxNewFirstName.Enabled = checkBoxFirstName.Checked;
        }

        private void checkBoxLastName_CheckedChanged(object sender, EventArgs e) {
            textBoxNewLastName.Enabled = checkBoxLastName.Checked;
        }

        private void checkBoxNewDept_CheckedChanged(object sender, EventArgs e) {
            comboBoxNewDept.Enabled = checkBoxNewDept.Checked;
        }

        public EmployeeDataPanel() {
            InitializeComponent();
        }

        public void SetupDepartments(List<Dept> departments) {
            comboBoxNewDept.DataSource = departments;
        }

        public void Clear() {
            checkBoxFirstName.Checked = checkBoxLastName.Checked = checkBoxNewDept.Checked = false;
            textBoxNewFirstName.Text = textBoxNewLastName.Text = "";
            if (comboBoxNewDept.Items.Count > 0) {
                comboBoxNewDept.SelectedIndex = 0;
            }
        }

    }
}
