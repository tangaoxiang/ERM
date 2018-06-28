/*********************************
 * 作者　　张建宏
 * 日期　　2008-12-10
 * 功能　　案卷列表界面
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
        ERM.CBLL.PageSize PageSizeDB = new ERM.CBLL.PageSize();//user数据库操作类
        public frmPageSizeList()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmPageSizeList_Load(object sender, EventArgs e)
        {
            this.Text = "案卷盒设置列表";
            BindGridViewData(true);
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsAdd_Click(object sender, EventArgs e)
        {
            frmPageSizeDetail frm = new frmPageSizeDetail(null);
            frm.Text = "新增";
            if (DialogResult.OK == frm.ShowDialog())
            {
                BindGridViewData(false);//重新绑定数据
            }
        }
        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsEdit_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection rows = this.dgPageSize.SelectedRows;
            if (rows.Count == 0)
            {
                TXMessageBoxExtensions.Info("至少要选择一行记录才能够操作！");
                return;
            }
            else
            {
                int id = Convert.ToInt16(rows[0].Cells["PID"].Value.ToString());//要编辑的主键
                frmPageSizeDetail frm = new frmPageSizeDetail(id);
                frm.Text = "修改";
                if (DialogResult.OK == frm.ShowDialog())
                {
                    BindGridViewData(false);//重新绑定数据
                }
            }
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsDelete_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection rows = this.dgPageSize.SelectedRows;
            if (rows.Count == 0)
            {
                TXMessageBoxExtensions.Info("至少要选择一行记录才能够操作！");
                return;
            }
            else
            {   //询问是否删除
                if (TXMessageBoxExtensions.Question("确定要删除记录吗 ？") == DialogResult.Cancel)
                {
                    return;
                }
                else//确定删除
                {
                    //if (rows[0].Cells["isdefault"].Value.ToString() == "1")
                    //{
                    //    TXMessageBoxExtensions.Info("必须先设置一个默认！");
                    //    return;
                    //}
                    ERM.BLL.PageSize bll_pagesiz = new ERM.BLL.PageSize();
                    DataSet ds = bll_pagesiz.GetAllList();
                    if (ds != null && ds.Tables.Count > 0 &&
                        ds.Tables[0] != null && ds.Tables[0].Rows.Count > 1)
                    {
                        int id = Convert.ToInt16(rows[0].Cells["PID"].Value.ToString());
                        bll_pagesiz.Delete(id);//删除
                        BindGridViewData(false);//重新绑定数据
                    }
                    else
                    {
                        TXMessageBoxExtensions.Info("提示：至少需要保留一条记录信息！");
                    }
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
        /// 设置列表样式
        /// </summary>
        private void SetGridStyle()
        {
            this.dgPageSize.Columns["PID"].HeaderText = "PID";
            this.dgPageSize.Columns["PTYPE"].HeaderText = "卷册类别";
            this.dgPageSize.Columns["Pages"].HeaderText = "页数稳定值";
            this.dgPageSize.Columns["Pfloat"].HeaderText = "页数浮动值";
            this.dgPageSize.Columns["IsDefault"].HeaderText = "是否默认";
            this.dgPageSize.Columns["C_IsDefault"].HeaderText = "是否默认";
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
        /// 向GridViewData绑定数据
        /// </summary>
        private void BindGridViewData(bool bindStyle)
        {
            DataSet ds = PageSizeDB.GetList();//绑定数据
            ds.Tables[0].Columns.Add("C_IsDefault", typeof(string));
            if (ds.Tables.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    if (ds.Tables[0].Rows[i]["IsDefault"].ToString() == "1")
                    {
                        ds.Tables[0].Rows[i]["C_IsDefault"] = "是";
                    }
                    else
                    {
                        ds.Tables[0].Rows[i]["C_IsDefault"] = "否";
                    }
                }
            }
            this.dgPageSize.DataSource = ds.Tables[0];
            if (bindStyle)
                SetGridStyle(); //设置样式
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
