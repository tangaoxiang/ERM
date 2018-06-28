using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ERM.Common;
namespace ERM.UI
{
    public partial class frmSignpassword : Form
    {
        public frmSignpassword()
        {
            InitializeComponent();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            bool bResult = false;
            bResult = this.axPDFReader1.VerifyPin(this.txtSignPassword.Text.Trim());
            if (bResult)
            {
                Globals.SignPassword = this.txtSignPassword.Text.Trim();
                this.Close();
            }
            else
            {
                MessageBox.Show("√‹¬Î¥ÌŒÛ!");
                this.txtSignPassword.Text = string.Empty;
                this.txtSignPassword.Focus();
                Globals.SignPassword = null;
            }
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            Globals.FrmCancle = false;
            this.Close();
        }
        private void btnExit_Click_1(object sender, EventArgs e)
        {
        }
    }
}
