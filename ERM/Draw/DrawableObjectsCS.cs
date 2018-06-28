using System;
using System.Drawing;
using System.Collections;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Collections.Generic;
namespace ERM.UI
{
    public abstract class DShape
    {
        public bool IsNear = false;
        public abstract void Draw(Graphics g);
        protected Rectangle bounding;
        protected List<Point> pointlist;
        protected Pen pen_Rec = new Pen(Color.LightSkyBlue, 1);
        public DShape(List<Point> p, Color penColor, float penWidth)
        {
            pen_Rec.DashStyle = DashStyle.DashDot;
            this.pointlist = p;
            this.penColor = penColor;
            this.penWidth = penWidth;
            GetBound();        
        }
        public DShape()
        { }
        public virtual void ChangeProperty(Color c,float penwidth)
        {
            this.penColor = c;
            this.penWidth = penwidth;
        }
        public void DrawRec(Graphics g,int x ,int y)
        {
            Rectangle rec = new Rectangle(bounding.X+x, bounding.Y +y,bounding.Width,bounding.Height);
            g.DrawRectangle(new Pen(Color.Red), rec);
        }
        protected abstract void GetBound();
        public virtual void pointchange(int x, int y)
        {
            for (int i = 0; i < pointlist.Count; i++)
            {
                Point p = pointlist[i];
                p.X += x;
                p.Y += y;
                pointlist[i] = p;
            }
            GetBound();
        }
        public virtual bool Near(int x, int y)
        {
            return bounding.Contains(x, y);
        }
        public virtual GraphicsPath pathChange(GraphicsPath path, bool pick)
        {
            return null;
        }
        protected Color penColor;
        protected float penWidth;
    }
    public interface IFillable
    {
        void Fill(Graphics g);
        Color FillBrushColor
        {
            get;
            set;
        }
    }
    public class DPoint : DShape
    {
        public DPoint(List<Point> p, Color penColor, float penWidth):base(p,penColor,penWidth)
        {
        }
        protected override void GetBound()
        {
            bounding = new Rectangle(pointlist[0], new Size((int)penWidth, (int)penWidth));
        }
        public override void pointchange(int x, int y)
        {
            for (int i = 0; i < pointlist.Count; i++)
            {
                Point p = pointlist[i];
                p.X += x;
                p.X += y;
            }
            bounding = new Rectangle(pointlist[0], new Size((int)penWidth, (int)penWidth));
        }
        public override bool Near(int x, int y)
        {
            return this.bounding.Contains(x, y);
        }
        public override void Draw(Graphics g)
        {
            using (Pen p = new Pen(penColor, penWidth))
            {
                g.DrawRectangle(p, bounding);
                if (this.penWidth > 1)
                {
                    using (Brush b = new SolidBrush(penColor))
                    {
                        g.FillRectangle(b, bounding);
                    }
                }
            }
        }
    }
    public class DMuiltLine : DShape
    {
        public DMuiltLine(List<Point> p, Color penColor, float penWidth)
            : base(p, penColor, penWidth)
        {
        }
        protected override  void GetBound()
        {
            int max_x = pointlist[0].X, max_y = pointlist[0].Y, min_x = pointlist[0].X, min_y = pointlist[0].Y;
            for (int i = 1; i < pointlist.Count; i++)
            {
                if (pointlist[i].X < min_x)
                    min_x = pointlist[i].X;
                if (pointlist[i].Y < min_y)
                    min_y = pointlist[i].Y;
                if (pointlist[i].X > max_x)
                    max_x = pointlist[i].X;
                if (pointlist[i].Y > max_y)
                    max_y = pointlist[i].Y;
            }
            this.bounding = Rectangle.FromLTRB(min_x, min_y, max_x, max_y);
        }
        public override void Draw(Graphics g)
        {
            using (Pen p = new Pen(penColor, penWidth))
            {
                for (int i = 1; i < pointlist.Count; i++)
                {
                    g.DrawLine(p, pointlist[i - 1].X, pointlist[i - 1].Y, pointlist[i].X, pointlist[i].Y);
                }
                if (IsNear)
                    g.DrawRectangle(pen_Rec, bounding);
            }
        }
    }
    public class DLine : DShape
    {
        public DLine(List<Point> p, Color penColor, float penWidth)
            : base(p, penColor, penWidth)
        {
        }
        protected override void GetBound()
        {
            int max_x, max_y, min_x, min_y;
            if (pointlist[0].X > pointlist[1].X)
            {
                max_x = pointlist[0].X;
                min_x = pointlist[1].X;
            }
            else
            {
                max_x = pointlist[1].X;
                min_x = pointlist[0].X;
            }
            if (pointlist[0].Y > pointlist[1].Y)
            {
                max_y = pointlist[0].Y;
                min_y = pointlist[1].Y;
            }
            else
            {
                max_y = pointlist[1].Y;
                min_y = pointlist[0].Y;
            }
            bounding = Rectangle.FromLTRB(min_x ,min_y , max_x, max_y );
        }
        public override bool Near(int x, int y)
        {
            return new RectangleF(bounding.X - penWidth, bounding.Y - penWidth, bounding.Width + penWidth*2, bounding.Height + penWidth*2).Contains(x, y);
        }
        public override void Draw(Graphics g)
        {
            using (Pen p = new Pen(penColor, penWidth))
            {
                g.DrawLine(p, this.pointlist[0], this.pointlist[1]);
                if (IsNear)
                    g.DrawRectangle(pen_Rec, bounding);
            }
        }
    }
    public class DHollowCircle : DShape
        {
            public DHollowCircle(List<Point> p, Color penColor, float penWidth)
                : base(p, penColor, penWidth)
            {
            }
            protected  override void GetBound()
            {
                int max_x, max_y, min_x, min_y;
                if (pointlist[0].X > pointlist[1].X)
                {
                    max_x = pointlist[0].X;
                    min_x = pointlist[1].X;
                }
                else
                {
                    max_x = pointlist[1].X;
                    min_x = pointlist[0].X;
                }
                if (pointlist[0].Y > pointlist[1].Y)
                {
                    max_y = pointlist[0].Y;
                    min_y = pointlist[1].Y;
                }
                else
                {
                    max_y = pointlist[1].Y;
                    min_y = pointlist[0].Y;
                }
                int cha_x = max_x - min_x;
                int cha_y = max_y - min_y;
                int dis = Math.Abs(cha_x - cha_y);
                bool b = cha_y > cha_x;
                if (!b)
                {
                    if (pointlist[0].X > pointlist[1].X)
                    {
                        min_x = min_x + dis;
                    }
                    else
                    {
                        max_x = max_x - dis;
                    }
                }
                else
                {
                    if (pointlist[0].Y > pointlist[1].Y)
                    {
                        min_y = min_y + dis;
                    }
                    else
                    {
                        max_y = max_y - dis;
                    }
                }
                bounding = Rectangle.FromLTRB(min_x, min_y, max_x, max_y);
            }
            public override void Draw(Graphics g)
            {
                using (Pen p = new Pen(penColor, penWidth))
                {
                    g.DrawEllipse(p, bounding);
                    if (IsNear)
                        g.DrawRectangle(pen_Rec, bounding);
                }
            }
        }
        public class DHollowEllipse : DShape
        {
            public DHollowEllipse(List<Point> p, Color penColor, float penWidth)
                : base(p, penColor, penWidth)
            {
            }
            protected override  void GetBound()
            {
                int max_x, max_y, min_x, min_y;
                if (pointlist[0].X > pointlist[1].X)
                {
                    max_x = pointlist[0].X;
                    min_x = pointlist[1].X;
                }
                else
                {
                    max_x = pointlist[1].X;
                    min_x = pointlist[0].X;
                }
                if (pointlist[0].Y > pointlist[1].Y)
                {
                    max_y = pointlist[0].Y;
                    min_y = pointlist[1].Y;
                }
                else
                {
                    max_y = pointlist[1].Y;
                    min_y = pointlist[0].Y;
                }
                bounding = Rectangle.FromLTRB(min_x, min_y, max_x, max_y);
            }
            public override void Draw(Graphics g)
            {
                using (Pen p = new Pen(penColor, penWidth))
                {
                    g.DrawEllipse(p, bounding);
                    if (IsNear)
                        g.DrawRectangle(pen_Rec, bounding);
                }
            }
        }
    public class DHollowRectangle : DHollowEllipse
    {
        public DHollowRectangle(List<Point> p, Color penColor, float penWidth)
            : base(p, penColor, penWidth)
        {
        }
        public override void Draw(Graphics g)
        {
            using (Pen p = new Pen(penColor, penWidth))
            {
                g.DrawRectangle(p, bounding);
                if (IsNear)
                    g.DrawRectangle(pen_Rec, bounding);
            }
        }
    }
    ////实心矩形
    ////画路径
    ////橡皮擦
        public class DText : DShape
        {
            protected Color brushColor;
            protected string Text;
            protected Font font;
            public DText(List<Point> p, Color penColor, string Text,  Font font)
            {
                this.pointlist = p;
                this.brushColor = penColor;
                this.Text = Text;
                this.font = font;
                GetBound();
            }
            protected override void GetBound()
            {
                int max_x, max_y, min_x, min_y;
                if (pointlist[0].X > pointlist[1].X)
                {
                    max_x = pointlist[0].X;
                    min_x = pointlist[1].X;
                }
                else
                {
                    max_x = pointlist[1].X;
                    min_x = pointlist[0].X;
                }
                if (pointlist[0].Y > pointlist[1].Y)
                {
                    max_y = pointlist[0].Y;
                    min_y = pointlist[1].Y;
                }
                else
                {
                    max_y = pointlist[1].Y;
                    min_y = pointlist[0].Y;
                }
                bounding = Rectangle.FromLTRB(min_x, min_y, max_x, max_y);
            }
            public override void Draw(Graphics g)
            {
                using (Brush b = new SolidBrush(brushColor))
                {
                    g.TranslateTransform(bounding.Left + bounding.Width /2 , bounding.Top + bounding.Height/2 );
                    g.RotateTransform(0);
                    g.DrawString(Text, font, b,new Rectangle(-bounding.Width/2, -bounding.Height/2, bounding.Width, bounding.Height)/*bounding*/, new StringFormat(StringFormatFlags.NoClip));
                    g.ResetTransform();
                    if (IsNear)
                        g.DrawRectangle(pen_Rec, bounding);
                }
            }
        }
    public class DArc : DShape
    {
        protected double angle1;
        protected double angle2;
        protected Rectangle ArcRec;
        public DArc(List<Point> p, Color penColor, float penWidth):base(p,penColor,penWidth)
        {
        }
        protected override void GetBound()
        {
            angle1 = Math.Abs(Math.Atan2(pointlist[1].Y - pointlist[0].Y, pointlist[1].X - pointlist[0].X) * 180 / Math.PI);
            angle2 = Math.Abs(Math.Atan2(pointlist[2].Y - pointlist[0].Y, pointlist[2].X - pointlist[0].X) * 180 / Math.PI);
            int dist = (int)Math.Sqrt(Math.Pow((pointlist[0].X - pointlist[1].X), 2.0) + Math.Pow((pointlist[0].Y - pointlist[1].Y), 2.0));
            Point _tempt = new Point(pointlist[0].X - dist, pointlist[0].Y - dist);
            int diameter = dist * 2;
            this.ArcRec = new Rectangle(_tempt, new Size(diameter, diameter));
            int max_x = pointlist[0].X, max_y = pointlist[0].Y, min_x = pointlist[0].X, min_y = pointlist[0].Y;
            for (int i = 1; i < pointlist.Count; i++)
            {
                if (pointlist[i].X < min_x)
                    min_x = pointlist[i].X;
                if (pointlist[i].Y < min_y)
                    min_y = pointlist[i].Y;
                if (pointlist[i].X > max_x)
                    max_x = pointlist[i].X;
                if (pointlist[i].Y > max_y)
                    max_y = pointlist[i].Y;
            }
            this.bounding = Rectangle.FromLTRB(min_x, min_y, max_x, max_y);
        }
        public override void Draw(Graphics g)
        {
            using (Pen p = new Pen(penColor, penWidth))
            {
                if (pointlist[1].Y > pointlist[0].Y)//圆心是从上往上画
                {
                    if (pointlist[2].Y > pointlist[0].Y)//当前点在原点下面
                    {
                        if (angle2 < angle1)//画大圆
                        {
                            g.DrawArc(p, ArcRec, (float)angle1, (float)(360 - angle1 + angle2));
                        }
                        else//半截的
                        {
                            g.DrawArc(p, ArcRec, (float)angle1, (float)(angle2 - angle1));
                        }
                    }
                    else//当前点在原点上面
                    {
                        g.DrawArc(p, ArcRec, (float)angle1, (float)(360 - (angle1 + angle2)));
                    }
                }
                else//圆心从下往上画
                {
                    if (pointlist[2].Y < pointlist[0].Y)//当前点在原点上面
                    {
                        if (angle2 < angle1)//画小圆
                        {
                            g.DrawArc(p, ArcRec, (float)(360 - angle1), (float)(angle1 - angle2));
                        }
                        else//大的
                        {
                            g.DrawArc(p, ArcRec, (float)(360 - angle1), (float)(360 + angle1 - angle2));
                        }
                    }
                    else//当前点在原点下面
                    {
                        g.DrawArc(p, ArcRec, (float)(360 - angle1), (float)(angle1 + angle2));
                    }
                }
                if (IsNear)
                    g.DrawRectangle(pen_Rec, bounding);
            }
        }
    }
    public class DPie : DArc
    {
        public DPie(List<Point> p, Color penColor, float penWidth)
            : base(p, penColor, penWidth)
        { }
        public override void Draw(Graphics g)
        {
            using (Pen p = new Pen(penColor, penWidth))
            {
                if (pointlist[1].Y > pointlist[0].Y)//圆心是从上往上画
                {
                    if (pointlist[2].Y > pointlist[0].Y)//当前点在原点下面
                    {
                        if (angle2 < angle1)//画大圆
                        {
                            g.DrawPie(p, ArcRec, (float)angle1, (float)(360 - angle1 + angle2));
                        }
                        else//半截的
                        {
                            g.DrawPie(p, ArcRec, (float)angle1, (float)(angle2 - angle1));
                        }
                    }
                    else//当前点在原点上面
                    {
                        g.DrawPie(p, ArcRec, (float)angle1, (float)(360 - (angle1 + angle2)));
                    }
                }
                else//圆心从下往上画
                {
                    if (pointlist[2].Y < pointlist[0].Y)//当前点在原点上面
                    {
                        if (angle2 < angle1)//画小圆
                        {
                            g.DrawPie(p, ArcRec, (float)(360 - angle1), (float)(angle1 - angle2));
                        }
                        else//大的
                        {
                            g.DrawPie(p, ArcRec, (float)(360 - angle1), (float)(360 + angle1 - angle2));
                        }
                    }
                    else//当前点在原点下面
                    {
                        g.DrawPie(p, ArcRec, (float)(360 - angle1), (float)(angle1 + angle2));
                    }
                }
                if(IsNear)
                    g.DrawRectangle(pen_Rec, bounding);
            }
        }
    }
    public class DPolygon : DShape
    {
        public DPolygon(List<Point> p, Color penColor, float penWidth):base (p,penColor,penWidth)
        {
            ps = new Point[p.Count];
            p.CopyTo(ps);
        }
        protected override void GetBound()
        {
            int max_x = pointlist[0].X, max_y = pointlist[0].Y, min_x = pointlist[0].X, min_y = pointlist[0].Y;
            for (int i = 1; i < pointlist.Count; i++)
            {
                if (pointlist[i].X < min_x)
                    min_x = pointlist[i].X;
                if (pointlist[i].Y < min_y)
                    min_y = pointlist[i].Y;
                if (pointlist[i].X > max_x)
                    max_x = pointlist[i].X;
                if (pointlist[i].Y > max_y)
                    max_y = pointlist[i].Y;
            }
            this.bounding = Rectangle.FromLTRB(min_x, min_y, max_x, max_y);
        }
        Point[] ps;
        public override void pointchange(int x, int y)
        {
            base.pointchange(x, y);
            pointlist.CopyTo(ps);
        }
        public override void Draw(Graphics g)
        {
            using (Pen p = new Pen(penColor, penWidth))
            {
                g.DrawPolygon(p, ps);
                if (IsNear)
                    g.DrawRectangle(pen_Rec, bounding);
            }
        }
    }
    ////基数样条
    ////闭合样条
    ////Beziers
    ////图像
    public class DShapeList : CollectionBase
    {
        DrawCollection wholeList = new DrawCollection();
        public new int Count
        {
            get
            {
                return wholeList.Count;
            }
        }
        public void Add(DShape d)
        {
            wholeList.Add(d);
        }
        public new void RemoveAt(int i)
        {
            wholeList.RemoveAt(i);
        }
        public void Remove(DShape d)
        {
            for (int i = 0; i < wholeList.Count; i++)
            {
                if (wholeList[i] == d)
                {
                    wholeList.RemoveAt(i);
                    return;
                }
            }
        }
        public DShape this[int newshapeIndex]
        {
            get
            {
                return (DShape)wholeList[newshapeIndex];
            }
            set
            {
                wholeList[newshapeIndex] = value;
            }
        }
        public void DrawList(Graphics g)
        {
            if (wholeList.Count != 0)
            {
                foreach (DShape d in wholeList)
                    d.Draw(g);
            }
        }
        public DShape GetNear(int x, int y)
        {
            for (int i = this.Count - 1; i >= 0; i--)
            {
                if (this[i].Near(x, y))
                    return this[i];
            }
            return null;
        }
    }
    public class DrawCollection : CollectionBase
    {
        public void Add(DShape d)
        {
            List.Add(d);
        }
        public new void RemoveAt(int i)
        {
            List.RemoveAt(i);
        }
        public DShape this[int shapeIndex]
        {
            get
            {
                return (DShape)List[shapeIndex];
            }
            set
            {
                List[shapeIndex] = value;
            }
        }
    }
    public class NewRegion : CollectionBase
        {
            public Region this[int regionIndex]
            {
                get
                {
                    return (Region)List[regionIndex];
                }
                set
                {
                    List[regionIndex] = value;
                }
            }
            public void Add(Region newRegion)
            {
                List.Add(newRegion);
            }
            public new void RemoveAt(int i)
            {
                List.RemoveAt(i);
            }
            public void Remove(Region oldRegion)
            {
                List.Remove(oldRegion);
            }
            public NewRegion()
            {
            }
        }
    public class NewRegionArray : CollectionBase
    {
        public Region[] this[int regionIndex]
        {
            get
            {
                return (Region[])List[regionIndex];
            }
            set
            {
                List[regionIndex] = value;
            }
        }
        public void Add(Region[] newRegion)
        {
            List.Add(newRegion);
        }
        public void Remove(Region[] oldRegion)
        {
            List.Remove(oldRegion);
        }
        public new void RemoveAt(int i)
        {
            List.RemoveAt(i);
        }
        public NewRegionArray()
        {
        }
    }
    public class PointCollection : CollectionBase
    {
        public Point this[int pointIndex]
        {
            get
            {
                return (Point)List[pointIndex];
            }
            set
            {
                List[pointIndex] = value;
            }
        }
        public void Add(Point newPoint)
        {
            List.Add(newPoint);
        }
        public void RemoveRange(int x, int y)
        {
            for (int i = y - 1; i >= 0; i--)
            {
                List.RemoveAt(i);
            }
        }
        public void AddRange(List<Point> point)
        {
            foreach (Point p in point)
            {
                List.Add(p);
            }
        }
        public PointCollection()
        {
        }
    }
    public class PointArrayCollection : CollectionBase
    {
        public List<Point> this[int pointIndex]
        {
            get
            {
                return (List<Point>)List[pointIndex];
            }
            set
            {
                List[pointIndex] = value;
            }
        }
        public void Add(List<Point> newPointArray)
        {
            List.Add(newPointArray);
        }
        public void RemoveRange(int x, int y)
        {
            for (int i = y - 1; i >= 0; i--)
            {
                List.RemoveAt(i);
            }
        }
        /*public void AddRange(List<Point> point)
        {
            foreach(Point p in point)
            {
                List.Add(p);
            }
        } */
        public PointArrayCollection()
        {
        }
    }
    public class Number : CollectionBase
    {
        public int this[int intIndex]
        {
            get
            {
                return (int)List[intIndex];
            }
            set
            {
                List[intIndex] = value;
            }
        }
        public void Add(int i)
        {
            List.Add(i);
        }
    }
    }
