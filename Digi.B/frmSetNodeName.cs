using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DigiPower.ERM.CBLL;

namespace Digi.B
{
    public partial class frmSetNodeName : Form
    {
        string strType = null;

        TreeNode NewNode = new TreeNode();

        TreeView tree = null;

        TreesData td = new TreesData();


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
            #region
            //if (!String.IsNullOrEmpty(this.txtNodeName.Text) && !String.IsNullOrEmpty(this.strType))
            //{
            //    switch (strType.ToUpper().Trim())
            //    {
            //        case "同级目录":
            //            {
            //                TreeNode tNode = new TreeNode(this.txtNodeName.Text);

            //                tNode.ImageIndex = 1;

            //                tNode.SelectedImageIndex = 1;

            //                NewNode.Parent.Nodes.Add(tNode);

            //                DataSet ds = td.GetNewFileRecording_TempletID(NewNode.Parent.FullPath);

            //                string NewID = "0101";

            //                if(ds!=null && ds.Tables[0].Rows.Count>0)
            //                {
            //                    long Flag = Convert.ToInt64(ds.Tables[0].Rows[0]["id"].ToString())+1;

            //                    NewID = "0" + Flag.ToString();
            //                }

            //                tree.SelectedNode = tNode;

            //                NewNode.Parent.Expand();

            //                td.InsertNewFileRecording_Templet(NewNode.Parent.FullPath, tNode.FullPath, "kongbai", this.txtNodeName.Text, NewID);
            //            }
                        
            //            break;

            //        case "子目录":
            //            {
            //                TreeNode tNode = new TreeNode(this.txtNodeName.Text);

            //                tNode.ImageIndex = 1;

            //                tNode.SelectedImageIndex = 1;

            //                DataSet ds = td.GetNewFileRecording_TempletID(NewNode.FullPath);

            //                string NewID = "0101";

            //                if (ds != null && ds.Tables[0].Rows.Count > 0)
            //                {
            //                    long Flag = Convert.ToInt64(ds.Tables[0].Rows[0]["id"].ToString()) + 1;

            //                    NewID = "0" + Flag.ToString();
            //                }
            //                else
            //                {
            //                    NewID = NewNode.Name + "01";
            //                }


            //                tNode.Name = NewID.ToString();

            //                NewNode.Nodes.Add(tNode);

            //                td.InsertNewFileRecording_Templet(NewNode.FullPath, NewNode.FullPath + "\\" + this.txtNodeName.Text, "kongbai", this.txtNodeName.Text, NewID);

            //                //刷新节点
            //                //TreeNodeEx tNewFolder = new TreeNodeEx();
            //                //tNewFolder.Name = NewID;         //节点唯一ID,用来检索
            //                //tNewFolder.Text = this.txtNodeName.Text;          //标题
            //                //NewNode.Nodes.Add(tNewFolder);
            //                //tNewFolder.ImageIndex = 1;
            //                //tNewFolder.SelectedImageIndex = 1;

            //                TreeFactory treefactory = new TreeFactory();

            //                treefactory.RefreshFileNode(NewNode, true, "digipower", true, false, RegistEnum.FULL);


            //                NewNode.Expand();

            //                //选中新节点
            //                this.tree.SelectedNode = tNode;

            //                this.Cursor = Cursors.Default;
            //            }

            //            break;

            //        case "根目录":
            //            {
            //                TreeNode node = new TreeNode();

            //                node.Name = "01";

            //                node.Text = this.txtNodeName.Text;

            //                node.ImageIndex = 1;

            //                node.SelectedImageIndex = 1;

            //                this.tree.Nodes.Add(node);

            //                td.InsertNewFileRecording_Templet("", node.FullPath, "", node.Text, "01");
            //            }

            //            break;
                       
            //    }
            //}

            //this.Close();
            #endregion
            if (this.txtNodeName.Text.Trim() == "")
                return;
            this.DialogResult = DialogResult.OK;
        }

        private void btnConsle_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}