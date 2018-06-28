using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Diagnostics;
using System.ComponentModel;
namespace ERM.UI
{
    /// <summary>
    /// 自定义 SkinPanelEX 类
    /// </summary>
    public class CustomPanel : Panel
    {
        public CustomPanel()
        {
            this.SetStyle(ControlStyles.ResizeRedraw, true);
        }
        private Color _startColor = SystemColors.Control;
        public Color StartColor
        {
            get { return _startColor; }
            set
            {
                _startColor = value;
                this.Invalidate();
            }
        }
        private bool _squareTop = false;
        /// <summary>
        /// 获取或设置头部是否为方型
        /// </summary>
        [DefaultValue(false)]
        public bool SquareTop
        {
            get { return _squareTop; }
            set
            {
                _squareTop = value;
                this.StartColor = Color.FromArgb(220, 220, 220);
                this.Invalidate();
            }
        }
        private bool _squareBottom = false;
        /// <summary>
        /// 获取或设置底部是否为方型
        /// </summary>
        [DefaultValue(false)]
        public bool SquareBottom
        {
            get { return _squareBottom; }
            set
            {
                _squareBottom = value;
                this.Invalidate();
            }
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Pen pen;
            int X1 = this.ClientRectangle.Left;
            int X2 = this.ClientRectangle.Right - 1;
            int Y1 = this.ClientRectangle.Top;
            int Y2 = this.ClientRectangle.Bottom - 1;
            Color color = Color.FromArgb(204, 204, 204);
            if (this.StartColor != SystemColors.Control)
            {
                color = this.StartColor;
                Brush brush;
                using (brush = new SolidBrush(color))
                {
                    e.Graphics.FillRectangle(brush, X1 + 1, Y1 + 1, this.ClientRectangle.Width - 2, this.ClientRectangle.Height - 2);
                }
            }
            using (pen = new Pen(color))
            {
                if (this.SquareTop)
                {
                    Pen newPen;
                    using (newPen = new Pen(Color.White))
                    {
                        e.Graphics.DrawLine(newPen, X1 + 1, Y1, X2 - 1, Y1);
                    }
                    e.Graphics.DrawLine(pen, X1, Y1, X1, Y2 - 1);
                    e.Graphics.DrawLine(pen, X2, Y1, X2, Y2 - 1);
                }
                else
                {
                    e.Graphics.DrawLine(pen, X1, Y1 + 1, X1, Y2 - 1);
                    e.Graphics.DrawLine(pen, X2, Y1 + 1, X2, Y2 - 1);
                    e.Graphics.DrawLine(pen, X1 + 1, Y1, X2 - 1, Y1);
                }
                if (this.SquareBottom)
                {
                    e.Graphics.DrawLine(pen, X1, Y2, X2, Y2);
                }
                else
                {
                    e.Graphics.DrawLine(pen, X1 + 1, Y2, X2 - 1, Y2);
                }
            }
        }
        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.ResumeLayout(false);
        }
    }
}
