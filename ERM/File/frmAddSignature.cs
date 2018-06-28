using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ERM.Common;
using System.Xml;
namespace ERM.UI
{
    public partial class frmAddSignature : Form
    {
        private Point mouse_offset;
        bool IsClick = false;
        Point p;
        public frmAddSignature()
        {
            InitializeComponent();
            this.drpSingtrueModel.Text = Globals.SignatureModel;
            this.pictureBox1.Location = new Point(Convert.ToInt32(Globals.SignatureModelPositionX), Convert.ToInt32(Globals.SignatureModelPositionY));
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            Globals.SignatureModelPositionX = p.X.ToString();
            Globals.SignatureModelPositionY = p.Y.ToString();
            Globals.SignatureModel = this.drpSingtrueModel.Text;
            this.Close();
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            mouse_offset = new Point(-e.X, -e.Y);
        }
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            ((Control)sender).Cursor = Cursors.Arrow;//设置拖动时鼠标箭头
            if (e.Button == MouseButtons.Left)
            {
                Point mousePos = Control.MousePosition;
                mousePos.Offset(mouse_offset.X, mouse_offset.Y);//设置偏移
                Point PointNow = ((Control)sender).Parent.PointToClient(mousePos);
                if (PointNow.X > 300-this.pictureBox1.Width)
                {
                    PointNow.X = (300-this.pictureBox1.Width-3);
                }
                if (PointNow.Y > 400-this.pictureBox1.Height)
                {
                    PointNow.Y = (400 - this.pictureBox1.Height-3);
                }
                if (PointNow.X < 1)
                {
                    PointNow.X = 1; 
                }
                if (PointNow.Y < 1)
                {
                    PointNow.Y = 1;
                }
                ((Control)sender).Location = PointNow;
                p = PointNow;
            }
        }
    }
}
