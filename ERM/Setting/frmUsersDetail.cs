/*********************************
 * ���ߡ����Ž���
 * ���ڡ���2008-12-09
 * ���ܡ����û���Ϣ��ӱ༭����
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
        //ERM.MDL.T_Users users = new ERM.MDL.T_Users();//userʵ���� 
        //ERM.BLL.T_Users_BLL usersDB = new ERM.BLL.T_Users_BLL();//user���ݿ������
        private string optype;
        public string OpType
        {
            get { return this.optype; }
            set { this.optype = value; }
        }
        /// <summary>
        /// �û�ID����
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
        /// ��������¼�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmUsersDetail_Load(object sender, EventArgs e)
        {
            if (this.OpType == "Add")
            {
                this.Text = "����û���Ϣ";
                this.cmbUnits.Text = Globals.CompanyTitle;
                cmbUnitsType.SelectedIndex = 0;
            }
            else
            {
                this.Text = "�༭�û���Ϣ";
                SetData();
            }
            txtLogin.Focus();
        }
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            SaveData();
        }
        /// <summary>
        /// ��������
        /// </summary>
        private void  SaveData()
        {
            if (!ValidatorData())
            {
                return;
            }
            
            if (this.OpType == "Add")//���
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
                    TXMessageBoxExtensions.Info("�û����Ѿ����ڣ�");
                    this.txtLogin.Focus();
                    return ;
                }
            }
            else//�༭
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
        /// ���ؼ���ֵ
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
       /// ���Model
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
        /// ��֤���ݱ�����
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
                        TXMessageBoxExtensions.Info("�뽫������Ϣ��д������");
                        c.Focus();
                        return false;
                    }
                }
            }
            if(txtpasswd.Text!=txtpasswd2.Text)
            {
                TXMessageBoxExtensions.Info("�����������벻һ�£�");
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
