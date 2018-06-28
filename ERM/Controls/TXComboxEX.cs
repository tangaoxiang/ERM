using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ERM.UI.Controls
{
    public class TXComboxEX:TX.Framework.WindowUI.Controls.TXComboBox
    {
        public TXComboxEX() {
           base.Font = new System.Drawing.Font("微软雅黑", 9F);
           base.FormattingEnabled = true;
        }
    }
}
