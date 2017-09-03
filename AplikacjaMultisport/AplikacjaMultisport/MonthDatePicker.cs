using System;
using System.Windows.Forms;

namespace AppMultisport {

    public partial class MonthDatePicker : UserControl {

        public DateTime SelectedDate => new DateTime((int) spinBoxYear.Value, comboBoxMonth.SelectedIndex + 1, 1);
        
        public MonthDatePicker() {
            InitializeComponent();
            DateTime today = DateTime.Today;
            comboBoxMonth.SelectedIndex = today.Month - 1;
            spinBoxYear.Value = today.Year;
        }

    }

}
