using System.Windows.Forms;

namespace AppMultisport {
    public partial class InvoiceTotalDialog : Form {

        private decimal declaredInvoiceTotal;

        public decimal Summary {
            get {
                return invoiceTotalUpDown1.Summary;
            }
            set {
                invoiceTotalUpDown1.Summary = value;
            }
        }

        public decimal InvoiceTotal {
            get {
                return invoiceTotalUpDown1.InvoiceTotal;
            }
            set {
                buttonRevert.Enabled = true;
                declaredInvoiceTotal = value;
                invoiceTotalUpDown1.InvoiceTotal = value;
            }
        }

        public InvoiceTotalDialog() {
            InitializeComponent();
        }

        private void buttonRevert_Click(object sender, System.EventArgs e) {
            InvoiceTotal = declaredInvoiceTotal;
        }
    }
}
