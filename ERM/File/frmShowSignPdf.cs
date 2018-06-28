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
    public partial class frmShowSignPdf : Form
    {
        string _FileName = null;
        public frmShowSignPdf(string FileName)
        {
            InitializeComponent();
            _FileName = FileName;
            SetSignature();
            if (!String.IsNullOrEmpty(_FileName))
            {
                this.axPDFReader1.WebClose();
                ShowPdf();
            }
        }
        private void ShowPdf()
        {
            axPDFReader1.ShowTools = 0;
            axPDFReader1.ShowMenus = 0;
            axPDFReader1.ShowSigns = 0;
            axPDFReader1.ShowMarks = 0;
            axPDFReader1.ShowState = 0;
            axPDFReader1.ShowTitle = 0;
            if (System.IO.File.Exists(_FileName))
            {
                this.axPDFReader1.WebOpenLocalFile(_FileName);
            }
            else
            {
                axPDFReader1.WebClose();
            }
        }
        private void frmShowSignPdf_FormClosed(object sender, FormClosedEventArgs e)
        {
        }
        private void tsSignHand_Click(object sender, EventArgs e)
        {
            this.axPDFReader1.ShowSignDlg();
        }
        private void tsSave_Click(object sender, EventArgs e)
        {
            this.axPDFReader1.WebSaveLocalFile(_FileName);
        }
        /// <summary>
        /// 是否需要签章功能
        /// </summary>
        private void SetSignature()
        {
            if (Globals.IsSignature.Equals("1"))
            {
                tsSignHand.Visible = true;
            }
            else
            {
                tsSignHand.Visible = false;
            }
        }
    }
}
