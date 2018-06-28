using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using ERM.UI.Controls;
namespace ERM.UI
{
    public partial class frmAbout : Skin_DevEX
    {
        public frmAbout()
        {
            InitializeComponent();
        }
        private void frmAbout_Load(object sender, EventArgs e)
        {
            lblVersion.Text = "²úÆ·°æ±¾£º" + Assembly.GetExecutingAssembly().GetName().Version.ToString();
            lbl_phone.Text =  Properties.Settings.Default.lbl_phone;
            lbl_QQ.Text = Properties.Settings.Default.lbl_QQ;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lbl_phone_Click(object sender, EventArgs e)
        {

        }

        private void lbl_QQ_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {

        }
    }
}
