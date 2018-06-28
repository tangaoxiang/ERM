/*********************************
 * 作者　　张建宏
 * 日期　　2008-12-10
 * 功能　　案卷设置添加编辑
 * 
 * ********************************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ERM.Common;
using ERM.BLL;
using TX.Framework.WindowUI.Forms;
using TX.Framework.WindowUI.Controls;
namespace ERM.UI
{
    public partial class frmPageSizeDetail : ERM.UI.Controls.Skin_DevEX
    {
        private int? pid;
        private bool _IsDefault = false;
        ERM.CBLL.PageSize b_Pagesize = new ERM.CBLL.PageSize();
        ERM.MDL.PageSize model_PageSize = new ERM.MDL.PageSize();
        public frmPageSizeDetail(int? _pid)
        {
            InitializeComponent();
            this.pid = _pid;
        }
        private void frmPageSizeDetail_Load(object sender, EventArgs e)
        {
            if (pid.HasValue)
            {
                model_PageSize = new ERM.BLL.PageSize().Find((int)pid);
                numPages.Value = model_PageSize.Pages;
                numPfloat.Value = model_PageSize.Pfloat;
                txtptype.Text = model_PageSize.PTYPE;
                if (model_PageSize.IsDefault == 1)
                {
                    chIsDefault.Checked = true;
                    _IsDefault = true;
                }
                else
                    chIsDefault.Checked = false;
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
        private bool Check()
        {
            foreach (Control c in this.Controls)
            {
                if (c.GetType() == typeof(TextBox))
                {
                    if (c.Text.Trim() == "")
                    {
                        TXMessageBoxExtensions.Info("请将信息填写完整！");
                        c.Focus();
                        return false;
                    }
                }
            }
            if (numPages.Value <= numPfloat.Value)
            {
                TXMessageBoxExtensions.Info("页数浮动值必须小于页数稳定值！");
                numPages.Focus();
                return false;
            }
            if (chIsDefault.Checked == false)
            {
                if ((pid.HasValue) && _IsDefault)
                {
                    TXMessageBoxExtensions.Info("必须先设置一个默认！");
                    return false;
                }
            }
            return true;
        }
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (!Check())
                return;
            model_PageSize.PTYPE = MyCommon.ToSqlString(txtptype.Text.Trim());
            model_PageSize.Pages = Convert.ToInt16(numPages.Value);
            model_PageSize.Pfloat = Convert.ToInt16(numPfloat.Value);
            model_PageSize.IsDefault = (chIsDefault.Checked ? 1 : 0);
            if (chIsDefault.Checked == true && !_IsDefault)
            {
                b_Pagesize.ClearDefault();
            }
            if (pid.HasValue == false)
            {
                ERM.BLL.PageSize bll_pagesize = new ERM.BLL.PageSize();
                model_PageSize.PID = bll_pagesize.GetPageSizeMaxId() + 1;
                bll_pagesize.Add(model_PageSize);
            }
            else
            {
                b_Pagesize.Update(model_PageSize);
            }
            this.DialogResult = DialogResult.OK;
        }

        private void btnConfirm_Click_1(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {

        }
    }
}
