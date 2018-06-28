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
using TX.Framework.WindowUI.Forms;

namespace ERM.UI
{
    public partial class frmSettPoint : ERM.UI.Controls.Skin_DevEX
    {
        T_Point_BLL bll = new T_Point_BLL();
        T_Point point = new T_Point();

        string projectNo = string.Empty;
        public frmSettPoint()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 坐标设置
        /// </summary>
        /// <param name="ProjectNo"></param>
        public frmSettPoint(string ProjectNo)
        {
            InitializeComponent();
            this.projectNo = ProjectNo;
            this.Text += " - " + projectNo;
            DataBind();
        }

        /// <summary>
        /// 关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (setValue())
            {
                point.ID = Guid.NewGuid().ToString();
                if (!bll.Exists(point))
                {
                    bll.Insert(point);
                    TXMessageBoxExtensions.Info("新增成功！");
                    DataBind();
                }
                else
                {
                    TXMessageBoxExtensions.Info("顺序号重复！");
                }
            }
        }

        /// <summary>
        /// 设置参数
        /// </summary>
        private bool setValue()
        {
            if (this.txtSort.Text.Trim() == "")
            {
                TXMessageBoxExtensions.Info("顺序号不能为空！");
                this.txtSort.Focus();
                return false;
            }

            if (this.txtX.Text.Trim()=="")
            {
                TXMessageBoxExtensions.Info("X坐标不能为空！");
                this.txtX.Focus();
                return false;
            }

            if (this.txtY.Text.Trim() == "")
            {
                TXMessageBoxExtensions.Info("Y坐标不能为空！");
                this.txtY.Focus();
                return false;
            }

            point.X = this.txtX.Text;
            point.Y = this.txtY.Text;
            point.OrderIndex = Convert.ToInt32(this.txtSort.Text);
            point.ProjectNo = projectNo;

            return true;
        }

        /// <summary>
        /// 重置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReset_Click(object sender, EventArgs e)
        {
            this.txtSort.Text = "";
            this.txtX.Text = "";
            this.txtY.Text = "";
        }

        /// <summary>
        /// 数据绑定
        /// </summary>
        private void DataBind()
        {
            dgvPoint.Rows.Clear();
            IList<T_Point> list = bll.GetList(projectNo);
            foreach (var item in list)
            {
                dgvPoint.Rows.Add();

                DataGridViewRow dgv = dgvPoint.Rows[dgvPoint.Rows.Count - 1];
                dgv.Cells[0].Value = item.ID;
                dgv.Cells[1].Value = item.OrderIndex;
                dgv.Cells[2].Value = item.X.ToString();
                dgv.Cells[3].Value = item.Y.ToString();
            }
        }

        private void dgvPoint_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        /// <summary>
        /// 单击行加载编辑数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvPoint_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int rowIndex = e.RowIndex;
                DataGridViewRow dgv = this.dgvPoint.Rows[rowIndex];

                string ID = dgv.Cells[0].Value.ToString();
                string x = dgv.Cells[2].Value.ToString();
                string y = dgv.Cells[3].Value.ToString();
                string orderIndex = dgv.Cells[1].Value.ToString();

                this.lblID.Text = ID;
                this.txtSort.Text = orderIndex;
                this.txtX.Text = x;
                this.txtY.Text = y;
            }
            catch (Exception)
            {

            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (this.dgvPoint.Rows.Count == 0)
            {
                TXMessageBoxExtensions.Info("请选择要删除的数据行!");
                return;
            }

            if (TXMessageBoxExtensions.Question("确认删除选中行吗？")==DialogResult.OK)
            {
                point.ID = this.dgvPoint.SelectedRows[0].Cells[0].Value.ToString() ;
                bll.Delete(point);
                TXMessageBoxExtensions.Info("删除成功！");
                DataBind();
            }
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (setValue())
            {
                if (this.dgvPoint.Rows.Count == 0)
                {
                    TXMessageBoxExtensions.Info("请选择要修改的数据行!");
                    return;
                }
                point.ID = this.dgvPoint.SelectedRows[0].Cells[0].Value.ToString();
                if (!bll.ExistsByEdit(point))
                {
                    bll.Update(point);
                    TXMessageBoxExtensions.Info("修改成功！");
                    DataBind();
                }
                else
                {
                    TXMessageBoxExtensions.Info("顺序号重复！");
                }
            }
        }
    }
}
