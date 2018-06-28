using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ERM.UI.Controls
{
    public class TreeViewEX:CCWin.SkinControl.SkinTreeView
    {
        public TreeViewEX() : base() {
            base.BorderColor = System.Drawing.Color.Gainsboro;
            base.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
        }
    }
}
