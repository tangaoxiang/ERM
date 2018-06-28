using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
namespace ERM.CBLL
{
    public class CreateSip
    {
        private string _openedProjectNo = "";
        private ERM.BLL.T_Projects_BLL projectsData = new ERM.BLL.T_Projects_BLL();
        private ERM.BLL.T_Units_BLL unitData = new ERM.BLL.T_Units_BLL();
        private ERM.BLL.T_Item_BLL itemData = new ERM.BLL.T_Item_BLL();
        private Hashtable _projectDetail;
        /// <summary>
        /// 获取工程所有信息，在表头填充时用
        /// </summary>
        public Hashtable ProjectDetail
        {
            get { return _projectDetail; }
        }
        private Hashtable _item;
        /// <summary>
        /// 项目信息
        /// </summary>
        public Hashtable Item
        {
            get { return _item; }
        }
        /// <summary>
        /// 生成sip包
        /// </summary>
        /// <param name="openedProjectNo"></param>
        public CreateSip(string openedProjectNo)
        {
            this._openedProjectNo = openedProjectNo;
            ERM.MDL.T_Projects projectInfo = projectsData.Find(_openedProjectNo);

            Hashtable projectDetail = new Hashtable();
            CreatePaoject(projectInfo, projectDetail);
            Hashtable Item = new Hashtable();
            CreateItem(projectInfo, Item);
        }
        /// <summary>
        /// 获取项目基本信息
        /// </summary>
        /// <param name="projectInfo"></param>
        /// <param name="projectDetail"></param>
        private void CreateItem(ERM.MDL.T_Projects projectInfo, Hashtable Item)
        {
            string strOut = "";
            ERM.MDL.T_Item ItemInfo = itemData.Find(projectInfo.ItemID);
            Item.Add("项目名称", ItemInfo.ConStructionProjectName);
            Item.Add("所属区域", ItemInfo.Respective);
            Item.Add("工程地址", ItemInfo.ConstructionProjectAdd);
            Item.Add("工程类别", ItemInfo.ProjectType);
            Item.Add("总用地面积", ItemInfo.UseSoiAreaSum);
            Item.Add("总建筑面积", ItemInfo.ConstructionAreaSum);
            Item.Add("建设规模", ItemInfo.ConstructionScale);
            Item.Add("工程造价", ItemInfo.ProjectCost);
            Item.Add("工程结算", ItemInfo.ProjectSettlement);
            strOut = "";
            try
            {
                strOut = DateTime.Parse(ItemInfo.StartDate).ToString("yyyy.MM.dd");
            }
            catch { strOut = ""; }
            Item.Add("开工时间", strOut);

            strOut = "";
            try
            {
                strOut = DateTime.Parse(ItemInfo.FinishDate).ToString("yyyy.MM.dd");
            }
            catch { strOut = ""; }
            Item.Add("竣工时间", strOut);

            Item.Add("用地分类", ItemInfo.UseSoiType);
            Item.Add("征拨分类", ItemInfo.CollectionType);
            Item.Add("原土地分类", ItemInfo.OriginalSoiType);
            Item.Add("用地面积", ItemInfo.UseSoiArea);
            strOut = "";
            try
            {
                strOut = DateTime.Parse(ItemInfo.Approvedate).ToString("yyyy.MM.dd");
            }
            catch { strOut = ""; }
            Item.Add("批准时间", strOut);

            Item.Add("建设单位", ItemInfo.CreateUnit);
            Item.Add("建设单位项目负责人", ItemInfo.ItemFzr);
            Item.Add("总地价", ItemInfo.AllCost);
            Item.Add("容积率", ItemInfo.VolumeFar);
            Item.Add("绿化率", ItemInfo.GreenFar);
            Item.Add("建筑密度", ItemInfo.BuildingDensity);
            this._item = Item;
        }
        /// <summary>
        /// 生成工程信息 Hashtable
        /// </summary>
        /// <param name="projectInfo"></param>
        /// <param name="projectDetail"></param>
        private void CreatePaoject(ERM.MDL.T_Projects projectInfo, Hashtable projectDetail)
        {
            string strOut = "";
            projectDetail.Add("工程代码", projectInfo.ProjectNO);
            projectDetail.Add("工程名称", projectInfo.projectname);
            projectDetail.Add("工程地址", projectInfo.address);
            projectDetail.Add("工程性质", projectInfo.category);
            projectDetail.Add("结构类型", projectInfo.stru);
            projectDetail.Add("工程类别", projectInfo.projecttype);
            projectDetail.Add("高度", projectInfo.high);
            projectDetail.Add("地上层数", projectInfo.floors1);
            projectDetail.Add("地下层数", projectInfo.floors2);
            projectDetail.Add("建筑面积", projectInfo.area1);
            projectDetail.Add("用地面积", projectInfo.area2);
            projectDetail.Add("工程用地批准书号", projectInfo.ydpzcode);
            projectDetail.Add("用地规划许可证号", projectInfo.ydxkcode);
            projectDetail.Add("规划许可证号", projectInfo.ghcode);
            projectDetail.Add("工程施工许可证号", projectInfo.sgcode);
            projectDetail.Add("工程预算", projectInfo.price1);
            projectDetail.Add("工程决算", projectInfo.price2);
            strOut = "";
            try
            {
                strOut = DateTime.Parse(projectInfo.begindate).ToString("yyyy.MM.dd");
            }
            catch { strOut = ""; }
            projectDetail.Add("开工日期", strOut);

            strOut = "";
            try
            {
                strOut = DateTime.Parse(projectInfo.bjdate).ToString("yyyy.MM.dd");
            }
            catch { strOut = ""; }
            projectDetail.Add("报建日期", strOut);

            strOut = "";
            try
            {
                strOut = DateTime.Parse(projectInfo.enddate).ToString("yyyy.MM.dd");
            }
            catch { strOut = ""; }
            projectDetail.Add("竣工日期", strOut);

            projectDetail.Add("获奖情况", projectInfo.hjqk);
            projectDetail.Add("住宅面积", projectInfo.zzmj);
            projectDetail.Add("办公用房面积", projectInfo.bgyfmj);
            projectDetail.Add("商业用房面积", projectInfo.syyfmj);
            projectDetail.Add("厂房面积", projectInfo.cfmj);
            projectDetail.Add("地下室面积", projectInfo.dxsmj);
            projectDetail.Add("其他用房面积", projectInfo.qtyfmj);
            projectDetail.Add("单身公寓套数", projectInfo.ts1);
            projectDetail.Add("小户型套数", projectInfo.ts2);
            projectDetail.Add("中户型套数", projectInfo.ts3);
            projectDetail.Add("大户型套数", projectInfo.ts4);
            projectDetail.Add("总套数", projectInfo.tstotal);
            projectDetail.Add("专业工长", projectInfo.zygz);
            projectDetail.Add("项目专业质量检验员", projectInfo.zjy);
            projectDetail.Add("施工班组长", projectInfo.sgbzz);
            projectDetail.Add("填表人", projectInfo.tbr);
            projectDetail.Add("建设单位提交人", projectInfo.jsdwshr);
            projectDetail.Add("监理单位提交人", projectInfo.jldwshr);
            strOut = "";
            try
            {
                strOut = DateTime.Parse(projectInfo.createdate).ToString("yyyy.MM.dd");
            }
            catch { strOut = ""; }
            projectDetail.Add("填表时间", strOut);
            
            //dv = unitData.GetList("ProjectNO='" + this._openedProjectNo + "' and unittype='unit3'").Tables[0].DefaultView;
            UnitSetting(projectDetail);
            ////建设单位信息
            ////施工图审查单位
            ////监督单位
            ////安装单位
            this._projectDetail = projectDetail;
        }

        public DataView UnitSetting(Hashtable projectDetail)
        {
            MDL.T_Units mdl_unit = new ERM.MDL.T_Units();
            mdl_unit.ProjectNO = this._openedProjectNo;
            DataView dv;
            mdl_unit.unittype = "unit3";
            dv = unitData.GetList(mdl_unit).Tables[0].DefaultView;
            if (dv.Count <= 1)
            {
                if (dv.Count == 0)
                {
                    projectDetail.Add("设计单位", "");
                    projectDetail.Add("设计单位项目负责人", "");
                }
                else
                {
                    projectDetail.Add("设计单位", dv[0]["dwmc"].ToString());
                    projectDetail.Add("设计单位项目负责人", dv[0]["fzr"].ToString());
                }
            }
            else
            {
                string[] sjdwmc = new string[dv.Count];  //单位名称
                string[] sjdwxmfzr = new string[dv.Count]; //项目负责人
                string[] sjdwjsfzr = new string[dv.Count]; //技术负责人
                for (int i = 0; i < dv.Count; i++)
                {
                    sjdwmc[i] = dv[i]["dwmc"].ToString();
                    sjdwxmfzr[i] = dv[i]["fzr"].ToString();
                }
                projectDetail.Add("设计单位", sjdwmc);
                projectDetail.Add("设计单位项目负责人", sjdwxmfzr);
            }
            //dv = unitData.GetList("ProjectNO='" + this._openedProjectNo + "' and unittype='unit2'").Tables[0].DefaultView;
            mdl_unit.unittype = "unit2";
            dv = unitData.GetList(mdl_unit).Tables[0].DefaultView;
            if (dv.Count <= 1)
            {
                if (dv.Count == 0)
                {
                    projectDetail.Add("勘察单位", "");
                    projectDetail.Add("勘察单位项目负责人", "");
                }
                else
                {
                    projectDetail.Add("勘察单位", dv[0]["dwmc"].ToString());
                    projectDetail.Add("勘察单位项目负责人", dv[0]["fzr"].ToString());
                }
            }
            else
            {
                string[] kcdwmc = new string[dv.Count];  //单位名称
                string[] kcdwxmfzr = new string[dv.Count]; //项目负责人
                string[] kcdwjsfzr = new string[dv.Count]; //技术负责人
                for (int i = 0; i < dv.Count; i++)
                {
                    kcdwmc[i] = dv[i]["dwmc"].ToString();
                    kcdwxmfzr[i] = dv[i]["fzr"].ToString();
                }
                projectDetail.Add("勘察单位", kcdwmc);
                projectDetail.Add("勘察单位项目负责人", kcdwxmfzr);
            }
            //dv = unitData.GetList("ProjectNO='" + this._openedProjectNo + "' and unittype='unit6'").Tables[0].DefaultView;
            mdl_unit.unittype = "unit6";
            dv = unitData.GetList(mdl_unit).Tables[0].DefaultView;
            if (dv.Count <= 1)
            {
                if (dv.Count == 0)
                {
                    projectDetail.Add("监理单位", "");
                    projectDetail.Add("监理单位项目负责人", "");
                    projectDetail.Add("项目总监", "");
                    projectDetail.Add("现场监理", "");
                }
                else
                {
                    projectDetail.Add("监理单位", dv[0]["dwmc"].ToString());
                    projectDetail.Add("监理单位项目负责人", dv[0]["fzr"].ToString());
                    projectDetail.Add("项目总监", dv[0]["xmjl"].ToString());
                    projectDetail.Add("现场监理", dv[0]["fzr"].ToString());
                }
            }
            else
            {
                string[] jldwmc = new string[dv.Count];  //单位名称
                string[] jldwjlgcs = new string[dv.Count]; //监理工程师
                string[] jldwzjlgcs = new string[dv.Count]; //总监理工程师
                for (int i = 0; i < dv.Count; i++)
                {
                    jldwmc[i] = dv[i]["dwmc"].ToString();
                    jldwjlgcs[i] = dv[i]["fzr"].ToString();
                    jldwzjlgcs[i] = dv[i]["xmjl"].ToString();
                }
                projectDetail.Add("监理单位", jldwmc);
                projectDetail.Add("监理单位项目负责人", jldwjlgcs);
                projectDetail.Add("项目总监", jldwzjlgcs);
                projectDetail.Add("现场监理", jldwjlgcs);
            }
            //dv = unitData.GetList("ProjectNO='" + this._openedProjectNo + "' and unittype='unit8'").Tables[0].DefaultView;
            mdl_unit.unittype = "unit8";
            dv = unitData.GetList(mdl_unit).Tables[0].DefaultView;
            if (dv.Count <= 1)
            {
                if (dv.Count == 0)
                {
                    projectDetail.Add("分包单位", "");
                    projectDetail.Add("分包单位项目经理", "");
                }
                else
                {
                    projectDetail.Add("分包单位", dv[0]["dwmc"].ToString());
                    projectDetail.Add("分包单位项目经理", dv[0]["xmjl"].ToString());
                }
            }
            else
            {
                string[] fbdwmc = new string[dv.Count];  //单位名称
                string[] fbdwxmjl = new string[dv.Count]; //项目经理
                for (int i = 0; i < dv.Count; i++)
                {
                    fbdwmc[i] = dv[i]["dwmc"].ToString();
                    fbdwxmjl[i] = dv[i]["xmjl"].ToString();
                }
                projectDetail.Add("分包单位", fbdwmc);
                projectDetail.Add("分包单位项目经理", fbdwxmjl);
            }
            //dv = unitData.GetList("ProjectNO='" + this._openedProjectNo + "' and unittype='unit4'").Tables[0].DefaultView;
            mdl_unit.unittype = "unit4";
            dv = unitData.GetList(mdl_unit).Tables[0].DefaultView;
            if (dv.Count <= 1)
            {
                if (dv.Count == 0)
                {
                    projectDetail.Add("施工单位", "");
                    projectDetail.Add("施工单位项目经理", "");
                }
                else
                {
                    projectDetail.Add("施工单位", dv[0]["dwmc"].ToString());
                    projectDetail.Add("施工单位项目经理", dv[0]["xmjl"].ToString());
                }
            }
            else
            {
                string[] sgdwmc = new string[dv.Count];  //单位名称
                string[] sgdwxmfzr = new string[dv.Count]; //项目经理
                string[] sgdwjsfzr = new string[dv.Count]; //技术负责人
                for (int i = 0; i < dv.Count; i++)
                {
                    sgdwmc[i] = dv[i]["dwmc"].ToString();
                    sgdwxmfzr[i] = dv[i]["xmjl"].ToString();
                }
                projectDetail.Add("施工单位", sgdwmc);
                projectDetail.Add("施工单位项目经理", sgdwxmfzr);
            }
            return dv;
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetListArchive(string ProjectNO, string ArchiveID)
        {
            BLL.BLLMore bllMore = new ERM.BLL.BLLMore();
            return bllMore.GetListArchive(ProjectNO, ArchiveID);
        }
        /// <summary>
        /// 根据电子文件表取得 电子文件的案卷ID和文件登记表的所有信息
        /// </summary>
        /// <returns></returns>
        public DataSet GetListFile(string ProjectNO, string ArchiveID)
        {
            BLL.BLLMore bllMore = new ERM.BLL.BLLMore();
            return bllMore.GetListFile(ProjectNO, ArchiveID);
        }
    }
}
