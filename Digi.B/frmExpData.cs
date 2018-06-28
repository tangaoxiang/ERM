using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using DigiPower.ERM.Common;

namespace Digi.B 
{
    public partial class frmExpData : Form
    {


        ////ʵ�������ķ�����
        private TreeFactory treeFactory = new TreeFactory();

        //�����Ŀ¼
        string destFolder;

        string Sqlnodes = "";

        TreeNodeEx TheNode = null;

        DataSet ds = null;

        DigiPower.ERM.CBLL.TreesData treesData = new DigiPower.ERM.CBLL.TreesData();

        DigiPower.ERM.CBLL.ExportData exportData = new DigiPower.ERM.CBLL.ExportData();
        //private ProjectFactory projectFactory;

        public frmExpData(TreeNodeEx theNode)
        {
            InitializeComponent();

            TheNode = theNode;

        }
        //public frmExpData(string sqlnodes)
        //{
        //    InitializeComponent();
        //    projectFactory = new ProjectFactory(Globals.OpenedProjectNo);

        //    txtProjectName.Text = projectFactory.ProjectInfo.ProjectName;
        //}


        private List<string> archiveNodes = new List<string>();
        #region ��ѡ�нڵ������ң��ų����������������ļ��� ����GetAllParnetNode
        private void GetNodes()
        {
            DigiPower.ERM.BLL.Cell_Templet tCell = new DigiPower.ERM.BLL.Cell_Templet();
            DigiPower.ERM.BLL.FileRecording_Templet tFile = new DigiPower.ERM.BLL.FileRecording_Templet();

            DataTable tFileSet = tFile.GetAllList().Tables[0].Copy();
            DataTable tModelSet = tCell.GetAllList().Tables[0].Copy();

            tFileSet.TableName = "filerecording_templet";
            tModelSet.TableName = "cell_templet";
            ds = new DataSet("���ݵ���");
            ds.Tables.Add(tFileSet);
            ds.Tables.Add(tModelSet);
            //foreach (DataRow tFileRow in tFileSet.Rows) {
            //    AllPath.Add(tFileRow["id"].ToString());
            //}
            //foreach (DataRow tModelRow in tModelSet.Rows) {
            //    archiveNodes.Add(tModelRow["id"].ToString());
            //}
        }

        private void GetChildNodes( TreeNodeEx child)
        {
            for(int i =0 ;i<child.Nodes.Count;i++)
            {
                if (child.Nodes[i].ImageIndex == 1)
                {
                    if (!(child.Tag as DigiPower.ERM.Model.FileRecording_Templet).zrr.StartsWith("ϵͳ����Ա"))
                        continue;
                    else
                    {
                        AllPath.Add(child.Nodes[i].Name);
                        GetChildNodes((TreeNodeEx)child.Nodes[i]);

                    }
                }
                else
                {
                    AllPath.Add(child.Nodes[i].Name);
                    archiveNodes.Add(child.Nodes[i].Name);
                }
            }
        }
        #endregion

        List<string> AllPath= new List<string>();
        #region ���������ҽڵ㣬�ҵ�����·��
        private void GetAllParent(TreeNode  node)
        {
            if (!AllPath.Contains(node.Name))
            {
                AllPath.Add(node.Name);

            }
            if (node.Name != "01")
                GetAllParent(node.Parent);
        }
        #endregion


        private void btnExplorer_Click(object sender, EventArgs e)
        {
            //if (TheNode != null)
            //{
            //    //saveFileDialog1.FileName = projectFactory.ProjectDetail["projectname"].ToString() + /*GetParentName(TheNode) + "-" +*/ TheNode.Text + "(" + DateTime.Now.ToString("yyyyMMdd") + ")";
            //    //saveFileDialog1.FileName = saveFileDialog1.FileName.Replace("--", "-");
            //}
            //else
            //{
            //    saveFileDialog1.FileName = projectFactory.ProjectDetail["projectname"].ToString() + "-" + "(" + DateTime.Now.ToString("yyyyMMdd") + ")";
            //}
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtLoc.Text = saveFileDialog1.FileName;
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                //�����ж�
                txtLoc.Text = txtLoc.Text.Trim();
                if (txtLoc.Text == "")
                {
                    Functions.ShowWarning("��ѡ�񵼳��ļ��Ĵ洢·����");
                    txtLoc.Focus();
                    return;
                }

                //������ļ���
                string destFilename = Functions.GetFileShortName(txtLoc.Text);

                //�����Ŀ¼
                destFolder = txtLoc.Text.Substring(0, txtLoc.Text.Length - destFilename.Length - 1);

                //�ж�Ŀ¼�Ƿ����
                if (!Directory.Exists(destFolder))
                {
                    Functions.ShowWarning("�洢��·�������ڣ�");
                    return;
                }

                //�����Ŀ¼�½�һ����ʱ�ļ���
                Directory.CreateDirectory(destFolder + "\\temp");

                //����XML�ļ�
                //PlugIn plugin = new PlugIn();

                //����ʹ������


                string fileName = destFolder + "\\temp\\" + System.DateTime.Now.ToString("yyyyMMdd") + @".XML";

                lblTitle.Text = @"���ڻ�ȡ����.....";

                btnCancel.Enabled = false;
                btnConfirm.Enabled = false;
                btnExplorer.Enabled = false;
                //Application.DoEvents();
                //ֻ���ж��Ƿ�Ϊ��Ŀ¼
                if (!CheckGdfw())
                {
                    Functions.ShowWarning("�ýڵ㲻���ڹ鵵��Χ��");
                    this.DialogResult = DialogResult.Cancel;
                    return;
                }
                //treeFactory.RefreshNode(TheNode, "", "", true, "", true);                    
                //GetNodes();
                //if (archiveNodes.Count == 0)
                //{
                //    Functions.ShowWarning("û���ҵ�Ҫ���������ݣ�");
                //    this.DialogResult = DialogResult.Cancel;
                //    return;
                //}

                //�ҵ�ѡ���Ľڵ�

                this.Cursor = Cursors.WaitCursor;

                //CreateData(destFolder + @"\temp");


                //ds.WriteXml(fileName, XmlWriteMode.WriteSchema);

                Common.CopyDir.GetTemplet(destFolder + @"\temp\GDTemplet", Globals.CellPath);//����ģ��
                FileInfo tFileInfo = new FileInfo(Globals.MDBPath);
                Directory.CreateDirectory(destFolder + @"\temp\db");//�������ݿ��ļ���
                tFileInfo.CopyTo(destFolder + @"\temp\db\" + tFileInfo.Name);//�������ݿ�

            //    //ѹ��tempĿ¼
                DigiPower.ERM.Common.ZipFile zip = new  DigiPower.ERM.Common.ZipFile(destFolder + "\\temp", txtLoc.Text);
                zip.StartZip();

            //    //ɾ��tempĿ¼
                Directory.Delete(destFolder + "\\temp", true);

                //treeFactory.RefreshNode(TheNode, "", "", true, Globals.OpenedProjectNo, true, true);                    

                //this.Dispose();
                this.Cursor = Cursors.Default;

                this.DialogResult = DialogResult.OK;


            }
            catch (Exception ex)
            {
                Directory.Delete(destFolder + "\\temp", true);
                Functions.ShowErrors(ex);
                this.Dispose();
                this.DialogResult = DialogResult.Cancel;
            }

        }

        /// <summary>
        /// ���ýڵ������ļ��Ƿ�Ϊ���뵼���ķ�Χ
        /// </summary>
        private bool CheckGdfw()
        {
            TreeNode pNode = TheNode;
            if (TheNode.ImageIndex == 2)
                pNode = TheNode.Parent;
            if (!(pNode.Tag as DigiPower.ERM.Model.FileRecording_Templet).zrr.StartsWith("ϵͳ����Ա"))
            {
                return false;
            }
            else
                return true;
        }


        /// <summary>
        /// ��list/string/ת��SQL �е�in��ʽ
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        private string SetList2SqlIn(List<string> list)
        {
            string strlist = "";
            foreach (string str in list)
            {
                strlist += ("'" + str + "',");
            }
            return strlist;
        }

        /// <summary>
        /// �����ļ��븽��֮��Ĺ�ϵ
        /// </summary>
        private void CreateData(string destfile)
        {
            ds = new DataSet("���ݵ���");

            CreateErr();

            //DataTable pdt = new DigiPower.ERM.BLL.Projects().GetList("  projectno='" + Globals.OpenedProjectNo + "'").Tables[0];

            //pdt.TableName = "Projects";

            //pdt.AcceptChanges();

            //ds.Tables.Add(pdt.Copy());


            string str = SetList2SqlIn(AllPath).Trim(',').Trim();
            DataTable pdtPath = exportData.GetExportPath("", str).Tables[0];

            pdtPath.TableName = "Path";

            pdtPath.AcceptChanges();

            ds.Tables.Add(pdtPath.Copy());
            //����ģ��

            DataView dv = new DataView(pdtPath);
            List<string> liststring = new List<string>();
            foreach (DataRowView dr in dv)
            {
                if (dr["imageindex"].ToString() == "2")
                {
                    if (dr["filepath"].ToString().Trim() != "")
                    {
                        if (!liststring.Contains(dr["filepath"].ToString()))
                        {
                            liststring.Add(dr["filepath"].ToString());
                            //��������ϣ�������������ʱ��Ӵ���
                            if (!DigiPower.ERM.Common.FileCopy.CopyFile(destfile + dr["filepath"].ToString(), Globals.CellPath + dr["filepath"].ToString()))
                            {
                                AddErr(dr["id"].ToString(), dr["title"].ToString(),"2",dr["parentid"].ToString(), dr["filepath"] + " ����ʱ�����쳣");
                            }
                        }
                    }
                }
            }


             str = SetList2SqlIn(archiveNodes).Trim(',').Trim();
             if (str != "")//����û���û����ı��
             {
                 DataTable pdtArchiveData = exportData.GetExportData("", str).Tables[0];

                 pdtArchiveData.TableName = "ArchiveData";

                 pdtArchiveData.AcceptChanges();

                 ds.Tables.Add(pdtArchiveData.Copy());


                 #region �����ļ���Ŀ¼��Ϣ
                 if (pdtArchiveData != null)
                 {

                     lblTitle.Text = @"���ڻ�ȡ�ļ�����.....";
                     progressBar1.Value = 0;
                     progressBar1.Maximum = 100;
                     Application.DoEvents();

                     dv = new DataView(pdtArchiveData);
                     foreach (DataRowView drv in dv) 
                     {

                         if (progressBar1.Value >= 100)
                         {
                             progressBar1.Value = 0;
                         }

                         progressBar1.Value = progressBar1.Value + 1;
                         Application.DoEvents();

                         //��������ϣ�������������ʱ��Ӵ���
                         if (!DigiPower.ERM.Common.FileCopy.CopyFile(destfile + drv["filepath"].ToString(), Globals.ProjectPath + drv["filepath"].ToString()))
                         {
                             AddErr(drv["id"].ToString(), drv["title"].ToString(),"3",drv["cellparentid"].ToString(), drv["filepath"] + " ����ʱ�����쳣");
                         }
                     }
                 }
                 #endregion

             }

        }


        public DataTable dtErr;

        private void CreateErr()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("xh", typeof(Int32));
            dt.Columns.Add("nodeid", typeof(string));
            dt.Columns.Add("title", typeof(string));
            dt.Columns.Add("errorinfo", typeof(string));
            dt.Columns.Add("imageindex" ,typeof(Int32));
            dt.Columns.Add("parentid", typeof(string));
            dt.Columns[0].AutoIncrementSeed = 1;
            dt.Columns[0].AutoIncrement = true;
            dt.Columns[0].AutoIncrementStep = 1;
            dt.AcceptChanges();
            dtErr = dt;

        }

        private void AddErr( string nodeid, string title,string imageindex,string parentid, string errorinfo)
        {
            DataRow dr = dtErr.NewRow();
            dr["nodeid"] = nodeid;
            dr["title"] = title;
            dr["imageindex"] = imageindex;
            dr["parentid"] = parentid;
            dr["errorinfo"] = errorinfo;
            dtErr.Rows.Add(dr);
            dtErr.AcceptChanges();

        }

    }

}