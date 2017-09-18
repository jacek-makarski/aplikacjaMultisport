using System.Collections.Generic;
using System.Windows.Forms;

namespace AppMultisport {

    public partial class IdentityInput : UserControl {
        
        public string FirstName => textBoxFirstName.Text;
        public string LastName => textBoxLastName.Text;
        public Dept Department => (Dept) comboBoxDept.SelectedItem;
        public bool Retired => checkBoxRetired.Checked;
        public bool DepartmentSelected => comboBoxDept.SelectedIndex != -1;

        public void SetupDepartments(List<Dept> departments) {
            comboBoxDept.DataSource = departments;
        }

        public IdentityInput() {
            InitializeComponent();
        }

        private void checkBoxRetired_CheckedChanged(object sender, System.EventArgs e) {
            if (checkBoxRetired.Checked) {
                comboBoxDept.Enabled = false;
                comboBoxDept.SelectedIndex = -1;
            } else {
                comboBoxDept.Enabled = true;
                if (comboBoxDept.Items.Count > 0) {
                    comboBoxDept.SelectedIndex = 0;
                }
            }
        }
    }

}
