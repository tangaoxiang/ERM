/*******************************
 * ����:������(�����д),������(����)
 * ʱ��:2008�°���
 * Ŀ��:���ӹ鵵��̨������
 ******************************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using DigiPower.ERM.CBLL;

using System.IO;

namespace Digi.B {
    public partial class frmStandard : Form {
        #region ����������
        //ʵ�������ķ�����
        private TreeFactory treeFactory = new TreeFactory();

        const string CPROJECTNO = "digipower";

        DigiPower.ERM.BLL.FileRecording_Templet B_FileRecording_Templet = new DigiPower.ERM.BLL.FileRecording_Templet();

        DigiPower.ERM.BLL.Cell_Templet B_Cell_Templet = new DigiPower.ERM.BLL.Cell_Templet();

        DigiPower.ERM.Model.FileRecording_Templet M_FileRecording_Templet;

        DigiPower.ERM.Model.Cell_Templet M_Cell_Templet;

        SaveASynStatus pSaveStaus = new SaveASynStatus();

        /// <summary>
        /// �ж��Ƿ����ڶ�ȡĿ¼����ģ������
        /// </summary>
        bool isReadModel = true;

        bool isTitleChanged = false;

        bool isFilePathChanged = false;

        //        //������
        private Form _parentForm;
        #endregion

        #region ���캯��
        public frmStandard(Form parentForm) {
            InitializeComponent();
            pSaveStaus.Enter += new SaveASynStatus.EnterHandle(pSaveStaus_Enter);
            pSaveStaus.End += new SaveASynStatus.EndHandle(pSaveStaus_End);

            cpRecord.Dock = DockStyle.Fill;
            cpTable.Dock = DockStyle.Fill;
            //            //���캯����ֵ
            //            this.Text = title;
            //            this._isArchiveTable = isArchiveTable;
            //            this._tableName = tableName;
            //            this._standardTableForArchive = standardTableForArchive;
            this._parentForm = parentForm;

            BindingCombox();

            //������
            treeFactory.GetTree(treeView1, "", "", true, "", false);

        }
        #endregion

        #region ��������
        private void BindingCombox() {
            //�������� TreeView �� ImageList
            ImageList imageList1 = treeFactory.CreateTreeImageList();
            treeView1.ImageList = imageList1;

            //ͼ������
            cboImageIndex.ImageList = imageList1;
            cboImageIndex.DropDownStyle = ComboBoxStyle.DropDownList;
            cboImageIndex.Items.Add(new ComboBoxExItem("���ڵ�", 0));
            cboImageIndex.Items.Add(new ComboBoxExItem("�ļ���", 1));
            cboImageIndex.Items.Add(new ComboBoxExItem("���", 2));
            cboImageIndex.SelectedIndex = 0;

            cboSjdw.DataSource = new string[] { "", "����", "����", "����" };
            cboSgdw.DataSource = new string[] { "","����", "����", "����" };
            cboJldw.DataSource = new string[] { "", "����", "����", "����" };
            cboJsdw.DataSource = new string[] { "","����", "����", "����" };

            //string[] items2 = new string[] { "��Ҫ�ύ", "����Ҫ�ύ" };
            cboCjdag.Items.Add("��Ҫ�ύ");
            cboCjdag.Items.Add("����Ҫ�ύ");

            //string[] items3 = new string[] { "����", "����", "����" };
            cboWjmj.Items.Add("");
            cboWjmj.Items.Add("����");
            cboWjmj.Items.Add("����");
            cboWjmj.Items.Add("����");

            DigiPower.ERM.BLL.gclbbm gclb = new DigiPower.ERM.BLL.gclbbm();
            DataSet ds = gclb.GetAllList();
            clbGclx.DataSource = ds.Tables[0];
            clbGclx.ValueMember = "gclbbm";
            clbGclx.DisplayMember = "flmc";

            cbofbmc.DataSource = TreesData.GetDistinctFbmc();
            cbozfbmc.DataSource = TreesData.GetDistinctZfbmc();
            //--------------------------------------------
            //����ָʾԭ�ȵ���������ѡ���޶˵ı�ɶ�����
            //--------------------------------------------
            //cboUnit.DataSource = TreesData.GetDistinctUnitType();
        }

        /// <summary>
        /// ��ť���˵��ܷ������ж�
        /// </summary>
        private void CheckEnable() {
            t1_ExpandAll.Enabled = false;
            t1_CollapseAll.Enabled = false;
            t1_Find.Enabled = false;
            t1_Prev.Enabled = false;
            t1_Next.Enabled = false;
            MenuAddRoot.Enabled = false;
            MenuAddNodeBrother.Enabled = false;
            MenuAddNodeChild.Enabled = false;
            MenuAddBrotherModel.Enabled = false;
            MenuAddChildModel.Enabled = false;
            t1_Del.Enabled = false;

            tsmiNewRoot.Enabled = false;
            tsmiNewBrotherNode.Enabled = false;
            tsmiNewChildNode.Enabled = false;
            tsmiAddBrotherModel.Enabled = false;
            tsmiAddChildModel.Enabled = false;
            tsmiDelNode.Enabled = false;


            if (treeView1.Nodes.Count == 0)  //����û���κνڵ�
            {
                MenuAddRoot.Enabled = true;
                tsmiNewRoot.Enabled = true;
            } else //�����нڵ�
            {
                t1_ExpandAll.Enabled = true;
                t1_CollapseAll.Enabled = true;
                t1_Find.Enabled = true;
                t1_Prev.Enabled = true;
                t1_Next.Enabled = true;

                MenuAddNodeChild.Enabled = true;
                MenuAddNodeBrother.Enabled = true;
                MenuAddBrotherModel.Enabled = true;
                MenuAddChildModel.Enabled = true;

                tsmiNewBrotherNode.Enabled = true;
                tsmiNewChildNode.Enabled = true;
                tsmiAddBrotherModel.Enabled = true;
                tsmiAddChildModel.Enabled = true;

                TreeNode node = treeView1.SelectedNode;  //ѡ�еĽڵ�
                if (node != null)  //�����ѡ�еĽڵ�
                {
                    t1_Del.Enabled = true;
                    tsmiDelNode.Enabled = true;

                    if (node.Level != 0) //���Ǹ��ڵ�
                    {
                        MenuAddNodeBrother.Enabled = true;
                        tsmiNewBrotherNode.Enabled = true;
                    }
                }
            }
        }

        /// <summary>
        /// �����͸ı�ʱ,��Ӧ�ķֲ�,�ӷֲ���������ʾ�ı�
        /// </summary>
        private void Operator_ChangeCodeType() {
            switch (cboJdlb.SelectedIndex) {
                case 0://�ֲ�
                    this.cbofbmc.Enabled = true;
                    this.cbozfbmc.Text = ""; this.cbozfbmc.Enabled = false;
                    this.txtfxmc.Text = ""; this.txtfxmc.Enabled = false;
                    break;
                case 1://����
                    this.cbofbmc.Enabled = true;
                    this.cbozfbmc.Enabled = true;
                    this.txtfxmc.Enabled = true;
                    break;
                case 2://������
                    this.cbofbmc.Text = ""; this.cbofbmc.Enabled = false;
                    this.cbozfbmc.Text = ""; this.cbozfbmc.Enabled = false;
                    this.txtfxmc.Text = ""; this.txtfxmc.Enabled = false;
                    break;
                case 3://ʩ��
                    this.cbofbmc.Text = ""; this.cbofbmc.Enabled = false;
                    this.cbozfbmc.Text = ""; this.cbozfbmc.Enabled = false;
                    this.txtfxmc.Text = ""; this.txtfxmc.Enabled = false;
                    break;
                case 4://�ӷֲ�
                    this.cbofbmc.Enabled = true;
                    this.cbozfbmc.Enabled = true;
                    this.txtfxmc.Text = ""; this.txtfxmc.Enabled = false;
                    break;
                default:
                    this.cbofbmc.Text = ""; this.cbofbmc.Enabled = false;
                    this.cbozfbmc.Text = ""; this.cbozfbmc.Enabled = false;
                    this.txtfxmc.Text = ""; this.txtfxmc.Enabled = false;
                    break;
            }
        }


        private void SetComboItem(ComboBox cbo, string destString)
        {
            cbo.SelectedIndex = -1;
            for (int i = 0; i < cbo.Items.Count; i++)
            {
                if (cbo.Items[i].ToString() == destString)
                {
                    cbo.SelectedIndex = i;
                    break;
                }
            }
        }
        /// <summary>
        /// ���һ��ڵ㵯���˵����п���
        /// </summary>
        private void Operator_ContextMenuOpening(TreeNode pNode)
        {
            if (Command_IsSelectFile(pNode as TreeNodeEx)) {
                this.tsmiNewBrotherNode.Enabled = true;
                this.tsmiNewChildNode.Enabled = true;
                this.tsmiAddBrotherModel.Enabled = true;
                this.tsmiAddChildModel.Enabled = true;
            } else if (Command_IsSelectModel(pNode as TreeNodeEx)) {
                this.tsmiNewBrotherNode.Enabled = true;
                this.tsmiNewChildNode.Enabled = false;
                this.tsmiAddBrotherModel.Enabled = true;
                this.tsmiAddChildModel.Enabled = false;
            } else if (Command_IsSelectRoot(pNode as TreeNodeEx)) {
                this.tsmiNewBrotherNode.Enabled = false;
                this.tsmiNewChildNode.Enabled = true;
                this.tsmiAddBrotherModel.Enabled = false;
                this.tsmiAddChildModel.Enabled = true;
            }
        }

        /// <summary>
        /// ���ı�������ʾ�ļ���Ϣ
        /// </summary>
        /// <param name="theNode">TreeNodeEx</param>
        private void Operator_GetFile(TreeNodeEx theNode) {
            DigiPower.ERM.Model.FileRecording_Templet M_FileRecording_Templet = theNode.Tag as DigiPower.ERM.Model.FileRecording_Templet;
            cboImageIndex.SelectedIndex = theNode.ImageIndex;
            txtTitle.Text = M_FileRecording_Templet.gdwj;
            //txtZdz.Text = M_FileRecording_Templet.zrr;
            txtTableName.Text = M_FileRecording_Templet.table_name;
            //cboSgdw.Text = M_FileRecording_Templet.sgdw;
            //cboJsdw.Text = M_FileRecording_Templet.jsdw;
            //cboSjdw.Text = M_FileRecording_Templet.sjdw;
            //cboJldw.Text = M_FileRecording_Templet.jldw;
            //cboWjmj.Text = M_FileRecording_Templet.wjmj;

            SetComboItem(cboSgdw, M_FileRecording_Templet.sgdw);
            SetComboItem(cboJsdw, M_FileRecording_Templet.jsdw);
            SetComboItem(cboSjdw, M_FileRecording_Templet.sjdw);
            SetComboItem(cboJldw, M_FileRecording_Templet.jldw);
            SetComboItem(cboWjmj, M_FileRecording_Templet.wjmj);

            cboCjdag.Text = M_FileRecording_Templet.cjdag == "1" ? "��Ҫ�ύ" : "����Ҫ�ύ";//���������Ƶ�ת��
            string[] gclx = M_FileRecording_Templet.gclx.Split(';');
            for (int i = 0; i < clbGclx.Items.Count; i++) {
                clbGclx.SetItemChecked(i, false);
            }
            foreach (string str in gclx) {
                for (int i = 0; i < clbGclx.Items.Count; i++) {
                    if (clbGclx.GetItemText(clbGclx.Items[i]) == str)
                        clbGclx.SetItemChecked(i, true);
                }
            }
        }


        /// <summary>
        /// ���ı�������ʾģ����Ϣ
        /// </summary>
        /// <param name="theNode">TreeNodeEx</param>
        private void Operator_GetModel(TreeNodeEx theNode) {
            DigiPower.ERM.Model.Cell_Templet M_Cell_Templet = theNode.Tag as DigiPower.ERM.Model.Cell_Templet;
            cboImageIndex.SelectedIndex = theNode.ImageIndex;
            txtTitle.Text = theNode.Text;
            txtFilepath.Text = theNode.NodeValue;
            txtExamplePath.Text = M_Cell_Templet.examplepath;
            cboUnit.Text = M_Cell_Templet.zrr;
            cboJdlb.Text = this.cboJdlb.GetItemText(this.cboJdlb.Items[M_Cell_Templet.codetype - 2]);
            cbofbmc.Text = M_Cell_Templet.fbmc;
            cbozfbmc.Text = M_Cell_Templet.zfbmc;
            txtfxmc.Text = M_Cell_Templet.fxmc;
            txtCodeno.Text = theNode.NodeKey;
        }

        /// <summary>
        /// ���ýڵ�����
        /// </summary>
        /// <param name="pNode">�ڵ�</param>
        /// <param name="pCount">���Ƶ�λ��</param>
        void Operator_NodeUp(TreeNodeEx pNode, int pCount) {
            if (null != pNode.Parent) {
                TreeNodeEx tParentNode = pNode.Parent as TreeNodeEx;
                int tCount = tParentNode.Nodes.IndexOf(pNode) - pCount;
                tParentNode.Nodes.Remove(pNode);
                tParentNode.Nodes.Insert(tCount, pNode);
                this.treeView1.SelectedNode = pNode;
            } else {
                int tCount = this.treeView1.Nodes.IndexOf(pNode) - pCount;
                this.treeView1.Nodes.Remove(pNode);
                this.treeView1.Nodes.Insert(tCount, pNode);
                this.treeView1.SelectedNode = pNode;
            }
        }

        /// <summary>
        /// ����ʾ��Ŀ¼��Ϣ���浽���ڵ���
        /// </summary>
        /// <param name="theNode">TreeNodeEx</param>
        private void Operator_SetFile(TreeNodeEx theNode) {
            theNode.Text = txtTitle.Text;
        }

        /// <summary>
        /// ���ı����е�ģ����Ϣ���浽���ڵ���
        /// </summary>
        /// <param name="theNode">TreeNodeEx</param>
        private void Operator_SetModel(TreeNodeEx theNode) {
            theNode.Text = txtTitle.Text;
            theNode.NodeValue = txtFilepath.Text;
            theNode.NodeKey = txtCodeno.Text;
        }

        /// <summary>
        /// ���ڵ��ϷŽ���ʱ�Ĳ���
        /// </summary>
        /// <param name="e">DragEventArgs</param>
        private void Operator_TreeViewDragDrop(TreeNode targeNode) {
            //if (null != moveNode.Parent) {
            //    moveNode.Parent.Nodes.Remove(moveNode);
            //} else {
            //    this.treeView1.Nodes.Remove(moveNode);
            //}
            //targeNode.Nodes.Add(moveNode);

        }

        /// <summary>
        /// ���ڵ��Ϸ�ʱ������һ�ڵ�ʱ����
        /// </summary>
        /// <param name="sender">TreeView</param>
        /// <param name="e">DragEventArgs</param>
        private void Operator_TreeViewDragOver(object sender, DragEventArgs e) {
            Point pt = ((TreeView)(sender)).PointToClient(new Point(e.X, e.Y));
            TreeNode targeNode = this.treeView1.GetNodeAt(pt);
            this.treeView1.SelectedNode = targeNode;
        }

        /// <summary>
        /// ���ڵ��϶���ʼʱ����
        /// </summary>
        /// <param name="e">ItemDragEventArgs</param>
        private void Operator_TreeViewItemDrag(ItemDragEventArgs e) {
            moveNode = e.Item as TreeNode;
            DoDragDrop(e.Item, DragDropEffects.Move);
        }

        /// <summary>
        /// ���ýڵ�����
        /// </summary>
        /// <param name="pNode">�ڵ�</param>
        /// <param name="pCount">���Ƶ�λ��</param>
        void Operator_NodeDown(TreeNodeEx pNode, int pCount) {
            if (null != pNode.Parent) {
                TreeNodeEx tParentNode = pNode.Parent as TreeNodeEx;
                int tCount = tParentNode.Nodes.IndexOf(pNode) + pCount;
                tParentNode.Nodes.Remove(pNode);
                tParentNode.Nodes.Insert(tCount, pNode);
                this.treeView1.SelectedNode = pNode;
            } else {
                int tCount = this.treeView1.Nodes.IndexOf(pNode) + pCount;
                this.treeView1.Nodes.Remove(pNode);
                this.treeView1.Nodes.Insert(tCount, pNode);
                this.treeView1.SelectedNode = pNode;
            }
        }

        /// <summary>
        /// չ����ǰ�ڵ��µ�ȫ���ӽڵ�
        /// </summary>
        /// <param name="pNode">��ǰ�ڵ�</param>
        void Operator_AllExpand(TreeNodeEx pNode) {
            if (!this.Command_IsSelectModel(pNode)) {
                pNode.Expand();
                Application.DoEvents();
                foreach (TreeNodeEx tNode in pNode.Nodes) {
                    Operator_AllExpand(tNode);
                }
            }
        }

        #region �ڵ�������ɾ�����ƶ��ľ��巽��
        /// <summary>
        /// �������ڵ�
        /// </summary>
        private void NewRoot() {
            //newParentID = "0";
            //cboLastleaf.SelectedIndex = 0;
            //cboImageIndex.SelectedIndex = 0;
            //txtTitle.Text = "";

            //lblCheckLastLeaf.Visible = false;
            //lblCheckImageIndex.Visible = false;
            //lblCellNotExist.Visible = false;
            //lblExampleNotExist.Visible = false;
        }

        /// <summary>
        /// ����ģ��
        /// </summary>
        private void NewTable(bool ChildNode, TreeNodeEx theNode) {
            try {
                if (theNode == null) return;

                this.Cursor = Cursors.WaitCursor;


                //�ҵ����ڵ�
                TreeNodeEx parentNode;
                if (!ChildNode)//�����ͬ��Ŀ¼
                    parentNode = (TreeNodeEx)theNode.Parent;
                else {
                    parentNode = theNode;
                    Command_RefreshNode(parentNode);
                }
                TreesData treesData = new TreesData();
                string NodeID = treesData.GetNextNodeID(parentNode.Name, CPROJECTNO);

                int orderindex = treesData.GetNextIndex(parentNode.Name, CPROJECTNO);

                if (!this.Command_InLoneRange(orderindex)) {//�����˳��ų�����������͵ķ�ΧPow(2,31)-1,���յ�ǰ�ڵ�˳����������������˳���
                    orderindex = this.Command_BuildSeriersModelOrderindex(parentNode)+1;
                }

                string ParentID = parentNode.Name;

                string Title = "<����ģ��>"+orderindex.ToString();

                string ptreePath = parentNode.FullPath;

                int codetype = 5;

                DigiPower.ERM.Model.Cell_Templet cellMode = new DigiPower.ERM.Model.Cell_Templet();


                cellMode.codetype = codetype;

                cellMode.customdefine = 1;

                cellMode.id = NodeID;

                cellMode.orderindex = orderindex;

                cellMode.parentid = ParentID;

                cellMode.title = Title;

                cellMode.PTreePath = ptreePath;

                cellMode.TreePath = ptreePath + "\\" + Title;

                cellMode.zrr = this.txtZdz.Text;

                cellMode.projectno = "digipower";

                cellMode.isvisible = 1;

                this.B_Cell_Templet.Add(cellMode);

                //ˢ�½ڵ�
                //treeView1.DrawMode = TreeViewDrawMode.Normal;
                //treeFactory.RefreshNode(parentNode, "", "", true, "", false);
                TreeNodeEx tNewTable = new TreeNodeEx();
                tNewTable.Name = cellMode.id;         //�ڵ�ΨһID,��������
                tNewTable.Text = cellMode.title;          //����
                tNewTable.Tag = cellMode; //�Ƿ����һ���ڵ�,����·��,�Ƿ��û�������,����
                tNewTable.Checked = cellMode.isvisible == 1 ? true : false;//�Ƿ�ɼ�
                tNewTable.NodeKey = "";
                tNewTable.NodeValue = "";
                parentNode.Nodes.Add(tNewTable);
                tNewTable.ImageIndex = 2;
                tNewTable.SelectedImageIndex = 2;
                this.treeView1.Refresh();
                //treeView1.DrawMode = TreeViewDrawMode.OwnerDrawText;

                //ѡ���½ڵ�
                this.treeView1.SelectedNode = tNewTable;

                this.Cursor = Cursors.Default;
            } catch (Exception ex) {
#if DEBUG
                MessageBox.Show(ex.ToString());
#else
                Functions.ShowErrors(ex);
#endif
            }

        }

        /// <summary>
        /// �����ڵ�
        /// </summary>
        /// <param name="ChildNode">����ͬ��Ŀ¼�����ӽڵ�</param>
        private void NewFloder(bool ChildNode, TreeNodeEx theNode) {
            try {
                if (theNode == null) return;

                //�ҵ����ڵ�
                TreeNodeEx parentNode;
                if (!ChildNode)//�����ͬ��Ŀ¼
                    parentNode = (TreeNodeEx)theNode.Parent;
                else {
                    parentNode = theNode;
                    Command_RefreshNode(parentNode);
                }


                //��ʼ
                this.Cursor = Cursors.WaitCursor;



                //��Ҫ��������������ռ�
                TreesData treesData = new TreesData();
                string NodeID = treesData.GetNextNodeID(parentNode.Name, CPROJECTNO);

                int orderindex = treesData.GetNextIndex(parentNode.Name, CPROJECTNO);

                if (!this.Command_InLoneRange(orderindex)) {//�����˳��ų�����������͵ķ�ΧPow(2,31)-1,���յ�ǰ�ڵ�˳����������������˳���
                    orderindex = this.Command_BuildSeriersFileOrderindex(parentNode)+1;
                }
                string Title = "<�½��ڵ�>"+orderindex.ToString();

                DigiPower.ERM.Model.FileRecording_Templet fileModel = new DigiPower.ERM.Model.FileRecording_Templet();

                fileModel.gdwj = Title;

                fileModel.id = NodeID;

                fileModel.orderindex = orderindex;

                fileModel.TreePath = parentNode.FullPath + "\\" + Title;

                fileModel.isvisible = 1;

                DigiPower.ERM.Model.FileRecording_Templet pModel = parentNode.Tag as DigiPower.ERM.Model.FileRecording_Templet;

                fileModel.cjdag = pModel.cjdag;
                fileModel.gclx = pModel.gclx;
                fileModel.jldw = pModel.jldw;
                fileModel.jsdw = pModel.jsdw;
                fileModel.sgdw = pModel.sgdw;
                fileModel.sjdw = pModel.sjdw;
                fileModel.wjmj = pModel.wjmj;
                fileModel.projectno = "digipower";
                fileModel.zrr = this.txtZdz.Text;//��½�û�

                this.B_FileRecording_Templet.Add(fileModel);


                //ˢ�½ڵ�
                //treeView1.DrawMode = TreeViewDrawMode.Normal;

                //treeFactory.RefreshNode(parentNode, "", "", true, "", false);
                TreeNodeEx tNewFolder = new TreeNodeEx();
                tNewFolder.Name = fileModel.id;         //�ڵ�ΨһID,��������
                tNewFolder.Text = fileModel.gdwj;          //����
                tNewFolder.Tag = fileModel; //�Ƿ����һ���ڵ�,����·��,�Ƿ��û�������,����
                tNewFolder.Checked = fileModel.isvisible == 1 ? true : false;//�Ƿ�ɼ�
                parentNode.Nodes.Add(tNewFolder);
                tNewFolder.ImageIndex = 1;
                tNewFolder.SelectedImageIndex = 1;
                this.treeView1.Refresh();

                //treeView1.DrawMode = TreeViewDrawMode.OwnerDrawText;

                //ѡ���½ڵ�
                this.treeView1.SelectedNode = tNewFolder;

                this.Cursor = Cursors.Default;
            } catch (Exception ex) {
#if DEBUG
                MessageBox.Show(ex.ToString());
#else
                Functions.ShowErrors(ex);
#endif
            }
        }



        /// <summary>
        /// ɾ���ڵ�
        /// </summary>
        private void DelNode(TreeNodeEx pNode) {
            if (this.Command_IsSelectModel(pNode)) {
                B_Cell_Templet.Delete(pNode.Name, CPROJECTNO);
                this.treeView1.SelectedNode = pNode.Parent;
                //treeFactory.RefreshNode(pNode.Parent as TreeNodeEx, "", "", true, "", false);
                this.treeView1.Refresh();
            } else if (this.Command_IsSelectFile(pNode)) {
                TreesData.DeleteFileAndChild(pNode.Name);
                this.treeView1.SelectedNode = pNode.Parent;
                //treeFactory.RefreshNode(pNode.Parent as TreeNodeEx, "", "", true, "", false);
                this.treeView1.Refresh();
            } else {
                TreesData.DeleteFileAndChild(pNode.Name);
                this.treeView1.Refresh();
            }
            pNode.Remove();
            //TreeNode theNode = treeView1.SelectedNode;
            //if (theNode == null) return;

            //TreeNodeEx parentNode = (TreeNodeEx)theNode.Parent;
            //if (parentNode == null) parentNode = (TreeNodeEx)treeView1.Nodes[0];

            //DialogResult ret = Functions.ShowQuestion("ȷ��ɾ�� [" + theNode.Text + "] �����ӽڵ㣿");
            //if (ret == DialogResult.Yes)
            //{
            //    //ʹ�ù�����ɾ���ڵ�
            //    this.Cursor = Cursors.WaitCursor;

            //    treeFactory.DelNodes((TreeNodeEx)theNode, this._tableName, string.Empty);


            //    treeView1.DrawMode = TreeViewDrawMode.Normal;

            //    //ˢ�½ڵ�
            //    treeFactory.RefreshNode(parentNode, this._tableName, true, string.Empty);

            //    //ѡ�нڵ�
            //    treeFactory.SelectNode(parentNode);

            //    treeView1.DrawMode = TreeViewDrawMode.OwnerDrawText;

            //    //��鰴ť�Ŀɲ�����
            //    this.CheckEnable();

            //    this.Cursor = Cursors.Default;
            //}
        }

        #endregion
        #endregion

        #region �����

        /// <summary>
        /// ���ڵ��϶�ʱ�ı���Ӧ���ݿ�ļ�¼
        /// <remarks>
        /// ·��,���
        /// </remarks>
        /// </summary>
        /// <param name="sender">TreeView</param>
        /// <param name="e">DragEventArgs</param>
        void Command_TreeViewDragDrop(object sender, DragEventArgs e) {
            Point pt = ((TreeView)(sender)).PointToClient(new Point(e.X,e.Y));
            TreeNodeEx targetNode =(TreeNodeEx)treeView1.GetNodeAt(pt);
            if (targetNode == null)
                return;
            TreeNodeEx moveNode2 = (TreeNodeEx)e.Data.GetData("Digi.B.TreeNodeEx");
            if (moveNode2 == targetNode)
                return;
            if (moveNode2.Parent != targetNode.Parent)//����ͬһ�����Ĳ�������
                return;

            TreeNodeEx temp = (TreeNodeEx)(moveNode2.Clone());
            moveNode2.Remove();

            targetNode.Parent.Nodes.Insert(targetNode.Index, moveNode2);
            treeView1.SelectedNode = moveNode2;
            IList<string> ids = new List<string>();
            for (int i = 0; i < targetNode.Parent.Nodes.Count; i++)
            {
                ids.Add(targetNode.Parent.Nodes[i].Name);
            }
            if (Command_IsSelectModel((TreeNodeEx)targetNode))
                TreesData.UpdateSeriersModelOrderIndex(ids,"digipower");
            if (Command_IsSelectFile((TreeNodeEx)targetNode))
                TreesData.UpdateSeriersFileOrderIndex(ids,"digipower");


            #region
            /*
            Point pt = ((TreeView)(sender)).PointToClient(new Point(e.X, e.Y));
            TreeNode targetNode = treeView1.GetNodeAt(pt);
            if (this.Command_CanDrag(moveNode as TreeNodeEx, targetNode as TreeNodeEx)) {//���Ŀ��ڵ����Ҫ��
                if (Command_IsSelectFile(this.moveNode as TreeNodeEx)) {//�ж��Ƿ�ѡ��Ŀ¼
                    Command_RefreshNode(targetNode as TreeNodeEx);
                    DigiPower.ERM.Model.FileRecording_Templet tTargetFile = (targetNode as TreeNodeEx).Tag as DigiPower.ERM.Model.FileRecording_Templet;
                    tTargetFile.TreePath = targetNode.FullPath;
                    if (!Command_IsSelectRoot(targetNode as TreeNodeEx)) {
                        tTargetFile.pTreePath = targetNode.Parent.FullPath;
                    }
                    DigiPower.ERM.Model.FileRecording_Templet tMoveFile = (this.moveNode as TreeNodeEx).Tag as DigiPower.ERM.Model.FileRecording_Templet;
                    tMoveFile.TreePath = moveNode.FullPath;
                    if (!Command_IsSelectRoot(moveNode as TreeNodeEx)) {
                        tMoveFile.pTreePath = moveNode.Parent.FullPath;
                    }
                    if (!Command_IsSelectModel(targetNode as TreeNodeEx)) {
                        TreesData.MoveFileNodeIn(tTargetFile, tMoveFile);
                    }
                    Operator_TreeViewDragDrop(targetNode);
                }
            }
             */
            #endregion
        }

        /// <summary>
        /// ˢ�µ�ǰ�ڵ�
        /// <remarks>
        /// 1������ýڵ��ǵ�һ�α�չ��,ִ��ˢ�·���
        /// </remarks>
        /// </summary>
        /// <param name="pNode">Ŀ��ڵ�</param>
        private void Command_RefreshNode(TreeNodeEx pNode) {
            if (pNode.IsFirstExpand)
                treeFactory.RefreshNode(pNode, "", "", true, "", false);
            pNode.IsFirstExpand = false;
        }

        /// <summary>
        /// ��ȡ��ǰ�û������Ŀ¼����ʵ��
        /// </summary>
        private void Command_SetFile(TreeNodeEx pNode) {
            M_FileRecording_Templet = pNode.Tag as DigiPower.ERM.Model.FileRecording_Templet;
            M_FileRecording_Templet.id = pNode.Name;
            M_FileRecording_Templet.cjdag = cboCjdag.SelectedIndex == 0 ? "1" : "0";
            M_FileRecording_Templet.gdwj = txtTitle.Text;
            M_FileRecording_Templet.jldw = cboJldw.Text;
            M_FileRecording_Templet.jsdw = cboJsdw.Text;
            M_FileRecording_Templet.sgdw = cboSgdw.Text;
            M_FileRecording_Templet.sjdw = cboSjdw.Text;
            M_FileRecording_Templet.wjmj = cboWjmj.Text;
            M_FileRecording_Templet.gclx = clbGclx.Text;
            M_FileRecording_Templet.zrr = txtZdz.Text;
            M_FileRecording_Templet.table_name = txtTableName.Text;
            M_FileRecording_Templet.TreePath = pNode.FullPath;
            if (!this.Command_IsSelectRoot(pNode)) {
                M_FileRecording_Templet.pTreePath = pNode.Parent.FullPath;
            }
            StringBuilder tBuilder = new StringBuilder();
            for (int tNum = 0; tNum < clbGclx.Items.Count; tNum++) {
                if (clbGclx.GetItemChecked(tNum)) {
                    tBuilder.Append(clbGclx.GetItemText(clbGclx.Items[tNum]));
                    tBuilder.Append(";");
                }
            }
            M_FileRecording_Templet.gclx = tBuilder.ToString().TrimEnd(';');
            M_FileRecording_Templet = null;
        }

        /// <summary>
        /// ���ļ�˳��ű��浽�ڵ���
        /// </summary>
        /// <param name="pNode">�ڵ�</param>
        /// <param name="pOrderindex">˳���</param>
        void Command_SetFileOrderindex(TreeNodeEx pNode,string pOrderindex) {
            M_FileRecording_Templet = pNode.Tag as DigiPower.ERM.Model.FileRecording_Templet;
            M_FileRecording_Templet.orderindex = int.Parse(pOrderindex);
            M_FileRecording_Templet = null;
        }

        /// <summary>
        /// ��ȡ��ǰ�ļ��ڵ��˳���
        /// </summary>
        /// <param name="pNode">��ǰ�ļ��ڵ�</param>
        /// <returns>˳���</returns>
        string Command_GetFileOrderindex(TreeNodeEx pNode) {
            M_FileRecording_Templet = pNode.Tag as DigiPower.ERM.Model.FileRecording_Templet;
            string tOrderindex = M_FileRecording_Templet.orderindex.ToString();
            M_FileRecording_Templet = null;
            return tOrderindex;
        }

        /// <summary>
        /// ��ȡ��ǰ�û������ģ�����ʵ��
        /// </summary>
        private void Command_SetModel(TreeNodeEx pNode) {
            M_Cell_Templet = pNode.Tag as DigiPower.ERM.Model.Cell_Templet;
            M_Cell_Templet.id = pNode.Name;
            M_Cell_Templet.title = txtTitle.Text;
            M_Cell_Templet.fxmc = txtfxmc.Text;
            M_Cell_Templet.codeno = txtCodeno.Text;
            M_Cell_Templet.zrr = cboUnit.Text;
            M_Cell_Templet.filepath = txtFilepath.Text;
            M_Cell_Templet.examplepath = txtExamplePath.Text;
            M_Cell_Templet.fbmc = cbofbmc.Text;
            M_Cell_Templet.zfbmc = cbozfbmc.Text;
            M_Cell_Templet.TreePath = pNode.FullPath;
            M_Cell_Templet.codetype = cboJdlb.SelectedIndex+2;
            M_Cell_Templet.PTreePath = pNode.Parent != null ? pNode.Parent.FullPath : "";
            M_Cell_Templet = null;
        }

        /// <summary>
        /// ��ģ��˳��ű��浽�ڵ���
        /// </summary>
        /// <param name="pNode">�ڵ�</param>
        /// <param name="pOrderindex">˳���</param>
        void Command_SetModelOrderindex(TreeNodeEx pNode, string pOrderindex) {
            M_Cell_Templet = pNode.Tag as DigiPower.ERM.Model.Cell_Templet;
            M_Cell_Templet.orderindex = int.Parse(pOrderindex);
            M_Cell_Templet = null;
        }

        /// <summary>
        /// ��ȡ��ǰģ��ڵ��˳���
        /// </summary>
        /// <param name="pNode">��ǰģ��ڵ�</param>
        /// <returns>˳���</returns>
        string Command_GetModelOrderindex(TreeNodeEx pNode) {
            M_Cell_Templet = pNode.Tag as DigiPower.ERM.Model.Cell_Templet;
            string tOrderindex = M_Cell_Templet.orderindex.ToString();
            M_Cell_Templet = null;
            return tOrderindex;
        }

        /// <summary>
        /// �Ƿ񳬳������ͷ�Χ
        /// </summary>
        /// <param name="pMax">�������</param>
        /// <returns>bool</returns>
        bool Command_InLoneRange(long pMax) {
            const long CLongMax = -2147483648;//������͵ķ�ΧPow(2,31)-1,�з��ŵ�Pow(2,31)Ϊ-2147483648
            return pMax == CLongMax ? false : true;
        }

        /// <summary>
        /// ����ȫ���ļ���·��
        /// </summary>
        /// <param name="pNode">Ŀ¼�ڵ�</param>
        protected virtual void Command_InitFileTreePath(TreeNodeEx pNode) {
            if (!Command_IsSelectModel(pNode) && "��ʱ����" != pNode.Text) {
                DigiPower.ERM.Model.FileRecording_Templet tFile = pNode.Tag as DigiPower.ERM.Model.FileRecording_Templet;
                tFile.TreePath = pNode.FullPath;
                if (!Command_IsSelectRoot(pNode)) {
                    tFile.pTreePath = pNode.Parent.FullPath;
                }
                B_FileRecording_Templet.Update(tFile);
                foreach (TreeNodeEx tNode in pNode.Nodes) {
                    Command_InitFileTreePath(tNode as TreeNodeEx);
                }
            }
        }

        /// <summary>
        /// ��Ŀ¼�ڵ��ϵ���Ϣ���ݵ�����ģ����
        /// </summary>
        /// <param name="pNode"></param>
        void Command_FileNodeToModel(TreeNodeEx pNode) {
            M_FileRecording_Templet = pNode.Tag as DigiPower.ERM.Model.FileRecording_Templet;
        }

        /// <summary>
        /// ��ģ�ͽڵ��ϵ���Ϣ���ݵ�����ģ����
        /// </summary>
        /// <param name="pNode"></param>
        void Command_ModelNodeToModel(TreeNodeEx pNode) {
            M_Cell_Templet = pNode.Tag as DigiPower.ERM.Model.Cell_Templet;
        }

        //����TextChanged
        private void DoTextChange() {
            btnSearchConfirm.Tag = "0";   //���ݿ��дӵڼ����ڵ�ID��ʼ���ң����ڲ�����һ���ڵ㣬�������ݸ��ĺ���Ϊһ���²�ѯ
            if (txtSearchTitle.Text.Trim() == "" && txtSearchCodeno.Text.Trim() == "") {
                btnSearchConfirm.Enabled = false;
            } else {
                btnSearchConfirm.Enabled = true;
            }
        }

        /// <summary>
        /// �����û�ѡ������ͽ��и��±���
        /// </summary>
        private void Command_SaveCatalog(TreeNodeEx pNode) {
            if (null != pNode) {
                if (Command_IsSelectRoot(pNode)) {
                } else if (Command_IsSelectFile(pNode)) {
                    this.Command_UpdateFile(pNode);
                } else if (Command_IsSelectModel(pNode)) {
                    this.Command_UpdateModel(pNode);
                }
            }
            ////
            ////ˢ�½ڵ㣬ѡ�нڵ�
            ////
            //TreeNode[] nodes = treeView1.Nodes.Find(_parentID, true);
            //if (nodes != null && nodes.Length > 0)
            //    _parentNode = nodes[0];  //���ڵ�
            //else
            //{
            //    if (treeView1.Nodes.Count == 0)  //û��һ���ڵ㣬˵���Ǹո��½����ڵ�
            //    {
            //        treeFactory.GetTree(treeView1, this._tableName, true, string.Empty, "", false, true, false);
            //        this.Cursor = Cursors.Default;
            //        return;
            //    }
            //    else
            //    {
            //        _parentNode = treeView1.Nodes[0];
            //    }

            //}


            //treeView1.DrawMode = TreeViewDrawMode.Normal;
            //treeFactory.RefreshNode((TreeNodeEx)_parentNode, this._tableName, true, string.Empty);  //ˢ��

            ////ѡ���޸Ļ�������Node
            ////treeFactory.SelectNode((TreeNodeEx)_parentNode);  //ѡ��
            //treeFactory.SelectNode(treeView1, _nodeID);

            //treeView1.DrawMode = TreeViewDrawMode.OwnerDrawText;


            //this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// �жϵ�ǰѡ�еĽڵ��Ƿ�Ϊģ��
        /// </summary>
        /// <returns>bool</returns>
        private bool Command_IsSelectModel(TreeNodeEx pNode) {
            return pNode.ImageIndex == 2;
        }

        /// <summary>
        /// �жϵ�ǰѡ�еĽڵ��Ƿ�ΪĿ¼
        /// </summary>
        /// <returns>bool</returns>
        private bool Command_IsSelectFile(TreeNodeEx pNode) {
            return pNode.ImageIndex == 1;
        }

        /// <summary>
        /// �жϵ�ǰѡ�еĽڵ��Ƿ�Ϊ���ڵ�
        /// </summary>
        /// <returns>bool</returns>
        private bool Command_IsSelectRoot(TreeNodeEx pNode) {
            return pNode.ImageIndex == 0;
        }

        /// <summary>
        ///�����ڵ��˳����ϵ�
        /// </summary>
        private void Command_NodeUp(TreeNodeEx pNode) {
            if (null != pNode.PrevNode && null != pNode) {
                bool select = this.Command_IsSelectFile(pNode);
                bool pre = this.Command_IsSelectFile(pNode.PrevNode as TreeNodeEx);

                string tPreNodeOrderIndex = pre ? this.Command_GetFileOrderindex(pNode.PrevNode as TreeNodeEx) : this.Command_GetModelOrderindex(pNode.PrevNode as TreeNodeEx);
                string tSelectdeNodeOrderIndex = select ? this.Command_GetFileOrderindex(pNode as TreeNodeEx) : this.Command_GetModelOrderindex(pNode);

                if (pre)
                {
                    TreesData.UpdateFileOrderIndex(pNode.PrevNode.Name, tSelectdeNodeOrderIndex);
                    this.Command_SetFileOrderindex(pNode.PrevNode as TreeNodeEx, tSelectdeNodeOrderIndex);
                }
                else
                {
                    TreesData.UpdateModelOrderIndex(pNode.PrevNode.Name, tSelectdeNodeOrderIndex);
                    this.Command_SetModelOrderindex(pNode.PrevNode as TreeNodeEx, tSelectdeNodeOrderIndex);
                }

                if (select)
                {
                    TreesData.UpdateFileOrderIndex(pNode.Name, tPreNodeOrderIndex);
                    this.Command_SetFileOrderindex(pNode, tPreNodeOrderIndex);
                }
                else
                {
                    TreesData.UpdateModelOrderIndex(pNode.Name, tPreNodeOrderIndex);
                    this.Command_SetModelOrderindex(pNode, tPreNodeOrderIndex);
                }
                this.Operator_NodeUp(pNode as TreeNodeEx, 1);//����һλ
            }
        }

        /// <summary>
        /// ���ڵ��˳����µ�
        /// </summary>
        private void Command_NodeDown(TreeNodeEx pNode) {
            if (null != pNode.NextNode && null != pNode) {

                bool select = this.Command_IsSelectFile(pNode);
                bool next = this.Command_IsSelectFile(pNode.NextNode as TreeNodeEx);

                string tPreNodeOrderIndex = next ? this.Command_GetFileOrderindex(pNode.NextNode as TreeNodeEx) : this.Command_GetModelOrderindex(pNode.NextNode as TreeNodeEx);
                string tSelectdeNodeOrderIndex = select ? this.Command_GetFileOrderindex(pNode as TreeNodeEx) : this.Command_GetModelOrderindex(pNode);

                if (next)
                {
                    TreesData.UpdateFileOrderIndex(pNode.NextNode.Name, tSelectdeNodeOrderIndex);
                    this.Command_SetFileOrderindex(pNode.NextNode as TreeNodeEx, tSelectdeNodeOrderIndex);
                }
                else
                {
                    TreesData.UpdateModelOrderIndex(pNode.NextNode.Name, tSelectdeNodeOrderIndex);
                    this.Command_SetModelOrderindex(pNode.NextNode as TreeNodeEx, tSelectdeNodeOrderIndex);
                }

                if (select)
                {
                    TreesData.UpdateFileOrderIndex(pNode.Name, tPreNodeOrderIndex);
                    this.Command_SetFileOrderindex(pNode, tPreNodeOrderIndex);
                }
                else
                {
                    TreesData.UpdateModelOrderIndex(pNode.Name, tPreNodeOrderIndex);
                    this.Command_SetModelOrderindex(pNode, tPreNodeOrderIndex);
                }
                


                this.Operator_NodeDown(pNode as TreeNodeEx, 1);//����һλ
            }
        }

        /// <summary>
        /// �����ļ�
        /// </summary>
        private void Command_AddFile(TreeNodeEx pNode) {
            Command_SetFile(pNode);
            B_FileRecording_Templet.Add(pNode.Tag as DigiPower.ERM.Model.FileRecording_Templet);
        }

        /// <summary>
        /// ����ģ��
        /// </summary>
        private void Command_AddModel(TreeNodeEx pNode) {
            Command_SetModel(pNode);
            B_Cell_Templet.Add(pNode.Tag as DigiPower.ERM.Model.Cell_Templet);
        }

        /// <summary>
        /// �����������ļ�˳���
        /// </summary>
        /// <param name="pParentNode">���ڵ�</param>
        /// <returns>�������ɵ�����˳��Ÿ���</returns>
        int Command_BuildSeriersFileOrderindex(TreeNodeEx pParentNode) {
            IList<string> tFileIds = new List<string>();
            foreach (TreeNodeEx tChildNode in pParentNode.Nodes) {
                if (this.Command_IsSelectFile(tChildNode)) {
                    tFileIds.Add(tChildNode.Name);
                }
            }
            TreesData.UpdateSeriersFileOrderIndex(tFileIds,"digipower");
            return tFileIds.Count;
        }

        /// <summary>
        /// ����������ģ��˳���
        /// </summary>
        /// <param name="pParentNode">���ڵ�</param>
        /// <returns>�������ɵ�����˳��Ÿ���</returns>
        int Command_BuildSeriersModelOrderindex(TreeNodeEx pParentNode) {
            IList<string> tModelIds = new List<string>();
            foreach (TreeNodeEx tChildNode in pParentNode.Nodes) {
                if (this.Command_IsSelectModel(tChildNode)) {
                    tModelIds.Add(tChildNode.Name);
                }
            }
            TreesData.UpdateSeriersModelOrderIndex(tModelIds,"digipower");
            return tModelIds.Count;
        }

        /// <summary>
        /// �ж��Ƿ��ܽ�Դ�ڵ��ƶ���Ŀ��ڵ���
        /// </summary>
        /// <param name="pMoveNode">Դ�ڵ�</param>
        /// <param name="pTargetNode">Ŀ��ڵ�</param>
        bool Command_CanDrag(TreeNodeEx pMoveNode, TreeNodeEx pTargetNode) {
            return Command_TargetIsDirectParentNode(pMoveNode, pTargetNode) & Command_TargetIsChildNode(pMoveNode, pTargetNode);
        }

        /// <summary>
        /// �ж�Ŀ��ڵ��Ƿ�ΪԴ�ڵ���ӽڵ�����䱾��
        /// </summary>
        /// <param name="pMoveNode">Դ�ڵ�</param>
        /// <param name="pTargetNode">Ŀ��ڵ�</param>
        /// <returns>bool</returns>
        private bool Command_TargetIsChildNode(TreeNodeEx pMoveNode, TreeNodeEx pTargetNode) {
            if (pMoveNode == pTargetNode) {
                return false;
            }
            if (null == pTargetNode.Parent) {
                return true;
            }
            if (Command_TargetIsChildNode(pMoveNode, pTargetNode.Parent as TreeNodeEx)) {
                return true;
            } else {
                return false;
            }
        }

        /// <summary>
        /// �ж�Ŀ��ڵ��Ƿ�ΪԴ�ڵ��ֱ�Ӹ��ڵ�
        /// </summary>
        /// <param name="pMoveNode">Դ�ڵ�</param>
        /// <param name="pTargetNode">Ŀ��ڵ�</param>
        /// <returns>bool</returns>
        bool Command_TargetIsDirectParentNode(TreeNodeEx pMoveNode, TreeNodeEx pTargetNode) {
            if (Command_IsSelectRoot(pMoveNode)) {
                return false;
            } else {
                return pMoveNode.Parent != pTargetNode;
            }
        }

        /// <summary>
        /// �жϵ�ǰ�ڵ�ĸ����Ƿ��ܼ�����ǰ��չ
        /// <remarks>
        /// ���ܵ�ԭ��:����ͬ���ڵ��������ýڵ�������ͬ
        /// </remarks>
        /// </summary>
        /// <param name="pTitle">����</param>
        /// <param name="pNode">�ڵ�</param>
        /// <returns>bool</returns>
        bool Command_NodeCanChange(string pTitle, TreeNodeEx pNode) {
            if (Command_IsSelectRoot(pNode)) {
                foreach (TreeNode tNode in this.treeView1.Nodes) {
                    if (tNode != pNode) {
                        if (tNode.Text == pTitle) {
                            return false;
                        }
                    }
                }
            } else {
                foreach (TreeNode tNode in pNode.Parent.Nodes) {
                    if (tNode != pNode) {
                        if (tNode.Text == pTitle) {
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// �жϵ�ǰ�ڵ�ĸ����Ƿ��ܼ�����ǰ��չ
        /// <remarks>
        /// ���ܵ�ԭ��:�ýڵ�ģ�岻���ڻ��߲��Ǳ�׼��ģ��
        /// </remarks>
        /// </summary>
        /// <param name="pFilePath">pFilePath</param>
        /// <param name="pExamplePath">pExamplePath</param>
        /// <returns>bool</returns>
        bool Command_NodeCanChange(string pFilePath, string pExamplePath) {
            byte[] tCellByte = {67,0,101,0,108,0,108,0,53,0,49 };//Cell�ļ��ı�ͷǰ10���ֽ�("C e l l 5 1")
            /**************************************
             * �����ļ�·��Ϊ��,��·����Ϊ��ʱ�ж���
             * ·���Ƿ�Ϊ��Ч��Cell�ļ�
             *************************************/
            if (Globals.CellPath != pFilePath.Trim()){
                if (File.Exists(pFilePath)) {
                    byte[] tFileBuffer = File.ReadAllBytes(pFilePath);
                    for (int tBufferNum = 0; tBufferNum < tCellByte.Length; tBufferNum++) {
                        if (tFileBuffer.GetValue(tBufferNum).ToString() != tCellByte.GetValue(tBufferNum).ToString()) {
                            return false;
                        }
                    }
                } else {
                    return false;
                }
            }
            if (Globals.CellPath != pExamplePath.Trim()) {
                if (File.Exists(pExamplePath)) {
                    byte[] tFileBuffer = File.ReadAllBytes(pExamplePath);
                    for (int tBufferNum = 0; tBufferNum < tCellByte.Length; tBufferNum++) {
                        if (tFileBuffer.GetValue(tBufferNum).ToString() != tCellByte.GetValue(tBufferNum).ToString()) {
                            return false;
                        }
                    }
                } else {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// ���µ�ǰĿ¼
        /// </summary>
        private void Command_UpdateFile(TreeNodeEx pNode) {

            if (TreesData.CheckSameTableName(Functions.ToSqlString(txtTableName.Text.Trim()) , Globals.OpenedProjectNo, pNode.Name))
            {
                Functions.ShowWarning("����Ŀ¼�����ظ�");
                return;
            }


            if (this.isTitleChanged) {//��������и���
                if (Command_NodeCanChange(this.txtTitle.Text.Trim(), pNode)) {//�����������ı�
                    string tOldPath = pNode.FullPath;//����ǰ·��
                    pNode.Text = this.txtTitle.Text;//���º�·��
                    TreesData.UpdateFileTreePath(pNode.Name, tOldPath, pNode.FullPath);//����Ŀ¼·���Լ�����Ŀ¼���ļ���·��
                } else {
                    MessageBox.Show("��ͬ���ڵ��д�����֮������ͬ�Ľڵ�", "����", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            if (this.isGclxChange) {//����������ͷ����˱仯
                IList<DigiPower.ERM.Model.wjssgclx> tWjssgclxs = new List<DigiPower.ERM.Model.wjssgclx>();
                for (int tGclxNum = 0; tGclxNum < this.clbGclx.Items.Count; tGclxNum++) {
                    if (this.clbGclx.GetItemChecked(tGclxNum)) {
                        DigiPower.ERM.Model.wjssgclx tWjssgclx = new DigiPower.ERM.Model.wjssgclx();
                        tWjssgclx.id = pNode.Name;
                        tWjssgclx.PTreePath = pNode.Parent.FullPath;
                        tWjssgclx.ProjectName = (this.clbGclx.Items[tGclxNum] as DataRowView)[0].ToString();
                        tWjssgclx.ProjectCode = (this.clbGclx.Items[tGclxNum] as DataRowView)[2].ToString();
                        tWjssgclxs.Add(tWjssgclx);
                    }
                }
                TreesData.UpdateWjssgclx(tWjssgclxs, pNode.Name);
            }
            Command_SetFile(pNode);
            B_FileRecording_Templet.Update(pNode.Tag as DigiPower.ERM.Model.FileRecording_Templet);
            this.Operator_SetFile(pNode);
        }

        /// <summary>
        /// ���µ�ǰģ��
        /// </summary>
        private void Command_UpdateModel(TreeNodeEx pNode) {
            if (this.isTitleChanged) {//��������и���
                if (Command_NodeCanChange(this.txtTitle.Text.Trim(), pNode)) {//�����������ı�
                    pNode.Text = this.txtTitle.Text;//���º�·��
                } else {
                    MessageBox.Show("��ͬ���ڵ��д�����֮������ͬ�Ľڵ�", "����", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            if (this.isFilePathChanged) {//ģ��·���и���
                if (Command_NodeCanChange(Globals.CellPath + this.txtFilepath.Text.Trim(), Globals.CellPath + this.txtExamplePath.Text.Trim())) {//���ģ�����
                } else {
                    MessageBox.Show("�ýڵ�ģ�岻���ڻ��߲��Ǳ�׼��ģ��", "����", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            Command_SetModel(pNode);
            this.B_Cell_Templet.Update(pNode.Tag as DigiPower.ERM.Model.Cell_Templet);
            this.Operator_SetModel(pNode);
        }

        /// <summary>
        /// �жϸýڵ��Check���Ըı��Ƿ񲻴�����Ӧ���¼�
        /// </summary>
        bool isNonExcuteTreeCheckedEvent = false;

        /// <summary>
        /// ���¸�ȫ�����ڵ�Ŀɼ���
        /// </summary>
        /// <param name="pChecked">Ҫ�ı��ѡ��״̬</param>
        /// <param name="pNode">���ڵ�</param>
        private void Command_UpdateParentVisible(TreeNodeEx pNode,bool pChecked) {
            this.isNonExcuteTreeCheckedEvent = true;//��������Ӧ���¼�
            if (!this.Command_IsSelectRoot(pNode)) {//������Ǹ��ڵ�
                TreeNodeEx tParentNode = pNode.Parent as TreeNodeEx;
                if (tParentNode.Checked != pChecked) {//������ڵ�Ŀɼ����������Ĳ�һ��,�޸�
                    TreesData.UpdateFileVisibleNonByChild(tParentNode.Name, pChecked);
                    tParentNode.Checked = pChecked;
                    DigiPower.ERM.Model.FileRecording_Templet fileTag = tParentNode.Tag as DigiPower.ERM.Model.FileRecording_Templet;
                    fileTag.isvisible = pChecked ? 1 : 0;
                    //tParentNode.Tag = fileTag;
                    Command_UpdateParentVisible(tParentNode, pChecked);
                }
            }
            this.isNonExcuteTreeCheckedEvent = false;
        }
        #endregion

        #region �¼�
        void pSaveStaus_End(ESaveASynStatus sender) {
            this.lbSave.Text = "�ѱ���";
        }

        void pSaveStaus_Enter(ESaveASynStatus sender, bool e) {
            if (!e) {//�������༭״̬
                this.lbSave.Text = "���ڱ༭";
            } else {
                this.Command_SaveCatalog(treeView1.SelectedNode as TreeNodeEx);
                this.isTitleChanged = false;
                this.isFilePathChanged = false;
                this.isGclxChange = false;
                this.lbSave.Text = "�ѱ���";
            }
        }

        private void frmStandard_Load(object sender, EventArgs e) {
            //����treeview1Ϊ����
            this.ActiveControl = treeView1;

            //���� [�������]
            panelSearch.Visible = false;

            //��鰴ť�ɲ�����
            this.CheckEnable();
        }


        private void frmStandard_FormClosed(object sender, FormClosedEventArgs e) {
            this._parentForm.Show();
            this._parentForm.Activate();
        }

        #region FileDialog �¼�
        //�������ļ�
        private void btnExplorer_Click(object sender, EventArgs e) {
            openFileDialog1.Filter = "�����ļ�|*.cll|�����ļ�|*.*";
            openFileDialog1.FileName = "";
            openFileDialog1.InitialDirectory = Globals.CellPath;

            DialogResult ret = openFileDialog1.ShowDialog();
            if (ret == DialogResult.OK) {
                if (!openFileDialog1.FileName.ToLower().Contains(Globals.CellPath.ToLower())) {
                    Functions.ShowWarning("�������õĵ��ӱ��Ŀ¼��ָ���ļ���");
                    return;
                }
                txtFilepath.Text = Functions.Replace(openFileDialog1.FileName, Globals.CellPath, "");



                //�����ļ��Զ����Ͻڵ�����������¼��
                string tmpcodeno = "";
                string tmptitle = Functions.GetFileShortName(openFileDialog1.FileName);
                tmptitle = Functions.Left(tmptitle, tmptitle.Length - 4);
                if (tmptitle.Contains("#")) {
                    string[] str = tmptitle.Split('#');
                    tmptitle = str[1];
                    tmpcodeno = str[0];
                }
                if (txtTitle.Text == "") {
                    txtTitle.Text = tmptitle;
                    if (tmpcodeno != "")
                        txtTitle.Text += "(" + tmpcodeno + ")";
                }
                if (txtCodeno.Text == "")
                    txtCodeno.Text = tmpcodeno;
            }

        }

        //�������ļ�
        private void btnExplorer2_Click(object sender, EventArgs e) {
            openFileDialog1.Filter = "�����ļ�|*.cll|�����ļ�|*.*";
            openFileDialog1.FileName = "";
            openFileDialog1.InitialDirectory = Globals.CellPath;

            DialogResult ret = openFileDialog1.ShowDialog();
            if (ret == DialogResult.OK) {
                if (!openFileDialog1.FileName.ToLower().Contains(Globals.CellPath.ToLower())) {
                    Functions.ShowWarning("�������õĵ��ӱ��Ŀ¼��ָ���ļ���");
                    return;
                }
                txtExamplePath.Text = Functions.Replace(openFileDialog1.FileName, Globals.CellPath, "");
            }
        }
        #endregion


        #region �༭���
        private void btnEdit_Click(object sender, EventArgs e) {
            if (txtFilepath.Text.Trim() == "" || !File.Exists(Globals.CellPath + txtFilepath.Text.Trim())) return;

            this.Cursor = Cursors.WaitCursor;

            frmCellEdit frm = new frmCellEdit(Globals.CellPath + txtFilepath.Text.Trim());

            this.Cursor = Cursors.Default;

            frm.Show();
        }

        private void btnEdit2_Click(object sender, EventArgs e) {
            if (txtExamplePath.Text.Trim() == "" || !File.Exists(Globals.CellPath + txtExamplePath.Text.Trim())) return;

            this.Cursor = Cursors.WaitCursor;

            frmCellEdit frm = new frmCellEdit(Globals.CellPath + txtExamplePath.Text.Trim());

            this.Cursor = Cursors.Default;

            frm.Show();
        }

        #endregion

        private void TextBox_TextChanged(object sender, EventArgs e) {
            if (!this.isReadModel) {
                this.pSaveStaus.Edit(ESaveASynStatus.Catalog);
                if (sender is TextBox && sender == this.txtTitle) {
                    if (this.txtTitle.Text.Trim() != this.treeView1.SelectedNode.Text) {
                        isTitleChanged = true;
                    } else {
                        isTitleChanged = false;
                    }
                }
                if (sender is TextBox && sender == this.txtFilepath || sender == this.txtExamplePath) {
                    isFilePathChanged = true;
                }
            }
            //--------------------------------------------
            //��2008-12-10��������,����ѡ��ı�����Ͳ�ͬ
            //�ض��Էֲ�,�ӷֲ���������ʾ������ͬ
            //--------------------------------------------
            if (sender == this.cboJdlb) {
                Operator_ChangeCodeType();
            }
        }

        bool isGclxChange = false;
        private void clbGclx_SelectedIndexChanged(object sender, EventArgs e) {
            if (!this.isReadModel) {
                this.pSaveStaus.Edit(ESaveASynStatus.Catalog);
                this.isGclxChange = true;
            }
        }

        private void treeView1_BeforeSelect(object sender, TreeViewCancelEventArgs e) {
            if (!this.pSaveStaus.IsAllSave()) {
                DialogResult result = MessageBox.Show("�Ƿ񱣴浱ǰ�޸ĵ�����", "������ʾ", MessageBoxButtons.YesNoCancel);
                if (result == DialogResult.Yes) {
                    this.pSaveStaus.Save(ESaveASynStatus.Catalog);
                } else if (result == DialogResult.No) {
                    this.pSaveStaus.Finish();
                } else if (result == DialogResult.Cancel) {
                    e.Cancel = true;
                }
            }
        }

        private void treeView1_BeforeExpand(object sender, TreeViewCancelEventArgs e) {
            this.Cursor = Cursors.WaitCursor;


            //�ҵ�ѡ���Ľڵ�
            TreeNodeEx theNode = (TreeNodeEx)e.Node;
            if (theNode == null) return;
            if (theNode.IsFirstExpand == false) {
                this.Cursor = Cursors.Default;
                return;
            }
            if (theNode.ImageIndex == 1) {
                Command_RefreshNode(theNode);
            }

            this.Cursor = Cursors.Default;

        }
        //�ڵ�ѡ�����������¼�
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e) {
            this.isReadModel = true;
            TreeNodeEx theNode = (TreeNodeEx)e.Node; //ѡ�еĽڵ�

            if (this.Command_IsSelectRoot(theNode)) {
            } else if (this.Command_IsSelectFile(theNode)) {
                cpRecord.Visible = true;
                cpTable.Visible = false;
                Operator_GetFile(theNode);
            } else {
                cpTable.Visible = true;
                cpRecord.Visible = false;
                Operator_GetModel(theNode);
            }
            this.isReadModel = false;
            //��ť�ɲ����Լ��
            //this.CheckEnable();
        }

        /// <summary>
        /// �жϿ�ѡ���Ӧ�Ľڵ��Ƿ�Ϊ������Ľڵ�
        /// <remarks>
        /// ��ֹ��Ƕ�׵������ظ��������ݿ�
        /// </remarks>
        /// </summary>
        bool isMouseClickNode = true;
        private void treeView1_AfterCheck(object sender, TreeViewEventArgs e) {
            if (!this.isNonExcuteTreeCheckedEvent) {//����������¼�
                TreeNodeEx pNode = e.Node as TreeNodeEx;
                if (this.isMouseClickNode) {//�����ǰ�ڵ�Ϊ��ǰ������Ľڵ�
                    if (this.Command_IsSelectModel(pNode)) {
                        DigiPower.ERM.Model.Cell_Templet nodeTag = pNode.Tag as DigiPower.ERM.Model.Cell_Templet;
                        nodeTag.isvisible = pNode.Checked ? 1 : 0;
                        TreesData.UpdateModelVisible(pNode.Name, pNode.Checked);
                    } else {
                        DigiPower.ERM.Model.FileRecording_Templet nodeTag = pNode.Tag as DigiPower.ERM.Model.FileRecording_Templet;
                        nodeTag.isvisible = pNode.Checked ? 1 : 0;
                        TreesData.UpdateFileVisible(pNode.Name, pNode.Checked);
                    }
                    if (pNode.Checked) {//�����ǰ�ڵ���ѡ�е�״̬,ʹ��ȫ�����ڵ�Ҳ��ʾѡ�е�״̬
                        this.Command_UpdateParentVisible(pNode, pNode.Checked);
                    }
                }
                treeView1.BeginUpdate();
                foreach (TreeNodeEx tNode in pNode.Nodes) {//ʹ��ǰ�ڵ���ֽڵ��ѡ��״̬��ýڵ���ͬ
                    this.isMouseClickNode = false;
                    tNode.Checked = pNode.Checked;
                    if(Command_IsSelectModel(tNode))
                    {
                        DigiPower.ERM.Model.Cell_Templet cellTag= tNode.Tag as DigiPower.ERM.Model.Cell_Templet;
                        cellTag.isvisible = pNode.Checked ? 1 : 0;
                    }
                    else if (Command_IsSelectFile(tNode))
                    {
                        DigiPower.ERM.Model.FileRecording_Templet fileTag = tNode.Tag as DigiPower.ERM.Model.FileRecording_Templet;
                        fileTag.isvisible = pNode.Checked ? 1 : 0;
                    }
                    //tNode.Tag = fileTag;
                    this.isMouseClickNode = true;
                }
                treeView1.EndUpdate();
            }
        }

        //�ڵ��ػ�
        private void treeView1_DrawNode(object sender, DrawTreeNodeEventArgs e) {
            Font nodeFont = ((TreeView)(sender)).Font;  //����

            //����ѡȡ�ڵ�ı���ɫ
            if ((e.State & TreeNodeStates.Selected) != 0) {
                e.Graphics.FillRectangle(Brushes.RoyalBlue, e.Node.Bounds);  //����
                e.Graphics.DrawString(e.Node.Text, nodeFont, Brushes.White, e.Bounds.Left, e.Bounds.Top + 4);  //ǰ������
            } else {
                e.Graphics.DrawString(e.Node.Text, nodeFont, Brushes.Black, e.Bounds.Left, e.Bounds.Top + 4);  //ǰ������
            }
        }

        //�Ҽ�����ڵ��ֱ�ӽ���ѡ��
        private void treeView1_MouseDown(object sender, MouseEventArgs e) {
            // �������ʹ�����ǰ�������Ҽ�...
            if (e.Button == MouseButtons.Right) {
                // ȡ����걻���µ�λ�á�
                Point p = new Point(e.X, e.Y);

                // ȡ�ñ�ʹ����������Ҽ����µĽڵ㡣
                TreeNode theNode = treeView1.GetNodeAt(p);

                // �����걻����֮���Ƿ������һ���ڵ㡣
                if (theNode != null) {
                    // ѡȡ��ʹ����������Ҽ����µĽڵ㡣
                    treeView1.SelectedNode = theNode;
                }
            }
        }

        TreeNode moveNode;

        //Դ�ڵ��Ϸŵ�treeview1�ؼ����������¼�
        private void treeView1_DragEnter(object sender, DragEventArgs e) {
            if (e.Data.GetDataPresent("Digi.B.TreeNodeEx"))
            {
                e.Effect = DragDropEffects.Move;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        //�ϷŲ������ʱ�¼�
        private void treeView1_DragDrop(object sender, DragEventArgs e) {
            Command_TreeViewDragDrop(sender,e);
        }

        private void treeView1_DragOver(object sender, DragEventArgs e) {
            Operator_TreeViewDragOver(sender, e);
        }

        private void treeView1_ItemDrag(object sender, ItemDragEventArgs e) {
            if (e.Button == MouseButtons.Left)
            {
                DoDragDrop((TreeNodeEx)e.Item, DragDropEffects.Move);

            }
        }

        #region �������¼�
        //չ��
        private void t1_ExpandAll_Click(object sender, EventArgs e) {
            this.Cursor = Cursors.WaitCursor;

            treeView1.BeginUpdate();
            if (null != this.treeView1.SelectedNode) {
                treeFactory.RefreshNode((TreeNodeEx)treeView1.SelectedNode, "", "", true, "digipower", true);
                treeView1.SelectedNode.ExpandAll();
                //Operator_AllExpand(this.treeView1.SelectedNode as TreeNodeEx);
            } else {
                //treeFactory.RefreshNode((TreeNodeEx)treeView1.Nodes[0], "", "", true, "digipower", true);
                treeView1.Nodes[0].ExpandAll();
                //Operator_AllExpand(this.treeView1.Nodes[0] as TreeNodeEx);
            }
            treeView1.Nodes[0].EnsureVisible();
            treeView1.EndUpdate();
            this.Cursor = Cursors.Default;
        }


        //�۵�
        private void t1_CollapseAll_Click(object sender, EventArgs e) {
            if (null != this.treeView1.SelectedNode) {
                this.treeView1.SelectedNode.Collapse();
            } else {
                treeView1.CollapseAll();
            }
        }

        //����
        private void t1_Find_Click(object sender, EventArgs e) {
            if (panelSearch.Visible) {
                panelSearch.Visible = false;
            } else {
                txtSearchCodeno.Text = "";
                txtSearchTitle.Text = "";
                btnSearchConfirm.Enabled = false;
                btnSearchConfirm.Tag = "0";
                txtSearchTitle.Focus();
                panelSearch.Visible = true;
            }

        }


        //��һ��
        private void t1_Prev_Click(object sender, EventArgs e) {
            treeFactory.SelectPrevNode(treeView1);
        }

        //��һ��
        private void t1_Next_Click(object sender, EventArgs e) {
            treeFactory.SelectNextNode(treeView1);
        }


        //ɾ��
        private void t1_Del_Click(object sender, EventArgs e) {
            if (MessageBox.Show("�Ƿ�ɾ��<" + this.treeView1.SelectedNode.Text+ ">�ڵ㼰���ӽڵ���Ϣ", "�ڵ�ɾ������", MessageBoxButtons.YesNo) == DialogResult.Yes) {
                this.DelNode(this.treeView1.SelectedNode as TreeNodeEx);
            }
        }


        //����ģ��
        private void t1_AddTemplet_Click(object sender, EventArgs e) {
            //this.AddTemplet();
        }


        //����(Ĭ��"������Ŀ¼")
        private void t1_New_ButtonClick(object sender, EventArgs e) {
            if (null != this.treeView1.SelectedNode.Parent)
                this.NewFloder(true, this.treeView1.SelectedNode as TreeNodeEx);
        }

        private void MenuAddBrotherModel_Click(object sender, EventArgs e) {
            if (null != this.treeView1.SelectedNode.Parent)
                this.NewTable(false, this.treeView1.SelectedNode as TreeNodeEx);
        }

        private void MenuAddChildModel_Click(object sender, EventArgs e) {
            if (null != this.treeView1.SelectedNode.Parent)
                if (!this.Command_IsSelectModel(this.treeView1.SelectedNode as TreeNodeEx))
                    this.NewTable(true, this.treeView1.SelectedNode as TreeNodeEx);
        }

        private void tsmiAddBrotherModel_Click(object sender, EventArgs e) {
            if (null != this.treeView1.SelectedNode.Parent)
                this.NewTable(false, this.treeView1.SelectedNode as TreeNodeEx);
        }

        private void tsmiAddChildModel_Click(object sender, EventArgs e) {
            if (null != this.treeView1.SelectedNode.Parent)
                if (!this.Command_IsSelectModel(this.treeView1.SelectedNode as TreeNodeEx))
                    this.NewTable(true, this.treeView1.SelectedNode as TreeNodeEx);
        }

        //������Ŀ¼
        private void MenuAddNodeChild_Click(object sender, EventArgs e) {
            if (null != this.treeView1.SelectedNode.Parent)
                this.NewFloder(true, this.treeView1.SelectedNode as TreeNodeEx);
        }

        //����ͬ��Ŀ¼
        private void MenuAddNodeBrother_Click(object sender, EventArgs e) {
            if (null != this.treeView1.SelectedNode.Parent)
                this.NewFloder(false, this.treeView1.SelectedNode as TreeNodeEx);
        }

        //�������ڵ�
        private void MenuAddRoot_Click(object sender, EventArgs e) {
            this.NewRoot();
        }
        #endregion


        #region TreeView1 ���ݲ˵��ĸ����¼�
        //�������ڵ�
        private void tsmiNewRoot_Click(object sender, EventArgs e) {
            this.NewRoot();
        }
        //����ͬ���ڵ�
        private void tsmiNewChildNode_Click(object sender, EventArgs e) {
            if (null != this.treeView1.SelectedNode.Parent)
                this.NewFloder(true, this.treeView1.SelectedNode as TreeNodeEx);
        }

        //�����ӽڵ�
        private void tsmiNewBrotherNode_Click(object sender, EventArgs e) {
            if (null != this.treeView1.SelectedNode.Parent)
                this.NewFloder(false, this.treeView1.SelectedNode as TreeNodeEx);
        }

        //ɾ���ڵ�
        private void tsmiDelNode_Click(object sender, EventArgs e) {
            if (MessageBox.Show("�Ƿ�ɾ��<" + this.treeView1.SelectedNode.Text + ">�ڵ㼰���ӽڵ���Ϣ", "�ڵ�ɾ������", MessageBoxButtons.YesNo) == DialogResult.Yes) {
                this.DelNode(this.treeView1.SelectedNode as TreeNodeEx);
            }
        }

        //����ģ��
        private void tsmiAddTemplet_Click(object sender, EventArgs e) {
            //this.AddTemplet();
        }

        #region [���ҽڵ�]�ľ��崦����
        //ȡ������
        private void btnSearchCancel_Click(object sender, EventArgs e) {
            panelSearch.Visible = false;
        }

        //����
        private void btnSearchConfirm_Click(object sender, EventArgs e) {
            //�������ж�
            if (txtSearchTitle.Text.Trim() == "" && txtSearchCodeno.Text.Trim() == "") {
                txtSearchTitle.Focus();
                return;
            }


            //����
            //this.Cursor = Cursors.WaitCursor;

            //string sql = "select nodeid from " + this._tableName + " where nodeid>" + btnSearchConfirm.Tag;
            //if (txtSearchCodeno.Text.Trim() != "")
            //    sql += " and codeno like '%" + Functions.ToSqlString(txtSearchCodeno.Text) + "%'";
            //if (txtSearchTitle.Text.Trim() != "")
            //    sql += " and title like '%" + Functions.ToSqlString(txtSearchTitle.Text) + "%'";
            //object obj = DBFunc.ExecuteScalar(sql);

            //if (obj == null)
            //{
            //    btnSearchConfirm.Tag = "0";
            //    Functions.ShowInfo("û���ҵ�������ϣ�");
            //}
            //else
            //{
            //    btnSearchConfirm.Tag = ((int)obj).ToString();
            //    treeFactory.SelectNode(treeView1, btnSearchConfirm.Tag.ToString());
            //}
            //this.Cursor = Cursors.Default;

        }


        //TextChanged
        private void txtSearchTitle_TextChanged(object sender, EventArgs e) {
            this.DoTextChange();
        }

        //TextChanged
        private void txtSearchCodeno_TextChanged(object sender, EventArgs e) {
            this.DoTextChange();
        }

        //����
        private void btnSave_Click(object sender, EventArgs e) {
            this.pSaveStaus.Save(ESaveASynStatus.Catalog);
        }

        #endregion

        private void MenuUpNode_Click(object sender, EventArgs e) {
            this.Command_NodeUp(this.treeView1.SelectedNode as TreeNodeEx);
        }
        #endregion

        private void MenuDownNode_Click(object sender, EventArgs e) {
            this.Command_NodeDown(this.treeView1.SelectedNode as TreeNodeEx);
        }

        private void btnExport_Click(object sender, EventArgs e) {
            frmExpData tfrmExpData = new frmExpData(this.treeView1.Nodes[0] as TreeNodeEx);
            tfrmExpData.ShowDialog();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e) {
            Operator_ContextMenuOpening(this.treeView1.SelectedNode as TreeNodeEx);
        }

        #endregion

    }
}


