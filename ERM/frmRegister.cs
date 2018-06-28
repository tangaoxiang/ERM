using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ERM;
namespace ERM.UI
{
    public partial class frmRegister : Form
    {
        public frmRegister()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
        }
        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            string RegResult = null;
            if (!String.IsNullOrEmpty(this.txtRegistNum.Text))
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MyCommon.Show("ÇëÌîÐ´×¢²áÂë!");
            }
        }
    }
}
