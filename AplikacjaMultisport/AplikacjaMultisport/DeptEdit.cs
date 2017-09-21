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
            buttonRename.Enabled = false;
            buttonRemove.Enabled = false;
            buttonUp.Enabled = false;
            buttonDown.Enabled = false;
        }

        private void SetupForNonEmptyList() {
            listBoxDepts.Enabled = true;
            buttonRename.Enabled = true;
            buttonRemove.Enabled = true;
        }

        private void listBoxDepts_SelectedIndexChanged(object sender, EventArgs e) {
            buttonUp.Enabled = !(listBoxDepts.SelectedIndex == 0);
            buttonDown.Enabled = !(listBoxDepts.SelectedIndex == listBoxDepts.Items.Count - 1);
        }

        private void buttonAddDept_Click(object sender, EventArgs e) {
            DeptNameDialog dialog = new DeptNameDialog();
            dialog.DeptName = "Nowy dział";
            bool continueInput = true;
            while (continueInput) {
                if (dialog.ShowDialog() == DialogResult.OK) {
                    if (PreparedUpdate.AddDeptIfUnique(dialog.DeptName, dialog.DeptShortName)) {
                        continueInput = false;
                        RefreshListBox();
                        if (listBoxDepts.Items.Count == 1) {
                            SetupForNonEmptyList();
                        }
                        listBoxDepts.SelectedIndex = listBoxDepts.Items.Count - 1;
                    } else {
                        MessageBox.Show("Nazwy działów i ich skróty muszą być unikalne.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                } else {  //w przypadku anulowania
                    continueInput = false;
                }
            }
        }

        private void buttonRemove_Click(object sender, EventArgs e) {
            if (MessageBox.Show("Czy na pewno usunąć dział?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes) {
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

        private void buttonRename_Click(object sender, EventArgs e) {
            DeptNameDialog dialog = new DeptNameDialog();
            dialog.DeptName = ((Dept) listBoxDepts.SelectedItem).Name;
            if (!((Dept) listBoxDepts.SelectedItem).ShortName.Equals(dialog.DeptName)) {
                dialog.DeptShortName = ((Dept) listBoxDepts.SelectedItem).ShortName;
            }
            bool continueInput = true;
            while (continueInput) {
                if (dialog.ShowDialog() == DialogResult.OK) {
                    if (PreparedUpdate.RenameIfUnique(listBoxDepts.SelectedIndex, dialog.DeptName, dialog.DeptShortName)) {
                        continueInput = false;
                        RefreshListBox();
                    } else {
                        MessageBox.Show("Nazwy działów i ich skróty muszą być unikalne.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                } else {  //w przypadku anulowania
                    continueInput = false;
                }
            }
        }
    }
}
