﻿using System;
using System.Windows.Forms;

namespace AppMultisport {
    public partial class DeptNameDialog : Form {

        public string DeptName {
            get {
                return textBoxDeptName.Text;
            }
            set {
                textBoxDeptName.Text = value;
            }
        }

        public string DeptShortName {
            get {
                return textBoxDeptShortName.Text;
            }
            set {
                textBoxDeptShortName.Text = value;
            }
        }

        public DeptNameDialog() {
            InitializeComponent();
        }

        private void textBoxDeptName_TextChanged(object sender, EventArgs e) {
            buttonOK.Enabled = !textBoxDeptName.Text.Equals(string.Empty);
        }

        private void DeptNameDialog_Shown(object sender, EventArgs e) {
            textBoxDeptName.SelectAll();
            textBoxDeptName.Focus();
        }
    }
}