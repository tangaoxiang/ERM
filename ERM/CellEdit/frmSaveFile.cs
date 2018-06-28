using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.IO;
using TX.Framework.WindowUI.Forms;
using TX.Framework.WindowUI.Controls;

namespace ERM.UI
{
    public partial class frmSaveFile : ERM.UI.Controls.Skin_DevEX
    {
        string _CellID = null;
        string _FileID = null;
        string _gdID = null;
        int _a_flg;

        public frmSaveFile()
        {
            InitializeComponent();
        }
        public frmSaveFile(int a_Flg, string cellID, string FileID)
        {
            InitializeComponent();
            _CellID = cellID;
            _FileID = FileID;
            _a_flg = a_Flg;
            getGDID();
            if (_a_flg == 1)
            {
                //单个表格
            }
            else if (_a_flg == 2)
            {
                //多个表格
            }
            else if (_a_flg == 3)
            {
                //文件
            }
        }

        private void frmSaveFile_Load(object sender, EventArgs e)
        {
            CreateCheckBokList();
        }
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            ///说明：表格保存流程
            ///1单个表格保存
            ///选择“组卷类别”，保存时，将文件和当前表格文件拷贝到归档类别下面
            /// 修改时，如果如果是当个表格就直接将文件条目，改变到新归档类别下
            /// 
            ///2多个表格保存，就在多个目录下都创建一个目录，每个目录对应一个电子表格
            /// 
            ///3文件保存
            ///3.1 将文件下所有表格指定到同目录下
            ///3.2 将没有设置目录的表格指定到一个目录下
            ///

            _gdID = getCheckBoxID();
            if (string.IsNullOrEmpty(_gdID))
            {
                TXMessageBoxExtensions.Info("提示：请选择归档类别！");
                return;
            }
            else
            {
                if (_a_flg == 1)//单个表格
                {
                    #region
                    BLL.T_FileList_BLL File_BLL = new BLL.T_FileList_BLL();
                    BLL.T_CellAndEFile_BLL Cell_BLL = new BLL.T_CellAndEFile_BLL();
                    MDL.T_CellAndEFile cell_MDL = Cell_BLL.Find(_CellID, Globals.ProjectNO);
                    MDL.T_FileList File_MDL = File_BLL.Find(_FileID, Globals.ProjectNO);

                    if (cell_MDL != null && File_MDL != null)
                    {
                        //判断是否存在以前的记录
                        if (string.IsNullOrEmpty(cell_MDL.GdFileID))
                        {
                            //无记录，第一次直接添加
                            SaveInfo(1, File_MDL, cell_MDL, File_BLL, Cell_BLL);
                        }
                        else
                        {
                            ///存在记录
                            ///如果只有当前电子表格的，就将文件一起修改到最新归档目录下
                            ///如果文件目录下有多个表格，就再创建一条记录，最后一条记录，就修改文件归档类别
                            IList<MDL.T_CellAndEFile> CellMDL_list =
                                Cell_BLL.FindByGdFileID(cell_MDL.GdFileID, Globals.ProjectNO);

                            if (CellMDL_list != null && CellMDL_list.Count > 0)
                            {
                                if (CellMDL_list.Count == 1)
                                {
                                    ///一条记录，多条改成一条，只要是最后一个电子文件，调整时，就是将文件归档分类修改
                                    MDL.T_FileList FileCheck_MDL = File_BLL.Find(cell_MDL.GdFileID, Globals.ProjectNO);
                                    if (FileCheck_MDL != null)
                                    {
                                        SaveInfo(2, FileCheck_MDL, null, File_BLL, null);
                                    }
                                    else
                                    {
                                        ///记录不存在，重新创建
                                        SaveInfo(1, File_MDL, cell_MDL, File_BLL, Cell_BLL);
                                    }
                                }
                                else if (CellMDL_list.Count > 1)
                                {
                                    ///多条记录 ，产生一条，新的文件条目，将电子文件挂到当前条目下
                                    SaveInfo(1, File_MDL, cell_MDL, File_BLL, Cell_BLL);
                                }
                            }
                        }
                        TXMessageBoxExtensions.Info("提示：保存成功！");
                        this.Close();
                    }
                    #endregion
                }
                else if (_a_flg == 2)//多个表格
                {
                    #region
                    BLL.T_FileList_BLL File_BLL = new BLL.T_FileList_BLL();
                    BLL.T_CellAndEFile_BLL Cell_BLL = new BLL.T_CellAndEFile_BLL();
                    MDL.T_FileList File_MDL = File_BLL.Find(_FileID, Globals.ProjectNO);

                    if (File_MDL != null)
                    {
                        SaveInfo(3, File_MDL, null, File_BLL, Cell_BLL);
                        TXMessageBoxExtensions.Info("提示：保存成功！");
                        this.Close();
                    }
                    #endregion
                }
                else if (_a_flg == 3)//文件
                {
                    #region
                    BLL.T_FileList_BLL File_BLL = new BLL.T_FileList_BLL();
                    BLL.T_CellAndEFile_BLL Cell_BLL = new BLL.T_CellAndEFile_BLL();
                    MDL.T_FileList File_MDL = File_BLL.Find(_FileID, Globals.ProjectNO);
                    ArrayList gdFileList = new ArrayList();

                    if (File_MDL != null)
                    {
                        IList<MDL.T_CellAndEFile> CellMDL_list =
                             Cell_BLL.FindByFileIDAndNOCell(_FileID, Globals.ProjectNO);

                        if (CellMDL_list != null && CellMDL_list.Count > 0)
                        {
                            File_MDL.FromFileID = File_MDL.FileID;
                            File_MDL.FileID = Guid.NewGuid().ToString();
                            File_MDL.GDID = _gdID;
                            File_MDL.FL = 1;
                            File_MDL.GdFileOrderIndex =
                                File_BLL.GetMaxGdFileOrderIndex(File_MDL.GDID, Globals.ProjectNO) + 1;
                            File_BLL.Add(File_MDL);

                            foreach (MDL.T_CellAndEFile cell_m in CellMDL_list)
                            {
                                if (!string.IsNullOrEmpty(cell_m.GdFileID))
                                {
                                    gdFileList.Add(cell_m.GdFileID);
                                }

                                cell_m.GdFileID = File_MDL.FileID;
                                cell_m.GdOrderIndex =
                                    Cell_BLL.GetMaxGdFileOrderIndex(cell_m.GdFileID, Globals.ProjectNO) + 1;
                                Cell_BLL.Update(cell_m);
                            }
                        }
                        //表格更新完成之后，再删除
                        for (int i = 0; i < gdFileList.Count; i++)
                        {
                            string gdf_id = gdFileList[i].ToString();

                            MDL.T_FileList file_mdl_del =
                                            File_BLL.Find(gdf_id, Globals.ProjectNO);

                            if (file_mdl_del != null)
                            {
                                IList<MDL.T_CellAndEFile> CellMDL_checklist =
                                    Cell_BLL.FindByGdFileID(gdf_id, Globals.ProjectNO);

                                if (CellMDL_checklist == null
                                    || CellMDL_checklist.Count == 0)
                                {
                                    //文件条目只有一条记录的，就删掉
                                    File_BLL.Delete(file_mdl_del);
                                }
                            }
                        }

                    }
                    #endregion
                }
            }
        }

        private void SaveInfo(int a_flg, MDL.T_FileList File_MDL, MDL.T_CellAndEFile Cell_MDL,
            BLL.T_FileList_BLL File_BLL, BLL.T_CellAndEFile_BLL Cell_BLL)
        {
            switch (a_flg)
            {
                case 1://首次或多条记录 添加
                    File_MDL.ParentID = _gdID;
                    File_MDL.FromFileID = File_MDL.FileID;
                    File_MDL.FileID = Guid.NewGuid().ToString();
                    File_MDL.GDID = _gdID;
                    File_MDL.FL = 1;
                    File_MDL.GdFileOrderIndex =
                        File_BLL.GetMaxGdFileOrderIndex(File_MDL.GDID, Globals.ProjectNO) + 1;
                    File_BLL.Add(File_MDL);
                    if (Cell_MDL != null)
                    {
                        Cell_MDL.GdFileID = File_MDL.FileID;
                        Cell_MDL.DoStatus = 1;
                        Cell_MDL.GdOrderIndex =
                            Cell_BLL.GetMaxGdFileOrderIndex(Cell_MDL.GdFileID, Globals.ProjectNO) + 1;
                        Cell_BLL.Update(Cell_MDL);

                        //添加原文信息
                        if (File.Exists(Globals.ProjectPath + Cell_MDL.filepath))
                        {
                            MyCommon.InsertOldEfile(Cell_MDL.CellID, Globals.ProjectNO, Globals.LoginUser, "资料用表-保存并归档-首次或多条记录 添加", Globals.ProjectPath + Cell_MDL.filepath);
                        }
                    }
                    break;
                case 2://一条记录,修改文件级
                    File_MDL.GDID = _gdID;
                    File_MDL.GdFileOrderIndex =
                        File_BLL.GetMaxGdFileOrderIndex(File_MDL.GDID, Globals.ProjectNO) + 1;
                    File_BLL.Update(File_MDL);
                    break;
                case 3://多个表格设置 以前的文件条目是否要删除？还是不动
                    File_MDL.ParentID = _gdID;
                    File_MDL.FromFileID = File_MDL.FileID;
                    File_MDL.FileID = Guid.NewGuid().ToString();
                    File_MDL.GDID = _gdID;
                    File_MDL.FL = 1;
                    File_BLL.Add(File_MDL);

                    ArrayList gdFileList = new ArrayList();

                    string[] cell_list = _CellID.Split(new char[] { ';' });
                    foreach (string c_id in cell_list)
                    {
                        if (c_id != null && c_id.Trim() == "")
                            continue;

                        MDL.T_CellAndEFile cell_m =
                            Cell_BLL.Find(c_id, Globals.ProjectNO);

                        if (!string.IsNullOrWhiteSpace(cell_m.GdFileID))
                            gdFileList.Add(cell_m.GdFileID);

                        if (cell_m != null)
                        {
                            cell_m.GdFileID = File_MDL.FileID;
                            cell_m.DoStatus = 1;
                            cell_m.GdOrderIndex =
                                Cell_BLL.GetMaxGdFileOrderIndex(cell_m.GdFileID, Globals.ProjectNO) + 1;
                            Cell_BLL.Update(cell_m);

                            //添加原文信息
                            if (File.Exists(Globals.ProjectPath + cell_m.filepath))
                            {
                                MyCommon.InsertOldEfile(cell_m.CellID,  Globals.ProjectNO, Globals.LoginUser, "资料用表-保存并归档-多个表格设置", Globals.ProjectPath + cell_m.filepath);
                            }
                        }
                    }
                    //修改前可以判断下文件级，如果要删除，就在修改前删除
                    //表格更新完成之后，再删除
                    for (int i = 0; i < gdFileList.Count; i++)
                    {
                        string gdf_id = gdFileList[i].ToString();
                        MDL.T_FileList file_mdl_del =
                                        File_BLL.Find(gdf_id, Globals.ProjectNO);

                        if (file_mdl_del != null)
                        {
                            IList<MDL.T_CellAndEFile> CellMDL_checklist =
                                Cell_BLL.FindByGdFileID(gdf_id, Globals.ProjectNO);

                            if (CellMDL_checklist == null
                                || CellMDL_checklist.Count == 0)
                            {
                                //文件条目只有一条记录的，就删掉
                                File_BLL.Delete(file_mdl_del);
                            }
                        }
                    }
                    break;
            }
        }

        /// <summary>
        /// 设置单选
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if ((sender as CheckBox).Checked == true)
            {
                foreach (CheckBox chk in (sender as CheckBox).Parent.Controls)
                {
                    if (chk != sender)
                    {
                        chk.Checked = false;
                    }
                }
            }
        }
        /// <summary>
        /// 获取已经选择的组卷类别
        /// </summary>
        private void getGDID()
        {
            if (_a_flg == 1)//单个表格
            {
                #region
                MDL.T_CellAndEFile cell_MDL =
                    (new BLL.T_CellAndEFile_BLL()).Find(_CellID, Globals.ProjectNO);
                if (cell_MDL != null)
                {
                    _FileID = cell_MDL.FileID;
                    MDL.T_FileList file_MDL =
                        (new BLL.T_FileList_BLL()).Find(cell_MDL.GdFileID, Globals.ProjectNO);

                    if (file_MDL != null)
                    {
                        if (!string.IsNullOrEmpty(file_MDL.GDID))
                        {
                            _gdID = file_MDL.GDID;
                        }
                    }
                }
                #endregion
            }
            else if (_a_flg == 2)//多个表格
            {
                #region
                BLL.T_CellAndEFile_BLL Cell_BLL = new BLL.T_CellAndEFile_BLL();
                BLL.T_FileList_BLL File_BLL = new BLL.T_FileList_BLL();
                string[] cell_list = _CellID.Split(new char[] { ';' });

                foreach (string c_id in cell_list)
                {
                    if (c_id != null && c_id.Trim() == "")
                        continue;
                    MDL.T_CellAndEFile cell_MDL =
                        Cell_BLL.Find(c_id, Globals.ProjectNO);
                    _FileID = cell_MDL.FileID;
                    if (cell_MDL != null)
                    {
                        MDL.T_FileList file_MDL =
                            File_BLL.Find(cell_MDL.GdFileID, Globals.ProjectNO);

                        if (file_MDL != null)
                        {
                            if (!string.IsNullOrEmpty(file_MDL.GDID)
                                && string.IsNullOrEmpty(_gdID))
                            {
                                _gdID = file_MDL.GDID;
                            }
                            if (!string.IsNullOrEmpty(file_MDL.GDID)
                               && !string.IsNullOrEmpty(_gdID) && _gdID != file_MDL.GDID)
                            {
                                _gdID = null;
                                break;
                            }
                        }
                    }
                }
                #endregion
            }
            else if (_a_flg == 3)//文件
            {
                #region
                BLL.T_FileList_BLL File_BLL = new BLL.T_FileList_BLL();
                MDL.T_FileList file_MDL =
                            File_BLL.Find(_FileID, Globals.ProjectNO);

                if (file_MDL != null)
                {
                    _gdID = file_MDL.GDID;
                }
                #endregion
            }
        }
        /// <summary>
        /// 获取选中的归档类别
        /// </summary>
        private string getCheckBoxID()
        {
            string return_flg = null;
            foreach (CheckBox chk in pl_gd.Controls)
            {
                if (chk.Checked)
                {
                    return_flg = chk.Name;
                    break;
                }
            }
            return return_flg;
        }
        /// <summary>
        /// 获取显示的归档列表
        /// </summary>
        private void CreateCheckBokList()
        {
            IList<MDL.T_GdList> gd_list
                = (new BLL.T_GdList_BLL()).FindByProjectNo(Globals.ProjectNO);

            TXCheckBox ckb_gd = null;
            Point p = new Point();
            p.X = 30;

            for (int i = 0; i < gd_list.Count; i++)
            {
                MDL.T_GdList gd_mdl = gd_list[i];
                if (gd_mdl.IsShow == 0)
                {
                    gd_list.Remove(gd_mdl);
                    i--;
                    continue;
                }
                if (i > 0 && i % 7 == 0)
                {
                    p.X += 247;
                    p.Y = 15;
                }
                else
                {
                    if (i == 0)
                        p.Y = 15;
                    else
                        p.Y += 40;
                }
                ckb_gd = new TXCheckBox();
                ckb_gd.Name = gd_mdl.ID;
                ckb_gd.Text = gd_mdl.GdName;
                ckb_gd.Location = p;
                if (string.Compare(ckb_gd.Name, _gdID) == 0)
                {
                    ckb_gd.Checked = true;
                }
                this.pl_gd.Controls.Add(ckb_gd);
                ckb_gd.CheckedChanged += new EventHandler(this.CheckBox_CheckedChanged);
            }
        }

        private void frmSaveFile_Shown(object sender, EventArgs e)
        {

        }

        private void pl_gd_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {

        }



    }
}
