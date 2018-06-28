using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ERM.Common;
using TX.Framework.WindowUI.Forms;
using System.Configuration;
namespace ERM.UI
{
    public partial class frmAddTemplet : ERM.UI.Controls.Skin_DevEX
    {
        Form _parentForm;
        ITreeFactory treeFactory;

        public frmAddTemplet(TreeNodeEx Node, Form ParentForm, ITreeFactory Itree, bool fileOrFlord_flg)
        {
            InitializeComponent();
            _parentForm = ParentForm;
            treeFactory = Itree;
            checkBox1.Checked = fileOrFlord_flg;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!MyCommon.IsMatchCode(this.txtReName.Text))
            {
                TXMessageBoxExtensions.Info("输入存在非法字符,\r\n不能包括" + ConfigurationManager.AppSettings["isMatchCode"].ToString() + "等特殊符号！");
                return;
            }

            if (!String.IsNullOrEmpty(this.txtReName.Text))
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                TXMessageBoxExtensions.Info("模版名称不能为空！");
                return;
            }
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {

        }

        private void btnExit_Click_1(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 设置新增模版实体
        /// </summary>
        /// <param name="FileNode"></param>
        /// <returns></returns>
        /// <summary>
        /// 设置节点唯一ID
        /// </summary>
        /// <param name="FileNode"></param>
        /// <param name="NewNode"></param>
    }
}
