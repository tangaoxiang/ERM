using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using TX.Framework.WindowUI.Controls;
using TX.Framework.WindowUI.Forms;

namespace ERM.UI.Controls
{
    public class TXTextBoxEX:TXTextBox
    {
        public TXTextBoxEX() {
            base.Height = 25;
            base.Width = 100;
            base.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point,((byte)(134)));
            base._TextBox.KeyPress+=_TextBox_KeyPress;
            base._TextBox.KeyDown+=_TextBox_KeyDown;
        }

        private void _TextBox_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void _TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!MyCommon.IsMatchCode(e.KeyChar.ToString()))
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
        }
    }
}
