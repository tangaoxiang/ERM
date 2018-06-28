using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ERM.Common;
using ERM.BLL;
using System.IO;
using ERM.MDL;
using TX.Framework.WindowUI.Forms;
using System.Threading;
using System.Xml;
using ERM.UI.Common;

namespace ERM.UI
{
    /// <summary>
    /// 工程管理
    /// </summary>
    public partial class frmProjectList : ERM.UI.Controls.Skin_DevEX
    {
        #region 参数初始化
        int startIndex = 0;
        T_Dict_BLL dictBll = new T_Dict_BLL();
        ERM.UI.frmMDIMain.setComBoxDel _setComBoxDel;
        #endregion

        #region  窗体函数
        public frmProjectList(ERM.UI.frmMDIMain.setComBoxDel setComBoxDel)
        {
            InitializeComponent();
            _setComBoxDel = setComBoxDel;
        }
        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmProjectSelect_Load(object sender, EventArgs e)
        {
            BindGridViewData(true);
            if (!MyCommon.CheckMenuState("5"))
            {
                tsAdd.Visible = false;
            }
            if (!MyCommon.CheckMenuState("6"))
            {
                tsDelete.Visible = false;
            }
        }
        /// <summary>
        /// 关闭事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmProjectSelect_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.dgProject.Rows.Count == 0)
            {
                _setComBoxDel(true);
            }

            if (this.DialogResult != DialogResult.OK)
            {
                if (!string.IsNullOrWhiteSpace(Globals.ProjectNO))//如果已经打开过工程
                {
                    bool b = false;//判断工程DataGrid里是否有这个工程号，true表示找到,false就是已经被删了
                    for (int i = 0; i < dgProject.Rows.Count; i++)
                    {
                        if (Globals.ProjectNO == dgProject.Rows[i].Cells["ProjectNO"].Value.ToString())
                        {
                            Globals.Projectname = dgProject.Rows[i].Cells["projectname"].Value.ToString();
                            b = true;
                            break;
                        }
                    }
                    if (b)//如果找到，就设成OK
                    {
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        _setComBoxDel(true);
                        TXMessageBoxExtensions.Info("系统找不到之前打开的工程，请重新选择工程！");
                        Globals.ProjectNO = "";
                        Globals.Projectname = "";
                        e.Cancel = true;
                    }
                }
            }
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsAdd_Click(object sender, EventArgs e)
        {
            frmProjectInfo frmProjectInfo = new frmProjectInfo("", true);
            frmProjectInfo.ShowDialog();
            BindGridViewData(false);//重新绑定数据
        }
        /// <summary>
        /// 编辑列表界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsEdit_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection rows = this.dgProject.SelectedRows;
            if (rows.Count == 0)
            {
                return;
            }
            else
            {
                string ProjectNO = rows[0].Cells["ProjectNO"].Value.ToString();//要编辑的主键
                frmProjectInfo frmProjectInfo = new frmProjectInfo(ProjectNO, false);
                frmProjectInfo.ShowDialog();
                BindGridViewData(false);//重新绑定数据
            }
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnProjectDelete_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection rows = this.dgProject.SelectedRows;
            if (rows.Count == 0)
            {
                return;
            }
            else
            {   //询问是否删除
                if (TXMessageBoxExtensions.Question("确定要删除工程：" + rows[0].Cells["ProjectName"].Value.ToString() + "吗？  \n 【温馨提示：删除工程后信息将无法恢复！请慎重！！！】") == DialogResult.Cancel)
                {
                    return;
                }
                else//确定删除
                {
                    string ProjectNO = rows[0].Cells["ProjectNO"].Value.ToString();
                    ERM.BLL.T_Projects_BLL ProjectsDB = new ERM.BLL.T_Projects_BLL();
                    T_Item_BLL item = new T_Item_BLL();
                    item.Delete(ProjectsDB.Find(ProjectNO).ItemID);

                    ProjectsDB.Delete(ProjectNO);
                    BLL.BLLMore bllMore = new BLLMore();
                    
                    bllMore.DeleteUnitByProjectNO(ProjectNO);
                    bllMore.DeleteFileListByProjectNO(ProjectNO);
                    bllMore.DeleteCellFileByProjectNO(ProjectNO);
                    bllMore.DeleteArchiveByProjectNO(ProjectNO);
                    bllMore.DeleteGdListByProjectNO(ProjectNO);

                    bllMore.DeleteBrigeByProjectNO(ProjectNO);
                    bllMore.DeleteRoadLampByProjectNO(ProjectNO);
                    bllMore.DeleteTrafficByProjectNO(ProjectNO);

                    bllMore.DeletePointByPorjectNo(ProjectNO);
                    bllMore.DeleteYW_CellAndEFileByPorjectNo(ProjectNO);
                    MyCommon.DeleteAndCreateEmptyDirectory(Globals.ProjectPathParent + ProjectNO, false);
                    BindGridViewData(false);//重新绑定数据
                }
            }
        }
        /// <summary>
        /// 工程双击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgProject_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int RowIndex = 0;
            if (dgProject.SelectedRows.Count > 0)
                RowIndex = dgProject.SelectedRows[0].Index;
            else
                return;
            string ProjectNO = dgProject.Rows[RowIndex].Cells["ProjectNO"].Value.ToString();//要操作工程的主键
            string projectname = dgProject.Rows[RowIndex].Cells["projectname"].Value.ToString();
            Globals.ProjectNO = ProjectNO;//工程编号也传过去
            Globals.Projectname = projectname;//工程名也传过去   

            Globals.CreateProjectPath();
            this.DialogResult = DialogResult.OK;
        }
        /// <summary>
        /// 导入工程事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsImportProject_Click(object sender, EventArgs e)
        {
            frmExportProject dlg = new frmExportProject();
            dlg.OpType = "恢复";
            dlg.ShowDialog();
            BindGridViewData(false);
        }
        /// <summary>
        /// 导出工程
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tdExProject_Click(object sender, EventArgs e)
        {
            if (dgProject.RowCount == 0)
            {
                TXMessageBoxExtensions.Info("当前系统没有工程可导出");
                return;
            }
            DataGridViewRow dr = dgProject.SelectedRows[0];
            string ProjectNo = dr.Cells["ProjectNO"].Value.ToString();

            frmExportProject dlg = new frmExportProject();
            dlg.ProjectNO = ProjectNo;
            dlg.ProjectName = dr.Cells["projectname"].Value.ToString();
            dlg.OpType = "备份";
            dlg.ShowDialog();
        }
        /// <summary>
        /// 退出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsCheck_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// 选择事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClear_Click(object sender, EventArgs e)
        {
            dgProject_CellDoubleClick(sender, null);
        }
        /// <summary>
        /// 快速查找
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ts_Find_Click(object sender, EventArgs e)
        {
            Project.frmProjectSearch searchFrm = (Project.frmProjectSearch)Application.OpenForms["Project.frmProjectSearch"];
            if (searchFrm == null)
            {
                searchFrm = new Project.frmProjectSearch(this);
                searchFrm.Owner = this;
                searchFrm.Show();
            }
            searchFrm.Focus();
        }
        /// <summary>
        /// 导入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsb_DaoRu_Click(object sender, EventArgs e)
        {
            frmExportProject dlg = new frmExportProject();
            dlg.OpType = "导入";
            dlg.ShowDialog();
            BindGridViewData(false);
        }
        /// <summary>
        /// 复制
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsb_FuZhi_Click(object sender, EventArgs e)
        {
            frmProjectCopy ProjectCopy = new frmProjectCopy();
            ProjectCopy.ShowDialog();
            BindGridViewData(false);
        }
        #endregion

        #region 自定义函数
        /// <summary>
        /// 设定显示的工程显示额列信息和规则
        /// </summary>
        private void SetGridStyle()
        {
            this.dgProject.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgProject.Columns.Add("ProjectNO", "工程编号");
            dgProject.Columns.Add("district", "区域");
            dgProject.Columns.Add("ProjectCategory", "工程类别");
            dgProject.Columns.Add("projectname", "工程名称");
            dgProject.Columns.Add("address", "工程地址");
            dgProject.Columns.Add("begindate", "开工日期");
            //dgProject.Columns.Add("bjdate", "报建日期");
            dgProject.Columns.Add("enddate", "竣工日期");
         
            //this.dgProject.Columns["begindate"].DefaultCellStyle.Format = "yyyy-MM-dd";
            //this.dgProject.Columns["bjdate"].DefaultCellStyle.Format = "yyyy-MM-dd";
            //this.dgProject.Columns["enddate"].DefaultCellStyle.Format = "yyyy-MM-dd";
        }
        /// <summary>
        /// 绑定所有工程方法
        /// </summary>
        /// <param name="SetStyle">是否设定表格样式</param>
        private void BindGridViewData(bool SetStyle)
        {
            dgProject.AutoGenerateColumns = false;
            if (SetStyle)
                SetGridStyle(); //设置样式
            dgProject.Rows.Clear();
            ERM.BLL.T_Projects_BLL ProjectsDB = new ERM.BLL.T_Projects_BLL();
            IList<MDL.T_Projects> projList = ProjectsDB.GetAll();//.GetList("").Tables[0].DefaultView;//绑定数据
            IList<T_Dict> dict = dictBll.FindByKeyWord("ProjectCategory");
           
            foreach (MDL.T_Projects obj in projList)
            {
                dgProject.Rows.Add();
                dgProject.Rows[dgProject.Rows.Count - 1].Cells["ProjectNO"].Value = obj.ProjectNO;
                dgProject.Rows[dgProject.Rows.Count - 1].Cells["district"].Value = obj.district;
                dgProject.Rows[dgProject.Rows.Count - 1].Cells["projectname"].Value = obj.projectname;
                dgProject.Rows[dgProject.Rows.Count - 1].Cells["address"].Value = obj.address;
                dgProject.Rows[dgProject.Rows.Count - 1].Cells["begindate"].Value = obj.begindate;

                foreach (var item in dict)
                {
                    if (item.ValueName == obj.ProjectCategory)
                    {
                       dgProject.Rows[dgProject.Rows.Count - 1].Cells["ProjectCategory"].Value = item.DisplayName;
                       break;
                    }
                }

                dgProject.Rows[dgProject.Rows.Count - 1].Cells["begindate"].Value =
                    string.IsNullOrWhiteSpace(obj.begindate) ? "" : MyCommon.ToDate(obj.begindate).ToString("yyyy-MM-dd");
                //dgProject.Rows[dgProject.Rows.Count - 1].Cells["bjdate"].Value = MyCommon.ToDate(obj.bjdate).ToString("yyyy-MM-dd");
                dgProject.Rows[dgProject.Rows.Count - 1].Cells["enddate"].Value =
                    string.IsNullOrWhiteSpace(obj.enddate) ? "" : MyCommon.ToDate(obj.enddate).ToString("yyyy-MM-dd");

                if (Globals.ProjectNO != null && Globals.ProjectNO != string.Empty && Globals.ProjectNO == obj.ProjectNO)
                {
                    dgProject.Rows[dgProject.Rows.Count - 1].Selected = true;
                }
            
            }
        }
        /// <summary>
        /// 快速查询方法
        /// </summary>
        /// <param name="findIndex">查询起始位置</param>
        /// <param name="projectNo">工程编号</param>
        /// <param name="projectName">工程名称</param>
        public void FindProject(string projectNo, string projectName)
        {
            int flag = 0;
            if (startIndex >= dgProject.Rows.Count)
            {
                startIndex = 0;
            }

            if (dgProject.Rows.Count > 0)
            {
                for (int r = startIndex; r < dgProject.Rows.Count; r++)
                {
                    startIndex = r + 1;
                    DataGridViewRow dgv_row = dgProject.Rows[r];
                    if (projectNo != "" && projectName != "")
                    {
                        if (dgv_row.Cells["ProjectNO"].Value.ToString().Contains(projectNo) && dgv_row.Cells["projectname"].Value.ToString().Contains(projectName))
                        {
                            dgv_row.Selected = true;
                            dgProject.FirstDisplayedScrollingRowIndex = dgv_row.Index;
                            break;
                        }
                    }
                    else if (projectNo == "" && projectName != "")
                    {
                        if (dgv_row.Cells["projectname"].Value.ToString().Contains(projectName))
                        {
                            dgv_row.Selected = true;
                            dgProject.FirstDisplayedScrollingRowIndex = dgv_row.Index;
                            break;
                        } 
                    }
                    else if (projectNo != "" && projectName == "")
                    {
                        if (dgv_row.Cells["ProjectNO"].Value.ToString().Contains(projectNo))
                        {
                            dgv_row.Selected = true;
                            dgProject.FirstDisplayedScrollingRowIndex = dgv_row.Index;
                            break;
                        }
                    }
                    flag++;
                }
            }
            if (flag == dgProject.Rows.Count)
            {
                TXMessageBoxExtensions.Info("没有查询到相应工程信息");
            }
        }
        #endregion

        /// <summary>
        /// 导出项目信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsb_DaoChu_Click(object sender, EventArgs e)
        {
            if (dgProject.RowCount == 0)
            {
                TXMessageBoxExtensions.Info("提示：当前系统没有项目可导出");
                return;
            }
            DataGridViewRow dr = dgProject.SelectedRows[0];
            string ProjectNo = dr.Cells["ProjectNO"].Value.ToString();
            string ProjectName = dr.Cells["projectname"].Value.ToString();
            MyCommon.DaoChuPrjectInfo(ProjectNo, ProjectName);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dgProject_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frmProjectList_Click(object sender, EventArgs e)
        {
         
        }

        private void frmProjectList_Activated(object sender, EventArgs e)
        {
           
        }

        private void frmProjectList_Leave(object sender, EventArgs e)
        {
         
        }

        private void frmProjectList_MouseLeave(object sender, EventArgs e)
        {
          
        }

        private void frmProjectList_Deactivate(object sender, EventArgs e)
        {
           
        }

        /// <summary>
        /// 坐标设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbSetPoint_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection rows = this.dgProject.SelectedRows;
            if (rows.Count == 0)
            {
                return;
            }
            else
            {
                string ProjectNO = rows[0].Cells["ProjectNO"].Value.ToString();
                frmSettPoint point = new frmSettPoint(ProjectNO);
                point.ShowDialog();
            }
        }
    }
}
