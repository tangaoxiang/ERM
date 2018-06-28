using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ERM.UI.Controls
{
    public class SkinPanelEX:CCWin.SkinControl.SkinPanel
    {
        public SkinPanelEX() {
           base.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
           base.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
           base.ControlState = CCWin.SkinClass.ControlState.Normal;
           base.Radius = 2;
           base.RoundStyle = CCWin.SkinClass.RoundStyle.All;
        }
    }
}
