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
        private TreeNodeEx theNode;//��ǰ�ڵ�
        ERM.CBLL.CellTreesData treesData = new ERM.CBLL.CellTreesData();
        private TreeNodeEx PNode;//���ڵ�
        /// <summary>
        /// ��frmMain���������Ľڵ����Խ����޸�
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
            openFileDialog1.Filter = "����ļ�(*.cll)|*.cll";
            openFileDialog1.FileName = "";
            openFileDialog1.InitialDirectory = "C:";
            DialogResult ret = openFileDialog1.ShowDialog();
            if (ret == DialogResult.OK)
            {
                if (openFileDialog1.FileName.ToLower().Contains(Globals.CellPath.ToLower()) || openFileDialog1.FileName.ToLower().Contains(Globals.ProjectPath.ToLower()))
                {
                    TXMessageBoxExtensions.Info("���ڴ��ģ�弰�����ļ����ļ���������ļ�������Ŀ¼���������ϴ����ļ���");
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
                TXMessageBoxExtensions.Info("���ܰ�����" + MyCommon.Chars2String() + "���ַ���");
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
