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
        /// 父节点 用来判断同一节点下名称不能相同
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
                Functions.ShowInfo("请输入名称！");
                txtTitle.Focus();
                return;
            }
            if (FilterChars.HasFilterChars(txtTitle.Text))
            {
                Functions.ShowWarning("不能包含有" + FilterChars.Chars2String() + "等字符！");
                txtTitle.Focus();
                return;
            }
            if (treesData.CheckSameTitle(TheNode.Name, Functions.ToSqlString(txtTitle.Text), Globals.ProjectNO,"",true))
            {
                Functions.ShowInfo("同一节点下表格名称不可相同！");
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
