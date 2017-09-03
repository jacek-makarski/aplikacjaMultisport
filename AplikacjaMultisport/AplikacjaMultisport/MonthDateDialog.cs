using System;
using System.Windows.Forms;

namespace AppMultisport {

    public partial class MonthDateDialog : Form {

        public DateTime SelectedDate => monthDatePicker.SelectedDate;
        
        public MonthDateDialog() {
            InitializeComponent();
        }

    }

}
