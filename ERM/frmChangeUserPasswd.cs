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
    /// �޸�����
    /// </summary>
    public partial class frmChangeUserPasswd :  Skin_DevEX
    {
        #region ������ʼ��
        private int userid;//�û�ID
        #endregion

        #region ���庯��
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
        /// ȡ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// ȷ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            SaveData();
        }
        #endregion

        #region �Զ��庯��
        /// <summary>
        /// ��֤���ݱ�����
        /// </summary>
        /// <returns></returns>
        private bool ValidatorData()
        {
            if (this.txtUserLogin.Text.Trim() == "")
            {
                TXMessageBoxExtensions.Info(SystemTips.MSG_USERID_NOTNULL, SystemTips.MSG_TITLE);//�û�ID����Ϊ��
                this.txtUserLogin.Focus();
                return false;
            }
            if (this.txtOldPasswd.Text.Trim() == "")
            {
                TXMessageBoxExtensions.Info(SystemTips.MSG_USERPWD_NOTNULL, SystemTips.MSG_TITLE);//�û�������Ϊ��
                this.txtOldPasswd.Focus();
                return false;
            }
            if (this.txtNewPasswd.Text.Trim() == "")
            {
                TXMessageBoxExtensions.Info("�����벻��Ϊ��", SystemTips.MSG_TITLE);//�û�ȫ������Ϊ��
                this.txtNewPasswd.Focus();
                return false;
            }
            if (this.txtNewPasswd.Text.Trim() != txtConfrmPasswd.Text.Trim())
            {
                TXMessageBoxExtensions.Info("ȷ�������������벻���������������ȷ������", SystemTips.MSG_TITLE);//��ѡ���û����
                this.txtConfrmPasswd.Focus();
                return false;
            }
            BLL.T_Users_BLL bll1 = new ERM.BLL.T_Users_BLL();
            MDL.T_Users mdl1 = bll1.Find(Globals.UserID);
            if (HandlePwd.Decrypt(mdl1.password) != this.txtOldPasswd.Text.Trim())
            {
                TXMessageBoxExtensions.Info("ԭ������󣬲������޸ģ�", SystemTips.MSG_TITLE);//��ѡ���û����
                this.txtConfrmPasswd.Focus();
                return false;
            }
            return true;
        }
        /// <summary>
        /// ��������
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
