using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.IO;
using System.Drawing.Text;
using ERM.Common;
using TX.Framework.WindowUI.Forms;

namespace ERM.UI
{
    /// <summary>
    /// ʩ���ñ�
    /// </summary>
    public partial class frmCellEdit : ERM.UI.Controls.Skin_DevEX
    {
        #region ������ʼ��
        private frmCellMain _parentForm;
        TreeFactory treeFactory = new TreeFactory();
        private int myX = 0;
        private int myY = 0;
        private string ProjectNO;
        private TreeNodeEx fileNode;
        //ERM.CBLL.CellTreesData treesData = new ERM.CBLL.CellTreesData();
        ProjectFactory projectFactory;
        //string codetype;
        private int[] CustomColors;
        private bool FillAll = false;
        public static Boolean IsOK = false;
        private string TitleName = "";
        private delPrintPDF MyDel;
        //private string AddCellFormTitle = "�������";//��ӱ��ʱ���������ƵĴ����title
        TreeNode LastNode = null;

        #endregion

        #region ���庯��
        #endregion

        #region �Զ��庯��
        #endregion

        /// <summary>
        /// ���캯��
        /// </summary>
        /// <param name="parentForm">������ر�ʱ������ʾ</param>
        /// <param name="_projectinfo">������Ϣ ˢ�±����</param>
        public frmCellEdit(frmCellMain parentForm, TreeNodeEx theNode, delPrintPDF _del)
        {
            InitializeComponent();
            this.Cell1.Login("digipower", "11100101845", "1040-1145-0062-4005");
            this.Cell1.LocalizeControl(0x804);
            this.Cell2.Login("digipower", "11100101845", "1040-1145-0062-4005");
            this.Cell2.LocalizeControl(0x804);
            this._parentForm = parentForm;
            MyDel = _del;
            //this._parentForm.ShowInTaskbar = false;
            this._parentForm.Hide();
            this.ProjectNO = Globals.ProjectNO;
            this.projectFactory = new ProjectFactory(Globals.ProjectNO);
            fileNode = theNode;
            this.Init();
        }
        /// <summary>
        /// ��ʼ����ϸ����
        /// </summary>
        private void Init()
        {
            try
            {
                TitleName = "";
                tssLabel1.Text = Globals.NormalStatus;                          //״̬��:����
                tssLabel2.Text = Globals.AppTitle;                              //״̬��:Ӧ�ó������
                tssLabel3.Text = "��ǰ�û���" + Globals.LoginUser;              //״̬��:��ǰ�û�  
                ////����ѡ��
                InitComboBox();
                ////�������� TreeView �� ImageList
                ImageList imageList1 = treeFactory.CreateTreeImageList();
                treeView1.ImageList = imageList1;
                treeFactory.GetCelllFileList(this.treeView1, fileNode.Name);
            }
            catch (Exception ex)
            {
            }
        }
        /// <summary>
        /// ��ʼ������ComboBox
        /// </summary>
        private void InitComboBox()
        {
            FontFamily[] fonts = (new InstalledFontCollection()).Families;
            for (int i = 0; i < fonts.Length; i++)
            {
                cboFonts.Items.Add(fonts[i].Name);
            }
            cboFonts.Text = Cell1.GetDefaultFontName();
            cboFontSize.Text = Cell1.GetDefaultFontSize().ToString();
            cboLine.ImageList = imageBorder;
            cboLine.DropDownStyle = ComboBoxStyle.DropDownList;
            for (int i = 0; i < imageBorder.Images.Count; i++)
            {
                cboLine.Items.Add(new ComboBoxExItem("", i));
            }
            cboLine.SelectedIndex = 0;
            cboZoom.Text = "100%";
        }
        /// <summary>
        /// �������ӡ��pdf
        /// </summary>
        /// <param name="cellfile">����ȫ·��</param>
        /// <param name="SavePath">pdf����·��</param>
        private void frmCellEdit_Load(object sender, EventArgs e)
        {
            this._parentForm.Visible = false;
            this.ActiveControl = treeView1; //�۽�
            Cell1.EnableUndo(1);     //��������
            TitleName = fileNode.Text.Remove(0, fileNode.Text.IndexOf(']') + 1).Replace("*", "");
            this.Text = Globals.AppTitle + " - " + TitleName;  //�������
            Cell1.RdonlyCellColor = 16775152;//�����豳��ɫ�ˣ�ֱ�Ӱ������ĵ�Ԫ��ı�����ɵ���ɫ
        }
        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.CheckSave();
            this._parentForm.Show();
            this._parentForm.Visible = true;
            this._parentForm.Activate();
            Cell1.closefile();
            Cell2.closefile();
        }
        /// <summary>
        /// ��ʾ���������Ŀ¼
        /// </summary>
        private void ShowHideTree()
        {
            if (splitContainer1.Panel1Collapsed)
            {
                splitContainer1.Panel1Collapsed = false;
                tsmiHideArchive.Text = "����Ŀ¼";
                btnHideArchive.Text = "����Ŀ¼";
            }
            else
            {
                splitContainer1.Panel1Collapsed = true;
                tsmiHideArchive.Text = "��ʾĿ¼";
                btnHideArchive.Text = "��ʾĿ¼";
            }
        }
        /// <summary>
        /// ��乤����Ϣ�����
        /// </summary>
        /// <param name="fullfilename">�ļ�·��</param>
        /// <param name="RefreshHeadOnly">ֻˢ�±�ͷ</param>
        /// <param name="CellIndex">����Index,ֻˢ�±�ͷʱ��������</param>
        /// <param name="title">�ޱ�ʽ��̧ͷ,ֻˢ�±�ͷʱ��������</param>
        /// <param name="CheckPage">����ʱtrue ������ж�����</param>
        /// <param name="Isfb">�Ƿ�Ϊ�ֲ�</param>
        /// <param name="Isfx">�Ƿ�Ϊ����</param>
        /// <returns>��ҳ��</returns>
        public int RefreshCell(string fullfilename, bool RefreshHeadOnly, int CellIndex, string title, bool Isfb, bool Isfx, bool CheckPage)
        {
            Cell1.closefile();
            Cell2.closefile();

            int a = Cell2.OpenFile(fullfilename, "");

            if (a != 1)
            {
                TXMessageBoxExtensions.Info("��ʾ������(" + a + ")  ģ���ʧ��01����ȷ��ģ��İ汾�Ƿ���ȷ");
                Cell1.OpenFile(Globals.BlankCell, "");
                return 0;
            }

            Hashtable CellHash = GetCellParem();

            int pages = 0;
            string key;
            string keyType;
            for (int sheet = 0; sheet < Cell2.GetTotalSheets(); sheet++)
            {
                for (int col = 1; col < Cell2.GetCols(sheet); col++)
                {
                    for (int row = 1; row < Cell2.GetRows(sheet); row++)
                    {
                        key = Cell2.GetCellNote(col, row, sheet).ToLower();
                        if (key != "" && !key.StartsWith("run"))
                        {
                            try
                            {
                                keyType = MyCommon.Left(key, 1);  //�������
                                key = MyCommon.Right(key, key.Length - 2); //�����ı���
                                switch (keyType)
                                {
                                    case "0": //˳���
                                        if (!RefreshHeadOnly)  //ֻˢ�±�ͷʱ��ִ��
                                        {
                                            string IndexID = MyCommon.Right(("00" + CellIndex.ToString()), 3);
                                            string IndexID1 = IndexID.Substring(2, 1);
                                            string IndexID2 = IndexID.Substring(1, 1);
                                            string IndexID3 = IndexID.Substring(0, 1);
                                            if (key.ToLower() == "indexid")
                                                Cell2.S(col, row, sheet, IndexID);
                                            else if (key.ToLower() == "indexid1")
                                                Cell2.S(col, row, sheet, IndexID1);
                                            else if (key.ToLower() == "indexid2")
                                                Cell2.S(col, row, sheet, IndexID2);
                                            else if (key.ToLower() == "indexid3")
                                                Cell2.S(col, row, sheet, IndexID3);
                                        }
                                        break;
                                    case "1": //��Ŀ��Ϣ
                                        ////������ProjectDetail�����ݼ��У���ʼ���
                                        #region ��õ�Ԫ���еĿؼ�����
                                        /***********************************************************************
                                      *  ˵������õ�Ԫ���еĿؼ����� GetCellType
                                      *  
                                      *  0 Ϊһ�㵥Ԫ��
                                      *  1 ��Ť��Ԫ��
                                      *  2 ��ѡŤ��Ԫ��
                                      *  3 ������Ԫ��
                                      *  4 ��ѡŤ��Ԫ��
                                      *  5 ΢��Ť��Ԫ��
                                      *  6 �������ڵ�Ԫ��
                                      *  7 ͼ��Ԫ��
                                      *  8 �����뵥Ԫ��
                                      ******************************************************************/
                                        #endregion
                                        //int celltype = Cell2.GetCellType(col, row, sheet);
                                        //if (celltype == 3)
                                        //{

                                        //}
                                        //else
                                        //{
                                        if (projectFactory.ProjectDetail.Contains(key.ToLower()))
                                        {
                                            if (projectFactory.ProjectDetail[key.ToLower()].GetType() == typeof(System.String[]))//���¼����������ѡ��
                                            {
                                                Cell2.SetDroplistCell(col, row, sheet, MyCommon.Array2DroplistCell((string[])projectFactory.ProjectDetail[key.ToLower()]), 2);
                                                Cell2.SetCellString(col, row, sheet, ((string[])projectFactory.ProjectDetail[key.ToLower()])[0]);
                                            }
                                            else
                                            {
                                                if (projectFactory.ProjectDetail[key.ToLower()] != null &&
                                                    projectFactory.ProjectDetail[key.ToLower()].ToString().Trim() != "")
                                                    Cell2.S(col, row, sheet, projectFactory.ProjectDetail[key.ToLower()].ToString());
                                            }
                                        }
                                        else if (CellHash.Contains(key.ToLower()))
                                        {
                                            if (CellHash[key.ToLower()].GetType() == typeof(System.String[]))//���¼����������ѡ��
                                            {
                                                Cell2.SetDroplistCell(col, row, sheet, MyCommon.Array2DroplistCell((string[])CellHash[key.ToLower()]), 2);
                                                Cell2.SetCellString(col, row, sheet, ((string[])CellHash[key.ToLower()])[0]);
                                            }
                                            else
                                            {
                                                if (CellHash[key.ToLower()] != null &&
                                                    CellHash[key.ToLower()].ToString().Trim() != "")
                                                    Cell2.S(col, row, sheet, CellHash[key.ToLower()].ToString());
                                            }
                                        }
                                        // }
                                        break;
                                    case "2": //��ǰ����
                                        if (!RefreshHeadOnly) //ֻˢ�±�ͷʱ��ִ��
                                        {
                                            Cell2.S(col, row, sheet, DateTime.Now.ToString("yyyy��MM��dd��"));
                                        }
                                        break;
                                    case "3": //�ޱ�ʽ̧ͷ
                                        if (!RefreshHeadOnly) //ֻˢ�±�ͷʱ��ִ��
                                        {
                                            Cell2.S(col, row, sheet, title);
                                        }
                                        break;
                                    case "4": //ֻ����������
                                        if (!RefreshHeadOnly) //ֻˢ�±�ͷʱ��ִ��
                                        {
                                            Cell2.SetCellValidChars(col, row, sheet, 1);
                                        }
                                        break;
                                    case "5"://�ֲ�
                                        {
                                            switch (key)
                                            {
                                                case "xh"://���
                                                    {
                                                        if (Isfb)
                                                        {
                                                            if (xh_fb < dvfb.Count)
                                                            {
                                                                Cell2.S(col, row, sheet, dvfb[xh_fb]["xh"].ToString());
                                                                xh_fb++;
                                                            }
                                                        }
                                                    }
                                                    break;
                                                case "fbmc"://�ֲ�����
                                                    {
                                                        if (Isfb)
                                                        {
                                                            if (fbmc_fb < dvfb.Count)
                                                            {
                                                                Cell2.S(col, row, sheet, dvfb[fbmc_fb]["fbmc"].ToString());
                                                                fbmc_fb++;
                                                            }
                                                        }
                                                    }
                                                    break;
                                                case "fxmc"://��������
                                                    {
                                                        if (Isfb)
                                                        {
                                                            if (fxmc_fb < dvfb.Count)
                                                            {
                                                                Cell2.S(col, row, sheet, dvfb[fxmc_fb]["fxmc"].ToString());
                                                                fxmc_fb++;
                                                            }
                                                        }
                                                    }
                                                    break;
                                                case "ps"://����
                                                    {
                                                        if (Isfb)
                                                        {
                                                            if (ps_fb < dvfb.Count)
                                                            {
                                                                Cell2.S(col, row, sheet, dvfb[ps_fb]["ps"].ToString());
                                                                ps_fb++;
                                                            }
                                                        }
                                                    }
                                                    break;
                                            }
                                        }
                                        break;
                                    case "6":
                                        {
                                            switch (key)
                                            {
                                                case "fxmc"://��������
                                                    {
                                                        if (Isfx)
                                                        {
                                                            if (fxmc_fx < ds_fx.Tables[ys_fx].Rows.Count)
                                                            {
                                                                if (!CheckPage)
                                                                    Cell2.S(col, row, sheet, ds_fx.Tables[ys_fx].Rows[fxmc_fx]["fxmc"].ToString());
                                                                fxmc_fx++;
                                                            }
                                                        }
                                                    }
                                                    break;
                                                case "ps"://����
                                                    {
                                                        if (Isfx)
                                                        {
                                                            if (ps_fx < ds_fx.Tables[ys_fx].Rows.Count)
                                                            {
                                                                if (!CheckPage)
                                                                    Cell2.S(col, row, sheet, ds_fx.Tables[ys_fx].Rows[ps_fx]["ps"].ToString());
                                                                ps_fx++;
                                                            }
                                                        }
                                                    }
                                                    break;
                                                case "xh"://���
                                                    {
                                                        if (Isfx)
                                                        {
                                                            if (xh_fx < ds_fx.Tables[ys_fx].Rows.Count)
                                                            {
                                                                if (!CheckPage)
                                                                    Cell2.S(col, row, sheet, ds_fx.Tables[ys_fx].Rows[xh_fx]["xh"].ToString());
                                                                xh_fx++;
                                                            }
                                                        }
                                                    }
                                                    break;
                                                case "bw"://��λ
                                                    {
                                                        if (Isfx)
                                                        {
                                                            if (bw_fx < ds_fx.Tables[ys_fx].Rows.Count)
                                                            {
                                                                if (!CheckPage)
                                                                    Cell2.S(col, row, sheet, ds_fx.Tables[ys_fx].Rows[bw_fx]["bw"].ToString());
                                                                bw_fx++;
                                                            }
                                                        }
                                                    }
                                                    break;
                                            }
                                        }
                                        break;
                                    case "7"://�������еĲ�λ
                                        {
                                            Cell2.S(col, row, sheet, title);
                                        }
                                        break;
                                }
                            }
                            catch (Exception e)
                            {
                            }
                        }
                    }
                }
                string TittleName = Cell2.GetSheetLabel(sheet);
                if (TittleName.Contains(Globals.Descriptive) == false)
                {
                    pages = pages + Cell2.PrintGetPages(sheet);
                }
            }
            if (Isfx && CheckPage)
            {
                int pages2 = ds_fx.Tables[ys_fx].Rows.Count / bw_fx;
                if ((ds_fx.Tables[ys_fx].Rows.Count % bw_fx) > 0)
                    pages2++;
                if (pages2 > 1)
                {
                    Cell2.InsertSheet(1, pages2 - 1);
                    for (int i = 1; i < pages2; i++)
                        Cell2.CopySheet(i, 0);
                }
                Cell2.SaveFile(fullfilename, 0);
                // Cell2.OpenFile(fullfilename, "");//2013 3.25 YQ ģ��̫���ʱ�򣬱���̫�������ε��ٴδ��ļ�����
                Cell2.closefile();
                bw_fx = 0;
                xh_fx = 0;
                fxmc_fx = 0;
                ps_fx = 0;
                pages = RefreshCell(fullfilename, RefreshHeadOnly, CellIndex, title, Isfb, Isfx, false);
            }

            Cell2.SetCurSheet(0);
            Cell2.PrintSetMargin(5, 5, 5, 5);//����ҳ�߾�

            Cell2.SaveFile(fullfilename, 0);
            // Cell2.OpenFile(fullfilename, "");//2013 3.25 YQ ģ��̫���ʱ�򣬱���̫�������ε��ٴδ��ļ�����
            Cell2.closefile();
            return pages;
        }
        /// <summary>
        /// �޸Ľڵ�����
        /// </summary>
        private void EditNode()
        {
            try
            {
                TreeNodeEx theNode = (TreeNodeEx)treeView1.SelectedNode;
                if (theNode == null) return;
                frmCellNameEdit frm = new frmCellNameEdit(theNode, fileNode);
                DialogResult ret = frm.ShowDialog();
                if (ret == DialogResult.OK)
                {
                    int pages = 0;
                    MDL.T_CellAndEFile cellMDL = (new BLL.T_CellAndEFile_BLL()).Find(theNode.Name, Globals.ProjectNO);
                    if (cellMDL != null)
                    {
                        cellMDL.title = frm.txtTitle.Text;
                        (new BLL.T_CellAndEFile_BLL()).Update(cellMDL);
                        theNode.Text = frm.txtTitle.Text.Trim();
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }
        /// <summary>
        /// ɾ����ǰ�ڵ�
        /// </summary>
        private void DelNode()
        {
            //DialogResult ret = TXMessageBoxExtensions.Question("��ʾ��ȷ������ɾ����");
            bool isrefreshNoNode_flg = false;
            //if (ret == DialogResult.OK)
            {
                ArrayList objList = new ArrayList();
                foreach (TreeNodeEx obj in treeView1.Nodes)
                {
                    if (obj.Checked == true)
                    {
                        objList.Add(obj);
                    }
                }

                bool isdelete_flg = false;

                if (objList.Count > 0)
                {
                    if (TXMessageBoxExtensions.Question("��ʾ��ȷ��ɾ����Ŀ¼�µ�����ģ���ļ���  \n ����ܰ��ʾ��ɾ������Ϣ�����޷��ָ��������أ�������") != DialogResult.OK)
                        isdelete_flg = true;
                }
                else
                {
                    TXMessageBoxExtensions.Question("��ʾ����ѡ����Ҫɾ�����ļ���");
                    return;
                }

                if (isdelete_flg)
                    return;


                foreach (TreeNodeEx obj in objList)
                {
                    TreeNodeEx theNode = (TreeNodeEx)obj;// treeView1.SelectedNode;
                    if (theNode == null) return;

                    if (obj.Checked)
                    {
                        Cell1.closefile();
                        Cell2.closefile();

                        //Cell1.OpenFile(fileNode.NodeValue.Trim() == "" ? Globals.BlankCell : Globals.CellPath + fileNode.NodeValue, "");  //�򿪿հױ�񣬷�ֹɾ��ʧ��
                        Cell1.OpenFile(Globals.BlankCell, "");
                        (new BLL.T_CellAndEFile_BLL()).Delete(theNode.Name, Globals.ProjectNO);
                        MyCommon.DeleteOldEfile(theNode.Name, Globals.ProjectNO); //ɾ�������ļ���Ӧ��ԭ����Ϣ 

                        try
                        {
                            System.IO.File.Delete(Globals.ProjectPath + theNode.NodeValue);
                        }
                        catch { }
                        treeView1.Nodes.Remove(obj);
                        isrefreshNoNode_flg = true;
                    }
                }
            }
            if (isrefreshNoNode_flg)
            {
                if (treeView1.Nodes.Count > 0)
                {
                    treeView1.SelectedNode = treeView1.Nodes[0];
                    TreeNodeEx theNode = (TreeNodeEx)treeView1.SelectedNode;
                    Cell1.OpenFile(Globals.ProjectPath + theNode.NodeValue, "");
                }
                else
                {
                    Cell1.OpenFile(Globals.BlankCell, "");
                }
            }
        }
        /// <summary>
        /// ��ʾ��дʾ��
        /// </summary>
        private void ShowExampleFile()
        {
            if (fileNode != null) //�����ѡ�еĽڵ�
            {
                if (MyCommon.GetExamplePathFromTag(fileNode.Tag) != "")
                {
                    string examplePath = Globals.CellPath + MyCommon.GetExamplePathFromTag(fileNode.Tag);
                    if (System.IO.File.Exists(examplePath))
                    {
                        //frmShowExample frm = new frmShowExample(examplePath);
                        //frm.Owner = this;
                        //frm.Show();
                        //frm.Focus();
                    }
                }
            }
        }

        /// <summary>
        /// �����ƶ��������ƶ�
        /// </summary>
        /// <param name="upDown">up,down</param>
        private void MoveNode(string upDown)
        {
            TreeNode theNode = treeView1.SelectedNode;
            if (theNode == null) return;
            TreeNode OtherNode = null;
            if (upDown.ToUpper() == "UP")
            {
                OtherNode = theNode.PrevNode;
            }
            else
                OtherNode = theNode.NextNode;
            if (OtherNode == null)
                return;
            if (upDown.ToUpper() == "UP")
            {
                theNode.Remove();
                treeView1.Nodes.Insert(OtherNode.Index, theNode);
            }
            else
            {
                theNode.Remove();
                treeView1.Nodes.Insert(OtherNode.Index + 1, theNode);
            }
            BLL.T_CellAndEFile_BLL cellBLL = new ERM.BLL.T_CellAndEFile_BLL();
            MDL.T_CellAndEFile theNodeMDL = cellBLL.Find(theNode.Name, Globals.ProjectNO);
            MDL.T_CellAndEFile otherNodeMDL = cellBLL.Find(OtherNode.Name, Globals.ProjectNO);
            int OrderIndex = theNodeMDL.orderindex;
            theNodeMDL.orderindex = otherNodeMDL.orderindex;
            cellBLL.Update(theNodeMDL);
            otherNodeMDL.orderindex = OrderIndex;
            cellBLL.Update(otherNodeMDL);
            treeFactory.SelectNode2(treeView1, theNode.Name);
        }
        private void CopyCell()
        {
            TreeNodeEx theNode = (TreeNodeEx)treeView1.SelectedNode;
            if (theNode == null)
                return;
            //string s = GetNextTitle(theNode.Text);
            string s = theNode.Text; //+ "_����";
            if (!string.IsNullOrEmpty(s))
            {
                string sourpath = theNode.NodeValue;
                if (System.IO.File.Exists(Globals.ProjectPath + sourpath))
                {
                    FileInfo fileInfo = new FileInfo(Globals.ProjectPath + sourpath);
                    string newCellName = Guid.NewGuid().ToString();
                    System.IO.File.Copy(Globals.ProjectPath + sourpath, Globals.ProjectPath + "ODOC\\" + newCellName + fileInfo.Extension, true);
                    BLL.T_CellAndEFile_BLL cellBLL = new ERM.BLL.T_CellAndEFile_BLL();
                    MDL.T_CellAndEFile cellMDL = cellBLL.Find(theNode.Name, Globals.ProjectNO);
                    int OrderIndex = cellBLL.GetMaxOrderIndex(cellMDL.FileID, Globals.ProjectNO);
                    cellMDL.ProjectNO = Globals.ProjectNO;
                    cellMDL.CellID = newCellName;// Guid.NewGuid().ToString();
                    cellMDL.FileID = fileNode.Name;
                    cellMDL.DocYs = 1;
                    cellMDL.GdFileID = null;
                    cellMDL.DoStatus = 1;
                    cellMDL.filepath = "ODOC\\" + newCellName + fileInfo.Extension;
                    //cellMDL.title += "_����";
                    cellMDL.orderindex = OrderIndex + 1;
                    cellBLL.Add(cellMDL);

                    //���ԭ����Ϣ
                    // MyCommon.InsertOldEfile(cellMDL.CellID, cellMDL.FileID, Globals.ProjectNO, Globals.LoginUser, "�����ñ�-���ٸ���", Globals.ProjectPath + sourpath);    

                    TreeNodeEx newNode = (TreeNodeEx)theNode.Clone();
                    newNode.Name = cellMDL.CellID;
                    newNode.NodeValue = cellMDL.filepath;
                    newNode.ImageIndex = 3;
                    newNode.SelectedImageIndex = 3;
                    //newNode.Text += "_����";
                    treeView1.Nodes.Add(newNode);
                    //treeView1.SelectedNode = newNode;
                }
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            bool bRefresh = false;
            //CellOperate("SAVE");
            TreeNodeEx selectNode = (TreeNodeEx)treeView1.SelectedNode;
            if (selectNode.NodeValue == "")
            {//����δʹ�ù���������copyһ��
                BLL.T_CellFileTemplate_BLL cellTplBLL = new ERM.BLL.T_CellFileTemplate_BLL();
                MDL.T_CellFileTemplate cellTplMDL = cellTplBLL.Find(selectNode.Name);
                if (cellTplMDL != null)
                {
                    string CelllTplFile = Application.StartupPath + "\\Template" + cellTplMDL.filepath;
                    if (System.IO.File.Exists(CelllTplFile))
                    {
                        FileInfo fileInfo = new FileInfo(CelllTplFile);
                        string NewCellFileID = selectNode.Name;// Guid.NewGuid().ToString();
                        string NewCellFile = Globals.ProjectPath + "ODOC\\" + NewCellFileID + fileInfo.Extension;
                        System.IO.File.Copy(CelllTplFile, NewCellFile, true);
                        MDL.T_CellAndEFile cellMDL = (new ERM.BLL.T_CellAndEFile_BLL()).Find(selectNode.Name, Globals.ProjectNO);
                        //cellMDL.DoStatus = 1;
                        cellMDL.filepath = "ODOC\\" + NewCellFileID + fileInfo.Extension;
                        (new BLL.T_CellAndEFile_BLL()).Update(cellMDL);
                        selectNode.NodeValue = cellMDL.filepath;
                        bRefresh = true;
                    }
                }
            }
            if (!bRefresh)
            {
                MDL.T_CellAndEFile cellMDL = (new ERM.BLL.T_CellAndEFile_BLL()).Find(selectNode.Name, Globals.ProjectNO);
                if (cellMDL != null && cellMDL.DoStatus == 1)
                {
                    bRefresh = false;
                }
                else
                {
                    bRefresh = true;
                }
            }
            string cellFilePath = Globals.ProjectPath + selectNode.NodeValue;
            if (bRefresh == true && (System.IO.File.Exists(cellFilePath)))
            {
                RefreshCell(cellFilePath, false, selectNode.Index + 1, "", false, false, false);
            }
            if (System.IO.File.Exists(cellFilePath))
            {
                //Cell2.PrintSetMargin(15, 10, 5, 5);//����ҳ�߾�
                Cell2.closefile();
                Cell1.closefile();
                int open_flg = Cell1.OpenFile(cellFilePath, "");
                if (open_flg != 1)
                {
                    TXMessageBoxExtensions.Info("��ʾ������(" + open_flg + ")  ģ���ʧ��02����ȷ��ģ��İ汾�Ƿ���ȷ");
                    Cell1.OpenFile(Globals.BlankCell, "");
                }
                else
                    Cell1.PrintSetMargin(5, 5, 5, 5);//Cell1.PrintSetMargin(10, 10, 5, 5);

                //if (Cell1.GetTotalSheets() > 0)
                //    Cell2.SetCurSheet(0);
                if (Cell1.GetTotalSheets() > 1)
                    Cell1.SetCurSheet(0);
                Cell1.SaveEdit();
                Cell1.SetModified(0);//����û�иĶ���
            }
            else
            {
                Cell1.OpenFile(Globals.BlankCell, "");
            }
        }
        private void treeView1_DrawNode(object sender, DrawTreeNodeEventArgs e)
        {
            Font nodeFont = ((TreeView)(sender)).Font;  //����
            if ((e.State & TreeNodeStates.Selected) != 0)
            {
                e.Graphics.FillRectangle(Brushes.RoyalBlue, e.Node.Bounds);  //����
                e.Graphics.DrawString(e.Node.Text, nodeFont, Brushes.White, e.Bounds.Left, e.Bounds.Top + 4);  //ǰ������
            }
            else
            {
                e.Graphics.DrawString(e.Node.Text, nodeFont, Brushes.Black, e.Bounds.Left, e.Bounds.Top + 4);  //ǰ������
            }
        }
        private void treeView1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Point p = new Point(e.X, e.Y);
                TreeNode theNode = treeView1.GetNodeAt(p);
                if (theNode != null)
                {
                    treeView1.SelectedNode = theNode;
                }
            }
        }
        private void treeView1_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            string openfilename = Cell1.GetFileName();
            if (openfilename != null && openfilename != "")
            {
                Cell1.SaveEdit();
                Cell1.SaveFile(openfilename, 0);
                //Cell1.OpenFile(openfilename, ""); //2013 3.25 YQ ģ��̫���ʱ�򣬱���̫�������ε��ٴδ��ļ�����
            }
            if (Cell1.IsModified() == 1)
            {
                //DialogResult dialog = TXMessageBoxExtensions.Info("��ʾ���������޸ģ���Ҫ������", "��ʾ", MessageBoxButtons.YesNoCancel);
                //if (dialog == DialogResult.OK)
                //{
                //    this.CellOperate("save");
                //}
                //else if (dialog == DialogResult.Cancel)
                //{
                //    e.Cancel = true;
                //}
                this.CellOperate("save");
            }
        }
        private void tsmiCopyFile_Click(object sender, EventArgs e)
        {
            //CopyCell();
            toolCopy_Click(null, null);
        }
        private void tsmiPageSetup_Click(object sender, EventArgs e)
        {
            this.CellOperate("PageSetup");
        }
        private void tsmiPrintPreview_Click(object sender, EventArgs e)
        {
            this.CellOperate("Printpreview");
        }
        private void tsmiPrint_Click(object sender, EventArgs e)
        {
            this.CellOperate("Print");
        }
        private void tsmiClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void tsmiHideArchive_Click(object sender, EventArgs e)
        {
            this.ShowHideTree();
        }
        private void tsmiDelNode_Click(object sender, EventArgs e)
        {
            this.DelNode();
        }
        private void tsmiEditNode_Click(object sender, EventArgs e)
        {
            this.EditNode();
        }
        private void tsmiUndo_Click(object sender, EventArgs e)
        {
            this.CellOperate("Undo");
        }
        private void tsmiRedo_Click(object sender, EventArgs e)
        {
            this.CellOperate("Redo");
        }
        private void tsmiCut_Click(object sender, EventArgs e)
        {
            this.CellOperate("Cut");
        }
        private void tsmiCopy_Click(object sender, EventArgs e)
        {
            this.CellOperate("Copy");
        }
        private void tsmiPaste_Click(object sender, EventArgs e)
        {
            this.CellOperate("Paste");
        }
        private void tsmiSelectAll_Click(object sender, EventArgs e)
        {
            this.CellOperate("SelectAll");
        }
        private void tsmiRepeatFill_Click(object sender, EventArgs e)
        {
            this.CellOperate("RepeatFill");
        }
        private void tsmiRndFill_Click(object sender, EventArgs e)
        {
            FillAll = true;
            this.CellOperate("RndFill");
        }
        private void tsmiRndSelectFill_Click(object sender, EventArgs e)
        {
            FillAll = false;
            this.CellOperate("RndFill");
        }
        private void tsmiSumH_Click(object sender, EventArgs e)
        {
            this.CellOperate("SumH");
        }
        private void tsmiSumV_Click(object sender, EventArgs e)
        {
            this.CellOperate("SumV");
        }
        private void tsmiSum_Click(object sender, EventArgs e)
        {
            this.CellOperate("Sum");
        }
        private void tsmiClearText_Click(object sender, EventArgs e)
        {
            this.CellOperate("ClearText");
        }
        private void tsmiClearImage_Click(object sender, EventArgs e)
        {
            this.CellOperate("ClearImage");
        }
        private void tsmiClearFormat_Click(object sender, EventArgs e)
        {
            this.CellOperate("ClearFormat");
        }
        private void tsmiClearAll_Click(object sender, EventArgs e)
        {
            this.CellOperate("ClearAll");
        }
        private void tsmiSymbol_Click(object sender, EventArgs e)
        {
            this.CellOperate("Symbol");
        }
        private void tsmiInsertPic_Click(object sender, EventArgs e)
        {
            this.CellOperate("InsertPic");
        }
        private void tsmiMergeCell_Click(object sender, EventArgs e)
        {
            this.CellOperate("MergeCell");
        }
        private void tsmiUnmergeCell_Click(object sender, EventArgs e)
        {
            this.CellOperate("UnmergeCell");
        }
        private void tsmiRepair_Click(object sender, EventArgs e)
        {
            this.CellOperate("Repair");
        }
        private void tsmiCellOption_Click(object sender, EventArgs e)
        {
            this.CellOperate("CellOption");
        }
        private void btnHideArchive_Click(object sender, EventArgs e)
        {
            this.ShowHideTree();
        }
        private void btnCopyFile_Click(object sender, EventArgs e)
        {
            this.CellOperate("Save");
            CopyCell();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            tsmiClose.PerformClick();
        }
        /// <summary>
        /// �����ƶ����ӱ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void t1_Up_Click(object sender, EventArgs e)
        {
            MoveNode("UP");
        }
        /// <summary>
        /// �����ƶ����ӱ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void t1_Down_Click(object sender, EventArgs e)
        {
            MoveNode("Down");
        }
        private void tsbtnDelete_Click(object sender, EventArgs e)
        {
            this.DelNode();
        }
        private void imgHideArchive_Click(object sender, EventArgs e)
        {
            this.ShowHideTree();
        }
        private void menuEditNode_Click(object sender, EventArgs e)
        {
            this.EditNode();
        }
        private void menuDelNode_Click(object sender, EventArgs e)
        {
            this.DelNode();
        }
        private void CheckSave()
        {
            if (Cell1.IsModified() == 1)
            {
                if (TXMessageBoxExtensions.Question("�������޸ģ���Ҫ������") == DialogResult.OK)
                {
                    this.CellOperate("Save");
                }
            }
        }
        /// <summary>
        /// ���ؼ����ֲ�����ʵ�ַ���(���塢�ֺš����塢б�塢���롢���ƵȵȵĴ���)
        /// </summary>
        /// <param name="key"></param>
        private void CellOperate(string key)
        {
            string UpKey = key.ToUpper();
            int startCol = 0, startRow = 0, endCol = 0, endRow = 0;
            Cell1.GetSelectRange(ref startCol, ref startRow, ref endCol, ref endRow);
            int sheet = Cell1.GetCurSheet();
            ColorDialog colorDlg;
            DialogResult ret;
            if (UpKey != "SAVE" && UpKey != "PAGESETUP" && UpKey != "PRINTPREVIEW" && UpKey != "PRINT"          //"��ӡ������" ����Ҫѡ�е�Ԫ��
                && UpKey != "UNDO" && UpKey != "REDO"                                        //"��������" ����Ҫѡ�е�Ԫ��
                && UpKey != "ROWHIDESHOW" && UpKey != "COLHIDESHOW" && UpKey != "GRIDLINE"   //"��ʾ/�����бꡢ�бꡢ������" ����Ҫѡ�е�Ԫ��
                && UpKey != "ZOOM" && UpKey != "REPAIR" && UpKey != "SELECTALL" && UpKey != "RNDFILL")             //"��ʾ����������ȫѡ,������" ����Ҫѡ�е�Ԫ��
                if (startCol <= 0 || startRow <= 0 || endCol <= 0 || endRow <= 0) return;
            switch (UpKey)
            {
                case "DRAWTRIA":
                    int imageID = Cell1.AddImage(Application.StartupPath + "\\pd.wmf");
                    Cell1.SetCellImage(startCol, startRow, sheet, imageID, 0, 2, 2);
                    break;
                case "DRAWCIR":
                    int imageID2 = Cell1.AddImage(Application.StartupPath + "\\pc.wmf");
                    Cell1.SetCellImage(startCol, startRow, sheet, imageID2, 0, 2, 2);
                    break;
                case "FONTS":
                    int fontName = Cell1.FindFontIndex(cboFonts.SelectedItem.ToString(), 1);
                    for (int i = startCol; i <= endCol; i++)
                    {
                        for (int j = startRow; j <= endRow; j++)
                            Cell1.SetCellFont(i, j, sheet, fontName);
                    }
                    break;
                case "FONTSIZE":
                    int fontSize = MyCommon.IsInt(cboFontSize.Text) ? MyCommon.ToInt(cboFontSize.Text) : 10;
                    for (int i = startCol; i <= endCol; i++)
                    {
                        for (int j = startRow; j <= endRow; j++)
                            Cell1.SetCellFontSize(i, j, sheet, fontSize);
                    }
                    break;
                case "BOLD":
                    if (btnBold.Checked)  //Ӧ�ô���
                    {
                        for (int i = startCol; i <= endCol; i++)
                        {
                            for (int j = startRow; j <= endRow; j++)
                            {
                                int style = Cell1.GetCellFontStyle(i, j, sheet);
                                if ((style & 2) != 2)
                                    Cell1.SetCellFontStyle(i, j, sheet, style + 2);
                            }
                        }
                    }
                    else  //ȡ������
                    {
                        for (int i = startCol; i <= endCol; i++)
                        {
                            for (int j = startRow; j <= endRow; j++)
                            {
                                int style = Cell1.GetCellFontStyle(i, j, sheet);
                                if ((style & 2) == 2)
                                    Cell1.SetCellFontStyle(i, j, sheet, style - 2);
                            }
                        }
                    }
                    break;
                case "ITALIC":
                    if (btnItalic.Checked)  //Ӧ��б��
                    {
                        for (int i = startCol; i <= endCol; i++)
                        {
                            for (int j = startRow; j <= endRow; j++)
                            {
                                int style = Cell1.GetCellFontStyle(i, j, sheet);
                                if ((style & 4) != 4)
                                    Cell1.SetCellFontStyle(i, j, sheet, style + 4);
                            }
                        }
                    }
                    else  //ȡ��б��
                    {
                        for (int i = startCol; i <= endCol; i++)
                        {
                            for (int j = startRow; j <= endRow; j++)
                            {
                                int style = Cell1.GetCellFontStyle(i, j, sheet);
                                if ((style & 4) == 4)
                                    Cell1.SetCellFontStyle(i, j, sheet, style - 4);
                            }
                        }
                    }
                    break;
                case "UNDERLINE":
                    if (btnItalic.Checked)  //Ӧ���»���
                    {
                        for (int i = startCol; i <= endCol; i++)
                        {
                            for (int j = startRow; j <= endRow; j++)
                            {
                                int style = Cell1.GetCellFontStyle(i, j, sheet);
                                if ((style & 8) != 8)
                                    Cell1.SetCellFontStyle(i, j, sheet, style + 8);
                            }
                        }
                    }
                    else  //ȡ���»���
                    {
                        for (int i = startCol; i <= endCol; i++)
                        {
                            for (int j = startRow; j <= endRow; j++)
                            {
                                int style = Cell1.GetCellFontStyle(i, j, sheet);
                                if ((style & 8) == 8)
                                    Cell1.SetCellFontStyle(i, j, sheet, style - 8);
                            }
                        }
                    }
                    break;
                case "BACKCOLOR":
                    colorDlg = new ColorDialog();
                    colorDlg.AllowFullOpen = true;
                    colorDlg.CustomColors = CustomColors;
                    ret = colorDlg.ShowDialog();
                    if (ret == DialogResult.OK)
                    {
                        CustomColors = colorDlg.CustomColors;
                        for (int i = startCol; i <= endCol; i++)
                        {
                            for (int j = startRow; j <= endRow; j++)
                            {
                                int index = Cell1.FindColorIndex(MyCommon.GetRGBFromColor(colorDlg.Color), 1);
                                if (index != -1)
                                    Cell1.SetCellBackColor(i, j, sheet, index);
                            }
                        }
                    }
                    break;
                case "FORECOLOR":
                    colorDlg = new ColorDialog();
                    colorDlg.AllowFullOpen = true;
                    colorDlg.CustomColors = CustomColors;
                    ret = colorDlg.ShowDialog();
                    if (ret == DialogResult.OK)
                    {
                        for (int i = startCol; i <= endCol; i++)
                        {
                            for (int j = startRow; j <= endRow; j++)
                            {
                                CustomColors = colorDlg.CustomColors;
                                int index = Cell1.FindColorIndex(MyCommon.GetRGBFromColor(colorDlg.Color), 1);
                                if (index != -1)
                                    Cell1.SetCellTextColor(i, j, sheet, index);
                            }
                        }
                    }
                    break;
                case "WORDWRAP":
                    if (btnWordWrap.Checked)  //Ӧ��������ʾ
                    {
                        for (int i = startCol; i <= endCol; i++)
                        {
                            for (int j = startRow; j <= endRow; j++)
                                Cell1.SetCellTextStyle(i, j, sheet, 2);
                        }
                    }
                    else //ȡ��������ʾ
                    {
                        for (int i = startCol; i <= endCol; i++)
                        {
                            for (int j = startRow; j <= endRow; j++)
                                Cell1.SetCellTextStyle(i, j, sheet, 1);
                        }
                    }
                    break;
                case "ALIGNLEFT":
                    if (btnAlignLeft.Checked)  //Ӧ�þ���
                    {
                        for (int i = startCol; i <= endCol; i++)
                        {
                            for (int j = startRow; j <= endRow; j++)
                            {
                                int align = Cell1.GetCellAlign(i, j, sheet);
                                if ((align & 1) != 1)
                                {
                                    align = MyCommon.NumberMinus(align, 2);
                                    align = MyCommon.NumberMinus(align, 4);
                                    Cell1.SetCellAlign(i, j, sheet, align + 1);
                                    btnAlignCenter.Checked = false;
                                    btnAlignRight.Checked = false;
                                }
                            }
                        }
                    }
                    else //ȡ������
                    {
                        for (int i = startCol; i <= endCol; i++)
                        {
                            for (int j = startRow; j <= endRow; j++)
                            {
                                int align = Cell1.GetCellAlign(i, j, sheet);
                                if ((align & 1) == 1)
                                    Cell1.SetCellAlign(i, j, sheet, align - 1);
                            }
                        }
                    }
                    break;
                case "ALIGNCENTER":
                    if (btnAlignCenter.Checked)  //Ӧ�þ���
                    {
                        for (int i = startCol; i <= endCol; i++)
                        {
                            for (int j = startRow; j <= endRow; j++)
                            {
                                int align = Cell1.GetCellAlign(i, j, sheet);
                                if ((align & 4) != 4)
                                {
                                    align = MyCommon.NumberMinus(align, 1);
                                    align = MyCommon.NumberMinus(align, 2);
                                    Cell1.SetCellAlign(i, j, sheet, align + 4);
                                    btnAlignLeft.Checked = false;
                                    btnAlignRight.Checked = false;
                                }
                            }
                        }
                    }
                    else //ȡ������
                    {
                        for (int i = startCol; i <= endCol; i++)
                        {
                            for (int j = startRow; j <= endRow; j++)
                            {
                                int align = Cell1.GetCellAlign(i, j, sheet);
                                if ((align & 4) == 4)
                                    Cell1.SetCellAlign(i, j, sheet, align - 4);
                            }
                        }
                    }
                    break;
                case "ALIGNRIGHT":
                    if (btnAlignRight.Checked)  //Ӧ�þ���
                    {
                        for (int i = startCol; i <= endCol; i++)
                        {
                            for (int j = startRow; j <= endRow; j++)
                            {
                                int align = Cell1.GetCellAlign(i, j, sheet);
                                if ((align & 2) != 2)
                                {
                                    align = MyCommon.NumberMinus(align, 1);
                                    align = MyCommon.NumberMinus(align, 4);
                                    Cell1.SetCellAlign(i, j, sheet, align + 2);
                                    btnAlignLeft.Checked = false;
                                    btnAlignCenter.Checked = false;
                                }
                            }
                        }
                    }
                    else //ȡ������
                    {
                        for (int i = startCol; i <= endCol; i++)
                        {
                            for (int j = startRow; j <= endRow; j++)
                            {
                                int align = Cell1.GetCellAlign(i, j, sheet);
                                if ((align & 2) == 2)
                                    Cell1.SetCellAlign(i, j, sheet, align - 2);
                            }
                        }
                    }
                    break;
                case "ALIGNTOP":
                    if (btnAlignTop.Checked)  //Ӧ�þ���
                    {
                        for (int i = startCol; i <= endCol; i++)
                        {
                            for (int j = startRow; j <= endRow; j++)
                            {
                                int align = Cell1.GetCellAlign(i, j, sheet);
                                if ((align & 8) != 8)
                                {
                                    align = MyCommon.NumberMinus(align, 16);
                                    align = MyCommon.NumberMinus(align, 32);
                                    Cell1.SetCellAlign(i, j, sheet, align + 8);
                                    btnAlignMiddle.Checked = false;
                                    btnAlignBottom.Checked = false;
                                }
                            }
                        }
                    }
                    else //ȡ������
                    {
                        for (int i = startCol; i <= endCol; i++)
                        {
                            for (int j = startRow; j <= endRow; j++)
                            {
                                int align = Cell1.GetCellAlign(i, j, sheet);
                                if ((align & 8) == 8)
                                    Cell1.SetCellAlign(i, j, sheet, align - 8);
                            }
                        }
                    }
                    break;
                case "ALIGNMIDDLE":
                    if (btnAlignMiddle.Checked)  //Ӧ�ô�ֱ����
                    {
                        for (int i = startCol; i <= endCol; i++)
                        {
                            for (int j = startRow; j <= endRow; j++)
                            {
                                int align = Cell1.GetCellAlign(i, j, sheet);
                                if ((align & 32) != 32)
                                {
                                    align = MyCommon.NumberMinus(align, 8);
                                    align = MyCommon.NumberMinus(align, 16);
                                    Cell1.SetCellAlign(i, j, sheet, align + 32);
                                    btnAlignTop.Checked = false;
                                    btnAlignBottom.Checked = false;
                                }
                            }
                        }
                    }
                    else //ȡ����ֱ����
                    {
                        for (int i = startCol; i <= endCol; i++)
                        {
                            for (int j = startRow; j <= endRow; j++)
                            {
                                int align = Cell1.GetCellAlign(i, j, sheet);
                                if ((align & 32) == 32)
                                    Cell1.SetCellAlign(i, j, sheet, align - 32);
                            }
                        }
                    }
                    break;
                case "ALIGNBOTTOM":
                    if (btnAlignBottom.Checked)  //Ӧ�þ���
                    {
                        for (int i = startCol; i <= endCol; i++)
                        {
                            for (int j = startRow; j <= endRow; j++)
                            {
                                int align = Cell1.GetCellAlign(i, j, sheet);
                                if ((align & 16) != 16)
                                {
                                    align = MyCommon.NumberMinus(align, 8);
                                    align = MyCommon.NumberMinus(align, 32);
                                    Cell1.SetCellAlign(i, j, sheet, align + 16);
                                    btnAlignTop.Checked = false;
                                    btnAlignMiddle.Checked = false;
                                }
                            }
                        }
                    }
                    else //ȡ������
                    {
                        for (int i = startCol; i <= endCol; i++)
                        {
                            for (int j = startRow; j <= endRow; j++)
                            {
                                int align = Cell1.GetCellAlign(i, j, sheet);
                                if ((align & 16) == 16)
                                    Cell1.SetCellAlign(i, j, sheet, align - 16);
                            }
                        }
                    }
                    break;
                case "DRAWBORDER1":
                    Cell1.DrawGridLine(startCol, startRow, endCol, endRow, 0, cboLine.SelectedIndex + 2, -1);
                    break;
                case "DRAWBORDER2":
                    Cell1.DrawGridLine(startCol, startRow, endCol, endRow, 1, cboLine.SelectedIndex + 2, -1);
                    break;
                case "DRAWBORDER3":
                    Cell1.DrawGridLine(startCol, startRow, endCol, endRow, 2, cboLine.SelectedIndex + 2, -1);
                    break;
                case "DRAWBORDER4":
                    Cell1.DrawGridLine(startCol, startRow, endCol, endRow, 3, cboLine.SelectedIndex + 2, -1);
                    break;
                case "DRAWBORDER5":
                    Cell1.DrawGridLine(startCol, startRow, endCol, endRow, 4, cboLine.SelectedIndex + 2, -1);
                    break;
                case "DRAWBORDER6":
                    Cell1.DrawGridLine(startCol, startRow, endCol, endRow, 5, cboLine.SelectedIndex + 2, -1);
                    break;
                case "DRAWBORDER7":
                    Cell1.DrawGridLine(startCol, startRow, endCol, endRow, 6, cboLine.SelectedIndex + 2, -1);
                    break;
                case "DRAWBORDER8":
                    Cell1.DrawGridLine(startCol, startRow, endCol, endRow, 7, cboLine.SelectedIndex + 2, -1);
                    break;
                case "ERASEBORDER1":
                    Cell1.ClearGridLine(startCol, startRow, endCol, endRow, 0);
                    break;
                case "ERASEBORDER2":
                    Cell1.ClearGridLine(startCol, startRow, endCol, endRow, 1);
                    break;
                case "ERASEBORDER3":
                    Cell1.ClearGridLine(startCol, startRow, endCol, endRow, 2);
                    break;
                case "ERASEBORDER4":
                    Cell1.ClearGridLine(startCol, startRow, endCol, endRow, 3);
                    break;
                case "ERASEBORDER5":
                    Cell1.ClearGridLine(startCol, startRow, endCol, endRow, 4);
                    break;
                case "ERASEBORDER6":
                    Cell1.ClearGridLine(startCol, startRow, endCol, endRow, 5);
                    break;
                case "ERASEBORDER7":
                    Cell1.ClearGridLine(startCol, startRow, endCol, endRow, 6);
                    break;
                case "ERASEBORDER8":
                    Cell1.ClearGridLine(startCol, startRow, endCol, endRow, 7);
                    break;
                case "SYMBOL":
                    if (Cell1.GetCellInput(startCol, startRow, sheet) != 5) //δ����
                    {
                        frmSymbol SymbolForm = new frmSymbol();
                        ret = SymbolForm.ShowDialog();
                        if (ret == DialogResult.OK)
                        {
                            Cell1.InsertString(startCol, startRow, SymbolForm.lblBig.Text);
                        }
                    }
                    break;
                case "INSERTPIC":
                    if (Cell1.GetCellInput(startCol, startRow, sheet) != 5)  //δ����
                    {
                        int image_index = -1;
                        int imge_style = 2;
                        int img_vagin = 0;
                        int img_hagin = 0;
                        Cell1.GetCellImage(startCol, startRow, sheet, ref image_index, ref imge_style, ref img_vagin, ref img_hagin);
                        Cell1.SetCellImage(startCol, startRow, sheet, image_index, imge_style, img_vagin, img_hagin);

                        Cell1.SetCellImageDlg();
                        Cell1.ReDraw();
                    }
                    break;
                case "SAVE":
                    string openfilename = Cell1.GetFileName();
                    if (openfilename != null && openfilename != "")
                    {
                        Cell1.SaveEdit();
                        // this.RemoveTips();
                        if (Cell1.SaveFile(openfilename, 0) != 1)
                        {
                            TXMessageBoxExtensions.Info("��ʾ������ʧ�ܣ�");
                        }
                        //Cell1.OpenFile(openfilename, "");//2013 3.25 YQ ģ��̫���ʱ�򣬱���̫�������ε��ٴδ��ļ�����
                    }
                    if (treeView1.SelectedNode != null)
                    {
                        TreeNodeEx cellNode = (TreeNodeEx)treeView1.SelectedNode;
                        //if (openfilename.Trim() == "")
                        //    Cell1.SaveFile(Globals.ProjectPath + cellNode.NodeValue, 0);
                        //else
                        //Cell1.SaveEdit();
                        //Cell1.SaveFile(openfilename, 0);

                        MDL.T_CellAndEFile cellMDL = (new BLL.T_CellAndEFile_BLL()).Find(cellNode.Name, Globals.ProjectNO);
                        if (cellMDL != null)
                        {
                            cellMDL.DocYs = 1;//Leo �и��£���Ҫ��Ҫ��Ҫ����pdf
                            cellMDL.DoStatus = 1;
                            (new BLL.T_CellAndEFile_BLL()).Update(cellMDL);
                        }
                    }
                    Cell1.SetModified(0);//����û�иĶ���
                    break;
                case "PRINT":
                    Cell1.PrintSetAlign(1, 1);
                    Cell1.PrintPara(1, 1, 0, 0);
                    Cell1.PrintSheet(1, sheet);
                    break;
                case "PRINTPREVIEW":
                    Cell1.PrintSetAlign(1, 1);
                    Cell1.PrintPara(1, 1, 0, 0); //��ɫ��ӡ
                    Cell1.PrintPreview(1, sheet);//PrintPara
                    break;
                case "PAGESETUP":
                    Cell1.PrintSetAlign(1, 1);
                    Cell1.PrintPara(1, 1, 0, 0); //��ɫ��ӡ
                    Cell1.PrintPageSetup();
                    break;
                case "CUT":
                    if (Cell1.GetCellInput(startCol, startRow, sheet) != 5)  //δ����
                        Cell1.CutRange(startCol, startRow, endCol, endRow);
                    break;
                case "COPY":
                    Cell1.CopyRange(startCol, startRow, endCol, endRow);
                    break;
                case "PASTE":
                    Cell1.Paste(startCol, startRow, 2, 1, 1);
                    break;
                case "UNDO":
                    Cell1.Undo();
                    this.CheckUnDoReDo();
                    break;
                case "REDO":
                    Cell1.Redo();
                    this.CheckUnDoReDo();
                    break;
                case "ROWHIDESHOW":
                    if (Cell1.GetTopLabelState(sheet) == 0) //δ��ʾ
                        Cell1.ShowTopLabel(1, sheet);
                    else
                        Cell1.ShowTopLabel(0, sheet);
                    break;
                case "COLHIDESHOW":
                    if (Cell1.GetSideLabelState(sheet) == 0) //δ��ʾ
                        Cell1.ShowSideLabel(1, sheet);
                    else
                        Cell1.ShowSideLabel(0, sheet);
                    break;
                ///��ʾ/����������
                case "GRIDLINE":
                    if (Cell1.GetGridLineState(sheet) == 0) //δ��ʾ
                        Cell1.ShowGridLine(1, sheet);
                    else
                        Cell1.ShowGridLine(0, sheet);
                    break;
                case "MERGECELL":
                    if (Cell1.GetCellInput(startCol, startRow, sheet) != 5)  //δ����
                        Cell1.MergeCells(startCol, startRow, endCol, endRow);
                    break;
                case "UNMERGECELL":
                    if (Cell1.GetCellInput(startCol, startRow, sheet) != 5) //δ����
                    {
                        int startCol1 = 0, startRow1 = 0, endCol1 = 0, endRow1 = 0;
                        for (int i = startCol; i <= endCol; i++)
                        {
                            for (int j = startRow; j <= endRow; j++)
                            {
                                Cell1.GetMergeRange(i, j, ref startCol1, ref startRow1, ref endCol1, ref endRow1);
                                Cell1.UnmergeCells(startCol1, startRow1, endCol1, endRow1);
                            }
                        }
                    }
                    break;
                case "ZOOM":
                    string strZoom = (cboZoom.Text.Trim() == string.Empty ? "100" : cboZoom.Text.Trim());
                    strZoom = strZoom.Replace("%", "");
                    strZoom = strZoom.Replace(" ", "");
                    int scale = MyCommon.IsInt(strZoom) ? MyCommon.ToInt(strZoom) : 100;
                    cboZoom.Text = scale.ToString() + "%";
                    Cell1.SetScreenScale(sheet, scale / 100.0);
                    break;
                case "INSERTCOL":
                    Cell1.InsertCol(startCol, endCol - startCol + 1, sheet);
                    break;
                case "DELETECOL":
                    Cell1.DeleteCol(startCol, endCol - startCol + 1, sheet);
                    break;
                case "INSERTROW":
                    Cell1.InsertRow(startRow, endRow - startRow + 1, sheet);
                    break;
                case "DELETEROW":
                    Cell1.DeleteRow(startRow, endRow - startRow + 1, sheet);
                    break;
                case "SETSIZE":
                    if (Cell1.GetCurrentRow() > 0 && Cell1.GetCurrentCol() > 0)
                        Cell1.SetCols(Cell1.GetCurrentCol() + 1, 0);
                    Cell1.SetRows(Cell1.GetCurrentRow() + 1, 0);
                    break;
                case "SELECTALL":
                    Cell1.SelectRange(1, 1, Cell1.GetCols(sheet) - 1, Cell1.GetRows(sheet) - 1);
                    break;
                case "RNDFILL":
                    frmXsd frm = new frmXsd();
                    DialogResult drs = frm.ShowDialog();
                    if (drs == DialogResult.OK)
                    {
                        int ws = int.Parse(frm.UpDown1.Text);
                        if (FillAll)//����������
                        {
                            for (int sheet1 = 0; sheet1 < Cell1.GetTotalSheets(); sheet1++)
                            {
                                for (int col = 1; col < Cell1.GetCols(sheet1); col++)
                                {
                                    for (int row = 1; row < Cell1.GetRows(sheet1); row++)
                                    {
                                        string no = Cell1.GetCellNote(col, row, sheet1);
                                        if (no.Trim() != "")
                                        {
                                            if (no.Trim().StartsWith("run", true, null))
                                                MyCommon.parse(no, col, row, sheet1, Cell1, ws, frm.checkBox1.Checked);
                                        }
                                        else
                                        {
                                            //string o = Rnd(Convert.ToDouble(min), Convert.ToDouble(max), ws);
                                            //if (fh && !o.ToString().StartsWith("-"))
                                            //    o = "+" + o;//���Ҫ���ţ��Ҳ���Ϊ����
                                            //Cell1.S(col2, row2, sheet, o);
                                        }
                                    }
                                }
                            }
                        }
                        else//ֻ���ѡ�е�
                        {
                            for (int col = startCol; col < endCol + 1; col++)
                            {
                                for (int row = startRow; row < endRow + 1; row++)
                                {
                                    string no = Cell1.GetCellNote(col, row, sheet);
                                    if (no.Trim() != "")
                                    {
                                        if (no.Trim().StartsWith("run", true, null))
                                            MyCommon.parse(no, col, row, sheet, Cell1, ws, frm.checkBox1.Checked);
                                    }
                                    else
                                    {
                                        //string o = Rnd(Convert.ToDouble(min), Convert.ToDouble(max), ws);
                                        //if (fh && !o.ToString().StartsWith("-"))
                                        //    o = "+" + o;//���Ҫ���ţ��Ҳ���Ϊ����
                                        //Cell1.S(col2, row2, sheet, o);
                                    }
                                }
                            }
                        }
                        Cell1.Refresh();
                    }
                    ////����
                    break;
                case "REPEATFILL":
                    Cell1.Fill(16);
                    break;
                case "SUMH":
                    if (startCol == endCol)
                        TXMessageBoxExtensions.Info("��ѡ��һ����������");
                    else
                    {
                        for (int i = startRow; i <= endRow; i++)
                        {
                            string formula;
                            formula = "sum(" + Cell1.CellToLabel(startCol, i) + ":" + Cell1.CellToLabel(endCol - 1, i) + ")";
                            Cell1.SetFormula(endCol, i, sheet, formula);
                        }
                        Cell1.ReDraw();
                    }
                    break;
                case "SUMV":
                    if (startRow == endRow)
                        TXMessageBoxExtensions.Info("��ѡ��һ����������");
                    else
                    {
                        for (int i = startCol; i <= endCol; i++)
                        {
                            string formula;
                            formula = "sum(" + Cell1.CellToLabel(i, startRow) + ":" + Cell1.CellToLabel(i, endRow - 1) + ")";
                            Cell1.SetFormula(i, endRow, sheet, formula);
                        }
                        Cell1.ReDraw();
                    }
                    break;
                case "SUM":
                    if (startRow == endRow && startCol == endCol)
                        TXMessageBoxExtensions.Info("��ѡ��һ����������");
                    else
                    {
                        string formula;
                        for (int i = startRow; i <= endRow; i++)
                        {
                            formula = "sum(" + Cell1.CellToLabel(startCol, i) + ":" + Cell1.CellToLabel(endCol - 1, i) + ")";
                            Cell1.SetFormula(endCol, i, sheet, formula);
                        }
                        for (int i = startCol; i <= endCol; i++)
                        {
                            formula = "sum(" + Cell1.CellToLabel(i, startRow) + ":" + Cell1.CellToLabel(i, endRow - 1) + ")";
                            Cell1.SetFormula(i, endRow, sheet, formula);
                        }
                        formula = "sum(" + Cell1.CellToLabel(startCol, startRow) + ":" + Cell1.CellToLabel(endCol - 1, endRow - 1) + ")";
                        Cell1.SetFormula(endCol, endRow, sheet, formula);
                        Cell1.ReDraw();
                    }
                    break;
                case "CLEARTEXT":
                    for (int i = startCol; i <= endCol; i++)
                    {
                        for (int j = startRow; j <= endRow; j++)
                        {
                            if (Cell1.GetCellInput(i, j, sheet) != 5) //δ����
                                Cell1.ClearArea(i, j, i, j, sheet, 1);
                        }
                    }
                    break;
                case "CLEARIMAGE":
                    for (int i = startCol; i <= endCol; i++)
                    {
                        for (int j = startRow; j <= endRow; j++)
                        {
                            if (Cell1.GetCellInput(i, j, sheet) != 5) //δ����
                                Cell1.SetCellImage(i, j, sheet, -1, 1, 0, 0);
                        }
                    }
                    break;
                case "CLEARFORMAT":
                    for (int i = startCol; i <= endCol; i++)
                    {
                        for (int j = startRow; j <= endRow; j++)
                        {
                            if (Cell1.GetCellInput(i, j, sheet) != 5) //δ����
                                Cell1.ClearArea(i, j, i, j, sheet, 8);
                        }
                    }
                    break;
                case "CLEARALL":
                    for (int i = startCol; i <= endCol; i++)
                    {
                        for (int j = startRow; j <= endRow; j++)
                        {
                            if (Cell1.GetCellInput(i, j, sheet) != 5) //δ����
                                Cell1.ClearArea(i, j, i, j, sheet, 32);
                        }
                    }
                    break;
                case "REPAIR":
                    for (int st = 0; st < Cell1.GetTotalSheets(); st++)
                    {
                        for (int col = 1; col < Cell1.GetCols(st); col++)
                        {
                            for (int row = 1; row < Cell1.GetRows(st); row++)
                            {
                                key = Cell1.GetCellNote(col, row, st).ToLower();
                                if (key != "" && key.StartsWith("run"))
                                {
                                    this.Evaluate(col, row, st, false);
                                }
                            }
                        }
                    }
                    break;
                case "CELLOPTION":
                    if (Cell1.GetCellInput(startCol, startRow, sheet) != 5)
                        Cell1.CellPropertyDlg();
                    break;
                case "READONLYT":
                    for (int i = startCol; i <= endCol; i++)
                        for (int j = startRow; j <= endRow; j++)
                            Cell1.SetCellInput(i, j, sheet, 5);
                    break;
                case "READONLYF":
                    for (int i = startCol; i <= endCol; i++)
                        for (int j = startRow; j <= endRow; j++)
                            Cell1.SetCellInput(i, j, sheet, 1);
                    break;
                case "FH1":
                    for (int i = startCol; i <= endCol; i++)
                        for (int j = startRow; j <= endRow; j++)
                            Cell1.SetCellString(i, j, sheet, "��");
                    break;
                case "FH2":
                    for (int i = startCol; i <= endCol; i++)
                        for (int j = startRow; j <= endRow; j++)
                            Cell1.SetCellString(i, j, sheet, "��");
                    break;
                case "FH3":
                    for (int i = startCol; i <= endCol; i++)
                        for (int j = startRow; j <= endRow; j++)
                            Cell1.SetCellString(i, j, sheet, "��");
                    break;
                case "FH4":
                    for (int i = startCol; i <= endCol; i++)
                        for (int j = startRow; j <= endRow; j++)
                            Cell1.SetCellString(i, j, sheet, "��");
                    break;
            }
        }
        /// <summary>
        /// �Ե�Ԫ�����ݽ�������
        /// </summary>
        /// <param name="col">��</param>
        /// <param name="row">��</param>
        /// <param name="sheet">ҳ</param>
        /// <param name="showWarn">����������ݽ��м���,�������ֵĻ�������ʾ��.(��������ʱ����Ҫ)</param>
        private void Evaluate(int col, int row, int sheet, bool showWarn)
        {
            string key = Cell1.GetCellNote(col, row, sheet);
            if (key == "" || !key.StartsWith("run", true, null)) return;
            string text = Cell1.GetCellString2(col, row, sheet);
            if (text.Trim() == "")
            {
                //Cell1.SetCellTextColor(col, row, sheet, Cell1.FindColorIndex(MyCommon.GetRGBFromColor(0, 0, 255), 1));
                Cell1.SetCellTextColor(col, row, sheet, Cell1.FindColorIndex(MyCommon.GetRGBFromColor(0, 0, 0), 1));
                Cell1.SetCellImage(col, row, sheet, -1, 1, 0, 0);
                return;
            }
            int imageID = -1;
            if (System.IO.File.Exists(Application.StartupPath + "\\pd.wmf"))
                imageID = Cell1.AddImage(Application.StartupPath + "\\pd.wmf");

            if (!MyCommon.IsNumeric(text))
            {
                if (showWarn)
                {
                    TXMessageBoxExtensions.Info("��ʾ���������ݿ�����Ҫ��Ĳ��������飡");
                }
                Cell1.SetCellImage(col, row, sheet, imageID, 1, 0, 0);
                //Cell1.SetCellTextColor(col, row, sheet, Cell1.FindColorIndex(MyCommon.GetRGBFromColor(255, 0, 255), 1));
                Cell1.SetCellTextColor(col, row, sheet, Cell1.FindColorIndex(MyCommon.GetRGBFromColor(255, 0, 0), 1));
                return;
            }
            if (this.parse(key, sheet, Convert.ToDouble(text)))
            {
                //Cell1.SetCellTextColor(col, row, sheet, Cell1.FindColorIndex(MyCommon.GetRGBFromColor(0, 0, 255), 1));
                Cell1.SetCellTextColor(col, row, sheet, Cell1.FindColorIndex(MyCommon.GetRGBFromColor(0, 0, 0), 1));
                Cell1.SetCellImage(col, row, sheet, -1, 1, 0, 0);
            }
            else
            {
                Cell1.SetCellImage(col, row, sheet, imageID, 0, 2, 2);
                //Cell1.SetCellTextColor(col, row, sheet, Cell1.FindColorIndex(MyCommon.GetRGBFromColor(255, 0, 255), 1));
                Cell1.SetCellTextColor(col, row, sheet, Cell1.FindColorIndex(MyCommon.GetRGBFromColor(250, 0, 0), 1));
            }
        }
        /// <summary>
        /// �������ظ�������ť��״̬���
        /// </summary>
        private void CheckUnDoReDo()
        {
            if (Cell1.GetUndoState() == 1)
            {
                btnUndo.Enabled = true;
                tsmiUndo.Enabled = true;
            }
            else
            {
                btnUndo.Enabled = false;
                tsmiUndo.Enabled = false;
            }
            if (Cell1.GetRedoState() == 1)
            {
                btnRedo.Enabled = true;
                tsmiRedo.Enabled = true;
            }
            else
            {
                btnRedo.Enabled = false;
                tsmiRedo.Enabled = false;
            }
        }
        /// <summary>
        /// �Թ�ʽ�������н���
        /// </summary>
        /// <param name="expression">���ʽ</param>
        /// <param name="sheet">ҳ������������ʱ�õ�</param>
        /// <param name="compare">��Ҫ�Ƚϵ�ֵ</param>
        /// <returns>������������ture</returns>
        private bool parse(string expression, int sheet, double compare)
        {
            string str = expression.Replace("\r", "").Replace("\n", "").Replace(" ", "").ToLower();
            str = str.Replace("run{", "");
            str = str.Replace("}", "");
            str = str.Replace("break;", "#");
            if (str == "") return false;
            string newExpression = "";
            int col = 0;
            int row = 0;
            string[] condArr = str.Split('#');
            if (condArr.Length > 1)
            {
                for (int i = 0; i < condArr.Length; i++)
                {
                    if (condArr[i] != "")
                    {
                        string[] subCondArr = condArr[i].Split(':');
                        if (subCondArr.Length > 1)
                        {
                            if (Cell1.LabelToCell(subCondArr[0], ref col, ref row))
                            {
                                if (Cell1.GetCellDouble(col, row, sheet).ToString() == "1")
                                {
                                    newExpression = subCondArr[1];
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                newExpression = str;
            }
            string strMin = "";  //"��С"���ʽ
            string strMax = "";  //"���"���ʽ
            string strX = "";    //"����"���ʽ
            string strX1 = "";   //strX�ĺ�벿�֣�����Ԫ��
            string strXVal = ""; //��Ԫ���ֵ
            string strOther = ""; //��������
            if (newExpression == "") return false;
            string[] arr = newExpression.Split(';');
            if (arr.Length <= 1) return false;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i].StartsWith("min"))
                    strMin = arr[i];
                if (arr[i].StartsWith("max"))
                    strMax = arr[i];
                if (arr[i].StartsWith("x"))
                    strX = arr[i];
                if (arr[i].StartsWith("value"))
                    strOther = arr[i];
            }
            if (strX != "" && strX.Contains("="))
            {
                strX1 = strX.Split('=')[1];
                if (Cell1.LabelToCell(strX1, ref col, ref row))
                {
                    strXVal = Cell1.GetCellString(col, row, sheet);
                    if (!MyCommon.IsNumeric(strXVal))
                        strXVal = "";
                }
            }
            strMin = strMin.Replace("min", compare.ToString()).Replace("x", strXVal);
            strMax = strMax.Replace("max", compare.ToString()).Replace("x", strXVal);
            strOther = strOther.Replace("value", compare.ToString()).Replace("x", strXVal);
            if (((strMin == "") ? true : MyCommon.Eval(strMin)) && ((strMax == "") ? true : MyCommon.Eval(strMax)) && ((strOther == "") ? true : MyCommon.Eval(strOther)))
                return true;
            else
                return false;
        }
        private void Cell1_MouseDClick(object sender, AxCELL50Lib._DCell2000Events_MouseDClickEvent e)
        {
            if (Cell1.WorkbookReadonly)
            {
                TXMessageBoxExtensions.Info("��ǰ���Ϊģ����Ѿ��ύ��������༭��");
                return;
            }
            else
            {
                string key = Cell1.GetCellNote(e.col, e.row, Cell1.GetCurSheet());
                string keyType = MyCommon.Left(key, 1);  //�������
                key = MyCommon.Right(key, key.Length - 2); //�����ı���
                if (string.Compare(keyType, "9", true) == 0)
                {
                    Help.ShowHelp(this, Application.StartupPath + "\\���Ϲ�����.CHM", HelpNavigator.KeywordIndex, key);
                }
            }
        }
        private void Cell1_AllowMove(object sender, AxCELL50Lib._DCell2000Events_AllowMoveEvent e)
        {
            if (Cell1.WorkbookReadonly) return;
            int col = e.newcol;
            int row = e.newrow;
            int sheet = Cell1.GetCurSheet();
            ///////////////////////////////////////////////////////////////////
            for (int i = 0; i < cboFonts.Items.Count; i++)
            {
                if (Cell1.GetFontName(Cell1.GetCellFont(col, row, sheet)) == cboFonts.Items[i].ToString())
                {
                    cboFonts.SelectedIndex = i;
                    break;
                }
            }
            cboFontSize.Text = Cell1.GetCellFontSize(col, row, sheet).ToString();
            int style = this.Cell1.GetCellFontStyle(col, row, sheet); //������
            if ((style & 2) == 2)
                btnBold.Checked = true;
            else
                btnBold.Checked = false;
            if ((style & 4) == 4)
                btnItalic.Checked = true;
            else
                btnItalic.Checked = false;
            if ((style & 8) == 8)
                btnUnderLine.Checked = true;
            else
                btnUnderLine.Checked = false;
            if (Cell1.GetCellTextStyle(col, row, sheet) == 2)
                btnWordWrap.Checked = true;
            else
                btnWordWrap.Checked = false;
            int align = this.Cell1.GetCellAlign(col, row, sheet);  //��Ԫ��Ķ��뷽ʽ
            btnAlignLeft.Checked = false;
            btnAlignCenter.Checked = false;
            btnAlignRight.Checked = false;
            btnAlignTop.Checked = false;
            btnAlignMiddle.Checked = false;
            btnAlignBottom.Checked = false;
            if ((align & 1) == 1)
            {
                btnAlignLeft.Checked = true;
            }
            if ((align & 2) == 2)
            {
                btnAlignRight.Checked = true;
            }
            if ((align & 4) == 4)
            {
                btnAlignCenter.Checked = true;
            }
            if ((align & 8) == 8)
            {
                btnAlignTop.Checked = true;
            }
            if ((align & 16) == 16)
            {
                btnAlignBottom.Checked = true;
            }
            if ((align & 32) == 32)
            {
                btnAlignMiddle.Checked = true;
            }
            this.CheckUnDoReDo();
        }
        private void Cell1_MouseMoving(object sender, AxCELL50Lib._DCell2000Events_MouseMovingEvent e)
        {
            myX = e.x;
            myY = e.y;
        }
        private void Cell1_MenuStart(object sender, AxCELL50Lib._DCell2000Events_MenuStartEvent e)
        {
            if (Cell1.WorkbookReadonly == true) return;
            if (e.section == 1) //����ڱ������
            {
                if (Cell1.GetCellInput(e.col, e.row, Cell1.GetCurSheet()) == 5)
                    menuReadOnly.Checked = true;
                else
                    menuReadOnly.Checked = false;
                contextMenuCell.Show(Cell1, myX, myY);
            }
        }
        private void Cell1_KeyDown2(object sender, AxCELL50Lib._DCell2000Events_KeyDown2Event e)
        {
            if (e.keycode == 13 && e.shift == 0)
            {
                e.approve = 0;
                if (!Cell1.IsCellEditing(e.col, e.row))
                {
                    int tp = Cell1.GetCellNumType(e.col, e.row, e.sheet);
                    if (tp != 3 && tp != 4)
                        Cell1.StartEdit(e.col, e.row);
                    else
                    {
                        TXMessageBoxExtensions.Info("��˫��ѡ�����ڻ�ʱ�䣡");
                    }
                }
                else
                {
                    string str = Cell1.GetCellString2(e.col, e.row, e.sheet);
                    Cell1.InsertString(e.col, e.row, "\r\n");
                }
            }
        }
        private void Cell1_AllowInputFormula(object sender, AxCELL50Lib._DCell2000Events_AllowInputFormulaEvent e)
        {
            e.approve = 1;
        }
        private void Cell1_EditFinish(object sender, AxCELL50Lib._DCell2000Events_EditFinishEvent e)
        {
            int col = Cell1.GetCurrentCol();
            int row = Cell1.GetCurrentRow();
            int sheet = Cell1.GetCurSheet();
            if (tsmiAutoEval.Checked)
                this.Evaluate(col, row, sheet, true);
        }
        private void cboFonts_DropDownClosed(object sender, EventArgs e)
        {
            if (cboFonts.SelectedItem == null) return;
            cboFonts.Text = cboFonts.SelectedItem.ToString();
            this.CellOperate("FONTS");
        }
        private void cboFontSize_DropDownClosed(object sender, EventArgs e)
        {
            if (cboFontSize.SelectedItem == null) return;
            cboFontSize.Text = cboFontSize.SelectedItem.ToString();
            this.CellOperate("FontSize");
        }
        private void cboFontSize_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.CellOperate("FontSize");
            }
        }
        private void btnBold_Click(object sender, EventArgs e)
        {
            this.CellOperate("Bold");
        }
        private void btnItalic_Click(object sender, EventArgs e)
        {
            this.CellOperate("Italic");
        }
        private void btnUnderLine_Click(object sender, EventArgs e)
        {
            this.CellOperate("UnderLine");
        }
        private void btnBackColor_Click(object sender, EventArgs e)
        {
            this.CellOperate("BackColor");
        }
        private void btnForeColor_Click(object sender, EventArgs e)
        {
            this.CellOperate("ForeColor");
        }
        private void btnWordWrap_Click(object sender, EventArgs e)
        {
            this.CellOperate("WordWrap");
        }
        private void btnAlignLeft_Click(object sender, EventArgs e)
        {
            this.CellOperate("AlignLeft");
        }
        private void btnAlignCenter_Click(object sender, EventArgs e)
        {
            this.CellOperate("AlignCenter");
        }
        private void btnAlignRight_Click(object sender, EventArgs e)
        {
            this.CellOperate("AlignRight");
        }
        private void btnAlignTop_Click(object sender, EventArgs e)
        {
            this.CellOperate("AlignTop");
        }
        private void btnAlignMiddle_Click(object sender, EventArgs e)
        {
            this.CellOperate("AlignMiddle");
        }
        private void btnAlignBottom_Click(object sender, EventArgs e)
        {
            this.CellOperate("AlignBottom");
        }
        private void btnDrawBorder_ButtonClick(object sender, EventArgs e)
        {
            this.CellOperate("DrawBorder1");
        }
        private void menuDrawBorder1_Click(object sender, EventArgs e)
        {
            this.CellOperate("DrawBorder1");
        }
        private void menuDrawBorder2_Click(object sender, EventArgs e)
        {
            this.CellOperate("DrawBorder2");
        }
        private void menuDrawBorder3_Click(object sender, EventArgs e)
        {
            this.CellOperate("DrawBorder3");
        }
        private void menuDrawBorder4_Click(object sender, EventArgs e)
        {
            this.CellOperate("DrawBorder4");
        }
        private void menuDrawBorder5_Click(object sender, EventArgs e)
        {
            this.CellOperate("DrawBorder5");
        }
        private void menuDrawBorder6_Click(object sender, EventArgs e)
        {
            this.CellOperate("DrawBorder6");
        }
        private void menuDrawBorder7_Click(object sender, EventArgs e)
        {
            this.CellOperate("DrawBorder7");
        }
        private void menuDrawBorder8_Click(object sender, EventArgs e)
        {
            this.CellOperate("DrawBorder8");
        }
        private void btnEraseBorder_ButtonClick(object sender, EventArgs e)
        {
            this.CellOperate("EraseBorder1");
        }
        private void menuEraseBorder1_Click(object sender, EventArgs e)
        {
            this.CellOperate("EraseBorder1");
        }
        private void menuEraseBorder2_Click(object sender, EventArgs e)
        {
            this.CellOperate("EraseBorder2");
        }
        private void menuEraseBorder3_Click(object sender, EventArgs e)
        {
            this.CellOperate("EraseBorder3");
        }
        private void menuEraseBorder4_Click(object sender, EventArgs e)
        {
            this.CellOperate("EraseBorder4");
        }
        private void menuEraseBorder5_Click(object sender, EventArgs e)
        {
            this.CellOperate("EraseBorder5");
        }
        private void menuEraseBorder6_Click(object sender, EventArgs e)
        {
            this.CellOperate("EraseBorder6");
        }
        private void menuEraseBorder7_Click(object sender, EventArgs e)
        {
            this.CellOperate("EraseBorder7");
        }
        private void menuEraseBorder8_Click(object sender, EventArgs e)
        {
            this.CellOperate("EraseBorder8");
        }
        private void btnSymbol_Click(object sender, EventArgs e)
        {
            this.CellOperate("Symbol");
        }
        private void btnInsertPic_Click(object sender, EventArgs e)
        {
            this.CellOperate("InsertPic");
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            this.CellOperate("Save");
        }
        private void btnPrint_Click(object sender, EventArgs e)
        {
            this.CellOperate("Print");
        }
        private void btnPrintpreview_Click(object sender, EventArgs e)
        {
            this.CellOperate("Printpreview");
        }
        private void btnCut_Click(object sender, EventArgs e)
        {
            this.CellOperate("Cut");
        }
        private void btnCopy_Click(object sender, EventArgs e)
        {
            this.CellOperate("Copy");
        }
        private void btnPaste_Click(object sender, EventArgs e)
        {
            this.CellOperate("Paste");
        }
        private void btnUndo_Click(object sender, EventArgs e)
        {
            this.CellOperate("Undo");
        }
        private void btnRedo_Click(object sender, EventArgs e)
        {
            this.CellOperate("Redo");
        }
        private void btnRow_Click(object sender, EventArgs e)
        {
            this.CellOperate("RowHideShow");
        }
        private void btnCol_Click(object sender, EventArgs e)
        {
            this.CellOperate("ColHideShow");
        }
        private void btnGridline_Click(object sender, EventArgs e)
        {
            this.CellOperate("Gridline");
        }
        private void btnMergeCell_Click(object sender, EventArgs e)
        {
            this.CellOperate("MergeCell");
        }
        private void btnUnmergeCell_Click(object sender, EventArgs e)
        {
            this.CellOperate("UnmergeCell");
        }
        /// <summary>
        /// ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDrawTria_Click(object sender, EventArgs e)
        {
            CellOperate("DRAWTRIA");
        }
        /// <summary>
        /// Բ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDrawCir_Click(object sender, EventArgs e)
        {
            CellOperate("DRAWCIR");
        }
        private void cboZoom_DropDownClosed(object sender, EventArgs e)
        {
            if (cboZoom.SelectedItem == null) return;
            cboZoom.Text = cboZoom.SelectedItem.ToString();
            this.CellOperate("Zoom");
        }
        private void cboZoom_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.CellOperate("Zoom");
            }
        }
        private void btnInsertCol_Click(object sender, EventArgs e)
        {
            this.CellOperate("InsertCol");
        }
        private void btnDeleteCol_Click(object sender, EventArgs e)
        {
            this.CellOperate("DeleteCol");
        }
        private void btnInsertRow_Click(object sender, EventArgs e)
        {
            this.CellOperate("InsertRow");
        }
        private void btnDeleteRow_Click(object sender, EventArgs e)
        {
            this.CellOperate("DeleteRow");
        }
        private void btnRndFill_Click(object sender, EventArgs e)
        {
            FillAll = false;
            this.CellOperate("RndFill");
        }
        private void btnSumH_Click(object sender, EventArgs e)
        {
            this.CellOperate("SumH");
        }
        private void btnSumV_Click(object sender, EventArgs e)
        {
            this.CellOperate("SumV");
        }
        private void btnSum_Click(object sender, EventArgs e)
        {
            this.CellOperate("Sum");
        }
        private void menuReadOnly_Click(object sender, EventArgs e)
        {
            if (menuReadOnly.Checked)
            {
                menuReadOnly.Checked = false;
                this.CellOperate("ReadOnlyF");
            }
            else
            {
                menuReadOnly.Checked = true;
                this.CellOperate("ReadOnlyT");
            }
        }
        private void menuCut_Click(object sender, EventArgs e)
        {
            this.CellOperate("Cut");
        }
        private void menuCopy_Click(object sender, EventArgs e)
        {
            this.CellOperate("Copy");
        }
        private void menuPaste_Click(object sender, EventArgs e)
        {
            this.CellOperate("Paste");
        }
        private void menuRepeatFill_Click(object sender, EventArgs e)
        {
            this.CellOperate("RepeatFill");
        }
        private void menuRndFill_Click(object sender, EventArgs e)
        {
            FillAll = true;
            this.CellOperate("RndFill");
        }
        private void menuSumH_Click(object sender, EventArgs e)
        {
            this.CellOperate("SumH");
        }
        private void menuSumV_Click(object sender, EventArgs e)
        {
            this.CellOperate("SumV");
        }
        private void menuSum_Click(object sender, EventArgs e)
        {
            this.CellOperate("Sum");
        }
        private void menuSymbol_Click(object sender, EventArgs e)
        {
            this.CellOperate("Symbol");
        }
        private void menuClearText_Click(object sender, EventArgs e)
        {
            this.CellOperate("ClearText");
        }
        private void menuClearImage_Click(object sender, EventArgs e)
        {
            this.CellOperate("ClearImage");
        }
        private void menuClearFormat_Click(object sender, EventArgs e)
        {
            this.CellOperate("ClearFormat");
        }
        private void menuClearAll_Click(object sender, EventArgs e)
        {
            this.CellOperate("ClearAll");
        }
        private void menuInsertPic_Click(object sender, EventArgs e)
        {
            this.CellOperate("InsertPic");
        }
        private void menuMergeCell_Click(object sender, EventArgs e)
        {
            this.CellOperate("MergeCell");
        }
        private void menuUnmergeCell_Click(object sender, EventArgs e)
        {
            this.CellOperate("UnmergeCell");
        }
        private void menuRepair_Click(object sender, EventArgs e)
        {
            this.CellOperate("Repair");
        }
        private void menuCellOption_Click(object sender, EventArgs e)
        {
            this.CellOperate("CellOption");
        }
        private bool Checkfbfx()
        {
            foreach (TreeNode tn in treeView1.Nodes)
            {
                if (tn.ImageIndex == ImageLists.CellLock)
                    return false;
            }
            return true;
        }
        private bool CheckHasChild()
        {
            if (treeView1.Nodes.Count > 0)
                return true;
            else
                return false;
        }
        private void InsertCell(bool Isfx)
        {
            string createDate = DateTime.Now.ToString("yyyy-MM-dd");
            string cellParentid = fileNode.Name;
            int docstatus = 0;
            string ptreepath = fileNode.Parent.FullPath + "\\" + fileNode.Text.Substring(fileNode.Text.LastIndexOf("]") + 1);
            string title = "";
            if (Isfx)
            {
                title = (ys_fx + 1).ToString("D2");
            }
            else
            {
                title = (fxmc_fb + 1).ToString("D2");
            }
            string treepath = ptreepath + "\\" + title;
            int orderindex = 0;//treesData.GetNextArchiveIndex(cellParentid, ProjectNO);
            string FileExt = MyCommon.GetFileExtension(fileNode.NodeValue);  //��չ��
            string desFilename = MyCommon.GetUnique() + FileExt;  //�����ļ����ļ���,���뱣֤�ļ�����Ψһ
            string Filepath = "\\" + ProjectNO + "\\" + desFilename;  //�����ļ������·��
            int pages;
            try
            {
                if (System.IO.File.Exists(Globals.ProjectPath + Filepath))
                    System.IO.File.Delete(Globals.ProjectPath + Filepath);
                System.IO.File.Copy(Globals.CellPath + fileNode.NodeValue, Globals.ProjectPath + Filepath, true);
                pages = RefreshCell(Globals.ProjectPath + Filepath, false, orderindex, title, !Isfx, Isfx, Isfx ? true : false);
                ////modelArchiveData = new ERM.MDL.ArchiveData();
                ////codetype fbmc,fxmc,zfbmc���Բ�Ҫ
                if (Isfx)
                {
                    ys_fx++;
                    if (ys_fx < ds_fx.Tables.Count)
                    {
                        InsertCell(Isfx);
                    }
                }
                else
                {
                    if (fxmc_fb < dvfb.Count)
                    {
                        InsertCell(Isfx);
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }
        private void DelCells()
        {
            for (int i = 0; i < treeView1.Nodes.Count; i++)
            {
                treeFactory.DelNodes((TreeNodeEx)treeView1.Nodes[i], "", "", Globals.ProjectNO);
            }
        }
        DataView dvfb;
        int xh_fb = 0;
        int fbmc_fb = 0;
        int fxmc_fb = 0;
        int ps_fb = 0;
        int ys_fx;
        DataSet ds_fx;
        int bw_fx;
        int xh_fx;
        int fxmc_fx;
        int ps_fx;
        void treeView1_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
        {
            if (e.Data.GetDataPresent("TreeNodeEx"))
            {
                e.Effect = DragDropEffects.Move;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }
        private void treeView1_DragDrop(object sender, DragEventArgs e)
        {
            Point pt;
            TreeNodeEx targeNode;
            pt = ((TreeView)(sender)).PointToClient(new Point(e.X, e.Y));
            targeNode = (TreeNodeEx)this.treeView1.GetNodeAt(pt);
            if (targeNode == null)
                return;
            TreeNodeEx moveNode = (TreeNodeEx)e.Data.GetData("TreeNodeEx");
            if (moveNode == targeNode)
                return;
            ;
            TreeNodeEx temp = (TreeNodeEx)(moveNode.Clone());
            moveNode.Remove();
            treeView1.Nodes.Insert(targeNode.Index, moveNode);
            List<string> ids = new List<string>();
            for (int i = 0; i < treeView1.Nodes.Count; i++)
            {
                ids.Add(treeView1.Nodes[i].Name);
            }
            //treesData.UpdateOrderIndex(ids, Globals.ProjectNO);
            ////�Ƴ��ϷŵĽڵ� 
            treeView1.SelectedNode = moveNode;
        }
        private void treeView1_ItemDrag(object sender, ItemDragEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                DoDragDrop((TreeNodeEx)e.Item, DragDropEffects.Move);
            }
        }
        private void treeView1_DragOver(object sender, DragEventArgs e)
        {
            Point mousePoint = treeView1.PointToClient(new Point(e.X, e.Y));
            TreeNode theNode = treeView1.GetNodeAt(mousePoint);
            if (theNode != null)
            {
                treeView1.AfterSelect -= new TreeViewEventHandler(treeView1_AfterSelect);
                treeView1.SelectedNode = theNode;
                treeView1.AfterSelect += new TreeViewEventHandler(treeView1_AfterSelect);
            }
        }
        private void treeView1_MouseDown(object sender, MouseEventArgs e)
        {
            TreeNode tn = (TreeNode)treeView1.GetNodeAt(new Point(e.X, e.Y));
            if (tn != null)
                treeView1.SelectedNode = tn;
        }
        private void menuAutoEval_Click(object sender, EventArgs e)
        {
            tsmiAutoEval.Checked = menuAutoEval.Checked;
        }
        private void tsmiAutoEval_Click(object sender, EventArgs e)
        {
            menuAutoEval.Checked = tsmiAutoEval.Checked;
        }
        private void menuCellHeadInfo_Click(object sender, EventArgs e)
        {
            int col = Cell1.GetCurrentCol();
            int row = Cell1.GetCurrentRow();
            int sheet = Cell1.GetCurSheet();
            if (col < 1 || row < 1)
                return;
            frmHeadInfo frm = new frmHeadInfo(Cell1.GetCellNote(col, row, sheet));
            DialogResult drs = frm.ShowDialog();
            if (drs == DialogResult.OK)
            {
                string note;
                if (frm.cboVars.SelectedIndex == -1)
                    note = "";
                else
                    note = frm.cboVars.SelectedValue.ToString();
                Cell1.SetCellNote(col, row, sheet, note);
            }
        }
        private void treeView1_BeforeLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            LastNode = this.treeView1.SelectedNode;
            if (LastNode == null || LastNode.ImageIndex != 3)
            {
                return;
            }
        }
        private void treeView1_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            TreeNodeEx node = (TreeNodeEx)LastNode;
            if (node == null || node.ImageIndex != 3)
            {
                return;
            }
            if (e.Node != null)
            {
                if (!RenameNodetext(e.Label, node))
                    e.CancelEdit = true;
            }
        }
        /// <summary>
        /// �������ڵ����
        /// </summary>
        private bool RenameNodetext(string NewText, TreeNodeEx node)
        {
            if (!String.IsNullOrEmpty(NewText))
            {
                if (MyCommon.HasFilterChars(NewText))
                {
                    TXMessageBoxExtensions.Info("���ܰ�����" + MyCommon.Chars2String() + "���ַ���");
                    return false;
                }
                string NewPath = node.NodeKey.Substring(0, node.NodeKey.LastIndexOf("\\") + 1) + NewText;
                //CBLL.CellTreesData cbll = new ERM.CBLL.CellTreesData();
                //cbll.UpdateNodeTitleByTreePath(node.NodeKey, NewPath, NewText, Globals.ProjectNO);
                node.NodeKey = NewPath;
                return true;
            }
            else
                return false;
        }
        private void toolbtnSave_Click(object sender, EventArgs e)
        {
            this.CellOperate("Save");
        }

        private void toolCopy_Click(object sender, EventArgs e)
        {
            string openfilename = Cell1.GetFileName();
            if (openfilename != null && openfilename != "")
            {
                Cell1.SaveEdit();
                Cell1.SaveFile(openfilename, 0);
                //Cell1.OpenFile(openfilename, "");//2013 3.25 YQ ģ��̫���ʱ�򣬱���̫�������ε��ٴδ��ļ�����
            }
            string CopyString = "";
            int iCount = 0;
            Clipboard.Clear();
            foreach (TreeNodeEx obj in treeView1.Nodes)
            {
                if (obj.Checked == true || obj.IsSelected)
                {
                    CopyString += obj.Name;
                    CopyString += ";";
                    CopyString += Globals.ProjectNO;
                    CopyString += "|";

                    iCount++;
                }
            }
            if (CopyString != "")
            {
                Clipboard.SetDataObject(CopyString.Remove(CopyString.Length - 1));
            }

            statusStrip1.Items[0].Text = "������" + iCount.ToString() + "����񣬿��Կ��ļ�ճ����";
        }

        private void toolPaster_Click(object sender, EventArgs e)
        {
            try
            {
                string CopyString = "";
                IDataObject iData = Clipboard.GetDataObject();
                if (iData.GetDataPresent(DataFormats.Text))
                {
                    CopyString = (String)iData.GetData(DataFormats.Text);
                    string[] cellList = CopyString.Split('|');
                    BLL.T_CellAndEFile_BLL cellBLL = new ERM.BLL.T_CellAndEFile_BLL();
                    foreach (string cellID in cellList)
                    {
                        string[] CellIDList = cellID.Split(';');

                        if (CellIDList.Length != 2)
                            continue;

                        MDL.T_CellAndEFile cellMDL = cellBLL.Find(CellIDList[0], CellIDList[1]);
                        if (cellMDL != null)
                        {
                            if (cellMDL.FileID == fileNode.Name)
                            {
                                //����
                                cellMDL.DocYs = 1;//Leo �и��£���Ҫ��Ҫ��Ҫ����pdf
                                cellMDL.DoStatus = 1;
                                cellBLL.Update(cellMDL);
                            }

                            string sourpath = Application.StartupPath + "\\" + Properties.Settings.Default.ProjectPath + "\\" + cellMDL.ProjectNO + "\\" + cellMDL.filepath;
                            if (System.IO.File.Exists(sourpath))
                            {
                                FileInfo fileInfo = new FileInfo(sourpath);
                                string newCellName = Guid.NewGuid().ToString();
                                System.IO.File.Copy(sourpath, Globals.ProjectPath + "ODOC\\" + newCellName + fileInfo.Extension, true);

                                int OrderIndex = cellBLL.GetMaxOrderIndex(fileNode.Name, Globals.ProjectNO);
                                cellMDL.ProjectNO = Globals.ProjectNO;
                                cellMDL.CellID = newCellName;// Guid.NewGuid().ToString();
                                cellMDL.FileID = fileNode.Name;
                                cellMDL.DocYs = 1;//Leo �и��£���Ҫ��Ҫ��Ҫ����pdf
                                cellMDL.DoStatus = 1;
                                cellMDL.GdFileID = null;
                                cellMDL.filepath = "ODOC\\" + newCellName + fileInfo.Extension;
                                cellMDL.orderindex = OrderIndex + 1;
                                cellBLL.Add(cellMDL);

                                //���ԭ����Ϣ
                                // MyCommon.InsertOldEfile(cellMDL.CellID, cellMDL.FileID, Globals.ProjectNO, Globals.LoginUser, "�����ñ�-ճ�����", sourpath);    

                                TreeNodeEx newNode = new TreeNodeEx();
                                newNode.Name = cellMDL.CellID;
                                newNode.NodeValue = cellMDL.filepath;
                                newNode.ImageIndex = 3;
                                newNode.SelectedImageIndex = 3;
                                newNode.Text = cellMDL.title;
                                treeView1.Nodes.Add(newNode);
                                if (treeView1.Nodes.Count == 1)
                                    treeView1.SelectedNode = newNode;
                            }
                            else
                            {
                                TXMessageBoxExtensions.Info("��ʾ���Ҳ������Ʊ���ԭ�ģ����ȱ��渴���ļ���");
                                break;
                            }
                        }
                    }
                }
            }
            catch { }
        }

        private void toolStripButtonModify_Click(object sender, EventArgs e)
        {
            this.EditNode();
        }

        private void checkBoxSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            foreach (TreeNodeEx obj in treeView1.Nodes)
            {
                obj.Checked = checkBoxSelectAll.Checked;
            }
        }

        /// <summary>
        /// ����ֻ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ts_CellReadOnly_Click(object sender, EventArgs e)
        {
            int startCol = 0, startRow = 0, endCol = 0, endRow = 0;
            Cell1.GetSelectRange(ref startCol, ref startRow, ref endCol, ref endRow);
            int sheet = Cell1.GetCurSheet();

            for (int i = startCol; i <= endCol; i++)
            {
                for (int j = startRow; j <= endRow; j++)
                {
                    int style = Cell1.GetCellInput(i, j, sheet);
                    if (style != 5)
                        Cell1.SetCellInput(i, j, sheet, 5);
                    else
                        Cell1.SetCellInput(i, j, sheet, 0);
                }
            }
        }

        private void tsmiPageOption_Click(object sender, EventArgs e)
        {
            this.CellOperate("PageSetup");
        }

        /// <summary>
        /// ����ģ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_InputTemplet_Click(object sender, EventArgs e)
        {
            DialogResult ret = TXMessageBoxExtensions.Question("��ʾ��ȷ�����ø�Ŀ¼������ģ����");
            if (ret != DialogResult.OK)
                return;
            //����ģ��� ����м�¼����ӹ��� ���û�оͲ���� ��ʾ��
            IList<MDL.T_CellFileTemplate> EFTemplate_List =
                (new BLL.T_CellFileTemplate_BLL()).FindByFileID(fileNode.Name);
            if (EFTemplate_List != null && EFTemplate_List.Count > 0)
            {
                foreach (MDL.T_CellFileTemplate c_template in EFTemplate_List)
                {
                    string CelllTplFile = Application.StartupPath + "\\Template" + c_template.filepath;
                    if (System.IO.File.Exists(CelllTplFile))
                    {
                        MDL.T_CellAndEFile add_MDL = new ERM.MDL.T_CellAndEFile();
                        add_MDL.CellID = Guid.NewGuid().ToString();
                        add_MDL.ProjectNO = Globals.ProjectNO;
                        add_MDL.FileID = c_template.FileID;
                        add_MDL.parentid = c_template.parentid;
                        add_MDL.codeno = c_template.codeno;
                        add_MDL.title = c_template.title;
                        add_MDL.isvisible = 1;
                        add_MDL.DocYs = 1;//Leo �и��£���Ҫ��Ҫ��Ҫ����pdf
                        add_MDL.DoStatus = 1;
                        add_MDL.orderindex = (new BLL.T_CellAndEFile_BLL()).GetMaxOrderIndex(add_MDL.FileID, add_MDL.ProjectNO) + 1;//c_template.orderindex; 

                        TreeNodeEx node = new TreeNodeEx();
                        node.Name = add_MDL.CellID;
                        node.Text = add_MDL.title;
                        node.Tag = 0;
                        node.ImageIndex = 3;
                        node.SelectedImageIndex = node.ImageIndex;

                        FileInfo fileInfo = new FileInfo(CelllTplFile);
                        string NewCellFileID = add_MDL.CellID;
                        string NewCellFile = Globals.ProjectPath + "ODOC\\" + NewCellFileID + fileInfo.Extension;
                        System.IO.File.Copy(CelllTplFile, NewCellFile, true);

                        add_MDL.filepath = "ODOC\\" + NewCellFileID + fileInfo.Extension;
                        node.NodeValue = add_MDL.filepath;


                        //���ԭ����Ϣ
                        // MyCommon.InsertOldEfile(add_MDL.CellID, add_MDL.FileID, Globals.ProjectNO, Globals.LoginUser, "�����ñ�-����ģ��", CelllTplFile);    

                        (new BLL.T_CellAndEFile_BLL()).Add(add_MDL);

                        RefreshCell(NewCellFile, false, this.treeView1.Nodes.Count + 1, "", false, false, false);

                        this.treeView1.Nodes.Add(node);
                        this.treeView1.SelectedNode = node;
                    }
                }
            }
            else
                TXMessageBoxExtensions.Info("����ܰ��ʾ������Ŀ¼��û��ģ��������ã�");
        }
        /**********************************************************************
         * ��ͼ ����
         */
        private void btn_Imge_Click(object sender, EventArgs e)
        {
            string systemPath = Environment.GetFolderPath(Environment.SpecialFolder.System);
            System.Diagnostics.Process.Start(systemPath + "\\mspaint.exe");
        }

        private void menuImge_Click(object sender, EventArgs e)
        {
            string systemPath = Environment.GetFolderPath(Environment.SpecialFolder.System);
            System.Diagnostics.Process.Start(systemPath + "\\mspaint.exe");
        }

        private void tsb_SavaAndGd_Click(object sender, EventArgs e)
        {
            StringBuilder objList = new StringBuilder();
            foreach (TreeNodeEx obj in treeView1.Nodes)
            {
                if (obj.Checked == true)
                {
                    objList.Append(obj.Name + ";");
                }
            }
            if (objList.Length > 0)
            {
                if (TXMessageBoxExtensions.Question("��ʾ��ȷ���������� [�鵵���] ��") == DialogResult.OK)
                {
                    frmSaveFile frm_SaveFile = new frmSaveFile(2,
                        objList.ToString().Substring(0, objList.ToString().Length - 1), null);
                    frm_SaveFile.ShowDialog();
                }
            }
            else
            {
                if (treeView1.SelectedNode != null)
                {
                    TreeNodeEx cellNode = (TreeNodeEx)treeView1.SelectedNode;
                    frmSaveFile frm_SaveFile = new frmSaveFile(1, cellNode.Name, null);
                    frm_SaveFile.ShowDialog();
                }
                else
                {
                    TXMessageBoxExtensions.Question("��ʾ����ѡ����Ҫɾ�����ļ���");
                    return;
                }
            }
        }

        private void Cell1_MouseLClick(object sender, AxCELL50Lib._DCell2000Events_MouseLClickEvent e)
        {

            string key = Cell1.GetCellNote(e.col, e.row, Cell1.GetCurSheet());
            //��Ԫ�����Ϊ�գ����߱���������"run"��ʼ���˳�
            if (key == "" || !key.StartsWith("m", true, null))
                return;

            this.Cell1.MouseLClick -= new AxCELL50Lib._DCell2000Events_MouseLClickEventHandler(this.Cell1_MouseLClick);
            //TXMessageBoxExtensions.Info(MyCommon.Right(key, key.Length - 2));
            Form fm = new ERM.UI.CellEdit.frmCellTip(MyCommon.Right(key, key.Length - 2));
            fm.ShowDialog();
            this.Cell1.MouseLClick += new AxCELL50Lib._DCell2000Events_MouseLClickEventHandler(this.Cell1_MouseLClick);
        }

        private void ts_FH_Click(object sender, EventArgs e)
        {
            this.CellOperate("FH1");
        }

        private void ts_FH2_Click(object sender, EventArgs e)
        {
            this.CellOperate("FH2");
        }

        private void ts_FH3_Click(object sender, EventArgs e)
        {
            this.CellOperate("FH3");
        }

        private void tx_FH4_Click(object sender, EventArgs e)
        {
            this.CellOperate("FH4");
        }

        private Hashtable GetCellParem()
        {
            Hashtable cellParem = new Hashtable();
            ERM.BLL.T_Dict_BLL dicData = new ERM.BLL.T_Dict_BLL();
            IList<MDL.T_Dict> ds = dicData.FindByKeyWord("jsbzmchbh");

            string[] cell = new string[ds.Count + 1];
            cell[0] = "";
            for (int i = 0; i < ds.Count; i++)
            {
                cell[i + 1] = (ds[i].DisplayName);
            }
            cellParem.Add("jsbzmchbh".ToLower(), cell);

            IList<MDL.T_Dict> ds2 = dicData.FindByKeyWord("sgdwjcpdjg");
            string[] cell2 = new string[ds2.Count + 1];
            cell2[0] = "";
            for (int i = 0; i < ds2.Count; i++)
            {
                cell2[i + 1] = (ds2[i].DisplayName);
            }
            cellParem.Add("sgdwjcpdjg".ToLower(), cell2);

            IList<MDL.T_Dict> ds3 = dicData.FindByKeyWord("jlysjl");
            string[] cell3 = new string[ds3.Count + 1];
            cell3[0] = "";
            for (int i = 0; i < ds3.Count; i++)
            {
                cell3[i + 1] = (ds3[i].DisplayName);
            }
            cellParem.Add("jlysjl".ToLower(), cell3);
            return cellParem;
        }

        private void tsmi_Excel_Click(object sender, EventArgs e)
        {
            Cell1.ExportExcelDlg();
        }

        private void tsmi_PDF_Click(object sender, EventArgs e)
        {
            SaveFileDialog FileDialog = new SaveFileDialog();
            //�����ļ�����
            //��д�������磺txt files(*.txt)|*.txt
            FileDialog.Filter = "pdf files(*.pdf)|*.pdf|All files(*.*)|*.*";
            //����Ĭ���ļ��������Բ����ã�
            FileDialog.FileName = Cell1.GetSheetLabel(Cell1.GetCurSheet());
            //����Ի����Ƿ�����ϴδ򿪵�Ŀ¼
            FileDialog.RestoreDirectory = true;

            if (FileDialog.ShowDialog() == DialogResult.OK)
            {
                Cell1.ExportPdfFile(FileDialog.FileName, Cell1.GetCurSheet(), 0, 1);
            }
            //Cell1.ExportPdfFile()
        }

        private void tsb_FL_Click(object sender, EventArgs e)
        {
            frmTemplateInfo frm_TemplateInfo = new frmTemplateInfo(fileNode.Name);
            frm_TemplateInfo.ShowDialog();
        }
    }
}
