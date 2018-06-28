using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using ERM.Common;
using System.Runtime.InteropServices;
using System.Diagnostics;
using Microsoft.Win32;
using TX.Framework.WindowUI.Forms;

namespace ERM.UI
{
    /// <summary>
    /// �û���¼����
    /// </summary>
    public partial class frmLogin: ERM.UI.Controls.Skin_DevEX
    {
        #region ��ʼ����Ϣ
        [DllImport("CellCtrl5.ocx")]
        public static extern int DllRegisterServer();//ע��ʱ��
        [DllImport("CellCtrl5.ocx")]
        public static extern int DllUnregisterServer();//ȡ��ע��ʱ��
        /// <summary>
        /// �û���Ϣ������
        /// </summary>
        ERM.BLL.T_Users_BLL UsersDB = new ERM.BLL.T_Users_BLL();
        #endregion

        #region ���庯��

        public frmLogin()
        {
            InitializeComponent();
            this.txtPasswd.Text = "admin";
            this.lbltitle1.Text = Properties.Settings.Default.lbl_t1;
            this.lbltitle2.Text = Properties.Settings.Default.lbl_t2;
            this.lbltitle3.Text = Properties.Settings.Default.lbl_t3;
        }

        /// <summary>
        /// ��¼�������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Login_Load(object sender, EventArgs e)
        {
            FillControls();
            //string versionFile = Application.StartupPath + "\\ERM_LangFang_Version.dat";
            try
            {
                System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
                string oldVersino = assembly.GetName().Version.ToString();//��exe�Զ�����
                lblVersion.Text = "�汾��" + oldVersino + " ";
                lblVersion.Visible = true;
            }
            catch { }         
        }
        /// <summary>
        /// ��¼ʱ�������¼�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (MyCommon.IsCheckFD())
            {
                #region KEY ��֤����
                //USBKey usbkey = new USBKey();
                //if (!usbkey.CheckUSB())
                //{
                //    TXMessageBoxExtensions.Info("UKeyУ��ʧ��,������������,�ٽ��в����� \n  ����ܰ��ʾ��������������������ϵ��0755-83995038��", "��Ϣ��ʾ",
                //        MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    return;
                //}
                string DoResult = ERM.UI.WriteDog.DoReader();
                if (DoResult != "")
                {
                    USBKey usbkey = new USBKey();
                    if (!usbkey.CheckUSB())
                    {
                        //if (!ERM.UI.FDKey.CheckUserKey())
                        //{
                        TXMessageBoxExtensions.Info("UKeyУ��ʧ��,������������,�ٽ��в����� \n  ����ܰ��ʾ��������������������ϵ��0755-83995038��", "��Ϣ��ʾ");
                        return;
                        //}
                    }
                }
                #endregion
            }
            if (cboLogin.SelectedValue == null || txtPasswd.Text == null ||
                cboLogin.SelectedValue.ToString().Trim() == "" ||
                txtPasswd.Text.Trim() == "")//����Ϊ�յĴ���
            {
                TXMessageBoxExtensions.Info("�û��������벻��Ϊ�գ����������룡");
                txtPasswd.Focus();
                return;
            }
            else//��֤����
            {
                int userid = Convert.ToInt32(this.cboLogin.SelectedValue.ToString());
                string pwd = this.txtPasswd.Text.Trim();
                int i111 = (new BLL.T_Users_BLL()).GetCount();
                MDL.T_Users users = (new BLL.T_Users_BLL()).Find(userid);
                if (pwd == HandlePwd.Decrypt(users.password))//����֮�� �����������
                {
                    Globals.UserID = userid;
                    Globals.SH = users.sh;
                    Globals.Theme = users.theme;
                    Globals.Password = users.password;//���ܵ����롡�û��޸������õ�
                    Globals.LoginUser = users.login;
                    Globals.Fullname = users.fullname;
                    Globals.CompanyTitle = users.units;
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    TXMessageBoxExtensions.Info("����������������룡");
                    txtPasswd.Text = "";
                    txtPasswd.Focus();
                    return;
                }
            }
        }
        /// <summary>
        /// �ر�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
        /// <summary>
        /// ����� �س��¼�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtPasswd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnOK_Click(e, null);
            }
        }
        #endregion

        #region �Զ��庯��
        /// <summary>
        /// ע�Ừ��ؼ�
        /// </summary>
        private void RegisterServer()
        {
            try
            {
                string system32Path = Environment.GetFolderPath(Environment.SpecialFolder.System);
                try
                {
                    if (!System.IO.File.Exists(system32Path + "\\CellCtrl5.ocx"))
                    {
                        System.IO.File.Copy(Application.StartupPath + "\\SystemFiles\\CellCtrl5.ocx", system32Path + "\\CellCtrl5.ocx", true);
                    }
                }
                catch { }

                if (true)
                {
                    //Dllû��ע�ᣬ���������DllRegisterServer()��
                    if (DllRegisterServer() >= 0)
                    {

                    }
                }
            }
            catch { }
        }
        /// <summary>
        /// ��ʼ���û�����ѡ��
        /// </summary>
        private void FillControls()
        {
            DataSet ds = UsersDB.GetList("");
            cboLogin.DisplayMember = "login";
            cboLogin.ValueMember = "userid";
            cboLogin.DataSource = ds.Tables[0].DefaultView;
        }

        private string GetSystemInfo()
        {
            OperatingSystem os = Environment.OSVersion;
            string SystemInfoText = null;
            switch (os.Platform)
            {
                case PlatformID.Win32Windows:
                    switch (os.Version.Minor)
                    {
                        case 0:
                            SystemInfoText = "Windows   95 ";
                            break;
                        case 10:
                            if (os.Version.Revision.ToString() == "2222A ")
                                SystemInfoText = "Windows   98   �ڶ��� ";
                            else
                                SystemInfoText = "Windows   98 ";
                            break;
                        case 90:
                            SystemInfoText = "Windows   Me ";
                            break;
                    }
                    break;
                case PlatformID.Win32NT:
                    switch (os.Version.Major)
                    {
                        case 3:
                            SystemInfoText = "Windows   NT   3.51 ";
                            break;
                        case 4:
                            SystemInfoText = "Windows   NT   4.0 ";
                            break;
                        case 5:
                            switch (os.Version.Minor)
                            {
                                case 0:
                                    SystemInfoText = "Windows   200 ";
                                    break;
                                case 1:
                                    SystemInfoText = "Windows   XP ";
                                    break;
                                case 2:
                                    SystemInfoText = "Windows   2003 ";
                                    break;
                            }
                            break;
                        case 6:
                            switch (os.Version.Minor)
                            {
                                case 0:
                                    SystemInfoText = "Windows  Vista ";
                                    break;
                                case 1:
                                    SystemInfoText = "Windows   7 ";
                                    break;
                            }
                            break;
                    }
                    break;
            }
            return SystemInfoText;
        }
        #endregion

        private void btnOK_Click_1(object sender, EventArgs e)
        {

        }

        private void btnOK_Click_2(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click_3(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {

        }

        private void btnOK_Click_4(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click_2(object sender, EventArgs e)
        {

        }

    }
}
