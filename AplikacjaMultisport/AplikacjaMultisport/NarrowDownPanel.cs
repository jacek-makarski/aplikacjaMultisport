using System;
using System.Windows.Forms;

namespace AppMultisport {

    public partial class NarrowDownPanel : UserControl {

        public event EventHandler ButtonNextClick;
        public event EventHandler ButtonCancelClick;

        public ListBox ListBoxEmployees => listBoxEmployees;

        public NarrowDownPanel() {
            InitializeComponent();
        }

        public void Clear() {
            listBoxEmployees.Items.Clear();
        }

        private void buttonNext_Click(object sender, EventArgs e) {   
            if (ButtonNextClick != null) {
                ButtonNextClick(this, e);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e) {
            if (ButtonCancelClick != null) {
                ButtonCancelClick(this, e);
            }
        }

    }

}
