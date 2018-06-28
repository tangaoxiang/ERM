using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ERM.Common;
using System.IO;
using TX.Framework.WindowUI.Forms;
namespace ERM.UI
{
    public partial class frmCellNameEdit : ERM.UI.Controls.Skin_DevEX
    {
        private TreeNodeEx theNode;//当前节点
        ERM.CBLL.CellTreesData treesData = new ERM.CBLL.CellTreesData();
        private TreeNodeEx PNode;//父节点
        /// <summary>
        /// 对frmMain窗体中树的节点属性进行修改
        /// </summary>
        /// <param name="frm"></param>
        public frmCellNameEdit(TreeNodeEx node, TreeNodeEx _pNode)
        {
            InitializeComponent();
            this.theNode = node;
            this.PNode = _pNode;
            txtTitle.Text = theNode.Text;
        }
        private void frmMainEdit_Load(object sender, EventArgs e)
        {
        }
        private void btnExplorer_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "表格文件(*.cll)|*.cll";
            openFileDialog1.FileName = "";
            openFileDialog1.InitialDirectory = "C:";
            DialogResult ret = openFileDialog1.ShowDialog();
            if (ret == DialogResult.OK)
            {
                if (openFileDialog1.FileName.ToLower().Contains(Globals.CellPath.ToLower()) || openFileDialog1.FileName.ToLower().Contains(Globals.ProjectPath.ToLower()))
                {
                    TXMessageBoxExtensions.Info("请在存放模板及电子文件的文件夹外浏览文件，以上目录用来保存上传的文件！");
                    return;
                }
                txtFilePath.Text = openFileDialog1.FileName;
            }
        }
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (txtTitle.Text.Trim() == "") return;
            if (MyCommon.HasFilterChars(txtTitle.Text))
            {
                TXMessageBoxExtensions.Info("不能包含有" + MyCommon.Chars2String() + "等字符！");
                txtTitle.Focus();
                return;
            }
            this.DialogResult = DialogResult.OK;
        }

        private void btnConfirm_Click_1(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
