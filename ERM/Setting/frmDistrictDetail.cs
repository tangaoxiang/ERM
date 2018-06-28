using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ERM.Common;
using ERM.BLL;
using TX.Framework.WindowUI.Forms;
using CCWin;
namespace ERM.UI
{
    public partial class frmDistrictDetail : ERM.UI.Controls.Skin_DevEX
    {
        ERM.BLL.District DistrictDB = new ERM.BLL.District();//DistrictDB数据库操作类
        ERM.MDL.District District = new ERM.MDL.District();//District实体类
        ERM.CBLL.District DistrictDBC = new ERM.CBLL.District();
        private string optype;
        public string OpType
        {
            get { return this.optype; }
            set { this.optype = value; }
        }
        /// <summary>
        /// 区域ID主键
        /// </summary>
        private int districtID;
        public int DistrictID
        {
            set { this.districtID = value; }
            get { return this.districtID; }
        }
        public frmDistrictDetail()
        {
            InitializeComponent();
        }
       /// <summary>
       /// 窗体加载事件
       /// </summary>
       /// <param name="sender"></param>
       /// <param name="e"></param>
        private void frmDistrictDetail_Load(object sender, EventArgs e)
        {
            if (this.OpType == "Add")
            {
                this.Text = "添加区域详细信息";
                 this.numOrderIndex.Value =  DistrictDBC.GetNextOrderIndex();
            }
            else
            {
                this.Text = "编辑区域详细信息";
                SetData();
            }
        }
        /// <summary>
        /// 给控件赋值
        /// </summary>
        private void SetData()
        {
            District = DistrictDB.Find(this.districtID);
            this.txtDistrictName.Text = District.DistrictName;
            this.numOrderIndex.Value = District.OrderIndex;
        }
        /// <summary>
        /// 保存数据
        /// </summary>
        private void SaveData()
        {
            if (!ValidateData())
            {
                return;
            }
            GetData();
            if (this.OpType == "Add")//添加
            {
                if (!DistrictDBC.Exists(District.DistrictName))  //判断是否存相同的区域名称
                {
                    District.DistrictID = District.OrderIndex;
                    DistrictDB.Add(District);//添加
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    TXMessageBoxExtensions.Info("已经存相同的区域名称！");
                    this.txtDistrictName.Focus();
                    return;
                }
            }
            else//编辑
            {
                if (!DistrictDBC.Exists(District.DistrictName,District.DistrictID.Value))  //判断是否存相同的区域名称
                {
                    DistrictDBC.Update(District);//更新
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    TXMessageBoxExtensions.Info("已经存相同的区域名称！");
                    this.txtDistrictName.Focus();
                    return;
                }
            }
        }
        /// <summary>
        /// 验证数据必填项
        /// </summary>
        /// <returns></returns>
        private bool ValidateData()
        {
            if (this.txtDistrictName.Text.Trim() == "")
            {
                TXMessageBoxExtensions.Info("区域名不能为空！");
                this.txtDistrictName.Focus();
                return false;
            }
            return true;
        }
        /// <summary>
        /// 保存数据
        /// </summary>
        private void GetData()
        {
             District.DistrictName=this.txtDistrictName.Text.Trim();
             District.OrderIndex = (int)this.numOrderIndex.Value ;
             District.TempID = 4;
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            SaveData();
        }

        private void btnConfirm_Click_1(object sender, EventArgs e)
        {

        }

        private void btnConfirm_Click_2(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {

        }
    }
}
