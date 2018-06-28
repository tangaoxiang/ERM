using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using System.Threading;
using ERM.Common;
using System.Collections;
using TX.Framework.WindowUI.Forms;

namespace ERM.UI
{
    public partial class frmImpData : ERM.UI.Controls.Skin_DevEX
    {
        #region �����Զ���
        #endregion

        #region ���庯��
        #endregion

        #region �Զ��庯��
        #endregion

        private string Infile = "";
        private DataSet ds = new DataSet();
        TreeNode SelectTreeNode = null;
        string TreeNodeState_flg;//��ǰĿ¼״̬ 0 ��ʾȫ�� 1�޵����ļ� 2�е����ļ� 3 
        int EFCount_flg = 0;

        public frmImpData(TreeNode CureNode, string NodeState_flg, int EFileCount_flg)
        {
            InitializeComponent();
            if (Globals.ProjectNO != "")
            {
                this.Text += "-" + Globals.Projectname;
            }
            SelectTreeNode = CureNode;
            TreeNodeState_flg = NodeState_flg;
            EFCount_flg = EFileCount_flg;
        }
        private void btnExplorer_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "������NOD��(*.nod) | *.nod";
            openFileDialog1.Title = "���ݵ���";
            openFileDialog1.FileName = "";
            DialogResult ret = openFileDialog1.ShowDialog();
            if (ret == DialogResult.OK)
            {
                Infile = openFileDialog1.FileName;
                txtLoc.Text = Infile;
            }
        }

        bool chk_DBPath = true;
        /// <summary>
        /// �ݹ��ȡ��T_FileList�ļ�����һ��
        /// </summary>
        /// <param name="IntoPath"></param>
        /// <param name="FileList_tempPath"></param>
        private void GetIntoFileListPath(string IntoPath, ref string FileList_tempPath)
        {
            if (chk_DBPath)
            {
                if (System.IO.Directory.Exists(IntoPath + "\\T_FileList"))
                {
                    chk_DBPath = false;
                    FileList_tempPath = IntoPath;
                    return;
                }
                DirectoryInfo IntoDirectory = new DirectoryInfo(IntoPath);
                foreach (DirectoryInfo into_temp in IntoDirectory.GetDirectories())
                {
                    GetIntoFileListPath(into_temp.FullName, ref FileList_tempPath);
                }
            }
        }

        int curStateIndex = 0;//״̬��ֵ
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (!System.IO.File.Exists(txtLoc.Text))
            {
                TXMessageBoxExtensions.Info("��ʾ�������ļ������ڣ�");
                btnCancel.Enabled = true;
                return;
            }
            /// <summary>
            /// ���빦���漰���ļ���ʱ���Ŀ¼
            /// </summary>

            string ImptempPath =
                Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "\\ERM\\ImpDataTemp\\";
            try
            {
                string[] fileList = Directory.GetDirectories(ImptempPath);

                if (Directory.Exists(ImptempPath))
                {
                    MyCommon.DeleteFilesAndFolders(ImptempPath);
                    Directory.CreateDirectory(ImptempPath);
                }
            }
            catch (Exception ex)
            {
                TXMessageBoxExtensions.Info(ex.Message.ToString());
            }

            Directory.CreateDirectory(ImptempPath);
            lblTitle.Text = @"���ڽ�ѹ��ǰ������ʱĿ¼.....";
            btnCancel.Enabled = false;
            btnConfirm.Enabled = false;
            btnExplorer.Enabled = false;
            Application.DoEvents();

            DirectoryInfo dir = new DirectoryInfo(ImptempPath);
            if (Directory.Exists(dir.FullName))
                MyCommon.DeleteAndCreateEmptyDirectory(dir.FullName, false);
            MyCommon.DeleteAndCreateEmptyDirectory(dir.FullName, true);

            //UpZipFile unZip = new Common.UpZipFile(txtLoc.Text, ImptempPath);
            //unZip.StartUnZip();

            using (SevenZip.SevenZipExtractor tmp = new SevenZip.SevenZipExtractor(txtLoc.Text))
            {
                SevenZip.SevenZipExtractor.SetLibraryPath(Application.StartupPath + "\\7z.dll");
                for (int i = 0; i < tmp.ArchiveFileData.Count; i++)
                {
                    tmp.ExtractFiles(ImptempPath, tmp.ArchiveFileData[i].Index);
                    lblTitle.Text = "���ڽ�ѹ�ļ���" + tmp.ArchiveFileData[i].FileName;
                    Application.DoEvents();
                }
            }
            System.Threading.Thread.Sleep(1000);

            string[] ParentfileList = System.IO.Directory.GetDirectories(dir.FullName);
            curStateIndex = 0;
            if (ParentfileList != null && ParentfileList.Length > 0)
            {
                string IntoFileTemp_ID = ParentfileList[0];
                if (!System.IO.Directory.Exists(ParentfileList[0] + "\\T_FileList"))
                {
                    chk_DBPath = true;
                    GetIntoFileListPath(ParentfileList[0], ref IntoFileTemp_ID);

                    if (IntoFileTemp_ID != ParentfileList[0])
                        ParentfileList[0] = IntoFileTemp_ID;
                }

                DirectoryInfo ParentFile_dir = new DirectoryInfo(ParentfileList[0]);
                string parentFileID = ParentFile_dir.Name;//���ڵ�ID
                if (Directory.Exists(ParentFile_dir.FullName))
                {
                    bool checkfile_flg = true;
                    int sumfileCount = 0;
                    MyCommon.GetFileCount(ParentFile_dir.FullName + "\\T_FileList\\", ref checkfile_flg, ref sumfileCount);

                    if (checkfile_flg && sumfileCount > 0)
                    {
                        progressBar1.Maximum = sumfileCount;
                        DataSet file_ds = new DataSet();//�ļ�Ŀ¼��Ϣ��

                        if (Directory.Exists(ParentFile_dir.FullName + "\\T_FileList\\"))
                        {
                            string[] fileList =
                                System.IO.Directory.GetFiles(ParentFile_dir.FullName + "\\T_FileList\\");
                            foreach (string file in fileList)
                            {
                                FileInfo fInfo = new FileInfo(file);
                                if (fInfo.Extension.ToLower() == ".xml")//���Ǳ��¼
                                {
                                    DataSet ds = new DataSet();
                                    ds.ReadXml(file, XmlReadMode.ReadSchema);
                                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                                    {
                                        if (file_ds.Tables["T_FileList"] == null)
                                        {
                                            DataTable file_tb = new DataTable();
                                            file_tb = ds.Tables[0].Clone();
                                            file_tb.TableName = "T_FileList";
                                            file_ds.Tables.Add(file_tb);
                                        }
                                        foreach (DataRow file_row in ds.Tables[0].Rows)//�ռ��ļ���Ϣ
                                        {
                                            file_ds.Tables["T_FileList"].ImportRow(file_row);
                                        }
                                    }
                                }
                            }
                            if (Directory.Exists(ParentFile_dir.FullName + "\\T_CellAndEFile\\"))
                            {
                                string[] cellList =
                                    System.IO.Directory.GetFiles(ParentFile_dir.FullName + "\\T_CellAndEFile\\");
                                foreach (string cell in cellList)
                                {
                                    FileInfo fInfo = new FileInfo(cell);
                                    if (fInfo.Extension.ToLower() == ".xml")//���Ǳ��¼
                                    {
                                        DataSet ds = new DataSet();
                                        ds.ReadXml(cell, XmlReadMode.ReadSchema);
                                        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                                        {
                                            if (file_ds.Tables["T_CellAndEFile"] == null)
                                            {
                                                DataTable CellAndEFile_tb = new DataTable();
                                                CellAndEFile_tb = ds.Tables[0].Clone();
                                                CellAndEFile_tb.TableName = "T_CellAndEFile";
                                                file_ds.Tables.Add(CellAndEFile_tb);
                                            }
                                            foreach (DataRow efile_row in ds.Tables[0].Rows)//�ռ������ļ���Ϣ
                                            {
                                                file_ds.Tables["T_CellAndEFile"].ImportRow(efile_row);
                                            }
                                        }
                                    }
                                }
                            }

                            if (Directory.Exists(ParentFile_dir.FullName + "\\T_GdList\\"))
                            {
                                string[] GdList =
                                    System.IO.Directory.GetFiles(ParentFile_dir.FullName + "\\T_GdList\\");
                                foreach (string gd in GdList)
                                {
                                    FileInfo fInfo = new FileInfo(gd);
                                    if (fInfo.Extension.ToLower() == ".xml")//���Ǳ��¼
                                    {
                                        DataSet ds = new DataSet();
                                        ds.ReadXml(gd, XmlReadMode.ReadSchema);
                                        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                                        {
                                            if (file_ds.Tables["T_GdList"] == null)
                                            {
                                                DataTable GdList_tb = new DataTable();
                                                GdList_tb = ds.Tables[0].Clone();
                                                GdList_tb.TableName = "T_GdList";
                                                file_ds.Tables.Add(GdList_tb);
                                            }
                                            foreach (DataRow efile_row in ds.Tables[0].Rows)//�ռ������ļ���Ϣ
                                            {
                                                file_ds.Tables["T_GdList"].ImportRow(efile_row);
                                            }
                                        }
                                    }
                                }
                            }

                            /***********************************************************************************************
                             * ˵����������֤ƥ��
                             *******************************************************************************/
                            #region �������롢����
                            //DataRow[] file_rows = file_ds.Tables["T_FileList"].Select("FileID='" + parentFileID + "'");
                            //if (file_rows != null && file_rows.Length > 0)
                            //{
                            //    try
                            //    {
                            //        MDL.T_FileList fileMDL = (new BLL.T_FileList_BLL()).Find(SelectTreeNode.Name, Globals.ProjectNO);
                            //        if (fileMDL == null)
                            //        {
                            //            TXMessageBoxExtensions.Info("��ʾ��ѡ����Ľڵ���Ч��������ѡ��ڵ㵼�룡��");
                            //            return;
                            //        }
                            //        if (fileMDL.wjtm != file_rows[0]["wjtm"].ToString() || Globals.ProjectNO != file_rows[0]["ProjectNO"].ToString())
                            //        {
                            //            DialogResult Dialog =
                            //                TXMessageBoxExtensions.Question("��ʾ������ͬһ�ڵ��ͬ���̽ڵ�֮�䵼�룡 �Ƿ��������\n    ����ܰ��ʾ����ڵ��繤�̵��������أ���");
                            //            if (Dialog != DialogResult.OK)
                            //                return;
                            //        }

                            //        DataTable tbl_FileList = file_ds.Tables["T_FileList"];
                            //        DataTable tbl_CellAndEFile = file_ds.Tables["T_CellAndEFile"];
                            //        DataTable tbl_TempFileLis = null;//ģ���
                            //        DataTable tbl_TempCellAndEFile = null;//ģ��� ��Ҫ����������ʵ������
                            //        if (tbl_FileList != null && tbl_FileList.Rows.Count > 0)
                            //            tbl_TempFileLis = tbl_FileList.Clone();
                            //        if (tbl_CellAndEFile != null && tbl_CellAndEFile.Rows.Count > 0)
                            //            tbl_TempCellAndEFile = tbl_CellAndEFile.Clone();//

                            //        if (file_rows[0]["isvisible"].ToString() == "1")//�ļ�������
                            //        {
                            //            ImpDataInfo(tbl_FileList, tbl_CellAndEFile,
                            //                parentFileID, tbl_TempFileLis, tbl_TempCellAndEFile,
                            //                SelectTreeNode.Name, ParentFile_dir.FullName + "\\T_CellAndEFile\\", false);

                            //            if (EFCount_flg == 1)//�����ñ�
                            //            {
                            //                if (SelectTreeNode.ImageIndex != 0 && SelectTreeNode.ImageIndex != 1)
                            //                {
                            //                    SelectTreeNode.ImageIndex = ((new TreeFactory()).CheckEFileByFileID(SelectTreeNode.Name) == true) ? 7 : 2;//�ж��Ƿ��е����ļ�
                            //                    SelectTreeNode.SelectedImageIndex = SelectTreeNode.ImageIndex;
                            //                }
                            //                else if (SelectTreeNode.ImageIndex == 0 || SelectTreeNode.ImageIndex == 1)
                            //                {
                            //                    //ˢ�½ڵ�
                            //                    (new TreeFactory()).InitTree(Globals.ProjectNO, TreeNodeState_flg, SelectTreeNode,
                            //                        true, EFCount_flg, true);
                            //                }
                            //            }
                            //            else//�ļ��Ǽ�
                            //            {
                            //                if (SelectTreeNode.ImageIndex != 0 && SelectTreeNode.ImageIndex != 1)
                            //                {
                            //                    TreeFactory tfactory = new TreeFactory();
                            //                    SelectTreeNode.ImageIndex = (tfactory.CheckEFileByFileID(SelectTreeNode.Name) == true) ? 7 : 2;//�ж��Ƿ��е����ļ�
                            //                    SelectTreeNode.SelectedImageIndex = SelectTreeNode.ImageIndex;
                            //                    tfactory.GetCellFileNodesCount((TreeNodeEx)SelectTreeNode, true);
                            //                }
                            //                else if (SelectTreeNode.ImageIndex == 0 || SelectTreeNode.ImageIndex == 1)
                            //                {
                            //                    //ˢ�½ڵ�
                            //                    (new TreeFactory()).InitTree(Globals.ProjectNO, TreeNodeState_flg, SelectTreeNode,
                            //                        true, EFCount_flg, true);
                            //                }
                            //            }
                            //        }
                            //        else//�ļ��м�����
                            //        {
                            //            ImpDataInfo(tbl_FileList, tbl_CellAndEFile,
                            //                parentFileID, tbl_TempFileLis, tbl_TempCellAndEFile,
                            //                SelectTreeNode.Name, ParentFile_dir.FullName + "\\T_CellAndEFile\\", true);

                            //            //ˢ�½ڵ�
                            //            (new TreeFactory()).InitTree(Globals.ProjectNO, TreeNodeState_flg, SelectTreeNode,
                            //                true, EFCount_flg, true);
                            //        }
                            //    }
                            //    catch
                            //    {
                            //        //�������Ϣ�д���
                            //        this.DialogResult = DialogResult.Cancel;
                            //    }
                            //}
                            #endregion

                            #region �������룬����
                            ///�����ڵ�˵����
                            ///1.�����Ľڵ�Ϊ���ڵ㣨ֻ�ܶ�Ӧ���ڵ㣩
                            ///2.�����Ľڵ�Ϊ�鵵��𣨶�Ӧ���ڵ㣬�鵵���
                            ///3.�����Ľڵ�Ϊ�ļ�����Ӧ�������������
                            ///
                            ///���սڵ�˵����
                            ///1.���յĽڵ�Ϊ���ڵ�
                            ///2.���յĽڵ�Ϊ�鵵���
                            ///3.���յĽڵ�Ϊ�ļ�
                            ///
                            DataTable tbl_GdList = file_ds.Tables["T_GdList"];
                            DataTable tbl_FileList = file_ds.Tables["T_FileList"];
                            DataTable tbl_CellAndEFile = file_ds.Tables["T_CellAndEFile"];
                            DataTable tbl_TempFileLis = null;//ģ���
                            DataTable tbl_TempCellAndEFile = null;//ģ��� ��Ҫ����������ʵ������

                            if (tbl_FileList != null && tbl_FileList.Rows.Count > 0)
                                tbl_TempFileLis = tbl_FileList.Clone();
                            if (tbl_CellAndEFile != null && tbl_CellAndEFile.Rows.Count > 0)
                                tbl_TempCellAndEFile = tbl_CellAndEFile.Clone();//
                            string efilePath = ParentFile_dir.FullName + "\\T_CellAndEFile\\";

                            DataRow[] file_rows = tbl_FileList.Select("FileID='" + parentFileID + "'");
                            if (file_rows != null && file_rows.Length > 0)
                            {
                                #region ����Ϊ�ļ� �� ��Ŀ¼
                                try
                                {
                                    MDL.T_FileList fileMDL = fileImp_BLL.Find(SelectTreeNode.Name, Globals.ProjectNO);
                                    if (fileMDL != null)
                                    {
                                        if (string.IsNullOrEmpty(fileMDL.ParentID) ||
                                            fileMDL.ParentID.ToString().Trim() == "")
                                        {
                                            TXMessageBoxExtensions.Info("��ʾ���ļ���ֻ���������鵵����У�");
                                            btnCancel.Enabled = true;
                                            return;
                                        }
                                        if (fileMDL.wjtm != file_rows[0]["wjtm"].ToString() || Globals.ProjectNO != file_rows[0]["ProjectNO"].ToString())
                                        {
                                            DialogResult Dialog =
                                                TXMessageBoxExtensions.Question("��ʾ������ [ͬһ�ڵ�] �� [ͬ���̽ڵ�] ֮�䵼�룡 �Ƿ������ \n  ����ܰ��ʾ����ڵ��繤�̵��������أ���");
                                            btnCancel.Enabled = true;
                                            if (Dialog != DialogResult.OK)
                                                return;
                                        }
                                        #region ����Ϊ�ļ� �����ļ��ڵ�
                                        if (tbl_CellAndEFile != null && tbl_CellAndEFile.Rows.Count > 0)
                                        {
                                            DataRow[] efile_rows =
                                                tbl_CellAndEFile.Select("GdFileID='" + parentFileID + "'", "GdOrderIndex asc");//����ڵ��µĵ����ļ�

                                            if (efile_rows != null && efile_rows.Length > 0)
                                            {
                                                tbl_TempCellAndEFile.Rows.Clear();
                                                foreach (DataRow efile_row in efile_rows)
                                                {
                                                    tbl_TempCellAndEFile.ImportRow(efile_row);
                                                }

                                                IList<MDL.T_CellAndEFile> efileMDL_List =
                                                        MyCommon.DataTableToList<MDL.T_CellAndEFile>(tbl_TempCellAndEFile);//ת���ڵ��µ����ļ���¼

                                                if (efileMDL_List != null && efileMDL_List.Count > 0)
                                                {
                                                    foreach (MDL.T_CellAndEFile obj_efile in efileMDL_List)
                                                    {
                                                        if (obj_efile.filepath == null || obj_efile.filepath.Trim() == "")
                                                            continue;

                                                        obj_efile.CellID = Guid.NewGuid().ToString();
                                                        obj_efile.FileID = fileMDL.FromFileID;
                                                        obj_efile.GdFileID = fileMDL.FileID;

                                                        if (obj_efile.DocYs != 1)
                                                        {
                                                            obj_efile.DocYs = 0;
                                                            obj_efile.DoStatus = 1;

                                                            if (File.Exists(efilePath + obj_efile.filepath))
                                                            {
                                                                string efileExt = System.IO.Path.GetExtension(efilePath + obj_efile.filepath);
                                                                System.IO.File.Copy(efilePath + obj_efile.filepath,
                                                                    Globals.ProjectPath + "ODOC\\" + obj_efile.CellID + efileExt, true);//������ǰ�����ļ�
                                                                obj_efile.filepath = "ODOC\\" + obj_efile.CellID + efileExt;
                                                            }
                                                            else
                                                            {
                                                                obj_efile.filepath = "";
                                                            }
                                                        }
                                                        else
                                                        {
                                                            obj_efile.DocYs = 0;
                                                            obj_efile.DoStatus = 1;

                                                            if (File.Exists(efilePath + obj_efile.filepath))
                                                            {
                                                                string efileExt = System.IO.Path.GetExtension(efilePath + obj_efile.filepath);
                                                                System.IO.File.Copy(efilePath + obj_efile.filepath,
                                                                    Globals.ProjectPath + "ODOC\\" + obj_efile.CellID + efileExt, true);//������ǰ�����ļ�
                                                                obj_efile.filepath = "ODOC\\" + obj_efile.CellID + efileExt;
                                                            }
                                                            else
                                                            {
                                                                obj_efile.filepath = "";
                                                            }

                                                            if (File.Exists(efilePath + obj_efile.fileTreePath))
                                                            {
                                                                string efileExt = System.IO.Path.GetExtension(efilePath + obj_efile.fileTreePath);
                                                                System.IO.File.Copy(efilePath + obj_efile.fileTreePath,
                                                                    Globals.ProjectPath + "PDF\\" + obj_efile.CellID + efileExt, true);//������ǰ�����ļ�
                                                                obj_efile.fileTreePath = "PDF\\" + obj_efile.CellID + efileExt;
                                                            }
                                                            else
                                                            {
                                                                obj_efile.fileTreePath = "";
                                                                obj_efile.DocYs = 1;//��������PDF
                                                            }
                                                        }
                                                        obj_efile.ProjectNO = Globals.ProjectNO;
                                                        obj_efile.orderindex =
                                                            CEfileImp_BLL.GetMaxOrderIndex(fileMDL.FromFileID, Globals.ProjectNO) + 1;
                                                        obj_efile.GdOrderIndex =
                                                            CEfileImp_BLL.GetMaxGdFileOrderIndex(obj_efile.GdFileID, Globals.ProjectNO) + 1;

                                                        CEfileImp_BLL.Insert(obj_efile);
                                                        //���ԭ����Ϣ
                                                        MyCommon.InsertOldEfile(obj_efile.CellID,  Globals.ProjectNO, Globals.LoginUser, "�ļ��Ǽ�-�����1", obj_efile.filepath);    

                                                    }
                                                    fileMDL.selected = 1;//�����˵����ļ� �޸�Ŀ¼״̬
                                                    fileImp_BLL.Update(fileMDL);
                                                }
                                            }
                                        }
                                        #endregion
                                    }
                                    else
                                    {
                                        MDL.T_GdList gdList_MDL =
                                            (new BLL.T_GdList_BLL()).FindIDAndProjectNo(SelectTreeNode.Name, Globals.ProjectNO);
                                        if (gdList_MDL != null)
                                        {
                                            #region ����Ϊ�ļ� ����鵵���
                                            tbl_TempFileLis.Rows.Clear();
                                            tbl_TempFileLis.ImportRow(file_rows[0]);

                                            IList<MDL.T_FileList> fileMDL_List =
                                                MyCommon.DataTableToList<MDL.T_FileList>(tbl_TempFileLis);

                                            if (fileMDL_List != null && fileMDL_List.Count > 0)
                                            {
                                                fileMDL_List[0].FileID = Guid.NewGuid().ToString();

                                                if (tbl_CellAndEFile != null && tbl_CellAndEFile.Rows.Count > 0)
                                                {
                                                    #region �����ļ�
                                                    DataRow[] efile_rows =
                                                        tbl_CellAndEFile.Select("GdFileID='" + parentFileID + "'", "GdOrderIndex asc");//����ڵ��µĵ����ļ�

                                                    if (efile_rows != null && efile_rows.Length > 0)
                                                    {
                                                        tbl_TempCellAndEFile.Rows.Clear();
                                                        foreach (DataRow efile_row in efile_rows)
                                                        {
                                                            tbl_TempCellAndEFile.ImportRow(efile_row);
                                                        }
                                                        IList<MDL.T_CellAndEFile> efileMDL_List =
                                                                MyCommon.DataTableToList<MDL.T_CellAndEFile>(tbl_TempCellAndEFile);//ת���ڵ��µ����ļ���¼

                                                        if (efileMDL_List != null && efileMDL_List.Count > 0)
                                                        {
                                                            foreach (MDL.T_CellAndEFile obj_efile in efileMDL_List)
                                                            {
                                                                if (obj_efile.filepath == null || obj_efile.filepath.Trim() == "")
                                                                    continue;

                                                                obj_efile.CellID = Guid.NewGuid().ToString();
                                                                obj_efile.FileID = fileMDL_List[0].FromFileID;
                                                                obj_efile.GdFileID = fileMDL_List[0].FileID;

                                                                if (obj_efile.DocYs != 1)
                                                                {
                                                                    obj_efile.DocYs = 0;
                                                                    obj_efile.DoStatus = 1;

                                                                    if (File.Exists(efilePath + obj_efile.filepath))
                                                                    {
                                                                        string efileExt = System.IO.Path.GetExtension(efilePath + obj_efile.filepath);
                                                                        System.IO.File.Copy(efilePath + obj_efile.filepath,
                                                                            Globals.ProjectPath + "ODOC\\" + obj_efile.CellID + efileExt, true);//������ǰ�����ļ�
                                                                        obj_efile.filepath = "ODOC\\" + obj_efile.CellID + efileExt;
                                                                    }
                                                                    else
                                                                    {
                                                                        obj_efile.filepath = "";
                                                                    }
                                                                }
                                                                else
                                                                {
                                                                    obj_efile.DocYs = 0;
                                                                    obj_efile.DoStatus = 1;

                                                                    if (File.Exists(efilePath + obj_efile.filepath))
                                                                    {
                                                                        string efileExt = System.IO.Path.GetExtension(efilePath + obj_efile.filepath);
                                                                        System.IO.File.Copy(efilePath + obj_efile.filepath,
                                                                            Globals.ProjectPath + "ODOC\\" + obj_efile.CellID + efileExt, true);//������ǰ�����ļ�
                                                                        obj_efile.filepath = "ODOC\\" + obj_efile.CellID + efileExt;
                                                                    }
                                                                    else
                                                                    {
                                                                        obj_efile.filepath = "";
                                                                    }

                                                                    if (File.Exists(efilePath + obj_efile.fileTreePath))
                                                                    {
                                                                        string efileExt = System.IO.Path.GetExtension(efilePath + obj_efile.fileTreePath);
                                                                        System.IO.File.Copy(efilePath + obj_efile.fileTreePath,
                                                                            Globals.ProjectPath + "PDF\\" + obj_efile.CellID + efileExt, true);//������ǰ�����ļ�
                                                                        obj_efile.fileTreePath = "PDF\\" + obj_efile.CellID + efileExt;
                                                                    }
                                                                    else
                                                                    {
                                                                        obj_efile.fileTreePath = "";
                                                                        obj_efile.DocYs = 1;//��������PDF
                                                                    }
                                                                }
                                                                obj_efile.ProjectNO = Globals.ProjectNO;
                                                                obj_efile.orderindex =
                                                                    CEfileImp_BLL.GetMaxOrderIndex(fileMDL_List[0].FromFileID, Globals.ProjectNO) + 1;
                                                                obj_efile.GdOrderIndex =
                                                                    CEfileImp_BLL.GetMaxGdFileOrderIndex(fileMDL_List[0].FileID, Globals.ProjectNO) + 1;

                                                                CEfileImp_BLL.Insert(obj_efile);

                                                                //���ԭ����Ϣ
                                                                MyCommon.InsertOldEfile(obj_efile.CellID,  Globals.ProjectNO, Globals.LoginUser, "�ļ��Ǽ�-�����2", obj_efile.filepath);   
                                                            }
                                                        }
                                                    }
                                                    #endregion
                                                }
                                                fileMDL_List[0].ArchiveID = "";
                                                if (fileMDL_List[0].fileStatus == "4" || fileMDL_List[0].fileStatus == "6")
                                                    fileMDL_List[0].fileStatus = "4";
                                                else
                                                    fileMDL_List[0].fileStatus = "0";

                                                if (fileMDL_List[0].filepath != null && fileMDL_List[0].filepath.Trim() != "")
                                                {
                                                    string efileExt = System.IO.Path.GetExtension(efilePath + fileMDL_List[0].filepath);

                                                    if (File.Exists(efilePath + fileMDL_List[0].filepath))
                                                    {
                                                        System.IO.File.Copy(efilePath + fileMDL_List[0].filepath,
                                                                    Globals.ProjectPath + "MPDF\\" + fileMDL_List[0].FileID + efileExt, true);//������ǰ�����ļ�
                                                        fileMDL_List[0].filepath = "MPDF\\" + fileMDL_List[0].FileID + efileExt;
                                                    }

                                                }

                                                fileMDL_List[0].OrderIndex =
                                                    fileImp_BLL.GetMaxOrderIndex(fileMDL_List[0].ParentID, Globals.ProjectNO) + 1;
                                                fileMDL_List[0].GdFileOrderIndex =
                                                    fileImp_BLL.GetMaxGdFileOrderIndex(SelectTreeNode.Name, Globals.ProjectNO) + 1;
                                                fileMDL_List[0].GDID = SelectTreeNode.Name;//�޸ĸ��ڵ�
                                                fileMDL_List[0].ProjectNO = Globals.ProjectNO;
                                                fileImp_BLL.Insert(fileMDL_List[0]);
                                            }
                                            #endregion
                                        }
                                        else
                                        {
                                            TXMessageBoxExtensions.Info("��ʾ��ѡ����Ľڵ���Ч��������ѡ��ڵ㵼�룡��");
                                            btnCancel.Enabled = true;
                                            return;
                                        }
                                    }
                                }
                                catch
                                {
                                    //�������Ϣ�д���
                                    this.DialogResult = DialogResult.Cancel;
                                }
                                #endregion
                            }
                            else
                            {
                                DataRow[] gd_rows = tbl_GdList.Select("ID='" + parentFileID + "'");
                                if (gd_rows != null && gd_rows.Length > 0)
                                {
                                    #region ����Ϊ���鵵���
                                    try
                                    {
                                        MDL.T_FileList fileMDL = fileImp_BLL.Find(SelectTreeNode.Name, Globals.ProjectNO);
                                        if (fileMDL != null)
                                        {
                                            if (Globals.ProjectNO != gd_rows[0]["ProjectNo"].ToString())
                                            {
                                                DialogResult Dialog =
                                                    TXMessageBoxExtensions.Question("��ʾ������ [ͬһ�ڵ�] �� [ͬ���̽ڵ�] ֮�䵼�룡 �Ƿ������ \n  ����ܰ��ʾ����ڵ��繤�̵��������أ���");
                                                btnCancel.Enabled = true;
                                                if (Dialog != DialogResult.OK)                                               
                                                    return;
                                            }

                                            if (string.IsNullOrEmpty(fileMDL.ParentID) ||
                                                fileMDL.ParentID.ToString().Trim() == "")
                                            {
                                                ///���ڵ�
                                                TXMessageBoxExtensions.Info("��ʾ���޷��Ը�Ŀ¼���е��룡 \n ����ܰ��ʾ����ѡ���Ŀ¼����Ч��Ŀ¼���е��롿");
                                                btnCancel.Enabled = true;
                                                return;
                                            }
                                            else
                                            {
                                                #region ����Ϊ�鵵��� �����ļ�
                                                DataRow[] AddFiles_rows =
                                                    tbl_FileList.Select("GDID='" + parentFileID + "'", "GdFileOrderIndex ASC");

                                                if (AddFiles_rows != null && AddFiles_rows.Length > 0)
                                                {
                                                    tbl_TempFileLis.Rows.Clear();
                                                    foreach (DataRow addfile_row in AddFiles_rows)
                                                    {
                                                        tbl_TempFileLis.ImportRow(addfile_row);
                                                    }
                                                    IList<MDL.T_FileList> fileMDL_List =
                                                        MyCommon.DataTableToList<MDL.T_FileList>(tbl_TempFileLis);

                                                    if (fileMDL_List != null && fileMDL_List.Count > 0)
                                                    {
                                                        foreach (MDL.T_FileList AddFile_MDL in fileMDL_List)
                                                        {
                                                            string OLD_FileID = AddFile_MDL.FileID;
                                                            AddFile_MDL.FileID = Guid.NewGuid().ToString();

                                                            if (tbl_CellAndEFile != null && tbl_CellAndEFile.Rows.Count > 0)
                                                            {
                                                                #region �����ļ�
                                                                DataRow[] efile_rows =
                                                                    tbl_CellAndEFile.Select("GdFileID='" + OLD_FileID + "'", "GdOrderIndex asc");//����ڵ��µĵ����ļ�

                                                                if (efile_rows != null && efile_rows.Length > 0)
                                                                {
                                                                    tbl_TempCellAndEFile.Rows.Clear();
                                                                    foreach (DataRow efile_row in efile_rows)
                                                                    {
                                                                        tbl_TempCellAndEFile.ImportRow(efile_row);
                                                                    }

                                                                    IList<MDL.T_CellAndEFile> efileMDL_List =
                                                                            MyCommon.DataTableToList<MDL.T_CellAndEFile>(tbl_TempCellAndEFile);//ת���ڵ��µ����ļ���¼

                                                                    if (efileMDL_List != null && efileMDL_List.Count > 0)
                                                                    {
                                                                        foreach (MDL.T_CellAndEFile obj_efile in efileMDL_List)
                                                                        {
                                                                            if (obj_efile.filepath == null || obj_efile.filepath.Trim() == "")
                                                                                continue;

                                                                            obj_efile.CellID = Guid.NewGuid().ToString();
                                                                            obj_efile.FileID = AddFile_MDL.FromFileID;
                                                                            obj_efile.GdFileID = AddFile_MDL.FileID;

                                                                            if (obj_efile.DocYs != 1)
                                                                            {
                                                                                obj_efile.DocYs = 0;
                                                                                obj_efile.DoStatus = 1;

                                                                                if (File.Exists(efilePath + obj_efile.filepath))
                                                                                {
                                                                                    string efileExt = System.IO.Path.GetExtension(efilePath + obj_efile.filepath);
                                                                                    System.IO.File.Copy(efilePath + obj_efile.filepath,
                                                                                        Globals.ProjectPath + "ODOC\\" + obj_efile.CellID + efileExt, true);//������ǰ�����ļ�
                                                                                    obj_efile.filepath = "ODOC\\" + obj_efile.CellID + efileExt;
                                                                                }
                                                                                else
                                                                                {
                                                                                    obj_efile.filepath = "";
                                                                                }
                                                                            }
                                                                            else
                                                                            {
                                                                                obj_efile.DocYs = 0;
                                                                                obj_efile.DoStatus = 1;

                                                                                if (File.Exists(efilePath + obj_efile.filepath))
                                                                                {
                                                                                    string efileExt = System.IO.Path.GetExtension(efilePath + obj_efile.filepath);
                                                                                    System.IO.File.Copy(efilePath + obj_efile.filepath,
                                                                                        Globals.ProjectPath + "ODOC\\" + obj_efile.CellID + efileExt, true);//������ǰ�����ļ�
                                                                                    obj_efile.filepath = "ODOC\\" + obj_efile.CellID + efileExt;
                                                                                }
                                                                                else
                                                                                {
                                                                                    obj_efile.filepath = "";
                                                                                }

                                                                                if (File.Exists(efilePath + obj_efile.fileTreePath))
                                                                                {
                                                                                    string efileExt = System.IO.Path.GetExtension(efilePath + obj_efile.fileTreePath);
                                                                                    System.IO.File.Copy(efilePath + obj_efile.fileTreePath,
                                                                                        Globals.ProjectPath + "PDF\\" + obj_efile.CellID + efileExt, true);//������ǰ�����ļ�
                                                                                    obj_efile.fileTreePath = "PDF\\" + obj_efile.CellID + efileExt;
                                                                                }
                                                                                else
                                                                                {
                                                                                    obj_efile.fileTreePath = "";
                                                                                    obj_efile.DocYs = 1;//��������PDF
                                                                                }
                                                                            }
                                                                            obj_efile.ProjectNO = Globals.ProjectNO;
                                                                            obj_efile.orderindex =
                                                                                CEfileImp_BLL.GetMaxOrderIndex(AddFile_MDL.FromFileID, Globals.ProjectNO) + 1;
                                                                            obj_efile.GdOrderIndex =
                                                                                CEfileImp_BLL.GetMaxGdFileOrderIndex(obj_efile.GdFileID, Globals.ProjectNO) + 1;

                                                                            CEfileImp_BLL.Insert(obj_efile);

                                                                            //���ԭ����Ϣ
                                                                            MyCommon.InsertOldEfile(obj_efile.CellID,  Globals.ProjectNO, Globals.LoginUser, "�ļ��Ǽ�-�����3", obj_efile.filepath);   
                                                                        }
                                                                    }
                                                                }
                                                                #endregion
                                                            }

                                                            AddFile_MDL.ArchiveID = "";
                                                            if (AddFile_MDL.fileStatus == "4" || AddFile_MDL.fileStatus == "6")
                                                                AddFile_MDL.fileStatus = "4";
                                                            else
                                                                AddFile_MDL.fileStatus = "0";

                                                            if (AddFile_MDL.filepath != null && AddFile_MDL.filepath.Trim() != "")
                                                            {
                                                                string efileExt =
                                                                    System.IO.Path.GetExtension(efilePath + AddFile_MDL.filepath);
                                                                if (File.Exists(efilePath + AddFile_MDL.filepath))
                                                                {
                                                                    System.IO.File.Copy(efilePath + AddFile_MDL.filepath,
                                                                                Globals.ProjectPath + "MPDF\\" + AddFile_MDL.FileID + efileExt, true);//������ǰ�����ļ�
                                                                    AddFile_MDL.filepath = "MPDF\\" + AddFile_MDL.FileID + efileExt;
                                                                }

                                                            }

                                                            AddFile_MDL.OrderIndex =
                                                                fileImp_BLL.GetMaxOrderIndex(AddFile_MDL.ParentID, Globals.ProjectNO) + 1;
                                                            AddFile_MDL.GdFileOrderIndex =
                                                                fileImp_BLL.GetMaxGdFileOrderIndex(fileMDL.GDID, Globals.ProjectNO) + 1;
                                                            AddFile_MDL.GDID = fileMDL.GDID;//�޸ĸ��ڵ�
                                                            AddFile_MDL.ProjectNO = Globals.ProjectNO;
                                                            fileImp_BLL.Insert(AddFile_MDL);
                                                        }
                                                    }
                                                }
                                                #endregion
                                            }
                                        }
                                        else
                                        {
                                            //�������鵵���
                                            MDL.T_GdList gdList_MDL =
                                            (new BLL.T_GdList_BLL()).FindIDAndProjectNo(SelectTreeNode.Name, Globals.ProjectNO);
                                            if (gdList_MDL != null)
                                            {
                                                #region ����Ϊ�鵵��� ����鵵���
                                                DataRow[] AddFiles_rows =
                                                    tbl_FileList.Select("GDID='" + parentFileID + "'", "GdFileOrderIndex ASC");

                                                if (AddFiles_rows != null && AddFiles_rows.Length > 0)
                                                {
                                                    tbl_TempFileLis.Rows.Clear();
                                                    foreach (DataRow addfile_row in AddFiles_rows)
                                                    {
                                                        tbl_TempFileLis.ImportRow(addfile_row);
                                                    }
                                                    IList<MDL.T_FileList> fileMDL_List =
                                                        MyCommon.DataTableToList<MDL.T_FileList>(tbl_TempFileLis);

                                                    if (fileMDL_List != null && fileMDL_List.Count > 0)
                                                    {
                                                        foreach (MDL.T_FileList AddFile_MDL in fileMDL_List)
                                                        {
                                                            string OLD_FileID = AddFile_MDL.FileID;
                                                            AddFile_MDL.FileID = Guid.NewGuid().ToString();

                                                            if (tbl_CellAndEFile != null && tbl_CellAndEFile.Rows.Count > 0)
                                                            {
                                                                #region �����ļ�
                                                                DataRow[] efile_rows =
                                                                    tbl_CellAndEFile.Select("GdFileID='" + OLD_FileID + "'", "GdOrderIndex asc");//����ڵ��µĵ����ļ�

                                                                if (efile_rows != null && efile_rows.Length > 0)
                                                                {
                                                                    tbl_TempCellAndEFile.Rows.Clear();
                                                                    foreach (DataRow efile_row in efile_rows)
                                                                    {
                                                                        tbl_TempCellAndEFile.ImportRow(efile_row);
                                                                    }

                                                                    IList<MDL.T_CellAndEFile> efileMDL_List =
                                                                            MyCommon.DataTableToList<MDL.T_CellAndEFile>(tbl_TempCellAndEFile);//ת���ڵ��µ����ļ���¼

                                                                    if (efileMDL_List != null && efileMDL_List.Count > 0)
                                                                    {
                                                                        foreach (MDL.T_CellAndEFile obj_efile in efileMDL_List)
                                                                        {
                                                                            if (obj_efile.filepath == null || obj_efile.filepath.Trim() == "")
                                                                                continue;

                                                                            obj_efile.CellID = Guid.NewGuid().ToString();
                                                                            obj_efile.FileID = AddFile_MDL.FromFileID;
                                                                            obj_efile.GdFileID = AddFile_MDL.FileID;

                                                                            if (obj_efile.DocYs != 1)
                                                                            {
                                                                                obj_efile.DocYs = 0;
                                                                                obj_efile.DoStatus = 1;

                                                                                if (File.Exists(efilePath + obj_efile.filepath))
                                                                                {
                                                                                    string efileExt = System.IO.Path.GetExtension(efilePath + obj_efile.filepath);
                                                                                    System.IO.File.Copy(efilePath + obj_efile.filepath,
                                                                                        Globals.ProjectPath + "ODOC\\" + obj_efile.CellID + efileExt, true);//������ǰ�����ļ�
                                                                                    obj_efile.filepath = "ODOC\\" + obj_efile.CellID + efileExt;
                                                                                }
                                                                                else
                                                                                {
                                                                                    obj_efile.filepath = "";
                                                                                }
                                                                            }
                                                                            else
                                                                            {
                                                                                obj_efile.DocYs = 0;
                                                                                obj_efile.DoStatus = 1;

                                                                                if (File.Exists(efilePath + obj_efile.filepath))
                                                                                {
                                                                                    string efileExt = System.IO.Path.GetExtension(efilePath + obj_efile.filepath);
                                                                                    System.IO.File.Copy(efilePath + obj_efile.filepath,
                                                                                        Globals.ProjectPath + "ODOC\\" + obj_efile.CellID + efileExt, true);//������ǰ�����ļ�
                                                                                    obj_efile.filepath = "ODOC\\" + obj_efile.CellID + efileExt;
                                                                                }
                                                                                else
                                                                                {
                                                                                    obj_efile.filepath = "";
                                                                                }

                                                                                if (File.Exists(efilePath + obj_efile.fileTreePath))
                                                                                {
                                                                                    string efileExt = System.IO.Path.GetExtension(efilePath + obj_efile.fileTreePath);
                                                                                    System.IO.File.Copy(efilePath + obj_efile.fileTreePath,
                                                                                        Globals.ProjectPath + "PDF\\" + obj_efile.CellID + efileExt, true);//������ǰ�����ļ�
                                                                                    obj_efile.fileTreePath = "PDF\\" + obj_efile.CellID + efileExt;
                                                                                }
                                                                                else
                                                                                {
                                                                                    obj_efile.fileTreePath = "";
                                                                                    obj_efile.DocYs = 1;//��������PDF
                                                                                }
                                                                            }
                                                                            obj_efile.ProjectNO = Globals.ProjectNO;
                                                                            obj_efile.orderindex =
                                                                                CEfileImp_BLL.GetMaxOrderIndex(AddFile_MDL.FromFileID, Globals.ProjectNO) + 1;
                                                                            obj_efile.GdOrderIndex =
                                                                                CEfileImp_BLL.GetMaxGdFileOrderIndex(obj_efile.GdFileID, Globals.ProjectNO) + 1;

                                                                            CEfileImp_BLL.Insert(obj_efile);

                                                                            //���ԭ����Ϣ
                                                                            MyCommon.InsertOldEfile(obj_efile.CellID,  Globals.ProjectNO, Globals.LoginUser, "�ļ��Ǽ�-�����4", obj_efile.filepath);   
                                                                        }
                                                                    }
                                                                }
                                                                #endregion
                                                            }

                                                            AddFile_MDL.ArchiveID = "";
                                                            if (AddFile_MDL.fileStatus == "4" || AddFile_MDL.fileStatus == "6")
                                                                AddFile_MDL.fileStatus = "4";
                                                            else
                                                                AddFile_MDL.fileStatus = "0";

                                                            if (AddFile_MDL.filepath != null && AddFile_MDL.filepath.Trim() != "")
                                                            {
                                                                string efileExt =
                                                                    System.IO.Path.GetExtension(efilePath + AddFile_MDL.filepath);
                                                                if (File.Exists(efilePath + AddFile_MDL.filepath))
                                                                {
                                                                    System.IO.File.Copy(efilePath + AddFile_MDL.filepath,
                                                                                Globals.ProjectPath + "MPDF\\" + AddFile_MDL.FileID + efileExt, true);//������ǰ�����ļ�
                                                                    AddFile_MDL.filepath = "MPDF\\" + AddFile_MDL.FileID + efileExt;
                                                                }
                                                                
                                                            }

                                                            AddFile_MDL.OrderIndex =
                                                                fileImp_BLL.GetMaxOrderIndex(AddFile_MDL.ParentID, Globals.ProjectNO) + 1;
                                                            AddFile_MDL.GdFileOrderIndex =
                                                                fileImp_BLL.GetMaxGdFileOrderIndex(SelectTreeNode.Name, Globals.ProjectNO) + 1;
                                                            AddFile_MDL.GDID = SelectTreeNode.Name;//�޸ĸ��ڵ�
                                                            AddFile_MDL.ProjectNO = Globals.ProjectNO;
                                                            fileImp_BLL.Insert(AddFile_MDL);
                                                        }
                                                    }
                                                }
                                                #endregion
                                            }
                                            else
                                            {
                                                TXMessageBoxExtensions.Info("��ʾ��ѡ����Ľڵ���Ч��������ѡ��ڵ㵼�룡��");
                                                btnCancel.Enabled = true;
                                                return;
                                            }
                                        }
                                    }
                                    catch
                                    {
                                        //�������Ϣ�д���
                                        this.DialogResult = DialogResult.Cancel;
                                    }
                                    #endregion
                                }
                                else
                                {
                                    TXMessageBoxExtensions.Info("��ʾ��ѡ�������Ϣ��Ч����ȷ�ϵ�������Ϣ���󣡣�");
                                    btnCancel.Enabled = true;
                                    return;
                                }
                            }
                            if (SelectTreeNode.ImageIndex != 0 && SelectTreeNode.ImageIndex != 1)
                            {
                                (new TreeFactory()).InitGDTree(Globals.ProjectNO, TreeNodeState_flg, SelectTreeNode.Parent,
                                   true, EFCount_flg, true);
                                //TreeFactory tfactory = new TreeFactory();
                                //SelectTreeNode.ImageIndex = (tfactory.CheckEFileByFileID(SelectTreeNode.Name, 2) == true) ? 7 : 2;//�ж��Ƿ��е����ļ�
                                //SelectTreeNode.SelectedImageIndex = SelectTreeNode.ImageIndex;
                                //tfactory.GetCellFileNodesCount((TreeNodeEx)SelectTreeNode, true);
                            }
                            else if (SelectTreeNode.ImageIndex == 0)
                            {
                                ///ˢ�½ڵ�
                                (new TreeFactory()).InitGDTree2(Globals.ProjectNO, TreeNodeState_flg, SelectTreeNode,
                                    true, EFCount_flg, true);
                            }
                            else if (SelectTreeNode.ImageIndex == 1)
                            {
                                ///ˢ�½ڵ�
                                (new TreeFactory()).InitGDTree(Globals.ProjectNO, TreeNodeState_flg, SelectTreeNode,
                                    true, EFCount_flg, true);
                            }
                            #endregion
                        }
                        else
                        {
                            //�������Ϣ�д���
                            TXMessageBoxExtensions.Info("��ʾ�����������Ϣ�д��������µ���");
                            this.DialogResult = DialogResult.Cancel;
                        }
                    }
                }
                MyCommon.DeleteAndCreateEmptyDirectory(dir.FullName, false);
                btnCancel.Enabled = true;
                lblTitle.Text = @"������ɣ�";
                progressBar1.Value = progressBar1.Maximum;
                Application.DoEvents();
                this.DialogResult = DialogResult.OK;
                #region

                //DirectoryInfo dir = new DirectoryInfo(Application.StartupPath + "\\temp");

                //MyCommon.DeleteAndCreateEmptyDirectory(dir.FullName + "\\T_FileList\\");
                //MyCommon.DeleteAndCreateEmptyDirectory(dir.FullName + "\\T_CellAndEFile\\");

                //lblTitle.Text = @"���ڽ�ѹ��ǰ������ʱĿ¼.....";
                //btnCancel.Enabled = false;
                //btnConfirm.Enabled = false;
                //btnExplorer.Enabled = false;
                //bool gx_flg = false;
                //Application.DoEvents();

                //UpZipFile unZip = new Common.UpZipFile(openFileDialog1.FileName, ImptempPath);
                //unZip.StartUnZip();
                //string[] cellList = System.IO.Directory.GetFiles(dir.FullName + "\\T_CellAndEFile\\");
                //foreach (string cell in cellList)
                //{
                //    FileInfo fInfo = new FileInfo(cell);
                //    if (fInfo.Extension.ToLower() == ".xml")
                //    {//���Ǳ��¼
                //        DataSet ds = new DataSet();
                //        ds.ReadXml(cell, XmlReadMode.ReadSchema);
                //        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                //        {
                //            IList<MDL.T_CellAndEFile> cellList2 = MyCommon.DataTableToList<MDL.T_CellAndEFile>(ds.Tables[0]);
                //            foreach (MDL.T_CellAndEFile obj in cellList2)
                //            {
                //                obj.ProjectNO = Globals.ProjectNO;//���ɵ�ǰ����               

                //                //�ж��Ƿ���ڵ����ļ� ����ļ�����û�е����ļ� �Ͳ���Ҫ�ϲ�pdf
                //                if (string.IsNullOrEmpty(obj.filepath) || obj.filepath == "")
                //                {
                //                    obj.DocYs = 0;//�޸���
                //                }
                //                else
                //                    obj.DocYs = 1;//�и��£��´ο�ͼ����Ҫ����

                //                BLL.T_CellAndEFile_BLL cellBLL = new ERM.BLL.T_CellAndEFile_BLL();
                //                if (cellBLL.Exists(obj.CellID, Globals.ProjectNO))
                //                {
                //                    //cellBLL.Update(obj);
                //                }
                //                else
                //                {
                //                    //cellBLL.Add(obj);
                //                }
                //            }
                //        }
                //    }
                //    else
                //    {//copy ԭ��
                //        System.IO.File.Copy(cell, Globals.ProjectPath + "ODOC\\" + fInfo.Name, true);
                //    }
                //}

                //string[] fileList = System.IO.Directory.GetFiles(dir.FullName + "\\T_FileList\\");

                //DataSet file_ds = new DataSet();
                //foreach (string file in fileList)
                //{
                //    FileInfo fInfo = new FileInfo(file);
                //    if (fInfo.Extension.ToLower() == ".xml")
                //    {//���Ǳ��¼
                //        DataSet ds = new DataSet();
                //        ds.ReadXml(file, XmlReadMode.ReadSchema);
                //        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                //        {
                //            if (file_ds.Tables.Count <= 0)
                //            {
                //                DataTable file_tb = new DataTable();
                //                file_tb.TableName = ds.Tables[0].TableName;
                //                file_tb = ds.Tables[0].Clone();
                //                file_ds.Tables.Add(file_tb);
                //            }

                //            foreach (DataRow file_row in ds.Tables[0].Rows)
                //            {
                //                file_ds.Tables[0].ImportRow(file_row);
                //            }

                //            //IList<MDL.T_FileList> fileList2 = MyCommon.DataTableToList<MDL.T_FileList>(ds.Tables[0]);
                //            //foreach (MDL.T_FileList obj in fileList2)
                //            //{
                //            //    obj.ProjectNO = Globals.ProjectNO;//���ɵ�ǰ����
                //            //    gx_flg = false;
                //            //    BLL.T_FileList_BLL fileBLL = new ERM.BLL.T_FileList_BLL();
                //            //    BLL.T_CellAndEFile_BLL cellBLL = new ERM.BLL.T_CellAndEFile_BLL();

                //            //    //�ж��Ƿ���ڵ����ļ� ����ļ�����û�е����ļ� �Ͳ���Ҫ�ϲ�pdf
                //            //    IList<ERM.MDL.T_CellAndEFile> cellandFile_MDLList =
                //            //        cellBLL.FindByFileIDAndNOCell(obj.FileID, Globals.ProjectNO);

                //            //    foreach (ERM.MDL.T_CellAndEFile cellandFile_mdl in cellandFile_MDLList)
                //            //    {
                //            //        if (!string.IsNullOrEmpty(cellandFile_mdl.filepath)
                //            //            && cellandFile_mdl.filepath != "")
                //            //        {
                //            //            gx_flg = true;
                //            //            break;
                //            //        }
                //            //    }
                //            //    if (gx_flg)
                //            //        obj.selected = 1;//�и��£��´ο�ͼ����Ҫ����
                //            //    else
                //            //        obj.selected = 0;

                //            //    //if (fileBLL.Exists(obj.FileID, obj.ProjectNO))
                //            //    //MDL.T_FileList fileList_mdlflg = fileBLL.Find(obj.FileID, Globals.ProjectNO);
                //            //    if (fileBLL.Exists(obj.FileID, Globals.ProjectNO))//�����
                //            //    {
                //            //        fileBLL.Update(obj);
                //            //    }
                //            //    else
                //            //    {
                //            //        fileBLL.Add(obj);
                //            //    }
                //            //}
                //        }
                //    }
                //}
                #endregion
            }
        }

        /// <summary>
        /// FileListҵ�������
        /// </summary>
        BLL.T_FileList_BLL fileImp_BLL = new ERM.BLL.T_FileList_BLL();
        /// <summary>
        /// CellAndEFileҵ�������
        /// </summary>
        BLL.T_CellAndEFile_BLL CEfileImp_BLL = new ERM.BLL.T_CellAndEFile_BLL();
        List<MDL.T_CellAndEFile> AddEFileList = new List<ERM.MDL.T_CellAndEFile>();//���
        List<MDL.T_CellAndEFile> UpdateEFileList = new List<ERM.MDL.T_CellAndEFile>();//�޸�
        List<MDL.T_CellAndEFile> DelEFileList = new List<ERM.MDL.T_CellAndEFile>();//ɾ��

        /// <summary>
        /// �ԱȽڵ���Ϣ 
        /// *************************************************************************************************
        /// ��ӵ����ļ�˵����
        /// 1������Ѿ�����ĵ����ļ��������ж�ֱ����ӹ�ȥ
        /// 2�����û�б���ĵ����ļ���Ŀ��Ŀ¼����Ҳû�е����ļ�ģ��Ļ�������ӹ�ȥ
        /// *************************************************************************************************
        /// </summary>
        /// <param name="tbl_fileInfo">�ļ���Ϣ��</param>
        /// <param name="tbl_efileInfo">�����ļ���Ϣ��</param>
        /// <param name="parentFileID">�ϼ����ڵ�ID</param>
        /// <param name="tbl_ImpFileTemp">fileTemp��</param>
        /// <param name="tbl_ImpEFileTemp">ImpEFileTemp��</param>
        /// <param name="ImpTreeNode">ѡ�еĽڵ����</param>
        /// <param name="efilePath">�����ļ�·��</param>
        /// <param name="FlordOrFile_flg">�ļ��� Or �ļ� ��true��ʾ�ļ��� false�ļ���</param>
        private void ImpDataInfo(DataTable tbl_fileInfo, DataTable tbl_efileInfo,
            string parentFileID, DataTable tbl_ImpFileTemp, DataTable tbl_ImpEFileTemp,
            string ImpTreeNode_Name, string efilePath, bool FlordOrFile_flg)
        {
            DataRow[] file_rows = null;

            if (FlordOrFile_flg)
                file_rows = tbl_fileInfo.Select("ParentID='" + parentFileID + "'", "orderindex asc");
            else
                file_rows = tbl_fileInfo.Select("FileID='" + parentFileID + "'", "orderindex asc");

            bool insert_flg = false;
            string fileID_temp = null;
            int isVisable_flg = 0;

            foreach (DataRow file_row in file_rows)
            {
                string fileID = file_row["FileID"] == null ? "" : file_row["FileID"].ToString().Trim();
                string fileTitle = file_row["wjtm"] == null ? "" : file_row["wjtm"].ToString().Trim();
                insert_flg = false;
                isVisable_flg = 0;
                fileID_temp = null;

                if (FlordOrFile_flg)
                {
                    IList<MDL.T_FileList> File_List = fileImp_BLL.FindByParentID(ImpTreeNode_Name, Globals.ProjectNO);
                    foreach (MDL.T_FileList file_mdl in File_List)
                    {
                        fileID_temp = file_mdl.FileID.Trim();
                        isVisable_flg = file_mdl.isvisible;
                        if ((fileTitle == file_mdl.wjtm.Trim() || fileID == fileID_temp))
                        {
                            insert_flg = true;
                            break;
                        }
                    }
                }
                else
                {
                    MDL.T_FileList file_mdl = fileImp_BLL.Find(ImpTreeNode_Name, Globals.ProjectNO);
                    if (file_mdl != null)
                    {
                        fileID_temp = file_mdl.FileID.Trim();
                        isVisable_flg = file_mdl.isvisible;
                        insert_flg = true;
                    }
                    else
                    {
                        break;
                    }
                }

                //foreach (TreeNode file_node in ImpTreeNode.Nodes)
                //{
                //    if (file_node.ImageIndex != 3)
                //    {
                //        fileID_temp = file_node.Name.Trim();
                //        ERM.MDL.T_FileList fileTemp_MDL = fileImp_BLL.Find(fileID_temp, Globals.ProjectNO);
                //        if (fileTemp_MDL != null && (fileTitle == fileTemp_MDL.wjtm.Trim() || fileID == fileID_temp))
                //        {//fileID == ImpTreeNode.Name.Trim() || fileTitle == file_node.Text.Trim()
                //            insert_flg = true;
                //            SameNode = file_node;
                //            break;
                //        }
                //    }
                //}

                if (!insert_flg)
                {
                    /***********************************************************************************
                     * ˵�����ڵ����Ʋ���ͬ ֱ����ӵ����
                     *       ͬʱ�ݹ鵱ǰ�ڵ��� �ж��Ƿ����ӽڵ�
                     ********************************************************************************/
                    #region �ڵ����� ����ͬ
                    tbl_ImpFileTemp.Rows.Clear();
                    tbl_ImpFileTemp.ImportRow(file_row);

                    IList<MDL.T_FileList> fileMDL_List =
                        MyCommon.DataTableToList<MDL.T_FileList>(tbl_ImpFileTemp);

                    if (fileMDL_List != null && fileMDL_List.Count > 0)
                    {
                        fileMDL_List[0].FileID = Guid.NewGuid().ToString();

                        if (file_row["isvisible"].ToString() == "1")//�ļ�
                        {
                            #region ===========================================================================
                            if (tbl_efileInfo != null && tbl_efileInfo.Rows.Count > 0)
                            {
                                DataRow[] efile_rows =
                                    tbl_efileInfo.Select("FileID='" + fileID + "'", "orderindex asc");//����ڵ��µĵ����ļ�

                                if (efile_rows != null && efile_rows.Length > 0)
                                {
                                    tbl_ImpEFileTemp.Rows.Clear();
                                    foreach (DataRow efile_row in efile_rows)
                                    {
                                        tbl_ImpEFileTemp.ImportRow(efile_row);
                                    }

                                    IList<MDL.T_CellAndEFile> efileMDL_List =
                                            MyCommon.DataTableToList<MDL.T_CellAndEFile>(tbl_ImpEFileTemp);//ת���ڵ��µ����ļ���¼

                                    if (efileMDL_List != null && efileMDL_List.Count > 0)
                                    {
                                        foreach (MDL.T_CellAndEFile obj_efile in efileMDL_List)
                                        {
                                            if (obj_efile.filepath == null || obj_efile.filepath.Trim() == "")
                                                continue;

                                            obj_efile.CellID = Guid.NewGuid().ToString();
                                            obj_efile.FileID = fileMDL_List[0].FileID;

                                            #region
                                            /*
                                            if (obj_efile.ProjectNO != Globals.ProjectNO)
                                            {
                                                obj_efile.DocYs = 0;
                                                obj_efile.DoStatus = 0;

                                                FileInfo efile = new FileInfo(obj_efile.filepath);
                                                if (File.Exists(efilePath + efile.Name))
                                                {
                                                    System.IO.File.Copy(efilePath + efile.Name,
                                                        Globals.ProjectPath + "ODOC\\" + obj_efile.CellID + efile.Extension, true);//������ǰ�����ļ�
                                                    obj_efile.filepath = "ODOC\\" + obj_efile.CellID + efile.Extension;

                                                    if (efile.Extension.ToLower() != ".cll".ToLower())
                                                    {
                                                        obj_efile.DocYs = 1;
                                                        obj_efile.DoStatus = 1;
                                                    }
                                                }
                                                else
                                                {
                                                    obj_efile.filepath = "";
                                                }
                                            }
                                            else
                                            {
                                                if (obj_efile.DoStatus != 1)
                                                {
                                                    obj_efile.DocYs = 0;
                                                    obj_efile.DoStatus = 0;

                                                    FileInfo efile = new FileInfo(obj_efile.filepath);
                                                    if (File.Exists(efilePath + efile.Name))
                                                    {
                                                        System.IO.File.Copy(efilePath + efile.Name,
                                                            Globals.ProjectPath + "ODOC\\" + obj_efile.CellID + efile.Extension, true);//������ǰ�����ļ�
                                                        obj_efile.filepath = "ODOC\\" + obj_efile.CellID + efile.Extension;

                                                        if (efile.Extension.ToLower() != ".cll".ToLower())
                                                        {
                                                            obj_efile.DocYs = 1;
                                                            obj_efile.DoStatus = 1;
                                                        }
                                                    }
                                                    else
                                                    {
                                                        obj_efile.filepath = "";
                                                    }
                                                }
                                                else
                                                {
                                                    obj_efile.DoStatus = 1;

                                                    FileInfo efile = new FileInfo(obj_efile.filepath);
                                                    if (File.Exists(efilePath + efile.Name))
                                                    {
                                                        System.IO.File.Copy(efilePath + efile.Name,
                                                            Globals.ProjectPath + "ODOC\\" + obj_efile.CellID + efile.Extension, true);//������ǰ�����ļ�
                                                        obj_efile.filepath = "ODOC\\" + obj_efile.CellID + efile.Extension;
                                                    }
                                                    else
                                                    {
                                                        obj_efile.filepath = "";
                                                    }

                                                    if (obj_efile.DocYs == 0)
                                                    {
                                                        FileInfo efile_pdf = new FileInfo(obj_efile.filepath);
                                                        if (File.Exists(efilePath + efile_pdf.Name))
                                                        {
                                                            System.IO.File.Copy(efilePath + "\\" + obj_efile.filepath,
                                                                Globals.ProjectPath + "ODOC\\" + obj_efile.CellID + efile.Extension, true);//������ǰ�����ļ�
                                                            obj_efile.filepath = "ODOC\\" + obj_efile.CellID + efile.Extension;
                                                        }
                                                        else
                                                        {
                                                            obj_efile.filepath = "";
                                                        }
                                                    }
                                                }
                                            }
                                             * */
                                            #endregion

                                            if (obj_efile.ProjectNO != Globals.ProjectNO)
                                            {
                                                obj_efile.DocYs = 0;
                                                obj_efile.DoStatus = 0;

                                                FileInfo efile = new FileInfo(obj_efile.filepath);
                                                if (File.Exists(efilePath + obj_efile.filepath))
                                                {
                                                    System.IO.File.Copy(efilePath + obj_efile.filepath,
                                                        Globals.ProjectPath + "ODOC\\" + obj_efile.CellID + efile.Extension, true);//������ǰ�����ļ�
                                                    obj_efile.filepath = "ODOC\\" + obj_efile.CellID + efile.Extension;

                                                    if (efile.Extension.ToLower() != ".cll".ToLower())
                                                    {
                                                        obj_efile.DocYs = 1;
                                                        obj_efile.DoStatus = 1;
                                                    }
                                                }
                                                else
                                                {
                                                    obj_efile.filepath = "";
                                                }
                                            }
                                            else
                                            {
                                                if (obj_efile.DoStatus != 1)
                                                {
                                                    obj_efile.DocYs = 0;
                                                    obj_efile.DoStatus = 0;

                                                    FileInfo efile = new FileInfo(obj_efile.filepath);
                                                    if (File.Exists(efilePath + obj_efile.filepath))
                                                    {
                                                        System.IO.File.Copy(efilePath + obj_efile.filepath,
                                                            Globals.ProjectPath + "ODOC\\" + obj_efile.CellID + efile.Extension, true);//������ǰ�����ļ�
                                                        obj_efile.filepath = "ODOC\\" + obj_efile.CellID + efile.Extension;

                                                        if (efile.Extension.ToLower() != ".cll".ToLower())
                                                        {
                                                            obj_efile.DocYs = 1;
                                                            obj_efile.DoStatus = 1;
                                                        }
                                                    }
                                                    else
                                                    {
                                                        obj_efile.filepath = "";
                                                    }
                                                }
                                                else
                                                {
                                                    obj_efile.DoStatus = 1;

                                                    FileInfo efile = new FileInfo(obj_efile.filepath);
                                                    if (File.Exists(efilePath + obj_efile.filepath))
                                                    {
                                                        System.IO.File.Copy(efilePath + obj_efile.filepath,
                                                            Globals.ProjectPath + "ODOC\\" + obj_efile.CellID + efile.Extension, true);//������ǰ�����ļ�
                                                        obj_efile.filepath = "ODOC\\" + obj_efile.CellID + efile.Extension;
                                                    }
                                                    else
                                                    {
                                                        obj_efile.filepath = "";
                                                    }

                                                    if (obj_efile.DocYs == 0)
                                                    {
                                                        FileInfo efile_pdf = new FileInfo(obj_efile.fileTreePath);
                                                        if (File.Exists(efilePath + obj_efile.fileTreePath))
                                                        {
                                                            System.IO.File.Copy(efilePath + obj_efile.fileTreePath,
                                                                Globals.ProjectPath + "PDF\\" + obj_efile.CellID + efile_pdf.Extension, true);//������ǰ�����ļ�
                                                            obj_efile.fileTreePath = "PDF\\" + obj_efile.CellID + efile_pdf.Extension;
                                                        }
                                                        else
                                                        {
                                                            obj_efile.fileTreePath = "";
                                                            obj_efile.DocYs = 1;//��������PDF
                                                        }
                                                    }
                                                }
                                            }
                                            obj_efile.ProjectNO = Globals.ProjectNO;
                                            obj_efile.orderindex =
                                                CEfileImp_BLL.GetMaxOrderIndex(obj_efile.FileID, Globals.ProjectNO) + 1;

                                            CEfileImp_BLL.Insert(obj_efile);
                                        }
                                        fileMDL_List[0].selected = 1;//�����˵����ļ� �޸�Ŀ¼״̬
                                    }
                                }
                            }
                            #endregion
                        }
                        else//�ļ���
                        {
                            ImpDataInfo(tbl_fileInfo, tbl_efileInfo, fileID, fileMDL_List[0].FileID, tbl_ImpFileTemp, tbl_ImpEFileTemp, efilePath);
                        }
                        fileMDL_List[0].ArchiveID = "";
                        if (fileMDL_List[0].ProjectNO == Globals.ProjectNO)
                        {
                            if (fileMDL_List[0].fileStatus == "4" || fileMDL_List[0].fileStatus == "6")
                                fileMDL_List[0].fileStatus = "4";
                            else
                                fileMDL_List[0].fileStatus = "0";

                            if (fileMDL_List[0].filepath != null && fileMDL_List[0].filepath.Trim() != "")
                            {
                                FileInfo file = new FileInfo(fileMDL_List[0].filepath);
                                if (File.Exists(efilePath + file.Name))
                                {
                                    System.IO.File.Copy(efilePath + file.Name,
                                                Globals.ProjectPath + "MPDF\\" + fileMDL_List[0].FileID + file.Extension, true);//������ǰ�����ļ�
                                    fileMDL_List[0].filepath = "MPDF\\" + fileMDL_List[0].FileID + file.Extension;
                                }
                            }
                        }
                        else
                            fileMDL_List[0].fileStatus = "0";
                        fileMDL_List[0].OrderIndex = fileImp_BLL.GetMaxOrderIndex(ImpTreeNode_Name, Globals.ProjectNO) + 1;
                        fileMDL_List[0].ParentID = ImpTreeNode_Name;//�޸ĸ��ڵ�
                        fileMDL_List[0].ProjectNO = Globals.ProjectNO;
                        fileImp_BLL.Insert(fileMDL_List[0]);
                    }
                    #endregion
                }
                else
                {
                    /***********************************************************************************
                     * ˵�����ڵ�������ͬ
                     *       �ж����ļ��� ���� �ļ���
                     *       �ļ��У������ݹ��Լ���TreeNode�ڵ� �жϽڵ���Ϣ
                     *       �ļ���ֱ�ӽ��ļ��µĵ����ļ���ӵ���ǰTreeNode�ڵ���
                       ********************************************************************************/
                    #region �ڵ����� ��ͬ
                    if (file_row["isvisible"].ToString() == "1")//�ļ�
                    {
                        if (isVisable_flg == 1)//Ŀ��ڵ�Ҳ���ļ�
                        {
                            #region ========================================================================================
                            DataRow[] efile_rows =
                                tbl_efileInfo.Select("FileID='" + fileID + "'", "orderindex asc");//����ڵ��µĵ����ļ�

                            AddEFileList.Clear();
                            UpdateEFileList.Clear();
                            DelEFileList.Clear();

                            if (efile_rows != null && efile_rows.Length > 0)
                            {
                                tbl_ImpEFileTemp.Rows.Clear();
                                foreach (DataRow efile_row in efile_rows)
                                {
                                    tbl_ImpEFileTemp.ImportRow(efile_row);
                                }
                                IList<MDL.T_CellAndEFile> efileMDL_List =
                                        MyCommon.DataTableToList<MDL.T_CellAndEFile>(tbl_ImpEFileTemp);//ת���ڵ��µ����ļ���¼

                                if (efileMDL_List != null && efileMDL_List.Count > 0)
                                {
                                    bool EFileAction_flg = true;//��� OR �޸� true��� false�޸�

                                    ERM.MDL.T_FileList fileMDL =
                                        fileImp_BLL.Find(fileID_temp, Globals.ProjectNO);

                                    foreach (MDL.T_CellAndEFile obj_efile in efileMDL_List)
                                    {
                                        if (obj_efile.filepath == null || obj_efile.filepath.Trim() == "")
                                            continue;
                                        EFileAction_flg = true;
                                        if (obj_efile.DoStatus != 1)
                                        {
                                            //�ж��Ƿ���Ҫ���ģ��
                                            if (!CheckedImpEFile(fileID_temp, Globals.ProjectNO))
                                                continue;
                                            obj_efile.CellID = Guid.NewGuid().ToString();
                                        }
                                        else
                                        {
                                            string efileID = string.Empty;
                                            if (CheckedImpEFileAction(obj_efile.title, fileID_temp, Globals.ProjectNO, ref efileID))
                                            {
                                                obj_efile.CellID = Guid.NewGuid().ToString();
                                                EFileAction_flg = true;
                                            }
                                            else
                                            {
                                                obj_efile.CellID = efileID;
                                                obj_efile.ProjectNO = Globals.ProjectNO;
                                                CEfileImp_BLL.Delete(obj_efile);
                                                obj_efile.CellID = Guid.NewGuid().ToString();
                                                EFileAction_flg = true;
                                            }
                                        }
                                        obj_efile.FileID = fileID_temp;//�޸Ľڵ��FileID

                                        if (obj_efile.ProjectNO != Globals.ProjectNO)
                                        {
                                            obj_efile.DocYs = 0;
                                            obj_efile.DoStatus = 0;

                                            FileInfo efile = new FileInfo(obj_efile.filepath);
                                            if (File.Exists(efilePath + obj_efile.filepath))
                                            {
                                                System.IO.File.Copy(efilePath + obj_efile.filepath,
                                                    Globals.ProjectPath + "ODOC\\" + obj_efile.CellID + efile.Extension, true);//������ǰ�����ļ�
                                                obj_efile.filepath = "ODOC\\" + obj_efile.CellID + efile.Extension;

                                                if (efile.Extension.ToLower() != ".cll".ToLower())
                                                {
                                                    obj_efile.DocYs = 1;
                                                    obj_efile.DoStatus = 1;
                                                }
                                            }
                                            else
                                            {
                                                obj_efile.filepath = "";
                                            }
                                        }
                                        else
                                        {
                                            if (obj_efile.DoStatus != 1)
                                            {
                                                obj_efile.DocYs = 0;
                                                obj_efile.DoStatus = 0;

                                                FileInfo efile = new FileInfo(obj_efile.filepath);
                                                if (File.Exists(efilePath + obj_efile.filepath))
                                                {
                                                    System.IO.File.Copy(efilePath + obj_efile.filepath,
                                                        Globals.ProjectPath + "ODOC\\" + obj_efile.CellID + efile.Extension, true);//������ǰ�����ļ�
                                                    obj_efile.filepath = "ODOC\\" + obj_efile.CellID + efile.Extension;

                                                    if (efile.Extension.ToLower() != ".cll".ToLower())
                                                    {
                                                        obj_efile.DocYs = 1;
                                                        obj_efile.DoStatus = 1;
                                                    }
                                                }
                                                else
                                                {
                                                    obj_efile.filepath = "";
                                                }
                                            }
                                            else
                                            {
                                                obj_efile.DoStatus = 1;

                                                FileInfo efile = new FileInfo(obj_efile.filepath);
                                                if (File.Exists(efilePath + obj_efile.filepath))
                                                {
                                                    System.IO.File.Copy(efilePath + obj_efile.filepath,
                                                        Globals.ProjectPath + "ODOC\\" + obj_efile.CellID + efile.Extension, true);//������ǰ�����ļ�
                                                    obj_efile.filepath = "ODOC\\" + obj_efile.CellID + efile.Extension;
                                                }
                                                else
                                                {
                                                    obj_efile.filepath = "";
                                                }

                                                if (obj_efile.DocYs == 0)
                                                {
                                                    FileInfo efile_pdf = new FileInfo(obj_efile.fileTreePath);
                                                    if (File.Exists(efilePath + obj_efile.fileTreePath))
                                                    {
                                                        System.IO.File.Copy(efilePath + obj_efile.fileTreePath,
                                                            Globals.ProjectPath + "PDF\\" + obj_efile.CellID + efile_pdf.Extension, true);//������ǰ�����ļ�
                                                        obj_efile.fileTreePath = "PDF\\" + obj_efile.CellID + efile_pdf.Extension;
                                                    }
                                                    else
                                                    {
                                                        obj_efile.fileTreePath = "";
                                                        obj_efile.DocYs = 1;
                                                    }
                                                }
                                            }
                                        }

                                        obj_efile.ProjectNO = Globals.ProjectNO;
                                        obj_efile.orderindex =
                                           CEfileImp_BLL.GetMaxOrderIndex(obj_efile.FileID, Globals.ProjectNO) + 1;

                                        #region
                                        /*if (obj_efile.ProjectNO != Globals.ProjectNO || obj_efile.DoStatus != 1)//ˢ�¹���
                                        {
                                            obj_efile.DocYs = 0;
                                            obj_efile.DoStatus = 0;
                                        }
                                        else
                                        {
                                            obj_efile.DocYs = 1;
                                            obj_efile.DoStatus = 1;
                                        }
                                        FileInfo efile = new FileInfo(obj_efile.filepath);
                                        if (File.Exists(efilePath + efile.Name))
                                        {
                                            System.IO.File.Copy(efilePath + efile.Name,
                                                Globals.ProjectPath + "ODOC\\" + obj_efile.CellID + efile.Extension, true);//������ǰ�����ļ�
                                            obj_efile.filepath = "ODOC\\" + obj_efile.CellID + efile.Extension;

                                            if (efile.Extension.ToLower() != ".cll".ToLower())
                                            {
                                                obj_efile.DocYs = 1;
                                                obj_efile.DoStatus = 1;
                                            }
                                        }
                                        else
                                        {
                                            obj_efile.filepath = "";
                                        }
                                         * */
                                        #endregion

                                        if (EFileAction_flg)
                                        {
                                            CEfileImp_BLL.Insert(obj_efile);
                                            //AddEFileList.Add(obj_efile);
                                        }
                                        else
                                            CEfileImp_BLL.Update(obj_efile);
                                    }

                                    //foreach (MDL.T_CellAndEFile obj_efile in AddEFileList)
                                    //{
                                    //    CEfileImp_BLL.Insert(obj_efile);
                                    //}

                                    fileMDL.selected = 1;//�����˵����ļ� �޸�Ŀ¼״̬
                                    fileMDL.ProjectNO = Globals.ProjectNO;
                                    fileImp_BLL.Update(fileMDL);
                                }
                            }
                            #endregion
                        }
                        else if (isVisable_flg == 0)
                        {
                            #region ===============================================================================
                            tbl_ImpFileTemp.Rows.Clear();
                            tbl_ImpFileTemp.ImportRow(file_row);

                            IList<MDL.T_FileList> fileMDL_List =
                                MyCommon.DataTableToList<MDL.T_FileList>(tbl_ImpFileTemp);

                            if (fileMDL_List != null && fileMDL_List.Count > 0)
                            {
                                fileMDL_List[0].FileID = Guid.NewGuid().ToString();

                                #region ===========================================================================
                                if (tbl_efileInfo != null && tbl_efileInfo.Rows.Count > 0)
                                {
                                    DataRow[] efile_rows =
                                        tbl_efileInfo.Select("FileID='" + fileID + "'", "orderindex asc");//����ڵ��µĵ����ļ�

                                    if (efile_rows != null && efile_rows.Length > 0)
                                    {
                                        tbl_ImpEFileTemp.Rows.Clear();
                                        foreach (DataRow efile_row in efile_rows)
                                        {
                                            tbl_ImpEFileTemp.ImportRow(efile_row);
                                        }
                                        IList<MDL.T_CellAndEFile> efileMDL_List =
                                                MyCommon.DataTableToList<MDL.T_CellAndEFile>(tbl_ImpEFileTemp);//ת���ڵ��µ����ļ���¼

                                        if (efileMDL_List != null && efileMDL_List.Count > 0)
                                        {

                                            foreach (MDL.T_CellAndEFile obj_efile in efileMDL_List)
                                            {
                                                if (obj_efile.filepath == null || obj_efile.filepath.Trim() == "")
                                                    continue;

                                                obj_efile.CellID = Guid.NewGuid().ToString();
                                                obj_efile.FileID = fileMDL_List[0].FileID;

                                                if (obj_efile.ProjectNO != Globals.ProjectNO)
                                                {
                                                    obj_efile.DocYs = 0;
                                                    obj_efile.DoStatus = 0;

                                                    FileInfo efile = new FileInfo(obj_efile.filepath);
                                                    if (File.Exists(efilePath + obj_efile.filepath))
                                                    {
                                                        System.IO.File.Copy(efilePath + obj_efile.filepath,
                                                            Globals.ProjectPath + "ODOC\\" + obj_efile.CellID + efile.Extension, true);//������ǰ�����ļ�
                                                        obj_efile.filepath = "ODOC\\" + obj_efile.CellID + efile.Extension;

                                                        if (efile.Extension.ToLower() != ".cll".ToLower())
                                                        {
                                                            obj_efile.DocYs = 1;
                                                            obj_efile.DoStatus = 1;
                                                        }
                                                    }
                                                    else
                                                    {
                                                        obj_efile.filepath = "";
                                                    }
                                                }
                                                else
                                                {
                                                    if (obj_efile.DoStatus != 1)
                                                    {
                                                        obj_efile.DocYs = 0;
                                                        obj_efile.DoStatus = 0;

                                                        FileInfo efile = new FileInfo(obj_efile.filepath);
                                                        if (File.Exists(efilePath + obj_efile.filepath))
                                                        {
                                                            System.IO.File.Copy(efilePath + obj_efile.filepath,
                                                                Globals.ProjectPath + "ODOC\\" + obj_efile.CellID + efile.Extension, true);//������ǰ�����ļ�
                                                            obj_efile.filepath = "ODOC\\" + obj_efile.CellID + efile.Extension;

                                                            if (efile.Extension.ToLower() != ".cll".ToLower())
                                                            {
                                                                obj_efile.DocYs = 1;
                                                                obj_efile.DoStatus = 1;
                                                            }
                                                        }
                                                        else
                                                        {
                                                            obj_efile.filepath = "";
                                                        }
                                                    }
                                                    else
                                                    {
                                                        obj_efile.DoStatus = 1;

                                                        FileInfo efile = new FileInfo(obj_efile.filepath);
                                                        if (File.Exists(efilePath + obj_efile.filepath))
                                                        {
                                                            System.IO.File.Copy(efilePath + obj_efile.filepath,
                                                                Globals.ProjectPath + "ODOC\\" + obj_efile.CellID + efile.Extension, true);//������ǰ�����ļ�
                                                            obj_efile.filepath = "ODOC\\" + obj_efile.CellID + efile.Extension;
                                                        }
                                                        else
                                                        {
                                                            obj_efile.filepath = "";
                                                        }

                                                        if (obj_efile.DocYs == 0)
                                                        {
                                                            FileInfo efile_pdf = new FileInfo(obj_efile.fileTreePath);
                                                            if (File.Exists(efilePath + obj_efile.fileTreePath))
                                                            {
                                                                System.IO.File.Copy(efilePath + obj_efile.fileTreePath,
                                                                    Globals.ProjectPath + "PDF\\" + obj_efile.CellID + efile_pdf.Extension, true);//������ǰ�����ļ�
                                                                obj_efile.fileTreePath = "PDF\\" + obj_efile.CellID + efile_pdf.Extension;
                                                            }
                                                            else
                                                            {
                                                                obj_efile.fileTreePath = "";
                                                                obj_efile.DocYs = 1;//��������PDF
                                                            }
                                                        }
                                                    }
                                                }

                                                obj_efile.ProjectNO = Globals.ProjectNO;
                                                obj_efile.orderindex =
                                                    CEfileImp_BLL.GetMaxOrderIndex(obj_efile.FileID, Globals.ProjectNO) + 1;

                                                CEfileImp_BLL.Insert(obj_efile);
                                            }
                                            fileMDL_List[0].selected = 1;//�����˵����ļ� �޸�Ŀ¼״̬
                                        }
                                    }
                                }
                                #endregion

                                fileMDL_List[0].ArchiveID = "";
                                if (fileMDL_List[0].ProjectNO == Globals.ProjectNO)
                                {
                                    if (fileMDL_List[0].fileStatus == "4" || fileMDL_List[0].fileStatus == "6")
                                        fileMDL_List[0].fileStatus = "4";
                                    else
                                        fileMDL_List[0].fileStatus = "0";

                                    if (fileMDL_List[0].filepath != null && fileMDL_List[0].filepath.Trim() != "")
                                    {
                                        FileInfo file = new FileInfo(fileMDL_List[0].filepath);
                                        if (File.Exists(efilePath + file.Name))
                                        {
                                            System.IO.File.Copy(efilePath + file.Name,
                                                        Globals.ProjectPath + "MPDF\\" + fileMDL_List[0].FileID + file.Extension, true);//������ǰ�����ļ�
                                            fileMDL_List[0].filepath = "MPDF\\" + fileMDL_List[0].FileID + file.Extension;
                                        }
                                    }
                                }
                                else
                                    fileMDL_List[0].fileStatus = "0";
                                fileMDL_List[0].ParentID = ImpTreeNode_Name;
                                fileMDL_List[0].ProjectNO = Globals.ProjectNO;
                                fileMDL_List[0].OrderIndex = fileImp_BLL.GetMaxOrderIndex(fileMDL_List[0].ParentID, Globals.ProjectNO) + 1;
                                fileImp_BLL.Insert(fileMDL_List[0]);
                            }
                            #endregion
                        }
                    }
                    else
                    {
                        ImpDataInfo(tbl_fileInfo, tbl_efileInfo, fileID, tbl_ImpFileTemp,
                            tbl_ImpEFileTemp, fileID_temp, efilePath, FlordOrFile_flg);
                    }
                    #endregion
                }

                lblTitle.Text = @"���ڵ��룺" + fileTitle;
                if (curStateIndex < progressBar1.Maximum)
                    progressBar1.Value = curStateIndex++;
                else
                    progressBar1.Value = progressBar1.Maximum - 1;
                Application.DoEvents();
            }
        }

        /// <summary>
        /// ����ͬ�Ľڵ����� �ݹ���ӵ��ϼ��ڵ���
        /// </summary>
        /// <param name="tbl_fileInfo">�ļ���Ϣ��</param>
        /// <param name="tbl_efileInfo">�����ļ���Ϣ��</param>
        /// <param name="parentFileID">�ϼ����ڵ�</param>
        /// <param name="parentFileIDNewID">�����µ�NewID</param>
        /// <param name="tbl_ImpFileTemp">fileTemp��</param>
        /// <param name="tbl_ImpEFileTemp">ImpEFileTemp��</param>
        /// <param name="efilePath">�����ļ�·��</param>
        private void ImpDataInfo(DataTable tbl_fileInfo, DataTable tbl_efileInfo,
            string parentFileID, string parentFileIDNewID,
            DataTable tbl_ImpFileTemp, DataTable tbl_ImpEFileTemp, string efilePath)
        {    
            DataRow[] file_rows = tbl_fileInfo.Select("ParentID='" + parentFileID + "'", "orderindex asc");

            foreach (DataRow file_row in file_rows)
            {
                string fileID = file_row["FileID"] == null ? "" : file_row["FileID"].ToString().Trim();
                string fileTitle = file_row["wjtm"] == null ? "" : file_row["wjtm"].ToString().Trim();

                tbl_ImpFileTemp.Rows.Clear();
                tbl_ImpFileTemp.ImportRow(file_row);

                IList<MDL.T_FileList> fileMDL_List =
                    MyCommon.DataTableToList<MDL.T_FileList>(tbl_ImpFileTemp);

                if (fileMDL_List != null && fileMDL_List.Count > 0)
                {
                    fileMDL_List[0].FileID = Guid.NewGuid().ToString();
                    if (file_row["isvisible"].ToString() == "1")//�ļ�
                    {
                        #region ===========================================================================
                        if (tbl_efileInfo != null && tbl_efileInfo.Rows.Count > 0)
                        {
                            DataRow[] efile_rows =
                                tbl_efileInfo.Select("FileID='" + fileID + "'", "orderindex asc");//����ڵ��µĵ����ļ�

                            if (efile_rows != null && efile_rows.Length > 0)
                            {
                                tbl_ImpEFileTemp.Rows.Clear();
                                foreach (DataRow efile_row in efile_rows)
                                {
                                    tbl_ImpEFileTemp.ImportRow(efile_row);
                                }
                                IList<MDL.T_CellAndEFile> efileMDL_List =
                                        MyCommon.DataTableToList<MDL.T_CellAndEFile>(tbl_ImpEFileTemp);//ת���ڵ��µ����ļ���¼

                                if (efileMDL_List != null && efileMDL_List.Count > 0)
                                {
                                    foreach (MDL.T_CellAndEFile obj_efile in efileMDL_List)
                                    {
                                        if (obj_efile.filepath == null || obj_efile.filepath.Trim() == "")
                                            continue;

                                        obj_efile.CellID = Guid.NewGuid().ToString();
                                        obj_efile.FileID = fileMDL_List[0].FileID;

                                        if (obj_efile.ProjectNO != Globals.ProjectNO)
                                        {
                                            obj_efile.DocYs = 0;
                                            obj_efile.DoStatus = 0;

                                            FileInfo efile = new FileInfo(obj_efile.filepath);
                                            if (File.Exists(efilePath + obj_efile.filepath))
                                            {
                                                System.IO.File.Copy(efilePath + obj_efile.filepath,
                                                    Globals.ProjectPath + "ODOC\\" + obj_efile.CellID + efile.Extension, true);//������ǰ�����ļ�
                                                obj_efile.filepath = "ODOC\\" + obj_efile.CellID + efile.Extension;

                                                if (efile.Extension.ToLower() != ".cll".ToLower())
                                                {
                                                    obj_efile.DocYs = 1;
                                                    obj_efile.DoStatus = 1;
                                                }
                                            }
                                            else
                                            {
                                                obj_efile.filepath = "";
                                            }
                                        }
                                        else
                                        {
                                            if (obj_efile.DoStatus != 1)
                                            {
                                                obj_efile.DocYs = 0;
                                                obj_efile.DoStatus = 0;

                                                FileInfo efile = new FileInfo(obj_efile.filepath);
                                                if (File.Exists(efilePath + obj_efile.filepath))
                                                {
                                                    System.IO.File.Copy(efilePath + obj_efile.filepath,
                                                        Globals.ProjectPath + "ODOC\\" + obj_efile.CellID + efile.Extension, true);//������ǰ�����ļ�
                                                    obj_efile.filepath = "ODOC\\" + obj_efile.CellID + efile.Extension;

                                                    if (efile.Extension.ToLower() != ".cll".ToLower())
                                                    {
                                                        obj_efile.DocYs = 1;
                                                        obj_efile.DoStatus = 1;
                                                    }
                                                }
                                                else
                                                {
                                                    obj_efile.filepath = "";
                                                }
                                            }
                                            else
                                            {
                                                obj_efile.DoStatus = 1;

                                                FileInfo efile = new FileInfo(obj_efile.filepath);
                                                if (File.Exists(efilePath + obj_efile.filepath))
                                                {
                                                    System.IO.File.Copy(efilePath + obj_efile.filepath,
                                                        Globals.ProjectPath + "ODOC\\" + obj_efile.CellID + efile.Extension, true);//������ǰ�����ļ�
                                                    obj_efile.filepath = "ODOC\\" + obj_efile.CellID + efile.Extension;
                                                }
                                                else
                                                {
                                                    obj_efile.filepath = "";
                                                }

                                                if (obj_efile.DocYs == 0)
                                                {
                                                    FileInfo efile_pdf = new FileInfo(obj_efile.fileTreePath);
                                                    if (File.Exists(efilePath + obj_efile.fileTreePath))
                                                    {
                                                        System.IO.File.Copy(efilePath + obj_efile.fileTreePath,
                                                            Globals.ProjectPath + "PDF\\" + obj_efile.CellID + efile_pdf.Extension, true);//������ǰ�����ļ�
                                                        obj_efile.fileTreePath = "PDF\\" + obj_efile.CellID + efile_pdf.Extension;
                                                    }
                                                    else
                                                    {
                                                        obj_efile.fileTreePath = "";
                                                        obj_efile.DocYs = 1;//��������PDF
                                                    }
                                                }
                                            }
                                        }

                                        obj_efile.ProjectNO = Globals.ProjectNO;
                                        obj_efile.orderindex =
                                            CEfileImp_BLL.GetMaxOrderIndex(obj_efile.FileID, Globals.ProjectNO) + 1;

                                        #region
                                        /*if (obj_efile.ProjectNO != Globals.ProjectNO || obj_efile.DoStatus != 1)
                                        {
                                            obj_efile.DocYs = 0;
                                            obj_efile.DoStatus = 0;
                                        }
                                        else
                                        {
                                            obj_efile.DocYs = 1;
                                            obj_efile.DoStatus = 1;
                                        }
                                        FileInfo efile = new FileInfo(obj_efile.filepath);
                                        if (File.Exists(efilePath + efile.Name))
                                        {
                                            System.IO.File.Copy(efilePath + efile.Name,
                                                Globals.ProjectPath + "ODOC\\" + obj_efile.CellID + efile.Extension, true);//������ǰ�����ļ�
                                            obj_efile.filepath = "ODOC\\" + obj_efile.CellID + efile.Extension;
                                            if (efile.Extension.ToLower() != ".cll".ToLower())
                                            {
                                                obj_efile.DocYs = 1;
                                                obj_efile.DoStatus = 1;
                                            }
                                        }
                                        else
                                        {
                                            obj_efile.filepath = "";
                                        }
                                        */
                                        #endregion

                                        //���ԭ����Ϣ
                                        MyCommon.InsertOldEfile(obj_efile.CellID,  Globals.ProjectNO, Globals.LoginUser, "�ļ��Ǽ�-�����", obj_efile.filepath);    


                                        CEfileImp_BLL.Insert(obj_efile);
                                    }
                                    fileMDL_List[0].selected = 1;//�����˵����ļ� �޸�Ŀ¼״̬
                                }
                            }
                        }
                        #endregion
                    }
                    else//�ļ���
                    {
                        ImpDataInfo(tbl_fileInfo, tbl_efileInfo, fileID,
                            fileMDL_List[0].FileID, tbl_ImpFileTemp, tbl_ImpEFileTemp, efilePath);
                    }
                    fileMDL_List[0].ArchiveID = "";
                    if (fileMDL_List[0].ProjectNO == Globals.ProjectNO)
                    {
                        if (fileMDL_List[0].fileStatus == "4" || fileMDL_List[0].fileStatus == "6")
                            fileMDL_List[0].fileStatus = "4";
                        else
                            fileMDL_List[0].fileStatus = "0";

                        if (fileMDL_List[0].filepath != null && fileMDL_List[0].filepath.Trim() != "")
                        {
                            FileInfo file = new FileInfo(fileMDL_List[0].filepath);
                            if (File.Exists(efilePath + file.Name))
                            {
                                System.IO.File.Copy(efilePath + file.Name,
                                            Globals.ProjectPath + "MPDF\\" + fileMDL_List[0].FileID + file.Extension, true);//������ǰ�����ļ�
                                fileMDL_List[0].filepath = "MPDF\\" + fileMDL_List[0].FileID + file.Extension;
                            }
                        }
                    }
                    else
                        fileMDL_List[0].fileStatus = "0";
                    fileMDL_List[0].ParentID = parentFileIDNewID;
                    fileMDL_List[0].ProjectNO = Globals.ProjectNO;
                    fileMDL_List[0].OrderIndex = fileImp_BLL.GetMaxOrderIndex(parentFileID, Globals.ProjectNO) + 1;
                    fileImp_BLL.Insert(fileMDL_List[0]);
                }

                lblTitle.Text = @"���ڵ��룺" + fileTitle;
                if (curStateIndex < progressBar1.Maximum)
                    progressBar1.Value = curStateIndex++;
                else
                    progressBar1.Value = progressBar1.Maximum - 1;
                Application.DoEvents();
            }
        }

        /// <summary>
        /// �ж��Ƿ���ӵ����ļ�
        /// </summary>
        /// <param name="FileID">Ŀ��Ŀ¼��ID</param>
        /// <param name="projNO">��ǰ����ID</param>
        /// <returns>bool��true��ʾ��� false��ʾ�����</returns>
        private bool CheckedImpEFile(string FileID, string projNO)
        {
            bool return_flg = true;
            IList<MDL.T_CellAndEFile> EFile_List =
                CEfileImp_BLL.FindByFileID(FileID, projNO);

            if (EFile_List.Count > 0)
            {
                return_flg = false;
            }
            else
            {
                IList<MDL.T_CellFileTemplate> EFTemplate_List = (new BLL.T_CellFileTemplate_BLL()).FindByFileID(FileID);
                if (EFTemplate_List != null && EFTemplate_List.Count > 0)
                {
                    return_flg = false;
                }
            }
            return return_flg;
        }

        /// <summary>
        /// �ж��Ƿ���ӵ����ļ�
        /// </summary>
        /// <param name="FileID">Ŀ��Ŀ¼��ID</param>
        /// <param name="projNO">��ǰ����ID</param>
        /// <returns>bool��true��ʾ��� false��ʾ�޸�</returns>
        private bool CheckedImpEFileAction(string EFileName, string FileID, string projNO, ref string efielID)
        {
            bool return_flg = true;
            IList<MDL.T_CellAndEFile> EFile_List =
                CEfileImp_BLL.FindByFileID(FileID, projNO);

            if (EFile_List.Count > 0)
            {
                return_flg = false;
                /*
                 * �������ͬ�Ľڵ����� ���޸ĵ�һ����ͬ������
                 * ���û�� ��Ĭ���޸ĵ�һ��
                 */

                foreach (MDL.T_CellAndEFile ef_mdl in EFile_List)
                {
                    if (ef_mdl.DoStatus != 1)
                    {
                        efielID = ef_mdl.CellID;
                        return_flg = false;
                        break;
                    }
                }
                //�޸� �ж��Ƿ���ֵ
                if (String.IsNullOrEmpty(efielID))
                    return_flg = true;
            }
            return return_flg;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void btnExplorer_Click_1(object sender, EventArgs e)
        {

        }

        private void btnConfirm_Click_1(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {

        }
    }
}
