using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
namespace ERM.UI.File
{
    public partial class frmTitle : Form
    {
        FrmScan _form;
        public frmTitle(FrmScan scan)
        {
            InitializeComponent();
            _form = scan;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            _form.strTitle = this.textBox1.Text.Trim();
            this.DialogResult = DialogResult.OK;
        }
    }
}
