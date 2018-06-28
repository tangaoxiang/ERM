/*********************************
 * 作者　　张建宏
 * 日期　　2008-12-09
 * 功能　　用户信息添加编辑界面
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
using ERM.MDL;
using TX.Framework.WindowUI.Forms;
using TX.Framework.WindowUI.Controls;
namespace ERM.UI
{
    public partial class frmUsersDetail : ERM.UI.Controls.Skin_DevEX
    {
        //ERM.MDL.T_Users users = new ERM.MDL.T_Users();//user实体类 
        //ERM.BLL.T_Users_BLL usersDB = new ERM.BLL.T_Users_BLL();//user数据库操作类
        private string optype;
        public string OpType
        {
            get { return this.optype; }
            set { this.optype = value; }
        }
        /// <summary>
        /// 用户ID主键
        /// </summary>
        private int userid;
        public int UserId
        {
            set { this.userid = value; }
            get { return this.userid; }
        }
        public frmUsersDetail()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 窗体加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmUsersDetail_Load(object sender, EventArgs e)
        {
            if (this.OpType == "Add")
            {
                this.Text = "添加用户信息";
                this.cmbUnits.Text = Globals.CompanyTitle;
                cmbUnitsType.SelectedIndex = 0;
            }
            else
            {
                this.Text = "编辑用户信息";
                SetData();
            }
            txtLogin.Focus();
        }
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            SaveData();
        }
        /// <summary>
        /// 保存数据
        /// </summary>
        private void  SaveData()
        {
            if (!ValidatorData())
            {
                return;
            }
            
            if (this.OpType == "Add")//添加
            {
                BLL.T_Users_BLL userBLL = new T_Users_BLL();
                IList<MDL.T_Users> userList = userBLL.FindBylogin(txtLogin.Text);
                if (userList.Count<=0)
                {
                    MDL.T_Users userMDL = GetData();                    
                    userBLL.Add(userMDL);
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    TXMessageBoxExtensions.Info("用户名已经存在！");
                    this.txtLogin.Focus();
                    return ;
                }
            }
            else//编辑
            {
                MDL.T_Users userMDL = GetData();
                userMDL.userid = userid;
                BLL.T_Users_BLL userBLL = new T_Users_BLL();
                userBLL.Update(userMDL);                
                this.DialogResult = DialogResult.OK;
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// 给控件赋值
        /// </summary>
        private void SetData()
        {
            BLL.T_Users_BLL userBLL = new T_Users_BLL();
            MDL.T_Users users = userBLL.Find(this.userid);
            this.txtLogin.Text=users.login ;
            this.txtpasswd.Text = HandlePwd.Decrypt(users.password);
            this.txtpasswd2.Text = HandlePwd.Decrypt(users.password);
            this.txtFullname.Text = users.fullname;
            this.txtTitle.Text = users.title;
            this.txtphone.Text = users.phone;
            this.cmbUnits.Text = users.units;
            this.cmbUnitsType.Text = users.unitstype;            
        }
        /// <summary>
       /// 填充Model
       /// </summary>
        private MDL.T_Users GetData()
        {
            MDL.T_Users users = new T_Users();
            users.login = MyCommon.ToSqlString( this.txtLogin.Text.Trim());
            users.password = HandlePwd.Encrypt(this.txtpasswd.Text.Trim());
            users.fullname =MyCommon.ToSqlString(  this.txtFullname.Text.Trim());
            users.title =MyCommon.ToSqlString(  this.txtTitle.Text.Trim());
            users.phone =MyCommon.ToSqlString(  this.txtphone.Text.Trim());    
            users.units =MyCommon.ToSqlString(  this.cmbUnits.Text.Trim());
            users.unitstype = MyCommon.ToSqlString(  this.cmbUnitsType.Text.Trim());            
            return users;
        }
        /// <summary>
        /// 验证数据必填项
        /// </summary>
        /// <returns></returns>
        private bool  ValidatorData()
        {
            foreach (Control c in this.Controls)
            {
                if (c.GetType() == typeof(ComboBox) || c.GetType() == typeof(TextBox))
                {
                    if (c.Text.Trim() == "")
                    {
                        TXMessageBoxExtensions.Info("请将各项信息填写完整！");
                        c.Focus();
                        return false;
                    }
                }
            }
            if(txtpasswd.Text!=txtpasswd2.Text)
            {
                TXMessageBoxExtensions.Info("两次输入密码不一致！");
                txtpasswd2.Focus();
                return false;
            }
            return true;
        }

        private void txtTitle_Load(object sender, EventArgs e)
        {

        }

        private void btnConfirm_Click_1(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {

        }
    }
}
