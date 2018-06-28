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
    public partial class frmGdList : Skin_DevEX
    {
        T_FileListTemplate fileTemp = new T_FileListTemplate();
        T_FileListTemplate_BLL templateBLL = new T_FileListTemplate_BLL();
        static IList<T_GdListTemplate> list = null;
        //static int pageIndex = 1;
        //static int pageSize = 30;
        //static int pageCount = 0;
        public delegate void refresh();

        public frmGdList()
        {
            InitializeComponent();
            DataBind();
            BindFileType();
            BindCategory(this.cboType.SelectedValue.ToString());
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
            DataSet ds = null;
            try
            {
                ds = templateBLL.GetList(fileTemp);
            }
            catch (Exception)
            {
                TXMessageBoxExtensions.Info("没有查询到记录！");
                return;
            }

            if (ds.Tables.Count>0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    gridGD.Rows.Add();
                    DataGridViewCellCollection dgvc = gridGD.Rows[i].Cells;
                    DataRow drc = ds.Tables[0].Rows[i];
                    string gdid = drc["gdid"].ToString();
                    string isGdid = string.Empty;
                    DataGridViewImageColumn status = new DataGridViewImageColumn();
                    status.DisplayIndex = 4;
                    status.HeaderText = "是否目录";
                    status.DataPropertyName = "isDire";
                    status.ImageLayout = DataGridViewImageCellLayout.Zoom;
                    if (drc["gdid"].ToString() == "")
                    {
                        status.Image = Properties.Resources._121;
                    }
                    //gridGD.Columns.Insert(i, status);
                    dgvc["wjtm"].Value = isGdid + drc["gdwj"].ToString();
                    dgvc["sorts"].Value = drc["orderIndex"].ToString();
                    dgvc["fileType"].Value = drc["projectCategory"].ToString() == "Buildding"
                        ? "建筑工程" : drc["projectCategory"].ToString() == "Traffic" ? "地下管线工程" :
                        drc["projectCategory"].ToString() == "RoadLamp" ? "道路工程" : "桥梁工程";
                    dgvc["ID"].Value = drc["FileID"].ToString();
                }
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
            fileTemp = new T_FileListTemplate();
            fileTemp.ProjectCategory = this.cboType.SelectedValue.ToString();
            fileTemp.gdwj = this.txtTitle.Text.Trim();
            fileTemp.GDID = this.cboCategory.SelectedValue.ToString();
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
       /// 新增
       /// </summary>
       /// <param name="sender"></param>
       /// <param name="e"></param>
 
       private void btnAdd_Click(object sender, EventArgs e)
        {
           
        }

        /// <summary>
        ///  编辑
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
       private void btnEdit_Click(object sender, EventArgs e)
       {
          
       }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
       private void skinButtonEX3_Click(object sender, EventArgs e)
       {
          
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
           this.cboCategory.SelectedIndex = 0;
           this.cboType.SelectedIndex = 0;
       }

        /// <summary>
        /// 上级分类
        /// </summary>
       private void BindCategory(string Type)
       {
           List<T_GdListTemplate> temp_list = new List<T_GdListTemplate>();
           T_GdListTemplate fileTemp = new T_GdListTemplate();
           fileTemp.ProjectCategory = this.cboType.SelectedValue.ToString();
           list = new T_GdListTemplate_BLL().GetAllByCategory(fileTemp);
           foreach (var item in list)
           {
               temp_list.Add(item);
           }
           this.cboCategory.DataSource = temp_list;
           this.cboCategory.DisplayMember = "GdName";
           this.cboCategory.ValueMember = "ID";
       }

        /// <summary>
        /// 加载归档目录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
       private void cboType_SelectedIndexChanged(object sender, EventArgs e)
       {
           BindCategory(this.cboType.SelectedValue.ToString());
       }

       private void panel1_Paint(object sender, PaintEventArgs e)
       {

       }

       private void btnFirst_Click(object sender, EventArgs e)
       {

       }

       private void btnUp_Click(object sender, EventArgs e)
       {

       }

       private void btnNext_Click(object sender, EventArgs e)
       {

       }

       private void btnLast_Click(object sender, EventArgs e)
       {

       }

       private void btnSkip_Click(object sender, EventArgs e)
       {

       }

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

       private void toolStripButton1_Click(object sender, EventArgs e)
       {

       }
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
       private void toolStripButton3_Click(object sender, EventArgs e)
       {
           refresh r = new refresh(Search);
           frmGdListEdit edit = new frmGdListEdit("", "归档文件-新增", this.cboType.SelectedValue.ToString(),r);
           edit.ShowDialog();
       }

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
           frmGdListEdit edit = new frmGdListEdit(id, "归档文件-编辑", this.cboType.SelectedValue.ToString(), r);
           edit.ShowDialog();
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
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
       private void toolStripButton1_Click_1(object sender, EventArgs e)
       {
           try
           {
               string id = getSelectID();
               if (string.IsNullOrEmpty(id))
               {
                   TXMessageBoxExtensions.Info("没有数据,不能删除!");
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
           toolStripButton2_Click(sender,e);
       }
    }
}
