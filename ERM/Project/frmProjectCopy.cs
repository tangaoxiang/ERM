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
    /// <summary>
    /// 工程复制
    /// </summary>
    public partial class frmProjectCopy : ERM.UI.Controls.Skin_DevEX
    {
        #region 参数初始化
        bool status_flg = false;
        T_Projects_BLL projectBLL = new T_Projects_BLL();
        #endregion

        #region 窗体函数
        public frmProjectCopy()
        {
            InitializeComponent();
        }
        private void frmProjectCopy_Load(object sender, EventArgs e)
        {
            BindGridViewData();
        }
        /// <summary>
        /// 取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Colse_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// 复制
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Click(object sender, EventArgs e)
        {
            frm2PDFProgressMsg fmessage = new frm2PDFProgressMsg();
            fmessage.Text = "工程复制中...";
            try
            {
                string sourceNO = string.Empty;
                string sourceName = string.Empty;
                string targeNO = string.Empty;
                string targeName = string.Empty;
                T_Projects sourcePorj;
                T_Projects targePorj;

                (cbx_Source.SelectedItem as System.Data.DataRowView)[0].ToString();

                if (cbx_Source.Items.Count == 1 || cbx_Trage.Items.Count == 1)
                {
                    TXMessageBoxExtensions.Info("提示：请选择需要复制的工程！");
                    cbx_Source.Focus();
                    return;
                }
                else if ((cbx_Source.SelectedItem as System.Data.DataRowView)[0].ToString() == "--请选择")
                {
                    TXMessageBoxExtensions.Info("提示：请选择复制的工程！");
                    cbx_Source.Focus();
                    return;
                }
                else if ((cbx_Trage.SelectedItem as System.Data.DataRowView)[0].ToString() == "--请选择")
                {
                    TXMessageBoxExtensions.Info("提示：请选择复制的目的工程！");
                    cbx_Trage.Focus();
                    return;
                }
                else
                {
                    sourceNO = (cbx_Source.SelectedItem as System.Data.DataRowView)[1].ToString();//要编辑的主键
                    sourceName = (cbx_Source.SelectedItem as System.Data.DataRowView)[0].ToString();//要编辑的主键
                    targeNO = (cbx_Trage.SelectedItem as System.Data.DataRowView)[1].ToString();//要编辑的主键
                    targeName = (cbx_Trage.SelectedItem as System.Data.DataRowView)[0].ToString();//要编辑的主键

                    //根据工程编号查询工程类别
                    sourcePorj = projectBLL.Find(sourceNO);
                    targePorj = projectBLL.Find(targeNO);
                    if (sourcePorj.ProjectCategory != targePorj.ProjectCategory)
                    {
                         TXMessageBoxExtensions.Info("复制的工程类别必须一致！");
                         return;
                    }
                    if (sourceNO == targeNO)
                    {
                        TXMessageBoxExtensions.Info("提示：同一工程不能复制！");
                        return;
                    }
                }
                if (TXMessageBoxExtensions.Question("提示：确定将工程\n编号：" + sourceNO + " 名称：" +
                    sourceName + "\n复制到工程\n编号：" + targeNO + " 名称：" + targeName
                    + "\n【温馨提示：复制之后工程信息将无法恢复！请慎重！！！】") == DialogResult.OK)
                {
                    status_flg = true;
                    btn_Copy.Enabled = false;
                    btn_Colse.Enabled = false;

                    fmessage = new frm2PDFProgressMsg();
                    fmessage.Text = "工程复制中...";
                    fmessage.progressBar1.Maximum = 4;

                    fmessage.label2.Text = "正在删除工程编号：" + targeNO + "信息...";
                    fmessage.progressBar1.Value = 1;
                    fmessage.Show();
                    Application.DoEvents();

                    //删除目的工程下信息
                    BLL.BLLMore bllMore = new BLL.BLLMore();
                    bllMore.DeleteUnitByProjectNO(targeNO);
                    bllMore.DeleteFileListByProjectNO(targeNO);
                    bllMore.DeleteCellFileByProjectNO(targeNO);
                    bllMore.DeleteArchiveByProjectNO(targeNO);
                    bllMore.DeleteGdFileByProjectNO(targeNO);//删除归档类别

                    #region add deleteProject
                    bllMore.DeleteTrafficByProjectNO(targeNO);
                    bllMore.DeleteRoadLampByProjectNO(targeNO);
                    bllMore.DeleteBrigeByProjectNO(targeNO);
                    bllMore.DeletePointByPorjectNo(targeNO);
                    #endregion

                    MyCommon.DeleteAndCreateEmptyDirectory(Globals.ProjectPathParent + targeNO);

                    //将源工程信息Copy到目的工程
                    fmessage.label2.Text = "正在更新工程编号：" + targeNO + "信息...";
                    fmessage.progressBar1.Value = 2;
                    Application.DoEvents();

                    BLL.T_Projects_BLL Proj_bll = new ERM.BLL.T_Projects_BLL();
                    ERM.MDL.T_Projects targe_proj_MDL = Proj_bll.Find(targeNO);
                    ERM.MDL.T_Projects source_proj_MDL = Proj_bll.Find(sourceNO);
                    targe_proj_MDL.address = source_proj_MDL.address;
                    targe_proj_MDL.area1 = source_proj_MDL.area1;
                    targe_proj_MDL.area2 = source_proj_MDL.area2;
                    targe_proj_MDL.begindate = source_proj_MDL.begindate;
                    targe_proj_MDL.bgyfmj = source_proj_MDL.bgyfmj;
                    targe_proj_MDL.bjdate = source_proj_MDL.bjdate;
                    targe_proj_MDL.category = source_proj_MDL.category;
                    targe_proj_MDL.cfmj = source_proj_MDL.cfmj;
                    targe_proj_MDL.createdate = source_proj_MDL.createdate;
                    targe_proj_MDL.district = source_proj_MDL.district;
                    targe_proj_MDL.dxsmj = source_proj_MDL.dxsmj;
                    targe_proj_MDL.enddate = source_proj_MDL.enddate;
                    targe_proj_MDL.floors1 = source_proj_MDL.floors1;
                    targe_proj_MDL.floors2 = source_proj_MDL.floors2;
                    targe_proj_MDL.ghcode = source_proj_MDL.ghcode;
                    targe_proj_MDL.high = source_proj_MDL.high;
                    targe_proj_MDL.hjqk = source_proj_MDL.hjqk;
                    targe_proj_MDL.jldwshr = source_proj_MDL.jldwshr;
                    targe_proj_MDL.jsdwshr = source_proj_MDL.jsdwshr;
                    targe_proj_MDL.passwd = source_proj_MDL.passwd;
                    targe_proj_MDL.price1 = source_proj_MDL.price1;
                    targe_proj_MDL.price2 = source_proj_MDL.price2;
                    targe_proj_MDL.projecttype = source_proj_MDL.projecttype;
                    targe_proj_MDL.qtyfmj = source_proj_MDL.qtyfmj;
                    targe_proj_MDL.sgbzz = source_proj_MDL.sgbzz;
                    targe_proj_MDL.sgcode = source_proj_MDL.sgcode;
                    targe_proj_MDL.stru = source_proj_MDL.stru;
                    targe_proj_MDL.syyfmj = source_proj_MDL.syyfmj;
                    targe_proj_MDL.tbr = source_proj_MDL.tbr;
                    targe_proj_MDL.tempid = source_proj_MDL.tempid;
                    targe_proj_MDL.ts1 = source_proj_MDL.ts1;
                    targe_proj_MDL.ts2 = source_proj_MDL.ts2;
                    targe_proj_MDL.ts3 = source_proj_MDL.ts3;
                    targe_proj_MDL.ts4 = source_proj_MDL.ts4;
                    targe_proj_MDL.tstotal = source_proj_MDL.tstotal;
                    targe_proj_MDL.ydpzcode = source_proj_MDL.ydpzcode;
                    targe_proj_MDL.ydxkcode = source_proj_MDL.ydxkcode;
                    targe_proj_MDL.zjy = source_proj_MDL.zjy;
                    targe_proj_MDL.zygz = source_proj_MDL.zygz;
                    targe_proj_MDL.zzmj = source_proj_MDL.zzmj;

                    targe_proj_MDL.ztcw = source_proj_MDL.ztcw;
                    targe_proj_MDL.dstcw = source_proj_MDL.dstcw;
                    targe_proj_MDL.dxtcw = source_proj_MDL.dxtcw;
                    targe_proj_MDL.kzsfcd = source_proj_MDL.kzsfcd;
                    targe_proj_MDL.ts5 = source_proj_MDL.ts5;
                    targe_proj_MDL.XMJL = source_proj_MDL.XMJL;
                    targe_proj_MDL.yjdw = source_proj_MDL.yjdw;
                    targe_proj_MDL.XCJL = source_proj_MDL.XCJL;

                    Proj_bll.Update(targe_proj_MDL);

                    //坐标信息
                    IList<T_Point> t_point_source = new T_Point_BLL().GetList(sourceNO);
                    foreach (var item in t_point_source)
                    {
                        item.ID = Guid.NewGuid().ToString();
                        item.ProjectNo = targeNO;
                        new T_Point_BLL().Insert(item);
                    }
                    
                    //电子文件
                    bllMore.CopyFileAndEFileList(sourceNO, targeNO);

                    BLL.T_Archive_BLL archive_bll = new ERM.BLL.T_Archive_BLL();//案卷信息
                    BLL.T_FileList_BLL filelist_bll = new ERM.BLL.T_FileList_BLL();//文件表
                    BLL.T_CellAndEFile_BLL cellAndEfile = new ERM.BLL.T_CellAndEFile_BLL();//电子文件
                    //单位
                    BLL.T_Units_BLL units_bll = new ERM.BLL.T_Units_BLL();//施工单位
                    IList<MDL.T_Units> IUnits = units_bll.FindByProjectNO(sourceNO);
                    if (IUnits != null && IUnits.Count > 0)
                    {
                        foreach (MDL.T_Units units in IUnits)
                        {
                            units.UnitID = Guid.NewGuid().ToString();
                            units.ProjectNO = targeNO;
                            units_bll.Add(units);//保存
                        }
                    }

                    //扩展信息
                    switch (sourcePorj.ProjectCategory)
                    {
                        case "Traffic":
                            T_Traffic_BLL trafficBll = new T_Traffic_BLL();
                            T_Traffic traffic = trafficBll.QueryTraffic_ByProjID(sourceNO);
                            if (traffic != null)
                            {
                                traffic.ID = Guid.NewGuid().ToString();
                                traffic.ProjectID = targeNO;
                                trafficBll.Insert(traffic);
                            }
                            break;
                        case "RoadLamp":
                            T_Project_RoadLamp_BLL roadLampBll = new T_Project_RoadLamp_BLL();
                            T_Project_RoadLamp roadLamp = roadLampBll.QueryRoadLamp_ByProjID(sourceNO);
                            if (roadLamp != null)
                            {
                                roadLamp.ProjectID = targeNO;
                                roadLamp.ID = Guid.NewGuid().ToString();
                                roadLampBll.Insert(roadLamp);
                            }
                            break;
                        case "Brige":
                            T_Project_Brige_BLL brigeBll = new T_Project_Brige_BLL();
                            T_Project_Brige brige = brigeBll.QueryBrige_ByProjID(sourceNO);
                            if (brige != null)
                            {
                                brige.ID = Guid.NewGuid().ToString();
                                brige.ProjectID = targeNO;
                                brigeBll.Insert(brige);
                            }
                            break;
                    }

                    fmessage.progressBar1.Value = 3;
                    Application.DoEvents();

                    //迁移文件夹
                    string mprojectPath = Application.StartupPath + "\\Project\\" + sourceNO;
                    string tprojectPath = Application.StartupPath + "\\Project\\" + targeNO;
                    string[] DirectoryList = new string[] { "MPDF", "ODOC", "PDF" };

                    if (System.IO.Directory.Exists(tprojectPath))
                    {
                        MyCommon.DeleteAndCreateEmptyDirectory(tprojectPath, false);
                        MyCommon.DeleteAndCreateEmptyDirectory(tprojectPath, true);
                    }
                    else
                    {
                        MyCommon.DeleteAndCreateEmptyDirectory(tprojectPath, true);
                    }
                    string tempText = fmessage.label2.Text;
                    char[] tempChar = tempText.ToCharArray();
                    int tempIndex = 0;
                    foreach (string dic in DirectoryList)
                    {
                        MyCommon.DeleteAndCreateEmptyDirectory(tprojectPath + "\\" + dic, true);
                        fmessage.label2.Text = "";
                        if (System.IO.Directory.Exists(mprojectPath))
                        {
                            if (System.IO.Directory.Exists(mprojectPath + "\\" + dic))
                            {
                                string[] files = System.IO.Directory.GetFiles(mprojectPath + "\\" + dic);
                                foreach (string filename in files)
                                {
                                    fmessage.label2.Text += tempChar[tempIndex];
                                    Application.DoEvents();
                                    tempIndex++;
                                    if (tempIndex >= tempChar.Length)
                                    {
                                        tempIndex = 0;
                                        fmessage.label2.Text = "";
                                    }
                                    System.IO.FileInfo fileinfo = new System.IO.FileInfo(filename);
                                    if (System.IO.File.Exists(filename))
                                    {
                                        System.IO.File.Copy(filename, tprojectPath + "\\" + dic + "\\" + fileinfo.Name, true);
                                    }
                                }
                            }
                        }
                    }

                    fmessage.progressBar1.Value = 4;
                    Application.DoEvents();
                    fmessage.Close();

                    btn_Copy.Enabled = true;
                    btn_Colse.Enabled = true;

                    TXMessageBoxExtensions.Info("提示：复制成功！");
                    BindGridViewData();
                }
            }
            catch (Exception ex)
            {
                if (fmessage != null)
                    fmessage.Close();
                TXMessageBoxExtensions.Info("提示：复制失败！");
                MyCommon.WriteLog("复制工程错误：" + ex.Message);
                btn_Copy.Enabled = true;
                btn_Colse.Enabled = true;
            }
        }
        #endregion

        #region 自定义函数
        /// <summary>
        /// 绑定所有工程方法
        /// </summary>
        /// <param name="SetStyle">是否设定表格样式</param>
        private void BindGridViewData()
        {

            ERM.BLL.T_Projects_BLL ProjectsDB = new ERM.BLL.T_Projects_BLL();
            IList<MDL.T_Projects> projList = ProjectsDB.GetAll();//绑定数据

            DataTable tbl_proj = new DataTable();
            tbl_proj.Columns.Add(new DataColumn("projectname", typeof(string)));
            tbl_proj.Columns.Add(new DataColumn("ProjectNO", typeof(string)));

            DataTable tbl_proj2 = new DataTable();
            tbl_proj2.Columns.Add(new DataColumn("projectname", typeof(string)));
            tbl_proj2.Columns.Add(new DataColumn("ProjectNO", typeof(string)));

            DataRow row_1 = tbl_proj.NewRow();
            row_1["projectname"] = "--请选择";
            row_1["ProjectNO"] = "--请选择";
            tbl_proj.Rows.Add(row_1);

            DataRow row_2 = tbl_proj2.NewRow();
            row_2["projectname"] = "--请选择";
            row_2["ProjectNO"] = "--请选择";
            tbl_proj2.Rows.Add(row_2);

            foreach (MDL.T_Projects obj in projList)
            {
                DataRow row_temp = tbl_proj.NewRow();
                row_temp["projectname"] = obj.projectname;
                row_temp["ProjectNO"] = obj.ProjectNO;
                tbl_proj.Rows.Add(row_temp);

                DataRow row_temp2 = tbl_proj2.NewRow();
                row_temp2["projectname"] = obj.projectname;
                row_temp2["ProjectNO"] = obj.ProjectNO;
                tbl_proj2.Rows.Add(row_temp2);
            }
            cbx_Source.DataSource = tbl_proj;
            cbx_Source.DisplayMember = "projectname";
            cbx_Source.ValueMember = "ProjectNO";

            cbx_Trage.DataSource = tbl_proj2;
            cbx_Trage.DisplayMember = "projectname";
            cbx_Trage.ValueMember = "ProjectNO";
        }
        #endregion

        private void frmProjectCopy_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (btn_Copy.Enabled == false)
                e.Cancel = true;
        }
    }
}
