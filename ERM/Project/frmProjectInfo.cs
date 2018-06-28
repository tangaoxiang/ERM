using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ERM.Common;
using ERM.BLL;
using ERM.UI.Controls;
using ERM.MDL;
using TX.Framework.WindowUI.Forms;
using CCWin.SkinControl;
using TX.Framework.WindowUI;

namespace ERM.UI
{
    /// <summary>
    /// 工程详细信息
    /// </summary>
    public partial class frmProjectInfo : Skin_DevEX
    {
        #region 参数初始化
        private bool Welcome;
    
        /// <summary>
        /// 工程编号主键
        /// </summary>
        private string ProjectNO;
        public string ProjectNo
        {
            set { this.ProjectNO = value; }
            get { return this.ProjectNO; }
        }

        MDL.T_Projects projectMDL;
        ERM.MDL.T_Item itemMDL;
        //用户控件接口，用于接收不同实例化控件对象
        IProject obj = null;
        //工程类别字典
        IList<MDL.T_Dict> ds3 = null;
        T_Point_BLL point_bll = new T_Point_BLL();
        T_Point point = new T_Point();
        #endregion

        #region 窗体函数
        public frmProjectInfo(string _projectNo, bool _welcome)
        {
            InitializeComponent();
            this.ProjectNo = _projectNo;
            cPanel2.Dock = DockStyle.Fill;
            Welcome = _welcome;
            this.toolTip1.SetToolTip(this.txtProjectNo._TextBox, "工程报建时，城建档案馆批准给与的编号");
            this.toolTip1.SetToolTip(this.txtProjectName._TextBox, "请输入工程名称");
            this.toolTip1.SetToolTip(this.dtpEndDate._TextBox, "竣工验收备案日期\r\n(格式：1900.01.01)");
            this.toolTip1.SetToolTip(this.dtpBeginDate._TextBox, "施工许可证日期\r\n(格式：1900.01.01)");
            this.toolTip1.SetToolTip(this.txtAddress._TextBox, "请输入工程地址");
            this.toolTip1.SetToolTip(this.txtGhcode._TextBox, "工程规划许可证");
            this.toolTip1.SetToolTip(this.txtSgcode._TextBox, "工程施工许可证号");
            PointDataBind();
        }
        private void frmProject_Load(object sender, EventArgs e)
        {
            Init();
        }
        /// <summary>
        /// 单位链接
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LinkLabel link = (LinkLabel)sender;
            ClearLinkBackColor();  //清楚背景色
            link.BackColor = Color.FromArgb(197,225,247);  //设置背景颜色
            link.LinkColor = Color.Black;
            if (link.Name == "lblProjectInfo")
            {
                cPanel2.Visible = false;
            }
            else
            {
                cPanel2.Visible = true;
                if (link.Name == "lblUnitAll")
                {
                    txtUnittype.Text = "";
                    LoadDataFromView(string.Empty);
                }
                else
                {
                    txtUnittype.Text = link.Name.Replace("lbl", "").ToLower();  //当前的单位类别
                    LoadDataFromView(link.Name.Replace("lbl", "").ToLower());
                }
            }
        }
        /// <summary>
        /// 链接颜色
        /// </summary>
        private void ClearLinkBackColor()
        {
            lblUnit1.BackColor = tableLayoutPanel1.BackColor;
            lblUnit2.BackColor = tableLayoutPanel1.BackColor;
            lblUnit3.BackColor = tableLayoutPanel1.BackColor;
            lblUnit4.BackColor = tableLayoutPanel1.BackColor;
            lblUnit6.BackColor = tableLayoutPanel1.BackColor;
            lblUnit15.BackColor = tableLayoutPanel1.BackColor;
            lblUnitAll.BackColor = tableLayoutPanel1.BackColor;
            for (int i=0;i<tableLayoutPanel1.Controls.Count;i++)
            {
                if (tableLayoutPanel1.Controls[i] is LinkLabel)
                {
                    (tableLayoutPanel1.Controls[i] as LinkLabel).LinkColor = Color.FromArgb(0, 56, 95);
                }
            }
        }
        private void btnDel_Click(object sender, EventArgs e)
        {
            if (Dgv1.Rows.Count == 0) {
                TXMessageBoxExtensions.Info("没有可删除的数据！");
                return;
            }
            if (Dgv1.CurrentRow.Index < 0) {
                TXMessageBoxExtensions.Info("请选择一行数据进行删除！");
                return;
            }
            if (TXMessageBoxExtensions.Question("提示：确定删除吗？") != DialogResult.OK)
                return;
            string unitid = Dgv1.Rows[Dgv1.CurrentRow.Index].Cells[0].Value.ToString(); //当前unitid
            (new BLL.T_Units_BLL()).Delete(unitid);
            this.LoadDataFromView(txtUnittype.Text);
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtProjectNo.Text.Trim()))
            {
                TXMessageBoxExtensions.Info("请先填写工程编号！");
                this.tabControl1.SelectedTab = tabPage1;
                this.txtProjectNo.Focus();
                return;
            }
            frmUnit frm = new frmUnit(txtUnittype.Text, txtProjectNo.Text, "");

            DialogResult ret = frm.ShowDialog();
            if (ret == DialogResult.OK)
            {
                string unittype = frm.cboUnittype.SelectedValue.ToString();
                MDL.T_Units unitMDL = new ERM.MDL.T_Units();
                unitMDL.UnitID = Guid.NewGuid().ToString();
                unitMDL.unittype = unittype;
                unitMDL.ProjectNO = txtProjectNo.Text;
                if (string.Compare(unittype, "unit12", true) == 0 || string.Compare(unittype, "unit13", true) == 0)
                {
                    unitMDL.dwmc = frm.label5.Text;
                    unitMDL.fzr = MyCommon.ToSqlString(frm.txtOther.Text.Trim());
                    unitMDL.fzrzs = string.Empty;
                    unitMDL.xmjl = string.Empty;
                    unitMDL.zzdj = string.Empty;
                    unitMDL.zzzh = string.Empty;
                    unitMDL.addr = string.Empty;
                    unitMDL.tel = string.Empty;
                    unitMDL.fax = string.Empty;
                    unitMDL.remark = string.Empty;
                }
                else
                {
                    unitMDL.dwmc = MyCommon.ToSqlString(frm.txtDwmc.Text.Trim());
                    unitMDL.fzr = MyCommon.ToSqlString(frm.txtFzr.Text.Trim());
                    unitMDL.fzrzs = MyCommon.ToSqlString(frm.txtFzrzs.Text.Trim());
                    unitMDL.xmjl = MyCommon.ToSqlString(frm.txtXmjl.Text.Trim());
                    unitMDL.zzdj = MyCommon.ToSqlString(frm.txtZzdj.Text.Trim());
                    unitMDL.zzzh = MyCommon.ToSqlString(frm.txtZzzh.Text.Trim());
                    unitMDL.addr = MyCommon.ToSqlString(frm.txtAddr.Text.Trim());
                    unitMDL.tel = MyCommon.ToSqlString(frm.txtTel.Text.Trim());
                    unitMDL.fax = MyCommon.ToSqlString(frm.txtFax.Text.Trim());
                    unitMDL.remark = MyCommon.ToSqlString(frm.txtRemark.Text.Trim());
                }
                (new BLL.T_Units_BLL()).Add(unitMDL);
                this.LoadDataFromView(txtUnittype.Text);
            }
        }

        /// <summary>
        /// 绑定单位信息
        /// TYX 20170824
        /// </summary>
        private void BindUnit()
        {
            if (!string.IsNullOrEmpty(txtProjectNo.Text))
            {
                IList<MDL.T_Units> unitList = (new BLL.T_Units_BLL()).FindByProjectNO(txtProjectNo.Text);
                foreach (var item in unitList)
                {
                    switch (item.unittype)
                    {
                        case "unit1":
                            this.txtJsdw.Text = item.dwmc;
                            break;
                        case "unit15":
                            this.txtLxpzdw.Text = item.dwmc;
                            break;
                        case "unit3":
                            this.txtSjdw.Text = item.dwmc;
                            break;
                        case "unit2":
                            this.txtKcdw.Text = item.dwmc;
                            break;
                        case "unit4":
                            this.txtSgdw.Text = item.dwmc;
                            break;
                        case "unit6":
                            this.txtJldw.Text = item.dwmc;
                            break;
                    }
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (Dgv1.Rows.Count == 0)
            {
                TXMessageBoxExtensions.Info("没有可编辑的数据！");
                return;
            }
            if (Dgv1.CurrentRow.Index < 0)
            {
                TXMessageBoxExtensions.Info("请选择一行数据进行编辑！");
                return;
            }
            string unitid = Dgv1.Rows[Dgv1.CurrentRow.Index].Cells[0].Value.ToString(); //当前unitid
            string unitType = Dgv1.Rows[Dgv1.CurrentRow.Index].Cells[1].Value.ToString();//当前单位类型
            //BUG修复20170420，如果不选择左侧的单位类型会导致编辑传过去的单位类型为空，改为如果为空则传当前选中行的单位类型
            frmUnit frm = new frmUnit(txtUnittype.Text == "" ? unitType : txtUnittype.Text, txtProjectNo.Text, unitid);
            DialogResult ret = frm.ShowDialog();  //open
            if (ret == DialogResult.OK)
            {
                MDL.T_Units unitMDL = (new ERM.BLL.T_Units_BLL()).Find(unitid);
                string unittype = frm.cboUnittype.SelectedValue.ToString();
                unitMDL.unittype = unittype;
                if (string.Compare(unittype, "unit12", true) == 0 || string.Compare(unittype, "unit13", true) == 0)
                {
                    unitMDL.dwmc = frm.label5.Text;
                    unitMDL.fzr = MyCommon.ToSqlString(frm.txtOther.Text.Trim());
                    unitMDL.fzrzs = string.Empty;
                    unitMDL.xmjl = string.Empty;
                    unitMDL.zzdj = string.Empty;
                    unitMDL.zzzh = string.Empty;
                    unitMDL.addr = string.Empty;
                    unitMDL.tel = string.Empty;
                    unitMDL.fax = string.Empty;
                    unitMDL.remark = string.Empty;
                }
                else
                {
                    unitMDL.dwmc = MyCommon.ToSqlString(frm.txtDwmc.Text.Trim());
                    unitMDL.fzr = MyCommon.ToSqlString(frm.txtFzr.Text.Trim());
                    unitMDL.fzrzs = MyCommon.ToSqlString(frm.txtFzrzs.Text.Trim());
                    unitMDL.xmjl = MyCommon.ToSqlString(frm.txtXmjl.Text.Trim());
                    unitMDL.zzdj = MyCommon.ToSqlString(frm.txtZzdj.Text.Trim());
                    unitMDL.zzzh = MyCommon.ToSqlString(frm.txtZzzh.Text.Trim());
                    unitMDL.addr = MyCommon.ToSqlString(frm.txtAddr.Text.Trim());
                    unitMDL.tel = MyCommon.ToSqlString(frm.txtTel.Text.Trim());
                    unitMDL.fax = MyCommon.ToSqlString(frm.txtFax.Text.Trim());
                    unitMDL.remark = MyCommon.ToSqlString(frm.txtRemark.Text.Trim());
                }
                (new ERM.BLL.T_Units_BLL()).Update(unitMDL);
                this.LoadDataFromView(txtUnittype.Text);
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            btnSave.Enabled = false;
            if (SaveData())
            {
                if (Welcome)//新增
                {
                    BLL.BLLMore bllMore = new ERM.BLL.BLLMore();
                    bllMore.CopyFileList(txtProjectNo.Text,projectMDL.ProjectCategory);

                    Globals.Projectname = txtProjectName.Text.Trim();
                    Globals.ProjectNO = txtProjectNo.Text.Trim();
                }
                TXMessageBoxExtensions.Info("保存成功！");
                this.Close();
            }
            btnSave.Enabled = true;
        }
        /// <summary>
        /// 将DataView的单位信息数据加载到Grid中
        /// </summary>
        /// <param name="unittype">单位类别，为空表示全部</param>
        private void LoadDataFromView(string unittype)
        {
            IList<MDL.T_Units> unitList = (new BLL.T_Units_BLL()).FindByProjectNO(txtProjectNo.Text);
            Dgv1.Rows.Clear();
            foreach (MDL.T_Units obj in unitList)
            {
                if (unittype != "")
                {
                    if (obj.unittype != unittype)
                    {
                        continue;
                    }
                }

                if (obj.ProjectNO=="")
                {
                    (new BLL.T_Units_BLL()).Delete(obj.UnitID);
                    continue;
                }

                Dgv1.Rows.Add();
                Dgv1.Rows[Dgv1.Rows.Count - 1].Cells[0].Value = obj.UnitID;
                Dgv1.Rows[Dgv1.Rows.Count - 1].Cells[1].Value = obj.unittype;
                Dgv1.Rows[Dgv1.Rows.Count - 1].Cells[2].Value = obj.dwmc;
                Dgv1.Rows[Dgv1.Rows.Count - 1].Cells[3].Value = obj.fzr;
                Dgv1.Rows[Dgv1.Rows.Count - 1].Cells[4].Value = obj.fzrzs;
                Dgv1.Rows[Dgv1.Rows.Count - 1].Cells[5].Value = obj.xmjl;
                Dgv1.Rows[Dgv1.Rows.Count - 1].Cells[6].Value = obj.zzdj;
                Dgv1.Rows[Dgv1.Rows.Count - 1].Cells[7].Value = obj.zzzh;
                Dgv1.Rows[Dgv1.Rows.Count - 1].Cells[8].Value = obj.addr;
                Dgv1.Rows[Dgv1.Rows.Count - 1].Cells[9].Value = obj.tel;
                Dgv1.Rows[Dgv1.Rows.Count - 1].Cells[10].Value = obj.fax;
                Dgv1.Rows[Dgv1.Rows.Count - 1].Cells[11].Value = obj.remark;
            }
        }
        private void cboDistrict_TextChanged(object sender, EventArgs e)
        {
            ComboBox cbo = (ComboBox)sender;
            if (cbo.Text.Length > 20)
            {
                cbo.Text = cbo.Text.Substring(0, 20);
                cbo.SelectionStart = cbo.Text.Length;
            }
        }
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 3)
            {
                if (itemMDL == null)
                    itemMDL = new ERM.BLL.T_Item_BLL().Find(projectMDL.ItemID);
                if (itemMDL == null)
                {
                    txtConStructionProjectName.Text = itemMDL.ConStructionProjectName;
                    txtRespective.Text = cboDistrict.Text;
                    return;
                }
                loadItemInfo();
            }
        }

        private void loadItemInfo()
        {
            if (string.IsNullOrEmpty(itemMDL.ConStructionProjectName))
            {
                itemMDL.ConStructionProjectName = txtProjectName.Text;
            }
            if (string.IsNullOrEmpty(itemMDL.ConstructionProjectAdd))
            {
                itemMDL.ConstructionProjectAdd = txtAddress.Text;
            }
            if (string.IsNullOrEmpty(itemMDL.Respective))
            {
                itemMDL.Respective = cboDistrict.Text;
            }

            if (txtConStructionProjectName.Text.Trim() == "")
                txtConStructionProjectName.Text = itemMDL.ConStructionProjectName;
            if (txtRespective.Text.Trim() == "")
                txtRespective.Text = itemMDL.Respective;
            if (txtConstructionProjectAdd.Text.Trim() == "")
                txtConstructionProjectAdd.Text = itemMDL.ConstructionProjectAdd;
            if (txtProjectType.Text.Trim() == "")
                txtProjectType.Text = itemMDL.ProjectType;
            if (txtUseSoiAreaSum.Text.Trim() == "")
                txtUseSoiAreaSum.Text = itemMDL.UseSoiAreaSum;
            if (txtConstructionAreaSum.Text.Trim() == "")
                txtConstructionAreaSum.Text = itemMDL.ConstructionAreaSum;
            if (txtProjectCost.Text.Trim() == "")
                txtProjectCost.Text = itemMDL.ProjectCost;
            if (txtProjectSettlement.Text.Trim() == "")
                txtProjectSettlement.Text = itemMDL.ProjectSettlement;

            if (txtCreateUnit.Text.Trim() == "")
            {
                if (string.IsNullOrWhiteSpace(itemMDL.CreateUnit))
                {
                    MDL.T_Units units_mdl = GetJSDW();
                    if (!string.IsNullOrWhiteSpace(units_mdl.dwmc))
                    {
                        txtCreateUnit.Text = units_mdl.dwmc;
                    }
                }
                else
                {
                    txtCreateUnit.Text = itemMDL.CreateUnit;
                }
            }
            if (txtItemFzr.Text.Trim() == "")
            {
                if (string.IsNullOrWhiteSpace(itemMDL.ItemFzr))
                {
                    MDL.T_Units units_mdl = GetJSDW();
                    if (!string.IsNullOrWhiteSpace(units_mdl.fzr))
                    {
                        txtItemFzr.Text = units_mdl.fzr;
                    }
                }
                else
                {
                    txtItemFzr.Text = itemMDL.ItemFzr;
                }
            }
            if (txtAllCost.Text.Trim() == "")
                txtAllCost.Text = itemMDL.AllCost;
            if (txtVolumeFar.Text.Trim() == "")
                txtVolumeFar.Text = itemMDL.VolumeFar;
            if (txtVolumeFar.Text == "0")
                txtVolumeFar.Text = "";
            if (txtGreenFar.Text.Trim() == "")
                txtGreenFar.Text = itemMDL.GreenFar;
            if (txtGreenFar.Text == "0")
                txtGreenFar.Text = "";
            if (txtBuildingDensity.Text.Trim() == "")
                txtBuildingDensity.Text = itemMDL.BuildingDensity;
            if (txtBuildingDensity.Text == "0")
                txtBuildingDensity.Text = "";
            if (txtds.Text == "")
                txtds.Text = itemMDL.ds;
            if (this.txtzcd.Text == "")
                txtzcd.Text = itemMDL.zcd;

            if (this.txtTlsyCode.Text == "")
            txtTlsyCode.Text = itemMDL.TlsyCode;
            if (this.txtXmCode.Text == "")
            txtXmCode.Text = itemMDL.XmCode;
            if (this.txtYdghxkCode.Text == "")
            txtYdghxkCode.Text = itemMDL.YdghxkCode;
            if (this.txtTlcrnx.Text == "")
            txtTlcrnx.Text = itemMDL.Tlcrnx;

            if (this.txtPZDW.Text.Trim() == "")
            {
                if (string.IsNullOrWhiteSpace(itemMDL.pzdw))
                {
                    MDL.T_Units units_mdl = GetJSDW();
                    if (!string.IsNullOrWhiteSpace(units_mdl.dwmc))
                    {
                        txtPZDW.Text = units_mdl.dwmc;
                    }
                }
                else
                {
                    txtPZDW.Text = itemMDL.pzdw;
                }
            }
            if (this.txtpzh.Text == "")
                txtpzh.Text = itemMDL.pzh;
        }
        #endregion

        #region 自定义函数
        /// <summary>
        /// 工程页面绑定
        /// </summary>
        private void ProjectBind()
        {
            //工程编号
            MyCommon.ShowTextBind(lbl_ProjectNO, "0");
            MyCommon.ShowTextBind(lbl_wh1, "1");
            MyCommon.ShowTextBind(lbl_wh2, "2");
            MyCommon.ShowTextBind(lbl_wh3, "3");
            MyCommon.ShowTextBind(lbl_wh4, "4");
        }
        private void Init()
        {
            ProjectBind();//页面绑定方法
            ERM.BLL.T_Dict_BLL dicData = new ERM.BLL.T_Dict_BLL();
            BLL.District bll1 = new ERM.BLL.District();
            DataSet ds = bll1.GetAllList();
            cboDistrict.DisplayMember = "DistrictName";
            cboDistrict.ValueMember = "DistrictName";
            cboDistrict.DataSource = ds.Tables[0];
            if (cboDistrict.Items.Count > 0)
            {
                cboDistrict.SelectedIndex = 0;
            }

            ds3 = dicData.FindByKeyWord("ProjectCategory");
            cboProjectType.DisplayMember = "displayname";
            cboProjectType.ValueMember = "valuename";
            cboProjectType.DataSource = ds3;

            if (ProjectNo != "")  //编辑模式
            {
                txtProjectNo.Enabled = false;//修改时，不允许修改项目编号，保证唯一性
                this.cboProjectType.Enabled = false;

                //修改 判断是否有权限修改工程编号与名称
                if (!MyCommon.CheckProjectBind())
                {
                    txtProjectNo.Enabled = false;
                    txtProjectName.Enabled = false;
                }

                projectMDL = (new BLL.T_Projects_BLL()).Find(ProjectNo);
                if (projectMDL != null)
                {
                    itemMDL = (new ERM.BLL.T_Item_BLL()).Find(projectMDL.ItemID);
                    loadItemInfo();
                    txtProjectNo.Text = projectMDL.ProjectNO; //工程代码
                    cboDistrict.Text = projectMDL.district == null ? "" : projectMDL.district; //区域
                    txtProjectName.Text = projectMDL.projectname;  //工程名称
                    txtAddress.Text = projectMDL.address == null ? "" : projectMDL.address;  //工程地址                    
                    cboProjectType.SelectedValue = projectMDL.ProjectCategory;
                    //txtYdpzcode.Text = projectMDL.ydpzcode == null ? "" : projectMDL.ydpzcode; //工程用地批准书号
                    txtYdghxkCode.Text = projectMDL.ydxkcode == null ? "" : projectMDL.ydxkcode; //用地规划许可证号
                    txtGhcode.Text = projectMDL.ghcode == null ? "" : projectMDL.ghcode;  //规划许可证号
                    txtSgcode.Text = projectMDL.sgcode == null ? "" : projectMDL.sgcode; //工程施工许可证号
                    txtysbah.Text = projectMDL.ajdh==null?"":projectMDL.ajdh;//验收备案号
                    dtpBeginDate.TextEx = projectMDL.begindate == null ? "" : (projectMDL.begindate); //开工日期
                    dtpEndDate.TextEx = projectMDL.enddate == null ? "" : projectMDL.enddate;

                    //this.txtajdh.Text = projectMDL.ajdh.ToString();
                    this.cboProjectType.SelectedValue = projectMDL.ProjectCategory;//根据工程类型显示扩展信息
                }
            }
            else
            {
                this.cboProjectType.SelectedIndex = 0;
                projectMDL = new ERM.MDL.T_Projects();
                itemMDL = new ERM.MDL.T_Item();
            }
            LoadDataFromView("");
            BindUnit();
        }

        /// <summary>
        /// 坐标数据绑定
        /// </summary>
        private void PointDataBind()
        {
            dgvPoint.Rows.Clear();
            IList<T_Point> list = new T_Point_BLL().GetList(this.ProjectNO);
            foreach (var item in list)
            {
                dgvPoint.Rows.Add();

                DataGridViewRow dgv = dgvPoint.Rows[dgvPoint.Rows.Count - 1];
                dgv.Cells[0].Value = item.ID;
                dgv.Cells[1].Value = item.OrderIndex;
                dgv.Cells[2].Value = item.X;
                dgv.Cells[3].Value = item.Y;
            }
        }

        /// <summary>
        /// 项目信息
        /// </summary>
        /// <param name="ItemID"></param>
        private void SetItemInfo(string itemID,int type=0)
        {
            itemMDL.ConStructionProjectName = MyCommon.ToSqlString2(txtConStructionProjectName.Text == "" ? txtProjectNo.Text : txtConStructionProjectName.Text);//项目名称
            itemMDL.Respective = MyCommon.ToSqlString2(txtRespective.Text);//所属区域
            if (itemMDL.Respective == "" && cboDistrict.Text != "")
            {
                itemMDL.Respective = cboDistrict.Text;
            }

            itemMDL.ConstructionProjectAdd = MyCommon.ToSqlString2(txtConstructionProjectAdd.Text == "" ? txtAddress.Text : txtConstructionProjectAdd.Text);//项目地址
            itemMDL.TlsyCode = txtTlsyCode.Text;
            itemMDL.XmCode = txtXmCode.Text;
            itemMDL.YdghxkCode = txtYdghxkCode.Text;
            itemMDL.Tlcrnx = txtTlcrnx.Text;
            itemMDL.ProjectType = MyCommon.ToSqlString2(txtProjectType.Text);//建筑性质           
            itemMDL.UseSoiAreaSum = txtUseSoiAreaSum.GetText;//总用地面积
            itemMDL.ConstructionAreaSum = txtConstructionAreaSum.GetText;//总建筑面积            
            itemMDL.ProjectCost = txtProjectCost.GetText;//总结算
            itemMDL.ProjectSettlement = txtProjectSettlement.GetText;//总预算
          
            itemMDL.CreateUnit = MyCommon.ToSqlString2(txtCreateUnit.Text);//建设单位
            itemMDL.ItemFzr = MyCommon.ToSqlString2(txtItemFzr.Text);//项目负责人
            itemMDL.AllCost = txtAllCost.GetText;//总地价
            itemMDL.GreenFar = txtGreenFar.Text;//绿化率
            itemMDL.VolumeFar = txtVolumeFar.Text;//容积率
            itemMDL.BuildingDensity = txtBuildingDensity.Text;//建筑密度
            itemMDL.ds = txtds.GetText;
            if (type==0)
            {
                itemMDL.ItemID = itemID;
            }
            
            //市政工程新增项目信息
            itemMDL.pzh = txtpzh.Text;//批准号
            itemMDL.zcd = txtzcd.Text;//总长度
            itemMDL.pzdw = txtPZDW.Text;//批准单位
           
           
            if (string.IsNullOrEmpty(txtConstructionProjectAdd.Text))
            {
                txtConstructionProjectAdd.Text = txtAddress.Text;
            }
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <returns></returns>
        private bool SaveData()
        {

            if (string.IsNullOrEmpty(this.txtConStructionProjectName.Text))
            {
                TXMessageBoxExtensions.Info("提示：项目名称不能为空！");
                this.tabControl1.SelectedTab = tabPage4;
                txtConStructionProjectName.Focus();
                return false;
            }


            if (string.IsNullOrEmpty(this.txtConstructionProjectAdd.Text))
            {
                TXMessageBoxExtensions.Info("提示：项目地址不能为空！");
                this.tabControl1.SelectedTab = tabPage4;
                txtConstructionProjectAdd.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(this.txtCreateUnit.Text))
            {
                TXMessageBoxExtensions.Info("提示：项目建设单位不能为空！");
                this.tabControl1.SelectedTab = tabPage4;
                txtCreateUnit.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(this.txtPZDW.Text))
            {
                TXMessageBoxExtensions.Info("提示：立项批准单位不能为空！");
                this.tabControl1.SelectedTab = tabPage4;
                txtPZDW.Focus();
                return false;
            }

            if (this.cboProjectType.SelectedIndex == -1)
            {
                TXMessageBoxExtensions.Info("提示：工程类型必须选择！");
                this.tabControl1.SelectedTab = tabPage4;
                return false;
            }
            if (txtProjectNo.Text.Trim() == "")
            {
                TXMessageBoxExtensions.Info("提示：工程编号必须填写！");
                this.tabControl1.SelectedTab = tabPage1;
                this.txtProjectNo.Focus();
                return false;
            }
            if (!MyCommon.isYesProjectNo(txtProjectNo.Text.Trim()))
            {
                TXMessageBoxExtensions.Info("提示：工程编号格式错误！\n【温馨提示：工程编号只允许输入数字，字母，下划线，横线】");
                this.tabControl1.SelectedTab = tabPage1;
                txtProjectNo.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtProjectName.Text))
            {
                TXMessageBoxExtensions.Info("提示：工程名称不能为空！");
                this.tabControl1.SelectedTab = tabPage1;
                txtProjectName.Focus();
                return false;
            }

            if (cboDistrict.SelectedValue.ToString()==""||string.IsNullOrEmpty(this.txtAddress.Text))
            { 
                TXMessageBoxExtensions.Info("提示：工程地址不能为空！");
                this.tabControl1.SelectedTab = tabPage1;
                txtAddress.Focus();
                return false;
            }

            if (dtpBeginDate.TextEx=="")
            {
                TXMessageBoxExtensions.Info("提示：开工日期必须填写！\n");
                this.tabControl1.SelectedTab = tabPage1;
                dtpBeginDate.Focus();
                return false; 
            }

            if (dtpEndDate.TextEx == "")
            {
                TXMessageBoxExtensions.Info("提示：竣工日期必须填写！\n");
                this.tabControl1.SelectedTab = tabPage1;
                dtpEndDate.Focus();
                return false;
            }

            //验证单位
            if (!isCheckUnit(new List<TXTextBoxEX>()
            {
                this.txtJsdw,this.txtLxpzdw,this.txtSjdw,this.txtKcdw,this.txtSgdw,this.txtJldw
            },
                new string[] { "建设", "立项批准", "设计", "勘察", "施工", "监理" }))
            {
                return false;
            }

            if (txtGhcode.Text == "")
            {
                TXMessageBoxExtensions.Info("提示：工程规划许可证号必须填写！\n");
                this.tabControl1.SelectedTab = tabPage1;
                txtGhcode.Focus();
                return false;
            }
            
            if (ProjectNO == "")//不是编辑
            {
                ERM.BLL.T_Projects_BLL ProjectDB = new ERM.BLL.T_Projects_BLL();
                if (ProjectDB.Exists(txtProjectNo.Text.Trim()))
                {
                    TXMessageBoxExtensions.Info("提示：工程编号有重复的请重新填写！");
                    this.tabControl1.SelectedTab = tabPage1;
                    txtProjectNo.Focus();
                    return false;
                }
                if (txtProjectName.Text.Trim() != ""
                    && ProjectDB.ExistsName(txtProjectName.Text.Trim()))
                {
                    TXMessageBoxExtensions.Info("提示：工程名称有重复的请重新填写！");
                    this.tabControl1.SelectedTab = tabPage1;
                    txtProjectName.Focus();
                    return false;
                }
            }

            if ((!String.IsNullOrEmpty(this.dtpBeginDate.TextEx)) && dtpBeginDate.TextEx != "")
            {
                if (this.dtpEndDate.TextEx != "" &&
                    (!this.dtpBeginDate.TextEx.Equals(this.dtpEndDate.TextEx)) &&
                            (MyCommon.ToDate(dtpBeginDate.TextEx) >
                            MyCommon.ToDate(dtpEndDate.TextEx)))
                {
                    TXMessageBoxExtensions.Info("提示：工程基本信息：开工日期 必须小于 竣工日期！");
                    this.tabControl1.SelectedTab = tabPage1;
                    this.dtpEndDate.Focus();
                    return false;
                }
            }

            projectMDL = obj.GetInfo(ProjectNo, projectMDL, 1) as T_Projects;

            projectMDL.ProjectNO = MyCommon.ToSqlString(txtProjectNo.Text);     //工程编号
            projectMDL.district = MyCommon.ToSqlString(cboDistrict.Text);       //所属区域
            projectMDL.projectname = MyCommon.ToSqlString(txtProjectName.Text); //工程名称
            projectMDL.address = MyCommon.ToSqlString(txtAddress.Text);         //工程地址
            projectMDL.ajdh = MyCommon.ToSqlString(txtysbah.Text);//验收备案号
            projectMDL.ProjectCategory = cboProjectType.SelectedValue.ToString();
            projectMDL.begindate = dtpBeginDate.TextEx;//开工时间
            projectMDL.enddate = dtpEndDate.TextEx;//竣工时间
            projectMDL.ghcode = MyCommon.ToSqlString(txtGhcode.Text);
            projectMDL.sgcode = MyCommon.ToSqlString(txtSgcode.Text);
            projectMDL.tbr = Globals.Fullname;
           
            //projectMDL.ydpzcode = MyCommon.ToSqlString(txtYdpzcode.Text);
            projectMDL.ydxkcode = MyCommon.ToSqlString(txtYdghxkCode.Text);
            SetItemInfo(itemMDL.ItemID, 1);

            if (this.ProjectNO == "")
            {
                projectMDL.createdate = DateTime.Now.ToString("yyyy.MM.dd");
                itemMDL.ItemID = Guid.NewGuid().ToString();
                projectMDL.ItemID = itemMDL.ItemID;
                SaveUnit();
                if (!obj.Add(projectMDL, itemMDL))
                {
                    TXMessageBoxExtensions.Info("保存失败！");
                    return false;
                }
                this.ProjectNO = txtProjectNo.Text;
                txtProjectNo.Enabled = false;
                try
                {
                    System.IO.Directory.CreateDirectory(Globals.ProjectPathParent + MyCommon.ToSqlString(txtProjectNo.Text));
                }
                catch
                {
                    TXMessageBoxExtensions.Info("发生错误，请检查存放电子文件的目录是否存在及可写！");
                }
            }
            else
            {
                SaveUnit();
                if (!obj.Updates(projectMDL, itemMDL))
                {
                    TXMessageBoxExtensions.Info("保存失败！");
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        ///  保存单位
        /// </summary>
        /// <returns></returns>
        private void SaveUnit() {
            List<T_Units> unitMDL = new List<T_Units>();
            T_Units_BLL units_bll = new T_Units_BLL();
            unitMDL.Add(new T_Units() { dwmc = this.txtJsdw.Text, ProjectNO = this.txtProjectNo.Text, unittype = "unit1", UnitID = Guid.NewGuid().ToString() });
            unitMDL.Add(new T_Units() { dwmc = this.txtSjdw.Text, ProjectNO = this.txtProjectNo.Text, unittype = "unit3", UnitID = Guid.NewGuid().ToString() });
            unitMDL.Add(new T_Units() { dwmc = this.txtSgdw.Text, ProjectNO = this.txtProjectNo.Text, unittype = "unit4", UnitID = Guid.NewGuid().ToString() });
            unitMDL.Add(new T_Units() { dwmc = this.txtJldw.Text, ProjectNO = this.txtProjectNo.Text, unittype = "unit6", UnitID = Guid.NewGuid().ToString() });
            unitMDL.Add(new T_Units() { dwmc = this.txtKcdw.Text, ProjectNO = this.txtProjectNo.Text, unittype = "unit2", UnitID = Guid.NewGuid().ToString() });
            unitMDL.Add(new T_Units() { dwmc = this.txtLxpzdw.Text, ProjectNO = this.txtProjectNo.Text, unittype = "unit15", UnitID = Guid.NewGuid().ToString() });

            foreach (var item in unitMDL)
            {
                if (units_bll.Exists1(item))
                {
                    units_bll.Updates(item);
                }
                else
                {
                    units_bll.Insert(item);
                }
            }
        }

        /// <summary>
        /// 验证单位是否正确
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        private bool isCheckUnit(List<TXTextBoxEX>list,string[] dwmc)
        {
            int i = 0;
            int flag = 0;
            foreach (var item in list)
            {
                if (string.IsNullOrEmpty(item.Text))
                {
                    TXMessageBoxExtensions.Info("提示：" + dwmc[i].ToString() + "单位不能为空！");
                    this.tabControl1.SelectedTab = tabPage1;
                    item.Focus();
                    flag = 1;
                    break;
                }
                i++;
            }
            if (flag>0)
            {
                return false;  
            }
            return true;
        }

        /// <summary>
        /// 获取工程的建设单位名称和负责人
        /// 如果有多个单位，默认取第一条记录
        /// </summary>
        /// <returns>MDL.T_Units</returns>
        private MDL.T_Units GetJSDW()
        {
            BLL.T_Units_BLL Units_BLL = new BLL.T_Units_BLL();
            MDL.T_Units mdl_unit = new ERM.MDL.T_Units();
            mdl_unit.ProjectNO = this.ProjectNO;
            mdl_unit.unittype = "unit1";
            DataSet tbl_units = Units_BLL.GetList(mdl_unit);
            if (tbl_units != null && tbl_units.Tables.Count > 0 &&
                tbl_units.Tables[0].Rows.Count > 0)
            {
                mdl_unit.dwmc = tbl_units.Tables[0].Rows[0]["dwmc"].ToString();
                mdl_unit.fzr = tbl_units.Tables[0].Rows[0]["fzr"].ToString();
            }
            return mdl_unit;
        }
        #endregion

        /// <summary>
        /// 选择不同工程类型显示不同的工程扩展信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboProjectType_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.gbjz.Controls.Clear();
            getInstance();

            this.gbjz.Text = this.cboProjectType.Text;

            this.tabPage2.AutoScroll = (this.gbjz.Height > this.tabPage2.Height) ? true : false;
        }

        /// <summary>
        /// 根据工程类型动态创建相应用户控件对象
        /// </summary>
        /// <returns></returns>
        private void getInstance()
        {
            try
            {
                obj = Project_Factory.getInstance(ds3, this.cboProjectType.SelectedValue.ToString());
                obj.GetInfo(ProjectNo, projectMDL);
                UserControl uc = obj as UserControl;
                uc.Top = 15;
                uc.Left = 15;
                this.gbjz.Controls.Add(uc);
            }
            catch (Exception ex)
            {
                TXMessageBoxExtensions.Info(ex.Message);
            }
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {

        }

        private void txtProjectName_Load(object sender, EventArgs e)
        {

        }

        private void btnNew_Click_1(object sender, EventArgs e)
        {

        }

        private void btnEdit_Click_1(object sender, EventArgs e)
        {

        }

        private void btnDel_Click_1(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dtpEndDate_Click(object sender, EventArgs e)
        {
          
        }

        private void dtpEndDate_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void dtpEndDate_MouseClick(object sender, MouseEventArgs e)
        {
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
