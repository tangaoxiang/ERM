
using CCWin;
using CCWin.SkinControl;
using ERM.UI.Controls;
using System.Drawing;
using System.Windows.Forms;
using TX.Framework.WindowUI.Controls;
using TX.Framework.WindowUI.Forms;
namespace ERM.UI
{
    partial class frmProjectInfo
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProjectInfo));
            this.addr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.zzzh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.zzdj = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.xmjl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fzrzs = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fzr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unittype = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unitid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolTip1 = new CCWin.SkinToolTip(this.components);
            this.cboDistrict = new ERM.UI.Controls.TXComboxEX();
            this.cboProjectType = new ERM.UI.Controls.TXComboxEX();
            this.txtProjectNo = new ERM.UI.Controls.TXTextBoxEX();
            this.dtpEndDate = new ERM.UI.DateTimeEx(this.components);
            this.dtpBeginDate = new ERM.UI.DateTimeEx(this.components);
            this.txtYdpzcode = new ERM.UI.Controls.TXTextBoxEX();
            this.txtYdghxkCode = new ERM.UI.Controls.TXTextBoxEX();
            this.txtAddress = new ERM.UI.Controls.TXTextBoxEX();
            this.txtProjectName = new ERM.UI.Controls.TXTextBoxEX();
            this.fax = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.remark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new ERM.UI.Controls.SkinPanelEX();
            this.btnSave = new ERM.UI.Controls.SkinButtonEX();
            this.tabControl1 = new ERM.UI.Controls.TXTabControlEX();
            this.tabPage4 = new CCWin.SkinControl.SkinTabPage();
            this.TXGroupEX1 = new ERM.UI.Controls.TXGroupEX();
            this.skinLabelEX23 = new ERM.UI.Controls.SkinLabelEX();
            this.skinLabelEX22 = new ERM.UI.Controls.SkinLabelEX();
            this.skinLabelEX21 = new ERM.UI.Controls.SkinLabelEX();
            this.skinLabelEX20 = new ERM.UI.Controls.SkinLabelEX();
            this.txtTlcrnx = new ERM.UI.Controls.NumberTextBoxEX();
            this.lblssss = new ERM.UI.Controls.SkinLabelEX();
            this.skinLabelEX18 = new ERM.UI.Controls.SkinLabelEX();
            this.txtTlsyCode = new ERM.UI.Controls.TXTextBoxEX();
            this.skinLabelEX17 = new ERM.UI.Controls.SkinLabelEX();
            this.txtXmCode = new ERM.UI.Controls.TXTextBoxEX();
            this.lblxmh = new ERM.UI.Controls.SkinLabelEX();
            this.txtpzh = new ERM.UI.Controls.TXTextBoxEX();
            this.label5 = new ERM.UI.Controls.SkinLabelEX();
            this.txtPZDW = new ERM.UI.Controls.TXTextBoxEX();
            this.label1 = new ERM.UI.Controls.SkinLabelEX();
            this.txtCreateUnit = new ERM.UI.Controls.TXTextBoxEX();
            this.txtConStructionProjectName = new ERM.UI.Controls.TXTextBoxEX();
            this.txtConstructionProjectAdd = new ERM.UI.Controls.TXTextBoxEX();
            this.label78 = new ERM.UI.Controls.SkinLabelEX();
            this.label23 = new ERM.UI.Controls.SkinLabelEX();
            this.label59 = new ERM.UI.Controls.SkinLabelEX();
            this.tabPage1 = new CCWin.SkinControl.SkinTabPage();
            this.groupBox2 = new ERM.UI.Controls.TXGroupEX();
            this.skinLabelEX14 = new ERM.UI.Controls.SkinLabelEX();
            this.txtysbah = new ERM.UI.Controls.TXTextBoxEX();
            this.skinLabelEX13 = new ERM.UI.Controls.SkinLabelEX();
            this.lbl_wh3 = new ERM.UI.Controls.SkinLabelEX();
            this.txtGhcode = new ERM.UI.Controls.TXTextBoxEX();
            this.lbl_wh4 = new ERM.UI.Controls.SkinLabelEX();
            this.txtSgcode = new ERM.UI.Controls.TXTextBoxEX();
            this.label2 = new System.Windows.Forms.Label();
            this.txGroupEX2 = new ERM.UI.Controls.TXGroupEX();
            this.skinLabelEX16 = new ERM.UI.Controls.SkinLabelEX();
            this.skinLabelEX15 = new ERM.UI.Controls.SkinLabelEX();
            this.skinLabelEX10 = new ERM.UI.Controls.SkinLabelEX();
            this.skinLabelEX9 = new ERM.UI.Controls.SkinLabelEX();
            this.skinLabelEX8 = new ERM.UI.Controls.SkinLabelEX();
            this.skinLabelEX7 = new ERM.UI.Controls.SkinLabelEX();
            this.skinLabelEX5 = new ERM.UI.Controls.SkinLabelEX();
            this.skinLabelEX4 = new ERM.UI.Controls.SkinLabelEX();
            this.txtJldw = new ERM.UI.Controls.TXTextBoxEX();
            this.txtSgdw = new ERM.UI.Controls.TXTextBoxEX();
            this.skinLabelEX6 = new ERM.UI.Controls.SkinLabelEX();
            this.txtSjdw = new ERM.UI.Controls.TXTextBoxEX();
            this.skinLabelEX3 = new ERM.UI.Controls.SkinLabelEX();
            this.txtKcdw = new ERM.UI.Controls.TXTextBoxEX();
            this.skinLabelEX2 = new ERM.UI.Controls.SkinLabelEX();
            this.txtLxpzdw = new ERM.UI.Controls.TXTextBoxEX();
            this.skinLabelEX1 = new ERM.UI.Controls.SkinLabelEX();
            this.txtJsdw = new ERM.UI.Controls.TXTextBoxEX();
            this.groupBox1 = new ERM.UI.Controls.TXGroupEX();
            this.skinLabelEX24 = new ERM.UI.Controls.SkinLabelEX();
            this.label27 = new ERM.UI.Controls.SkinLabelEX();
            this.skinLabelEX19 = new ERM.UI.Controls.SkinLabelEX();
            this.skinLabelEX12 = new ERM.UI.Controls.SkinLabelEX();
            this.skinLabelEX11 = new ERM.UI.Controls.SkinLabelEX();
            this.label25 = new ERM.UI.Controls.SkinLabelEX();
            this.label26 = new ERM.UI.Controls.SkinLabelEX();
            this.lbl_ProjectNO = new ERM.UI.Controls.SkinLabelEX();
            this.label13 = new ERM.UI.Controls.SkinLabelEX();
            this.label11 = new ERM.UI.Controls.SkinLabelEX();
            this.label3 = new ERM.UI.Controls.SkinLabelEX();
            this.label4 = new ERM.UI.Controls.SkinLabelEX();
            this.txtPasswd = new ERM.UI.Controls.TXTextBoxEX();
            this.tabPage2 = new CCWin.SkinControl.SkinTabPage();
            this.gbjz = new ERM.UI.Controls.TXGroupEX();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.txGroupEX3 = new ERM.UI.Controls.TXGroupEX();
            this.dgvPoint = new ERM.UI.Controls.Skin_DataGridEX();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OrderIndex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.X = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Y = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label6 = new ERM.UI.Controls.SkinLabelEX();
            this.label15 = new ERM.UI.Controls.SkinLabelEX();
            this.label66 = new ERM.UI.Controls.SkinLabelEX();
            this.label67 = new ERM.UI.Controls.SkinLabelEX();
            this.label70 = new ERM.UI.Controls.SkinLabelEX();
            this.label72 = new ERM.UI.Controls.SkinLabelEX();
            this.txtItemFzr = new ERM.UI.Controls.TXTextBoxEX();
            this.txtRespective = new ERM.UI.Controls.TXTextBoxEX();
            this.txtProjectType = new ERM.UI.Controls.TXTextBoxEX();
            this.label73 = new ERM.UI.Controls.SkinLabelEX();
            this.label74 = new ERM.UI.Controls.SkinLabelEX();
            this.label75 = new ERM.UI.Controls.SkinLabelEX();
            this.label76 = new ERM.UI.Controls.SkinLabelEX();
            this.label77 = new ERM.UI.Controls.SkinLabelEX();
            this.label22 = new ERM.UI.Controls.SkinLabelEX();
            this.label57 = new ERM.UI.Controls.SkinLabelEX();
            this.txtzcd = new ERM.UI.Controls.NumberTextBoxEX();
            this.txtds = new ERM.UI.Controls.NumberTextBoxEX();
            this.txtConstructionAreaSum = new ERM.UI.Controls.NumberTextBoxEX();
            this.txtUseSoiAreaSum = new ERM.UI.Controls.NumberTextBoxEX();
            this.txtAllCost = new ERM.UI.Controls.NumberTextBoxEX();
            this.txtProjectSettlement = new ERM.UI.Controls.NumberTextBoxEX();
            this.txtProjectCost = new ERM.UI.Controls.NumberTextBoxEX();
            this.txtVolumeFar = new ERM.UI.Controls.NumberTextBoxEX();
            this.txtGreenFar = new ERM.UI.Controls.NumberTextBoxEX();
            this.txtBuildingDensity = new ERM.UI.Controls.NumberTextBoxEX();
            this.lbl_wh2 = new ERM.UI.Controls.SkinLabelEX();
            this.lbl_wh1 = new ERM.UI.Controls.SkinLabelEX();
            this.tabPage3 = new CCWin.SkinControl.SkinTabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblUnit1 = new System.Windows.Forms.LinkLabel();
            this.lblUnit2 = new System.Windows.Forms.LinkLabel();
            this.lblUnit3 = new System.Windows.Forms.LinkLabel();
            this.lblUnit4 = new System.Windows.Forms.LinkLabel();
            this.lblUnit6 = new System.Windows.Forms.LinkLabel();
            this.lblUnit15 = new System.Windows.Forms.LinkLabel();
            this.lblUnitAll = new System.Windows.Forms.LinkLabel();
            this.cPanel2 = new ERM.UI.Controls.SkinPanelEX();
            this.Dgv1 = new ERM.UI.Controls.Skin_DataGridEX();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dwmc1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnEdit = new ERM.UI.Controls.SkinButtonEX();
            this.btnDel = new ERM.UI.Controls.SkinButtonEX();
            this.btnNew = new ERM.UI.Controls.SkinButtonEX();
            this.txtUnittype = new ERM.UI.Controls.TXTextBoxEX();
            this.txtGhxkz = new ERM.UI.Controls.TXTextBoxEX();
            this.panel2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.TXGroupEX1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.txGroupEX2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.txGroupEX3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPoint)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.cPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv1)).BeginInit();
            this.SuspendLayout();
            // 
            // addr
            // 
            this.addr.HeaderText = "地址";
            this.addr.Name = "addr";
            this.addr.ReadOnly = true;
            this.addr.Width = 132;
            // 
            // zzzh
            // 
            this.zzzh.HeaderText = "资质证号";
            this.zzzh.Name = "zzzh";
            this.zzzh.ReadOnly = true;
            this.zzzh.Width = 97;
            // 
            // zzdj
            // 
            this.zzdj.HeaderText = "资质等级";
            this.zzdj.Name = "zzdj";
            this.zzdj.ReadOnly = true;
            this.zzdj.Width = 64;
            // 
            // xmjl
            // 
            this.xmjl.HeaderText = "项目经理";
            this.xmjl.Name = "xmjl";
            this.xmjl.ReadOnly = true;
            this.xmjl.Width = 62;
            // 
            // fzrzs
            // 
            this.fzrzs.HeaderText = "负责人资格证号";
            this.fzrzs.Name = "fzrzs";
            this.fzrzs.ReadOnly = true;
            this.fzrzs.Width = 96;
            // 
            // fzr
            // 
            this.fzr.HeaderText = "负责人";
            this.fzr.Name = "fzr";
            this.fzr.ReadOnly = true;
            this.fzr.Width = 60;
            // 
            // unittype
            // 
            this.unittype.HeaderText = "unittype";
            this.unittype.Name = "unittype";
            this.unittype.ReadOnly = true;
            this.unittype.Visible = false;
            // 
            // unitid
            // 
            this.unitid.HeaderText = "unitid";
            this.unitid.Name = "unitid";
            this.unitid.ReadOnly = true;
            this.unitid.Visible = false;
            // 
            // tel
            // 
            this.tel.HeaderText = "联系电话";
            this.tel.Name = "tel";
            this.tel.ReadOnly = true;
            this.tel.Width = 99;
            // 
            // toolTip1
            // 
            this.toolTip1.AutoPopDelay = 5000;
            this.toolTip1.InitialDelay = 10;
            this.toolTip1.IsBalloon = true;
            this.toolTip1.OwnerDraw = true;
            this.toolTip1.ReshowDelay = 10;
            this.toolTip1.ShowAlways = true;
            this.toolTip1.ToolTipTitle = "填写说明：";
            this.toolTip1.UseAnimation = false;
            this.toolTip1.UseFading = false;
            // 
            // cboDistrict
            // 
            this.cboDistrict.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDistrict.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.cboDistrict.FormattingEnabled = true;
            this.cboDistrict.Location = new System.Drawing.Point(123, 111);
            this.cboDistrict.Margin = new System.Windows.Forms.Padding(0);
            this.cboDistrict.Name = "cboDistrict";
            this.cboDistrict.Size = new System.Drawing.Size(210, 25);
            this.cboDistrict.TabIndex = 14;
            this.toolTip1.SetToolTip(this.cboDistrict, "选择工程所属区域");
            // 
            // cboProjectType
            // 
            this.cboProjectType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProjectType.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.cboProjectType.FormattingEnabled = true;
            this.cboProjectType.IntegralHeight = false;
            this.cboProjectType.Location = new System.Drawing.Point(123, 17);
            this.cboProjectType.Margin = new System.Windows.Forms.Padding(0);
            this.cboProjectType.Name = "cboProjectType";
            this.cboProjectType.Size = new System.Drawing.Size(601, 25);
            this.cboProjectType.TabIndex = 11;
            this.toolTip1.SetToolTip(this.cboProjectType, "选择工程类别");
            this.cboProjectType.SelectedIndexChanged += new System.EventHandler(this.cboProjectType_SelectedIndexChanged);
            // 
            // txtProjectNo
            // 
            this.txtProjectNo.BackColor = System.Drawing.Color.Transparent;
            this.txtProjectNo.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtProjectNo.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtProjectNo.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtProjectNo.HeightLightBolorColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.txtProjectNo.Image = null;
            this.txtProjectNo.ImageSize = new System.Drawing.Size(0, 0);
            this.txtProjectNo.Location = new System.Drawing.Point(123, 48);
            this.txtProjectNo.MaxLength = 50;
            this.txtProjectNo.Name = "txtProjectNo";
            this.txtProjectNo.Padding = new System.Windows.Forms.Padding(3);
            this.txtProjectNo.PasswordChar = '\0';
            this.txtProjectNo.Required = false;
            this.txtProjectNo.Size = new System.Drawing.Size(601, 25);
            this.txtProjectNo.TabIndex = 12;
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.BorderColor = System.Drawing.Color.Gainsboro;
            this.dtpEndDate.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtpEndDate.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.dtpEndDate.ForeColor = System.Drawing.Color.Black;
            this.dtpEndDate.HeightLightBolorColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.dtpEndDate.Image = null;
            this.dtpEndDate.ImageSize = new System.Drawing.Size(0, 0);
            this.dtpEndDate.Location = new System.Drawing.Point(513, 145);
            this.dtpEndDate.Margin = new System.Windows.Forms.Padding(0);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.PasswordChar = '\0';
            this.dtpEndDate.Required = false;
            this.dtpEndDate.Size = new System.Drawing.Size(211, 25);
            this.dtpEndDate.TabIndex = 17;
            this.dtpEndDate.TextEx = "";
            this.dtpEndDate.Click += new System.EventHandler(this.dtpEndDate_Click);
            this.dtpEndDate.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dtpEndDate_MouseClick);
            this.dtpEndDate.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dtpEndDate_MouseDown);
            // 
            // dtpBeginDate
            // 
            this.dtpBeginDate.BorderColor = System.Drawing.Color.Gainsboro;
            this.dtpBeginDate.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtpBeginDate.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.dtpBeginDate.ForeColor = System.Drawing.Color.Black;
            this.dtpBeginDate.HeightLightBolorColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.dtpBeginDate.Image = null;
            this.dtpBeginDate.ImageSize = new System.Drawing.Size(0, 0);
            this.dtpBeginDate.Location = new System.Drawing.Point(123, 145);
            this.dtpBeginDate.Margin = new System.Windows.Forms.Padding(0);
            this.dtpBeginDate.Name = "dtpBeginDate";
            this.dtpBeginDate.PasswordChar = '\0';
            this.dtpBeginDate.Required = false;
            this.dtpBeginDate.Size = new System.Drawing.Size(211, 25);
            this.dtpBeginDate.TabIndex = 16;
            this.dtpBeginDate.TextEx = "";
            // 
            // txtYdpzcode
            // 
            this.txtYdpzcode.BackColor = System.Drawing.Color.Transparent;
            this.txtYdpzcode.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtYdpzcode.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtYdpzcode.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtYdpzcode.HeightLightBolorColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.txtYdpzcode.Image = null;
            this.txtYdpzcode.ImageSize = new System.Drawing.Size(0, 0);
            this.txtYdpzcode.Location = new System.Drawing.Point(129, 30);
            this.txtYdpzcode.Margin = new System.Windows.Forms.Padding(0);
            this.txtYdpzcode.MaxLength = 30;
            this.txtYdpzcode.Name = "txtYdpzcode";
            this.txtYdpzcode.Padding = new System.Windows.Forms.Padding(3);
            this.txtYdpzcode.PasswordChar = '\0';
            this.txtYdpzcode.Required = false;
            this.txtYdpzcode.Size = new System.Drawing.Size(205, 25);
            this.txtYdpzcode.TabIndex = 9;
            // 
            // txtYdghxkCode
            // 
            this.txtYdghxkCode.BackColor = System.Drawing.Color.Transparent;
            this.txtYdghxkCode.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtYdghxkCode.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtYdghxkCode.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtYdghxkCode.HeightLightBolorColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.txtYdghxkCode.Image = null;
            this.txtYdghxkCode.ImageSize = new System.Drawing.Size(0, 0);
            this.txtYdghxkCode.Location = new System.Drawing.Point(119, 227);
            this.txtYdghxkCode.Margin = new System.Windows.Forms.Padding(0);
            this.txtYdghxkCode.MaxLength = 80;
            this.txtYdghxkCode.Name = "txtYdghxkCode";
            this.txtYdghxkCode.Padding = new System.Windows.Forms.Padding(3);
            this.txtYdghxkCode.PasswordChar = '\0';
            this.txtYdghxkCode.Required = false;
            this.txtYdghxkCode.Size = new System.Drawing.Size(603, 25);
            this.txtYdghxkCode.TabIndex = 7;
            // 
            // txtAddress
            // 
            this.txtAddress.BackColor = System.Drawing.Color.Transparent;
            this.txtAddress.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtAddress.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtAddress.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtAddress.HeightLightBolorColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.txtAddress.Image = null;
            this.txtAddress.ImageSize = new System.Drawing.Size(0, 0);
            this.txtAddress.Location = new System.Drawing.Point(339, 111);
            this.txtAddress.MaxLength = 120;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Padding = new System.Windows.Forms.Padding(3);
            this.txtAddress.PasswordChar = '\0';
            this.txtAddress.Required = false;
            this.txtAddress.Size = new System.Drawing.Size(385, 25);
            this.txtAddress.TabIndex = 15;
            // 
            // txtProjectName
            // 
            this.txtProjectName.BackColor = System.Drawing.Color.Transparent;
            this.txtProjectName.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtProjectName.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtProjectName.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtProjectName.HeightLightBolorColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.txtProjectName.Image = null;
            this.txtProjectName.ImageSize = new System.Drawing.Size(0, 0);
            this.txtProjectName.Location = new System.Drawing.Point(123, 80);
            this.txtProjectName.MaxLength = 100;
            this.txtProjectName.Name = "txtProjectName";
            this.txtProjectName.Padding = new System.Windows.Forms.Padding(3);
            this.txtProjectName.PasswordChar = '\0';
            this.txtProjectName.Required = false;
            this.txtProjectName.Size = new System.Drawing.Size(601, 25);
            this.txtProjectName.TabIndex = 13;
            this.txtProjectName.Load += new System.EventHandler(this.txtProjectName_Load);
            // 
            // fax
            // 
            this.fax.HeaderText = "传真";
            this.fax.Name = "fax";
            this.fax.ReadOnly = true;
            // 
            // remark
            // 
            this.remark.HeaderText = "备注";
            this.remark.Name = "remark";
            this.remark.ReadOnly = true;
            // 
            // panel2
            // 
            this.panel2.AutoSize = true;
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel2.Controls.Add(this.btnSave);
            this.panel2.Controls.Add(this.tabControl1);
            this.panel2.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.DownBack = null;
            this.panel2.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.panel2.Location = new System.Drawing.Point(4, 34);
            this.panel2.MouseBack = null;
            this.panel2.Name = "panel2";
            this.panel2.NormlBack = null;
            this.panel2.Radius = 4;
            this.panel2.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.panel2.Size = new System.Drawing.Size(782, 542);
            this.panel2.TabIndex = 61;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Transparent;
            this.btnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSave.BackRectangle = new System.Drawing.Rectangle(59, 23, 59, 25);
            this.btnSave.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(168)))), ((int)(((byte)(213)))));
            this.btnSave.BorderColor = System.Drawing.Color.Empty;
            this.btnSave.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.DownBack = null;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.btnSave.ForeColor = System.Drawing.Color.Black;
            this.btnSave.GlowColor = System.Drawing.Color.Transparent;
            this.btnSave.InnerBorderColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(358, 508);
            this.btnSave.Margin = new System.Windows.Forms.Padding(0);
            this.btnSave.MouseBack = null;
            this.btnSave.MouseBaseColor = System.Drawing.Color.SkyBlue;
            this.btnSave.Name = "btnSave";
            this.btnSave.NormlBack = null;
            this.btnSave.Palace = true;
            this.btnSave.Radius = 10;
            this.btnSave.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.btnSave.Size = new System.Drawing.Size(84, 29);
            this.btnSave.TabIndex = 77;
            this.btnSave.TabStop = false;
            this.btnSave.Text = "保存(&S)";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.BaseTabColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.tabControl1.BorderColor = System.Drawing.Color.Gainsboro;
            this.tabControl1.CaptionFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabControl1.CheckedTabColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(225)))), ((int)(((byte)(247)))));
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.tabControl1.HeightLightTabColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.tabControl1.Location = new System.Drawing.Point(3, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(776, 505);
            this.tabControl1.TabCornerRadius = 3;
            this.tabControl1.TabIndex = 60;
            // 
            // tabPage4
            // 
            this.tabPage4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.tabPage4.Controls.Add(this.TXGroupEX1);
            this.tabPage4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabPage4.Location = new System.Drawing.Point(4, 29);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(768, 472);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.TabItemImage = null;
            this.tabPage4.Text = "项目信息";
            // 
            // TXGroupEX1
            // 
            this.TXGroupEX1.BackColor = System.Drawing.Color.Transparent;
            this.TXGroupEX1.BorderColor = System.Drawing.Color.Gainsboro;
            this.TXGroupEX1.CaptionColor = System.Drawing.Color.Black;
            this.TXGroupEX1.CaptionFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold);
            this.TXGroupEX1.Controls.Add(this.skinLabelEX23);
            this.TXGroupEX1.Controls.Add(this.skinLabelEX22);
            this.TXGroupEX1.Controls.Add(this.skinLabelEX21);
            this.TXGroupEX1.Controls.Add(this.skinLabelEX20);
            this.TXGroupEX1.Controls.Add(this.txtTlcrnx);
            this.TXGroupEX1.Controls.Add(this.lblssss);
            this.TXGroupEX1.Controls.Add(this.txtYdghxkCode);
            this.TXGroupEX1.Controls.Add(this.skinLabelEX18);
            this.TXGroupEX1.Controls.Add(this.txtTlsyCode);
            this.TXGroupEX1.Controls.Add(this.skinLabelEX17);
            this.TXGroupEX1.Controls.Add(this.txtXmCode);
            this.TXGroupEX1.Controls.Add(this.lblxmh);
            this.TXGroupEX1.Controls.Add(this.txtpzh);
            this.TXGroupEX1.Controls.Add(this.label5);
            this.TXGroupEX1.Controls.Add(this.txtPZDW);
            this.TXGroupEX1.Controls.Add(this.label1);
            this.TXGroupEX1.Controls.Add(this.txtCreateUnit);
            this.TXGroupEX1.Controls.Add(this.txtConStructionProjectName);
            this.TXGroupEX1.Controls.Add(this.txtConstructionProjectAdd);
            this.TXGroupEX1.Controls.Add(this.label78);
            this.TXGroupEX1.Controls.Add(this.label23);
            this.TXGroupEX1.Controls.Add(this.label59);
            this.TXGroupEX1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.TXGroupEX1.ForeColor = System.Drawing.Color.Black;
            this.TXGroupEX1.Location = new System.Drawing.Point(3, 3);
            this.TXGroupEX1.Name = "TXGroupEX1";
            this.TXGroupEX1.Size = new System.Drawing.Size(765, 338);
            this.TXGroupEX1.TabIndex = 0;
            this.TXGroupEX1.TabStop = false;
            this.TXGroupEX1.Text = "项目信息";
            this.TXGroupEX1.TextMargin = 6;
            // 
            // skinLabelEX23
            // 
            this.skinLabelEX23.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.skinLabelEX23.AutoSize = true;
            this.skinLabelEX23.BackColor = System.Drawing.Color.Transparent;
            this.skinLabelEX23.BorderColor = System.Drawing.Color.White;
            this.skinLabelEX23.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabelEX23.ForeColor = System.Drawing.Color.Red;
            this.skinLabelEX23.Location = new System.Drawing.Point(725, 64);
            this.skinLabelEX23.Name = "skinLabelEX23";
            this.skinLabelEX23.Size = new System.Drawing.Size(13, 17);
            this.skinLabelEX23.TabIndex = 303;
            this.skinLabelEX23.Text = "*";
            this.skinLabelEX23.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // skinLabelEX22
            // 
            this.skinLabelEX22.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.skinLabelEX22.AutoSize = true;
            this.skinLabelEX22.BackColor = System.Drawing.Color.Transparent;
            this.skinLabelEX22.BorderColor = System.Drawing.Color.White;
            this.skinLabelEX22.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabelEX22.ForeColor = System.Drawing.Color.Red;
            this.skinLabelEX22.Location = new System.Drawing.Point(725, 163);
            this.skinLabelEX22.Name = "skinLabelEX22";
            this.skinLabelEX22.Size = new System.Drawing.Size(13, 17);
            this.skinLabelEX22.TabIndex = 299;
            this.skinLabelEX22.Text = "*";
            this.skinLabelEX22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // skinLabelEX21
            // 
            this.skinLabelEX21.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.skinLabelEX21.AutoSize = true;
            this.skinLabelEX21.BackColor = System.Drawing.Color.Transparent;
            this.skinLabelEX21.BorderColor = System.Drawing.Color.White;
            this.skinLabelEX21.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabelEX21.ForeColor = System.Drawing.Color.Red;
            this.skinLabelEX21.Location = new System.Drawing.Point(725, 131);
            this.skinLabelEX21.Name = "skinLabelEX21";
            this.skinLabelEX21.Size = new System.Drawing.Size(13, 17);
            this.skinLabelEX21.TabIndex = 298;
            this.skinLabelEX21.Text = "*";
            this.skinLabelEX21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // skinLabelEX20
            // 
            this.skinLabelEX20.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.skinLabelEX20.AutoSize = true;
            this.skinLabelEX20.BackColor = System.Drawing.Color.Transparent;
            this.skinLabelEX20.BorderColor = System.Drawing.Color.White;
            this.skinLabelEX20.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabelEX20.ForeColor = System.Drawing.Color.Red;
            this.skinLabelEX20.Location = new System.Drawing.Point(725, 97);
            this.skinLabelEX20.Name = "skinLabelEX20";
            this.skinLabelEX20.Size = new System.Drawing.Size(13, 17);
            this.skinLabelEX20.TabIndex = 297;
            this.skinLabelEX20.Text = "*";
            this.skinLabelEX20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtTlcrnx
            // 
            this.txtTlcrnx.BackColor = System.Drawing.Color.Transparent;
            this.txtTlcrnx.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtTlcrnx.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTlcrnx.DecimalLength = 0;
            this.txtTlcrnx.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtTlcrnx.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtTlcrnx.HeightLightBolorColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.txtTlcrnx.Image = null;
            this.txtTlcrnx.ImageSize = new System.Drawing.Size(0, 0);
            this.txtTlcrnx.Location = new System.Drawing.Point(119, 294);
            this.txtTlcrnx.MaxValuelLength = 4;
            this.txtTlcrnx.Name = "txtTlcrnx";
            this.txtTlcrnx.PasswordChar = '\0';
            this.txtTlcrnx.Required = false;
            this.txtTlcrnx.ShowMsg = false;
            this.txtTlcrnx.Size = new System.Drawing.Size(603, 23);
            this.txtTlcrnx.TabIndex = 9;
            this.txtTlcrnx.Tag = "土地年限,int";
            // 
            // lblssss
            // 
            this.lblssss.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.lblssss.AutoSize = true;
            this.lblssss.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.lblssss.BorderColor = System.Drawing.Color.White;
            this.lblssss.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblssss.ForeColor = System.Drawing.Color.Black;
            this.lblssss.Location = new System.Drawing.Point(34, 297);
            this.lblssss.Name = "lblssss";
            this.lblssss.Size = new System.Drawing.Size(80, 17);
            this.lblssss.TabIndex = 295;
            this.lblssss.Text = "土地出让年限";
            // 
            // skinLabelEX18
            // 
            this.skinLabelEX18.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.skinLabelEX18.AutoSize = true;
            this.skinLabelEX18.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.skinLabelEX18.BorderColor = System.Drawing.Color.White;
            this.skinLabelEX18.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabelEX18.ForeColor = System.Drawing.Color.Black;
            this.skinLabelEX18.Location = new System.Drawing.Point(22, 230);
            this.skinLabelEX18.Name = "skinLabelEX18";
            this.skinLabelEX18.Size = new System.Drawing.Size(92, 17);
            this.skinLabelEX18.TabIndex = 293;
            this.skinLabelEX18.Text = "用地规划许可证";
            // 
            // txtTlsyCode
            // 
            this.txtTlsyCode.BackColor = System.Drawing.Color.Transparent;
            this.txtTlsyCode.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtTlsyCode.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtTlsyCode.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtTlsyCode.HeightLightBolorColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.txtTlsyCode.Image = null;
            this.txtTlsyCode.ImageSize = new System.Drawing.Size(0, 0);
            this.txtTlsyCode.Location = new System.Drawing.Point(119, 194);
            this.txtTlsyCode.MaxLength = 80;
            this.txtTlsyCode.Name = "txtTlsyCode";
            this.txtTlsyCode.Padding = new System.Windows.Forms.Padding(3);
            this.txtTlsyCode.PasswordChar = '\0';
            this.txtTlsyCode.Required = false;
            this.txtTlsyCode.Size = new System.Drawing.Size(603, 25);
            this.txtTlsyCode.TabIndex = 6;
            // 
            // skinLabelEX17
            // 
            this.skinLabelEX17.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.skinLabelEX17.AutoSize = true;
            this.skinLabelEX17.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.skinLabelEX17.BorderColor = System.Drawing.Color.White;
            this.skinLabelEX17.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabelEX17.ForeColor = System.Drawing.Color.Black;
            this.skinLabelEX17.Location = new System.Drawing.Point(34, 197);
            this.skinLabelEX17.Name = "skinLabelEX17";
            this.skinLabelEX17.Size = new System.Drawing.Size(80, 17);
            this.skinLabelEX17.TabIndex = 291;
            this.skinLabelEX17.Text = "土地使用证号";
            // 
            // txtXmCode
            // 
            this.txtXmCode.BackColor = System.Drawing.Color.Transparent;
            this.txtXmCode.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtXmCode.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtXmCode.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtXmCode.HeightLightBolorColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.txtXmCode.Image = null;
            this.txtXmCode.ImageSize = new System.Drawing.Size(0, 0);
            this.txtXmCode.Location = new System.Drawing.Point(119, 27);
            this.txtXmCode.MaxLength = 50;
            this.txtXmCode.Name = "txtXmCode";
            this.txtXmCode.Padding = new System.Windows.Forms.Padding(3);
            this.txtXmCode.PasswordChar = '\0';
            this.txtXmCode.Required = false;
            this.txtXmCode.Size = new System.Drawing.Size(603, 25);
            this.txtXmCode.TabIndex = 1;
            // 
            // lblxmh
            // 
            this.lblxmh.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.lblxmh.AutoSize = true;
            this.lblxmh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.lblxmh.BorderColor = System.Drawing.Color.White;
            this.lblxmh.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblxmh.ForeColor = System.Drawing.Color.Black;
            this.lblxmh.Location = new System.Drawing.Point(70, 30);
            this.lblxmh.Name = "lblxmh";
            this.lblxmh.Size = new System.Drawing.Size(44, 17);
            this.lblxmh.TabIndex = 290;
            this.lblxmh.Text = "项目号";
            // 
            // txtpzh
            // 
            this.txtpzh.BackColor = System.Drawing.Color.Transparent;
            this.txtpzh.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtpzh.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtpzh.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtpzh.HeightLightBolorColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.txtpzh.Image = null;
            this.txtpzh.ImageSize = new System.Drawing.Size(0, 0);
            this.txtpzh.Location = new System.Drawing.Point(119, 260);
            this.txtpzh.MaxLength = 80;
            this.txtpzh.Name = "txtpzh";
            this.txtpzh.Padding = new System.Windows.Forms.Padding(3);
            this.txtpzh.PasswordChar = '\0';
            this.txtpzh.Required = false;
            this.txtpzh.Size = new System.Drawing.Size(603, 25);
            this.txtpzh.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.label5.BorderColor = System.Drawing.Color.White;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(34, 263);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 17);
            this.label5.TabIndex = 287;
            this.label5.Text = "立项批准文号";
            // 
            // txtPZDW
            // 
            this.txtPZDW.BackColor = System.Drawing.Color.Transparent;
            this.txtPZDW.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtPZDW.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtPZDW.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtPZDW.HeightLightBolorColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.txtPZDW.Image = null;
            this.txtPZDW.ImageSize = new System.Drawing.Size(0, 0);
            this.txtPZDW.Location = new System.Drawing.Point(119, 160);
            this.txtPZDW.MaxLength = 100;
            this.txtPZDW.Name = "txtPZDW";
            this.txtPZDW.Padding = new System.Windows.Forms.Padding(3);
            this.txtPZDW.PasswordChar = '\0';
            this.txtPZDW.Required = false;
            this.txtPZDW.Size = new System.Drawing.Size(603, 25);
            this.txtPZDW.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.label1.BorderColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(34, 163);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 17);
            this.label1.TabIndex = 285;
            this.label1.Text = "立项批准单位";
            // 
            // txtCreateUnit
            // 
            this.txtCreateUnit.BackColor = System.Drawing.Color.Transparent;
            this.txtCreateUnit.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtCreateUnit.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtCreateUnit.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtCreateUnit.HeightLightBolorColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.txtCreateUnit.Image = null;
            this.txtCreateUnit.ImageSize = new System.Drawing.Size(0, 0);
            this.txtCreateUnit.Location = new System.Drawing.Point(119, 128);
            this.txtCreateUnit.MaxLength = 100;
            this.txtCreateUnit.Name = "txtCreateUnit";
            this.txtCreateUnit.Padding = new System.Windows.Forms.Padding(3);
            this.txtCreateUnit.PasswordChar = '\0';
            this.txtCreateUnit.Required = false;
            this.txtCreateUnit.Size = new System.Drawing.Size(603, 25);
            this.txtCreateUnit.TabIndex = 4;
            // 
            // txtConStructionProjectName
            // 
            this.txtConStructionProjectName.BackColor = System.Drawing.Color.Transparent;
            this.txtConStructionProjectName.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtConStructionProjectName.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtConStructionProjectName.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtConStructionProjectName.HeightLightBolorColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.txtConStructionProjectName.Image = null;
            this.txtConStructionProjectName.ImageSize = new System.Drawing.Size(0, 0);
            this.txtConStructionProjectName.Location = new System.Drawing.Point(119, 61);
            this.txtConStructionProjectName.MaxLength = 80;
            this.txtConStructionProjectName.Name = "txtConStructionProjectName";
            this.txtConStructionProjectName.Padding = new System.Windows.Forms.Padding(3);
            this.txtConStructionProjectName.PasswordChar = '\0';
            this.txtConStructionProjectName.Required = false;
            this.txtConStructionProjectName.Size = new System.Drawing.Size(603, 25);
            this.txtConStructionProjectName.TabIndex = 2;
            // 
            // txtConstructionProjectAdd
            // 
            this.txtConstructionProjectAdd.BackColor = System.Drawing.Color.Transparent;
            this.txtConstructionProjectAdd.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtConstructionProjectAdd.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtConstructionProjectAdd.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtConstructionProjectAdd.HeightLightBolorColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.txtConstructionProjectAdd.Image = null;
            this.txtConstructionProjectAdd.ImageSize = new System.Drawing.Size(0, 0);
            this.txtConstructionProjectAdd.Location = new System.Drawing.Point(119, 95);
            this.txtConstructionProjectAdd.MaxLength = 80;
            this.txtConstructionProjectAdd.Name = "txtConstructionProjectAdd";
            this.txtConstructionProjectAdd.Padding = new System.Windows.Forms.Padding(3);
            this.txtConstructionProjectAdd.PasswordChar = '\0';
            this.txtConstructionProjectAdd.Required = false;
            this.txtConstructionProjectAdd.Size = new System.Drawing.Size(603, 25);
            this.txtConstructionProjectAdd.TabIndex = 3;
            // 
            // label78
            // 
            this.label78.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.label78.AutoSize = true;
            this.label78.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.label78.BorderColor = System.Drawing.Color.White;
            this.label78.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label78.ForeColor = System.Drawing.Color.Black;
            this.label78.Location = new System.Drawing.Point(58, 132);
            this.label78.Name = "label78";
            this.label78.Size = new System.Drawing.Size(56, 17);
            this.label78.TabIndex = 276;
            this.label78.Text = "建设单位";
            // 
            // label23
            // 
            this.label23.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.label23.AutoSize = true;
            this.label23.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.label23.BorderColor = System.Drawing.Color.White;
            this.label23.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label23.ForeColor = System.Drawing.Color.Black;
            this.label23.Location = new System.Drawing.Point(58, 64);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(56, 17);
            this.label23.TabIndex = 269;
            this.label23.Text = "项目名称";
            // 
            // label59
            // 
            this.label59.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.label59.AutoSize = true;
            this.label59.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.label59.BorderColor = System.Drawing.Color.White;
            this.label59.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label59.ForeColor = System.Drawing.Color.Black;
            this.label59.Location = new System.Drawing.Point(58, 99);
            this.label59.Name = "label59";
            this.label59.Size = new System.Drawing.Size(56, 17);
            this.label59.TabIndex = 267;
            this.label59.Text = "项目地址";
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.txGroupEX2);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.txtPasswd);
            this.tabPage1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabPage1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(768, 472);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.TabItemImage = null;
            this.tabPage1.Text = "工程基本信息";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.BorderColor = System.Drawing.Color.Gainsboro;
            this.groupBox2.CaptionColor = System.Drawing.Color.Black;
            this.groupBox2.CaptionFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold);
            this.groupBox2.Controls.Add(this.skinLabelEX14);
            this.groupBox2.Controls.Add(this.txtysbah);
            this.groupBox2.Controls.Add(this.skinLabelEX13);
            this.groupBox2.Controls.Add(this.lbl_wh3);
            this.groupBox2.Controls.Add(this.txtGhcode);
            this.groupBox2.Controls.Add(this.lbl_wh4);
            this.groupBox2.Controls.Add(this.txtSgcode);
            this.groupBox2.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.groupBox2.ForeColor = System.Drawing.Color.Black;
            this.groupBox2.Location = new System.Drawing.Point(7, 324);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.groupBox2.Size = new System.Drawing.Size(759, 89);
            this.groupBox2.TabIndex = 310;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "文号项";
            this.groupBox2.TextMargin = 6;
            // 
            // skinLabelEX14
            // 
            this.skinLabelEX14.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.skinLabelEX14.AutoSize = true;
            this.skinLabelEX14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.skinLabelEX14.BorderColor = System.Drawing.Color.White;
            this.skinLabelEX14.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabelEX14.ForeColor = System.Drawing.Color.Black;
            this.skinLabelEX14.Location = new System.Drawing.Point(55, 53);
            this.skinLabelEX14.Name = "skinLabelEX14";
            this.skinLabelEX14.Size = new System.Drawing.Size(68, 17);
            this.skinLabelEX14.TabIndex = 67;
            this.skinLabelEX14.Text = "验收备案号";
            // 
            // txtysbah
            // 
            this.txtysbah.BackColor = System.Drawing.Color.Transparent;
            this.txtysbah.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtysbah.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtysbah.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtysbah.HeightLightBolorColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.txtysbah.Image = null;
            this.txtysbah.ImageSize = new System.Drawing.Size(0, 0);
            this.txtysbah.Location = new System.Drawing.Point(127, 50);
            this.txtysbah.Margin = new System.Windows.Forms.Padding(0);
            this.txtysbah.MaxLength = 80;
            this.txtysbah.Name = "txtysbah";
            this.txtysbah.Padding = new System.Windows.Forms.Padding(3);
            this.txtysbah.PasswordChar = '\0';
            this.txtysbah.Required = false;
            this.txtysbah.Size = new System.Drawing.Size(602, 25);
            this.txtysbah.TabIndex = 26;
            // 
            // skinLabelEX13
            // 
            this.skinLabelEX13.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.skinLabelEX13.AutoSize = true;
            this.skinLabelEX13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.skinLabelEX13.BorderColor = System.Drawing.Color.White;
            this.skinLabelEX13.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabelEX13.ForeColor = System.Drawing.Color.Red;
            this.skinLabelEX13.Location = new System.Drawing.Point(338, 24);
            this.skinLabelEX13.Name = "skinLabelEX13";
            this.skinLabelEX13.Size = new System.Drawing.Size(13, 17);
            this.skinLabelEX13.TabIndex = 65;
            this.skinLabelEX13.Text = "*";
            this.skinLabelEX13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_wh3
            // 
            this.lbl_wh3.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.lbl_wh3.AutoSize = true;
            this.lbl_wh3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.lbl_wh3.BorderColor = System.Drawing.Color.White;
            this.lbl_wh3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_wh3.ForeColor = System.Drawing.Color.Black;
            this.lbl_wh3.Location = new System.Drawing.Point(19, 24);
            this.lbl_wh3.Name = "lbl_wh3";
            this.lbl_wh3.Size = new System.Drawing.Size(104, 17);
            this.lbl_wh3.TabIndex = 16;
            this.lbl_wh3.Text = "工程规划许可证号";
            // 
            // txtGhcode
            // 
            this.txtGhcode.BackColor = System.Drawing.Color.Transparent;
            this.txtGhcode.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtGhcode.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtGhcode.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtGhcode.HeightLightBolorColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.txtGhcode.Image = null;
            this.txtGhcode.ImageSize = new System.Drawing.Size(0, 0);
            this.txtGhcode.Location = new System.Drawing.Point(127, 19);
            this.txtGhcode.Margin = new System.Windows.Forms.Padding(0);
            this.txtGhcode.MaxLength = 80;
            this.txtGhcode.Name = "txtGhcode";
            this.txtGhcode.Padding = new System.Windows.Forms.Padding(3);
            this.txtGhcode.PasswordChar = '\0';
            this.txtGhcode.Required = false;
            this.txtGhcode.Size = new System.Drawing.Size(211, 25);
            this.txtGhcode.TabIndex = 24;
            // 
            // lbl_wh4
            // 
            this.lbl_wh4.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.lbl_wh4.AutoSize = true;
            this.lbl_wh4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.lbl_wh4.BorderColor = System.Drawing.Color.White;
            this.lbl_wh4.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_wh4.ForeColor = System.Drawing.Color.Black;
            this.lbl_wh4.Location = new System.Drawing.Point(410, 24);
            this.lbl_wh4.Name = "lbl_wh4";
            this.lbl_wh4.Size = new System.Drawing.Size(104, 17);
            this.lbl_wh4.TabIndex = 20;
            this.lbl_wh4.Text = "工程施工许可证号";
            // 
            // txtSgcode
            // 
            this.txtSgcode.BackColor = System.Drawing.Color.Transparent;
            this.txtSgcode.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtSgcode.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtSgcode.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtSgcode.HeightLightBolorColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.txtSgcode.Image = null;
            this.txtSgcode.ImageSize = new System.Drawing.Size(0, 0);
            this.txtSgcode.Location = new System.Drawing.Point(518, 19);
            this.txtSgcode.Margin = new System.Windows.Forms.Padding(0);
            this.txtSgcode.MaxLength = 80;
            this.txtSgcode.Name = "txtSgcode";
            this.txtSgcode.Padding = new System.Windows.Forms.Padding(3);
            this.txtSgcode.PasswordChar = '\0';
            this.txtSgcode.Required = false;
            this.txtSgcode.Size = new System.Drawing.Size(211, 25);
            this.txtSgcode.TabIndex = 25;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(191, 429);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(429, 20);
            this.label2.TabIndex = 82;
            this.label2.Text = "提示：请输入正确的资料信息，错误资料将会影响该项目的数据关联";
            // 
            // txGroupEX2
            // 
            this.txGroupEX2.BackColor = System.Drawing.Color.Transparent;
            this.txGroupEX2.BorderColor = System.Drawing.Color.Gainsboro;
            this.txGroupEX2.CaptionColor = System.Drawing.Color.Black;
            this.txGroupEX2.CaptionFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold);
            this.txGroupEX2.Controls.Add(this.skinLabelEX16);
            this.txGroupEX2.Controls.Add(this.skinLabelEX15);
            this.txGroupEX2.Controls.Add(this.skinLabelEX10);
            this.txGroupEX2.Controls.Add(this.skinLabelEX9);
            this.txGroupEX2.Controls.Add(this.skinLabelEX8);
            this.txGroupEX2.Controls.Add(this.skinLabelEX7);
            this.txGroupEX2.Controls.Add(this.skinLabelEX5);
            this.txGroupEX2.Controls.Add(this.skinLabelEX4);
            this.txGroupEX2.Controls.Add(this.txtJldw);
            this.txGroupEX2.Controls.Add(this.txtSgdw);
            this.txGroupEX2.Controls.Add(this.skinLabelEX6);
            this.txGroupEX2.Controls.Add(this.txtSjdw);
            this.txGroupEX2.Controls.Add(this.skinLabelEX3);
            this.txGroupEX2.Controls.Add(this.txtKcdw);
            this.txGroupEX2.Controls.Add(this.skinLabelEX2);
            this.txGroupEX2.Controls.Add(this.txtLxpzdw);
            this.txGroupEX2.Controls.Add(this.skinLabelEX1);
            this.txGroupEX2.Controls.Add(this.txtJsdw);
            this.txGroupEX2.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txGroupEX2.ForeColor = System.Drawing.Color.Black;
            this.txGroupEX2.Location = new System.Drawing.Point(7, 198);
            this.txGroupEX2.Name = "txGroupEX2";
            this.txGroupEX2.Size = new System.Drawing.Size(759, 120);
            this.txGroupEX2.TabIndex = 81;
            this.txGroupEX2.TabStop = false;
            this.txGroupEX2.Text = "责任单位";
            this.txGroupEX2.TextMargin = 6;
            // 
            // skinLabelEX16
            // 
            this.skinLabelEX16.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.skinLabelEX16.AutoSize = true;
            this.skinLabelEX16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.skinLabelEX16.BorderColor = System.Drawing.Color.White;
            this.skinLabelEX16.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabelEX16.ForeColor = System.Drawing.Color.Black;
            this.skinLabelEX16.Location = new System.Drawing.Point(458, 87);
            this.skinLabelEX16.Name = "skinLabelEX16";
            this.skinLabelEX16.Size = new System.Drawing.Size(56, 17);
            this.skinLabelEX16.TabIndex = 309;
            this.skinLabelEX16.Text = "监理单位";
            // 
            // skinLabelEX15
            // 
            this.skinLabelEX15.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.skinLabelEX15.AutoSize = true;
            this.skinLabelEX15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.skinLabelEX15.BorderColor = System.Drawing.Color.White;
            this.skinLabelEX15.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabelEX15.ForeColor = System.Drawing.Color.Black;
            this.skinLabelEX15.Location = new System.Drawing.Point(67, 87);
            this.skinLabelEX15.Name = "skinLabelEX15";
            this.skinLabelEX15.Size = new System.Drawing.Size(56, 17);
            this.skinLabelEX15.TabIndex = 308;
            this.skinLabelEX15.Text = "施工单位";
            // 
            // skinLabelEX10
            // 
            this.skinLabelEX10.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.skinLabelEX10.AutoSize = true;
            this.skinLabelEX10.BackColor = System.Drawing.Color.Transparent;
            this.skinLabelEX10.BorderColor = System.Drawing.Color.White;
            this.skinLabelEX10.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabelEX10.ForeColor = System.Drawing.Color.Red;
            this.skinLabelEX10.Location = new System.Drawing.Point(733, 88);
            this.skinLabelEX10.Name = "skinLabelEX10";
            this.skinLabelEX10.Size = new System.Drawing.Size(13, 17);
            this.skinLabelEX10.TabIndex = 307;
            this.skinLabelEX10.Text = "*";
            this.skinLabelEX10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // skinLabelEX9
            // 
            this.skinLabelEX9.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.skinLabelEX9.AutoSize = true;
            this.skinLabelEX9.BackColor = System.Drawing.Color.Transparent;
            this.skinLabelEX9.BorderColor = System.Drawing.Color.White;
            this.skinLabelEX9.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabelEX9.ForeColor = System.Drawing.Color.Red;
            this.skinLabelEX9.Location = new System.Drawing.Point(733, 57);
            this.skinLabelEX9.Name = "skinLabelEX9";
            this.skinLabelEX9.Size = new System.Drawing.Size(13, 17);
            this.skinLabelEX9.TabIndex = 306;
            this.skinLabelEX9.Text = "*";
            this.skinLabelEX9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // skinLabelEX8
            // 
            this.skinLabelEX8.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.skinLabelEX8.AutoSize = true;
            this.skinLabelEX8.BackColor = System.Drawing.Color.Transparent;
            this.skinLabelEX8.BorderColor = System.Drawing.Color.White;
            this.skinLabelEX8.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabelEX8.ForeColor = System.Drawing.Color.Red;
            this.skinLabelEX8.Location = new System.Drawing.Point(733, 23);
            this.skinLabelEX8.Name = "skinLabelEX8";
            this.skinLabelEX8.Size = new System.Drawing.Size(13, 17);
            this.skinLabelEX8.TabIndex = 305;
            this.skinLabelEX8.Text = "*";
            this.skinLabelEX8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // skinLabelEX7
            // 
            this.skinLabelEX7.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.skinLabelEX7.AutoSize = true;
            this.skinLabelEX7.BackColor = System.Drawing.Color.Transparent;
            this.skinLabelEX7.BorderColor = System.Drawing.Color.White;
            this.skinLabelEX7.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabelEX7.ForeColor = System.Drawing.Color.Red;
            this.skinLabelEX7.Location = new System.Drawing.Point(341, 88);
            this.skinLabelEX7.Name = "skinLabelEX7";
            this.skinLabelEX7.Size = new System.Drawing.Size(13, 17);
            this.skinLabelEX7.TabIndex = 304;
            this.skinLabelEX7.Text = "*";
            this.skinLabelEX7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // skinLabelEX5
            // 
            this.skinLabelEX5.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.skinLabelEX5.AutoSize = true;
            this.skinLabelEX5.BackColor = System.Drawing.Color.Transparent;
            this.skinLabelEX5.BorderColor = System.Drawing.Color.White;
            this.skinLabelEX5.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabelEX5.ForeColor = System.Drawing.Color.Red;
            this.skinLabelEX5.Location = new System.Drawing.Point(341, 57);
            this.skinLabelEX5.Name = "skinLabelEX5";
            this.skinLabelEX5.Size = new System.Drawing.Size(13, 17);
            this.skinLabelEX5.TabIndex = 303;
            this.skinLabelEX5.Text = "*";
            this.skinLabelEX5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // skinLabelEX4
            // 
            this.skinLabelEX4.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.skinLabelEX4.AutoSize = true;
            this.skinLabelEX4.BackColor = System.Drawing.Color.Transparent;
            this.skinLabelEX4.BorderColor = System.Drawing.Color.White;
            this.skinLabelEX4.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabelEX4.ForeColor = System.Drawing.Color.Red;
            this.skinLabelEX4.Location = new System.Drawing.Point(341, 23);
            this.skinLabelEX4.Name = "skinLabelEX4";
            this.skinLabelEX4.Size = new System.Drawing.Size(13, 17);
            this.skinLabelEX4.TabIndex = 63;
            this.skinLabelEX4.Text = "*";
            this.skinLabelEX4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtJldw
            // 
            this.txtJldw.BackColor = System.Drawing.Color.Transparent;
            this.txtJldw.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtJldw.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtJldw.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtJldw.HeightLightBolorColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.txtJldw.Image = null;
            this.txtJldw.ImageSize = new System.Drawing.Size(0, 0);
            this.txtJldw.Location = new System.Drawing.Point(518, 83);
            this.txtJldw.MaxLength = 30;
            this.txtJldw.Name = "txtJldw";
            this.txtJldw.Padding = new System.Windows.Forms.Padding(2);
            this.txtJldw.PasswordChar = '\0';
            this.txtJldw.Required = false;
            this.txtJldw.Size = new System.Drawing.Size(211, 25);
            this.txtJldw.TabIndex = 23;
            this.txtJldw.Tag = "总长度,number";
            // 
            // txtSgdw
            // 
            this.txtSgdw.BackColor = System.Drawing.Color.Transparent;
            this.txtSgdw.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtSgdw.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtSgdw.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtSgdw.HeightLightBolorColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.txtSgdw.Image = null;
            this.txtSgdw.ImageSize = new System.Drawing.Size(0, 0);
            this.txtSgdw.Location = new System.Drawing.Point(127, 83);
            this.txtSgdw.MaxLength = 30;
            this.txtSgdw.Name = "txtSgdw";
            this.txtSgdw.Padding = new System.Windows.Forms.Padding(2);
            this.txtSgdw.PasswordChar = '\0';
            this.txtSgdw.Required = false;
            this.txtSgdw.Size = new System.Drawing.Size(211, 25);
            this.txtSgdw.TabIndex = 22;
            this.txtSgdw.Tag = "总长度,number";
            // 
            // skinLabelEX6
            // 
            this.skinLabelEX6.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.skinLabelEX6.AutoSize = true;
            this.skinLabelEX6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.skinLabelEX6.BorderColor = System.Drawing.Color.White;
            this.skinLabelEX6.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabelEX6.ForeColor = System.Drawing.Color.Black;
            this.skinLabelEX6.Location = new System.Drawing.Point(68, 55);
            this.skinLabelEX6.Name = "skinLabelEX6";
            this.skinLabelEX6.Size = new System.Drawing.Size(56, 17);
            this.skinLabelEX6.TabIndex = 297;
            this.skinLabelEX6.Text = "设计单位";
            // 
            // txtSjdw
            // 
            this.txtSjdw.BackColor = System.Drawing.Color.Transparent;
            this.txtSjdw.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtSjdw.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtSjdw.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtSjdw.HeightLightBolorColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.txtSjdw.Image = null;
            this.txtSjdw.ImageSize = new System.Drawing.Size(0, 0);
            this.txtSjdw.Location = new System.Drawing.Point(127, 51);
            this.txtSjdw.MaxLength = 30;
            this.txtSjdw.Name = "txtSjdw";
            this.txtSjdw.Padding = new System.Windows.Forms.Padding(2);
            this.txtSjdw.PasswordChar = '\0';
            this.txtSjdw.Required = false;
            this.txtSjdw.Size = new System.Drawing.Size(211, 25);
            this.txtSjdw.TabIndex = 20;
            this.txtSjdw.Tag = "总长度,number";
            // 
            // skinLabelEX3
            // 
            this.skinLabelEX3.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.skinLabelEX3.AutoSize = true;
            this.skinLabelEX3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.skinLabelEX3.BorderColor = System.Drawing.Color.White;
            this.skinLabelEX3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabelEX3.ForeColor = System.Drawing.Color.Black;
            this.skinLabelEX3.Location = new System.Drawing.Point(458, 55);
            this.skinLabelEX3.Name = "skinLabelEX3";
            this.skinLabelEX3.Size = new System.Drawing.Size(56, 17);
            this.skinLabelEX3.TabIndex = 295;
            this.skinLabelEX3.Text = "勘察单位";
            // 
            // txtKcdw
            // 
            this.txtKcdw.BackColor = System.Drawing.Color.Transparent;
            this.txtKcdw.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtKcdw.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtKcdw.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtKcdw.HeightLightBolorColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.txtKcdw.Image = null;
            this.txtKcdw.ImageSize = new System.Drawing.Size(0, 0);
            this.txtKcdw.Location = new System.Drawing.Point(518, 51);
            this.txtKcdw.MaxLength = 30;
            this.txtKcdw.Name = "txtKcdw";
            this.txtKcdw.Padding = new System.Windows.Forms.Padding(2);
            this.txtKcdw.PasswordChar = '\0';
            this.txtKcdw.Required = false;
            this.txtKcdw.Size = new System.Drawing.Size(211, 25);
            this.txtKcdw.TabIndex = 21;
            this.txtKcdw.Tag = "总长度,number";
            // 
            // skinLabelEX2
            // 
            this.skinLabelEX2.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.skinLabelEX2.AutoSize = true;
            this.skinLabelEX2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.skinLabelEX2.BorderColor = System.Drawing.Color.White;
            this.skinLabelEX2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabelEX2.ForeColor = System.Drawing.Color.Black;
            this.skinLabelEX2.Location = new System.Drawing.Point(434, 22);
            this.skinLabelEX2.Name = "skinLabelEX2";
            this.skinLabelEX2.Size = new System.Drawing.Size(80, 17);
            this.skinLabelEX2.TabIndex = 293;
            this.skinLabelEX2.Text = "立项批准单位";
            // 
            // txtLxpzdw
            // 
            this.txtLxpzdw.BackColor = System.Drawing.Color.Transparent;
            this.txtLxpzdw.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtLxpzdw.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtLxpzdw.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtLxpzdw.HeightLightBolorColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.txtLxpzdw.Image = null;
            this.txtLxpzdw.ImageSize = new System.Drawing.Size(0, 0);
            this.txtLxpzdw.Location = new System.Drawing.Point(518, 18);
            this.txtLxpzdw.MaxLength = 30;
            this.txtLxpzdw.Name = "txtLxpzdw";
            this.txtLxpzdw.Padding = new System.Windows.Forms.Padding(2);
            this.txtLxpzdw.PasswordChar = '\0';
            this.txtLxpzdw.Required = false;
            this.txtLxpzdw.Size = new System.Drawing.Size(211, 25);
            this.txtLxpzdw.TabIndex = 19;
            this.txtLxpzdw.Tag = "总长度,number";
            // 
            // skinLabelEX1
            // 
            this.skinLabelEX1.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.skinLabelEX1.AutoSize = true;
            this.skinLabelEX1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.skinLabelEX1.BorderColor = System.Drawing.Color.White;
            this.skinLabelEX1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabelEX1.ForeColor = System.Drawing.Color.Black;
            this.skinLabelEX1.Location = new System.Drawing.Point(68, 22);
            this.skinLabelEX1.Name = "skinLabelEX1";
            this.skinLabelEX1.Size = new System.Drawing.Size(56, 17);
            this.skinLabelEX1.TabIndex = 291;
            this.skinLabelEX1.Text = "建设单位";
            // 
            // txtJsdw
            // 
            this.txtJsdw.BackColor = System.Drawing.Color.Transparent;
            this.txtJsdw.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtJsdw.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtJsdw.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtJsdw.HeightLightBolorColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.txtJsdw.Image = null;
            this.txtJsdw.ImageSize = new System.Drawing.Size(0, 0);
            this.txtJsdw.Location = new System.Drawing.Point(127, 18);
            this.txtJsdw.MaxLength = 30;
            this.txtJsdw.Name = "txtJsdw";
            this.txtJsdw.Padding = new System.Windows.Forms.Padding(2);
            this.txtJsdw.PasswordChar = '\0';
            this.txtJsdw.Required = false;
            this.txtJsdw.Size = new System.Drawing.Size(211, 25);
            this.txtJsdw.TabIndex = 18;
            this.txtJsdw.Tag = "总长度,number";
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSize = true;
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.BorderColor = System.Drawing.Color.Gainsboro;
            this.groupBox1.CaptionColor = System.Drawing.Color.Black;
            this.groupBox1.CaptionFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold);
            this.groupBox1.Controls.Add(this.skinLabelEX24);
            this.groupBox1.Controls.Add(this.cboProjectType);
            this.groupBox1.Controls.Add(this.label27);
            this.groupBox1.Controls.Add(this.skinLabelEX19);
            this.groupBox1.Controls.Add(this.skinLabelEX12);
            this.groupBox1.Controls.Add(this.skinLabelEX11);
            this.groupBox1.Controls.Add(this.label25);
            this.groupBox1.Controls.Add(this.label26);
            this.groupBox1.Controls.Add(this.lbl_ProjectNO);
            this.groupBox1.Controls.Add(this.txtProjectNo);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.txtAddress);
            this.groupBox1.Controls.Add(this.dtpBeginDate);
            this.groupBox1.Controls.Add(this.dtpEndDate);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtProjectName);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cboDistrict);
            this.groupBox1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(7, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(759, 189);
            this.groupBox1.TabIndex = 54;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "工程信息";
            this.groupBox1.TextMargin = 6;
            // 
            // skinLabelEX24
            // 
            this.skinLabelEX24.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.skinLabelEX24.AutoSize = true;
            this.skinLabelEX24.BackColor = System.Drawing.Color.Transparent;
            this.skinLabelEX24.BorderColor = System.Drawing.Color.White;
            this.skinLabelEX24.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabelEX24.ForeColor = System.Drawing.Color.Red;
            this.skinLabelEX24.Location = new System.Drawing.Point(728, 20);
            this.skinLabelEX24.Name = "skinLabelEX24";
            this.skinLabelEX24.Size = new System.Drawing.Size(13, 17);
            this.skinLabelEX24.TabIndex = 304;
            this.skinLabelEX24.Text = "*";
            this.skinLabelEX24.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label27
            // 
            this.label27.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.label27.AutoSize = true;
            this.label27.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.label27.BorderColor = System.Drawing.Color.White;
            this.label27.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label27.ForeColor = System.Drawing.Color.Black;
            this.label27.Location = new System.Drawing.Point(64, 20);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(56, 17);
            this.label27.TabIndex = 302;
            this.label27.Text = "工程类别";
            // 
            // skinLabelEX19
            // 
            this.skinLabelEX19.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.skinLabelEX19.AutoSize = true;
            this.skinLabelEX19.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.skinLabelEX19.BorderColor = System.Drawing.Color.White;
            this.skinLabelEX19.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabelEX19.ForeColor = System.Drawing.Color.Red;
            this.skinLabelEX19.Location = new System.Drawing.Point(728, 82);
            this.skinLabelEX19.Name = "skinLabelEX19";
            this.skinLabelEX19.Size = new System.Drawing.Size(13, 17);
            this.skinLabelEX19.TabIndex = 65;
            this.skinLabelEX19.Text = "*";
            this.skinLabelEX19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // skinLabelEX12
            // 
            this.skinLabelEX12.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.skinLabelEX12.AutoSize = true;
            this.skinLabelEX12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.skinLabelEX12.BorderColor = System.Drawing.Color.White;
            this.skinLabelEX12.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabelEX12.ForeColor = System.Drawing.Color.Red;
            this.skinLabelEX12.Location = new System.Drawing.Point(339, 149);
            this.skinLabelEX12.Name = "skinLabelEX12";
            this.skinLabelEX12.Size = new System.Drawing.Size(13, 17);
            this.skinLabelEX12.TabIndex = 64;
            this.skinLabelEX12.Text = "*";
            this.skinLabelEX12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // skinLabelEX11
            // 
            this.skinLabelEX11.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.skinLabelEX11.AutoSize = true;
            this.skinLabelEX11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.skinLabelEX11.BorderColor = System.Drawing.Color.White;
            this.skinLabelEX11.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabelEX11.ForeColor = System.Drawing.Color.Red;
            this.skinLabelEX11.Location = new System.Drawing.Point(729, 148);
            this.skinLabelEX11.Name = "skinLabelEX11";
            this.skinLabelEX11.Size = new System.Drawing.Size(13, 17);
            this.skinLabelEX11.TabIndex = 63;
            this.skinLabelEX11.Text = "*";
            this.skinLabelEX11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label25
            // 
            this.label25.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.label25.AutoSize = true;
            this.label25.BackColor = System.Drawing.Color.Transparent;
            this.label25.BorderColor = System.Drawing.Color.White;
            this.label25.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label25.ForeColor = System.Drawing.Color.Red;
            this.label25.Location = new System.Drawing.Point(728, 49);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(13, 17);
            this.label25.TabIndex = 61;
            this.label25.Text = "*";
            this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label26
            // 
            this.label26.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.label26.AutoSize = true;
            this.label26.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.label26.BorderColor = System.Drawing.Color.White;
            this.label26.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label26.ForeColor = System.Drawing.Color.Red;
            this.label26.Location = new System.Drawing.Point(728, 115);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(13, 17);
            this.label26.TabIndex = 57;
            this.label26.Text = "*";
            this.label26.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_ProjectNO
            // 
            this.lbl_ProjectNO.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.lbl_ProjectNO.AutoSize = true;
            this.lbl_ProjectNO.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.lbl_ProjectNO.BorderColor = System.Drawing.Color.White;
            this.lbl_ProjectNO.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_ProjectNO.ForeColor = System.Drawing.Color.Blue;
            this.lbl_ProjectNO.Location = new System.Drawing.Point(20, 51);
            this.lbl_ProjectNO.Name = "lbl_ProjectNO";
            this.lbl_ProjectNO.Size = new System.Drawing.Size(100, 17);
            this.lbl_ProjectNO.TabIndex = 51;
            this.lbl_ProjectNO.Text = "工程编号(备案号)";
            // 
            // label13
            // 
            this.label13.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.label13.BorderColor = System.Drawing.Color.White;
            this.label13.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label13.ForeColor = System.Drawing.Color.Black;
            this.label13.Location = new System.Drawing.Point(454, 148);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(56, 17);
            this.label13.TabIndex = 25;
            this.label13.Text = "竣工时间";
            // 
            // label11
            // 
            this.label11.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.label11.BorderColor = System.Drawing.Color.White;
            this.label11.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(64, 148);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(56, 17);
            this.label11.TabIndex = 22;
            this.label11.Text = "开工时间";
            // 
            // label3
            // 
            this.label3.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.label3.BorderColor = System.Drawing.Color.White;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(64, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "工程名称";
            // 
            // label4
            // 
            this.label4.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.label4.BorderColor = System.Drawing.Color.White;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(64, 115);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "工程地址";
            // 
            // txtPasswd
            // 
            this.txtPasswd.BackColor = System.Drawing.Color.Transparent;
            this.txtPasswd.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtPasswd.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtPasswd.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtPasswd.HeightLightBolorColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.txtPasswd.Image = null;
            this.txtPasswd.ImageSize = new System.Drawing.Size(0, 0);
            this.txtPasswd.Location = new System.Drawing.Point(-31, -14);
            this.txtPasswd.MaxLength = 15;
            this.txtPasswd.Name = "txtPasswd";
            this.txtPasswd.Padding = new System.Windows.Forms.Padding(3);
            this.txtPasswd.PasswordChar = '\0';
            this.txtPasswd.Required = false;
            this.txtPasswd.Size = new System.Drawing.Size(15, 29);
            this.txtPasswd.TabIndex = 17;
            this.txtPasswd.Visible = false;
            // 
            // tabPage2
            // 
            this.tabPage2.AutoScroll = true;
            this.tabPage2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.tabPage2.Controls.Add(this.gbjz);
            this.tabPage2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(768, 472);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.TabItemImage = null;
            this.tabPage2.Text = "工程扩展信息";
            // 
            // gbjz
            // 
            this.gbjz.AutoSize = true;
            this.gbjz.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.gbjz.BorderColor = System.Drawing.Color.Gainsboro;
            this.gbjz.CaptionColor = System.Drawing.Color.Black;
            this.gbjz.CaptionFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold);
            this.gbjz.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gbjz.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.gbjz.Location = new System.Drawing.Point(0, 1);
            this.gbjz.Margin = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.gbjz.Name = "gbjz";
            this.gbjz.Size = new System.Drawing.Size(768, 471);
            this.gbjz.TabIndex = 56;
            this.gbjz.TabStop = false;
            this.gbjz.Text = "专业记载";
            this.gbjz.TextMargin = 6;
            // 
            // tabPage5
            // 
            this.tabPage5.AutoScroll = true;
            this.tabPage5.Controls.Add(this.txGroupEX3);
            this.tabPage5.Location = new System.Drawing.Point(4, 29);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(768, 472);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "工程坐标信息预览";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // txGroupEX3
            // 
            this.txGroupEX3.BackColor = System.Drawing.Color.Transparent;
            this.txGroupEX3.BorderColor = System.Drawing.Color.Gainsboro;
            this.txGroupEX3.CaptionColor = System.Drawing.Color.Black;
            this.txGroupEX3.CaptionFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold);
            this.txGroupEX3.Controls.Add(this.dgvPoint);
            this.txGroupEX3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txGroupEX3.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.txGroupEX3.ForeColor = System.Drawing.Color.Black;
            this.txGroupEX3.Location = new System.Drawing.Point(3, 3);
            this.txGroupEX3.Name = "txGroupEX3";
            this.txGroupEX3.Size = new System.Drawing.Size(762, 466);
            this.txGroupEX3.TabIndex = 0;
            this.txGroupEX3.TabStop = false;
            this.txGroupEX3.Text = "坐标列表";
            this.txGroupEX3.TextMargin = 6;
            // 
            // dgvPoint
            // 
            this.dgvPoint.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            this.dgvPoint.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPoint.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPoint.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvPoint.BackgroundColor = System.Drawing.Color.White;
            this.dgvPoint.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvPoint.ColumnFont = null;
            this.dgvPoint.ColumnForeColor = System.Drawing.Color.Black;
            this.dgvPoint.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(246)))), ((int)(((byte)(239)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(235)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPoint.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvPoint.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPoint.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.OrderIndex,
            this.X,
            this.Y});
            this.dgvPoint.ColumnSelectBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(215)))), ((int)(((byte)(244)))));
            this.dgvPoint.ColumnSelectForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(188)))), ((int)(((byte)(240)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPoint.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvPoint.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPoint.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvPoint.EnableHeadersVisualStyles = false;
            this.dgvPoint.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dgvPoint.GridColor = System.Drawing.Color.Gainsboro;
            this.dgvPoint.HeadFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dgvPoint.HeadSelectBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(235)))), ((int)(((byte)(252)))));
            this.dgvPoint.HeadSelectForeColor = System.Drawing.SystemColors.ControlText;
            this.dgvPoint.LineNumber = false;
            this.dgvPoint.LineNumberForeColor = System.Drawing.Color.Black;
            this.dgvPoint.Location = new System.Drawing.Point(3, 19);
            this.dgvPoint.MultiSelect = false;
            this.dgvPoint.Name = "dgvPoint";
            this.dgvPoint.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvPoint.RowHeadersVisible = false;
            this.dgvPoint.RowHeadersWidth = 22;
            this.dgvPoint.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(215)))), ((int)(((byte)(244)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvPoint.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvPoint.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvPoint.RowTemplate.Height = 25;
            this.dgvPoint.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPoint.Size = new System.Drawing.Size(756, 444);
            this.dgvPoint.SkinGridColor = System.Drawing.Color.Gainsboro;
            this.dgvPoint.TabIndex = 3;
            this.dgvPoint.TitleBack = null;
            this.dgvPoint.TitleBackColorBegin = System.Drawing.Color.White;
            this.dgvPoint.TitleBackColorEnd = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(235)))), ((int)(((byte)(252)))));
            // 
            // ID
            // 
            this.ID.HeaderText = "Column1";
            this.ID.Name = "ID";
            this.ID.Visible = false;
            // 
            // OrderIndex
            // 
            this.OrderIndex.HeaderText = "排序";
            this.OrderIndex.Name = "OrderIndex";
            this.OrderIndex.ReadOnly = true;
            // 
            // X
            // 
            this.X.HeaderText = "X坐标";
            this.X.Name = "X";
            this.X.ReadOnly = true;
            // 
            // Y
            // 
            this.Y.HeaderText = "Y坐标";
            this.Y.Name = "Y";
            this.Y.ReadOnly = true;
            this.Y.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // label6
            // 
            this.label6.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.label6.BorderColor = System.Drawing.Color.White;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(81, 278);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 17);
            this.label6.TabIndex = 289;
            this.label6.Text = "总长度";
            // 
            // label15
            // 
            this.label15.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.label15.BorderColor = System.Drawing.Color.White;
            this.label15.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label15.ForeColor = System.Drawing.Color.Black;
            this.label15.Location = new System.Drawing.Point(93, 216);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(32, 17);
            this.label15.TabIndex = 284;
            this.label15.Text = "栋数";
            // 
            // label66
            // 
            this.label66.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.label66.AutoSize = true;
            this.label66.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.label66.BorderColor = System.Drawing.Color.White;
            this.label66.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label66.ForeColor = System.Drawing.Color.Black;
            this.label66.Location = new System.Drawing.Point(30, 150);
            this.label66.Name = "label66";
            this.label66.Size = new System.Drawing.Size(95, 17);
            this.label66.TabIndex = 273;
            this.label66.Text = "总建筑面积(M2)";
            // 
            // label67
            // 
            this.label67.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.label67.AutoSize = true;
            this.label67.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.label67.BorderColor = System.Drawing.Color.White;
            this.label67.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label67.ForeColor = System.Drawing.Color.Black;
            this.label67.Location = new System.Drawing.Point(279, 183);
            this.label67.Name = "label67";
            this.label67.Size = new System.Drawing.Size(95, 17);
            this.label67.TabIndex = 274;
            this.label67.Text = "总用地面积(M2)";
            // 
            // label70
            // 
            this.label70.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.label70.AutoSize = true;
            this.label70.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.label70.BorderColor = System.Drawing.Color.White;
            this.label70.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label70.ForeColor = System.Drawing.Color.Black;
            this.label70.Location = new System.Drawing.Point(543, 183);
            this.label70.Name = "label70";
            this.label70.Size = new System.Drawing.Size(76, 17);
            this.label70.TabIndex = 275;
            this.label70.Text = "总地价(万元)";
            // 
            // label72
            // 
            this.label72.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.label72.AutoSize = true;
            this.label72.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.label72.BorderColor = System.Drawing.Color.White;
            this.label72.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label72.ForeColor = System.Drawing.Color.Black;
            this.label72.Location = new System.Drawing.Point(81, 183);
            this.label72.Name = "label72";
            this.label72.Size = new System.Drawing.Size(44, 17);
            this.label72.TabIndex = 277;
            this.label72.Text = "容积率";
            // 
            // txtItemFzr
            // 
            this.txtItemFzr.BackColor = System.Drawing.Color.Transparent;
            this.txtItemFzr.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtItemFzr.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtItemFzr.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtItemFzr.HeightLightBolorColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.txtItemFzr.Image = null;
            this.txtItemFzr.ImageSize = new System.Drawing.Size(0, 0);
            this.txtItemFzr.Location = new System.Drawing.Point(624, 85);
            this.txtItemFzr.MaxLength = 20;
            this.txtItemFzr.Name = "txtItemFzr";
            this.txtItemFzr.Padding = new System.Windows.Forms.Padding(3);
            this.txtItemFzr.PasswordChar = '\0';
            this.txtItemFzr.Required = false;
            this.txtItemFzr.Size = new System.Drawing.Size(110, 25);
            this.txtItemFzr.TabIndex = 272;
            // 
            // txtRespective
            // 
            this.txtRespective.BackColor = System.Drawing.Color.Transparent;
            this.txtRespective.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtRespective.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtRespective.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtRespective.HeightLightBolorColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.txtRespective.Image = null;
            this.txtRespective.ImageSize = new System.Drawing.Size(0, 0);
            this.txtRespective.Location = new System.Drawing.Point(131, 85);
            this.txtRespective.MaxLength = 20;
            this.txtRespective.Name = "txtRespective";
            this.txtRespective.Padding = new System.Windows.Forms.Padding(3);
            this.txtRespective.PasswordChar = '\0';
            this.txtRespective.Required = false;
            this.txtRespective.Size = new System.Drawing.Size(110, 25);
            this.txtRespective.TabIndex = 256;
            // 
            // txtProjectType
            // 
            this.txtProjectType.BackColor = System.Drawing.Color.Transparent;
            this.txtProjectType.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtProjectType.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtProjectType.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtProjectType.HeightLightBolorColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.txtProjectType.Image = null;
            this.txtProjectType.ImageSize = new System.Drawing.Size(0, 0);
            this.txtProjectType.Location = new System.Drawing.Point(380, 85);
            this.txtProjectType.MaxLength = 20;
            this.txtProjectType.Name = "txtProjectType";
            this.txtProjectType.Padding = new System.Windows.Forms.Padding(3);
            this.txtProjectType.PasswordChar = '\0';
            this.txtProjectType.Required = false;
            this.txtProjectType.Size = new System.Drawing.Size(110, 25);
            this.txtProjectType.TabIndex = 258;
            // 
            // label73
            // 
            this.label73.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.label73.AutoSize = true;
            this.label73.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.label73.BorderColor = System.Drawing.Color.White;
            this.label73.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label73.ForeColor = System.Drawing.Color.Black;
            this.label73.Location = new System.Drawing.Point(298, 246);
            this.label73.Name = "label73";
            this.label73.Size = new System.Drawing.Size(76, 17);
            this.label73.TabIndex = 278;
            this.label73.Text = "总预算(万元)";
            // 
            // label74
            // 
            this.label74.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.label74.AutoSize = true;
            this.label74.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.label74.BorderColor = System.Drawing.Color.White;
            this.label74.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label74.ForeColor = System.Drawing.Color.Black;
            this.label74.Location = new System.Drawing.Point(543, 248);
            this.label74.Name = "label74";
            this.label74.Size = new System.Drawing.Size(76, 17);
            this.label74.TabIndex = 279;
            this.label74.Text = "总结算(万元)";
            // 
            // label75
            // 
            this.label75.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.label75.AutoSize = true;
            this.label75.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.label75.BorderColor = System.Drawing.Color.White;
            this.label75.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label75.ForeColor = System.Drawing.Color.Black;
            this.label75.Location = new System.Drawing.Point(311, 215);
            this.label75.Name = "label75";
            this.label75.Size = new System.Drawing.Size(63, 17);
            this.label75.TabIndex = 280;
            this.label75.Text = "绿化率(%)";
            // 
            // label76
            // 
            this.label76.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.label76.AutoSize = true;
            this.label76.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.label76.BorderColor = System.Drawing.Color.White;
            this.label76.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label76.ForeColor = System.Drawing.Color.Black;
            this.label76.Location = new System.Drawing.Point(544, 216);
            this.label76.Name = "label76";
            this.label76.Size = new System.Drawing.Size(75, 17);
            this.label76.TabIndex = 281;
            this.label76.Text = "建筑密度(%)";
            // 
            // label77
            // 
            this.label77.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.label77.AutoSize = true;
            this.label77.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.label77.BorderColor = System.Drawing.Color.White;
            this.label77.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label77.ForeColor = System.Drawing.Color.Black;
            this.label77.Location = new System.Drawing.Point(551, 88);
            this.label77.Name = "label77";
            this.label77.Size = new System.Drawing.Size(68, 17);
            this.label77.TabIndex = 282;
            this.label77.Text = "项目负责人";
            // 
            // label22
            // 
            this.label22.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.label22.AutoSize = true;
            this.label22.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.label22.BorderColor = System.Drawing.Color.White;
            this.label22.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label22.ForeColor = System.Drawing.Color.Black;
            this.label22.Location = new System.Drawing.Point(69, 88);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(56, 17);
            this.label22.TabIndex = 270;
            this.label22.Text = "所属区域";
            // 
            // label57
            // 
            this.label57.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.label57.AutoSize = true;
            this.label57.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.label57.BorderColor = System.Drawing.Color.White;
            this.label57.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label57.ForeColor = System.Drawing.Color.Black;
            this.label57.Location = new System.Drawing.Point(318, 88);
            this.label57.Name = "label57";
            this.label57.Size = new System.Drawing.Size(56, 17);
            this.label57.TabIndex = 268;
            this.label57.Text = "建筑性质";
            // 
            // txtzcd
            // 
            this.txtzcd.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtzcd.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtzcd.DecimalLength = 3;
            this.txtzcd.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtzcd.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtzcd.HeightLightBolorColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.txtzcd.Image = null;
            this.txtzcd.ImageSize = new System.Drawing.Size(0, 0);
            this.txtzcd.Location = new System.Drawing.Point(131, 275);
            this.txtzcd.MaxValuelLength = 1;
            this.txtzcd.Name = "txtzcd";
            this.txtzcd.PasswordChar = '\0';
            this.txtzcd.PromptChar = ' ';
            this.txtzcd.Required = false;
            this.txtzcd.ShowMsg = false;
            this.txtzcd.Size = new System.Drawing.Size(110, 25);
            this.txtzcd.TabIndex = 290;
            this.txtzcd.Tag = "总长度,number";
            // 
            // txtds
            // 
            this.txtds.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtds.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtds.DecimalLength = 3;
            this.txtds.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtds.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtds.HeightLightBolorColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.txtds.Image = null;
            this.txtds.ImageSize = new System.Drawing.Size(0, 0);
            this.txtds.Location = new System.Drawing.Point(131, 213);
            this.txtds.MaxValuelLength = 1;
            this.txtds.Name = "txtds";
            this.txtds.PasswordChar = '\0';
            this.txtds.PromptChar = ' ';
            this.txtds.Required = false;
            this.txtds.ShowMsg = false;
            this.txtds.Size = new System.Drawing.Size(110, 25);
            this.txtds.TabIndex = 283;
            this.txtds.Tag = "栋数,int";
            // 
            // txtConstructionAreaSum
            // 
            this.txtConstructionAreaSum.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtConstructionAreaSum.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtConstructionAreaSum.DecimalLength = 3;
            this.txtConstructionAreaSum.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtConstructionAreaSum.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtConstructionAreaSum.HeightLightBolorColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.txtConstructionAreaSum.Image = null;
            this.txtConstructionAreaSum.ImageSize = new System.Drawing.Size(0, 0);
            this.txtConstructionAreaSum.Location = new System.Drawing.Point(131, 148);
            this.txtConstructionAreaSum.MaxValuelLength = 1;
            this.txtConstructionAreaSum.Name = "txtConstructionAreaSum";
            this.txtConstructionAreaSum.PasswordChar = '\0';
            this.txtConstructionAreaSum.PromptChar = ' ';
            this.txtConstructionAreaSum.Required = false;
            this.txtConstructionAreaSum.ShowMsg = false;
            this.txtConstructionAreaSum.Size = new System.Drawing.Size(603, 25);
            this.txtConstructionAreaSum.TabIndex = 259;
            this.txtConstructionAreaSum.Tag = "总建筑面积,number";
            // 
            // txtUseSoiAreaSum
            // 
            this.txtUseSoiAreaSum.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtUseSoiAreaSum.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtUseSoiAreaSum.DecimalLength = 3;
            this.txtUseSoiAreaSum.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtUseSoiAreaSum.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtUseSoiAreaSum.HeightLightBolorColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.txtUseSoiAreaSum.Image = null;
            this.txtUseSoiAreaSum.ImageSize = new System.Drawing.Size(0, 0);
            this.txtUseSoiAreaSum.Location = new System.Drawing.Point(380, 179);
            this.txtUseSoiAreaSum.MaxValuelLength = 1;
            this.txtUseSoiAreaSum.Name = "txtUseSoiAreaSum";
            this.txtUseSoiAreaSum.PasswordChar = '\0';
            this.txtUseSoiAreaSum.PromptChar = ' ';
            this.txtUseSoiAreaSum.Required = false;
            this.txtUseSoiAreaSum.ShowMsg = false;
            this.txtUseSoiAreaSum.Size = new System.Drawing.Size(110, 25);
            this.txtUseSoiAreaSum.TabIndex = 260;
            this.txtUseSoiAreaSum.Tag = "总用地面积,number";
            // 
            // txtAllCost
            // 
            this.txtAllCost.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtAllCost.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtAllCost.DecimalLength = 3;
            this.txtAllCost.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtAllCost.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtAllCost.HeightLightBolorColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.txtAllCost.Image = null;
            this.txtAllCost.ImageSize = new System.Drawing.Size(0, 0);
            this.txtAllCost.Location = new System.Drawing.Point(624, 179);
            this.txtAllCost.MaxValuelLength = 1;
            this.txtAllCost.Name = "txtAllCost";
            this.txtAllCost.PasswordChar = '\0';
            this.txtAllCost.PromptChar = ' ';
            this.txtAllCost.Required = false;
            this.txtAllCost.ShowMsg = false;
            this.txtAllCost.Size = new System.Drawing.Size(110, 25);
            this.txtAllCost.TabIndex = 263;
            this.txtAllCost.Tag = "总地价,number";
            // 
            // txtProjectSettlement
            // 
            this.txtProjectSettlement.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtProjectSettlement.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtProjectSettlement.DecimalLength = 3;
            this.txtProjectSettlement.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtProjectSettlement.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtProjectSettlement.HeightLightBolorColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.txtProjectSettlement.Image = null;
            this.txtProjectSettlement.ImageSize = new System.Drawing.Size(0, 0);
            this.txtProjectSettlement.Location = new System.Drawing.Point(380, 243);
            this.txtProjectSettlement.MaxValuelLength = 1;
            this.txtProjectSettlement.Name = "txtProjectSettlement";
            this.txtProjectSettlement.PasswordChar = '\0';
            this.txtProjectSettlement.PromptChar = ' ';
            this.txtProjectSettlement.Required = false;
            this.txtProjectSettlement.ShowMsg = false;
            this.txtProjectSettlement.Size = new System.Drawing.Size(110, 25);
            this.txtProjectSettlement.TabIndex = 262;
            this.txtProjectSettlement.Tag = "工程结算,number";
            // 
            // txtProjectCost
            // 
            this.txtProjectCost.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtProjectCost.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtProjectCost.DecimalLength = 3;
            this.txtProjectCost.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtProjectCost.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtProjectCost.HeightLightBolorColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.txtProjectCost.Image = null;
            this.txtProjectCost.ImageSize = new System.Drawing.Size(0, 0);
            this.txtProjectCost.Location = new System.Drawing.Point(624, 244);
            this.txtProjectCost.MaxValuelLength = 1;
            this.txtProjectCost.Name = "txtProjectCost";
            this.txtProjectCost.PasswordChar = '\0';
            this.txtProjectCost.PromptChar = ' ';
            this.txtProjectCost.Required = false;
            this.txtProjectCost.ShowMsg = false;
            this.txtProjectCost.Size = new System.Drawing.Size(110, 25);
            this.txtProjectCost.TabIndex = 261;
            this.txtProjectCost.Tag = "工程造价,number";
            // 
            // txtVolumeFar
            // 
            this.txtVolumeFar.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtVolumeFar.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtVolumeFar.DecimalLength = 3;
            this.txtVolumeFar.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtVolumeFar.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtVolumeFar.HeightLightBolorColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.txtVolumeFar.Image = null;
            this.txtVolumeFar.ImageSize = new System.Drawing.Size(0, 0);
            this.txtVolumeFar.Location = new System.Drawing.Point(131, 179);
            this.txtVolumeFar.MaxValuelLength = 1;
            this.txtVolumeFar.Name = "txtVolumeFar";
            this.txtVolumeFar.PasswordChar = '\0';
            this.txtVolumeFar.PromptChar = ' ';
            this.txtVolumeFar.Required = false;
            this.txtVolumeFar.ShowMsg = false;
            this.txtVolumeFar.Size = new System.Drawing.Size(110, 25);
            this.txtVolumeFar.TabIndex = 264;
            this.txtVolumeFar.Tag = "总容积率,number";
            // 
            // txtGreenFar
            // 
            this.txtGreenFar.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtGreenFar.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtGreenFar.DecimalLength = 3;
            this.txtGreenFar.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtGreenFar.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtGreenFar.HeightLightBolorColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.txtGreenFar.Image = null;
            this.txtGreenFar.ImageSize = new System.Drawing.Size(0, 0);
            this.txtGreenFar.Location = new System.Drawing.Point(380, 211);
            this.txtGreenFar.MaxValuelLength = 1;
            this.txtGreenFar.Name = "txtGreenFar";
            this.txtGreenFar.PasswordChar = '\0';
            this.txtGreenFar.PromptChar = ' ';
            this.txtGreenFar.Required = false;
            this.txtGreenFar.ShowMsg = false;
            this.txtGreenFar.Size = new System.Drawing.Size(110, 25);
            this.txtGreenFar.TabIndex = 265;
            this.txtGreenFar.Tag = "绿化率,number";
            // 
            // txtBuildingDensity
            // 
            this.txtBuildingDensity.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtBuildingDensity.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBuildingDensity.DecimalLength = 3;
            this.txtBuildingDensity.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtBuildingDensity.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtBuildingDensity.HeightLightBolorColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.txtBuildingDensity.Image = null;
            this.txtBuildingDensity.ImageSize = new System.Drawing.Size(0, 0);
            this.txtBuildingDensity.Location = new System.Drawing.Point(624, 213);
            this.txtBuildingDensity.MaxValuelLength = 1;
            this.txtBuildingDensity.Name = "txtBuildingDensity";
            this.txtBuildingDensity.PasswordChar = '\0';
            this.txtBuildingDensity.PromptChar = ' ';
            this.txtBuildingDensity.Required = false;
            this.txtBuildingDensity.ShowMsg = false;
            this.txtBuildingDensity.Size = new System.Drawing.Size(110, 25);
            this.txtBuildingDensity.TabIndex = 266;
            this.txtBuildingDensity.Tag = "建筑密度,number";
            // 
            // lbl_wh2
            // 
            this.lbl_wh2.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.lbl_wh2.AutoSize = true;
            this.lbl_wh2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.lbl_wh2.BorderColor = System.Drawing.Color.White;
            this.lbl_wh2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_wh2.ForeColor = System.Drawing.Color.Black;
            this.lbl_wh2.Location = new System.Drawing.Point(418, 33);
            this.lbl_wh2.Name = "lbl_wh2";
            this.lbl_wh2.Size = new System.Drawing.Size(104, 17);
            this.lbl_wh2.TabIndex = 46;
            this.lbl_wh2.Text = "用地规划许可证号";
            this.lbl_wh2.Visible = false;
            // 
            // lbl_wh1
            // 
            this.lbl_wh1.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.lbl_wh1.AutoSize = true;
            this.lbl_wh1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.lbl_wh1.BorderColor = System.Drawing.Color.White;
            this.lbl_wh1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_wh1.ForeColor = System.Drawing.Color.Black;
            this.lbl_wh1.Location = new System.Drawing.Point(21, 33);
            this.lbl_wh1.Name = "lbl_wh1";
            this.lbl_wh1.Size = new System.Drawing.Size(104, 17);
            this.lbl_wh1.TabIndex = 45;
            this.lbl_wh1.Text = "工程用地批准书号";
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(247)))), ((int)(((byte)(252)))));
            this.tabPage3.Controls.Add(this.splitContainer1);
            this.tabPage3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabPage3.Location = new System.Drawing.Point(4, 29);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(771, 469);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.TabItemImage = null;
            this.tabPage3.Text = "相关单位信息";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Left;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.cPanel2);
            this.splitContainer1.Size = new System.Drawing.Size(778, 469);
            this.splitContainer1.SplitterDistance = 99;
            this.splitContainer1.TabIndex = 3;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.lblUnit1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblUnit2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblUnit3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblUnit4, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblUnit6, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.lblUnit15, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.lblUnitAll, 0, 6);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 8;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(106, 469);
            this.tableLayoutPanel1.TabIndex = 0;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // lblUnit1
            // 
            this.lblUnit1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblUnit1.Image = global::ERM.UI.Properties.Resources.arrow;
            this.lblUnit1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblUnit1.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lblUnit1.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(56)))), ((int)(((byte)(95)))));
            this.lblUnit1.Location = new System.Drawing.Point(3, 0);
            this.lblUnit1.Name = "lblUnit1";
            this.lblUnit1.Padding = new System.Windows.Forms.Padding(18, 4, 0, 4);
            this.lblUnit1.Size = new System.Drawing.Size(100, 24);
            this.lblUnit1.TabIndex = 5;
            this.lblUnit1.TabStop = true;
            this.lblUnit1.Text = "建设单位";
            this.lblUnit1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblUnit1.VisitedLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.lblUnit1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkClicked);
            // 
            // lblUnit2
            // 
            this.lblUnit2.AutoSize = true;
            this.lblUnit2.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblUnit2.Image = global::ERM.UI.Properties.Resources.arrow;
            this.lblUnit2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblUnit2.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lblUnit2.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(56)))), ((int)(((byte)(95)))));
            this.lblUnit2.Location = new System.Drawing.Point(3, 24);
            this.lblUnit2.Name = "lblUnit2";
            this.lblUnit2.Padding = new System.Windows.Forms.Padding(18, 0, 0, 0);
            this.lblUnit2.Size = new System.Drawing.Size(71, 29);
            this.lblUnit2.TabIndex = 6;
            this.lblUnit2.TabStop = true;
            this.lblUnit2.Text = "勘察单位";
            this.lblUnit2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblUnit2.VisitedLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.lblUnit2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkClicked);
            // 
            // lblUnit3
            // 
            this.lblUnit3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblUnit3.AutoSize = true;
            this.lblUnit3.Image = global::ERM.UI.Properties.Resources.arrow;
            this.lblUnit3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblUnit3.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lblUnit3.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(56)))), ((int)(((byte)(95)))));
            this.lblUnit3.Location = new System.Drawing.Point(3, 57);
            this.lblUnit3.Name = "lblUnit3";
            this.lblUnit3.Padding = new System.Windows.Forms.Padding(18, 4, 0, 4);
            this.lblUnit3.Size = new System.Drawing.Size(71, 20);
            this.lblUnit3.TabIndex = 7;
            this.lblUnit3.TabStop = true;
            this.lblUnit3.Text = "设计单位";
            this.lblUnit3.VisitedLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.lblUnit3.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkClicked);
            // 
            // lblUnit4
            // 
            this.lblUnit4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblUnit4.AutoSize = true;
            this.lblUnit4.Image = global::ERM.UI.Properties.Resources.arrow;
            this.lblUnit4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblUnit4.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lblUnit4.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(56)))), ((int)(((byte)(95)))));
            this.lblUnit4.Location = new System.Drawing.Point(3, 87);
            this.lblUnit4.Name = "lblUnit4";
            this.lblUnit4.Padding = new System.Windows.Forms.Padding(18, 4, 0, 4);
            this.lblUnit4.Size = new System.Drawing.Size(71, 20);
            this.lblUnit4.TabIndex = 8;
            this.lblUnit4.TabStop = true;
            this.lblUnit4.Text = "施工单位";
            this.lblUnit4.VisitedLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.lblUnit4.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkClicked);
            // 
            // lblUnit6
            // 
            this.lblUnit6.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblUnit6.AutoSize = true;
            this.lblUnit6.Image = global::ERM.UI.Properties.Resources.arrow;
            this.lblUnit6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblUnit6.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lblUnit6.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(56)))), ((int)(((byte)(95)))));
            this.lblUnit6.Location = new System.Drawing.Point(3, 115);
            this.lblUnit6.Name = "lblUnit6";
            this.lblUnit6.Padding = new System.Windows.Forms.Padding(18, 4, 0, 4);
            this.lblUnit6.Size = new System.Drawing.Size(71, 20);
            this.lblUnit6.TabIndex = 10;
            this.lblUnit6.TabStop = true;
            this.lblUnit6.Text = "监理单位";
            this.lblUnit6.VisitedLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.lblUnit6.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkClicked);
            // 
            // lblUnit15
            // 
            this.lblUnit15.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblUnit15.AutoSize = true;
            this.lblUnit15.Image = global::ERM.UI.Properties.Resources.arrow;
            this.lblUnit15.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblUnit15.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lblUnit15.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(56)))), ((int)(((byte)(95)))));
            this.lblUnit15.Location = new System.Drawing.Point(3, 144);
            this.lblUnit15.Name = "lblUnit15";
            this.lblUnit15.Padding = new System.Windows.Forms.Padding(18, 4, 0, 4);
            this.lblUnit15.Size = new System.Drawing.Size(71, 20);
            this.lblUnit15.TabIndex = 25;
            this.lblUnit15.TabStop = true;
            this.lblUnit15.Text = "批准单位";
            this.lblUnit15.VisitedLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.lblUnit15.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkClicked);
            // 
            // lblUnitAll
            // 
            this.lblUnitAll.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblUnitAll.AutoSize = true;
            this.lblUnitAll.Image = global::ERM.UI.Properties.Resources.arrow;
            this.lblUnitAll.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblUnitAll.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lblUnitAll.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(56)))), ((int)(((byte)(95)))));
            this.lblUnitAll.Location = new System.Drawing.Point(3, 177);
            this.lblUnitAll.Name = "lblUnitAll";
            this.lblUnitAll.Padding = new System.Windows.Forms.Padding(18, 4, 0, 4);
            this.lblUnitAll.Size = new System.Drawing.Size(95, 20);
            this.lblUnitAll.TabIndex = 26;
            this.lblUnitAll.TabStop = true;
            this.lblUnitAll.Text = "显示所有单位";
            this.lblUnitAll.VisitedLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.lblUnitAll.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkClicked);
            // 
            // cPanel2
            // 
            this.cPanel2.BackColor = System.Drawing.Color.Transparent;
            this.cPanel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cPanel2.Controls.Add(this.Dgv1);
            this.cPanel2.Controls.Add(this.btnEdit);
            this.cPanel2.Controls.Add(this.btnDel);
            this.cPanel2.Controls.Add(this.btnNew);
            this.cPanel2.Controls.Add(this.txtUnittype);
            this.cPanel2.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.cPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.cPanel2.DownBack = null;
            this.cPanel2.Font = new System.Drawing.Font("宋体", 9F);
            this.cPanel2.ForeColor = System.Drawing.Color.Transparent;
            this.cPanel2.Location = new System.Drawing.Point(0, 0);
            this.cPanel2.MouseBack = null;
            this.cPanel2.Name = "cPanel2";
            this.cPanel2.NormlBack = null;
            this.cPanel2.Radius = 4;
            this.cPanel2.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.cPanel2.Size = new System.Drawing.Size(675, 469);
            this.cPanel2.TabIndex = 2;
            // 
            // Dgv1
            // 
            this.Dgv1.AllowUserToAddRows = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            this.Dgv1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.Dgv1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Dgv1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.Dgv1.BackgroundColor = System.Drawing.Color.White;
            this.Dgv1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Dgv1.ColumnFont = null;
            this.Dgv1.ColumnForeColor = System.Drawing.Color.Black;
            this.Dgv1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(246)))), ((int)(((byte)(239)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(235)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Dgv1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.Dgv1.ColumnHeadersHeight = 26;
            this.Dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.Dgv1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dwmc1,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn9,
            this.dataGridViewTextBoxColumn10,
            this.dataGridViewTextBoxColumn11});
            this.Dgv1.ColumnSelectBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(215)))), ((int)(((byte)(244)))));
            this.Dgv1.ColumnSelectForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(188)))), ((int)(((byte)(240)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Dgv1.DefaultCellStyle = dataGridViewCellStyle7;
            this.Dgv1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.Dgv1.EnableHeadersVisualStyles = false;
            this.Dgv1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Dgv1.GridColor = System.Drawing.Color.Gainsboro;
            this.Dgv1.HeadFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Dgv1.HeadSelectBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(235)))), ((int)(((byte)(252)))));
            this.Dgv1.HeadSelectForeColor = System.Drawing.SystemColors.ControlText;
            this.Dgv1.LineNumberForeColor = System.Drawing.Color.Black;
            this.Dgv1.Location = new System.Drawing.Point(4, 0);
            this.Dgv1.MultiSelect = false;
            this.Dgv1.Name = "Dgv1";
            this.Dgv1.ReadOnly = true;
            this.Dgv1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.Dgv1.RowHeadersVisible = false;
            this.Dgv1.RowHeadersWidth = 22;
            this.Dgv1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(172)))), ((int)(((byte)(215)))), ((int)(((byte)(244)))));
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Black;
            this.Dgv1.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.Dgv1.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Dgv1.RowTemplate.Height = 25;
            this.Dgv1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Dgv1.Size = new System.Drawing.Size(671, 430);
            this.Dgv1.SkinGridColor = System.Drawing.Color.Gainsboro;
            this.Dgv1.TabIndex = 82;
            this.Dgv1.TitleBack = null;
            this.Dgv1.TitleBackColorBegin = System.Drawing.Color.White;
            this.Dgv1.TitleBackColorEnd = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(235)))), ((int)(((byte)(252)))));
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "unitid";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "unittype";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Visible = false;
            // 
            // dwmc1
            // 
            this.dwmc1.HeaderText = "单位名称";
            this.dwmc1.Name = "dwmc1";
            this.dwmc1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "负责人";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 60;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "负责人资格证号";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 120;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "项目经理";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 80;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "资质等级";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 80;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.HeaderText = "资质证号";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Width = 97;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.HeaderText = "地址";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.Width = 132;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.HeaderText = "联系电话";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            this.dataGridViewTextBoxColumn9.Width = 99;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.HeaderText = "传真";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.HeaderText = "备注";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.ReadOnly = true;
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEdit.BackColor = System.Drawing.Color.Transparent;
            this.btnEdit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnEdit.BackRectangle = new System.Drawing.Rectangle(59, 23, 59, 25);
            this.btnEdit.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(168)))), ((int)(((byte)(213)))));
            this.btnEdit.BorderColor = System.Drawing.Color.Transparent;
            this.btnEdit.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btnEdit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEdit.DownBack = null;
            this.btnEdit.FlatAppearance.BorderSize = 0;
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.btnEdit.ForeColor = System.Drawing.Color.Black;
            this.btnEdit.GlowColor = System.Drawing.Color.Transparent;
            this.btnEdit.InnerBorderColor = System.Drawing.Color.White;
            this.btnEdit.Location = new System.Drawing.Point(91, 437);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(0);
            this.btnEdit.MouseBack = null;
            this.btnEdit.MouseBaseColor = System.Drawing.Color.SkyBlue;
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.NormlBack = null;
            this.btnEdit.Palace = true;
            this.btnEdit.Radius = 10;
            this.btnEdit.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.btnEdit.Size = new System.Drawing.Size(65, 25);
            this.btnEdit.TabIndex = 80;
            this.btnEdit.TabStop = false;
            this.btnEdit.Text = "编辑";
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDel
            // 
            this.btnDel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDel.BackColor = System.Drawing.Color.Transparent;
            this.btnDel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnDel.BackRectangle = new System.Drawing.Rectangle(59, 23, 59, 25);
            this.btnDel.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(168)))), ((int)(((byte)(213)))));
            this.btnDel.BorderColor = System.Drawing.Color.SkyBlue;
            this.btnDel.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btnDel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDel.DownBack = null;
            this.btnDel.FlatAppearance.BorderSize = 0;
            this.btnDel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDel.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.btnDel.ForeColor = System.Drawing.Color.Black;
            this.btnDel.GlowColor = System.Drawing.Color.Transparent;
            this.btnDel.InnerBorderColor = System.Drawing.Color.White;
            this.btnDel.Location = new System.Drawing.Point(165, 437);
            this.btnDel.Margin = new System.Windows.Forms.Padding(0);
            this.btnDel.MouseBack = null;
            this.btnDel.MouseBaseColor = System.Drawing.Color.SkyBlue;
            this.btnDel.Name = "btnDel";
            this.btnDel.NormlBack = null;
            this.btnDel.Palace = true;
            this.btnDel.Radius = 10;
            this.btnDel.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.btnDel.Size = new System.Drawing.Size(65, 25);
            this.btnDel.TabIndex = 81;
            this.btnDel.TabStop = false;
            this.btnDel.Text = "删除";
            this.btnDel.UseVisualStyleBackColor = false;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnNew
            // 
            this.btnNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnNew.BackColor = System.Drawing.Color.Transparent;
            this.btnNew.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnNew.BackRectangle = new System.Drawing.Rectangle(59, 23, 59, 25);
            this.btnNew.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(168)))), ((int)(((byte)(213)))));
            this.btnNew.BorderColor = System.Drawing.Color.Transparent;
            this.btnNew.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btnNew.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNew.DownBack = null;
            this.btnNew.FlatAppearance.BorderSize = 0;
            this.btnNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNew.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.btnNew.ForeColor = System.Drawing.Color.Black;
            this.btnNew.GlowColor = System.Drawing.Color.Transparent;
            this.btnNew.InnerBorderColor = System.Drawing.Color.White;
            this.btnNew.Location = new System.Drawing.Point(17, 437);
            this.btnNew.Margin = new System.Windows.Forms.Padding(0);
            this.btnNew.MouseBack = null;
            this.btnNew.MouseBaseColor = System.Drawing.Color.SkyBlue;
            this.btnNew.Name = "btnNew";
            this.btnNew.NormlBack = null;
            this.btnNew.Palace = true;
            this.btnNew.Radius = 10;
            this.btnNew.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.btnNew.Size = new System.Drawing.Size(65, 25);
            this.btnNew.TabIndex = 79;
            this.btnNew.TabStop = false;
            this.btnNew.Text = "新增";
            this.btnNew.UseVisualStyleBackColor = false;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // txtUnittype
            // 
            this.txtUnittype.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtUnittype.BackColor = System.Drawing.Color.Transparent;
            this.txtUnittype.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtUnittype.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtUnittype.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtUnittype.HeightLightBolorColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.txtUnittype.Image = null;
            this.txtUnittype.ImageSize = new System.Drawing.Size(0, 0);
            this.txtUnittype.Location = new System.Drawing.Point(249, -3804);
            this.txtUnittype.Name = "txtUnittype";
            this.txtUnittype.Padding = new System.Windows.Forms.Padding(3);
            this.txtUnittype.PasswordChar = '\0';
            this.txtUnittype.Required = false;
            this.txtUnittype.Size = new System.Drawing.Size(161, 29);
            this.txtUnittype.TabIndex = 12;
            this.txtUnittype.Visible = false;
            // 
            // txtGhxkz
            // 
            this.txtGhxkz.BackColor = System.Drawing.Color.Transparent;
            this.txtGhxkz.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtGhxkz.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtGhxkz.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtGhxkz.HeightLightBolorColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(67)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.txtGhxkz.Image = null;
            this.txtGhxkz.ImageSize = new System.Drawing.Size(0, 0);
            this.txtGhxkz.Location = new System.Drawing.Point(123, 229);
            this.txtGhxkz.MaxLength = 50;
            this.txtGhxkz.Name = "txtGhxkz";
            this.txtGhxkz.Padding = new System.Windows.Forms.Padding(3);
            this.txtGhxkz.PasswordChar = '\0';
            this.txtGhxkz.Required = false;
            this.txtGhxkz.Size = new System.Drawing.Size(603, 25);
            this.txtGhxkz.TabIndex = 294;
            // 
            // frmProjectInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(225)))), ((int)(((byte)(247)))));
            this.BackgroundImage = global::ERM.UI.Properties.Resources.panel2_BackgroundImage;
            this.ClientSize = new System.Drawing.Size(790, 580);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmProjectInfo";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "工程信息管理";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmProject_Load);
            this.panel2.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.TXGroupEX1.ResumeLayout(false);
            this.TXGroupEX1.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.txGroupEX2.ResumeLayout(false);
            this.txGroupEX2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage5.ResumeLayout(false);
            this.txGroupEX3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPoint)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.cPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Dgv1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridViewTextBoxColumn dwmc;
        private SkinToolTip toolTip1;
        private DataGridViewTextBoxColumn addr;
        private DataGridViewTextBoxColumn zzzh;
        private DataGridViewTextBoxColumn zzdj;
        private DataGridViewTextBoxColumn xmjl;
        private DataGridViewTextBoxColumn fzrzs;
        private DataGridViewTextBoxColumn fzr;
        private DataGridViewTextBoxColumn unittype;
        private DataGridViewTextBoxColumn unitid;
        private DataGridViewTextBoxColumn tel;
        private DataGridViewTextBoxColumn fax;
        private DataGridViewTextBoxColumn remark;
        private TXTabControlEX tabControl1;
        private SkinTabPage tabPage1;
        private TXTextBoxEX txtPasswd;
        private SkinTabPage tabPage2;
        private TXGroupEX gbjz;
        private SkinTabPage tabPage3;
        private SplitContainer splitContainer1;
        private SkinPanelEX cPanel2;
        private TXTextBoxEX txtUnittype;
        private SkinTabPage tabPage4;
        private SkinLabelEX label6;
        private SkinLabelEX label15;
        private SkinLabelEX label66;
        private SkinLabelEX label67;
        private SkinLabelEX label70;
        private SkinLabelEX label72;
        private TXTextBoxEX txtItemFzr;
        private TXTextBoxEX txtRespective;
        private TXTextBoxEX txtProjectType;
        private SkinLabelEX label73;
        private SkinLabelEX label74;
        private SkinLabelEX label75;
        private SkinLabelEX label76;
        private SkinLabelEX label77;
        private SkinLabelEX label22;
        private SkinLabelEX label57;
        private NumberTextBoxEX txtzcd;
        private NumberTextBoxEX txtds;
        private NumberTextBoxEX txtConstructionAreaSum;
        private NumberTextBoxEX txtUseSoiAreaSum;
        private NumberTextBoxEX txtAllCost;
        private NumberTextBoxEX txtProjectSettlement;
        private NumberTextBoxEX txtProjectCost;
        private NumberTextBoxEX txtVolumeFar;
        private NumberTextBoxEX txtGreenFar;
        private NumberTextBoxEX txtBuildingDensity;
        private SkinPanelEX panel2;
        private TXGroupEX groupBox1;
        private SkinLabelEX label25;
        private SkinLabelEX label26;
        private SkinLabelEX lbl_ProjectNO;
        private TXTextBoxEX txtProjectNo;
        private SkinLabelEX label13;
        private SkinLabelEX label11;
        private TXTextBoxEX txtAddress;
        private DateTimeEx dtpBeginDate;
        private DateTimeEx dtpEndDate;
        private SkinLabelEX label3;
        private TXTextBoxEX txtProjectName;
        private SkinLabelEX label4;
        private TXComboxEX cboDistrict;
        private SkinLabelEX lbl_wh2;
        private TXTextBoxEX txtYdghxkCode;
        private SkinLabelEX lbl_wh1;
        private TXTextBoxEX txtYdpzcode;
        private SkinButtonEX btnSave;
        private SkinButtonEX btnEdit;
        private SkinButtonEX btnDel;
        private SkinButtonEX btnNew;
        private TableLayoutPanel tableLayoutPanel1;
        private LinkLabel lblUnit1;
        private LinkLabel lblUnit2;
        private LinkLabel lblUnit3;
        private LinkLabel lblUnit4;
        private LinkLabel lblUnit6;
        private LinkLabel lblUnit15;
        private Skin_DataGridEX Dgv1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dwmc1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private LinkLabel lblUnitAll;
        private TXGroupEX txGroupEX2;
        private TXTextBoxEX txtJldw;
        private TXTextBoxEX txtSgdw;
        private SkinLabelEX skinLabelEX6;
        private TXTextBoxEX txtSjdw;
        private SkinLabelEX skinLabelEX3;
        private TXTextBoxEX txtKcdw;
        private SkinLabelEX skinLabelEX2;
        private TXTextBoxEX txtLxpzdw;
        private SkinLabelEX skinLabelEX1;
        private TXTextBoxEX txtJsdw;
        private SkinLabelEX skinLabelEX10;
        private SkinLabelEX skinLabelEX9;
        private SkinLabelEX skinLabelEX8;
        private SkinLabelEX skinLabelEX7;
        private SkinLabelEX skinLabelEX5;
        private SkinLabelEX skinLabelEX4;
        private SkinLabelEX skinLabelEX12;
        private SkinLabelEX skinLabelEX11;
        private TabPage tabPage5;
        private TXGroupEX TXGroupEX1;
        private TXTextBoxEX txtpzh;
        private SkinLabelEX label5;
        private TXTextBoxEX txtPZDW;
        private SkinLabelEX label1;
        private TXTextBoxEX txtCreateUnit;
        private TXTextBoxEX txtConStructionProjectName;
        private TXTextBoxEX txtConstructionProjectAdd;
        private SkinLabelEX label78;
        private SkinLabelEX label23;
        private SkinLabelEX label59;
        private TXGroupEX txGroupEX3;
        private Skin_DataGridEX dgvPoint;
        private DataGridViewTextBoxColumn ID;
        private DataGridViewTextBoxColumn OrderIndex;
        private DataGridViewTextBoxColumn X;
        private DataGridViewTextBoxColumn Y;
        private SkinLabelEX skinLabelEX16;
        private SkinLabelEX skinLabelEX15;
        private Label label2;
        private TXTextBoxEX txtTlsyCode;
        private SkinLabelEX skinLabelEX17;
        private TXTextBoxEX txtXmCode;
        private SkinLabelEX lblxmh;
        private TXTextBoxEX txtGhxkz;
        private SkinLabelEX skinLabelEX18;
        private NumberTextBoxEX txtTlcrnx;
        private SkinLabelEX lblssss;
        private SkinLabelEX skinLabelEX20;
        private SkinLabelEX skinLabelEX22;
        private SkinLabelEX skinLabelEX21;
        private TXGroupEX groupBox2;
        private SkinLabelEX skinLabelEX14;
        private TXTextBoxEX txtysbah;
        private SkinLabelEX skinLabelEX13;
        private SkinLabelEX lbl_wh3;
        private TXTextBoxEX txtGhcode;
        private SkinLabelEX lbl_wh4;
        private TXTextBoxEX txtSgcode;
        private SkinLabelEX skinLabelEX19;
        private TXComboxEX cboProjectType;
        private SkinLabelEX label27;
        private SkinLabelEX skinLabelEX23;
        private SkinLabelEX skinLabelEX24;
    }
}