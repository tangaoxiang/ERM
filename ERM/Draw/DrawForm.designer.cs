namespace ERM.UI
{
    partial class DrawForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DrawForm));
            this.pb = new System.Windows.Forms.PictureBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnPick = new System.Windows.Forms.ToolStripButton();
            this.btnLine = new System.Windows.Forms.ToolStripButton();
            this.btnMuiltLine = new System.Windows.Forms.ToolStripButton();
            this.btnHollowCir = new System.Windows.Forms.ToolStripButton();
            this.btnHollowEllipse = new System.Windows.Forms.ToolStripButton();
            this.btnHollowRec = new System.Windows.Forms.ToolStripButton();
            this.btnString = new System.Windows.Forms.ToolStripButton();
            this.btnArc = new System.Windows.Forms.ToolStripButton();
            this.btnPie = new System.Windows.Forms.ToolStripButton();
            this.btnPolygon = new System.Windows.Forms.ToolStripButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.Black = new System.Windows.Forms.Button();
            this.btnColor = new System.Windows.Forms.Button();
            this.MoreColor = new System.Windows.Forms.Button();
            this.Red = new System.Windows.Forms.Button();
            this.Yellow = new System.Windows.Forms.Button();
            this.blue = new System.Windows.Forms.Button();
            this.Cyan = new System.Windows.Forms.Button();
            this.White = new System.Windows.Forms.Button();
            this.Magenta = new System.Windows.Forms.Button();
            this.LawnGreen = new System.Windows.Forms.Button();
            this.cboLine = new ERM.UI.ComboBoxEx();
            this.imageBorder = new System.Windows.Forms.ImageList(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pb)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pb
            // 
            this.pb.BackColor = System.Drawing.Color.White;
            this.pb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pb.Location = new System.Drawing.Point(61, 3);
            this.pb.Name = "pb";
            this.pb.Size = new System.Drawing.Size(441, 197);
            this.pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb.TabIndex = 1;
            this.pb.TabStop = false;
            this.pb.MouseLeave += new System.EventHandler(this.pb_MouseLeave);
            this.pb.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pb_MouseDown);
            this.pb.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pb_MouseMove);
            this.pb.Paint += new System.Windows.Forms.PaintEventHandler(this.pb_Paint);
            this.pb.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pb_MouseUp);
            this.pb.MouseEnter += new System.EventHandler(this.pb_MouseEnter);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Left;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnPick,
            this.btnLine,
            this.btnMuiltLine,
            this.btnHollowCir,
            this.btnHollowEllipse,
            this.btnHollowRec,
            this.btnString,
            this.btnArc,
            this.btnPie,
            this.btnPolygon});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(58, 203);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnPick
            // 
            this.btnPick.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnPick.Image = ((System.Drawing.Image)(resources.GetObject("btnPick.Image")));
            this.btnPick.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPick.Name = "btnPick";
            this.btnPick.Size = new System.Drawing.Size(55, 16);
            this.btnPick.Text = "光标";
            this.btnPick.Click += new System.EventHandler(this.btn_Click);
            // 
            // btnLine
            // 
            this.btnLine.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnLine.Image = ((System.Drawing.Image)(resources.GetObject("btnLine.Image")));
            this.btnLine.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLine.Name = "btnLine";
            this.btnLine.Size = new System.Drawing.Size(55, 16);
            this.btnLine.Text = "线";
            this.btnLine.Click += new System.EventHandler(this.btn_Click);
            // 
            // btnMuiltLine
            // 
            this.btnMuiltLine.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnMuiltLine.Image = ((System.Drawing.Image)(resources.GetObject("btnMuiltLine.Image")));
            this.btnMuiltLine.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnMuiltLine.Name = "btnMuiltLine";
            this.btnMuiltLine.Size = new System.Drawing.Size(55, 16);
            this.btnMuiltLine.Text = "多条线";
            this.btnMuiltLine.Click += new System.EventHandler(this.btn_Click);
            // 
            // btnHollowCir
            // 
            this.btnHollowCir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnHollowCir.Image = ((System.Drawing.Image)(resources.GetObject("btnHollowCir.Image")));
            this.btnHollowCir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnHollowCir.Name = "btnHollowCir";
            this.btnHollowCir.Size = new System.Drawing.Size(55, 16);
            this.btnHollowCir.Text = "空心圆";
            this.btnHollowCir.Click += new System.EventHandler(this.btn_Click);
            // 
            // btnHollowEllipse
            // 
            this.btnHollowEllipse.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnHollowEllipse.Image = ((System.Drawing.Image)(resources.GetObject("btnHollowEllipse.Image")));
            this.btnHollowEllipse.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnHollowEllipse.Name = "btnHollowEllipse";
            this.btnHollowEllipse.Size = new System.Drawing.Size(55, 16);
            this.btnHollowEllipse.Text = "椭圆";
            this.btnHollowEllipse.Click += new System.EventHandler(this.btn_Click);
            // 
            // btnHollowRec
            // 
            this.btnHollowRec.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnHollowRec.Image = ((System.Drawing.Image)(resources.GetObject("btnHollowRec.Image")));
            this.btnHollowRec.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnHollowRec.Name = "btnHollowRec";
            this.btnHollowRec.Size = new System.Drawing.Size(55, 16);
            this.btnHollowRec.Text = "空心矩形";
            this.btnHollowRec.Click += new System.EventHandler(this.btn_Click);
            // 
            // btnString
            // 
            this.btnString.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnString.Image = ((System.Drawing.Image)(resources.GetObject("btnString.Image")));
            this.btnString.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnString.Name = "btnString";
            this.btnString.Size = new System.Drawing.Size(55, 16);
            this.btnString.Text = "文本";
            this.btnString.Click += new System.EventHandler(this.btn_Click);
            // 
            // btnArc
            // 
            this.btnArc.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnArc.Image = ((System.Drawing.Image)(resources.GetObject("btnArc.Image")));
            this.btnArc.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnArc.Name = "btnArc";
            this.btnArc.Size = new System.Drawing.Size(55, 16);
            this.btnArc.Text = "画弧";
            this.btnArc.Click += new System.EventHandler(this.btn_Click);
            // 
            // btnPie
            // 
            this.btnPie.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnPie.Image = ((System.Drawing.Image)(resources.GetObject("btnPie.Image")));
            this.btnPie.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPie.Name = "btnPie";
            this.btnPie.Size = new System.Drawing.Size(55, 16);
            this.btnPie.Text = "扇形";
            this.btnPie.Click += new System.EventHandler(this.btn_Click);
            // 
            // btnPolygon
            // 
            this.btnPolygon.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnPolygon.Image = ((System.Drawing.Image)(resources.GetObject("btnPolygon.Image")));
            this.btnPolygon.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPolygon.Name = "btnPolygon";
            this.btnPolygon.Size = new System.Drawing.Size(55, 16);
            this.btnPolygon.Text = "多边形";
            this.btnPolygon.Click += new System.EventHandler(this.btn_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.toolStrip1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.pb, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 117F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(505, 320);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.cboLine);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(61, 206);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(441, 111);
            this.panel1.TabIndex = 4;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.Black);
            this.panel2.Controls.Add(this.btnColor);
            this.panel2.Controls.Add(this.MoreColor);
            this.panel2.Controls.Add(this.Red);
            this.panel2.Controls.Add(this.Yellow);
            this.panel2.Controls.Add(this.blue);
            this.panel2.Controls.Add(this.Cyan);
            this.panel2.Controls.Add(this.White);
            this.panel2.Controls.Add(this.Magenta);
            this.panel2.Controls.Add(this.LawnGreen);
            this.panel2.Location = new System.Drawing.Point(123, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(207, 50);
            this.panel2.TabIndex = 33;
            // 
            // Black
            // 
            this.Black.BackColor = System.Drawing.Color.Black;
            this.Black.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Black.Location = new System.Drawing.Point(48, 25);
            this.Black.Name = "Black";
            this.Black.Size = new System.Drawing.Size(15, 15);
            this.Black.TabIndex = 0;
            this.Black.UseVisualStyleBackColor = false;
            this.Black.Click += new System.EventHandler(this.Black_Click);
            // 
            // btnColor
            // 
            this.btnColor.BackColor = System.Drawing.Color.Black;
            this.btnColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnColor.Location = new System.Drawing.Point(3, 11);
            this.btnColor.Name = "btnColor";
            this.btnColor.Size = new System.Drawing.Size(36, 24);
            this.btnColor.TabIndex = 32;
            this.btnColor.UseVisualStyleBackColor = false;
            // 
            // MoreColor
            // 
            this.MoreColor.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.MoreColor.Location = new System.Drawing.Point(148, 11);
            this.MoreColor.Name = "MoreColor";
            this.MoreColor.Size = new System.Drawing.Size(50, 26);
            this.MoreColor.TabIndex = 30;
            this.MoreColor.Text = "More>>";
            this.MoreColor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.MoreColor.UseVisualStyleBackColor = false;
            // 
            // Red
            // 
            this.Red.BackColor = System.Drawing.Color.Red;
            this.Red.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Red.Location = new System.Drawing.Point(120, 25);
            this.Red.Name = "Red";
            this.Red.Size = new System.Drawing.Size(15, 15);
            this.Red.TabIndex = 2;
            this.Red.UseVisualStyleBackColor = false;
            this.Red.Click += new System.EventHandler(this.Black_Click);
            // 
            // Yellow
            // 
            this.Yellow.BackColor = System.Drawing.Color.Yellow;
            this.Yellow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Yellow.Location = new System.Drawing.Point(120, 4);
            this.Yellow.Name = "Yellow";
            this.Yellow.Size = new System.Drawing.Size(15, 15);
            this.Yellow.TabIndex = 28;
            this.Yellow.UseVisualStyleBackColor = false;
            this.Yellow.Click += new System.EventHandler(this.Black_Click);
            // 
            // blue
            // 
            this.blue.BackColor = System.Drawing.Color.Blue;
            this.blue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.blue.Location = new System.Drawing.Point(72, 25);
            this.blue.Name = "blue";
            this.blue.Size = new System.Drawing.Size(15, 15);
            this.blue.TabIndex = 3;
            this.blue.UseVisualStyleBackColor = false;
            this.blue.Click += new System.EventHandler(this.Black_Click);
            // 
            // Cyan
            // 
            this.Cyan.BackColor = System.Drawing.Color.Cyan;
            this.Cyan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Cyan.Location = new System.Drawing.Point(96, 4);
            this.Cyan.Name = "Cyan";
            this.Cyan.Size = new System.Drawing.Size(15, 15);
            this.Cyan.TabIndex = 30;
            this.Cyan.UseVisualStyleBackColor = false;
            this.Cyan.Click += new System.EventHandler(this.Black_Click);
            // 
            // White
            // 
            this.White.BackColor = System.Drawing.Color.White;
            this.White.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.White.Location = new System.Drawing.Point(48, 4);
            this.White.Name = "White";
            this.White.Size = new System.Drawing.Size(15, 15);
            this.White.TabIndex = 1;
            this.White.UseVisualStyleBackColor = false;
            this.White.Click += new System.EventHandler(this.Black_Click);
            // 
            // Magenta
            // 
            this.Magenta.BackColor = System.Drawing.Color.Magenta;
            this.Magenta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Magenta.Location = new System.Drawing.Point(96, 25);
            this.Magenta.Name = "Magenta";
            this.Magenta.Size = new System.Drawing.Size(15, 15);
            this.Magenta.TabIndex = 31;
            this.Magenta.UseVisualStyleBackColor = false;
            this.Magenta.Click += new System.EventHandler(this.Black_Click);
            // 
            // LawnGreen
            // 
            this.LawnGreen.BackColor = System.Drawing.Color.LawnGreen;
            this.LawnGreen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LawnGreen.Location = new System.Drawing.Point(72, 4);
            this.LawnGreen.Name = "LawnGreen";
            this.LawnGreen.Size = new System.Drawing.Size(15, 15);
            this.LawnGreen.TabIndex = 29;
            this.LawnGreen.UseVisualStyleBackColor = false;
            this.LawnGreen.Click += new System.EventHandler(this.Black_Click);
            // 
            // cboLine
            // 
            this.cboLine.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboLine.FormattingEnabled = true;
            this.cboLine.ImageList = null;
            this.cboLine.Location = new System.Drawing.Point(3, 3);
            this.cboLine.Name = "cboLine";
            this.cboLine.Size = new System.Drawing.Size(105, 22);
            this.cboLine.TabIndex = 3;
            this.cboLine.SelectedIndexChanged += new System.EventHandler(this.cboLine_SelectedIndexChanged);
            // 
            // imageBorder
            // 
            this.imageBorder.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageBorder.ImageStream")));
            this.imageBorder.TransparentColor = System.Drawing.Color.White;
            this.imageBorder.Images.SetKeyName(0, "");
            this.imageBorder.Images.SetKeyName(1, "");
            this.imageBorder.Images.SetKeyName(2, "");
            // 
            // DrawForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(505, 320);
            this.Controls.Add(this.tableLayoutPanel1);
            this.KeyPreview = true;
            this.Name = "DrawForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DrawForm";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Test_KeyDown);
            this.Load += new System.EventHandler(this.Test_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pb)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pb;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnLine;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ToolStripButton btnPick;
        private System.Windows.Forms.ToolStripButton btnMuiltLine;
        private System.Windows.Forms.ToolStripButton btnHollowCir;
        private System.Windows.Forms.ToolStripButton btnHollowEllipse;
        private System.Windows.Forms.ToolStripButton btnHollowRec;
        private System.Windows.Forms.ToolStripButton btnString;
        private System.Windows.Forms.ToolStripButton btnArc;
        private System.Windows.Forms.ToolStripButton btnPie;
        private System.Windows.Forms.ToolStripButton btnPolygon;
        private ERM.UI.ComboBoxEx cboLine;
        private System.Windows.Forms.ImageList imageBorder;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button blue;
        private System.Windows.Forms.Button Red;
        private System.Windows.Forms.Button btnColor;
        private System.Windows.Forms.Button Magenta;
        private System.Windows.Forms.Button White;
        private System.Windows.Forms.Button Black;
        private System.Windows.Forms.Button Yellow;
        private System.Windows.Forms.Button LawnGreen;
        private System.Windows.Forms.Button Cyan;
        private System.Windows.Forms.Button MoreColor;
        private System.Windows.Forms.Panel panel2;
    }
}