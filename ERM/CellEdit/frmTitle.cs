using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ERM.Common;
namespace ERM.UI
{
    public partial class frmTitle : Form
    {
        TreeNodeEx TheNode;
        /// <summary>
        /// ���ڵ� �����ж�ͬһ�ڵ������Ʋ�����ͬ
        /// </summary>
        /// <param name="_theNode"></param>
        public frmTitle(TreeNodeEx _theNode)
        {
            InitializeComponent();
            TheNode = _theNode;
        }
        ERM.CBLL.CellTreesData treesData = new ERM.CBLL.CellTreesData();
        private void btnOK_Click_1(object sender, EventArgs e)
        {
            txtTitle.Text = txtTitle.Text.Trim();
            if (txtTitle.Text == "")
            {
                Functions.ShowInfo("���������ƣ�");
                txtTitle.Focus();
                return;
            }
            if (FilterChars.HasFilterChars(txtTitle.Text))
            {
                Functions.ShowWarning("���ܰ�����" + FilterChars.Chars2String() + "���ַ���");
                txtTitle.Focus();
                return;
            }
            if (treesData.CheckSameTitle(TheNode.Name, Functions.ToSqlString(txtTitle.Text), Globals.ProjectNO,"",true))
            {
                Functions.ShowInfo("ͬһ�ڵ��±�����Ʋ�����ͬ��");
                txtTitle.Focus();
                return;
            }
            this.DialogResult = DialogResult.OK;
        }
        public string Title
        {
            get { return txtTitle.Text; }
            set { txtTitle.Text = value; }
        }
    }
}
