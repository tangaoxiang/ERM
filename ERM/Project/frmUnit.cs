using ERM.BLL;
using ERM.MDL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TX.Framework.WindowUI.Forms;
namespace ERM.UI
{
    public partial class frmUnit : ERM.UI.Controls.Skin_DevEX
    {
        private string unitType = "";
        private string ProjectNO = "";
        private string unitID = "";
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="unittype">当前的单位类别</param>
        /// <param name="dv">编辑过程中提交的相关数据</param>
        public frmUnit(string _unittype, string _ProjectNO, string _unitID)
        {
            InitializeComponent();
            this.unitType = _unittype;
            ProjectNO = _ProjectNO;
            this.unitID = _unitID;
        }
        private void frmUnit_Load(object sender, EventArgs e)
        {
            this.Init();
        }
        private void Init()
        {
            ERM.BLL.T_Dict_BLL dicData = new ERM.BLL.T_Dict_BLL();
            IList<MDL.T_Dict> ds = dicData.FindByKeyWord("unittype");
            List<MDL.T_Dict> dictList = new List<MDL.T_Dict>();
            string[] unitList = new string[] { "unit1", "unit6", "unit4", "unit3", "unit2", "unit15" };

            for (int i = 0; i < ds.Count; i++)
            {
                for (int j = 0; j < unitList.Length; j++)
                {
                    if (ds[i].ValueName==unitList[j])
                    {
                        dictList.Add(ds[i]);
                    }
                }
            }
           
            cboUnittype.DisplayMember = "displayname";
            cboUnittype.ValueMember = "valuename";
            cboUnittype.DataSource = dictList;
            if (this.unitType != null)
            {
                cboUnittype.SelectedValue = unitType;
            }
            if (unitID != "")
            {
                BLL.T_Units_BLL unitBLL = new ERM.BLL.T_Units_BLL();
                MDL.T_Units unitMDL = unitBLL.Find(unitID);
                txtUnitid.Text = unitMDL.UnitID;
                if (string.Compare(cboUnittype.SelectedValue.ToString(), "unit12", true) == 0 || string.Compare(cboUnittype.SelectedValue.ToString(), "unit13", true) == 0)
                {
                    txtOther.Text = unitMDL.fzr;
                }
                else
                {
                    txtDwmc.Text = unitMDL.dwmc;
                    txtFzr.Text = unitMDL.fzr;
                    txtFzrzs.Text = unitMDL.fzrzs;
                    txtXmjl.Text = unitMDL.xmjl;
                    txtZzdj.Text = unitMDL.zzdj;
                    txtZzzh.Text = unitMDL.zzzh;
                    txtAddr.Text = unitMDL.addr;
                    txtTel.Text = unitMDL.tel;
                    txtFax.Text = unitMDL.fax;
                    txtRemark.Text = unitMDL.remark;

                    txtXmzyzljcy.Text = unitMDL.xmzyzljcy;
                    txtZlfzr.Text = unitMDL.zlfzr;
                    txtJccsfzr.Text = unitMDL.jccsfzr;
                    txtSyxfzr.Text = unitMDL.syxfzr;
                    txtTsfzr.Text = unitMDL.tsfzr;
                    txtOther.Text = unitMDL.xcjl;
                }
            }
        }
        private void ChangeForm(string unittypeValue)
        {
            if (string.Compare(unittypeValue, "unit12", true) == 0 || string.Compare(unittypeValue, "unit13", true) == 0)
            {
                tableLayoutPanel1.Visible = false;
                txtOther.Visible = true;
                label5.Visible = true;
                if (string.Compare(unittypeValue, "unit12", true) == 0)
                {
                    label5.Text = "施工班组长";
                }
                else
                {
                    label5.Text = "专业工长";
                }
            }
            else
            {
                tableLayoutPanel1.Visible = true;
                txtOther.Visible = false;
                label5.Visible = false;
            }

            lblJccsfzr.Visible = false;
            txtJccsfzr.Visible = false;
            lblSyxfzr.Visible = false;
            txtSyxfzr.Visible = false;
            lblTsfzr.Visible = false;
            txtTsfzr.Visible = false;

            switch (unittypeValue)
            {
                case "unit1":   //建设单位
                    lblXmjl.Visible = false;
                    txtXmjl.Visible = false;
                    lblFzr.Text = "项目负责人";
                    lblFzrzh.Text = "项目负责人资格证号";
                    lblPrompt.Text = "单位名称、项目负责人等在填表时会自动调出，供用户选择";
                    lblZlfzr.Visible = true;
                    txtZlfzr.Visible = true;
                    break;
                case "unit2":   //勘察单位
                    lblXmjl.Text = "单位技术负责人";
                    lblXmjl.Visible = true;
                    txtXmjl.Visible = true;
                    lblFzr.Text = "项目负责人";
                    lblFzrzh.Text = "项目负责人资格证号";
                    lblPrompt.Text = "单位名称、项目负责人、单位技术负责人等在填表时会自动调出，供用户选择";
                    break;
                case "unit3":   //设计单位
                    lblXmjl.Text = "单位技术负责人";
                    lblXmjl.Visible = true;
                    txtXmjl.Visible = true;
                    lblFzr.Text = "项目负责人";
                    lblFzrzh.Text = "项目负责人资格证号";
                    lblPrompt.Text = "单位名称、项目负责人、单位技术负责人等在填表时会自动调出，供用户选择";
                    break;
                case "unit4":   //施工单位
                    lblXmjl.Text = "项目经理";
                    lblXmjl.Visible = true;
                    txtXmjl.Visible = true;
                    lblFzr.Text = "技术负责人";
                    lblFzrzh.Text = "技术负责人资格证号";
                    lblPrompt.Text = "单位名称、技术负责人、项目经理等在填表时会自动调出，供用户选择";

                    lblXmjl.Visible = true;
                    txtXmjl.Visible = true;
                    lblXmzyzljcy.Visible = true;
                    txtXmzyzljcy.Visible = true;

                    lblJccsfzr.Visible = true;
                    txtJccsfzr.Visible = true;
                    lblSyxfzr.Visible = true;
                    txtSyxfzr.Visible = true;
                    lblTsfzr.Visible = true;
                    txtTsfzr.Visible = true;

                    break;
                case "unit5":   //施工图审查单位
                    lblXmjl.Visible = false;
                    txtXmjl.Visible = false;
                    lblFzr.Text = "项目负责人";
                    lblFzrzh.Text = "项目负责人资格证号";
                    lblPrompt.Text = "单位名称、项目负责人等在填表时会自动调出，供用户选择";
                    break;
                case "unit6":   //监理单位
                    lblXmjl.Text = "项目总监";
                    lblXmjl.Visible = true;
                    txtXmjl.Visible = true;
                    label5.Visible = true;
                    txtOther.Visible = true;
                    //lbljl.Visible = true;
                    //txtxcjl.Visible = true;
                    label5.Text = "现场监理";
                    lblFzrzh.Text = "监理工程师资格证号";
                    lblPrompt.Text = "单位名称、监理工程师、总监理工程师等在填表时会自动调出，供用户选择";
                    break;
                case "unit7":   //监督单位
                    lblXmjl.Visible = false;
                    txtXmjl.Visible = false;
                    lblFzr.Text = "监督员";
                    lblFzrzh.Text = "监督员资格证号";
                    lblPrompt.Text = "单位名称、监督员等在填表时会自动调出，供用户选择";
                    break;
                case "unit8":   //分包单位
                    lblXmjl.Text = "项目经理";
                    lblXmjl.Visible = true;
                    txtXmjl.Visible = true;
                    lblFzr.Text = "技术负责人";
                    lblFzrzh.Text = "技术负责人资格证号";
                    lblPrompt.Text = "单位名称、技术负责人、项目经理等在填表时会自动调出，供用户选择";
                    break;
                case "unit9":   //总承包单位
                    lblXmjl.Text = "项目经理";
                    lblXmjl.Visible = true;
                    txtXmjl.Visible = true;
                    lblFzr.Text = "总承包负责人";
                    lblFzrzh.Text = "总承包负责人资格证号";
                    lblPrompt.Text = "单位名称、总承包负责人、项目经理等在填表时会自动调出，供用户选择";

                    lblXmjl.Visible = true;
                    txtXmjl.Visible = true;
                    lblXmzyzljcy.Visible = true;
                    txtXmzyzljcy.Visible = true;

                    break;
                case "unit10":   //安装单位
                    lblXmjl.Text = "项目经理";
                    lblXmjl.Visible = true;
                    txtXmjl.Visible = true;
                    lblFzr.Text = "安装负责人";
                    lblFzrzh.Text = "安装负责人资格证号";
                    lblPrompt.Text = "单位名称、安装负责人、项目经理等在填表时会自动调出，供用户选择";
                    break;
                case "unit11":   //其他单位
                    lblXmjl.Text = "项目经理";
                    lblXmjl.Visible = true;
                    txtXmjl.Visible = true;
                    lblFzr.Text = "负责人";
                    lblFzrzh.Text = "负责人资格证号";
                    lblPrompt.Text = "单位名称、负责人、项目经理等在填表时会自动调出，供用户选择";
                    break;
                case "unit14":   //测量单位
                    lblXmjl.Text = "项目经理";
                    lblXmjl.Visible = true;
                    txtXmjl.Visible = true;
                    lblFzr.Text = "测量人员";
                    lblFzrzh.Text = "测量人员资格证号";
                    lblPrompt.Text = "单位名称、负责人、项目经理等在填表时会自动调出，供用户选择";
                    break;
            }
        }
        /// <summary>
        /// 改变单位类别时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboUnittype_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboUnittype.SelectedValue == null)
                cboUnittype.SelectedIndex = 0;
            this.ChangeForm(cboUnittype.SelectedValue.ToString());
        }
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (string.Compare(cboUnittype.SelectedValue.ToString(), "unit12", true) == 0 || string.Compare(cboUnittype.SelectedValue.ToString(), "unit13", true) == 0)
            {
                if (txtOther.Text.Trim() == "")
                {
                    TXMessageBoxExtensions.Info("请填写姓名！");
                    txtOther.Focus();
                    return;
                }
            }
            else
            {
                if (txtDwmc.Text.Trim() == "")
                {
                    TXMessageBoxExtensions.Info("单位名称必须填写！");
                    txtDwmc.Focus();
                    return;
                }
            }


            T_Units_BLL unitBLL = new T_Units_BLL();
            T_Units unitsList = new T_Units();
            unitsList.ProjectNO = ProjectNO;
            unitsList.unittype = this.cboUnittype.SelectedValue.ToString();
            DataSet ds = unitBLL.GetList(unitsList);
            if (ds.Tables.Count>0)
            {
                if (ds.Tables[0].Rows.Count>0)
                {
                    TXMessageBoxExtensions.Info("该工程已经存在相同类型单位，不能重复添加！");
                    return; 
                }
            }

            this.DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtOther_Load(object sender, EventArgs e)
        {

        }

        private void txtXmjl_Load(object sender, EventArgs e)
        {

        }

        private void txtZzdj_Load(object sender, EventArgs e)
        {

        }

        private void txtZzzh_Load(object sender, EventArgs e)
        {

        }

        private void txtFzr_Load(object sender, EventArgs e)
        {

        }

        private void txtFzrzs_Load(object sender, EventArgs e)
        {

        }

        private void txtTel_Load(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnConfirm_Click_1(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {

        }
    }
}
