using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Diagnostics;
using System.ComponentModel;
using CCWin.SkinControl;
namespace ERM.UI
{
    /// <summary>
    /// 自定义 SkinPanelEX 类
    /// </summary>
    public class PanelEx : SkinPanel
    {
        public PanelEx()
        {
            this.SetStyle(ControlStyles.ResizeRedraw, true);
        }
        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.ResumeLayout(false);
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            int X1 = this.ClientRectangle.Left;
            int X2 = this.ClientRectangle.Right - 1;
            int Y1 = this.ClientRectangle.Top;
            int Y2 = this.ClientRectangle.Bottom - 1;
            Pen pen;
            Brush brush;
            using (brush = new SolidBrush(_backColor))
            {
                e.Graphics.FillRectangle(brush, X1 + 1, Y1 + 1, this.ClientRectangle.Width - 2, this.ClientRectangle.Height - 2);
            }
            this.BackColor = Parent.BackColor;
            using (pen = new Pen(_borderColor))
            {
                if (_circle)
                {
                    e.Graphics.DrawLine(pen, X1 + 2, Y1, X1 + 2, Y1 + 1);
                    e.Graphics.DrawLine(pen, X1 + 1, Y1 + 1, X1 + 1, Y1 + 2);
                    e.Graphics.DrawLine(pen, X1, Y1 + 2, X1, Y1 + 2);
                    e.Graphics.DrawLine(pen, X2 - 2, Y1, X2 - 2, Y1 + 1);
                    e.Graphics.DrawLine(pen, X2 - 1, Y1 + 1, X2 - 1, Y1 + 2);
                    e.Graphics.DrawLine(pen, X2, Y1 + 2, X2, Y1 + 2);
                    e.Graphics.DrawLine(pen, X1 + 2, Y2, X1 + 2, Y2 - 1);
                    e.Graphics.DrawLine(pen, X1 + 1, Y2 - 1, X1 + 1, Y2 - 2);
                    e.Graphics.DrawLine(pen, X1, Y2 - 2, X1, Y2 - 2);
                    e.Graphics.DrawLine(pen, X2 - 2, Y2, X2 - 2, Y2 - 1);
                    e.Graphics.DrawLine(pen, X2 - 1, Y2 - 1, X2 - 1, Y2 - 2);
                    e.Graphics.DrawLine(pen, X2, Y1 - 2, X2, Y1 - 2);
                    e.Graphics.DrawLine(pen, X1, Y1 + 2, X1, Y2 - 2);
                    e.Graphics.DrawLine(pen, X2, Y1 + 2, X2, Y2 - 2);
                    e.Graphics.DrawLine(pen, X1 + 2, Y1, X2 - 2, Y1);
                    e.Graphics.DrawLine(pen, X1 + 2, Y2, X2 - 2, Y2);
                }
                else
                {
                    e.Graphics.DrawLine(pen, X1, Y1, X1, Y2);
                    e.Graphics.DrawLine(pen, X2, Y1, X2, Y2);
                    e.Graphics.DrawLine(pen, X1, Y1, X2, Y1);
                    e.Graphics.DrawLine(pen, X1, Y2, X2, Y2);
                }
            }
        }
        private bool _circle = false;
        [Browsable(true), Category("扩展"), Description("控件是否为圆角"), DefaultValue("false")]
        public bool Circle
        {
            get
            {
                return _circle;
            }
            set
            {
                _circle = value;
                this.Invalidate();
            }
        }
        private Color _borderColor = Color.FromArgb(208, 208, 191);
        [Browsable(true),Category("扩展"),Description("控件边框颜色"),DefaultValue("208, 208, 191")]
        public Color BorderColor
        {
            get
            {
                return _borderColor;
            }
            set
            {
                _borderColor = value;
                this.Invalidate();
            }
        }
        private Color _backColor = SystemColors.Control;
        [Browsable(true), Category("扩展"), Description("控件背景颜色"), DefaultValue("Control")]
        public Color BackColorEx
        {
            get
            {
                return _backColor;
            }
            set
            {
                _backColor = value;
                this.Invalidate();
            }
        }
        [Browsable(false)]
        public override Color BackColor
        {
            get
            {
                return base.BackColor;
            }
            set
            {
                base.BackColor = value;
            }
        }
    }
}
