using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ERM.Common;
namespace ERM.UI.File
{
    public partial class frmRotate : Form
    {
        FrmScan frmScan;
        public frmRotate(FrmScan frm)
        {
            InitializeComponent();
            frmScan = frm;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (Functions.IsNumeric(textBox1.Text.Trim()))
            {
                int x = int.Parse(textBox1.Text.Trim());
                Control[] editors = frmScan.Controls.Find("axImgEdit1", true);
                if (editors.Length > 0)
                {
                    AxImgeditLibCtl.AxImgEdit obj = (AxImgeditLibCtl.AxImgEdit)editors[0];
                    obj.RotateRight(x);
                    this.DialogResult = DialogResult.OK;
                }
            }
            else
                return;
        }
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            turnAnyDegree(e);
        }
        private void turnAnyDegree(KeyPressEventArgs e)
        {
            int x = 0;
            if (e.KeyChar != (char)13)
                return;
            else
            {
                if (Functions.IsNumeric(textBox1.Text.Trim()))
                {
                    x = int.Parse(textBox1.Text.Trim());
                    Control[] editors = frmScan.Controls.Find("axImgEdit1", true);
                    if (editors.Length > 0)
                    {
                        AxImgeditLibCtl.AxImgEdit obj = (AxImgeditLibCtl.AxImgEdit)editors[0];
                        obj.RotateRight(x);
                    }
                    this.DialogResult = DialogResult.OK;
                }
                else
                    return;
            }
        }
        private void frmRotate_Load(object sender, EventArgs e)
        {
            textBox1.Focus();
        }
    }
}
