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
                TXMessageBoxExtensions.Info("������ڷǷ��ַ�,\r\n���ܰ���" + ConfigurationManager.AppSettings["isMatchCode"].ToString() + "��������ţ�");
                return;
            }

            if (!String.IsNullOrEmpty(this.txtReName.Text))
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                TXMessageBoxExtensions.Info("ģ�����Ʋ���Ϊ�գ�");
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
        /// ��������ģ��ʵ��
        /// </summary>
        /// <param name="FileNode"></param>
        /// <returns></returns>
        /// <summary>
        /// ���ýڵ�ΨһID
        /// </summary>
        /// <param name="FileNode"></param>
        /// <param name="NewNode"></param>
    }
}
