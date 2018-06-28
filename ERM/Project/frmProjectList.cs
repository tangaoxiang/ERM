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
    /// ���̹���
    /// </summary>
    public partial class frmProjectList : ERM.UI.Controls.Skin_DevEX
    {
        #region ������ʼ��
        int startIndex = 0;
        T_Dict_BLL dictBll = new T_Dict_BLL();
        ERM.UI.frmMDIMain.setComBoxDel _setComBoxDel;
        #endregion

        #region  ���庯��
        public frmProjectList(ERM.UI.frmMDIMain.setComBoxDel setComBoxDel)
        {
            InitializeComponent();
            _setComBoxDel = setComBoxDel;
        }
        /// <summary>
        /// �������
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
        /// �ر��¼�
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
                if (!string.IsNullOrWhiteSpace(Globals.ProjectNO))//����Ѿ��򿪹�����
                {
                    bool b = false;//�жϹ���DataGrid���Ƿ���������̺ţ�true��ʾ�ҵ�,false�����Ѿ���ɾ��
                    for (int i = 0; i < dgProject.Rows.Count; i++)
                    {
                        if (Globals.ProjectNO == dgProject.Rows[i].Cells["ProjectNO"].Value.ToString())
                        {
                            Globals.Projectname = dgProject.Rows[i].Cells["projectname"].Value.ToString();
                            b = true;
                            break;
                        }
                    }
                    if (b)//����ҵ��������OK
                    {
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        _setComBoxDel(true);
                        TXMessageBoxExtensions.Info("ϵͳ�Ҳ���֮ǰ�򿪵Ĺ��̣�������ѡ�񹤳̣�");
                        Globals.ProjectNO = "";
                        Globals.Projectname = "";
                        e.Cancel = true;
                    }
                }
            }
        }
        /// <summary>
        /// ���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsAdd_Click(object sender, EventArgs e)
        {
            frmProjectInfo frmProjectInfo = new frmProjectInfo("", true);
            frmProjectInfo.ShowDialog();
            BindGridViewData(false);//���°�����
        }
        /// <summary>
        /// �༭�б����
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
                string ProjectNO = rows[0].Cells["ProjectNO"].Value.ToString();//Ҫ�༭������
                frmProjectInfo frmProjectInfo = new frmProjectInfo(ProjectNO, false);
                frmProjectInfo.ShowDialog();
                BindGridViewData(false);//���°�����
            }
        }
        /// <summary>
        /// ɾ��
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
            {   //ѯ���Ƿ�ɾ��
                if (TXMessageBoxExtensions.Question("ȷ��Ҫɾ�����̣�" + rows[0].Cells["ProjectName"].Value.ToString() + "��  \n ����ܰ��ʾ��ɾ�����̺���Ϣ���޷��ָ��������أ�������") == DialogResult.Cancel)
                {
                    return;
                }
                else//ȷ��ɾ��
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
                    BindGridViewData(false);//���°�����
                }
            }
        }
        /// <summary>
        /// ����˫���¼�
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
            string ProjectNO = dgProject.Rows[RowIndex].Cells["ProjectNO"].Value.ToString();//Ҫ�������̵�����
            string projectname = dgProject.Rows[RowIndex].Cells["projectname"].Value.ToString();
            Globals.ProjectNO = ProjectNO;//���̱��Ҳ����ȥ
            Globals.Projectname = projectname;//������Ҳ����ȥ   

            Globals.CreateProjectPath();
            this.DialogResult = DialogResult.OK;
        }
        /// <summary>
        /// ���빤���¼�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsImportProject_Click(object sender, EventArgs e)
        {
            frmExportProject dlg = new frmExportProject();
            dlg.OpType = "�ָ�";
            dlg.ShowDialog();
            BindGridViewData(false);
        }
        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tdExProject_Click(object sender, EventArgs e)
        {
            if (dgProject.RowCount == 0)
            {
                TXMessageBoxExtensions.Info("��ǰϵͳû�й��̿ɵ���");
                return;
            }
            DataGridViewRow dr = dgProject.SelectedRows[0];
            string ProjectNo = dr.Cells["ProjectNO"].Value.ToString();

            frmExportProject dlg = new frmExportProject();
            dlg.ProjectNO = ProjectNo;
            dlg.ProjectName = dr.Cells["projectname"].Value.ToString();
            dlg.OpType = "����";
            dlg.ShowDialog();
        }
        /// <summary>
        /// �˳�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsCheck_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// ѡ���¼�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClear_Click(object sender, EventArgs e)
        {
            dgProject_CellDoubleClick(sender, null);
        }
        /// <summary>
        /// ���ٲ���
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
        /// ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsb_DaoRu_Click(object sender, EventArgs e)
        {
            frmExportProject dlg = new frmExportProject();
            dlg.OpType = "����";
            dlg.ShowDialog();
            BindGridViewData(false);
        }
        /// <summary>
        /// ����
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

        #region �Զ��庯��
        /// <summary>
        /// �趨��ʾ�Ĺ�����ʾ������Ϣ�͹���
        /// </summary>
        private void SetGridStyle()
        {
            this.dgProject.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgProject.Columns.Add("ProjectNO", "���̱��");
            dgProject.Columns.Add("district", "����");
            dgProject.Columns.Add("ProjectCategory", "�������");
            dgProject.Columns.Add("projectname", "��������");
            dgProject.Columns.Add("address", "���̵�ַ");
            dgProject.Columns.Add("begindate", "��������");
            //dgProject.Columns.Add("bjdate", "��������");
            dgProject.Columns.Add("enddate", "��������");
         
            //this.dgProject.Columns["begindate"].DefaultCellStyle.Format = "yyyy-MM-dd";
            //this.dgProject.Columns["bjdate"].DefaultCellStyle.Format = "yyyy-MM-dd";
            //this.dgProject.Columns["enddate"].DefaultCellStyle.Format = "yyyy-MM-dd";
        }
        /// <summary>
        /// �����й��̷���
        /// </summary>
        /// <param name="SetStyle">�Ƿ��趨�����ʽ</param>
        private void BindGridViewData(bool SetStyle)
        {
            dgProject.AutoGenerateColumns = false;
            if (SetStyle)
                SetGridStyle(); //������ʽ
            dgProject.Rows.Clear();
            ERM.BLL.T_Projects_BLL ProjectsDB = new ERM.BLL.T_Projects_BLL();
            IList<MDL.T_Projects> projList = ProjectsDB.GetAll();//.GetList("").Tables[0].DefaultView;//������
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
        /// ���ٲ�ѯ����
        /// </summary>
        /// <param name="findIndex">��ѯ��ʼλ��</param>
        /// <param name="projectNo">���̱��</param>
        /// <param name="projectName">��������</param>
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
                TXMessageBoxExtensions.Info("û�в�ѯ����Ӧ������Ϣ");
            }
        }
        #endregion

        /// <summary>
        /// ������Ŀ��Ϣ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsb_DaoChu_Click(object sender, EventArgs e)
        {
            if (dgProject.RowCount == 0)
            {
                TXMessageBoxExtensions.Info("��ʾ����ǰϵͳû����Ŀ�ɵ���");
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
        /// ��������
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
