using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Digi.B
{
    public partial class Form1 : Form
    {
        private TreeFactory treeFactory = new TreeFactory();
        public Form1()
        {
            InitializeComponent();
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
                treeFactory.RefreshNode(theNode, "", "", true, "", false);
            }

            theNode.IsFirstExpand = false;

            this.Cursor = Cursors.Default;
        }

        private void button1_Click(object sender, EventArgs e) {
            treeFactory.GetTree(treeView1, "", "", true, "", false);
        }
    }
}