using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TX.Framework.WindowUI.Controls;
using TX.Framework.WindowUI.Forms;
namespace ERM.UI
{
    public partial class frmXsd : ERM.UI.Controls.Skin_DevEX
    {
        public frmXsd()
        {
            InitializeComponent();
            UpDown1.SelectedIndex = 0;
        }
        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void txt_RMin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 0x20)
                e.KeyChar = (char)0;  //��ֹ�ո��
            //if ((e.KeyChar == 0x2D) && (((TextBox)sender).Text.Length == 0)) 
            //    return;   //������
            if (e.KeyChar > 0x20)
            {
                try
                {
                    double.Parse(((ERM.UI.Controls.TXTextBoxEX)sender).Text + e.KeyChar.ToString());
                }
                catch
                {
                    e.KeyChar = (char)0;   //����Ƿ��ַ�
                }
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (MyCommon.IsInt(UpDown1.Text))
            {
                this.DialogResult = DialogResult.OK;
            }
            else
                TXMessageBoxExtensions.Info("����һ��0-5��������");
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
