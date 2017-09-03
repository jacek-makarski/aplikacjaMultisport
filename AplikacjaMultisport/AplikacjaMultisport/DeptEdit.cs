using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace AppMultisport {

    public partial class DeptEdit : UserControl {

        public DeptUpdate PreparedUpdate { get; private set; }

        private void RefreshListBox() {
            listBoxDepts.DisplayMember = "";
            listBoxDepts.DisplayMember = "Name";
        }

        private void SetupForEmptyList() {
            listBoxDepts.Enabled = false;
            textBoxDeptName.Enabled = false;
            textBoxDeptName.Text = string.Empty;
            buttonRemove.Enabled = false;
            buttonUp.Enabled = false;
            buttonDown.Enabled = false;
        }

        private void SetupForNonEmptyList() {
            listBoxDepts.Enabled = true;
            textBoxDeptName.Enabled = true;
            buttonRemove.Enabled = true;
        }

        private void listBoxDepts_SelectedIndexChanged(object sender, EventArgs e) {
            textBoxDeptName.Text = ((Dept) listBoxDepts.SelectedItem).Name;
            buttonUp.Enabled = !(listBoxDepts.SelectedIndex == 0);
            buttonDown.Enabled = !(listBoxDepts.SelectedIndex == listBoxDepts.Items.Count - 1);
        }

        private void textBoxDeptName_Validating(object sender, CancelEventArgs e) {
            if (textBoxDeptName.Text.Equals(string.Empty)) {
                MessageBox.Show("Nazwa działu nie może być pusta.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
            }
        }

        private void textBoxDeptName_Validated(object sender, EventArgs e) {
            PreparedUpdate.Rename(listBoxDepts.SelectedIndex, textBoxDeptName.Text);
            RefreshListBox();
        }

        private void textBoxDeptName_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {  //Zatwierdzanie klawiszem Enter
                listBoxDepts.Focus();
                e.Handled = e.SuppressKeyPress = true;
            }
            if (e.KeyCode == Keys.Escape) {  //Wycofywanie klawiszem Escape
                textBoxDeptName.CausesValidation = false;
                textBoxDeptName.Text = listBoxDepts.Items[listBoxDepts.SelectedIndex].ToString();
                listBoxDepts.Focus();
                e.Handled = e.SuppressKeyPress = true;
                textBoxDeptName.CausesValidation = true;
            }
        }

        private void buttonAddDept_Click(object sender, EventArgs e) {
            PreparedUpdate.AddDept();
            RefreshListBox();
            if (listBoxDepts.Items.Count == 1) {
                SetupForNonEmptyList();
            }
            listBoxDepts.SelectedIndex = listBoxDepts.Items.Count - 1;
            textBoxDeptName.SelectAll();
            textBoxDeptName.Focus();
        }

        private void buttonRemove_Click(object sender, EventArgs e) {
            if (MessageBox.Show("Czy na pewno usunąć dział, a także informacje o jego pracownikach i ich historię kart?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes) {
                PreparedUpdate.DeleteDept(listBoxDepts.SelectedIndex);
                RefreshListBox();
                if (listBoxDepts.Items.Count > 0) {
                    listBoxDepts.SelectedIndex = 0;
                } else {
                    SetupForEmptyList();
                }
            }
        }

        private void buttonDown_Click(object sender, EventArgs e) {
            int movedDeptIndex = listBoxDepts.SelectedIndex;
            PreparedUpdate.MoveDown(movedDeptIndex);
            RefreshListBox();
            listBoxDepts.SelectedIndex = movedDeptIndex + 1;
        }

        private void buttonUp_Click(object sender, EventArgs e) {
            int movedDeptIndex = listBoxDepts.SelectedIndex;
            PreparedUpdate.MoveUp(movedDeptIndex);
            RefreshListBox();
            listBoxDepts.SelectedIndex = movedDeptIndex - 1;
        }
        
        public DeptEdit() {
            InitializeComponent();
            PreparedUpdate = new DeptUpdate(DAO.GetDepartments());
            listBoxDepts.DataSource = PreparedUpdate.EditedDepts;
            if (listBoxDepts.Items.Count == 0) {
                SetupForEmptyList();
            } else {
                listBoxDepts.SelectedIndex = 0;
                listBoxDepts.DisplayMember = "Name";
            }
        }

    }
}
