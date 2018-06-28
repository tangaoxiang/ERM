using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
namespace ERM.UI
{
    public partial class frmDagdm : Form
    {
        public frmDagdm()
        {
            InitializeComponent();
        }
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (this.txtDagdm.Text.Trim() != "")
            {
                Properties.Settings.Default.DagDh = this.txtDagdm.Text.Trim();
                Properties.Settings.Default.Save();
                this.DialogResult = DialogResult.OK;
            }
            else
                return;
        }
        private void frmDagdm_Load(object sender, EventArgs e)
        {
            this.txtDagdm.Text = Properties.Settings.Default.DagDh;
        }
    }
}
