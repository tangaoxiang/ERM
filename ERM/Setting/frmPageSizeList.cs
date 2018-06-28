/*********************************
 * ���ߡ����Ž���
 * ���ڡ���2008-12-10
 * ���ܡ��������б����
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
    public partial class frmPageSizeList : ERM.UI.Controls.Skin_DevEX
    {
        ERM.CBLL.PageSize PageSizeDB = new ERM.CBLL.PageSize();//user���ݿ������
        public frmPageSizeList()
        {
            InitializeComponent();
        }
        /// <summary>
        /// �������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmPageSizeList_Load(object sender, EventArgs e)
        {
            this.Text = "����������б�";
            BindGridViewData(true);
        }
        /// <summary>
        /// ���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsAdd_Click(object sender, EventArgs e)
        {
            frmPageSizeDetail frm = new frmPageSizeDetail(null);
            frm.Text = "����";
            if (DialogResult.OK == frm.ShowDialog())
            {
                BindGridViewData(false);//���°�����
            }
        }
        /// <summary>
        /// �༭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsEdit_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection rows = this.dgPageSize.SelectedRows;
            if (rows.Count == 0)
            {
                TXMessageBoxExtensions.Info("����Ҫѡ��һ�м�¼���ܹ�������");
                return;
            }
            else
            {
                int id = Convert.ToInt16(rows[0].Cells["PID"].Value.ToString());//Ҫ�༭������
                frmPageSizeDetail frm = new frmPageSizeDetail(id);
                frm.Text = "�޸�";
                if (DialogResult.OK == frm.ShowDialog())
                {
                    BindGridViewData(false);//���°�����
                }
            }
        }
        /// <summary>
        /// ɾ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsDelete_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection rows = this.dgPageSize.SelectedRows;
            if (rows.Count == 0)
            {
                TXMessageBoxExtensions.Info("����Ҫѡ��һ�м�¼���ܹ�������");
                return;
            }
            else
            {   //ѯ���Ƿ�ɾ��
                if (TXMessageBoxExtensions.Question("ȷ��Ҫɾ����¼�� ��") == DialogResult.Cancel)
                {
                    return;
                }
                else//ȷ��ɾ��
                {
                    //if (rows[0].Cells["isdefault"].Value.ToString() == "1")
                    //{
                    //    TXMessageBoxExtensions.Info("����������һ��Ĭ�ϣ�");
                    //    return;
                    //}
                    ERM.BLL.PageSize bll_pagesiz = new ERM.BLL.PageSize();
                    DataSet ds = bll_pagesiz.GetAllList();
                    if (ds != null && ds.Tables.Count > 0 &&
                        ds.Tables[0] != null && ds.Tables[0].Rows.Count > 1)
                    {
                        int id = Convert.ToInt16(rows[0].Cells["PID"].Value.ToString());
                        bll_pagesiz.Delete(id);//ɾ��
                        BindGridViewData(false);//���°�����
                    }
                    else
                    {
                        TXMessageBoxExtensions.Info("��ʾ��������Ҫ����һ����¼��Ϣ��");
                    }
                }
            }
        }
        /// <summary>
        /// �ر�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// �����б���ʽ
        /// </summary>
        private void SetGridStyle()
        {
            this.dgPageSize.Columns["PID"].HeaderText = "PID";
            this.dgPageSize.Columns["PTYPE"].HeaderText = "������";
            this.dgPageSize.Columns["Pages"].HeaderText = "ҳ���ȶ�ֵ";
            this.dgPageSize.Columns["Pfloat"].HeaderText = "ҳ������ֵ";
            this.dgPageSize.Columns["IsDefault"].HeaderText = "�Ƿ�Ĭ��";
            this.dgPageSize.Columns["C_IsDefault"].HeaderText = "�Ƿ�Ĭ��";
            this.dgPageSize.Columns["PID"].Visible = false;
            this.dgPageSize.Columns["IsDefault"].Visible = false;
            this.dgPageSize.Columns["PID"].Width = 100;
            this.dgPageSize.Columns["PTYPE"].Width = 100;
            this.dgPageSize.Columns["Pages"].Width = 100;
            this.dgPageSize.Columns["Pfloat"].Width = 100;
            this.dgPageSize.Columns["IsDefault"].Width = 100;
            this.dgPageSize.Columns["C_IsDefault"].Width = 100;
        }
        /// <summary>
        /// ��GridViewData������
        /// </summary>
        private void BindGridViewData(bool bindStyle)
        {
            DataSet ds = PageSizeDB.GetList();//������
            ds.Tables[0].Columns.Add("C_IsDefault", typeof(string));
            if (ds.Tables.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    if (ds.Tables[0].Rows[i]["IsDefault"].ToString() == "1")
                    {
                        ds.Tables[0].Rows[i]["C_IsDefault"] = "��";
                    }
                    else
                    {
                        ds.Tables[0].Rows[i]["C_IsDefault"] = "��";
                    }
                }
            }
            this.dgPageSize.DataSource = ds.Tables[0];
            if (bindStyle)
                SetGridStyle(); //������ʽ
        }
        private void dgPageSize_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            else
            {
                tsEdit_Click(null, null);
            }
        }
    }
}
