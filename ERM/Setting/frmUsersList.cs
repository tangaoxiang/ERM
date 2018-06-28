/*********************************
 * ���ߡ����Ž���
 * ���ڡ���2008-12-09
 * ���ܡ����û���Ϣ�б����
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
        ERM.BLL.T_Users_BLL usersDB = new ERM.BLL.T_Users_BLL();//user���ݿ������
        public frmUsersList()
        {
            InitializeComponent();
        }
        /// <summary>
        /// �����б�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmUsersList_Load(object sender, EventArgs e)
        {
            this.Text = "�û��б�";
            BindGridViewData();//������
        }
        /// <summary>
        /// ����¼�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsAdd_Click(object sender, EventArgs e)
        {
            frmUsersDetail frm = new frmUsersDetail();
            frm.OpType = "Add";//��������
            if (DialogResult.OK == frm.ShowDialog())
            {
                BindGridViewData();//���°�����
            }
        }
        /// <summary>
        /// �༭�¼�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsEdit_Click(object sender, EventArgs e)
        {
             DataGridViewSelectedRowCollection rows = this.dgUsers.SelectedRows;
             if (rows.Count == 0)
             {
                 TXMessageBoxExtensions.Info(SystemTips.MSG_ATLAST_SELECTROW_OP, SystemTips.MSG_TITLE);//����Ҫѡ��һ�м�¼���ܹ�����
                 return;
             }
             else
             {
                 frmUsersDetail frm = new frmUsersDetail();
                 frm.OpType = "Edit";//��������
                 int id = Convert.ToInt16(rows[0].Cells["userid"].Value.ToString());//Ҫ�༭������
                 frm.UserId = id;//����ֵ
                 if (DialogResult.OK == frm.ShowDialog())
                 {
                     BindGridViewData();//���°�����
                 }
             }
         }
         /// <summary>
        /// ɾ���¼�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsDelete_Click(object sender, EventArgs e)
        {
                DataGridViewSelectedRowCollection rows = this.dgUsers.SelectedRows;
                if (rows.Count == 0)
                {
                    TXMessageBoxExtensions.Info(SystemTips.MSG_ATLAST_SELECTROW_OP, SystemTips.MSG_TITLE);//����Ҫѡ��һ�м�¼���ܹ�����
                    return;
                }
                else
                {   //ѯ���Ƿ�ɾ��
                    if (TXMessageBoxExtensions.Question("ȷ��Ҫɾ����") == DialogResult.Cancel)
                    {
                        return;
                    }
                    else//ȷ��ɾ��
                    {
                        int id  = Convert.ToInt16(rows[0].Cells["userid"].Value.ToString());
                        if (id == Globals.UserID)
                        {
                            TXMessageBoxExtensions.Info("����ɾ���ѵ�½���û���");
                            return;
                        }
                        usersDB.Delete(id);//ɾ��
                        BindGridViewData();//���°�����
                    } 
                }
            }
            /// <summary>
        /// �ر��¼�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// ˫���¼�����༭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgUsers_DoubleClick(object sender, EventArgs e)
        {
            tsEdit_Click(null, null);//����༭�¼�
        }
        /// <summary>
        /// �����б���ʽ
        /// </summary>
        private void SetGridStyle()
        {
            this.dgUsers.Columns["userid"].HeaderText = "userid";
            this.dgUsers.Columns["login"].HeaderText = "�û���";
            this.dgUsers.Columns["fullname"].HeaderText = "�û�����";
            this.dgUsers.Columns["title"].HeaderText = "�û�ְ��";
            this.dgUsers.Columns["phone"].HeaderText = "�û��绰";
            this.dgUsers.Columns["sh"].HeaderText = "�ύȨ��";
            this.dgUsers.Columns["Units"].HeaderText = "���ڵ�λ";
            this.dgUsers.Columns["UnitsType"].HeaderText = "���ڵ�λ����";
            this.dgUsers.Columns["password"].HeaderText = "�û�����";
            this.dgUsers.Columns["theme"].HeaderText = "ϵͳ��ʽ";
            this.dgUsers.Columns["C_sh"].HeaderText = "�Ƿ��ύȨ��";
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
            this.dgUsers.Columns["password"].HeaderText = "�û�����";
            this.dgUsers.Columns["theme"].HeaderText = "ϵͳ��ʽ";
        }
        /// <summary>
        /// ��GridViewData������
        /// </summary>
        private void BindGridViewData()
        {
            DataSet ds = usersDB.GetList("1=1");//������
            ds.Tables[0].Columns.Add("C_sh", typeof(string));
            if (ds.Tables.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    if (ds.Tables[0].Rows[i]["sh"].ToString() == "1")
                    {
                        ds.Tables[0].Rows[i]["C_sh"] = "��";
                    }
                    else
                    {
                        ds.Tables[0].Rows[i]["C_sh"] = "��";
                    }
                }
            }
            this.dgUsers.DataSource = ds.Tables[0];
            SetGridStyle(); //������ʽ
        }

        private void dgUsers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
