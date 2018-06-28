namespace Digi.B
{
    partial class frmNewCellEdit
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNewCellEdit));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.toolStandard = new Digi.B.MyToolStrip();
            this.t1_ExpandAll = new System.Windows.Forms.ToolStripButton();
            this.t1_CollapseAll = new System.Windows.Forms.ToolStripButton();
            this.t1_Find = new System.Windows.Forms.ToolStripButton();
            this.t1_Prev = new System.Windows.Forms.ToolStripButton();
            this.t1_Next = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.t1_New = new System.Windows.Forms.ToolStripSplitButton();
            this.MenuAddRoot = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuAddNodeBrother = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuAddNodeChild = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuAddBrotherModel = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuAddChildModel = new System.Windows.Forms.ToolStripMenuItem();
            this.t1_Del = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuUpNode = new System.Windows.Forms.ToolStripButton();
            this.MenuDownNode = new System.Windows.Forms.ToolStripButton();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.listView1 = new System.Windows.Forms.ListView();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.toolStandard.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panel6);
            this.splitContainer1.Size = new System.Drawing.Size(512, 429);
            this.splitContainer1.SplitterDistance = 260;
            this.splitContainer1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(260, 429);
            this.panel1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.treeView1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 29);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(260, 400);
            this.panel3.TabIndex = 1;
            // 
            // treeView1
            // 
            this.treeView1.AllowDrop = true;
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(260, 400);
            this.treeView1.TabIndex = 0;
            this.treeView1.DragDrop += new System.Windows.Forms.DragEventHandler(this.treeView1_DragDrop);
            this.treeView1.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeView1_BeforeExpand);
            this.treeView1.DragOver += new System.Windows.Forms.DragEventHandler(this.treeView1_DragOver);
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            this.treeView1.DragEnter += new System.Windows.Forms.DragEventHandler(this.treeView1_DragEnter);
            this.treeView1.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.treeView1_ItemDrag);
            this.treeView1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.treeView1_MouseDown);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.toolStandard);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(260, 29);
            this.panel2.TabIndex = 0;
            // 
            // toolStandard
            // 
            this.toolStandard.BackColor = System.Drawing.Color.Transparent;
            this.toolStandard.CanOverflow = false;
            this.toolStandard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStandard.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStandard.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.t1_ExpandAll,
            this.t1_CollapseAll,
            this.t1_Find,
            this.t1_Prev,
            this.t1_Next,
            this.toolStripSeparator2,
            this.t1_New,
            this.t1_Del,
            this.toolStripSeparator3,
            this.MenuUpNode,
            this.MenuDownNode});
            this.toolStandard.Location = new System.Drawing.Point(0, 0);
            this.toolStandard.Name = "toolStandard";
            this.toolStandard.Padding = new System.Windows.Forms.Padding(0);
            this.toolStandard.Size = new System.Drawing.Size(260, 29);
            this.toolStandard.TabIndex = 7;
            this.toolStandard.Text = "myToolStrip1";
            // 
            // t1_ExpandAll
            // 
            this.t1_ExpandAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.t1_ExpandAll.Image = global::Digi.B.Properties.Resources.img_expand;
            this.t1_ExpandAll.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.t1_ExpandAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.t1_ExpandAll.Margin = new System.Windows.Forms.Padding(0, 1, 2, 2);
            this.t1_ExpandAll.Name = "t1_ExpandAll";
            this.t1_ExpandAll.Size = new System.Drawing.Size(23, 26);
            this.t1_ExpandAll.Text = "展开项目";
            this.t1_ExpandAll.Click += new System.EventHandler(this.t1_ExpandAll_Click);
            // 
            // t1_CollapseAll
            // 
            this.t1_CollapseAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.t1_CollapseAll.Image = global::Digi.B.Properties.Resources.img_collapse;
            this.t1_CollapseAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.t1_CollapseAll.Margin = new System.Windows.Forms.Padding(0, 1, 2, 2);
            this.t1_CollapseAll.Name = "t1_CollapseAll";
            this.t1_CollapseAll.Size = new System.Drawing.Size(23, 26);
            this.t1_CollapseAll.Text = "折叠项目";
            this.t1_CollapseAll.Click += new System.EventHandler(this.t1_CollapseAll_Click);
            // 
            // t1_Find
            // 
            this.t1_Find.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.t1_Find.Image = global::Digi.B.Properties.Resources.img_search;
            this.t1_Find.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.t1_Find.Margin = new System.Windows.Forms.Padding(0, 1, 2, 2);
            this.t1_Find.Name = "t1_Find";
            this.t1_Find.Size = new System.Drawing.Size(23, 26);
            this.t1_Find.Text = "查找";
            this.t1_Find.Visible = false;
            // 
            // t1_Prev
            // 
            this.t1_Prev.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.t1_Prev.Image = global::Digi.B.Properties.Resources.img_prev;
            this.t1_Prev.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.t1_Prev.Margin = new System.Windows.Forms.Padding(0, 1, 2, 2);
            this.t1_Prev.Name = "t1_Prev";
            this.t1_Prev.Size = new System.Drawing.Size(23, 26);
            this.t1_Prev.Text = "上一条";
            this.t1_Prev.Click += new System.EventHandler(this.t1_Prev_Click);
            // 
            // t1_Next
            // 
            this.t1_Next.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.t1_Next.Image = global::Digi.B.Properties.Resources.img_next;
            this.t1_Next.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.t1_Next.Margin = new System.Windows.Forms.Padding(0, 1, 2, 2);
            this.t1_Next.Name = "t1_Next";
            this.t1_Next.Size = new System.Drawing.Size(23, 26);
            this.t1_Next.Text = "下一条";
            this.t1_Next.Click += new System.EventHandler(this.t1_Next_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 29);
            // 
            // t1_New
            // 
            this.t1_New.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.t1_New.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuAddRoot,
            this.MenuAddNodeBrother,
            this.MenuAddNodeChild,
            this.MenuAddBrotherModel,
            this.MenuAddChildModel});
            this.t1_New.Image = global::Digi.B.Properties.Resources.img_NewFolder;
            this.t1_New.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.t1_New.Name = "t1_New";
            this.t1_New.Size = new System.Drawing.Size(32, 26);
            this.t1_New.Text = "新建";
            // 
            // MenuAddRoot
            // 
            this.MenuAddRoot.Name = "MenuAddRoot";
            this.MenuAddRoot.Size = new System.Drawing.Size(142, 22);
            this.MenuAddRoot.Text = "新增根目录";
            this.MenuAddRoot.Click += new System.EventHandler(this.MenuAddRoot_Click);
            // 
            // MenuAddNodeBrother
            // 
            this.MenuAddNodeBrother.Name = "MenuAddNodeBrother";
            this.MenuAddNodeBrother.Size = new System.Drawing.Size(142, 22);
            this.MenuAddNodeBrother.Text = "新增同级目录";
            this.MenuAddNodeBrother.Click += new System.EventHandler(this.MenuAddNodeBrother_Click);
            // 
            // MenuAddNodeChild
            // 
            this.MenuAddNodeChild.Name = "MenuAddNodeChild";
            this.MenuAddNodeChild.Size = new System.Drawing.Size(142, 22);
            this.MenuAddNodeChild.Text = "新增子目录";
            this.MenuAddNodeChild.Click += new System.EventHandler(this.MenuAddNodeChild_Click);
            // 
            // MenuAddBrotherModel
            // 
            this.MenuAddBrotherModel.Name = "MenuAddBrotherModel";
            this.MenuAddBrotherModel.Size = new System.Drawing.Size(142, 22);
            this.MenuAddBrotherModel.Text = "新增同级模板";
            this.MenuAddBrotherModel.Visible = false;
            this.MenuAddBrotherModel.Click += new System.EventHandler(this.MenuAddBrotherModel_Click);
            // 
            // MenuAddChildModel
            // 
            this.MenuAddChildModel.Name = "MenuAddChildModel";
            this.MenuAddChildModel.Size = new System.Drawing.Size(142, 22);
            this.MenuAddChildModel.Text = "新增子模板";
            this.MenuAddChildModel.Visible = false;
            // 
            // t1_Del
            // 
            this.t1_Del.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.t1_Del.Image = global::Digi.B.Properties.Resources.img_del;
            this.t1_Del.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.t1_Del.Margin = new System.Windows.Forms.Padding(0, 1, 2, 2);
            this.t1_Del.Name = "t1_Del";
            this.t1_Del.Size = new System.Drawing.Size(23, 26);
            this.t1_Del.Text = "删除";
            this.t1_Del.Click += new System.EventHandler(this.t1_Del_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 29);
            // 
            // MenuUpNode
            // 
            this.MenuUpNode.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.MenuUpNode.Image = global::Digi.B.Properties.Resources.t1_Up;
            this.MenuUpNode.ImageTransparentColor = System.Drawing.Color.White;
            this.MenuUpNode.Name = "MenuUpNode";
            this.MenuUpNode.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.MenuUpNode.Size = new System.Drawing.Size(23, 26);
            this.MenuUpNode.Text = "节点上移";
            this.MenuUpNode.Visible = false;
            // 
            // MenuDownNode
            // 
            this.MenuDownNode.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.MenuDownNode.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.MenuDownNode.Image = global::Digi.B.Properties.Resources.t1_Down;
            this.MenuDownNode.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.MenuDownNode.Name = "MenuDownNode";
            this.MenuDownNode.Size = new System.Drawing.Size(23, 26);
            this.MenuDownNode.Text = "节点下移";
            this.MenuDownNode.Visible = false;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.panel5);
            this.panel6.Controls.Add(this.panel4);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(248, 429);
            this.panel6.TabIndex = 2;
            // 
            // panel5
            // 
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(248, 29);
            this.panel5.TabIndex = 1;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.listView1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Margin = new System.Windows.Forms.Padding(3, 29, 3, 3);
            this.panel4.Name = "panel4";
            this.panel4.Padding = new System.Windows.Forms.Padding(0, 29, 0, 0);
            this.panel4.Size = new System.Drawing.Size(248, 429);
            this.panel4.TabIndex = 0;
            // 
            // listView1
            // 
            this.listView1.Alignment = System.Windows.Forms.ListViewAlignment.Left;
            this.listView1.AllowDrop = true;
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.Location = new System.Drawing.Point(0, 29);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(248, 400);
            this.listView1.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.listView1.TabIndex = 1;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.listView1_ItemDrag);
            this.listView1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseDown);
            // 
            // frmNewCellEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(512, 429);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmNewCellEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "表格维护";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmNewCellEdit_FormClosing);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.toolStandard.ResumeLayout(false);
            this.toolStandard.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Panel panel2;
        private MyToolStrip toolStandard;
        private System.Windows.Forms.ToolStripButton t1_ExpandAll;
        private System.Windows.Forms.ToolStripButton t1_CollapseAll;
        private System.Windows.Forms.ToolStripButton t1_Find;
        private System.Windows.Forms.ToolStripButton t1_Prev;
        private System.Windows.Forms.ToolStripButton t1_Next;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSplitButton t1_New;
        private System.Windows.Forms.ToolStripMenuItem MenuAddRoot;
        private System.Windows.Forms.ToolStripMenuItem MenuAddNodeBrother;
        private System.Windows.Forms.ToolStripMenuItem MenuAddNodeChild;
        private System.Windows.Forms.ToolStripMenuItem MenuAddBrotherModel;
        private System.Windows.Forms.ToolStripMenuItem MenuAddChildModel;
        private System.Windows.Forms.ToolStripButton t1_Del;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton MenuUpNode;
        private System.Windows.Forms.ToolStripButton MenuDownNode;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.ListView listView1;
    }
}