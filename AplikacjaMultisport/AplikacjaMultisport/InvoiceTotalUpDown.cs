using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Windows.Forms;

namespace AppMultisport {
    public partial class InvoiceTotalUpDown : UserControl {
        
        private decimal summary;
        private decimal socialBenefitsFund;

        public decimal Summary {
            get {
                return summary;
            }
            set {
                summary = value;
                textBoxSummary.Text = summary.ToString("N2", CultureInfo.CurrentCulture);
                numericUpDownTotal.Minimum = summary;
                updateSocialBenefitsFund();
            }
        }

        public decimal InvoiceTotal {
            get {
                return numericUpDownTotal.Value;
            }
            set {
                if (value >= numericUpDownTotal.Minimum) {
                    numericUpDownTotal.Value = value;
                }
            }
        }

        private void updateSocialBenefitsFund() {
            socialBenefitsFund = numericUpDownTotal.Value - summary;
            textBoxSocialBenefitsFund.Text = socialBenefitsFund.ToString("N2", CultureInfo.CurrentCulture);
        }

        private void numericUpDownTotal_ValueChanged(object sender, EventArgs e) {
            updateSocialBenefitsFund();
        }

        public InvoiceTotalUpDown() {
            InitializeComponent();
            Summary = 0;
            numericUpDownTotal.Maximum = decimal.MaxValue;
        }
        
    }
}
