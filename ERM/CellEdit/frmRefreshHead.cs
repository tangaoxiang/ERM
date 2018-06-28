using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
namespace ERM.UI
{
    public partial class frmRefreshHead : Form
    {
        private delPrintPDF Mydel;
        private DataTable dtFiles;
        public string ErrorMsg = "";
        /// <summary>
        /// 
        /// </summary>
        /// <param name="theForm"></param>
        /// <param name="refreshSelf">refreshSelf = true����ʾ������һ�ű�ˢ���Լ��Ϳ�����</param>
        public frmRefreshHead(delPrintPDF _del,DataTable _dtfiles)
        {
            InitializeComponent();
            Mydel = _del;
            dtFiles = _dtfiles;
            this.progressBar1.Maximum = 10;
            this.progressBar1.Value = 0;
        }
        public void StartRefresh()
        {
            int i = 0;
            for (int j = 0; i < dtFiles.Rows.Count; j++)
            {
                DataRow dr = dtFiles.Rows[j];
                string filepath = Globals.ProjectPath + dr["filepath"].ToString();
                label1.Text = "��" + dtFiles.Rows.Count + "���ļ��������ύ��" + (i + 1) + "���ļ�";
                if (System.IO.File.Exists(filepath))
                {
                    if (!Mydel(filepath, dr["id"].ToString()))
                    {
                        ErrorMsg = dr["title"].ToString().Replace('\\', '-') + " ��ӡʧ�ܣ�";
                        break;
                    }
                    i++;
                }
                else
                {
                    ErrorMsg = dr["title"].ToString().Replace('\\', '-') + " cll�������ڣ�";
                    break;
                }
            }
            if (i == dtFiles.Rows.Count)
                this.DialogResult = DialogResult.OK;
            else
            {
                this.DialogResult = DialogResult.Cancel;
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (this.progressBar1.Value == this.progressBar1.Maximum)
                this.progressBar1.Value = 0;
            this.progressBar1.Value += 1;
        }
        public string SetMsg
        {
            get { return this.lblMsg.Text; }
            set { this.lblMsg.Text = value; }
        }
        public String SetTitle
        {
            get { return this.Text; }
            set { this.Text = value; }
        }
        private void frmRefreshHead_Load(object sender, EventArgs e)
        {
        }
        private void timerStartProcess_Tick(object sender, EventArgs e)
        {
            ;
            timerStartProcess.Enabled = false;
            timer1.Enabled = true;
            StartRefresh();
        }
    }
}
