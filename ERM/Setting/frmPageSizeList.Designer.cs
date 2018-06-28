using CCWin.SkinControl;
using ERM.UI.Controls;
namespace ERM.UI
{
    partial class frmPageSizeList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPageSizeList));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tsList = new ERM.UI.Controls.Skin_ToolStripEX();
            this.tsAdd = new System.Windows.Forms.ToolStripButton();
            this.tsEdit = new System.Windows.Forms.ToolStripButton();
            this.tsDelete = new System.Windows.Forms.ToolStripButton();
            this.tsClose = new System.Windows.Forms.ToolStripButton();
            this.dgPageSize = new ERM.UI.Controls.Skin_DataGridEX();
            this.tsList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgPageSize)).BeginInit();
            this.SuspendLayout();
            // 
            // tsList
            // 
            this.tsList.Arrow = System.Drawing.Color.Black;
            this.tsList.AutoSize = false;
            this.tsList.Back = System.Drawing.Color.White;
            this.tsList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(240)))), ((int)(((byte)(255)))));
            this.tsList.BackgroundImage = global::ERM.UI.Properties.Resources.about_bg;
            this.tsList.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tsList.BackRadius = 4;
            this.tsList.BackRectangle = new System.Drawing.Rectangle(10, 10, 10, 10);
            this.tsList.Base = System.Drawing.Color.Empty;
            this.tsList.BaseFore = System.Drawing.Color.Black;
            this.tsList.BaseForeAnamorphosis = false;
            this.tsList.BaseForeAnamorphosisBorder = 4;
            this.tsList.BaseForeAnamorphosisColor = System.Drawing.Color.White;
            this.tsList.BaseForeOffset = new System.Drawing.Point(0, 0);
            this.tsList.BaseHoverFore = System.Drawing.Color.Black;
            this.tsList.BaseItemAnamorphosis = true;
            this.tsList.BaseItemBorder = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.tsList.BaseItemBorderShow = true;
            this.tsList.BaseItemDown = ((System.Drawing.Image)(resources.GetObject("tsList.BaseItemDown")));
            this.tsList.BaseItemHover = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.tsList.BaseItemMouse = ((System.Drawing.Image)(resources.GetObject("tsList.BaseItemMouse")));
            this.tsList.BaseItemNorml = null;
            this.tsList.BaseItemPressed = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.tsList.BaseItemRadius = 4;
            this.tsList.BaseItemRadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.tsList.BaseItemSplitter = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.tsList.BindTabControl = null;
            this.tsList.CanOverflow = false;
            this.tsList.DropDownImageSeparator = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.tsList.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tsList.Fore = System.Drawing.Color.Black;
            this.tsList.GripMargin = new System.Windows.Forms.Padding(2, 2, 4, 2);
            this.tsList.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsList.HoverFore = System.Drawing.Color.Black;
            this.tsList.ItemAnamorphosis = true;
            this.tsList.ItemBorder = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.tsList.ItemBorderShow = true;
            this.tsList.ItemHover = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.tsList.ItemPressed = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.tsList.ItemRadius = 4;
            this.tsList.ItemRadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.tsList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsAdd,
            this.tsEdit,
            this.tsDelete,
            this.tsClose});
            this.tsList.Location = new System.Drawing.Point(4, 34);
            this.tsList.Name = "tsList";
            this.tsList.RadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.tsList.Size = new System.Drawing.Size(543, 40);
            this.tsList.SkinAllColor = true;
            this.tsList.Stretch = true;
            this.tsList.TabIndex = 9;
            this.tsList.TitleAnamorphosis = true;
            this.tsList.TitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(228)))), ((int)(((byte)(236)))));
            this.tsList.TitleRadius = 4;
            this.tsList.TitleRadiusStyle = CCWin.SkinClass.RoundStyle.All;
            // 
            // tsAdd
            // 
            this.tsAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tsAdd.Image = global::ERM.UI.Properties.Resources.Page_Add;
            this.tsAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsAdd.Name = "tsAdd";
            this.tsAdd.Size = new System.Drawing.Size(54, 37);
            this.tsAdd.Text = "新增(N)";
            this.tsAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsAdd.Click += new System.EventHandler(this.tsAdd_Click);
            // 
            // tsEdit
            // 
            this.tsEdit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tsEdit.Image = global::ERM.UI.Properties.Resources.Page_Edit;
            this.tsEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsEdit.Name = "tsEdit";
            this.tsEdit.Size = new System.Drawing.Size(51, 37);
            this.tsEdit.Text = "编辑(E)";
            this.tsEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsEdit.Click += new System.EventHandler(this.tsEdit_Click);
            // 
            // tsDelete
            // 
            this.tsDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tsDelete.Image = global::ERM.UI.Properties.Resources.Page_Delete;
            this.tsDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsDelete.Name = "tsDelete";
            this.tsDelete.Size = new System.Drawing.Size(53, 37);
            this.tsDelete.Text = "删除(D)";
            this.tsDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsDelete.Click += new System.EventHandler(this.tsDelete_Click);
            // 
            // tsClose
            // 
            this.tsClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tsClose.Image = global::ERM.UI.Properties.Resources.Page_Close;
            this.tsClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsClose.Name = "tsClose";
            this.tsClose.Size = new System.Drawing.Size(36, 37);
            this.tsClose.Text = "退出";
            this.tsClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsClose.Click += new System.EventHandler(this.tsClose_Click);
            // 
            // dgPageSize
            // 
            this.dgPageSize.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            this.dgPageSize.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgPageSize.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgPageSize.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgPageSize.BackgroundColor = System.Drawing.Color.White;
            this.dgPageSize.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgPageSize.ColumnFont = null;
            this.dgPageSize.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(246)))), ((int)(((byte)(239)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(235)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgPageSize.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgPageSize.ColumnHeadersHeight = 26;
            this.dgPageSize.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgPageSize.ColumnSelectBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(215)))), ((int)(((byte)(244)))));
            this.dgPageSize.ColumnSelectForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(188)))), ((int)(((byte)(240)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgPageSize.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgPageSize.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgPageSize.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgPageSize.EnableHeadersVisualStyles = false;
            this.dgPageSize.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dgPageSize.GridColor = System.Drawing.Color.Gainsboro;
            this.dgPageSize.HeadFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dgPageSize.HeadSelectBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(235)))), ((int)(((byte)(252)))));
            this.dgPageSize.HeadSelectForeColor = System.Drawing.SystemColors.ControlText;
            this.dgPageSize.LineNumberForeColor = System.Drawing.Color.Black;
            this.dgPageSize.Location = new System.Drawing.Point(4, 74);
            this.dgPageSize.MultiSelect = false;
            this.dgPageSize.Name = "dgPageSize";
            this.dgPageSize.ReadOnly = true;
            this.dgPageSize.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgPageSize.RowHeadersVisible = false;
            this.dgPageSize.RowHeadersWidth = 22;
            this.dgPageSize.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(215)))), ((int)(((byte)(244)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            this.dgPageSize.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgPageSize.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgPageSize.RowTemplate.Height = 25;
            this.dgPageSize.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgPageSize.Size = new System.Drawing.Size(543, 351);
            this.dgPageSize.SkinGridColor = System.Drawing.Color.Gainsboro;
            this.dgPageSize.TabIndex = 10;
            this.dgPageSize.TitleBack = null;
            this.dgPageSize.TitleBackColorBegin = System.Drawing.Color.White;
            this.dgPageSize.TitleBackColorEnd = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(235)))), ((int)(((byte)(252)))));
            this.dgPageSize.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgPageSize_CellDoubleClick);
            // 
            // frmPageSizeList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(240)))), ((int)(((byte)(255)))));
            this.BackgroundImage = global::ERM.UI.Properties.Resources.panel2_BackgroundImage;
            this.ClientSize = new System.Drawing.Size(551, 429);
            this.Controls.Add(this.dgPageSize);
            this.Controls.Add(this.tsList);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(551, 429);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(551, 429);
            this.Name = "frmPageSizeList";
            this.ShowInTaskbar = false;
            this.Text = "卷盒设置";
            this.Load += new System.EventHandler(this.frmPageSizeList_Load);
            this.tsList.ResumeLayout(false);
            this.tsList.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgPageSize)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public Skin_ToolStripEX tsList;
        public System.Windows.Forms.ToolStripButton tsAdd;
        public System.Windows.Forms.ToolStripButton tsEdit;
        public System.Windows.Forms.ToolStripButton tsDelete;
        private System.Windows.Forms.ToolStripButton tsClose;
        private Skin_DataGridEX dgPageSize;
    }
}