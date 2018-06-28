using ERM.UI.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ERM.BLL;
using ERM.MDL;
using ERM.UI.Setting;
using TX.Framework.WindowUI.Forms;

namespace ERM.UI
{
    public partial class frmGdmlList : Skin_DevEX
    {
        T_GdListTemplate fileTemp = new T_GdListTemplate();
        T_GdListTemplate_BLL templateBLL = new T_GdListTemplate_BLL();

        public frmGdmlList()
        {
            InitializeComponent();
            BindFileType();
            DataBind();
            Search();
        }

        private void skin_DataGridEX1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        /// <summary>
        /// 数据绑定
        /// </summary>
        private void DataBind()
        {
            this.gridGD.Rows.Clear();
            IList<T_GdListTemplate> list = null;

            try
            {
                list = templateBLL.GetAllByCategory(fileTemp);
            }
            catch (Exception)
            {
                TXMessageBoxExtensions.Info("没有查询到记录");
                return;
            }
            foreach (var item in list)
            {
                gridGD.Rows.Add();
                DataGridViewCellCollection dgvc = gridGD.Rows[gridGD.Rows.Count - 1].Cells;
                dgvc["GdName"].Value = item.GdName.ToString();
                dgvc["fileType"].Value = item.ProjectCategory.ToString() == "Buildding"
                    ? "房屋工程" : item.ProjectCategory.ToString() == "Traffic" ? "地下管线工程" :
                    item.ProjectCategory.ToString() == "RoadLamp" ? "道路工程" : "桥梁工程";
                dgvc["sorts"].Value = item.OrderIndex.ToString();
                dgvc["ID"].Value = item.ID.ToString();
            }
        }

        /// <summary>
        /// 获取归档类别
        /// </summary>
        private void BindFileType()
        {
            T_Dict_BLL dict_bll = new T_Dict_BLL();
            IList<T_Dict> dictList = dict_bll.FindByKeyWord("ProjectCategory");
            this.cboType.DataSource = dictList;
            this.cboType.DisplayMember = "DisplayName";
            this.cboType.ValueMember = "ValueName";
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            Search();
        }

        /// <summary>
        /// 条件查询
        /// </summary>
        private void Search()
        {
            this.btnSearch.Enabled = false;
            fileTemp = new T_GdListTemplate();
            fileTemp.ProjectCategory = this.cboType.SelectedValue.ToString();
            fileTemp.GdName = this.txtTitle.Text.Trim();

            if (!MyCommon.IsMatchCode(this.txtTitle.Text.Trim()))
            {
                TXMessageBoxExtensions.Info("没有查到记录！");
                this.btnSearch.Enabled = true;
                return;
            }

            DataBind();
            this.btnSearch.Enabled = true;
        }

      
        /// <summary>
        /// 重置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClear_Click(object sender, EventArgs e)
        {
            this.txtTitle.Text = "";
            this.cboType.SelectedIndex = 0;
            this.cboType.SelectedIndex = 0;
        }


        /// <summary>
        /// 加载归档目录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboType_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private string getSelectID()
        {
            string id = string.Empty;
            if (this.gridGD.Rows.Count > 0)
            {
                id = gridGD.SelectedRows[0].Cells[0].Value.ToString();
            }
            return id;
        }

        /// <summary>
        /// 单元格单击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridGD_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //for (int i = 0; i < gridGD.Rows.Count; i++)
                //{
                //    gridGD.Rows[i].Cells[1].Value = 0;
                //}

                //DataGridViewCell cell = this.gridGD.Rows[e.RowIndex].Cells[1];
                //if (cell.Value == null)
                //{
                //    cell.Value = 1;
                //}
                //else
                //{
                //    cell.Value = 0;
                //}
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            refresh r = new refresh(Search);
            frmGdmlEdit edit = new frmGdmlEdit("", "归档目录-新增", this.cboType.SelectedValue.ToString(),r);
            edit.ShowDialog();
        }

        public delegate void refresh();
        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            string id = getSelectID();
            if (string.IsNullOrEmpty(id))
            {
                TXMessageBoxExtensions.Info("没有数据,不能编辑!");
                return;
            }
            refresh r = new refresh(Search);
            frmGdmlEdit edit = new frmGdmlEdit(id, "归档目录-编辑", this.cboType.SelectedValue.ToString(),r);
            edit.ShowDialog();
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            try
            {
                string id = getSelectID();
                if (string.IsNullOrEmpty(id))
                {
                    TXMessageBoxExtensions.Info("没有数据,不能编辑!");
                    return;
                }

                if (TXMessageBoxExtensions.Question("确定要删除吗？") == DialogResult.OK)
                {
                    templateBLL.Delete(id);
                    TXMessageBoxExtensions.Info("删除成功！");
                    Search();
                }
            }
            catch (Exception)
            {
                TXMessageBoxExtensions.Info("删除失败！");
            }
        }

        private void gridGD_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            toolStripButton2_Click(sender, e);
        }
    }
}
