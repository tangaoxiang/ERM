/*
 作者　张建宏
 日期  2008-12-24
 功能　工程信息　项目信息　单位组织信息　写入哈希表中
 */
using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Collections;
using System.Data;
using System.Windows.Forms;
using System.IO;
using Digi.DBUtility;
using System.Text.RegularExpressions;
using ERM.MDL;
using System.Reflection;
using ERM.BLL;
namespace ERM.UI
{
    public class ProjectItemUnits
    {
        private string _openedProjectNo = "";
        private ERM.BLL.T_Projects_BLL projectsData = new ERM.BLL.T_Projects_BLL();
        private ERM.BLL.T_Units_BLL unitData = new ERM.BLL.T_Units_BLL();
        private ERM.BLL.T_Item_BLL itemData = new ERM.BLL.T_Item_BLL();
        private ERM.BLL.T_Project_Brige_BLL brigeData = new BLL.T_Project_Brige_BLL();
        private ERM.BLL.T_Project_RoadLamp_BLL roladLampData = new BLL.T_Project_RoadLamp_BLL();
        private ERM.BLL.T_Traffic_BLL trafficData = new BLL.T_Traffic_BLL();

        private Hashtable _projectDetail;
        public ProjectItemUnits(string openedProjectNo)
        {
            this._openedProjectNo = openedProjectNo;
            ERM.MDL.T_Projects projectInfo = projectsData.Find(_openedProjectNo);
            Hashtable projectDetail = new Hashtable();
            //2010-03-29 因为导入数据存在NULL的情况 加个判断
            projectDetail.Add("address", projectInfo.address == null ? "" : projectInfo.address);
            projectDetail.Add("area1", projectInfo.area1 == null ? "" : projectInfo.area1);
            projectDetail.Add("area2", projectInfo.area2 == null ? "" : projectInfo.area2);
            projectDetail.Add("district", projectInfo.district == null ? "" : projectInfo.district);
            projectDetail.Add("category", projectInfo.category == null ? "" : projectInfo.category);
            projectDetail.Add("begindate", (projectInfo.begindate == null || projectInfo.begindate == "") ? "" : DateTime.Parse(projectInfo.begindate).ToString("yyyy-MM-dd"));
            projectDetail.Add("bjdate", projectInfo.bjdate == null ? "" : projectInfo.bjdate);
            projectDetail.Add("enddate", (projectInfo.enddate == null || projectInfo.enddate == "") ? "" : DateTime.Parse(projectInfo.enddate).ToString("yyyy-MM-dd"));
            projectDetail.Add("floors1", projectInfo.floors1 == null ? "" : projectInfo.floors1);
            projectDetail.Add("floors2", projectInfo.floors2 == null ? "" : projectInfo.floors2);
            projectDetail.Add("ghcode", projectInfo.ghcode == null ? "" : projectInfo.ghcode);
            projectDetail.Add("passwd", projectInfo.passwd == null ? "" : projectInfo.passwd);
            projectDetail.Add("price1", projectInfo.price1 == null ? 0 : projectInfo.price1);
            projectDetail.Add("price2", projectInfo.price2 == null ? 0 : projectInfo.price2);
            projectDetail.Add("high", projectInfo.high == null ? "" : projectInfo.high);
            projectDetail.Add("projectname", projectInfo.projectname == null ? "" : projectInfo.projectname);
            projectDetail.Add("ProjectNO", projectInfo.ProjectNO == null ? "" : projectInfo.ProjectNO);
            projectDetail.Add("projecttype", projectInfo.projecttype == null ? "" : projectInfo.projecttype);
            projectDetail.Add("sgcode", projectInfo.sgcode == null ? "" : projectInfo.sgcode);
            projectDetail.Add("ydpzcode", projectInfo.ydpzcode == null ? "" : projectInfo.ydpzcode);
            projectDetail.Add("ydxkcode", projectInfo.ydxkcode == null ? "" : projectInfo.ydxkcode);
            projectDetail.Add("stru", projectInfo.stru == null ? "" : projectInfo.stru);
            projectDetail.Add("stru1", projectInfo.stru == null ? "" : getStruName(projectInfo.stru,"stru"));
            projectDetail.Add("tempid", projectInfo.tempid == null ? 0 : projectInfo.tempid);
            projectDetail.Add("hjqk", projectInfo.hjqk == null ? "" : projectInfo.hjqk);
            projectDetail.Add("zzmj", projectInfo.zzmj == null ? "" : projectInfo.zzmj);
            projectDetail.Add("bgyfmj", projectInfo.bgyfmj == null ? "" : projectInfo.bgyfmj);
            projectDetail.Add("syyfmj", projectInfo.syyfmj == null ? "" : projectInfo.syyfmj);
            projectDetail.Add("cfmj", projectInfo.cfmj == null ? "" : projectInfo.cfmj);
            projectDetail.Add("dxsmj", projectInfo.dxsmj == null ? "" : projectInfo.dxsmj);
            projectDetail.Add("qtyfmj", projectInfo.qtyfmj == null ? "" : projectInfo.qtyfmj);
            projectDetail.Add("ts1", projectInfo.ts1 == null ? "" : projectInfo.ts1);
            projectDetail.Add("ts2", projectInfo.ts2 == null ? "" : projectInfo.ts2);
            projectDetail.Add("ts3", projectInfo.ts3 == null ? "" : projectInfo.ts3);
            projectDetail.Add("ts4", projectInfo.ts4 == null ? "" : projectInfo.ts4);
            projectDetail.Add("ts5", projectInfo.ts5 == null ? "" : projectInfo.ts5);
            projectDetail.Add("tstotal", projectInfo.tstotal == null ? "" : projectInfo.tstotal);
            projectDetail.Add("zygz", projectInfo.zygz == null ? "" : projectInfo.zygz);
            projectDetail.Add("zjy", projectInfo.zjy == null ? "" : projectInfo.zjy);
            projectDetail.Add("sgbzz", projectInfo.sgbzz == null ? "" : projectInfo.sgbzz);
            projectDetail.Add("tbr", projectInfo.tbr == null ? "" : projectInfo.tbr);
            projectDetail.Add("jsdwshr", projectInfo.jsdwshr == null ? "" : projectInfo.jsdwshr);
            projectDetail.Add("jldwshr", projectInfo.jldwshr == null ? "" : projectInfo.jldwshr);
            projectDetail.Add("createdate", projectInfo.createdate == null ? "" : projectInfo.createdate);
            projectDetail.Add("ajdh", projectInfo.ajdh == null ? "" : projectInfo.ajdh);
            projectDetail.Add("kzsfcd", projectInfo.kzsfcd == null ? "" : projectInfo.kzsfcd);
            projectDetail.Add("ztcw", projectInfo.ztcw == null ? "" : projectInfo.ztcw);
            projectDetail.Add("dstcw", projectInfo.dstcw == null ? "" : projectInfo.dstcw);
            projectDetail.Add("dxtcw", projectInfo.dxtcw == null ? "" : projectInfo.dxtcw);
            projectDetail.Add("yjdw", projectInfo.yjdw == null ? "" : projectInfo.yjdw);
            projectDetail.Add("xmjl", projectInfo.XMJL == null ? "" : projectInfo.XMJL);
            projectDetail.Add("xcjl", projectInfo.XCJL == null ? "" : projectInfo.XCJL);
            DataView dv;
            MDL.T_Units mdl_unit = new ERM.MDL.T_Units();
            mdl_unit.ProjectNO = this._openedProjectNo;
            mdl_unit.unittype = "unit1";
            //dv = unitData.GetList("ProjectNO='" + this._openedProjectNo + "' and unittype='unit1'").Tables[0].DefaultView;
            dv = unitData.GetList(mdl_unit).Tables[0].DefaultView;
            
            if (dv.Count <= 1)
            {
                if (dv.Count == 0)
                {
                    projectDetail.Add("jsdw_mc", "");
                    projectDetail.Add("jsdw_xmfzr", "");
                    projectDetail.Add("jsdw_xmzyjsfzr", "");
                }
                else
                {
                    projectDetail.Add("jsdw_mc", dv[0]["dwmc"].ToString());
                    projectDetail.Add("jsdw_xmfzr", dv[0]["fzr"].ToString());
                    projectDetail.Add("jsdw_xmzyjsfzr", dv[0]["zlfzr"].ToString());
                }
            }
            else
            {
                string[] jsdwmc = new string[dv.Count];  //单位名称
                string[] jsdwxmfzr = new string[dv.Count]; //项目负责人
                for (int i = 0; i < dv.Count; i++)
                {
                    jsdwmc[i] = dv[i]["dwmc"].ToString();
                    jsdwxmfzr[i] = dv[i]["fzr"].ToString();
                }
                projectDetail.Add("jsdw_mc", jsdwmc);
                projectDetail.Add("jsdw_xmfzr", jsdwxmfzr);
            }
            //dv = unitData.GetList("ProjectNO='" + this._openedProjectNo + "' and unittype='unit2'").Tables[0].DefaultView;
            mdl_unit.unittype = "unit2";
            dv = unitData.GetList(mdl_unit).Tables[0].DefaultView;
            if (dv.Count <= 1)
            {
                if (dv.Count == 0)
                {
                    projectDetail.Add("kcdw_mc", "");
                    projectDetail.Add("kcdw_xmfzr", "");
                    projectDetail.Add("kcdw_jsfzr", "");
                }
                else
                {
                    projectDetail.Add("kcdw_mc", dv[0]["dwmc"].ToString());
                    projectDetail.Add("kcdw_xmfzr", dv[0]["fzr"].ToString());
                    projectDetail.Add("kcdw_jsfzr", dv[0]["xmjl"].ToString());
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
                    kcdwjsfzr[i] = dv[i]["xmjl"].ToString();
                }
                projectDetail.Add("kcdw_mc", kcdwmc);
                projectDetail.Add("kcdw_xmfzr", kcdwxmfzr);
                projectDetail.Add("kcdw_jsfzr", kcdwjsfzr);
            }

            mdl_unit.unittype = "unit15";
            dv = unitData.GetList(mdl_unit).Tables[0].DefaultView;
            if (dv.Count <= 1)
            {
                if (dv.Count == 0)
                {
                    projectDetail.Add("pzdw_mc", "");
                    projectDetail.Add("pzdw_xmfzr", "");
                    projectDetail.Add("pzdw_jsfzr", "");
                }
                else
                {
                    projectDetail.Add("pzdw_mc", dv[0]["dwmc"].ToString());
                    projectDetail.Add("pzdw_xmfzr", dv[0]["fzr"].ToString());
                    projectDetail.Add("pzdw_jsfzr", dv[0]["xmjl"].ToString());
                }
            }
            else
            {
                string[] pzdwmc = new string[dv.Count];  //单位名称
                string[] pzdwxmfzr = new string[dv.Count]; //项目负责人
                string[] pzdwjsfzr = new string[dv.Count]; //技术负责人
                for (int i = 0; i < dv.Count; i++)
                {
                    pzdwmc[i] = dv[i]["dwmc"].ToString();
                    pzdwxmfzr[i] = dv[i]["fzr"].ToString();
                    pzdwjsfzr[i] = dv[i]["xmjl"].ToString();
                }
                projectDetail.Add("kcdw_mc", pzdwmc);
                projectDetail.Add("kcdw_xmfzr", pzdwxmfzr);
                projectDetail.Add("kcdw_jsfzr", pzdwjsfzr);
            }
            //dv = unitData.GetList("ProjectNO='" + this._openedProjectNo + "' and unittype='unit3'").Tables[0].DefaultView;
            mdl_unit.unittype = "unit3";
            dv = unitData.GetList(mdl_unit).Tables[0].DefaultView;
            if (dv.Count <= 1)
            {
                if (dv.Count == 0)
                {
                    projectDetail.Add("sjdw_mc", "");
                    projectDetail.Add("sjdw_xmfzr", "");
                    projectDetail.Add("sjdw_jsfzr", "");
                }
                else
                {
                    projectDetail.Add("sjdw_mc", dv[0]["dwmc"].ToString());
                    projectDetail.Add("sjdw_xmfzr", dv[0]["fzr"].ToString());
                    projectDetail.Add("sjdw_jsfzr", dv[0]["xmjl"].ToString());
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
                    sjdwjsfzr[i] = dv[i]["xmjl"].ToString();
                }
                projectDetail.Add("sjdw_mc", sjdwmc);
                projectDetail.Add("sjdw_xmfzr", sjdwxmfzr);
                projectDetail.Add("sjdw_jsfzr", sjdwjsfzr);
            }
            //dv = unitData.GetList("ProjectNO='" + this._openedProjectNo + "' and unittype='unit4'").Tables[0].DefaultView;
            mdl_unit.unittype = "unit4";
            dv = unitData.GetList(mdl_unit).Tables[0].DefaultView;
            if (dv.Count <= 1)
            {
                if (dv.Count == 0)
                {
                    projectDetail.Add("sgdw_mc", "");
                    projectDetail.Add("sgdw_xmfzr", "");
                    projectDetail.Add("sgdw_jsfzr", "");
                    projectDetail.Add("sgdw_xmzyzljcy", "");
                    projectDetail.Add("sgdw_zlfzr", "");
                    projectDetail.Add("sgdw_jccsfzr", "");
                    projectDetail.Add("sgdw_syxfzr", "");
                    projectDetail.Add("sgdw_tsfzr", "");
                }
                else
                {
                    projectDetail.Add("sgdw_mc", dv[0]["dwmc"].ToString());
                    projectDetail.Add("sgdw_xmfzr", dv[0]["xmjl"].ToString());
                    projectDetail.Add("sgdw_jsfzr", dv[0]["dwmc"].ToString());
                    projectDetail.Add("sgdw_xmzyzljcy", dv[0]["xmzyzljcy"].ToString());
                    projectDetail.Add("sgdw_zlfzr", dv[0]["zlfzr"].ToString());
                    projectDetail.Add("sgdw_jccsfzr", dv[0]["jccsfzr"].ToString());
                    projectDetail.Add("sgdw_syxfzr", dv[0]["syxfzr"].ToString());
                    projectDetail.Add("sgdw_tsfzr", dv[0]["tsfzr"].ToString());
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
                    sgdwjsfzr[i] = dv[i]["dwmc"].ToString();
                }
                projectDetail.Add("sgdw_mc", sgdwmc);
                projectDetail.Add("sgdw_xmfzr", sgdwxmfzr);
                projectDetail.Add("sgdw_jsfzr", sgdwjsfzr);
            }
            //dv = unitData.GetList("ProjectNO='" + this._openedProjectNo + "' and unittype='unit5'").Tables[0].DefaultView;
            mdl_unit.unittype = "unit5";
            dv = unitData.GetList(mdl_unit).Tables[0].DefaultView;
            if (dv.Count <= 1)
            {
                if (dv.Count == 0)
                {
                    projectDetail.Add("sgtdw_mc", "");
                    projectDetail.Add("sgtdw_xmfzr", "");
                }
                else
                {
                    projectDetail.Add("sgtdw_mc", dv[0]["dwmc"].ToString());
                    projectDetail.Add("sgtdw_xmfzr", dv[0]["fzr"].ToString());
                }
            }
            else
            {
                string[] sgtdwmc = new string[dv.Count];  //单位名称
                string[] sgtdwxmfzr = new string[dv.Count]; //项目负责人
                for (int i = 0; i < dv.Count; i++)
                {
                    sgtdwmc[i] = dv[i]["dwmc"].ToString();
                    sgtdwxmfzr[i] = dv[i]["fzr"].ToString();
                }
                projectDetail.Add("sgtdw_mc", sgtdwmc);
                projectDetail.Add("sgtdw_xmfzr", sgtdwxmfzr);
            }
            //dv = unitData.GetList("ProjectNO='" + this._openedProjectNo + "' and unittype='unit6'").Tables[0].DefaultView;
            mdl_unit.unittype = "unit6";
            dv = unitData.GetList(mdl_unit).Tables[0].DefaultView;
            if (dv.Count <= 1)
            {
                if (dv.Count == 0)
                {
                    projectDetail.Add("jldw_mc", "");
                    projectDetail.Add("jldw_jlgcs", "");
                    projectDetail.Add("jldw_zjlgcs", "");
                }
                else
                {
                    projectDetail.Add("jldw_mc", dv[0]["dwmc"].ToString());
                    projectDetail.Add("jldw_xmfzr", dv[0]["fzr"].ToString());
                    projectDetail.Add("jldw_xmzj", dv[0]["xmjl"].ToString());
                    projectDetail.Add("jldw_xcjl", dv[0]["xcjl"].ToString());
                }
            }
            else
            {
                string[] jldwmc = new string[dv.Count];  //单位名称
                string[] jldwxmfzr = new string[dv.Count]; //项目负责人
                string[] jldwxmzj = new string[dv.Count]; //项目总监
                string[] jldwxcjl = new string[dv.Count]; //现场监理
                for (int i = 0; i < dv.Count; i++)
                {
                    jldwmc[i] = dv[i]["dwmc"].ToString();
                    jldwxmfzr[i] = dv[i]["fzr"].ToString();
                    jldwxmzj[i] = dv[i]["xmjl"].ToString();
                    jldwxcjl[i] = dv[i]["xcjl"].ToString();
                }
                projectDetail.Add("jldw_mc", jldwmc);
                projectDetail.Add("jldw_xmfzr", jldwxmfzr);
                projectDetail.Add("jldw_xmzj", jldwxmzj);
                projectDetail.Add("jldw_xcjl", jldwxmzj);
            }
            //dv = unitData.GetList("ProjectNO='" + this._openedProjectNo + "' and unittype='unit7'").Tables[0].DefaultView;
            mdl_unit.unittype = "unit7";
            dv = unitData.GetList(mdl_unit).Tables[0].DefaultView;
            if (dv.Count <= 1)
            {
                if (dv.Count == 0)
                {
                    projectDetail.Add("jddw_mc", "");
                    projectDetail.Add("jddw_jdy", "");
                }
                else
                {
                    projectDetail.Add("jddw_mc", dv[0]["dwmc"].ToString());
                    projectDetail.Add("jddw_jdy", dv[0]["fzr"].ToString());
                }
            }
            else
            {
                string[] jddwmc = new string[dv.Count];  //单位名称
                string[] jddwjdy = new string[dv.Count]; //监督员
                for (int i = 0; i < dv.Count; i++)
                {
                    jddwmc[i] = dv[i]["dwmc"].ToString();
                    jddwjdy[i] = dv[i]["fzr"].ToString();
                }
                projectDetail.Add("jddw_mc", jddwmc);
                projectDetail.Add("jddw_jdy", jddwjdy);
            }
            //dv = unitData.GetList("ProjectNO='" + this._openedProjectNo + "' and unittype='unit8'").Tables[0].DefaultView;
            mdl_unit.unittype = "unit8";
            dv = unitData.GetList(mdl_unit).Tables[0].DefaultView;
            if (dv.Count <= 1)
            {
                if (dv.Count == 0)
                {
                    projectDetail.Add("fbdw_mc", "");
                    projectDetail.Add("fbdw_xmfzr", "");
                    projectDetail.Add("fbdw_jsfzr", "");
                }
                else
                {
                    projectDetail.Add("fbdw_mc", dv[0]["dwmc"].ToString());
                    projectDetail.Add("fbdw_xmfzr", dv[0]["xmjl"].ToString());
                    projectDetail.Add("fbdw_jsfzr", dv[0]["fzr"].ToString());
                }
            }
            else
            {
                string[] fbdwmc = new string[dv.Count];  //单位名称
                string[] fbdwjsfzr = new string[dv.Count]; //技术负责人
                string[] fbdwxmjl = new string[dv.Count]; //项目经理
                for (int i = 0; i < dv.Count; i++)
                {
                    fbdwmc[i] = dv[i]["dwmc"].ToString();
                    fbdwjsfzr[i] = dv[i]["fzr"].ToString();
                    fbdwxmjl[i] = dv[i]["xmjl"].ToString();
                }
                projectDetail.Add("fbdw_mc", fbdwmc);
                projectDetail.Add("fbdw_xmfzr", fbdwxmjl);
                projectDetail.Add("fbdw_jsfzr", fbdwjsfzr);
            }
            //dv = unitData.GetList("ProjectNO='" + this._openedProjectNo + "' and unittype='unit9'").Tables[0].DefaultView;
            mdl_unit.unittype = "unit9";
            dv = unitData.GetList(mdl_unit).Tables[0].DefaultView;
            if (dv.Count <= 1)
            {
                if (dv.Count == 0)
                {
                    projectDetail.Add("zcbdw_mc", "");
                    projectDetail.Add("zcbdw_xmfzr", "");
                    projectDetail.Add("zcbdw_fzr", "");
                    projectDetail.Add("zcbdw_xmzyzljcy", "");
                    projectDetail.Add("zcbdw_zlfzr", "");
                }
                else
                {
                    projectDetail.Add("zcbdw_mc", dv[0]["dwmc"].ToString());
                    projectDetail.Add("zcbdw_xmfzr", dv[0]["xmjl"].ToString());
                    projectDetail.Add("zcbdw_fzr", dv[0]["fzr"].ToString());
                    projectDetail.Add("zcbdw_xmzyzljcy", dv[0]["xmzyzljcy"].ToString());
                    projectDetail.Add("zcbdw_zlfzr", dv[0]["zlfzr"].ToString());
                }
            }
            else
            {
                string[] zcbdwmc = new string[dv.Count];  //单位名称
                string[] zcbdwfzr = new string[dv.Count]; //总承包负责人
                string[] zcbdwxmjl = new string[dv.Count]; //项目经理
                for (int i = 0; i < dv.Count; i++)
                {
                    zcbdwmc[i] = dv[i]["dwmc"].ToString();
                    zcbdwfzr[i] = dv[i]["fzr"].ToString();
                    zcbdwxmjl[i] = dv[i]["xmjl"].ToString();
                }
                projectDetail.Add("zcbdw_mc", zcbdwmc);
                projectDetail.Add("zcbdw_xmfzr", zcbdwxmjl);
                projectDetail.Add("zcbdw_fzr", zcbdwfzr);
            }
            //dv = unitData.GetList("ProjectNO='" + this._openedProjectNo + "' and unittype='unit10'").Tables[0].DefaultView;
            mdl_unit.unittype = "unit10";
            dv = unitData.GetList(mdl_unit).Tables[0].DefaultView;
            if (dv.Count <= 1)
            {
                if (dv.Count == 0)
                {
                    projectDetail.Add("azdw_mc", "");
                    projectDetail.Add("azdw_xmfzr", "");
                    projectDetail.Add("azdw_azfzr", "");
                }
                else
                {
                    projectDetail.Add("azdw_mc", dv[0]["dwmc"].ToString());
                    projectDetail.Add("azdw_xmfzr", dv[0]["xmjl"].ToString());
                    projectDetail.Add("azdw_azfzr", dv[0]["fzr"].ToString());
                }
            }
            else
            {
                string[] azdwmc = new string[dv.Count];  //单位名称
                string[] azdwazfzr = new string[dv.Count]; //安装负责人
                string[] azdwxmjl = new string[dv.Count]; //项目经理
                for (int i = 0; i < dv.Count; i++)
                {
                    azdwmc[i] = dv[i]["dwmc"].ToString();
                    azdwazfzr[i] = dv[i]["fzr"].ToString();
                    azdwxmjl[i] = dv[i]["xmjl"].ToString();
                }
                projectDetail.Add("azdw_mc", azdwmc);
                projectDetail.Add("azdw_xmfzr", azdwxmjl);
                projectDetail.Add("azdw_azfzr", azdwazfzr);
            }
            mdl_unit.unittype = "unit14";
            dv = unitData.GetList(mdl_unit).Tables[0].DefaultView;
            if (dv.Count <= 1)
            {
                if (dv.Count == 0)
                {
                    projectDetail.Add("cldw_mc", "");
                    projectDetail.Add("cldw_xmfzr", "");
                    projectDetail.Add("cldw_azfzr", "");
                }
                else
                {
                    projectDetail.Add("cldw_mc", dv[0]["dwmc"].ToString());
                    projectDetail.Add("cldw_xmfzr", dv[0]["xmjl"].ToString());
                    projectDetail.Add("cldw_azfzr", dv[0]["fzr"].ToString());
                }
            }
            else
            {
                string[] cldwmc = new string[dv.Count];  //单位名称
                string[] cldwazfzr = new string[dv.Count]; //安装负责人
                string[] cldwxmjl = new string[dv.Count]; //项目经理
                for (int i = 0; i < dv.Count; i++)
                {
                    cldwmc[i] = dv[i]["dwmc"].ToString();
                    cldwazfzr[i] = dv[i]["fzr"].ToString();
                    cldwxmjl[i] = dv[i]["xmjl"].ToString();
                }
                projectDetail.Add("azdw_mc", cldwmc);
                projectDetail.Add("azdw_xmfzr", cldwxmjl);
                projectDetail.Add("azdw_azfzr", cldwazfzr);
            }

            ///项目信息
            ERM.MDL.T_Item ItemInfo = itemData.Find(projectInfo.ItemID);
            projectDetail.Add("YdghxkCode", ItemInfo.YdghxkCode == null ? "" : ItemInfo.YdghxkCode);
            projectDetail.Add("TlsyCode", ItemInfo.TlsyCode == null ? "" : ItemInfo.TlsyCode);
            projectDetail.Add("Tlcrnx", ItemInfo.Tlcrnx == null ? "" : ItemInfo.Tlcrnx);
            projectDetail.Add("ItemID", ItemInfo.ItemID == null ? "" : ItemInfo.ItemID);//ID
            projectDetail.Add("constructionprojectname",
                ItemInfo.ConStructionProjectName == null ? "" : ItemInfo.ConStructionProjectName);//项目名称
            projectDetail.Add("respective",
                ItemInfo.Respective == null ? "" : ItemInfo.Respective);//区域
            projectDetail.Add("constructionprojectadd",
                ItemInfo.ConstructionProjectAdd == null ? "" : ItemInfo.ConstructionProjectAdd);//项目地址
            projectDetail.Add("projecttype_item",
                ItemInfo.ProjectType == null ? "" : ItemInfo.ProjectType);//建筑性质
            projectDetail.Add("usesoiareasum",
                ItemInfo.UseSoiAreaSum == null ? "" : ItemInfo.UseSoiAreaSum);//总用地面积
            projectDetail.Add("constructionareasum",
                ItemInfo.ConstructionAreaSum == null ? "" : ItemInfo.ConstructionAreaSum);//总建筑面积
            projectDetail.Add("constructionscale",
                ItemInfo.ConstructionScale == null ? "" : ItemInfo.ConstructionScale);
            projectDetail.Add("projectcost",
                ItemInfo.ProjectCost == null ? "" : ItemInfo.ProjectCost);//总结算
            projectDetail.Add("projectsettlement",
                ItemInfo.ProjectSettlement == null ? "" : ItemInfo.ProjectSettlement);//总预算
            projectDetail.Add("usesoitype",
                ItemInfo.UseSoiType == null ? "" : ItemInfo.UseSoiType);
            projectDetail.Add("collectiontype",
                ItemInfo.CollectionType == null ? "" : ItemInfo.CollectionType);
            projectDetail.Add("originalsoitype",
                ItemInfo.OriginalSoiType == null ? "" : ItemInfo.OriginalSoiType);
            projectDetail.Add("usesoiarea", ItemInfo.UseSoiArea == null ? "" : ItemInfo.UseSoiArea);
            projectDetail.Add("startdate", ItemInfo.StartDate == null ? "" : ItemInfo.StartDate);
            projectDetail.Add("finishdate", ItemInfo.FinishDate == null ? "" : ItemInfo.FinishDate);
            projectDetail.Add("approvedate", ItemInfo.Approvedate == null ? "" : ItemInfo.Approvedate);
            projectDetail.Add("createunit", ItemInfo.CreateUnit == null ? "" : ItemInfo.CreateUnit);//建设单位
            projectDetail.Add("itemfzr", ItemInfo.ItemFzr == null ? "" : ItemInfo.ItemFzr);//项目负责人
            projectDetail.Add("allcost", ItemInfo.AllCost == null ? "" : ItemInfo.AllCost);//总地价
            projectDetail.Add("volumefar", ItemInfo.VolumeFar == null ? "" : ItemInfo.VolumeFar);//容积率
            projectDetail.Add("greenfar", ItemInfo.GreenFar == null ? "" : ItemInfo.GreenFar);//绿化率
            projectDetail.Add("buildingdensity", ItemInfo.BuildingDensity == null ? "" : ItemInfo.BuildingDensity);
            projectDetail.Add("ds", ItemInfo.ds == null ? "" : ItemInfo.ds);
            projectDetail.Add("pzdw", ItemInfo.pzdw == null ? "" : ItemInfo.pzdw);
            projectDetail.Add("pzh", ItemInfo.pzh == null ? "" : ItemInfo.pzh);
            projectDetail.Add("xmh", ItemInfo.XmCode == null ? "" : ItemInfo.XmCode);
            #region add
           // projectDetail.Add("zcd", ItemInfo.zcd == null ? "" : ItemInfo.zcd);
            projectDetail.Add("start_x", projectInfo.Start_X == null ? "" : projectInfo.Start_X);
            projectDetail.Add("start_y", projectInfo.Start_X == null ? "" : projectInfo.Start_X);
            projectDetail.Add("end_x", projectInfo.End_X == null ? "" : projectInfo.End_X);
            projectDetail.Add("end_y", projectInfo.End_Y == null ? "" : projectInfo.End_Y);
            projectDetail.Add("shr", projectInfo.shr == null ? "" : projectInfo.shr);
            projectDetail.Add("zlr", projectInfo.zlr == null ? "" : projectInfo.zlr);
            projectDetail.Add("zlrq", projectInfo.zlrq == null ? "" : projectInfo.zlrq);

            #region brige
            if (projectInfo.ProjectCategory.ToLower() == "brige")
            {
                T_Project_Brige brige = brigeData.QueryBrige_ByProjID(this._openedProjectNo);
                projectDetail.Add("acjgxs", brige.ACJGXS == null ? "" : brige.ACJGXS);
                projectDetail.Add("dz", brige.DZ == null ? "" : brige.DZ);
                projectDetail.Add("jcxs", brige.JCXS == null ? "" : brige.JCXS);
                projectDetail.Add("jk", brige.JK == null ? "" : brige.JK);
                projectDetail.Add("kj", brige.KJ == null ? "" : brige.KJ);
                projectDetail.Add("level", brige.Level == null ? "" : brige.Level);
                projectDetail.Add("longs", brige.Longs == null ? "" : brige.Longs);
                projectDetail.Add("mcxs", brige.MCXS == null ? "" : brige.MCXS);
                projectDetail.Add("projectid", brige.ProjectID == null ? "" : brige.ProjectID);
                projectDetail.Add("remark", brige.Remark == null ? "" : brige.Remark);
                projectDetail.Add("sbgz", brige.SBGZ == null ? "" : brige.SBGZ);
                projectDetail.Add("ssf", brige.SSF == null ? "" : brige.SSF);
                projectDetail.Add("sturucttype", brige.StuructType == null ? "" : brige.StuructType);
                projectDetail.Add("sturucttype1", brige.StuructType == null ? "" : getStruName(brige.StuructType,"stru_brige"));
                projectDetail.Add("width", brige.Width == null ? "" : brige.Width);
                projectDetail.Add("xbgz", brige.XBGZ == null ? "" : brige.XBGZ);
                projectDetail.Add("hz", brige.HZ == null ? "" : brige.HZ);
                projectDetail.Add("gcys", brige.GCYS == null ? "" : brige.GCYS);
                projectDetail.Add("gcjs", brige.GCJS == null ? "" : brige.GCJS);
                projectDetail.Add("brige_zcd", brige.ZCD == null ? "" : brige.ZCD);
                projectDetail.Add("lb", brige.LB == null ? "" : brige.LB);
                projectDetail.Add("brige_hjqk", brige.HJQK == null ? "" : brige.HJQK);
                projectDetail.Add("brige_gczl", brige.GCZL == null ? "" : brige.GCZL);
                projectDetail.Add("kz", brige.KZ == null ? "" : brige.KZ);
            }

            #endregion

            #region roadLamp
           
            if (projectInfo.ProjectCategory.ToLower() == "roadlamp")
            {
                T_Project_RoadLamp roadLamp = roladLampData.QueryRoadLamp_ByProjID(this._openedProjectNo);
                projectDetail.Add("dggd", roadLamp.DGGD == null ? "" : roadLamp.DGGD);
                projectDetail.Add("dgjjl", roadLamp.DGJJL == null ? "" : roadLamp.DGJJL);
                projectDetail.Add("dgzs", roadLamp.DGZS == null ? "" : roadLamp.DGZS);
                projectDetail.Add("djbc", roadLamp.DJBC == null ? "" : roadLamp.DJBC);
                projectDetail.Add("djzl", roadLamp.DJZL == null ? "" : roadLamp.DJZL);
                projectDetail.Add("dlcd", roadLamp.DLCD == null ? "" : roadLamp.DLCD);
                projectDetail.Add("dlgg", roadLamp.DLGG == null ? "" : roadLamp.DLGG);
                projectDetail.Add("ggdgd", roadLamp.GGDGD == null ? "" : roadLamp.GGDGD);
                projectDetail.Add("ggds", roadLamp.GGDS == null ? "" : roadLamp.GGDS);
                projectDetail.Add("gl", roadLamp.GL == null ? "" : roadLamp.GL);
                projectDetail.Add("gylx", roadLamp.GYLX == null ? "" : roadLamp.GYLX);
                projectDetail.Add("jxj", roadLamp.JXJ == null ? "" : roadLamp.JXJ);
                projectDetail.Add("ldxs_mt", roadLamp.LDXS_MT == null ? "" : roadLamp.LDXS_MT);
                projectDetail.Add("ldxs_st", roadLamp.LDXS_ST == null ? "" : roadLamp.LDXS_ST);
                projectDetail.Add("remark", roadLamp.Remark == null ? "" : roadLamp.Remark);
                projectDetail.Add("xbxh", roadLamp.XBXH == null ? "" : roadLamp.XBXH);
                projectDetail.Add("gcys", roadLamp.GCYS);
                projectDetail.Add("gcjs", roadLamp.GCJS);
                projectDetail.Add("dlmj", roadLamp.DLMJ);
                projectDetail.Add("dldj", roadLamp.DLDJ);
                projectDetail.Add("road_lk", roadLamp.LK);
                projectDetail.Add("road_zl", roadLamp.ZL == null ? "" : roadLamp.ZL);
                projectDetail.Add("road_zd", roadLamp.ZD == null ? "" : roadLamp.ZD);
                projectDetail.Add("road_gcqd", roadLamp.GCQD == null ? "" : roadLamp.GCQD);
                projectDetail.Add("road_gczd", roadLamp.GCZD == null ? "" : roadLamp.GCZD);
                projectDetail.Add("road_zcd", roadLamp.ZCD);
                projectDetail.Add("roadlamp_hjqk", roadLamp.HJQK == null ? "" :roadLamp.HJQK);
                projectDetail.Add("dlzcd",roadLamp.DLZCD);
            }
            #endregion

            #region traffic
            
            if (projectInfo.ProjectCategory.ToLower() == "traffic")
            {
                T_Traffic traffic = trafficData.QueryTraffic_ByProjID(this._openedProjectNo);
                projectDetail.Add("hz", traffic.HZ == null ? "" : traffic.HZ);
                projectDetail.Add("jcxs", traffic.JCXS == null ? "" : traffic.JCXS);
                projectDetail.Add("kj", traffic.KJ == null ? "" : traffic.KJ);
                projectDetail.Add("ks", traffic.KS == null ? "" : traffic.KS);
                projectDetail.Add("longcount", traffic.LongCount == null ? "" : traffic.LongCount);
                projectDetail.Add("mcxs", traffic.MCXS == null ? "" : traffic.MCXS);
                projectDetail.Add("pwdj", traffic.PWDJ == null ? "" : traffic.PWDJ);
                projectDetail.Add("remark", traffic.Remark == null ? "" : traffic.Remark);
                projectDetail.Add("road_level", traffic.Road_Level == null ? "" : traffic.Road_Level);
                projectDetail.Add("width", traffic.Width == null ? "" : traffic.Width);
                projectDetail.Add("zpws", traffic.ZPWS == null ? "" : traffic.ZPWS);
                projectDetail.Add("gcys", traffic.GCYS == null ? "" : traffic.GCYS);
                projectDetail.Add("gcjs", traffic.GCJS == null ? "" : traffic.GCJS);
                projectDetail.Add("startx", traffic.STARTX == null ? "" : traffic.STARTX);
                projectDetail.Add("starty", traffic.STARTY == null ? "" : traffic.STARTY);
                projectDetail.Add("endx", traffic.ENDX == null ? "" : traffic.ENDX);
                projectDetail.Add("traffic_zl", traffic.ZL == null ? "" : traffic.ZL);
                projectDetail.Add("traffic_cz", traffic.CZ == null ? "" : traffic.CZ);
                projectDetail.Add("endy", traffic.ENDY == null ? "" : traffic.ENDY);
                projectDetail.Add("traffic_sgyl", traffic.SGYL == null ? "" : traffic.SGYL);
                projectDetail.Add("traffic_hjqk", traffic.HJQK == null ? "" : traffic.HJQK);
                projectDetail.Add("traffic_gg", traffic.GG == null ? "" : traffic.GG);
                projectDetail.Add("traffic_cd", traffic.CD == null ? 0 : Convert.ToInt32(traffic.CD));
                IList<T_Traffic_Detail> detailList = new BLL.T_Traffic_Detail_BLL().QueryTraffic_ByProjID(traffic.ID);
                ERM.BLL.T_Dict_BLL dicData = new ERM.BLL.T_Dict_BLL();
                IList<T_Dict> dictList = dicData.FindByKeyWord("TrafficType");
                PropertyInfo[] properties = typeof(T_Traffic_Detail).GetProperties();

                foreach (var item in detailList)
                {
                    foreach (var dic in dictList)
                    {
                        if (dic.ValueName == item.Types)
                        {
                            for (int i = 0; i < properties.Length; i++)
                            {
                                string propertyID = properties[i].Name;

                                PropertyInfo pinfo = typeof(T_Traffic_Detail).GetProperty(propertyID);
                                string val = pinfo.GetValue(item, null) == null ? "" : pinfo.GetValue(item, null).ToString();

                                if (!string.IsNullOrEmpty(val))
                                {
                                    string key = item.Types.ToLower() + "_" + propertyID.ToLower();
                                    if (!projectDetail.ContainsKey(key))
                                    {
                                        projectDetail.Add(key, val); 
                                    }  
                                }
                            }
                        }
                    }
                }
            }
            #endregion
            #endregion

            this._projectDetail = projectDetail;
        }//构造函数完成
        /// <summary>
        /// 获取工程所有信息，在表头填充时用
        /// </summary>
        public Hashtable ProjectDetail
        {
            get { return _projectDetail; }
        }

        /// <summary>
        /// 根据字典值获取字典名称
        /// </summary>
        /// <param name="value"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        private string getStruName(string value,string key) {
            T_Dict_BLL dictBll = new T_Dict_BLL();
           IList<T_Dict> dict =  dictBll.FindByValueName(value);
           foreach (var item in dict)
           {
               if (item.KeyWord==key)
               {
                   return item.DisplayName;
               }
           }
           return "";
        }
    }//classEnd
}//namespaceend
