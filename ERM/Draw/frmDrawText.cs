using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Text;
namespace ERM.UI
{
    public partial class frmDrawText : Form
    {
        public frmDrawText()
        {
            InitializeComponent();
            FontFamily[] fonts = (new InstalledFontCollection()).Families;
            for (int i = 0; i < fonts.Length; i++)
            {
                this.cboFont.Items.Add(fonts[i].Name);
            }
            cboFont.SelectedItem = "宋体";
            cboSize.SelectedItem = "9";
        }
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (cboSize.Text != "")
                this.DialogResult = DialogResult.OK;
            else
            {
                MessageBox.Show("没有选择大小");
            }
        }
        public Font GetFont
        {
            get 
            {
                if (cboSize.Text != "")
                    return new Font(cboFont.SelectedItem.ToString(), int.Parse(cboSize.Text));
                else
                    return new Font(cboFont.SelectedItem.ToString(), 9);
            }
        }
    }
}
