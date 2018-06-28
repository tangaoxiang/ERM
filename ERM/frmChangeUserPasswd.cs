using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ERM.Common;
using TX.Framework.WindowUI.Forms;
using CCWin;
using ERM.UI.Controls;

namespace ERM.UI
{
    /// <summary>
    /// 修改密码
    /// </summary>
    public partial class frmChangeUserPasswd :  Skin_DevEX
    {
        #region 参数初始化
        private int userid;//用户ID
        #endregion

        #region 窗体函数
        public frmChangeUserPasswd()
        {
            InitializeComponent();
        }
        private void frmChangeUserPasswd_Load(object sender, EventArgs e)
        {
            userid = Globals.UserID;
            txtUserLogin.Text = Globals.LoginUser;
        }
        /// <summary>
        /// 取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// 确认
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            SaveData();
        }
        #endregion

        #region 自定义函数
        /// <summary>
        /// 验证数据必填项
        /// </summary>
        /// <returns></returns>
        private bool ValidatorData()
        {
            if (this.txtUserLogin.Text.Trim() == "")
            {
                TXMessageBoxExtensions.Info(SystemTips.MSG_USERID_NOTNULL, SystemTips.MSG_TITLE);//用户ID不能为空
                this.txtUserLogin.Focus();
                return false;
            }
            if (this.txtOldPasswd.Text.Trim() == "")
            {
                TXMessageBoxExtensions.Info(SystemTips.MSG_USERPWD_NOTNULL, SystemTips.MSG_TITLE);//用户名不能为空
                this.txtOldPasswd.Focus();
                return false;
            }
            if (this.txtNewPasswd.Text.Trim() == "")
            {
                TXMessageBoxExtensions.Info("新密码不能为空", SystemTips.MSG_TITLE);//用户全名不能为空
                this.txtNewPasswd.Focus();
                return false;
            }
            if (this.txtNewPasswd.Text.Trim() != txtConfrmPasswd.Text.Trim())
            {
                TXMessageBoxExtensions.Info("确认密码与新密码不相符，请重新输入确认密码", SystemTips.MSG_TITLE);//请选择用户风格
                this.txtConfrmPasswd.Focus();
                return false;
            }
            BLL.T_Users_BLL bll1 = new ERM.BLL.T_Users_BLL();
            MDL.T_Users mdl1 = bll1.Find(Globals.UserID);
            if (HandlePwd.Decrypt(mdl1.password) != this.txtOldPasswd.Text.Trim())
            {
                TXMessageBoxExtensions.Info("原密码错误，不可以修改！", SystemTips.MSG_TITLE);//请选择用户风格
                this.txtConfrmPasswd.Focus();
                return false;
            }
            return true;
        }
        /// <summary>
        /// 保存数据
        /// </summary>
        private void SaveData()
        {
            if (!ValidatorData())
            {
                return;
            }
            else
            {
                string confrmpw = HandlePwd.Encrypt(txtConfrmPasswd.Text.Trim());
                BLL.T_Users_BLL userBLL = new ERM.BLL.T_Users_BLL();
                MDL.T_Users UsersMDL = userBLL.Find(Globals.UserID);
                UsersMDL.password = confrmpw;
                userBLL.Update(UsersMDL);
                this.Close();
            }
        }
        #endregion  

        private void btnConfirm_Click_1(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {

        }
    }
}
