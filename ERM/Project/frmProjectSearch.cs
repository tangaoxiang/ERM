using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TX.Framework.WindowUI.Forms;

namespace ERM.UI.Project
{
    /// <summary>
    /// 查找工程
    /// </summary>
    public partial class frmProjectSearch : ERM.UI.Controls.Skin_DevEX
    {
        #region 参数初始化
        private frmProjectList _parentForm;
        #endregion

        #region 窗体函数
        public frmProjectSearch(Form frm)
        {
            InitializeComponent();
            _parentForm = (frmProjectList)frm;
            this.btnSearchConfirm.Enabled = false;
            this.txt_ProjectNo._TextBox.TextChanged+=_TextBox_TextChanged;
            this.txt_ProjectName._TextBox.TextChanged+=_TextBox_TextChanged;
        }

        private void _TextBox_TextChanged(object sender, EventArgs e)
        {
            if (this.txt_ProjectName.Text==""&&this.txt_ProjectNo.Text=="")
            {
                 this.btnSearchConfirm.Enabled = false;
            }
            else
            {
                this.btnSearchConfirm.Enabled = true;
            }
        }
        private void btnSearchConfirm_Click(object sender, EventArgs e)
        {
            string projectNO = txt_ProjectNo.Text.Trim();
            string projectName = txt_ProjectName.Text.Trim();

            if (projectNO == "" && projectName == "")
            {
                txt_ProjectName.Focus();
                TXMessageBoxExtensions.Info("至少输入一个查询条件");
                return;
            }

            if (!MyCommon.IsMatchCode(projectNO))
            {
                projectNO = "";
            }

            if (!MyCommon.IsMatchCode(projectName))
            {
                projectName = "";
            }

            if (_parentForm != null)
            {
                this._parentForm.FindProject(
                   projectNO, projectName);
            }
            this.Focus();
        }
        private void frmProjectSearch_Load(object sender, EventArgs e)
        {
            this.ActiveControl = txt_ProjectNo;
        }
        #endregion

        private void btnSearchConfirm_Click_1(object sender, EventArgs e)
        {

        }

        private void txt_ProjectNo_KeyDown(object sender, KeyEventArgs e)
        {
           
        }

        #region 自定义函数
        #endregion
      
    }
}
