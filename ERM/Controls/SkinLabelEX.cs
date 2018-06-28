using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ERM.UI.Controls
{
    public class SkinLabelEX : CCWin.SkinControl.SkinLabel
    {
        public SkinLabelEX()
        {
            base.ForeColor = System.Drawing.Color.Black;
            base.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            base.BorderColor = System.Drawing.Color.Transparent;
            base.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
        }
    }
}
