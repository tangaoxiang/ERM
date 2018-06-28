/*2009.06.11 汤
 * 
 * 
 * 多边形和多线条右键完成编辑
 * 
 * 图形选取方法：每个图形存储一个矩形区域，鼠标点击时，从图形集合中判断哪个图形的矩形区域包含点击的point，
 *              如果是焦点图形时，用特殊颜色绘制。
 *              每个图形绘制有顺序，遍历图形集合，从最大索引到最小判断。
 * 
 * 图形选取后移动的方法：直接判断拖动前的点 和松开的点 X Y相差距离，然后改变图形所有存储点的X Y 然后重绘。
 * 
 * 存在问题：1 画弧及扇形选取不准确
 *           2 由于存储的是矩形区域，当直线的起点和终点的X或Y相同时（-|两种线条时） 线条选取困难
 *           3 没有实现缩放
 *           4 没有实现填充  
 * 
 * 当加入CellEdit时，先获得单元格大小，然后传入当前窗体，然后设置picturebox大小。
 */ 
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
namespace ERM.UI
{
    public partial class DrawForm : Form
    {
        [DllImport("gdi32.dll")]
        public static extern bool LineTo(IntPtr hdc, int x, int y);
        [DllImport("gdi32.dll")]
        public static extern bool MoveToEx(IntPtr hdc, int x, int y, IntPtr lpPoint);
        /// <summary>
        /// 图形枚举。
        /// </summary>
        public enum ImageType
        {
            Empty,
            Point,
            Line,
            MuiltLine,
            HollowCir,
            HollowEllipse,
            HollowRectangle,
            Text,
            Arc,
            Pie,
            Polygon
        }
        public DrawForm()
        {
            InitializeComponent();
            ToolStripManager.RenderMode = ToolStripManagerRenderMode.Professional;
            ToolStripManager.VisualStylesEnabled = false;
        }
        DShapeList IgList = new DShapeList();
        DShape Ig;
        DShape igTmp;
        DShape curSelect = null;
        ImageType tp;
        Point pt_old;
        List<Point> MuiltPoint;
        Point pt_cur;
        private void pb_Paint(object sender, PaintEventArgs e)
        {
            ReDraw(e.Graphics,true);
        }
        private void ReDraw(Graphics g,bool b)
        {
            g.Clear(this.pb.BackColor);
            IgList.DrawList(g);
            if (tp != ImageType.Empty && b)//&& tp != ImageType.Text)
            {
                g.DrawLine(new Pen(Color.Black), new Point(this.pt_cur.X, 0), new Point(pt_cur.X, this.pb.ClientSize.Height));
                g.DrawLine(new Pen(Color.Black), new Point(0, pt_cur.Y), new Point(this.pb.ClientSize.Width, pt_cur.Y));
            }
            if (igTmp != null)
                igTmp.Draw(g);
        }
        private Pen MouseMovePen()
        {
            Pen p = new Pen(btnColor.BackColor, (this.cboLine.SelectedIndex+1) * zoom /100);
            return p;
        }
        private void pb_MouseEnter(object sender, EventArgs e)
        {
            if (this.tp == ImageType.Empty)
                this.Cursor = Cursors.Default;
            else
            {
                if(tp != ImageType.Text)
                    this.Cursor = Cursors.Arrow;
                else
                    this.Cursor = Cursors.IBeam;
            }
        }
        private void pb_MouseLeave(object sender, EventArgs e)
        {
        }
        int flag = 0;
        private void pb_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                pt_old = e.Location;
                if (tp == ImageType.Empty)
                {
                    DShape d = IgList.GetNear(e.X, e.Y) as DShape;
                    if (curSelect != null)
                    {
                        curSelect.IsNear = false;
                        curSelect = null;
                    }
                    if (d != null)
                    {
                        d.IsNear = true;
                        curSelect = d;
                    }
                    else
                    {                        
                    }
                    pb.Refresh();
                }
                else
                { 
                    MuiltPoint.Add(pt_cur);
                    if (flag == 1)
                    {
                        switch (tp)
                        {
                            case ImageType.Line:
                                Ig = new DLine(this.MuiltPoint, this.btnColor.BackColor, (this.cboLine.SelectedIndex + 1)*zoom/100);
                                IgList.Add(Ig);
                                MuiltPoint = new List<Point>();
                                flag = 0;
                                this.pb.Refresh();
                                break;
                            case ImageType.HollowCir:
                                Ig = new DHollowCircle(this.MuiltPoint, this.btnColor.BackColor, (this.cboLine.SelectedIndex + 1)*zoom/100);
                                IgList.Add(Ig);
                                MuiltPoint = new List<Point>();
                                flag = 0;
                                this.pb.Refresh();
                                break;
                            case ImageType.MuiltLine:
                                igTmp = new DMuiltLine(MuiltPoint, this.btnColor.BackColor, (this.cboLine.SelectedIndex + 1)*zoom/100);
                                this.pb.Refresh();
                                break;
                            case ImageType.Polygon:
                                break;
                            case ImageType.Text:
                                frmDrawText frm = new frmDrawText();
                                DialogResult drs = frm.ShowDialog();
                                if (drs == DialogResult.OK)
                                {
                                    Ig = new DText(MuiltPoint, this.btnColor.BackColor, frm.txtStr.Text, frm.GetFont);
                                    IgList.Add(Ig);
                                }
                                MuiltPoint = new List<Point>();
                                flag = 0;
                                this.pb.Refresh();
                                break;
                            case ImageType.HollowEllipse:
                            case ImageType.HollowRectangle:
                                if (tp == ImageType.HollowRectangle)
                                    Ig = new DHollowRectangle(this.MuiltPoint, this.btnColor.BackColor, (this.cboLine.SelectedIndex + 1)*zoom/100);
                                else 
                                    Ig = new DHollowEllipse(this.MuiltPoint, this.btnColor.BackColor, (this.cboLine.SelectedIndex + 1)*zoom/100);
                                IgList.Add(Ig);
                                MuiltPoint = new List<Point>();
                                flag = 0;
                                this.pb.Refresh();
                                break;
                            case ImageType.Arc:
                            case ImageType.Pie:
                                igTmp = new DLine(MuiltPoint, this.btnColor.BackColor, (this.cboLine.SelectedIndex + 1)*zoom/100);
                                flag = 2;
                                pb.Refresh();
                                break;
                        }
                    }
                    else
                    {
                        if (flag == 2)
                        {
                            if (tp == ImageType.Arc)
                                Ig = new DArc(this.MuiltPoint, this.btnColor.BackColor, (this.cboLine.SelectedIndex + 1)*zoom/100);
                            else
                                Ig = new DPie(this.MuiltPoint, this.btnColor.BackColor, (this.cboLine.SelectedIndex + 1)*zoom/100);
                            IgList.Add(Ig);
                            MuiltPoint = new List<Point>();
                            flag = 0;
                            igTmp = null;
                            this.pb.Refresh();
                        }
                        else
                            flag = 1;
                    }
                }
            }
            else
            {
                if (flag == 1)
                {
                    if (tp == ImageType.MuiltLine)
                    {
                        Ig = new DMuiltLine(this.MuiltPoint, this.btnColor.BackColor, (this.cboLine.SelectedIndex + 1)*zoom/100);
                        this.IgList.Add(Ig);
                        MuiltPoint = new List<Point>();
                        flag = 0;
                    }
                    else if (tp == ImageType.Polygon)
                    {
                        Ig = new DPolygon(this.MuiltPoint, this.btnColor.BackColor, (this.cboLine.SelectedIndex + 1)*zoom/100);
                        this.IgList.Add(Ig);
                        MuiltPoint = new List<Point>();
                        flag = 0;
                    }
                }
            }
        }
        private void pb_MouseMove(object sender, MouseEventArgs e)
        {
            pt_cur = e.Location;
            this.Text = "x=" + e.X + ";y=" + e.Y;
            if (tp != ImageType.Empty)
            {
                pb.Refresh();
                if (flag == 1)
                {
                    Graphics g = pb.CreateGraphics();
                    switch (tp)
                    {
                        case ImageType.Line:
                            g.DrawLine(MouseMovePen(), pt_old, e.Location);
                            break;
                        case ImageType.MuiltLine:
                            if (MuiltPoint.Count > 0)
                            {
                                g.DrawLine(MouseMovePen(), MuiltPoint[MuiltPoint.Count - 1], e.Location);
                            }
                            break;
                        case ImageType.Polygon:
                            if (MuiltPoint.Count > 0)
                            {
                                Point[] ps = new Point[MuiltPoint.Count + 1];
                                MuiltPoint.CopyTo(ps);
                                ps[MuiltPoint.Count] = e.Location;
                                g.DrawPolygon(MouseMovePen(), ps);
                            }
                            break;
                        case ImageType.HollowEllipse:
                        case ImageType.HollowRectangle:
                        case ImageType.Text:
                            int max_x, max_y, min_x, min_y;
                            if (pt_old.X > e.X)
                            {
                                max_x = pt_old.X;
                                min_x = e.X;
                            }
                            else
                            {
                                max_x = e.X;
                                min_x = pt_old.X;
                            }
                            if (pt_old.Y > e.Y)
                            {
                                max_y = pt_old.Y;
                                min_y = e.Y;
                            }
                            else
                            {
                                max_y = e.Y;
                                min_y = pt_old.Y;
                            }
                            if (tp == ImageType.HollowEllipse)
                                g.DrawEllipse(MouseMovePen(), Rectangle.FromLTRB(min_x, min_y, max_x, max_y));
                            else
                                g.DrawRectangle(MouseMovePen(), Rectangle.FromLTRB(min_x, min_y, max_x, max_y));
                            break;
                        case ImageType.HollowCir:
                            int _max_x, _max_y, _min_x, _min_y;
                            if (pt_old.X > e.X)
                            {
                                _max_x = pt_old.X;
                                _min_x = e.X;
                            }
                            else
                            {
                                _max_x = e.X;
                                _min_x = pt_old.X;
                            }
                            if (pt_old.Y > e.Y)
                            {
                                _max_y = pt_old.Y;
                                _min_y = e.Y;
                            }
                            else
                            {
                                _max_y = e.Y;
                                _min_y = pt_old.Y;
                            }
                            int cha_x = _max_x - _min_x;
                            int cha_y = _max_y - _min_y;
                            int dis = Math.Abs(cha_x - cha_y);
                            bool b = cha_y > cha_x;
                            if (!b)
                            {
                                if (pt_old.X > e.X)
                                {
                                    _min_x = _min_x + dis;
                                }
                                else
                                {
                                    _max_x = _max_x - dis;
                                }
                            }
                            else
                            {
                                if (pt_old.Y > e.Y)
                                {
                                    _min_y = _min_y + dis;
                                }
                                else
                                {
                                    _max_y = _max_y - dis;
                                }
                            }
                            g.DrawEllipse(MouseMovePen(), Rectangle.FromLTRB(_min_x, _min_y, _max_x, _max_y));
                            break;
                        case ImageType.Arc:
                        case ImageType.Pie:
                            g.DrawLine(MouseMovePen(), MuiltPoint[0], pt_cur);
                            break;
                    }
                }
                else if (flag == 2 && (tp == ImageType.Arc || tp == ImageType.Pie))
                {
                    Graphics g = pb.CreateGraphics();
                    double angle1 = Math.Abs(Math.Atan2(MuiltPoint[1].Y - MuiltPoint[0].Y, MuiltPoint[1].X - MuiltPoint[0].X) * 180 / Math.PI);
                    double angle2 = Math.Abs(Math.Atan2(e.Y - MuiltPoint[0].Y, e.X - MuiltPoint[0].X) * 180 / Math.PI);
                    int dist = (int)Math.Sqrt(Math.Pow((MuiltPoint[0].X - MuiltPoint[1].X), 2.0) + Math.Pow((MuiltPoint[0].Y - MuiltPoint[1].Y), 2.0));
                    Point _tempt = new Point(MuiltPoint[0].X - dist, MuiltPoint[0].Y - dist);
                    int diameter = dist * 2;
                    Rectangle rec = new Rectangle(_tempt, new Size(diameter, diameter));
                    if (MuiltPoint[1].Y > MuiltPoint[0].Y)//圆心是从上往上画
                    {
                        if (e.Y > MuiltPoint[0].Y)//当前点在原点下面
                        {
                            if (angle2 < angle1)//画大圆
                            {
                                if (tp == ImageType.Arc)
                                    g.DrawArc(MouseMovePen(), rec, (float)angle1, (float)(360 - angle1 + angle2));
                                else
                                    g.DrawPie(new Pen(Color.Red), rec, (float)angle1, (float)(360 - angle1 + angle2));
                            }
                            else//半截的
                            {
                                if (tp == ImageType.Arc)
                                    g.DrawArc(MouseMovePen(), rec, (float)angle1, (float)(angle2 - angle1));
                                else
                                    g.DrawPie(MouseMovePen(), rec, (float)angle1, (float)(angle2 - angle1));
                            }
                        }
                        else//当前点在原点上面
                        {
                            if (tp == ImageType.Arc)
                                g.DrawArc(MouseMovePen(), rec, (float)angle1, (float)(360 - (angle1 + angle2)));
                            else
                                g.DrawPie(MouseMovePen(), rec, (float)angle1, (float)(360 - (angle1 + angle2)));
                        }
                    }
                    else//圆心从下往上画
                    {
                        if (e.Y < MuiltPoint[0].Y)//当前点在原点上面
                        {
                            if (angle2 < angle1)//画小圆
                            {
                                if (tp == ImageType.Arc)
                                    g.DrawArc(MouseMovePen(), rec, (float)(360 - angle1), (float)(angle1 - angle2));
                                else
                                    g.DrawPie(MouseMovePen(), rec, (float)(360 - angle1), (float)(angle1 - angle2));
                            }
                            else//大的
                            {
                                if (tp == ImageType.Arc)
                                    g.DrawArc(MouseMovePen(), rec, (float)(360 - angle1), (float)(360 + angle1 - angle2));
                                else
                                    g.DrawPie(MouseMovePen(), rec, (float)(360 - angle1), (float)(360 + angle1 - angle2));
                            }
                        }
                        else//当前点在原点下面
                        {
                            if (tp == ImageType.Arc)
                                g.DrawArc(MouseMovePen(), rec, (float)(360 - angle1), (float)(angle1 + angle2));
                            else
                                g.DrawPie(MouseMovePen(), rec, (float)(360 - angle1), (float)(angle1 + angle2));
                        }
                    }
                }
            }
            else
            {
                if (e.Button == MouseButtons.Left)
                {
                    if (curSelect != null)
                    {
                        pb.Refresh();
                        curSelect.DrawRec(pb.CreateGraphics(), e.X-pt_old.X, e.Y-pt_old.Y);
                    }
                }
                else if (e.Button == MouseButtons.None)
                {
                    if (curSelect != null)
                    {
                        if (curSelect.Near(e.X, e.Y))
                            this.Cursor = Cursors.SizeAll;
                        else
                            this.Cursor = Cursors.Default;
                    }
                }
            }
        }
        private void ResetBtn(ToolStripButton bt)
        {
            flag = 0;
            MuiltPoint = new List<Point>();
            igTmp = null;
            if (curSelect != null)
            {
                curSelect.IsNear = false;
                curSelect = null;
            }
            ReDraw(this.pb.CreateGraphics(), false);
            for (int i = 0; i < this.toolStrip1.Items.Count; i++)
            {
                ToolStripButton _tb = toolStrip1.Items[i] as ToolStripButton;
                if (_tb != null)
                {
                    _tb.Checked = false;
                }
            }
            switch (bt.Name)
            {
                case "btnMuiltLine":
                    tp = ImageType.MuiltLine;
                    break;
                case "btnPick":
                    tp = ImageType.Empty;
                    break;
                case "btnLine":
                    tp = ImageType.Line;
                    break;
                case "btnHollowCir":
                    tp = ImageType.HollowCir;
                    break;
                case "btnHollowEllipse":
                    tp = ImageType.HollowEllipse;
                    break;
                case "btnHollowRec":
                    tp = ImageType.HollowRectangle;
                    break;
                case "btnString":
                    tp = ImageType.Text;
                    break;
                case "btnArc":
                    tp = ImageType.Arc;
                    break;
                case "btnPie":
                    tp = ImageType.Pie;
                    break;
                case "btnPolygon":
                    tp = ImageType.Polygon;
                    break;
            }
            bt.Checked = true;
        }
        private void Test_Load(object sender, EventArgs e)
        {
            btn_Click(btnPick, null);
            cboLine.ImageList =  imageBorder;
            cboLine.DropDownStyle = ComboBoxStyle.DropDownList;
            for (int i = 0; i < imageBorder.Images.Count; i++)
            {
                cboLine.Items.Add(new ERM.UI.ComboBoxExItem("", i));
            }
            cboLine.SelectedIndex = 0;
            ColorDialog c = new ColorDialog();
        }
        private void btn_Click(object sender, EventArgs e)
        {
            ToolStripButton btn = (ToolStripButton)sender;
            ResetBtn(btn);
        }
        private void Black_Click(object sender, EventArgs e)
        {
            btnColor.BackColor = ((Button)sender).BackColor;
            if (curSelect != null)
            {
                ChangeCurSelectProperty();
            }
        }
        private void pb_MouseUp(object sender, MouseEventArgs e)
        {
            if (curSelect != null)
            {
                curSelect.pointchange(e.X - pt_old.X, e.Y - pt_old.Y);
                pb.Refresh();
            }
        }
        private void Test_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (curSelect != null)
                {
                    IgList.Remove(curSelect);
                    curSelect = null;
                    pb.Refresh();
                }
            }
        }
        private void ChangeCurSelectProperty()
        {
            curSelect.ChangeProperty(this.btnColor.BackColor, (this.cboLine.SelectedIndex + 1)*zoom/100);
            ReDraw(this.pb.CreateGraphics(), false);
        }
        private void cboLine_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (curSelect != null)
            {
                ChangeCurSelectProperty();
            }
        }
        int zoom = 100;
    }
}
