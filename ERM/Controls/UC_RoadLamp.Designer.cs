using CCWin.SkinControl;
using System.Windows.Forms;
using TX.Framework.WindowUI.Controls;
namespace ERM.UI.Controls
{
    partial class UC_RoadLamp
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.txt_ld_gcys = new ERM.UI.NumberTextBox();
            this.skinLabelEX1 = new ERM.UI.Controls.SkinLabelEX();
            this.txt_ld_zl = new ERM.UI.Controls.TXTextBoxEX();
            this.txt_ld_zcd = new ERM.UI.NumberTextBox();
            this.txt_ld_gcjs = new ERM.UI.NumberTextBox();
            this.label1 = new ERM.UI.Controls.SkinLabelEX();
            this.txt_ld_hjqk = new ERM.UI.Controls.TXTextBoxEX();
            this.txt_ld_dldj = new ERM.UI.Controls.TXTextBoxEX();
            this.txt_ld_lk = new ERM.UI.NumberTextBox();
            this.txt_ld_dlmj = new ERM.UI.NumberTextBox();
            this.txt_ld_remark = new ERM.UI.Controls.TXTextBoxEX();
            this.label80 = new ERM.UI.Controls.SkinLabelEX();
            this.label55 = new ERM.UI.Controls.SkinLabelEX();
            this.label53 = new ERM.UI.Controls.SkinLabelEX();
            this.label50 = new ERM.UI.Controls.SkinLabelEX();
            this.txt_ld_zd = new ERM.UI.Controls.TXTextBoxEX();
            this.label47 = new ERM.UI.Controls.SkinLabelEX();
            this.label44 = new ERM.UI.Controls.SkinLabelEX();
            this.txt_ld_dlzcd = new ERM.UI.NumberTextBox();
            this.label43 = new ERM.UI.Controls.SkinLabelEX();
            this.label41 = new ERM.UI.Controls.SkinLabelEX();
            this.label42 = new ERM.UI.Controls.SkinLabelEX();
            this.label29 = new ERM.UI.Controls.SkinLabelEX();
            this.label28 = new ERM.UI.Controls.SkinLabelEX();
            this.txt_ld_gcqd = new ERM.UI.Controls.TXTextBoxEX();
            this.txt_ld_gczd = new ERM.UI.Controls.TXTextBoxEX();
            this.SuspendLayout();
            // 
            // txt_ld_gcys
            // 
            this.txt_ld_gcys.BorderColor = System.Drawing.Color.Gainsboro;
            this.txt_ld_gcys.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_ld_gcys.DecimalLength = 0;
            this.txt_ld_gcys.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txt_ld_gcys.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txt_ld_gcys.HeightLightBolorColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.txt_ld_gcys.Image = null;
            this.txt_ld_gcys.ImageSize = new System.Drawing.Size(0, 0);
            this.txt_ld_gcys.Location = new System.Drawing.Point(108, 70);
            this.txt_ld_gcys.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.txt_ld_gcys.MaxValuelLength = 8;
            this.txt_ld_gcys.Name = "txt_ld_gcys";
            this.txt_ld_gcys.PasswordChar = '\0';
            this.txt_ld_gcys.Required = false;
            this.txt_ld_gcys.ShowMsg = false;
            this.txt_ld_gcys.Size = new System.Drawing.Size(260, 25);
            this.txt_ld_gcys.TabIndex = 62;
            this.txt_ld_gcys.Tag = "总预算,number";
            // 
            // skinLabelEX1
            // 
            this.skinLabelEX1.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.skinLabelEX1.AutoSize = true;
            this.skinLabelEX1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.skinLabelEX1.BorderColor = System.Drawing.Color.White;
            this.skinLabelEX1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabelEX1.ForeColor = System.Drawing.Color.Black;
            this.skinLabelEX1.Location = new System.Drawing.Point(27, 73);
            this.skinLabelEX1.Name = "skinLabelEX1";
            this.skinLabelEX1.Size = new System.Drawing.Size(76, 17);
            this.skinLabelEX1.TabIndex = 348;
            this.skinLabelEX1.Text = "总预算(万元)";
            // 
            // txt_ld_zl
            // 
            this.txt_ld_zl.BackColor = System.Drawing.Color.Transparent;
            this.txt_ld_zl.BorderColor = System.Drawing.Color.Gainsboro;
            this.txt_ld_zl.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txt_ld_zl.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txt_ld_zl.HeightLightBolorColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.txt_ld_zl.Image = null;
            this.txt_ld_zl.ImageSize = new System.Drawing.Size(0, 0);
            this.txt_ld_zl.Location = new System.Drawing.Point(471, 38);
            this.txt_ld_zl.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.txt_ld_zl.MaxLength = 20;
            this.txt_ld_zl.Name = "txt_ld_zl";
            this.txt_ld_zl.Padding = new System.Windows.Forms.Padding(2);
            this.txt_ld_zl.PasswordChar = '\0';
            this.txt_ld_zl.Required = false;
            this.txt_ld_zl.Size = new System.Drawing.Size(260, 25);
            this.txt_ld_zl.TabIndex = 61;
            // 
            // txt_ld_zcd
            // 
            this.txt_ld_zcd.BorderColor = System.Drawing.Color.Gainsboro;
            this.txt_ld_zcd.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_ld_zcd.DecimalLength = 0;
            this.txt_ld_zcd.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txt_ld_zcd.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txt_ld_zcd.HeightLightBolorColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.txt_ld_zcd.Image = null;
            this.txt_ld_zcd.ImageSize = new System.Drawing.Size(0, 0);
            this.txt_ld_zcd.Location = new System.Drawing.Point(108, 102);
            this.txt_ld_zcd.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.txt_ld_zcd.MaxValuelLength = 8;
            this.txt_ld_zcd.Name = "txt_ld_zcd";
            this.txt_ld_zcd.PasswordChar = '\0';
            this.txt_ld_zcd.Required = false;
            this.txt_ld_zcd.ShowMsg = false;
            this.txt_ld_zcd.Size = new System.Drawing.Size(260, 25);
            this.txt_ld_zcd.TabIndex = 64;
            this.txt_ld_zcd.Tag = "总长度,number";
            // 
            // txt_ld_gcjs
            // 
            this.txt_ld_gcjs.BorderColor = System.Drawing.Color.Gainsboro;
            this.txt_ld_gcjs.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_ld_gcjs.DecimalLength = 0;
            this.txt_ld_gcjs.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txt_ld_gcjs.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txt_ld_gcjs.HeightLightBolorColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.txt_ld_gcjs.Image = null;
            this.txt_ld_gcjs.ImageSize = new System.Drawing.Size(0, 0);
            this.txt_ld_gcjs.Location = new System.Drawing.Point(470, 70);
            this.txt_ld_gcjs.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.txt_ld_gcjs.MaxValuelLength = 8;
            this.txt_ld_gcjs.Name = "txt_ld_gcjs";
            this.txt_ld_gcjs.PasswordChar = '\0';
            this.txt_ld_gcjs.Required = false;
            this.txt_ld_gcjs.ShowMsg = false;
            this.txt_ld_gcjs.Size = new System.Drawing.Size(260, 25);
            this.txt_ld_gcjs.TabIndex = 63;
            this.txt_ld_gcjs.Tag = "总决算,number";
            // 
            // label1
            // 
            this.label1.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.label1.BorderColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(389, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 17);
            this.label1.TabIndex = 100;
            this.label1.Text = "总决算(万元)";
            // 
            // txt_ld_hjqk
            // 
            this.txt_ld_hjqk.BackColor = System.Drawing.Color.Transparent;
            this.txt_ld_hjqk.BorderColor = System.Drawing.Color.Gainsboro;
            this.txt_ld_hjqk.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txt_ld_hjqk.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txt_ld_hjqk.HeightLightBolorColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.txt_ld_hjqk.Image = null;
            this.txt_ld_hjqk.ImageSize = new System.Drawing.Size(0, 0);
            this.txt_ld_hjqk.Location = new System.Drawing.Point(470, 102);
            this.txt_ld_hjqk.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.txt_ld_hjqk.MaxLength = 20;
            this.txt_ld_hjqk.Name = "txt_ld_hjqk";
            this.txt_ld_hjqk.Padding = new System.Windows.Forms.Padding(2);
            this.txt_ld_hjqk.PasswordChar = '\0';
            this.txt_ld_hjqk.Required = false;
            this.txt_ld_hjqk.Size = new System.Drawing.Size(260, 25);
            this.txt_ld_hjqk.TabIndex = 65;
            // 
            // txt_ld_dldj
            // 
            this.txt_ld_dldj.BackColor = System.Drawing.Color.Transparent;
            this.txt_ld_dldj.BorderColor = System.Drawing.Color.Gainsboro;
            this.txt_ld_dldj.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txt_ld_dldj.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txt_ld_dldj.HeightLightBolorColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.txt_ld_dldj.Image = null;
            this.txt_ld_dldj.ImageSize = new System.Drawing.Size(0, 0);
            this.txt_ld_dldj.Location = new System.Drawing.Point(470, 6);
            this.txt_ld_dldj.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.txt_ld_dldj.Name = "txt_ld_dldj";
            this.txt_ld_dldj.Padding = new System.Windows.Forms.Padding(2);
            this.txt_ld_dldj.PasswordChar = '\0';
            this.txt_ld_dldj.Required = false;
            this.txt_ld_dldj.Size = new System.Drawing.Size(260, 25);
            this.txt_ld_dldj.TabIndex = 59;
            // 
            // txt_ld_lk
            // 
            this.txt_ld_lk.BorderColor = System.Drawing.Color.Gainsboro;
            this.txt_ld_lk.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_ld_lk.DecimalLength = 0;
            this.txt_ld_lk.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txt_ld_lk.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txt_ld_lk.HeightLightBolorColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.txt_ld_lk.Image = null;
            this.txt_ld_lk.ImageSize = new System.Drawing.Size(0, 0);
            this.txt_ld_lk.Location = new System.Drawing.Point(108, 38);
            this.txt_ld_lk.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.txt_ld_lk.MaxValuelLength = 8;
            this.txt_ld_lk.Name = "txt_ld_lk";
            this.txt_ld_lk.PasswordChar = '\0';
            this.txt_ld_lk.Required = false;
            this.txt_ld_lk.ShowMsg = false;
            this.txt_ld_lk.Size = new System.Drawing.Size(260, 25);
            this.txt_ld_lk.TabIndex = 60;
            this.txt_ld_lk.Tag = "路宽,number";
            this.txt_ld_lk.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.txt_ld_End_X_MaskInputRejected);
            // 
            // txt_ld_dlmj
            // 
            this.txt_ld_dlmj.BorderColor = System.Drawing.Color.Gainsboro;
            this.txt_ld_dlmj.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_ld_dlmj.DecimalLength = 0;
            this.txt_ld_dlmj.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txt_ld_dlmj.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txt_ld_dlmj.HeightLightBolorColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.txt_ld_dlmj.Image = null;
            this.txt_ld_dlmj.ImageSize = new System.Drawing.Size(0, 0);
            this.txt_ld_dlmj.Location = new System.Drawing.Point(108, 6);
            this.txt_ld_dlmj.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.txt_ld_dlmj.MaxValuelLength = 8;
            this.txt_ld_dlmj.Name = "txt_ld_dlmj";
            this.txt_ld_dlmj.PasswordChar = '\0';
            this.txt_ld_dlmj.Required = false;
            this.txt_ld_dlmj.ShowMsg = false;
            this.txt_ld_dlmj.Size = new System.Drawing.Size(260, 25);
            this.txt_ld_dlmj.TabIndex = 58;
            this.txt_ld_dlmj.Tag = "道路面积,number";
            // 
            // txt_ld_remark
            // 
            this.txt_ld_remark.BackColor = System.Drawing.Color.Transparent;
            this.txt_ld_remark.BorderColor = System.Drawing.Color.Gainsboro;
            this.txt_ld_remark.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_ld_remark.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txt_ld_remark.HeightLightBolorColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.txt_ld_remark.Image = null;
            this.txt_ld_remark.ImageSize = new System.Drawing.Size(0, 0);
            this.txt_ld_remark.Location = new System.Drawing.Point(108, 225);
            this.txt_ld_remark.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.txt_ld_remark.MaxLength = 100;
            this.txt_ld_remark.Multiline = true;
            this.txt_ld_remark.Name = "txt_ld_remark";
            this.txt_ld_remark.Padding = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.txt_ld_remark.PasswordChar = '\0';
            this.txt_ld_remark.Required = false;
            this.txt_ld_remark.Size = new System.Drawing.Size(622, 52);
            this.txt_ld_remark.TabIndex = 70;
            // 
            // label80
            // 
            this.label80.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.label80.AutoSize = true;
            this.label80.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.label80.BorderColor = System.Drawing.Color.White;
            this.label80.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label80.ForeColor = System.Drawing.Color.Black;
            this.label80.Location = new System.Drawing.Point(71, 235);
            this.label80.Name = "label80";
            this.label80.Size = new System.Drawing.Size(32, 17);
            this.label80.TabIndex = 87;
            this.label80.Text = "其他";
            // 
            // label55
            // 
            this.label55.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.label55.AutoSize = true;
            this.label55.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.label55.BorderColor = System.Drawing.Color.White;
            this.label55.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label55.ForeColor = System.Drawing.Color.Black;
            this.label55.Location = new System.Drawing.Point(409, 137);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(56, 17);
            this.label55.TabIndex = 75;
            this.label55.Text = "工程质量";
            // 
            // label53
            // 
            this.label53.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.label53.AutoSize = true;
            this.label53.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.label53.BorderColor = System.Drawing.Color.White;
            this.label53.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label53.ForeColor = System.Drawing.Color.Black;
            this.label53.Location = new System.Drawing.Point(40, 105);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(63, 17);
            this.label53.TabIndex = 73;
            this.label53.Text = "总长度(m)";
            // 
            // label50
            // 
            this.label50.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.label50.AutoSize = true;
            this.label50.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.label50.BorderColor = System.Drawing.Color.White;
            this.label50.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label50.ForeColor = System.Drawing.Color.Black;
            this.label50.Location = new System.Drawing.Point(409, 105);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(56, 17);
            this.label50.TabIndex = 72;
            this.label50.Text = "获奖情况";
            // 
            // txt_ld_zd
            // 
            this.txt_ld_zd.BackColor = System.Drawing.Color.Transparent;
            this.txt_ld_zd.BorderColor = System.Drawing.Color.Gainsboro;
            this.txt_ld_zd.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txt_ld_zd.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txt_ld_zd.HeightLightBolorColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.txt_ld_zd.Image = null;
            this.txt_ld_zd.ImageSize = new System.Drawing.Size(0, 0);
            this.txt_ld_zd.Location = new System.Drawing.Point(470, 134);
            this.txt_ld_zd.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.txt_ld_zd.MaxLength = 20;
            this.txt_ld_zd.Name = "txt_ld_zd";
            this.txt_ld_zd.Padding = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.txt_ld_zd.PasswordChar = '\0';
            this.txt_ld_zd.Required = false;
            this.txt_ld_zd.Size = new System.Drawing.Size(260, 25);
            this.txt_ld_zd.TabIndex = 67;
            this.txt_ld_zd.Load += new System.EventHandler(this.txt_ld_ldxs_st_Load);
            // 
            // label47
            // 
            this.label47.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.label47.AutoSize = true;
            this.label47.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.label47.BorderColor = System.Drawing.Color.White;
            this.label47.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label47.ForeColor = System.Drawing.Color.Black;
            this.label47.Location = new System.Drawing.Point(46, 198);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(56, 17);
            this.label47.TabIndex = 68;
            this.label47.Text = "工程止点";
            // 
            // label44
            // 
            this.label44.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.label44.AutoSize = true;
            this.label44.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.label44.BorderColor = System.Drawing.Color.White;
            this.label44.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label44.ForeColor = System.Drawing.Color.Black;
            this.label44.Location = new System.Drawing.Point(47, 167);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(56, 17);
            this.label44.TabIndex = 64;
            this.label44.Text = "工程起点";
            // 
            // txt_ld_dlzcd
            // 
            this.txt_ld_dlzcd.BackColor = System.Drawing.Color.Transparent;
            this.txt_ld_dlzcd.BorderColor = System.Drawing.Color.Gainsboro;
            this.txt_ld_dlzcd.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_ld_dlzcd.DecimalLength = 0;
            this.txt_ld_dlzcd.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_ld_dlzcd.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txt_ld_dlzcd.HeightLightBolorColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.txt_ld_dlzcd.Image = null;
            this.txt_ld_dlzcd.ImageSize = new System.Drawing.Size(0, 0);
            this.txt_ld_dlzcd.Location = new System.Drawing.Point(108, 134);
            this.txt_ld_dlzcd.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.txt_ld_dlzcd.MaxValuelLength = 8;
            this.txt_ld_dlzcd.Name = "txt_ld_dlzcd";
            this.txt_ld_dlzcd.PasswordChar = '\0';
            this.txt_ld_dlzcd.Required = false;
            this.txt_ld_dlzcd.ShowMsg = false;
            this.txt_ld_dlzcd.Size = new System.Drawing.Size(260, 23);
            this.txt_ld_dlzcd.TabIndex = 66;
            this.txt_ld_dlzcd.Tag = "道路总长度,number";
            // 
            // label43
            // 
            this.label43.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.label43.AutoSize = true;
            this.label43.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.label43.BorderColor = System.Drawing.Color.White;
            this.label43.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label43.ForeColor = System.Drawing.Color.Black;
            this.label43.Location = new System.Drawing.Point(12, 138);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(91, 17);
            this.label43.TabIndex = 62;
            this.label43.Text = "道路总长度 (m)";
            // 
            // label41
            // 
            this.label41.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.label41.AutoSize = true;
            this.label41.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.label41.BorderColor = System.Drawing.Color.White;
            this.label41.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label41.ForeColor = System.Drawing.Color.Black;
            this.label41.Location = new System.Drawing.Point(409, 41);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(56, 17);
            this.label41.TabIndex = 61;
            this.label41.Text = "路面种类";
            // 
            // label42
            // 
            this.label42.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.label42.AutoSize = true;
            this.label42.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.label42.BorderColor = System.Drawing.Color.White;
            this.label42.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label42.ForeColor = System.Drawing.Color.Black;
            this.label42.Location = new System.Drawing.Point(52, 41);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(51, 17);
            this.label42.TabIndex = 60;
            this.label42.Text = "路宽(m)";
            // 
            // label29
            // 
            this.label29.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.label29.AutoSize = true;
            this.label29.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.label29.BorderColor = System.Drawing.Color.White;
            this.label29.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label29.ForeColor = System.Drawing.Color.Black;
            this.label29.Location = new System.Drawing.Point(409, 9);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(56, 17);
            this.label29.TabIndex = 59;
            this.label29.Text = "道路等级";
            // 
            // label28
            // 
            this.label28.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.label28.AutoSize = true;
            this.label28.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.label28.BorderColor = System.Drawing.Color.White;
            this.label28.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label28.ForeColor = System.Drawing.Color.Black;
            this.label28.Location = new System.Drawing.Point(23, 9);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(80, 17);
            this.label28.TabIndex = 58;
            this.label28.Text = "道路面积 (㎡)";
            // 
            // txt_ld_gcqd
            // 
            this.txt_ld_gcqd.BackColor = System.Drawing.Color.Transparent;
            this.txt_ld_gcqd.BorderColor = System.Drawing.Color.Gainsboro;
            this.txt_ld_gcqd.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txt_ld_gcqd.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txt_ld_gcqd.HeightLightBolorColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.txt_ld_gcqd.Image = null;
            this.txt_ld_gcqd.ImageSize = new System.Drawing.Size(0, 0);
            this.txt_ld_gcqd.Location = new System.Drawing.Point(108, 163);
            this.txt_ld_gcqd.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.txt_ld_gcqd.MaxLength = 254;
            this.txt_ld_gcqd.Name = "txt_ld_gcqd";
            this.txt_ld_gcqd.Padding = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.txt_ld_gcqd.PasswordChar = '\0';
            this.txt_ld_gcqd.Required = false;
            this.txt_ld_gcqd.Size = new System.Drawing.Size(622, 25);
            this.txt_ld_gcqd.TabIndex = 68;
            // 
            // txt_ld_gczd
            // 
            this.txt_ld_gczd.BackColor = System.Drawing.Color.Transparent;
            this.txt_ld_gczd.BorderColor = System.Drawing.Color.Gainsboro;
            this.txt_ld_gczd.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txt_ld_gczd.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txt_ld_gczd.HeightLightBolorColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.txt_ld_gczd.Image = null;
            this.txt_ld_gczd.ImageSize = new System.Drawing.Size(0, 0);
            this.txt_ld_gczd.Location = new System.Drawing.Point(108, 195);
            this.txt_ld_gczd.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.txt_ld_gczd.MaxLength = 254;
            this.txt_ld_gczd.Name = "txt_ld_gczd";
            this.txt_ld_gczd.Padding = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.txt_ld_gczd.PasswordChar = '\0';
            this.txt_ld_gczd.Required = false;
            this.txt_ld_gczd.Size = new System.Drawing.Size(622, 25);
            this.txt_ld_gczd.TabIndex = 69;
            // 
            // UC_RoadLamp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.Controls.Add(this.txt_ld_gczd);
            this.Controls.Add(this.txt_ld_gcqd);
            this.Controls.Add(this.txt_ld_gcys);
            this.Controls.Add(this.skinLabelEX1);
            this.Controls.Add(this.txt_ld_zl);
            this.Controls.Add(this.txt_ld_zcd);
            this.Controls.Add(this.txt_ld_gcjs);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_ld_hjqk);
            this.Controls.Add(this.txt_ld_dldj);
            this.Controls.Add(this.txt_ld_lk);
            this.Controls.Add(this.txt_ld_dlmj);
            this.Controls.Add(this.txt_ld_remark);
            this.Controls.Add(this.label80);
            this.Controls.Add(this.label55);
            this.Controls.Add(this.label53);
            this.Controls.Add(this.label50);
            this.Controls.Add(this.txt_ld_zd);
            this.Controls.Add(this.label47);
            this.Controls.Add(this.label44);
            this.Controls.Add(this.txt_ld_dlzcd);
            this.Controls.Add(this.label43);
            this.Controls.Add(this.label41);
            this.Controls.Add(this.label42);
            this.Controls.Add(this.label29);
            this.Controls.Add(this.label28);
            this.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.Name = "UC_RoadLamp";
            this.Size = new System.Drawing.Size(746, 283);
            this.Load += new System.EventHandler(this.UC_RoadLamp_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TXTextBoxEX txt_ld_hjqk;
        private TXTextBoxEX txt_ld_remark;
        private SkinLabelEX label80;
        private SkinLabelEX label55;
        private SkinLabelEX label53;
        private SkinLabelEX label50;
        private TXTextBoxEX txt_ld_zd;
        private SkinLabelEX label47;
        private SkinLabelEX label44;
        private NumberTextBox txt_ld_dlzcd;
        private SkinLabelEX label43;
        private SkinLabelEX label1;
        private NumberTextBox txt_ld_gcjs;
        private NumberTextBox txt_ld_zcd;
        private SkinLabelEX label28;
        private SkinLabelEX label29;
        private SkinLabelEX label42;
        private SkinLabelEX label41;
        private NumberTextBox txt_ld_dlmj;
        private NumberTextBox txt_ld_lk;
        private TXTextBoxEX txt_ld_dldj;
        private TXTextBoxEX txt_ld_zl;
        private NumberTextBox txt_ld_gcys;
        private SkinLabelEX skinLabelEX1;
        private TXTextBoxEX txt_ld_gcqd;
        private TXTextBoxEX txt_ld_gczd;
    }
}
