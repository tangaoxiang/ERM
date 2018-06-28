/*********************************
 * 作者　　张建宏
 * 日期　　2008-12-09
 * 功能　　用户信息列表界面
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
namespace ERM.UI
{
    public partial class frmUsersList : ERM.UI.Controls.Skin_DevEX
    {
        ERM.BLL.T_Users_BLL usersDB = new ERM.BLL.T_Users_BLL();//user数据库操作类
        public frmUsersList()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 窗体列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmUsersList_Load(object sender, EventArgs e)
        {
            this.Text = "用户列表";
            BindGridViewData();//绑定数据
        }
        /// <summary>
        /// 添加事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsAdd_Click(object sender, EventArgs e)
        {
            frmUsersDetail frm = new frmUsersDetail();
            frm.OpType = "Add";//操作类型
            if (DialogResult.OK == frm.ShowDialog())
            {
                BindGridViewData();//重新绑定数据
            }
        }
        /// <summary>
        /// 编辑事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsEdit_Click(object sender, EventArgs e)
        {
             DataGridViewSelectedRowCollection rows = this.dgUsers.SelectedRows;
             if (rows.Count == 0)
             {
                 TXMessageBoxExtensions.Info(SystemTips.MSG_ATLAST_SELECTROW_OP, SystemTips.MSG_TITLE);//至少要选择一行记录才能够操作
                 return;
             }
             else
             {
                 frmUsersDetail frm = new frmUsersDetail();
                 frm.OpType = "Edit";//操作类型
                 int id = Convert.ToInt16(rows[0].Cells["userid"].Value.ToString());//要编辑的主键
                 frm.UserId = id;//主键值
                 if (DialogResult.OK == frm.ShowDialog())
                 {
                     BindGridViewData();//重新绑定数据
                 }
             }
         }
         /// <summary>
        /// 删除事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsDelete_Click(object sender, EventArgs e)
        {
                DataGridViewSelectedRowCollection rows = this.dgUsers.SelectedRows;
                if (rows.Count == 0)
                {
                    TXMessageBoxExtensions.Info(SystemTips.MSG_ATLAST_SELECTROW_OP, SystemTips.MSG_TITLE);//至少要选择一行记录才能够操作
                    return;
                }
                else
                {   //询问是否删除
                    if (TXMessageBoxExtensions.Question("确定要删除吗？") == DialogResult.Cancel)
                    {
                        return;
                    }
                    else//确定删除
                    {
                        int id  = Convert.ToInt16(rows[0].Cells["userid"].Value.ToString());
                        if (id == Globals.UserID)
                        {
                            TXMessageBoxExtensions.Info("不能删除已登陆的用户！");
                            return;
                        }
                        usersDB.Delete(id);//删除
                        BindGridViewData();//重新绑定数据
                    } 
                }
            }
            /// <summary>
        /// 关闭事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// 双击事件进入编辑
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgUsers_DoubleClick(object sender, EventArgs e)
        {
            tsEdit_Click(null, null);//进入编辑事件
        }
        /// <summary>
        /// 设置列表样式
        /// </summary>
        private void SetGridStyle()
        {
            this.dgUsers.Columns["userid"].HeaderText = "userid";
            this.dgUsers.Columns["login"].HeaderText = "用户名";
            this.dgUsers.Columns["fullname"].HeaderText = "用户姓名";
            this.dgUsers.Columns["title"].HeaderText = "用户职称";
            this.dgUsers.Columns["phone"].HeaderText = "用户电话";
            this.dgUsers.Columns["sh"].HeaderText = "提交权限";
            this.dgUsers.Columns["Units"].HeaderText = "所在单位";
            this.dgUsers.Columns["UnitsType"].HeaderText = "所在单位类型";
            this.dgUsers.Columns["password"].HeaderText = "用户密码";
            this.dgUsers.Columns["theme"].HeaderText = "系统样式";
            this.dgUsers.Columns["C_sh"].HeaderText = "是否提交权限";
            this.dgUsers.Columns["userid"].Visible = false;
            this.dgUsers.Columns["password"].Visible = false;
            this.dgUsers.Columns["theme"].Visible = false;
            this.dgUsers.Columns["sh"].Visible = false;
            this.dgUsers.Columns["userid"].Width = 100;
            this.dgUsers.Columns["login"].Width = 100;
            this.dgUsers.Columns["fullname"].Width = 100;
            this.dgUsers.Columns["title"].Width = 100;
            this.dgUsers.Columns["phone"].Width = 100;
            this.dgUsers.Columns["sh"].Width = 100;
            this.dgUsers.Columns["Units"].Width = 200;
            this.dgUsers.Columns["UnitsType"].Width = 200;
            this.dgUsers.Columns["C_sh"].Width = 150;
            this.dgUsers.Columns["password"].HeaderText = "用户密码";
            this.dgUsers.Columns["theme"].HeaderText = "系统样式";
        }
        /// <summary>
        /// 向GridViewData绑定数据
        /// </summary>
        private void BindGridViewData()
        {
            DataSet ds = usersDB.GetList("1=1");//绑定数据
            ds.Tables[0].Columns.Add("C_sh", typeof(string));
            if (ds.Tables.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    if (ds.Tables[0].Rows[i]["sh"].ToString() == "1")
                    {
                        ds.Tables[0].Rows[i]["C_sh"] = "是";
                    }
                    else
                    {
                        ds.Tables[0].Rows[i]["C_sh"] = "否";
                    }
                }
            }
            this.dgUsers.DataSource = ds.Tables[0];
            SetGridStyle(); //设置样式
        }

        private void dgUsers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
