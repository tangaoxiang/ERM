using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ERM.UI.Controls
{
    public class TXGroupEX:TX.Framework.WindowUI.Controls.TXGroupBox
    {
        public TXGroupEX() {
            base.ForeColor = System.Drawing.Color.Black;
            base.CaptionColor = System.Drawing.Color.Black;
            base.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular);
            base.CaptionFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold);
        }
    }
}
