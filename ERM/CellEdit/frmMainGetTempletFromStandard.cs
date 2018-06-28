using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using ERM.Common;
using TX.Framework.WindowUI.Forms;
namespace ERM.UI
{
    public partial class frmMainGetTempletFromStandard : ERM.UI.Controls.Skin_DevEX
    {
        TreeNodeEx TheNode;//��ǰ�ڵ� û��ʱ�Ǹ�������ֵ��Treenodeex
        TreeNodeEx pNode;//���ڵ�
        ERM.CBLL.CellTreesData treesData = new ERM.CBLL.CellTreesData();
        private bool IsTemplet;//�Ƿ�Ϊ���
        /// </summary>
        /// <param name="node">�ӽڵ� ���������Ƿ�Ϊ����������ʱ���null��treenode</param>
        /// <param name="_istemplet">��ģ�廹��Ŀ¼��ģ����true</param>
        /// <param name="_pNode">���ڵ�</param>
        public frmMainGetTempletFromStandard(TreeNodeEx node, bool _istemplet, TreeNodeEx _pNode)
        {
            InitializeComponent();
            this.Cell1.Login("digipower", "11100101845", "1040-1145-0062-4005");
            this.Cell1.LocalizeControl(0x804);
            TheNode = node;
            pNode = _pNode;
            if (!_istemplet)
            {
                this.label1.Text = "�ڵ����ƣ�";
            }
            if (_istemplet && node == null)
            {
                this.customPanel2.Visible = true;
            }
            else
            {
                this.customPanel2.Visible = false;
                this.Size = new Size(this.Size.Width, 130);
            }
            if (node != null)
            {
                txtTitle.Text = node.Text.Remove(0, node.Text.IndexOf(']') + 1).Replace("*", "");
            }
            IsTemplet = _istemplet;
        }
        /// <summary>
        /// ���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExplorer_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = Globals.CellPath;
            openFileDialog1.Filter = "(*.cll)| *.cll";
            openFileDialog1.Title = "ѡ���Զ���ģ��";
            openFileDialog1.FileName = "";
            DialogResult ret = openFileDialog1.ShowDialog();
            if (ret == DialogResult.OK)
            {
                ;
                txtLocalPath.Text = openFileDialog1.FileName;
                string strPath = txtLocalPath.Text.ToLower();
                if (txtTitle.Text.Trim() == "")
                {
                    txtTitle.Text = Path.GetFileNameWithoutExtension(strPath);
                }
                if (strPath.StartsWith(Globals.CellPath.ToLower()))
                {
                    DataView dv = new ERM.BLL.T_CellAndEFile_BLL().GetList(" filepath='" + strPath.Remove(0, Globals.CellPath.Length) + "'").Tables[0].DefaultView;
                    if (dv.Count > 0)
                    {
                        //if (txtCodeno.Text.Trim() == "")
                        //    txtCodeno.Text = dv[0]["codeno"].ToString();
                    }
                }
                if (txtLocalPath.Text.Trim() != "")
                {
                    btnSure.Enabled = true;
                }
                else
                {
                    btnSure.Enabled = false;
                }
            }
        }
        /// <summary>
        /// ����ļ�ҳ��
        /// </summary>
        /// <returns></returns>
        private int GetPages()
        {
            int res = Cell1.OpenFile(txtLocalPath.Text, "");
            int pages = 0;
            if (res == 1)
            {
                for (int i = 0; i < Cell1.GetTotalSheets(); i++)
                {
                    if (Cell1.GetSheetLabel(i).Contains(Globals.Descriptive) == false)
                    {
                        pages += Cell1.PrintGetPages(i);
                    }
                }
            }
            Cell1.closefile();
            return pages;
        }
        private void btnSure_Click(object sender, EventArgs e)
        {
            if (txtTitle.Text.Trim() == "")
            {
                TXMessageBoxExtensions.Info("��������⣡");
                txtTitle.Focus();
                return;
            }
            if (MyCommon.HasFilterChars(txtTitle.Text))
            {
                TXMessageBoxExtensions.Info("���ܰ�����" + MyCommon.Chars2String() + "���ַ���");
                txtTitle.Focus();
                return;
            }
            if (TheNode == null)
            {
                if (IsTemplet)
                {
                    if (!System.IO.File.Exists(txtLocalPath.Text.Trim()))
                    {
                        TXMessageBoxExtensions.Info("�ļ������ڣ�");
                        btnExplorer.Focus();
                        return;
                    }
                    int pages = GetPages();
                    if (pages == 0)
                    {
                        TXMessageBoxExtensions.Info("�ļ���ʽ����ȷ��");
                        return;
                    }
                }
            }
            this.DialogResult = DialogResult.OK;
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
        private void frmMainGetTempletFromStandard_Load(object sender, EventArgs e)
        {
            this.ActiveControl = txtTitle;
        }
        public string StrTitle
        {
            get
            {
                return txtTitle.Text;
            }
            set
            {
                txtTitle.Text = value;
            }
        }

        private void btnExplorer_Click_1(object sender, EventArgs e)
        {

        }

        private void btnSure_Click_1(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {

        }
    }
}
