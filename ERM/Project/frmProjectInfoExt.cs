using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ERM.Common;
using TX.Framework.WindowUI.Forms;
using TX.Framework.WindowUI.Controls;
namespace ERM.UI
{
    public partial class frmProjectInfoExt : ERM.UI.Controls.Skin_DevEX
    {
        ERM.MDL.T_Item itemMDL;
        public frmProjectInfoExt(ERM.MDL.T_Projects _model_project,ERM.MDL.T_Item _model_item)
        {
            InitializeComponent();
            itemMDL = _model_item;
        }
        private void frmProjectInfoExt_Load(object sender, EventArgs e)
        {
                Init();
        }
        private void Init()
        {
            txtConStructionProjectName.Text = itemMDL.ConStructionProjectName;
            txtRespective.Text = itemMDL.Respective;
            txtConstructionProjectAdd.Text = itemMDL.ConstructionProjectAdd;
            txtProjectType.Text = itemMDL.ProjectType;
            txtUseSoiAreaSum.Text = itemMDL.UseSoiAreaSum;
            txtConstructionAreaSum.Text = itemMDL.ConstructionAreaSum;
            txtConstructionScale.Text = itemMDL.ConstructionScale;
            txtProjectCost.Text = itemMDL.ProjectCost;
            txtProjectSettlement.Text = itemMDL.ProjectSettlement;
            if(!string.IsNullOrEmpty(itemMDL.StartDate))
                dtpBeginDate.Value = Convert.ToDateTime( itemMDL.StartDate);
            if (!string.IsNullOrEmpty(itemMDL.FinishDate))
            {
                dtpEndDate.Value = Convert.ToDateTime(itemMDL.FinishDate);
            }
            txtUseSoiType.Text = itemMDL.UseSoiType;
            txtCollectionType.Text = itemMDL.CollectionType;
            txtOriginalSoiType.Text = itemMDL.OriginalSoiType;
            txtUseSoiArea.Text = itemMDL.UseSoiArea;
            if (!string.IsNullOrEmpty(itemMDL.Approvedate ))
                dtpApprove.Value = Convert.ToDateTime(itemMDL.Approvedate);
            txtCreateUnit.Text = itemMDL.CreateUnit;
            txtItemFzr.Text = itemMDL.ItemFzr;
            txtAllCost.Text = itemMDL.AllCost;
            txtVolumeFar.Text = itemMDL.VolumeFar;
            txtGreenFar.Text = itemMDL.GreenFar;
            txtBuildingDensity.Text = itemMDL.BuildingDensity;
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!Check())
                return;
           itemMDL.ConStructionProjectName =MyCommon.ToSqlString2( txtConStructionProjectName.Text);
           itemMDL.Respective = MyCommon.ToSqlString2(txtRespective.Text);
           itemMDL.ConstructionProjectAdd = MyCommon.ToSqlString2(txtConstructionProjectAdd.Text);
           itemMDL.ProjectType = MyCommon.ToSqlString2(txtProjectType.Text);
           itemMDL.UseSoiAreaSum = txtUseSoiAreaSum.GetText;
           itemMDL.ConstructionAreaSum =  txtConstructionAreaSum.GetText;
           itemMDL.ConstructionScale = MyCommon.ToSqlString2(txtConstructionScale.Text);
           itemMDL.ProjectCost = txtProjectCost.GetText;
           itemMDL.ProjectSettlement = txtProjectSettlement.GetText;
           itemMDL.StartDate = dtpBeginDate.Value.ToString("yyyy.MM.dd");
           itemMDL.FinishDate = dtpEndDate.Checked ? dtpEndDate.Value.ToString("yyyy.MM.dd") : "";
           itemMDL.UseSoiType = MyCommon.ToSqlString2(txtUseSoiType.Text);
           itemMDL.CollectionType = MyCommon.ToSqlString2(txtCollectionType.Text);
           itemMDL.OriginalSoiType = MyCommon.ToSqlString2(txtOriginalSoiType.Text);
           itemMDL.UseSoiArea = txtUseSoiArea.GetText;
           itemMDL.Approvedate = dtpApprove.Checked?dtpApprove.Value.ToString("yyyy.MM.dd"):"";
           itemMDL.CreateUnit = MyCommon.ToSqlString2(txtCreateUnit.Text);
           itemMDL.ItemFzr = MyCommon.ToSqlString2(txtItemFzr.Text);
           itemMDL.AllCost = txtAllCost.GetText;
           if (!String.IsNullOrEmpty(txtVolumeFar.GetText))
           {
               if (Convert.ToInt32(txtVolumeFar.GetText) > 100)
               {
                   itemMDL.VolumeFar = "100";
               }
               else
               {
                   itemMDL.VolumeFar = txtVolumeFar.GetText;
               }
           }
           if (!String.IsNullOrEmpty(txtGreenFar.GetText))
           {
               if (Convert.ToInt32(txtGreenFar.GetText) > 100)
               {
                   itemMDL.VolumeFar = "100";
               }
               else
               {
                   itemMDL.VolumeFar = txtGreenFar.GetText;
               }
           }
           if (!String.IsNullOrEmpty(txtBuildingDensity.GetText))
           {
               if (Convert.ToInt32(txtBuildingDensity.GetText) > 100)
               {
                   itemMDL.VolumeFar = "100";
               }
               else
               {
                   itemMDL.VolumeFar = txtBuildingDensity.GetText;
               }
           }
           this.DialogResult = DialogResult.OK;
        }
        private void butClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// 判断 数字
        /// </summary>
        /// <returns></returns>
        private bool Check()
        {
            foreach (Control c in groupBox1.Controls)
            {
                if (c.GetType() == typeof(TextBox))
                {
                    ERM.UI.Controls.TXTextBoxEX t = (ERM.UI.Controls.TXTextBoxEX)c;
                    if (t.Text != "" && t.Tag != null)
                    {
                        string[] strArr = t.Tag.ToString().ToLower().Split(',');
                        if (strArr.Length != 2)
                            continue;
                        string tag = strArr[1];
                        if (tag == "number")
                        {
                            if (!MyCommon.ProjectIsNumericParse(t.Text))
                            {
                                TXMessageBoxExtensions.Info("\"" + t.Tag.ToString().Split(',')[0] + "\" 必须是数字且为正数！");
                                t.Text = "0";
                                t.Focus();
                                return false;
                            }
                            else
                            {
                                string[] sp = t.Text.Trim().Split('.');
                                if (sp.Length > 1)
                                {
                                    if (sp[1].Length > 3)
                                    {
                                        t.Text = sp[0] + "." + sp[1].Substring(0, 3);
                                    }
                                }
                            }
                        }
                        else if (tag == "int")
                        {
                            if (!MyCommon.ProjectIsIntParse(t.Text))
                            {
                                TXMessageBoxExtensions.Info("\"" + t.Tag.ToString().Split(',')[0] + "\" 必须是整数且为正数！");
                                t.Text = "0";
                                t.Focus();
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
        }

        private void btnOK_Click_1(object sender, EventArgs e)
        {

        }

        private void butClose_Click_1(object sender, EventArgs e)
        {

        }
    }
}
