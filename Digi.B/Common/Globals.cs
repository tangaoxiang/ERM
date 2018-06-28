using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Digi.B
{
    /// <summary>
    /// 全局变量类，静态访问
    /// </summary>
    public class Globals
    {


        private const string dbType = "Access";                                 //数据库类型 (Access,SQL)

        private const string normalStatus = "就绪";                             //就绪状态的文字表述

        private const string blankCell = "blank.cll";                           //空表
        private const string newCell = "new.cll";                               //用来创建新表的模板


        private static string appTitle = "建设工程电子文件归档与管理系统";       //应用程序标题
        private static string promptTitle = "建设工程电子文件归档与管理系统";     //对话框标题
        private static string userTitle = "市城建档案馆";                         //所属档案馆名称
        private static string companyTitle = "软件使用单位";                      //软件使用单位

        private static string loginUser = "";                                   //登录用户
        private static int userID;                                              //登录用户ID
        private static int sh;                                                  //登陆用户是否具有审核权利
        private static int theme;                                               //界面风格
        private static int defaultTempID = 0;
        private static string password;
        private static string fullname = "";

        //默认组卷方式


        private static string openedProjectNo = "digipower";                             //系统中打开的工程的编号


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
        /// 获取或设置登录用户的审核权利。1有 0无
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
        /// 获取或设置系统中打开的工程的编号，是工程的唯一编号
        /// </summary>
        public static string OpenedProjectNo
        {
            get { return openedProjectNo; }
            set { openedProjectNo = value; }
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
                return Application.StartupPath + "\\" + Properties.Settings.Default.CellPath;// System.Configuration.ConfigurationManager.AppSettings["CellPath"].ToString();
            }
        }

        /// <summary>
        /// 获取工程表格存放的路径
        /// </summary>
        public static string ProjectPath
        {
            get
            {
                return Application.StartupPath + "\\" + Properties.Settings.Default.ProjectPath;
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
        /// 数据库路径
        /// </summary>
        public static string MDBPath
        {
            get
            {
                //return Properties.Settings.Default.MDBPath;
                return Application.StartupPath + "\\" + @"Db\data.mdb";

            }
        }

        public static bool UpdateSettings()
        {
            //Digi.BLL.Users users = new Digi.BLL.Users();
            //System.Data.DataSet ds= users.UpdateSettings();
            //if (ds != null)
            //{
            //    if (ds.Tables[0].Rows.Count == 1)
            //    {

            //        Globals.AppTitle = ds.Tables[0].Rows[0]["AppTitle"].ToString();
            //        Globals.PromptTitle = ds.Tables[0].Rows[0]["PromptTitle"].ToString();
            //        Globals.UserTitle = ds.Tables[0].Rows[0]["UserTitle"].ToString();
            //        Globals.DefaultTempID = (int)ds.Tables[0].Rows[0]["defaultTempID"];
            //        return true;
            //    }
            //    else
            //        return false;
            //}
            //else
            return false;
        }

     
    }
}
