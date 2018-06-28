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
    /// 用户登录窗体
    /// </summary>
    public partial class frmLogin: ERM.UI.Controls.Skin_DevEX
    {
        #region 初始化信息
        [DllImport("CellCtrl5.ocx")]
        public static extern int DllRegisterServer();//注册时用
        [DllImport("CellCtrl5.ocx")]
        public static extern int DllUnregisterServer();//取消注册时用
        /// <summary>
        /// 用户信息操作类
        /// </summary>
        ERM.BLL.T_Users_BLL UsersDB = new ERM.BLL.T_Users_BLL();
        #endregion

        #region 窗体函数

        public frmLogin()
        {
            InitializeComponent();
            this.txtPasswd.Text = "admin";
            this.lbltitle1.Text = Properties.Settings.Default.lbl_t1;
            this.lbltitle2.Text = Properties.Settings.Default.lbl_t2;
            this.lbltitle3.Text = Properties.Settings.Default.lbl_t3;
        }

        /// <summary>
        /// 登录窗体加载
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
                string oldVersino = assembly.GetName().Version.ToString();//随exe自动更新
                lblVersion.Text = "版本：" + oldVersino + " ";
                lblVersion.Visible = true;
            }
            catch { }         
        }
        /// <summary>
        /// 登录时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (MyCommon.IsCheckFD())
            {
                #region KEY 验证操作
                //USBKey usbkey = new USBKey();
                //if (!usbkey.CheckUSB())
                //{
                //    TXMessageBoxExtensions.Info("UKey校验失败,请插入加密锁后,再进行操作！ \n  【温馨提示：如有疑问请与我们联系，0755-83995038】", "信息提示",
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
                        TXMessageBoxExtensions.Info("UKey校验失败,请插入加密锁后,再进行操作！ \n  【温馨提示：如有疑问请与我们联系，0755-83995038】", "信息提示");
                        return;
                        //}
                    }
                }
                #endregion
            }
            if (cboLogin.SelectedValue == null || txtPasswd.Text == null ||
                cboLogin.SelectedValue.ToString().Trim() == "" ||
                txtPasswd.Text.Trim() == "")//不能为空的处理
            {
                TXMessageBoxExtensions.Info("用户名或密码不能为空，请重新输入！");
                txtPasswd.Focus();
                return;
            }
            else//验证密码
            {
                int userid = Convert.ToInt32(this.cboLogin.SelectedValue.ToString());
                string pwd = this.txtPasswd.Text.Trim();
                int i111 = (new BLL.T_Users_BLL()).GetCount();
                MDL.T_Users users = (new BLL.T_Users_BLL()).Find(userid);
                if (pwd == HandlePwd.Decrypt(users.password))//解密之后 进行密码较验
                {
                    Globals.UserID = userid;
                    Globals.SH = users.sh;
                    Globals.Theme = users.theme;
                    Globals.Password = users.password;//加密的密码　用户修改密码用到
                    Globals.LoginUser = users.login;
                    Globals.Fullname = users.fullname;
                    Globals.CompanyTitle = users.units;
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    TXMessageBoxExtensions.Info("密码错误，请重新输入！");
                    txtPasswd.Text = "";
                    txtPasswd.Focus();
                    return;
                }
            }
        }
        /// <summary>
        /// 关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
        /// <summary>
        /// 密码框 回车事件
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

        #region 自定义函数
        /// <summary>
        /// 注册华表控件
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
                    //Dll没有注册，在这里调用DllRegisterServer()吧
                    if (DllRegisterServer() >= 0)
                    {

                    }
                }
            }
            catch { }
        }
        /// <summary>
        /// 初始化用户下拉选单
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
                                SystemInfoText = "Windows   98   第二版 ";
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
