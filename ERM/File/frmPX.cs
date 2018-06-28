using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TX.Framework.WindowUI.Forms;

namespace ERM.UI
{
    public partial class frmPX : ERM.UI.Controls.Skin_DevEX
    {
        string _ParentID;
        int _Flg;
        public frmPX(string ParentID, int Flg)
        {
            _ParentID = ParentID;
            _Flg = Flg;
            InitializeComponent();
        }

        private void frmPX_Load(object sender, EventArgs e)
        {
            dgv_PX.AutoGenerateColumns = false;
            BindPxInfo(_ParentID, _Flg);
        }

        private void BindPxInfo(string ParentID, int Flg)
        {
            if (Flg == 0)
            {
                BLL.T_FileList_BLL FileList_BLL = new ERM.BLL.T_FileList_BLL();
                DataTable tbl_FileList = FileList_BLL.GetFileByGDID(Globals.ProjectNO, ParentID);
                if (tbl_FileList != null && tbl_FileList.Rows.Count > 0)
                {
                    int index = 1;
                    foreach (DataRow f_row in tbl_FileList.Rows)
                    {
                        dgv_PX.Rows.Add();
                        dgv_PX.Rows[dgv_PX.Rows.Count - 1].Cells["cl_ID"].Value = f_row["FileID"].ToString();
                        dgv_PX.Rows[dgv_PX.Rows.Count - 1].Cells["cl_Index"].Value = index;
                        dgv_PX.Rows[dgv_PX.Rows.Count - 1].Cells["cl_Name"].Value = f_row["wjtm"].ToString();
                        index++;
                    }
                }
            }
            else if (Flg == 1)
            {
                BLL.T_CellAndEFile_BLL CellAndEFile_BLL = new ERM.BLL.T_CellAndEFile_BLL();
                IList<MDL.T_CellAndEFile> CellAndEFile_List
                    = CellAndEFile_BLL.FindByGdFileID(ParentID, Globals.ProjectNO);
                int index = 1;
                foreach (MDL.T_CellAndEFile ef_MDL in CellAndEFile_List)
                {
                    dgv_PX.Rows.Add();
                    dgv_PX.Rows[dgv_PX.Rows.Count - 1].Cells["cl_ID"].Value = ef_MDL.CellID;
                    dgv_PX.Rows[dgv_PX.Rows.Count - 1].Cells["cl_Index"].Value = index;
                    dgv_PX.Rows[dgv_PX.Rows.Count - 1].Cells["cl_Name"].Value = ef_MDL.title;
                    index++;
                }
            }
        }
        /// <summary>
        /// 置顶
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTop_Click(object sender, EventArgs e)
        {
            DownAndUp(3);
        }
        /// <summary>
        /// 上移
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUp_Click(object sender, EventArgs e)
        {
            DownAndUp(1);
        }
        /// <summary>
        /// 下移
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDown_Click(object sender, EventArgs e)
        {
            DownAndUp(2);
        }
        /// <summary>
        /// 置后
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLast_Click(object sender, EventArgs e)
        {
            DownAndUp(4);
        }
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            BLL.T_CellAndEFile_BLL cellAndFile_bll = new BLL.T_CellAndEFile_BLL();
            BLL.T_FileList_BLL fileList_bll = new BLL.T_FileList_BLL();
            int OrderIndex = 1;
            foreach (DataGridViewRow px_ros in dgv_PX.Rows)
            {
                try
                {
                    if (_Flg == 0)
                    {
                        //文件级
                        MDL.T_FileList fileMDL1 = fileList_bll.Find(px_ros.Cells["cl_ID"].Value.ToString(), Globals.ProjectNO);
                        fileMDL1.GdFileOrderIndex = OrderIndex;
                        fileList_bll.Update(fileMDL1);
                    }
                    else
                    {
                        //电子文件
                        MDL.T_CellAndEFile cellMDL = cellAndFile_bll.Find(px_ros.Cells["cl_ID"].Value.ToString(), Globals.ProjectNO);
                        cellMDL.GdOrderIndex = OrderIndex;
                        cellAndFile_bll.Update(cellMDL);
                    }
                    OrderIndex++;
                }
                catch (Exception ex)
                {
                    TXMessageBoxExtensions.Info("排序更新失败！" + ex.Message);
                }
            }
            TXMessageBoxExtensions.Info("修改成功！");
            this.DialogResult = DialogResult.OK;
        }
        /// <summary>
        /// 取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// 数据移动
        /// </summary>
        /// <param name="tmpFlag">移动类型：1上移 2下移 3置顶 4置后</param>
        private void DownAndUp(int tmpFlag)
        {
            if (dgv_PX.RowCount == 0)
            {
                TXMessageBoxExtensions.Info("提示：无记录可操作");
                return;
            }
            DataGridViewRow dr = dgv_PX.SelectedRows[0];
            if (dr == null)
                return;
            if (tmpFlag == 1)
            {
                //向上
                if (dr.Index == 0)
                {
                    TXMessageBoxExtensions.Info("已经是第一行了!");
                }
                if (dr.Index > 0)
                {
                    int index = dr.Index;
                    dgv_PX.Rows.Remove(dr);
                    dgv_PX.Rows.Insert(index - 1, dr);
                    dr.Selected = true;
                }
            }
            else if (tmpFlag == 2)
            {
                //向下
                if (dr.Index == dgv_PX.Rows.Count - 1)
                {
                    TXMessageBoxExtensions.Info("已经是最后一行了");
                }
                if (dr.Index < dgv_PX.Rows.Count - 1)
                {
                    int index = dr.Index;
                    dgv_PX.Rows.Remove(dr);
                    dgv_PX.Rows.Insert(index + 1, dr);
                    dr.Selected = true;
                }
            }
            else if (tmpFlag == 3)
            {
                //置顶
                if (dr.Index == 0)
                {
                    TXMessageBoxExtensions.Info("已经是第一行了!");
                }
                if (dr.Index > 0)
                {
                    dgv_PX.Rows.Remove(dr);
                    dgv_PX.Rows.Insert(0, dr);
                    dr.Selected = true;
                }
            }
            else if (tmpFlag == 4)
            {
                //置后
                if (dr.Index == dgv_PX.Rows.Count - 1)
                {
                    TXMessageBoxExtensions.Info("已经是最后一行了");
                }
                if (dr.Index < dgv_PX.Rows.Count - 1)
                {
                    dgv_PX.Rows.Remove(dr);
                    dgv_PX.Rows.Insert(dgv_PX.Rows.Count, dr);
                    dr.Selected = true;
                }
            }
        }
        private void dgv_PX_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            System.Drawing.Rectangle rectangle = new System.Drawing.Rectangle(e.RowBounds.Location.X,
                e.RowBounds.Location.Y, dgv_PX.RowHeadersWidth - 4, e.RowBounds.Height);

            TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(),
                dgv_PX.RowHeadersDefaultCellStyle.Font, rectangle,
                dgv_PX.RowHeadersDefaultCellStyle.ForeColor,
                TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
        }

        private void btnTop_Click_1(object sender, EventArgs e)
        {

        }

        private void btnUp_Click_1(object sender, EventArgs e)
        {

        }

        private void btnDown_Click_1(object sender, EventArgs e)
        {

        }

        private void btnLast_Click_1(object sender, EventArgs e)
        {

        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {

        }

        private void btnCancle_Click_1(object sender, EventArgs e)
        {

        }
    }
}
