using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ERM.CBLL;
namespace ERM.UI
{
    public partial class frmSetNodeName : ERM.UI.Controls.Skin_DevEX
    {
        string strType = null;
        TreeNode NewNode = new TreeNode();
        TreeView tree = null;
        CellTreesData td = new CellTreesData();
        public string GetNodeText
        {
            get { return this.txtNodeName.Text.Trim(); }
        }
        public frmSetNodeName(TreeNode node,string addtype,TreeView t)
        {
            InitializeComponent();
            NewNode = node;
            strType = addtype;
            tree = t;
        }
        private void frmSetNodeName_Load(object sender, EventArgs e)
        {
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.txtNodeName.Text.Trim() == "")
                return;
            this.DialogResult = DialogResult.OK;
        }
        private void btnConsle_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {

        }

        private void btnConsle_Click_1(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
