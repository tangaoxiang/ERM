using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
namespace ERM.UI
{
    public partial class frmMainSearch : ERM.UI.Controls.Skin_DevEX
    {
        private frmCellMain _parentForm;
        private frmFileMain _parentFormEx;
        public frmMainSearch(Form frm)
        {
            InitializeComponent();
            this.txtSearchTitle.OnTextChanged += txtSearchTitle_TextChanged;
            if (frm.Name == "frmCellMain")
            {
                this._parentForm = (frmCellMain)frm;
            }
            else if (frm.Name == "frmFileMain")
            {
                this._parentFormEx = (frmFileMain)frm;
            }
            CheckText();
        }
        private void frmMainSearch_Load(object sender, EventArgs e)
        {
            this.ActiveControl = txtSearchTitle;
        }
        ////填充下拉选单
        private void btnSearchCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnSearchConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtSearchTitle.Text.Trim() == "")
                {
                    txtSearchTitle.Focus();
                    TX.Framework.WindowUI.Forms.TXMessageBoxExtensions.Info("请输入查询字符！");
                    return;
                }

                if (!MyCommon.IsMatchCode(this.txtSearchTitle.Text.Trim()))
                {
                    this.txtSearchTitle.Focus();
                    TX.Framework.WindowUI.Forms.TXMessageBoxExtensions.Info("没有找到相关资料！");
                    return;
                }

                if (_parentForm != null)
                {
                    btnSearchConfirm.Tag = this._parentForm.DoFind(btnSearchConfirm.Tag.ToString(), "", txtSearchTitle.Text, false, true);
                }
                else if (_parentFormEx != null)
                {
                    btnSearchConfirm.Tag = this._parentFormEx.DoFind(btnSearchConfirm.Tag.ToString(), "", txtSearchTitle.Text, false, true);
                }
            }
            catch (Exception)
            {
                TX.Framework.WindowUI.Forms.TXMessageBoxExtensions.Info("没有找到相关资料！");
            }
            //this.Focus();
        }


        private void DoTextChange()
        {
            btnSearchConfirm.Tag = "";
            if (txtSearchTitle.Text.Trim() == "")
            {
                btnSearchConfirm.Enabled = false;
            }
            else
            {
                btnSearchConfirm.Enabled = true;
            }
        }
        private void txtSearchTitle_TextChanged(object sender, EventArgs e)
        {
            this.DoTextChange();
            CheckText();
        }
        private void cboCodeno_TextChanged(object sender, EventArgs e)
        {
            this.DoTextChange();
        }
        private void CheckText()
        {
            if (!String.IsNullOrEmpty(txtSearchTitle.Text.Trim()))
            {
                btnSearchConfirm.Enabled = true;
            }
            else
            {
                btnSearchConfirm.Enabled = false;
            }
        }

        private void btnSearchConfirm_Click_1(object sender, EventArgs e)
        {

        }
    }
}
