using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.Web;
using System.Net;
using System.IO;
using ERM.Common;
namespace ERM.UI
{
    public partial class frmErrInfo : Form
    {
        private string url = "http://222.35.140.27/digicell/add.aspx";
        private string _title;
        private string _description;
        /// <summary>
        /// ���ʹ�����վ��
        /// </summary>
        /// <param name="title">������Ϣ</param>
        /// <param name="description">������ϸ����</param>
        public frmErrInfo(string title,string description)
        {
            InitializeComponent();
            this.Text = Globals.PromptTitle;
            this._title = title;
            this._description = description;
            lblTitle.Text = title;
            lblPrompt.Text = String.Format(lblPrompt.Text, Globals.PromptTitle);
            txtDescription.Text = description;
        }
        private void frmErrInfo_Load(object sender, EventArgs e)
        {
            this.ActiveControl = btnSend;
        }
        private void btnSend_Click(object sender, EventArgs e)
        {
            ;
            btnSend.Enabled = false;
            try
            {
                Encoding gb2312 = Encoding.GetEncoding("gb2312");
                string postData = "title=" +  HttpUtility.UrlEncode(this._title, gb2312) + "&description=" + HttpUtility.UrlEncode(this._description, gb2312) + "&dag=" + HttpUtility.UrlEncode(Globals.UserTitle, gb2312) + "&ver=" + Assembly.GetExecutingAssembly().GetName().Version.ToString() + "&uid=" + HttpUtility.UrlEncode(Globals.CompanyTitle, gb2312);
                byte[] data = Encoding.ASCII.GetBytes(postData);
                HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(url);
                myRequest.Timeout = 10000;
                myRequest.Method = "POST";
                myRequest.ContentType = "application/x-www-form-urlencoded";
                myRequest.ContentLength = data.Length;
                Stream newStream = myRequest.GetRequestStream();
                newStream.Write(data, 0, data.Length);
                newStream.Close();
                HttpWebResponse myResponse = (HttpWebResponse)myRequest.GetResponse();
                StreamReader reader = new StreamReader(myResponse.GetResponseStream(), Encoding.Default);
                string content = reader.ReadToEnd();
                if (content.Contains("ok"))
                {
                    Functions.ShowInfo("���ķ�����Ϣ�Ѿ��ɹ��ύ��лл��");
                    this.Close();
                }
                else
                {
                    btnSend.Enabled = true;
                    Functions.ShowInfo("��������ԭ���޷��ύ������Ϣ�������Խ�������Ϣ���ƺ�ͨ��QQ���͸����ǡ�");
                }
            }
            catch(Exception ex)
            {
                btnSend.Enabled = true;
                Functions.ShowInfo(ex.Message + "���뽫������Ϣ���ƺ�ͨ��QQ���͸����ǡ�");
            }
        }
        private void btnCopy_Click(object sender, EventArgs e)
        {
            txtDescription.SelectAll();
            txtDescription.Copy();
            Functions.ShowInfo("�Ѿ����Ƶ������塣");
        }
    }
}
