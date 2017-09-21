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
        public bool ChangingRetirement => checkBoxRetirement.Checked;

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

        public void SetRetirement(bool isRetired) {
            if (isRetired) {
                checkBoxRetirement.Text = "Powrót z emerytury";
            } else {
                checkBoxRetirement.Text = "Emerytura";
            }
        }

        public void Clear() {
            checkBoxFirstName.Checked = checkBoxLastName.Checked = checkBoxNewDept.Checked = checkBoxRetirement.Checked = false;
            textBoxNewFirstName.Text = textBoxNewLastName.Text = "";
            if (comboBoxNewDept.Items.Count > 0) {
                comboBoxNewDept.SelectedIndex = 0;
            }
        }

        private void textBoxNewFirstName_Validating(object sender, System.ComponentModel.CancelEventArgs e) {
            textBoxNewFirstName.Text = textBoxNewFirstName.Text.Trim();
        }
        
        private void textBoxNewLastName_Validating(object sender, System.ComponentModel.CancelEventArgs e) {
            textBoxNewLastName.Text = textBoxNewLastName.Text.Trim();
        }
    }
}
