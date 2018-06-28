/*******************************
 * 作者:梁健铭(程序编写),刘长伦(美工)
 * 时间:2008下半年
 * 目的:电子归档后台管理工具
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
        #region 变量与属性
        //实例化树的访问类
        private TreeFactory treeFactory = new TreeFactory();

        const string CPROJECTNO = "digipower";

        DigiPower.ERM.BLL.FileRecording_Templet B_FileRecording_Templet = new DigiPower.ERM.BLL.FileRecording_Templet();

        DigiPower.ERM.BLL.Cell_Templet B_Cell_Templet = new DigiPower.ERM.BLL.Cell_Templet();

        DigiPower.ERM.Model.FileRecording_Templet M_FileRecording_Templet;

        DigiPower.ERM.Model.Cell_Templet M_Cell_Templet;

        SaveASynStatus pSaveStaus = new SaveASynStatus();

        /// <summary>
        /// 判断是否正在读取目录或者模版数据
        /// </summary>
        bool isReadModel = true;

        bool isTitleChanged = false;

        bool isFilePathChanged = false;

        //        //父窗口
        private Form _parentForm;
        #endregion

        #region 构造函数
        public frmStandard(Form parentForm) {
            InitializeComponent();
            pSaveStaus.Enter += new SaveASynStatus.EnterHandle(pSaveStaus_Enter);
            pSaveStaus.End += new SaveASynStatus.EndHandle(pSaveStaus_End);

            cpRecord.Dock = DockStyle.Fill;
            cpTable.Dock = DockStyle.Fill;
            //            //构造函数赋值
            //            this.Text = title;
            //            this._isArchiveTable = isArchiveTable;
            //            this._tableName = tableName;
            //            this._standardTableForArchive = standardTableForArchive;
            this._parentForm = parentForm;

            BindingCombox();

            //加载树
            treeFactory.GetTree(treeView1, "", "", true, "", false);

        }
        #endregion

        #region 操作函数
        private void BindingCombox() {
            //创建用于 TreeView 的 ImageList
            ImageList imageList1 = treeFactory.CreateTreeImageList();
            treeView1.ImageList = imageList1;

            //图标索引
            cboImageIndex.ImageList = imageList1;
            cboImageIndex.DropDownStyle = ComboBoxStyle.DropDownList;
            cboImageIndex.Items.Add(new ComboBoxExItem("根节点", 0));
            cboImageIndex.Items.Add(new ComboBoxExItem("文件夹", 1));
            cboImageIndex.Items.Add(new ComboBoxExItem("表格", 2));
            cboImageIndex.SelectedIndex = 0;

            cboSjdw.DataSource = new string[] { "", "短期", "长期", "永久" };
            cboSgdw.DataSource = new string[] { "","短期", "长期", "永久" };
            cboJldw.DataSource = new string[] { "", "短期", "长期", "永久" };
            cboJsdw.DataSource = new string[] { "","短期", "长期", "永久" };

            //string[] items2 = new string[] { "需要提交", "不需要提交" };
            cboCjdag.Items.Add("需要提交");
            cboCjdag.Items.Add("不需要提交");

            //string[] items3 = new string[] { "绝密", "机密", "秘密" };
            cboWjmj.Items.Add("");
            cboWjmj.Items.Add("绝密");
            cboWjmj.Items.Add("机密");
            cboWjmj.Items.Add("秘密");

            DigiPower.ERM.BLL.gclbbm gclb = new DigiPower.ERM.BLL.gclbbm();
            DataSet ds = gclb.GetAllList();
            clbGclx.DataSource = ds.Tables[0];
            clbGclx.ValueMember = "gclbbm";
            clbGclx.DisplayMember = "flmc";

            cbofbmc.DataSource = TreesData.GetDistinctFbmc();
            cbozfbmc.DataSource = TreesData.GetDistinctZfbmc();
            //--------------------------------------------
            //根据指示原先的责任人由选择无端的变成定死的
            //--------------------------------------------
            //cboUnit.DataSource = TreesData.GetDistinctUnitType();
        }

        /// <summary>
        /// 按钮及菜单能否点击的判断
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


            if (treeView1.Nodes.Count == 0)  //树上没有任何节点
            {
                MenuAddRoot.Enabled = true;
                tsmiNewRoot.Enabled = true;
            } else //树上有节点
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

                TreeNode node = treeView1.SelectedNode;  //选中的节点
                if (node != null)  //如果有选中的节点
                {
                    t1_Del.Enabled = true;
                    tsmiDelNode.Enabled = true;

                    if (node.Level != 0) //不是根节点
                    {
                        MenuAddNodeBrother.Enabled = true;
                        tsmiNewBrotherNode.Enabled = true;
                    }
                }
            }
        }

        /// <summary>
        /// 当表型改变时,对应的分部,子分部与分项的显示改变
        /// </summary>
        private void Operator_ChangeCodeType() {
            switch (cboJdlb.SelectedIndex) {
                case 0://分部
                    this.cbofbmc.Enabled = true;
                    this.cbozfbmc.Text = ""; this.cbozfbmc.Enabled = false;
                    this.txtfxmc.Text = ""; this.txtfxmc.Enabled = false;
                    break;
                case 1://分项
                    this.cbofbmc.Enabled = true;
                    this.cbozfbmc.Enabled = true;
                    this.txtfxmc.Enabled = true;
                    break;
                case 2://检验批
                    this.cbofbmc.Text = ""; this.cbofbmc.Enabled = false;
                    this.cbozfbmc.Text = ""; this.cbozfbmc.Enabled = false;
                    this.txtfxmc.Text = ""; this.txtfxmc.Enabled = false;
                    break;
                case 3://施工
                    this.cbofbmc.Text = ""; this.cbofbmc.Enabled = false;
                    this.cbozfbmc.Text = ""; this.cbozfbmc.Enabled = false;
                    this.txtfxmc.Text = ""; this.txtfxmc.Enabled = false;
                    break;
                case 4://子分部
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
        /// 对右击节点弹出菜单进行控制
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
        /// 在文本框中显示文件信息
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

            cboCjdag.Text = M_FileRecording_Templet.cjdag == "1" ? "需要提交" : "不需要提交";//数字与名称的转换
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
        /// 在文本框中显示模版信息
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
        /// 将该节点上移
        /// </summary>
        /// <param name="pNode">节点</param>
        /// <param name="pCount">上移的位数</param>
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
        /// 将显示的目录信息保存到树节点中
        /// </summary>
        /// <param name="theNode">TreeNodeEx</param>
        private void Operator_SetFile(TreeNodeEx theNode) {
            theNode.Text = txtTitle.Text;
        }

        /// <summary>
        /// 将文本框中的模版信息保存到树节点中
        /// </summary>
        /// <param name="theNode">TreeNodeEx</param>
        private void Operator_SetModel(TreeNodeEx theNode) {
            theNode.Text = txtTitle.Text;
            theNode.NodeValue = txtFilepath.Text;
            theNode.NodeKey = txtCodeno.Text;
        }

        /// <summary>
        /// 树节点拖放结束时的操作
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
        /// 树节点拖放时经过另一节点时操作
        /// </summary>
        /// <param name="sender">TreeView</param>
        /// <param name="e">DragEventArgs</param>
        private void Operator_TreeViewDragOver(object sender, DragEventArgs e) {
            Point pt = ((TreeView)(sender)).PointToClient(new Point(e.X, e.Y));
            TreeNode targeNode = this.treeView1.GetNodeAt(pt);
            this.treeView1.SelectedNode = targeNode;
        }

        /// <summary>
        /// 树节点拖动开始时操作
        /// </summary>
        /// <param name="e">ItemDragEventArgs</param>
        private void Operator_TreeViewItemDrag(ItemDragEventArgs e) {
            moveNode = e.Item as TreeNode;
            DoDragDrop(e.Item, DragDropEffects.Move);
        }

        /// <summary>
        /// 将该节点下移
        /// </summary>
        /// <param name="pNode">节点</param>
        /// <param name="pCount">上移的位数</param>
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
        /// 展开当前节点下的全部子节点
        /// </summary>
        /// <param name="pNode">当前节点</param>
        void Operator_AllExpand(TreeNodeEx pNode) {
            if (!this.Command_IsSelectModel(pNode)) {
                pNode.Expand();
                Application.DoEvents();
                foreach (TreeNodeEx tNode in pNode.Nodes) {
                    Operator_AllExpand(tNode);
                }
            }
        }

        #region 节点新增、删除、移动的具体方法
        /// <summary>
        /// 新增根节点
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
        /// 新增模板
        /// </summary>
        private void NewTable(bool ChildNode, TreeNodeEx theNode) {
            try {
                if (theNode == null) return;

                this.Cursor = Cursors.WaitCursor;


                //找到父节点
                TreeNodeEx parentNode;
                if (!ChildNode)//如果是同级目录
                    parentNode = (TreeNodeEx)theNode.Parent;
                else {
                    parentNode = theNode;
                    Command_RefreshNode(parentNode);
                }
                TreesData treesData = new TreesData();
                string NodeID = treesData.GetNextNodeID(parentNode.Name, CPROJECTNO);

                int orderindex = treesData.GetNextIndex(parentNode.Name, CPROJECTNO);

                if (!this.Command_InLoneRange(orderindex)) {//如果该顺序号超过了最大长整型的范围Pow(2,31)-1,按照当前节点顺序重新生成连续的顺序号
                    orderindex = this.Command_BuildSeriersModelOrderindex(parentNode)+1;
                }

                string ParentID = parentNode.Name;

                string Title = "<新增模板>"+orderindex.ToString();

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

                //刷新节点
                //treeView1.DrawMode = TreeViewDrawMode.Normal;
                //treeFactory.RefreshNode(parentNode, "", "", true, "", false);
                TreeNodeEx tNewTable = new TreeNodeEx();
                tNewTable.Name = cellMode.id;         //节点唯一ID,用来检索
                tNewTable.Text = cellMode.title;          //标题
                tNewTable.Tag = cellMode; //是否最后一个节点,范例路径,是否用户定义表格,附件
                tNewTable.Checked = cellMode.isvisible == 1 ? true : false;//是否可见
                tNewTable.NodeKey = "";
                tNewTable.NodeValue = "";
                parentNode.Nodes.Add(tNewTable);
                tNewTable.ImageIndex = 2;
                tNewTable.SelectedImageIndex = 2;
                this.treeView1.Refresh();
                //treeView1.DrawMode = TreeViewDrawMode.OwnerDrawText;

                //选中新节点
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
        /// 新增节点
        /// </summary>
        /// <param name="ChildNode">新增同级目录还是子节点</param>
        private void NewFloder(bool ChildNode, TreeNodeEx theNode) {
            try {
                if (theNode == null) return;

                //找到父节点
                TreeNodeEx parentNode;
                if (!ChildNode)//如果是同级目录
                    parentNode = (TreeNodeEx)theNode.Parent;
                else {
                    parentNode = theNode;
                    Command_RefreshNode(parentNode);
                }


                //开始
                this.Cursor = Cursors.WaitCursor;



                //需要保存的数据内容收集
                TreesData treesData = new TreesData();
                string NodeID = treesData.GetNextNodeID(parentNode.Name, CPROJECTNO);

                int orderindex = treesData.GetNextIndex(parentNode.Name, CPROJECTNO);

                if (!this.Command_InLoneRange(orderindex)) {//如果该顺序号超过了最大长整型的范围Pow(2,31)-1,按照当前节点顺序重新生成连续的顺序号
                    orderindex = this.Command_BuildSeriersFileOrderindex(parentNode)+1;
                }
                string Title = "<新建节点>"+orderindex.ToString();

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
                fileModel.zrr = this.txtZdz.Text;//登陆用户

                this.B_FileRecording_Templet.Add(fileModel);


                //刷新节点
                //treeView1.DrawMode = TreeViewDrawMode.Normal;

                //treeFactory.RefreshNode(parentNode, "", "", true, "", false);
                TreeNodeEx tNewFolder = new TreeNodeEx();
                tNewFolder.Name = fileModel.id;         //节点唯一ID,用来检索
                tNewFolder.Text = fileModel.gdwj;          //标题
                tNewFolder.Tag = fileModel; //是否最后一个节点,范例路径,是否用户定义表格,附件
                tNewFolder.Checked = fileModel.isvisible == 1 ? true : false;//是否可见
                parentNode.Nodes.Add(tNewFolder);
                tNewFolder.ImageIndex = 1;
                tNewFolder.SelectedImageIndex = 1;
                this.treeView1.Refresh();

                //treeView1.DrawMode = TreeViewDrawMode.OwnerDrawText;

                //选中新节点
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
        /// 删除节点
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

            //DialogResult ret = Functions.ShowQuestion("确定删除 [" + theNode.Text + "] 及其子节点？");
            //if (ret == DialogResult.Yes)
            //{
            //    //使用公用类删除节点
            //    this.Cursor = Cursors.WaitCursor;

            //    treeFactory.DelNodes((TreeNodeEx)theNode, this._tableName, string.Empty);


            //    treeView1.DrawMode = TreeViewDrawMode.Normal;

            //    //刷新节点
            //    treeFactory.RefreshNode(parentNode, this._tableName, true, string.Empty);

            //    //选中节点
            //    treeFactory.SelectNode(parentNode);

            //    treeView1.DrawMode = TreeViewDrawMode.OwnerDrawText;

            //    //检查按钮的可操作性
            //    this.CheckEnable();

            //    this.Cursor = Cursors.Default;
            //}
        }

        #endregion
        #endregion

        #region 命令函数

        /// <summary>
        /// 树节点拖动时改变相应数据库的记录
        /// <remarks>
        /// 路径,编号
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
            if (moveNode2.Parent != targetNode.Parent)//不是同一个父的不允许拖
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
            if (this.Command_CanDrag(moveNode as TreeNodeEx, targetNode as TreeNodeEx)) {//如果目标节点符合要求
                if (Command_IsSelectFile(this.moveNode as TreeNodeEx)) {//判断是否选中目录
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
        /// 刷新当前节点
        /// <remarks>
        /// 1、如果该节点是第一次被展开,执行刷新方法
        /// </remarks>
        /// </summary>
        /// <param name="pNode">目标节点</param>
        private void Command_RefreshNode(TreeNodeEx pNode) {
            if (pNode.IsFirstExpand)
                treeFactory.RefreshNode(pNode, "", "", true, "", false);
            pNode.IsFirstExpand = false;
        }

        /// <summary>
        /// 获取当前用户输入的目录对象实例
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
        /// 将文件顺序号保存到节点上
        /// </summary>
        /// <param name="pNode">节点</param>
        /// <param name="pOrderindex">顺序号</param>
        void Command_SetFileOrderindex(TreeNodeEx pNode,string pOrderindex) {
            M_FileRecording_Templet = pNode.Tag as DigiPower.ERM.Model.FileRecording_Templet;
            M_FileRecording_Templet.orderindex = int.Parse(pOrderindex);
            M_FileRecording_Templet = null;
        }

        /// <summary>
        /// 获取当前文件节点的顺序号
        /// </summary>
        /// <param name="pNode">当前文件节点</param>
        /// <returns>顺序号</returns>
        string Command_GetFileOrderindex(TreeNodeEx pNode) {
            M_FileRecording_Templet = pNode.Tag as DigiPower.ERM.Model.FileRecording_Templet;
            string tOrderindex = M_FileRecording_Templet.orderindex.ToString();
            M_FileRecording_Templet = null;
            return tOrderindex;
        }

        /// <summary>
        /// 获取当前用户输入的模版对象实例
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
        /// 将模板顺序号保存到节点上
        /// </summary>
        /// <param name="pNode">节点</param>
        /// <param name="pOrderindex">顺序号</param>
        void Command_SetModelOrderindex(TreeNodeEx pNode, string pOrderindex) {
            M_Cell_Templet = pNode.Tag as DigiPower.ERM.Model.Cell_Templet;
            M_Cell_Templet.orderindex = int.Parse(pOrderindex);
            M_Cell_Templet = null;
        }

        /// <summary>
        /// 获取当前模板节点的顺序号
        /// </summary>
        /// <param name="pNode">当前模板节点</param>
        /// <returns>顺序号</returns>
        string Command_GetModelOrderindex(TreeNodeEx pNode) {
            M_Cell_Templet = pNode.Tag as DigiPower.ERM.Model.Cell_Templet;
            string tOrderindex = M_Cell_Templet.orderindex.ToString();
            M_Cell_Templet = null;
            return tOrderindex;
        }

        /// <summary>
        /// 是否超出长整型范围
        /// </summary>
        /// <param name="pMax">最大长整型</param>
        /// <returns>bool</returns>
        bool Command_InLoneRange(long pMax) {
            const long CLongMax = -2147483648;//最大长整型的范围Pow(2,31)-1,有符号的Pow(2,31)为-2147483648
            return pMax == CLongMax ? false : true;
        }

        /// <summary>
        /// 重置全部文件夹路径
        /// </summary>
        /// <param name="pNode">目录节点</param>
        protected virtual void Command_InitFileTreePath(TreeNodeEx pNode) {
            if (!Command_IsSelectModel(pNode) && "临时数据" != pNode.Text) {
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
        /// 将目录节点上的信息传递到对象模型中
        /// </summary>
        /// <param name="pNode"></param>
        void Command_FileNodeToModel(TreeNodeEx pNode) {
            M_FileRecording_Templet = pNode.Tag as DigiPower.ERM.Model.FileRecording_Templet;
        }

        /// <summary>
        /// 将模型节点上的信息传递到对象模型中
        /// </summary>
        /// <param name="pNode"></param>
        void Command_ModelNodeToModel(TreeNodeEx pNode) {
            M_Cell_Templet = pNode.Tag as DigiPower.ERM.Model.Cell_Templet;
        }

        //处理TextChanged
        private void DoTextChange() {
            btnSearchConfirm.Tag = "0";   //数据库中从第几个节点ID开始查找，用于查找下一个节点，查找内容更改后则为一个新查询
            if (txtSearchTitle.Text.Trim() == "" && txtSearchCodeno.Text.Trim() == "") {
                btnSearchConfirm.Enabled = false;
            } else {
                btnSearchConfirm.Enabled = true;
            }
        }

        /// <summary>
        /// 按照用户选择的类型进行更新保存
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
            ////刷新节点，选中节点
            ////
            //TreeNode[] nodes = treeView1.Nodes.Find(_parentID, true);
            //if (nodes != null && nodes.Length > 0)
            //    _parentNode = nodes[0];  //父节点
            //else
            //{
            //    if (treeView1.Nodes.Count == 0)  //没有一个节点，说明是刚刚新建根节点
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
            //treeFactory.RefreshNode((TreeNodeEx)_parentNode, this._tableName, true, string.Empty);  //刷新

            ////选中修改或新增的Node
            ////treeFactory.SelectNode((TreeNodeEx)_parentNode);  //选中
            //treeFactory.SelectNode(treeView1, _nodeID);

            //treeView1.DrawMode = TreeViewDrawMode.OwnerDrawText;


            //this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// 判断当前选中的节点是否为模版
        /// </summary>
        /// <returns>bool</returns>
        private bool Command_IsSelectModel(TreeNodeEx pNode) {
            return pNode.ImageIndex == 2;
        }

        /// <summary>
        /// 判断当前选中的节点是否为目录
        /// </summary>
        /// <returns>bool</returns>
        private bool Command_IsSelectFile(TreeNodeEx pNode) {
            return pNode.ImageIndex == 1;
        }

        /// <summary>
        /// 判断当前选中的节点是否为根节点
        /// </summary>
        /// <returns>bool</returns>
        private bool Command_IsSelectRoot(TreeNodeEx pNode) {
            return pNode.ImageIndex == 0;
        }

        /// <summary>
        ///　将节点的顺序号上调
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
                this.Operator_NodeUp(pNode as TreeNodeEx, 1);//上移一位
            }
        }

        /// <summary>
        /// 将节点的顺序号下调
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
                


                this.Operator_NodeDown(pNode as TreeNodeEx, 1);//上移一位
            }
        }

        /// <summary>
        /// 新增文件
        /// </summary>
        private void Command_AddFile(TreeNodeEx pNode) {
            Command_SetFile(pNode);
            B_FileRecording_Templet.Add(pNode.Tag as DigiPower.ERM.Model.FileRecording_Templet);
        }

        /// <summary>
        /// 新增模版
        /// </summary>
        private void Command_AddModel(TreeNodeEx pNode) {
            Command_SetModel(pNode);
            B_Cell_Templet.Add(pNode.Tag as DigiPower.ERM.Model.Cell_Templet);
        }

        /// <summary>
        /// 生成连续的文件顺序号
        /// </summary>
        /// <param name="pParentNode">父节点</param>
        /// <returns>返回生成的连续顺序号个数</returns>
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
        /// 生成连续的模板顺序号
        /// </summary>
        /// <param name="pParentNode">父节点</param>
        /// <returns>返回生成的连续顺序号个数</returns>
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
        /// 判断是否能将源节点移动到目标节点上
        /// </summary>
        /// <param name="pMoveNode">源节点</param>
        /// <param name="pTargetNode">目标节点</param>
        bool Command_CanDrag(TreeNodeEx pMoveNode, TreeNodeEx pTargetNode) {
            return Command_TargetIsDirectParentNode(pMoveNode, pTargetNode) & Command_TargetIsChildNode(pMoveNode, pTargetNode);
        }

        /// <summary>
        /// 判断目标节点是否为源节点的子节点或者其本身
        /// </summary>
        /// <param name="pMoveNode">源节点</param>
        /// <param name="pTargetNode">目标节点</param>
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
        /// 判断目标节点是否为源节点的直接父节点
        /// </summary>
        /// <param name="pMoveNode">源节点</param>
        /// <param name="pTargetNode">目标节点</param>
        /// <returns>bool</returns>
        bool Command_TargetIsDirectParentNode(TreeNodeEx pMoveNode, TreeNodeEx pTargetNode) {
            if (Command_IsSelectRoot(pMoveNode)) {
                return false;
            } else {
                return pMoveNode.Parent != pTargetNode;
            }
        }

        /// <summary>
        /// 判断当前节点的更改是否能继续向前发展
        /// <remarks>
        /// 不能的原因:存在同级节点的名称与该节点名称相同
        /// </remarks>
        /// </summary>
        /// <param name="pTitle">标题</param>
        /// <param name="pNode">节点</param>
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
        /// 判断当前节点的更改是否能继续向前发展
        /// <remarks>
        /// 不能的原因:该节点模板不存在或者不是标准的模板
        /// </remarks>
        /// </summary>
        /// <param name="pFilePath">pFilePath</param>
        /// <param name="pExamplePath">pExamplePath</param>
        /// <returns>bool</returns>
        bool Command_NodeCanChange(string pFilePath, string pExamplePath) {
            byte[] tCellByte = {67,0,101,0,108,0,108,0,53,0,49 };//Cell文件的表头前10个字节("C e l l 5 1")
            /**************************************
             * 允许文件路径为空,当路径不为空时判断其
             * 路径是否为有效的Cell文件
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
        /// 更新当前目录
        /// </summary>
        private void Command_UpdateFile(TreeNodeEx pNode) {

            if (TreesData.CheckSameTableName(Functions.ToSqlString(txtTableName.Text.Trim()) , Globals.OpenedProjectNo, pNode.Name))
            {
                Functions.ShowWarning("报送目录不能重复");
                return;
            }


            if (this.isTitleChanged) {//如果标题有更新
                if (Command_NodeCanChange(this.txtTitle.Text.Trim(), pNode)) {//如果标题允许改变
                    string tOldPath = pNode.FullPath;//更新前路径
                    pNode.Text = this.txtTitle.Text;//更新后路径
                    TreesData.UpdateFileTreePath(pNode.Name, tOldPath, pNode.FullPath);//更新目录路径以及其子目录和文件的路径
                } else {
                    MessageBox.Show("在同级节点中存在与之名称相同的节点", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            if (this.isGclxChange) {//如果工程类型发生了变化
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
        /// 更新当前模版
        /// </summary>
        private void Command_UpdateModel(TreeNodeEx pNode) {
            if (this.isTitleChanged) {//如果标题有更新
                if (Command_NodeCanChange(this.txtTitle.Text.Trim(), pNode)) {//如果标题允许改变
                    pNode.Text = this.txtTitle.Text;//更新后路径
                } else {
                    MessageBox.Show("在同级节点中存在与之名称相同的节点", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            if (this.isFilePathChanged) {//模板路径有更新
                if (Command_NodeCanChange(Globals.CellPath + this.txtFilepath.Text.Trim(), Globals.CellPath + this.txtExamplePath.Text.Trim())) {//如果模板存在
                } else {
                    MessageBox.Show("该节点模板不存在或者不是标准的模板", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            Command_SetModel(pNode);
            this.B_Cell_Templet.Update(pNode.Tag as DigiPower.ERM.Model.Cell_Templet);
            this.Operator_SetModel(pNode);
        }

        /// <summary>
        /// 判断该节点的Check属性改变是否不触发对应的事件
        /// </summary>
        bool isNonExcuteTreeCheckedEvent = false;

        /// <summary>
        /// 更新该全部父节点的可见性
        /// </summary>
        /// <param name="pChecked">要改变的选中状态</param>
        /// <param name="pNode">父节点</param>
        private void Command_UpdateParentVisible(TreeNodeEx pNode,bool pChecked) {
            this.isNonExcuteTreeCheckedEvent = true;//不触发对应的事件
            if (!this.Command_IsSelectRoot(pNode)) {//如果不是根节点
                TreeNodeEx tParentNode = pNode.Parent as TreeNodeEx;
                if (tParentNode.Checked != pChecked) {//如果父节点的可见性与期望的不一致,修改
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

        #region 事件
        void pSaveStaus_End(ESaveASynStatus sender) {
            this.lbSave.Text = "已保存";
        }

        void pSaveStaus_Enter(ESaveASynStatus sender, bool e) {
            if (!e) {//如果进入编辑状态
                this.lbSave.Text = "正在编辑";
            } else {
                this.Command_SaveCatalog(treeView1.SelectedNode as TreeNodeEx);
                this.isTitleChanged = false;
                this.isFilePathChanged = false;
                this.isGclxChange = false;
                this.lbSave.Text = "已保存";
            }
        }

        private void frmStandard_Load(object sender, EventArgs e) {
            //设置treeview1为焦点
            this.ActiveControl = treeView1;

            //隐藏 [查找面板]
            panelSearch.Visible = false;

            //检查按钮可操作性
            this.CheckEnable();
        }


        private void frmStandard_FormClosed(object sender, FormClosedEventArgs e) {
            this._parentForm.Show();
            this._parentForm.Activate();
        }

        #region FileDialog 事件
        //浏览表格文件
        private void btnExplorer_Click(object sender, EventArgs e) {
            openFileDialog1.Filter = "华表文件|*.cll|所有文件|*.*";
            openFileDialog1.FileName = "";
            openFileDialog1.InitialDirectory = Globals.CellPath;

            DialogResult ret = openFileDialog1.ShowDialog();
            if (ret == DialogResult.OK) {
                if (!openFileDialog1.FileName.ToLower().Contains(Globals.CellPath.ToLower())) {
                    Functions.ShowWarning("请在设置的电子表格目录下指定文件！");
                    return;
                }
                txtFilepath.Text = Functions.Replace(openFileDialog1.FileName, Globals.CellPath, "");



                //根据文件自动填上节点题名，方便录入
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

        //浏览表格文件
        private void btnExplorer2_Click(object sender, EventArgs e) {
            openFileDialog1.Filter = "华表文件|*.cll|所有文件|*.*";
            openFileDialog1.FileName = "";
            openFileDialog1.InitialDirectory = Globals.CellPath;

            DialogResult ret = openFileDialog1.ShowDialog();
            if (ret == DialogResult.OK) {
                if (!openFileDialog1.FileName.ToLower().Contains(Globals.CellPath.ToLower())) {
                    Functions.ShowWarning("请在设置的电子表格目录下指定文件！");
                    return;
                }
                txtExamplePath.Text = Functions.Replace(openFileDialog1.FileName, Globals.CellPath, "");
            }
        }
        #endregion


        #region 编辑表格
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
            //按2008-12-10汤所描述,根据选择的表格类型不同
            //重而对分部,子分部与分项的显示有所不同
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
                DialogResult result = MessageBox.Show("是否保存当前修改的内容", "保存提示", MessageBoxButtons.YesNoCancel);
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


            //找到选定的节点
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
        //节点选定后引发的事件
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e) {
            this.isReadModel = true;
            TreeNodeEx theNode = (TreeNodeEx)e.Node; //选中的节点

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
            //按钮可操作性检查
            //this.CheckEnable();
        }

        /// <summary>
        /// 判断可选框对应的节点是否为鼠标点击的节点
        /// <remarks>
        /// 防止在嵌套调用中重复连接数据库
        /// </remarks>
        /// </summary>
        bool isMouseClickNode = true;
        private void treeView1_AfterCheck(object sender, TreeViewEventArgs e) {
            if (!this.isNonExcuteTreeCheckedEvent) {//如果触发该事件
                TreeNodeEx pNode = e.Node as TreeNodeEx;
                if (this.isMouseClickNode) {//如果当前节点为当前鼠标点击的节点
                    if (this.Command_IsSelectModel(pNode)) {
                        DigiPower.ERM.Model.Cell_Templet nodeTag = pNode.Tag as DigiPower.ERM.Model.Cell_Templet;
                        nodeTag.isvisible = pNode.Checked ? 1 : 0;
                        TreesData.UpdateModelVisible(pNode.Name, pNode.Checked);
                    } else {
                        DigiPower.ERM.Model.FileRecording_Templet nodeTag = pNode.Tag as DigiPower.ERM.Model.FileRecording_Templet;
                        nodeTag.isvisible = pNode.Checked ? 1 : 0;
                        TreesData.UpdateFileVisible(pNode.Name, pNode.Checked);
                    }
                    if (pNode.Checked) {//如果当前节点是选中的状态,使该全部父节点也表示选中的状态
                        this.Command_UpdateParentVisible(pNode, pNode.Checked);
                    }
                }
                treeView1.BeginUpdate();
                foreach (TreeNodeEx tNode in pNode.Nodes) {//使当前节点的字节点的选中状态与该节点相同
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

        //节点重绘
        private void treeView1_DrawNode(object sender, DrawTreeNodeEventArgs e) {
            Font nodeFont = ((TreeView)(sender)).Font;  //字体

            //绘制选取节点的背景色
            if ((e.State & TreeNodeStates.Selected) != 0) {
                e.Graphics.FillRectangle(Brushes.RoyalBlue, e.Node.Bounds);  //背景
                e.Graphics.DrawString(e.Node.Text, nodeFont, Brushes.White, e.Bounds.Left, e.Bounds.Top + 4);  //前景文字
            } else {
                e.Graphics.DrawString(e.Node.Text, nodeFont, Brushes.Black, e.Bounds.Left, e.Bounds.Top + 4);  //前景文字
            }
        }

        //右键点击节点后直接将其选中
        private void treeView1_MouseDown(object sender, MouseEventArgs e) {
            // 如果侦测出使用者是按下鼠标右键...
            if (e.Button == MouseButtons.Right) {
                // 取得鼠标被按下的位置。
                Point p = new Point(e.X, e.Y);

                // 取得被使用者以鼠标右键按下的节点。
                TreeNode theNode = treeView1.GetNodeAt(p);

                // 检查鼠标被按下之处是否真的是一个节点。
                if (theNode != null) {
                    // 选取被使用者以鼠标右键按下的节点。
                    treeView1.SelectedNode = theNode;
                }
            }
        }

        TreeNode moveNode;

        //源节点拖放到treeview1控件上引发的事件
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

        //拖放操作完成时事件
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

        #region 工具条事件
        //展开
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


        //折叠
        private void t1_CollapseAll_Click(object sender, EventArgs e) {
            if (null != this.treeView1.SelectedNode) {
                this.treeView1.SelectedNode.Collapse();
            } else {
                treeView1.CollapseAll();
            }
        }

        //查找
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


        //上一条
        private void t1_Prev_Click(object sender, EventArgs e) {
            treeFactory.SelectPrevNode(treeView1);
        }

        //下一条
        private void t1_Next_Click(object sender, EventArgs e) {
            treeFactory.SelectNextNode(treeView1);
        }


        //删除
        private void t1_Del_Click(object sender, EventArgs e) {
            if (MessageBox.Show("是否删除<" + this.treeView1.SelectedNode.Text+ ">节点及其子节点信息", "节点删除警告", MessageBoxButtons.YesNo) == DialogResult.Yes) {
                this.DelNode(this.treeView1.SelectedNode as TreeNodeEx);
            }
        }


        //引用模板
        private void t1_AddTemplet_Click(object sender, EventArgs e) {
            //this.AddTemplet();
        }


        //新增(默认"新增子目录")
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

        //新增子目录
        private void MenuAddNodeChild_Click(object sender, EventArgs e) {
            if (null != this.treeView1.SelectedNode.Parent)
                this.NewFloder(true, this.treeView1.SelectedNode as TreeNodeEx);
        }

        //新增同级目录
        private void MenuAddNodeBrother_Click(object sender, EventArgs e) {
            if (null != this.treeView1.SelectedNode.Parent)
                this.NewFloder(false, this.treeView1.SelectedNode as TreeNodeEx);
        }

        //新增根节点
        private void MenuAddRoot_Click(object sender, EventArgs e) {
            this.NewRoot();
        }
        #endregion


        #region TreeView1 内容菜单的各项事件
        //新增根节点
        private void tsmiNewRoot_Click(object sender, EventArgs e) {
            this.NewRoot();
        }
        //新增同级节点
        private void tsmiNewChildNode_Click(object sender, EventArgs e) {
            if (null != this.treeView1.SelectedNode.Parent)
                this.NewFloder(true, this.treeView1.SelectedNode as TreeNodeEx);
        }

        //新增子节点
        private void tsmiNewBrotherNode_Click(object sender, EventArgs e) {
            if (null != this.treeView1.SelectedNode.Parent)
                this.NewFloder(false, this.treeView1.SelectedNode as TreeNodeEx);
        }

        //删除节点
        private void tsmiDelNode_Click(object sender, EventArgs e) {
            if (MessageBox.Show("是否删除<" + this.treeView1.SelectedNode.Text + ">节点及其子节点信息", "节点删除警告", MessageBoxButtons.YesNo) == DialogResult.Yes) {
                this.DelNode(this.treeView1.SelectedNode as TreeNodeEx);
            }
        }

        //引用模板
        private void tsmiAddTemplet_Click(object sender, EventArgs e) {
            //this.AddTemplet();
        }

        #region [查找节点]的具体处理方法
        //取消查找
        private void btnSearchCancel_Click(object sender, EventArgs e) {
            panelSearch.Visible = false;
        }

        //查找
        private void btnSearchConfirm_Click(object sender, EventArgs e) {
            //完整性判定
            if (txtSearchTitle.Text.Trim() == "" && txtSearchCodeno.Text.Trim() == "") {
                txtSearchTitle.Focus();
                return;
            }


            //检索
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
            //    Functions.ShowInfo("没有找到相关资料！");
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

        //保存
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


