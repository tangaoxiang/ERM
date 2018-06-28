using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
namespace ERM.UI
{
    public partial class frmHeadInfo : ERM.UI.Controls.Skin_DevEX
    {
        public frmHeadInfo(string note)
        {
            InitializeComponent();
            DataSet ds = new ERM.BLL.Vars().GetList(" isvisible = 1");
            this.cboVars.DataSource = ds.Tables[0];
            cboVars.DisplayMember = "vartitle";
            cboVars.ValueMember = "varname";
            cboVars.SelectedIndex = -1;
            for (int i=0;i< ds.Tables[0].Rows.Count;i++)
            {
                DataRow dr = ds.Tables[0].Rows[i];
                if (dr["varname"].ToString() == note)
                {
                    cboVars.SelectedIndex = i;
                    break;
                }
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
        private void frmHeadInfo_Load(object sender, EventArgs e)
        {
        }
        private void btnClearHeadInfo_Click(object sender, EventArgs e)
        {
            this.cboVars.SelectedIndex = -1;
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnClearHeadInfo_Click_1(object sender, EventArgs e)
        {

        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {

        }
    }
}
