using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
namespace ERM.UI
{
    /// <summary>
    /// 重写工具栏控件，使工具栏下方的分隔线更加美观（可用于Tab页）；另外默认情况下分隔线是不可见的。
    /// </summary>
    public class MyToolStrip : ToolStrip
    {
        private ToolRenderer _renderer = new ToolRenderer();
        /// <summary>
        /// 构造函数
        /// </summary>
        public MyToolStrip(): base()
        {
            this.Renderer = _renderer;
        }
        private bool _drawBorder = false;
        /// <summary>
        /// 是否在控件下放绘制直线
        /// </summary>
        [DefaultValue(false), Description("是否在控件下放绘制直线"), Category("Appearance")]
        public bool DrawBorder
        {
            get { return _drawBorder; }
            set
            {
                _drawBorder = value;
                _renderer.DrawBorder = value;
            }
        }
        protected override void OnRendererChanged(EventArgs e)
        {
            if (this.Renderer != _renderer)
            {
                this.Renderer = _renderer;
            }
            else
            {
                base.OnRendererChanged(e);
            }
        }
    }
    /// <summary>
    /// 工具栏控件 ToolStripSystemRenderer 的重构
    /// </summary>
    public class ToolRenderer : ToolStripSystemRenderer
    {
        private bool _drawBorder;
        /// <summary>
        /// 设置、获取DrawBorder的值
        /// </summary>
        public bool DrawBorder
        {
            get { return _drawBorder; }
            set { _drawBorder = value; }
        }
    }
    /// <summary>
    /// 重写菜单控件，使菜单下方的分隔线不可见的。
    /// </summary>
    public class MyMenuStrip : MenuStrip
    {
        private ToolStripRenderer _renderer = new MenuRenderer();
        public MyMenuStrip() : base()
        {
            ////this.Renderer = _renderer;
        }
        ////protected override void OnRendererChanged(EventArgs e)
        ////{
        ////    if (this.Renderer != _renderer)
        ////    {
        ////        // Force to our renderer
        ////        this.Renderer = _renderer;
        ////    }
        ////    else
        ////    {
        ////        base.OnRendererChanged(e);
        ////    }
        ////}
    }
    /// <summary>
    /// 菜单控件 ToolStripSystemRenderer 的重构
    /// </summary>
    public class MenuRenderer : ToolStripSystemRenderer
    {
        protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e)
        {
        }
    }
    public class MyToolStripProfessional : ToolStrip
    {
        private ToolRendererProfessional _renderer = new ToolRendererProfessional();
        private MyColorTable _colorTable;
        public MyToolStripProfessional()
            : base()
        {
            _renderer.RoundedEdges = false;
            this.Renderer = _renderer;
            this.GripStyle = ToolStripGripStyle.Hidden;
            this._colorTable = _renderer.MyColorTable;
        }
        protected override void OnBackColorChanged(EventArgs e)
        {
            base.OnBackColorChanged(e);
            _colorTable.BackColor = this.BackColor;
        }
        protected override void OnRendererChanged(EventArgs e)
        {
            if (this.Renderer != _renderer)
            {
                this.Renderer = _renderer;
            }
            else
            {
                base.OnRendererChanged(e);
            }
        }
    }
    public class ToolRendererProfessional : ToolStripProfessionalRenderer
    {
        public ToolRendererProfessional()
            : base(new MyColorTable())
        {
        }
        public MyColorTable MyColorTable
        {
            get { return this.ColorTable as MyColorTable; }
        }
        protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e)
        {
        }
        protected override void OnRenderButtonBackground(ToolStripItemRenderEventArgs e)
        {
            int X1 = 0;
            int X2 = e.Item.Width - 2;
            int Y1 = 0;
            int Y2 = e.Item.Height - 2;
            Color C1;
            Color C2;
            Color C3;
            Color C4;
            Color C5;
            if (e.Item.Selected)
            {
                C1 = Color.FromArgb(102, 102, 102);
                C2 = Color.FromArgb(51, 51, 51);
                C3 = Color.White;
                C4 = Color.White;
                C5 = Color.FromArgb(229, 229, 162);
            }
            else
            {
                C1 = Color.FromArgb(153, 153, 153);
                C2 = Color.FromArgb(102, 102, 102);
                C3 = Color.White;
                C4 = Color.FromArgb(250, 250, 250);
                C5 = Color.FromArgb(196, 191, 173);
            }
            Brush brush;
            Rectangle rect = new Rectangle(e.Item.ContentRectangle.X + 1, e.Item.ContentRectangle.Y + 1, e.Item.ContentRectangle.Width - 3, e.Item.ContentRectangle.Height - 3);
            using (brush = new LinearGradientBrush(rect, C4, C5, LinearGradientMode.Vertical))
            {
                e.Graphics.FillRectangle(brush, rect);
            }
            Pen pen;
            using (pen = new Pen(C1))
            {
                e.Graphics.DrawLine(pen, X1, Y1 + 1, X1, Y2 - 1);
                e.Graphics.DrawLine(pen, X1 + 1, Y1, X2 - 1, Y1);
            }
            using (pen = new Pen(C3))
            {
                e.Graphics.DrawLine(pen, X1 + 1, Y1 + 1, X1 + 1, Y2 - 1);
                e.Graphics.DrawLine(pen, X1 + 1, Y1 + 1, X2 - 1, Y1 + 1);
            }
            using (pen = new Pen(C2))
            {
                e.Graphics.DrawLine(pen, X2, Y1 + 1, X2, Y2 - 1);
                e.Graphics.DrawLine(pen, X1 + 1, Y2, X2 - 1, Y2);
            }
        }
    }
    public class MyColorTable : ProfessionalColorTable
    {
        public MyColorTable()
        {
            this.UseSystemColors = true;
            _backColor = base.ToolStripGradientEnd;
        }
        private Color _backColor;
        public Color BackColor
        {
            get { return _backColor; }
            set
            {
                _backColor = value;
            }
        }
        public override Color ButtonCheckedGradientBegin
        {
            get { return base.ButtonCheckedGradientBegin; }
        }
        public override Color ButtonCheckedGradientMiddle
        {
            get { return base.ButtonCheckedGradientMiddle; }
        }
        public override Color ButtonCheckedGradientEnd
        {
            get { return base.ButtonCheckedGradientEnd; }
        }
        public override Color ButtonCheckedHighlight
        {
            get { return base.ButtonCheckedHighlight; }
        }
        public override Color ButtonCheckedHighlightBorder
        {
            get { return base.ButtonCheckedHighlightBorder; }
        }
        public override Color ButtonPressedBorder
        {
            get { return base.ButtonPressedBorder; }
        }
        public override Color ButtonPressedGradientBegin
        {
            get { return base.ButtonPressedGradientBegin; }
        }
        public override Color ButtonPressedGradientEnd
        {
            get { return base.ButtonPressedGradientEnd; }
        }
        public override Color ButtonPressedGradientMiddle
        {
            get { return base.ButtonPressedGradientMiddle; }
        }
        public override Color ButtonPressedHighlight
        {
            get { return base.ButtonPressedHighlight; }
        }
        public override Color ButtonPressedHighlightBorder
        {
            get { return base.ButtonPressedHighlightBorder; }
        }
        public override Color ButtonSelectedBorder
        {
            get { return base.ButtonSelectedBorder; }
        }
        public override Color ButtonSelectedGradientBegin
        {
            get { return base.ButtonSelectedGradientBegin; }
        }
        public override Color ButtonSelectedGradientEnd
        {
            get { return base.ButtonSelectedGradientEnd; }
        }
        public override Color ButtonSelectedGradientMiddle
        {
            get { return base.ButtonSelectedGradientMiddle; }
        }
        public override Color ButtonSelectedHighlight
        {
            get { return base.ButtonSelectedHighlight; }
        }
        public override Color ButtonSelectedHighlightBorder
        {
            get { return base.ButtonSelectedHighlightBorder; }
        }
        public override Color CheckBackground
        {
            get { return base.CheckBackground; }
        }
        public override Color CheckPressedBackground
        {
            get { return base.CheckPressedBackground; }
        }
        public override Color CheckSelectedBackground
        {
            get { return base.CheckSelectedBackground; }
        }
        public override Color GripDark
        {
            get { return base.GripDark; }
        }
        public override Color GripLight
        {
            get { return base.GripLight; }
        }
        public override Color ImageMarginGradientBegin
        {
            get { return base.ImageMarginGradientBegin; }
        }
        public override Color ImageMarginGradientEnd
        {
            get { return base.ImageMarginGradientEnd; }
        }
        public override Color ImageMarginGradientMiddle
        {
            get { return base.ImageMarginGradientMiddle; }
        }
        public override Color ImageMarginRevealedGradientBegin
        {
            get { return base.ImageMarginRevealedGradientBegin; }
        }
        public override Color ImageMarginRevealedGradientEnd
        {
            get { return base.ImageMarginRevealedGradientEnd; }
        }
        public override Color ImageMarginRevealedGradientMiddle
        {
            get { return base.ImageMarginRevealedGradientMiddle; }
        }
        public override Color MenuBorder
        {
            get { return base.MenuBorder; }
        }
        public override Color MenuItemBorder
        {
            get { return base.MenuItemBorder; }
        }
        public override Color MenuItemPressedGradientBegin
        {
            get { return base.MenuItemPressedGradientBegin; }
        }
        public override Color MenuItemPressedGradientEnd
        {
            get { return base.MenuItemPressedGradientEnd; }
        }
        public override Color MenuItemPressedGradientMiddle
        {
            get { return base.MenuItemPressedGradientMiddle; }
        }
        public override Color MenuItemSelected
        {
            get { return base.MenuItemSelected; }
        }
        public override Color MenuItemSelectedGradientBegin
        {
            get { return base.MenuItemSelectedGradientBegin; }
        }
        public override Color MenuItemSelectedGradientEnd
        {
            get { return base.MenuItemSelectedGradientEnd; }
        }
        public override Color MenuStripGradientBegin
        {
            get { return base.MenuStripGradientBegin; }
        }
        public override Color MenuStripGradientEnd
        {
            get { return base.MenuStripGradientEnd; }
        }
        public override Color OverflowButtonGradientBegin
        {
            get { return base.OverflowButtonGradientBegin; }
        }
        public override Color OverflowButtonGradientEnd
        {
            get { return base.OverflowButtonGradientEnd; }
        }
        public override Color OverflowButtonGradientMiddle
        {
            get { return base.OverflowButtonGradientMiddle; }
        }
        public override Color RaftingContainerGradientBegin
        {
            get { return base.RaftingContainerGradientBegin; }
        }
        public override Color RaftingContainerGradientEnd
        {
            get { return base.RaftingContainerGradientEnd; }
        }
        public override Color SeparatorDark
        {
            get { return base.SeparatorDark; }
        }
        public override Color SeparatorLight
        {
            get { return base.SeparatorLight; }
        }
        public override Color StatusStripGradientBegin
        {
            get { return base.StatusStripGradientBegin; }
        }
        public override Color StatusStripGradientEnd
        {
            get { return base.StatusStripGradientEnd; }
        }
        public override Color ToolStripBorder
        {
            get { return base.ToolStripBorder; }
        }
        public override Color ToolStripContentPanelGradientBegin
        {
            get { return base.ToolStripContentPanelGradientBegin; }
        }
        public override Color ToolStripContentPanelGradientEnd
        {
            get { return base.ToolStripContentPanelGradientEnd; }
        }
        public override Color ToolStripDropDownBackground
        {
            get { return base.ToolStripDropDownBackground; }
        }
        public override Color ToolStripGradientBegin
        {
            get { return _backColor; }
        }
        public override Color ToolStripGradientEnd
        {
            get { return _backColor; }
        }
        public override Color ToolStripGradientMiddle
        {
            get { return _backColor; }
        }
        public override Color ToolStripPanelGradientBegin
        {
            get { return base.ToolStripPanelGradientBegin; }
        }
        public override Color ToolStripPanelGradientEnd
        {
            get { return base.ToolStripPanelGradientEnd; }
        }
    }
    /// <summary>
    /// 重写工具栏控件，用于Tab页的ActiveTab；
    /// </summary>
    public class MyToolStripHeader : ToolStrip
    {
        private HeaderRenderer _renderer = new HeaderRenderer();
        public MyToolStripHeader()
            : base()
        {
            _renderer.RoundedEdges = false;
            this.Renderer = _renderer;
            this.GripStyle = ToolStripGripStyle.Hidden;
        }
        protected override void OnRendererChanged(EventArgs e)
        {
            if (this.Renderer != _renderer)
            {
                this.Renderer = _renderer;
            }
            else
            {
                base.OnRendererChanged(e);
            }
        }
    }
    public class HeaderRenderer : ToolStripProfessionalRenderer
    {
        protected override void OnRenderToolStripBackground(ToolStripRenderEventArgs e)
        {
            base.OnRenderToolStripBackground(e);
            ToolStrip toolStrip = e.ToolStrip;
            Graphics g = e.Graphics;
            Rectangle bounds = new Rectangle(Point.Empty, toolStrip.Size);
            if (bounds.Width > 0 && bounds.Height > 0)
            {
                using (Brush b = new LinearGradientBrush(bounds, Color.FromArgb(90, 122, 90), Color.FromArgb(172, 208, 172), LinearGradientMode.Horizontal))
                {
                    g.FillRectangle(b, bounds);
                }
            }
        }
        protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e)
        {
        }
    }
}
