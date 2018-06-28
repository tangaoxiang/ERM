using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Digi.B
{
    public partial class frmWelcome : Form
    {
        public frmWelcome()
        {
            InitializeComponent();
        }

        private void btnZjz_Click(object sender, EventArgs e)
        {
            frmStandard frm = new frmStandard(this);
            frm.Show();
            this.Hide();
        }

        private void btnGd_Click(object sender, EventArgs e)
        {
            frmNewCellEdit frm = new frmNewCellEdit(this);

            frm.Show();
            this.Hide();
        }
    }
}