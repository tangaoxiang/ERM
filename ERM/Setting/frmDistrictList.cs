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
    public partial class frmDistrictList : ERM.UI.Controls.Skin_DevEX
    {
        ERM.BLL.District DistrictDB= new ERM.BLL.District();//user���ݿ������
        public frmDistrictList()
        {
            InitializeComponent();
        }
        private void frmDistrictList_Load(object sender, EventArgs e)
        {
            this.Text = "�����б�";
            BindGridViewData();
        }
        /// <summary>
        /// ���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsAdd_Click(object sender, EventArgs e)
        {
            frmDistrictDetail frm = new frmDistrictDetail();
            frm.OpType = "Add";//��������
            if (DialogResult.OK == frm.ShowDialog())
            {
                BindGridViewData();//���°�����
            }
        }
        /// <summary>
        /// ɾ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsDelete_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection rows = this.dgDistrict.SelectedRows;
            if (rows.Count == 0)
            {
                return;
            }
            else
            {   //ѯ���Ƿ�ɾ��
                if (TXMessageBoxExtensions.Question("ȷʵҪɾ��������¼��") == DialogResult.Cancel)
                {
                    return;
                }
                else//ȷ��ɾ��
                {
                    int id = Convert.ToInt16(rows[0].Cells["DistrictID"].Value.ToString());
                    DistrictDB.Delete(id);//ɾ��
                    BindGridViewData();//���°�����
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
       /// �༭
       /// </summary>
       /// <param name="sender"></param>
       /// <param name="e"></param>
        private void tsEdit_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection rows = this.dgDistrict.SelectedRows;
            if (rows.Count == 0)
            {
                return;
            }
            else
            {
                frmDistrictDetail frm = new frmDistrictDetail();
                frm.OpType = "Edit";//��������
                int id = Convert.ToInt16(rows[0].Cells["DistrictID"].Value.ToString());//Ҫ�༭������
                frm.DistrictID = id;//����ֵ
                if (DialogResult.OK == frm.ShowDialog())
                {
                    BindGridViewData();//���°�����
                }
            }
        }
        /// <summary>
        /// ˫���¼�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgDistrict_DoubleClick(object sender, EventArgs e)
        {
            tsEdit_Click(null, null);
        }
        /// <summary>
        /// �����б���ʽ
        /// </summary>
        private void SetGridStyle()
        {
            this.dgDistrict.Columns["DistrictID"].HeaderText = "DistrictID";
            this.dgDistrict.Columns["DistrictName"].HeaderText = "��������";
            this.dgDistrict.Columns["OrderIndex"].HeaderText = "˳��";
            this.dgDistrict.Columns["TempID"].HeaderText = "TempID";
            this.dgDistrict.Columns["DistrictID"].Visible = false;
            this.dgDistrict.Columns["TempID"].Visible = false;
            this.dgDistrict.Columns["DistrictName"].Width = 200;
            this.dgDistrict.Columns["OrderIndex"].Width = 100;
        }
        /// <summary>
        /// ��GridViewData������
        /// </summary>
        private void BindGridViewData()
        {
            DataView dv = DistrictDB.GetList("1=1").Tables[0].DefaultView;//������
            dv.Sort = "OrderIndex";
            this.dgDistrict.DataSource = dv;
            SetGridStyle(); //������ʽ
        }
    }
}
