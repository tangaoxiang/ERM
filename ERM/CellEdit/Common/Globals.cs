using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using ERM.BLL;
using ERM.MDL;
using System.Data;
using System.IO;

namespace ERM.UI
{
    /// <summary>
    /// 全局变量类，静态访问
    /// </summary>
    public class Globals
    {
        private const bool unSignCanGroup = true;                  //ture不需要签名也能组卷 false需要
        private const string dbType = "Access";                                 //数据库类型 (Access,SQL)
        private const string normalStatus = "就绪";                             //就绪状态的文字表述
        private const string waitStatus = "";                 //等待状态
        private const string blankCell = "blank.cll";                           //空表
        private const string newCell = "new.cll";                               //用来创建新表的模板
        private static string appTitle = "";       //应用程序标题
        private static string promptTitle = "";     //对话框标题
        private static string userTitle = "";                         //所属档案馆名称
        private static string userTitle2 = "";                        //省建设厅
        private static string companyTitle = "";                      //软件使用单位
        private static string loginUser = "";                                   //登录用户
        private static int userID;                                              //登录用户ID
        private static int sh;                                                  //登陆用户是否具有提交权利
        private static int theme;                                               //界面风格
        private static int defaultTempID = 0;
        private static string password;
        private static string fullname = "";
        private static string openedProjectNo = "";                             //系统中打开的工程的编号
        private static string openedAjdh = "";                             //系统中打开的工程的案卷档号
        private static string zrr;
        private static string signpassword = null;
        private static bool frmcancle = true;


        private static string isOkGuid = "28E6AC73-C17E-4568-AC9F-27FF92BBD43F";//Yes/启用 Guid 代表true
        private static string isNoGuid = "2542D895-C19D-423A-B2B6-D4B8B6115578";//No/禁用 Guid 代表false

        public static bool SystemDocxOffice { set; get; }       //判断系统是否安装Office2007 以上版本
        public static string IsOkGuid
        {
            get { return isOkGuid; }
        }

        public static string IsNoGuid
        {
            get { return isNoGuid; }
        }

        public static string IsFont
        {
            get { return Properties.Settings.Default.IsFont; }
        }
        /// <summary>
        /// 是否签章
        /// </summary>
        public static string IsSignature
        {
            get { return Properties.Settings.Default.IsSignature; }
        }
        /// <summary>
        /// 是否要页码
        /// </summary>
        public static string IsPageNo
        {
            get { return Properties.Settings.Default.IsPageNo; }
        }
        /// <summary>
        /// 页码位置X
        /// </summary>
        public static int PageNoLocationX
        {
            get { return MyCommon.ToInt(Properties.Settings.Default.PageNoLocationX); }
        }
        /// <summary>
        /// 页码位置Y
        /// </summary>
        public static int PageNoLocationY
        {
            get { return MyCommon.ToInt(Properties.Settings.Default.PageNoLocationY); }
        }
        /// <summary>
        /// 页码字体大小
        /// </summary>
        public static int PageNoLocationSize
        {
            get { return MyCommon.ToInt(Properties.Settings.Default.PageNoLocationSize); }
        }
        /// <summary>
        /// esaypdf序列好
        /// </summary>
        public static string LicenseKey
        {
            //get {  return "7FDD-FE1D-94E8-C288-B306-A087"; }//6.0
            get { return "7FDD-7E1D-94E8-C288-ADB6-B45F"; }//6.2

            //get { return Properties.Settings.Default.LicenseKey; }
            //get { return "7FDD-7E1D-94E8-C288-ADB6-B45F"; }//6.2
        }
        /// <summary>
        /// 是否窗体退出
        /// </summary>
        public static bool FrmCancle
        {
            get { return frmcancle; }
            set { frmcancle = value; }
        }
        /// <summary>
        /// 签章密码
        /// </summary>
        public static string SignPassword
        {
            get { return signpassword; }
            set { signpassword = value; }
        }
        /// <summary>
        /// 签章方式
        /// </summary>
        public static string SignatureModel
        {
            get { return Properties.Settings.Default.SignatureModel; }
            set
            {
                Properties.Settings.Default.SignatureModel = value;
                Properties.Settings.Default.Save();
            }
        }
        /// <summary>
        /// 签章x坐标
        /// </summary>
        public static string SignatureModelPositionX
        {
            get { return Properties.Settings.Default.SignatureModelPositionX; }
            set
            {
                Properties.Settings.Default.SignatureModelPositionX = value;
                Properties.Settings.Default.Save();
            }
        }
        /// <summary>
        /// 签章y坐标
        /// </summary>
        public static string SignatureModelPositionY
        {
            get { return Properties.Settings.Default.SignatureModelPositionY; }
            set
            {
                Properties.Settings.Default.SignatureModelPositionY = value;
                Properties.Settings.Default.Save();
            }
        }
        /// <summary>
        /// 文件登记选择树
        /// </summary>
        /// <remarks>CJDAG　档案馆　　　DANWEI  单位</remarks>
        public static string TreeSelectView
        {
            get { return Properties.Settings.Default.TreeSelect; }
        }
        /// <summary>
        /// 责任人
        /// </summary>
        public static string ZRR
        {
            get
            {
                return zrr;
            }
            set
            {
                zrr = value;
            }
        }
        /// <summary>
        /// 创建目录
        /// </summary>
        public static void CreateProjectPath()
        {
            if (!Directory.Exists(Application.StartupPath + "\\Project\\"))
            {
                Directory.CreateDirectory(Application.StartupPath + "\\Project\\");
            }
            if (!Directory.Exists(Application.StartupPath + "\\Project\\" + Globals.ProjectNO))
            {
                Directory.CreateDirectory(Application.StartupPath + "\\Project\\" + Globals.ProjectNO);
            }
            if (!Directory.Exists(Application.StartupPath + "\\Project\\" + Globals.ProjectNO + "\\ODOC"))
            {
                Directory.CreateDirectory(Application.StartupPath + "\\Project\\" + Globals.ProjectNO + "\\ODOC");
            }
            if (!Directory.Exists(Application.StartupPath + "\\Project\\" + Globals.ProjectNO + "\\PDF"))
            {
                Directory.CreateDirectory(Application.StartupPath + "\\Project\\" + Globals.ProjectNO + "\\PDF");
            }
            if (!Directory.Exists(Application.StartupPath + "\\Project\\" + Globals.ProjectNO + "\\MPDF"))
            {
                Directory.CreateDirectory(Application.StartupPath + "\\Project\\" + Globals.ProjectNO + "\\MPDF");
            }
        }
        /// <summary>
        /// 导入功能涉及的文件临时存放目录
        /// </summary>
        public static string BackupData
        {
            get { return Application.StartupPath + "\\" + Properties.Settings.Default.ProjectPath + "\\" + openedProjectNo + "\\" + Properties.Settings.Default.BackupData; }
        }

        public static string FilterType
        {
            get { return Properties.Settings.Default.FilterType.ToString(); }
        }
        public static string PDFTemp
        {
            get { return Application.StartupPath + "\\" + Properties.Settings.Default.ProjectPath + "\\" + openedProjectNo + "\\" + Properties.Settings.Default.PDFTemp; }
        }
        public static string PrintType
        {
            get { return Properties.Settings.Default.PrintType.ToString(); }
        }
        public static string Fullname
        {
            set { fullname = value; }
            get { return fullname; }
        }
        /// <summary>
        /// 获取或设置应用程序标题
        /// </summary>
        public static string AppTitle
        {
            get { return appTitle; }
            set { appTitle = value; }
        }
        /// <summary>
        /// 获取或设置应用程序简短标题，用在提示对话框中。
        /// </summary>
        public static string PromptTitle
        {
            get { return promptTitle; }
            set { promptTitle = value; }
        }
        /// <summary>
        /// 获取数据库类型
        /// </summary>
        public static string DBType
        {
            get { return dbType; }
        }
        /// <summary>
        /// 获取或设置所属档案馆名称
        /// </summary>
        public static string UserTitle
        {
            get { return userTitle; }
            set { userTitle = value; }
        }
        /// <summary>
        /// 获取或设置省建设厅名称
        /// </summary>
        public static string UserTitle2
        {
            get { return userTitle2; }
            set { userTitle2 = value; }
        }
        /// <summary>
        /// 获取或设置软件使用单位
        /// </summary>
        public static string CompanyTitle
        {
            get { return companyTitle; }
            set { companyTitle = value; }
        }
        /// <summary>
        /// 获取或设置登录用户的静态属性
        /// </summary>
        public static string LoginUser
        {
            get { return loginUser; }
            set { loginUser = value; }
        }
        /// <summary>
        /// 获取或设置登录用户ID的静态属性
        /// </summary>
        public static int UserID
        {
            get { return userID; }
            set { userID = value; }
        }
        /// <summary>
        /// 获取或设置登录用户的提交权利。1有 0无
        /// </summary>
        public static int SH
        {
            get { return sh; }
            set { sh = value; }
        }
        /// <summary>
        /// 默认组卷方式
        /// </summary>
        public static int DefaultTempID
        {
            get { return defaultTempID; }
            set { defaultTempID = value; }
        }
        /// <summary>
        /// 获取或设置登录用户的界面风格。1-xp;2-2003
        /// </summary>
        public static int Theme
        {
            get { return theme; }
            set { theme = value; }
        }
        /// <summary>
        /// 用户密码
        /// </summary>
        public static string Password
        {
            set { password = value; }
            get { return password; }
        }
        /// <summary>
        /// 获取就绪状态的文字表述
        /// </summary>
        public static string NormalStatus
        {
            get { return normalStatus; }
        }
        /// <summary>
        /// 等待状态时的文字
        /// </summary>
        public static string WaitStatus
        {
            get { return waitStatus; }
        }
        /// <summary>
        /// 获取或设置系统中打开的工程的编号，是工程的唯一编号
        /// </summary>
        public static string ProjectNO
        {
            get { return openedProjectNo; }
            set { openedProjectNo = value; }
        }
        /// <summary>
        /// 获取或设置系统中打开的工程的案卷档号
        /// </summary>
        public static string Ajdh
        {
            get { return openedAjdh; }
            set { openedAjdh = value; }
        }
        private static string projectname;
        public static string Projectname
        {
            get { return projectname; }
            set { projectname = value; }
        }
        /// <summary>
        /// 获取一个空表，用来在节点没有表格或表格缺失的情况下右侧表格控件中的显示
        /// </summary>
        public static string BlankCell
        {
            get { return Application.StartupPath + "\\" + blankCell; }
        }
        /// <summary>
        /// 获取用来创建新表的模板
        /// </summary>
        public static string NewCell
        {
            get
            {
                return Application.StartupPath + "\\" + newCell;
            }
        }
        /// <summary>
        /// 获取电子表格(模板)的路径
        /// </summary>
        public static string CellPath
        {
            get
            {
                return Application.StartupPath + "\\" + Properties.Settings.Default.CellPath;
            }
        }
        /// <summary>
        /// 获取Reports的路径
        /// </summary>
        public static string ReportsPath
        {
            get
            {
                return Application.StartupPath + "\\" + "Reports";
            }
        }
        /// <summary>
        /// 获取工程表格存放的路径
        /// </summary>
        public static string ProjectPath
        {
            get
            {
                if (ProjectNO != String.Empty)
                {
                    return Application.StartupPath + "\\" + Properties.Settings.Default.ProjectPath + "\\" + ProjectNO + "\\";
                }
                else
                {
                    return Application.StartupPath + "\\" + Properties.Settings.Default.ProjectPath + "\\";
                }
            }
        }
        public static string ProjectPathParent
        {
            get
            {
                return Application.StartupPath + "\\" + Properties.Settings.Default.ProjectPath + "\\";
            }
        }
        /// <summary>
        /// 填表说明/填表提示
        /// </summary>
        public static string Descriptive
        {
            get
            {
                return Properties.Settings.Default.descriptive;
            }
        }
        /// <summary>
        /// ture不需要签名也能组卷 false需要
        /// </summary>
        public static bool UnSignCanGroup
        {
            get
            {
                if (Properties.Settings.Default.IsSignature.Equals("0"))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        /// <summary>
        /// 档案馆代号
        /// </summary>
        /// <returns></returns>
        public static string DagDh
        {
            get
            {
                return Properties.Settings.Default.DagDh;
            }
        }
        public static bool UpdateSettings()
        {
            ERM.BLL.T_Settings_BLL settingBLL = new T_Settings_BLL();
            IList<MDL.T_Settings> settingList = settingBLL.GetAll();
            if (settingList.Count > 0)
            {
                ERM.MDL.T_Settings model = settingList[0];
                Globals.AppTitle = model.AppTitle;
                Globals.PromptTitle = model.PromptTitle;
                Globals.UserTitle = model.UserTitle;
                Globals.UserTitle2 = model.UserTitle2;
                return true;
            }
            else
                return false;
        }
        /// <summary>
        /// 获取 树的宽度
        /// </summary>
        public static string TreeWidth
        {
            get
            {
                return Properties.Settings.Default.TreeWidth;
            }
        }
        /// <summary>
        /// 原始电子文件路径
        /// </summary>
        public static string ODOCPath
        {
            get
            {
                return Application.StartupPath + "\\" + Properties.Settings.Default.ProjectPath + "\\" + openedProjectNo + "\\" + Properties.Settings.Default.ODOCPath;
            }
        }
        /// <summary>
        /// 合并后的PDF文件路径
        /// </summary>
        public static string MPDFPath
        {
            get
            {
                return Application.StartupPath + "\\" + Properties.Settings.Default.ProjectPath + "\\" + openedProjectNo + "\\" + Properties.Settings.Default.MPDFPath;
            }
        }
        /// <summary>
        /// 单页PDF电子文件路径
        /// </summary>
        public static string SPDFPath
        {
            get
            {
                return Application.StartupPath + "\\" + Properties.Settings.Default.ProjectPath + "\\" + openedProjectNo + "\\" + Properties.Settings.Default.SPDFPath;
            }
        }
    }
}
