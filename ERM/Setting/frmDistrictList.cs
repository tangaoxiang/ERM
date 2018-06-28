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
        ERM.BLL.District DistrictDB= new ERM.BLL.District();//user数据库操作类
        public frmDistrictList()
        {
            InitializeComponent();
        }
        private void frmDistrictList_Load(object sender, EventArgs e)
        {
            this.Text = "区域列表";
            BindGridViewData();
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsAdd_Click(object sender, EventArgs e)
        {
            frmDistrictDetail frm = new frmDistrictDetail();
            frm.OpType = "Add";//操作类型
            if (DialogResult.OK == frm.ShowDialog())
            {
                BindGridViewData();//重新绑定数据
            }
        }
        /// <summary>
        /// 删除
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
            {   //询问是否删除
                if (TXMessageBoxExtensions.Question("确实要删除该条记录吗？") == DialogResult.Cancel)
                {
                    return;
                }
                else//确定删除
                {
                    int id = Convert.ToInt16(rows[0].Cells["DistrictID"].Value.ToString());
                    DistrictDB.Delete(id);//删除
                    BindGridViewData();//重新绑定数据
                }
            }
        }
       /// <summary>
       /// 关闭
       /// </summary>
       /// <param name="sender"></param>
       /// <param name="e"></param>
        private void tsClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
       /// <summary>
       /// 编辑
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
                frm.OpType = "Edit";//操作类型
                int id = Convert.ToInt16(rows[0].Cells["DistrictID"].Value.ToString());//要编辑的主键
                frm.DistrictID = id;//主键值
                if (DialogResult.OK == frm.ShowDialog())
                {
                    BindGridViewData();//重新绑定数据
                }
            }
        }
        /// <summary>
        /// 双击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgDistrict_DoubleClick(object sender, EventArgs e)
        {
            tsEdit_Click(null, null);
        }
        /// <summary>
        /// 设置列表样式
        /// </summary>
        private void SetGridStyle()
        {
            this.dgDistrict.Columns["DistrictID"].HeaderText = "DistrictID";
            this.dgDistrict.Columns["DistrictName"].HeaderText = "区域名称";
            this.dgDistrict.Columns["OrderIndex"].HeaderText = "顺序";
            this.dgDistrict.Columns["TempID"].HeaderText = "TempID";
            this.dgDistrict.Columns["DistrictID"].Visible = false;
            this.dgDistrict.Columns["TempID"].Visible = false;
            this.dgDistrict.Columns["DistrictName"].Width = 200;
            this.dgDistrict.Columns["OrderIndex"].Width = 100;
        }
        /// <summary>
        /// 向GridViewData绑定数据
        /// </summary>
        private void BindGridViewData()
        {
            DataView dv = DistrictDB.GetList("1=1").Tables[0].DefaultView;//绑定数据
            dv.Sort = "OrderIndex";
            this.dgDistrict.DataSource = dv;
            SetGridStyle(); //设置样式
        }
    }
}
