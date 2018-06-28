using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
namespace ERM.UI
{
    public partial class frmFileList : Form
    {
        public frmFileList()
        {
            InitializeComponent();
        }
        private Form _parentForm;
        public frmFileList(Form parentForm)
        {
            InitializeComponent();
            this._parentForm = parentForm;
        }
        private void tsAdd_Click(object sender, EventArgs e)
        {
        }
        private void frmFileList_FormClosing(object sender, FormClosingEventArgs e)
        {
            this._parentForm.Show();　//显示父窗体
            this._parentForm.Activate();//激活父窗体
        }
    }
}
