using CCWin.SkinControl;
using ERM.UI.Controls;
using TX.Framework.WindowUI.Controls;
namespace ERM.UI
{
    partial class frmDelInfo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDelInfo));
            this.panel1 = new ERM.UI.Controls.SkinPanelEX();
            this.panel2 = new ERM.UI.Controls.SkinPanelEX();
            this.tv_Info = new System.Windows.Forms.TreeView();
            this.imgList = new System.Windows.Forms.ImageList(this.components);
            this.label1 = new ERM.UI.Controls.SkinLabelEX();
            this.btn_Close = new ERM.UI.Controls.SkinButtonEX();
            this.btn_OK = new ERM.UI.Controls.SkinButtonEX();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btn_Close);
            this.panel1.Controls.Add(this.btn_OK);
            this.panel1.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.DownBack = null;
            this.panel1.Location = new System.Drawing.Point(4, 34);
            this.panel1.MouseBack = null;
            this.panel1.Name = "panel1";
            this.panel1.NormlBack = null;
            this.panel1.Radius = 4;
            this.panel1.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.panel1.Size = new System.Drawing.Size(945, 601);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel2.Controls.Add(this.tv_Info);
            this.panel2.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.DownBack = null;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.MouseBack = null;
            this.panel2.Name = "panel2";
            this.panel2.NormlBack = null;
            this.panel2.Radius = 4;
            this.panel2.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.panel2.Size = new System.Drawing.Size(945, 537);
            this.panel2.TabIndex = 4;
            // 
            // tv_Info
            // 
            this.tv_Info.CheckBoxes = true;
            this.tv_Info.ImageIndex = 1;
            this.tv_Info.ImageList = this.imgList;
            this.tv_Info.Location = new System.Drawing.Point(-2, 0);
            this.tv_Info.Margin = new System.Windows.Forms.Padding(4);
            this.tv_Info.Name = "tv_Info";
            this.tv_Info.SelectedImageIndex = 1;
            this.tv_Info.Size = new System.Drawing.Size(947, 537);
            this.tv_Info.TabIndex = 0;
            // 
            // imgList
            // 
            this.imgList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgList.ImageStream")));
            this.imgList.TransparentColor = System.Drawing.Color.Fuchsia;
            this.imgList.Images.SetKeyName(0, "tree_home.png");
            this.imgList.Images.SetKeyName(1, "tree_folder.png");
            this.imgList.Images.SetKeyName(2, "tree_file.bmp");
            this.imgList.Images.SetKeyName(3, "tree_cell.bmp");
            this.imgList.Images.SetKeyName(4, "tree_cell_lock.bmp");
            this.imgList.Images.SetKeyName(5, "tree_file_s.bmp");
            this.imgList.Images.SetKeyName(6, "tree_folder_s.bmp");
            this.imgList.Images.SetKeyName(7, "tree_efile.bmp");
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.BorderColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(12, 541);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(295, 48);
            this.label1.TabIndex = 7;
            this.label1.Text = "提示：已经组卷的文件不允许修改！";
            // 
            // btn_Close
            // 
            this.btn_Close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_Close.BackColor = System.Drawing.Color.Transparent;
            this.btn_Close.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_Close.BackgroundImage")));
            this.btn_Close.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_Close.BackRectangle = new System.Drawing.Rectangle(59, 23, 59, 23);
            this.btn_Close.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(168)))), ((int)(((byte)(213)))));
            this.btn_Close.BorderColor = System.Drawing.Color.Transparent;
            this.btn_Close.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btn_Close.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Close.DownBack = null;
            this.btn_Close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Close.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.btn_Close.ForeColor = System.Drawing.Color.Black;
            this.btn_Close.GlowColor = System.Drawing.Color.Transparent;
            this.btn_Close.InnerBorderColor = System.Drawing.Color.White;
            this.btn_Close.Location = new System.Drawing.Point(450, 561);
            this.btn_Close.Margin = new System.Windows.Forms.Padding(0);
            this.btn_Close.MouseBack = null;
            this.btn_Close.MouseBaseColor = System.Drawing.Color.SkyBlue;
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.NormlBack = null;
            this.btn_Close.Palace = true;
            this.btn_Close.Radius = 10;
            this.btn_Close.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.btn_Close.Size = new System.Drawing.Size(70, 28);
            this.btn_Close.TabIndex = 6;
            this.btn_Close.TabStop = false;
            this.btn_Close.Text = "取消";
            this.btn_Close.UseVisualStyleBackColor = false;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // btn_OK
            // 
            this.btn_OK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_OK.BackColor = System.Drawing.Color.Transparent;
            this.btn_OK.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_OK.BackgroundImage")));
            this.btn_OK.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_OK.BackRectangle = new System.Drawing.Rectangle(59, 23, 59, 23);
            this.btn_OK.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(168)))), ((int)(((byte)(213)))));
            this.btn_OK.BorderColor = System.Drawing.Color.Transparent;
            this.btn_OK.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btn_OK.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_OK.DownBack = null;
            this.btn_OK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_OK.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.btn_OK.ForeColor = System.Drawing.Color.Black;
            this.btn_OK.GlowColor = System.Drawing.Color.Transparent;
            this.btn_OK.InnerBorderColor = System.Drawing.Color.White;
            this.btn_OK.Location = new System.Drawing.Point(365, 561);
            this.btn_OK.Margin = new System.Windows.Forms.Padding(0);
            this.btn_OK.MouseBack = null;
            this.btn_OK.MouseBaseColor = System.Drawing.Color.SkyBlue;
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.NormlBack = null;
            this.btn_OK.Palace = true;
            this.btn_OK.Radius = 10;
            this.btn_OK.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.btn_OK.Size = new System.Drawing.Size(70, 28);
            this.btn_OK.TabIndex = 5;
            this.btn_OK.TabStop = false;
            this.btn_OK.Text = "删除";
            this.btn_OK.UseVisualStyleBackColor = false;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // frmDelInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::ERM.UI.Properties.Resources.panel2_BackgroundImage;
            this.ClientSize = new System.Drawing.Size(953, 639);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            this.MaximizeBox = false;
            this.Name = "frmDelInfo";
            this.Text = "批量删除";
            this.Shown += new System.EventHandler(this.frmDelInfo_Shown);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private SkinPanelEX panel1;
        private SkinPanelEX panel2;
        private System.Windows.Forms.TreeView tv_Info;
        private System.Windows.Forms.ImageList imgList;
        private Controls.SkinLabelEX label1;
        private Controls.SkinButtonEX btn_Close;
        private Controls.SkinButtonEX btn_OK;

    }
}