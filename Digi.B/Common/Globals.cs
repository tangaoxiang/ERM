using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Digi.B
{
    /// <summary>
    /// ȫ�ֱ����࣬��̬����
    /// </summary>
    public class Globals
    {


        private const string dbType = "Access";                                 //���ݿ����� (Access,SQL)

        private const string normalStatus = "����";                             //����״̬�����ֱ���

        private const string blankCell = "blank.cll";                           //�ձ�
        private const string newCell = "new.cll";                               //���������±��ģ��


        private static string appTitle = "���蹤�̵����ļ��鵵�����ϵͳ";       //Ӧ�ó������
        private static string promptTitle = "���蹤�̵����ļ��鵵�����ϵͳ";     //�Ի������
        private static string userTitle = "�гǽ�������";                         //��������������
        private static string companyTitle = "���ʹ�õ�λ";                      //���ʹ�õ�λ

        private static string loginUser = "";                                   //��¼�û�
        private static int userID;                                              //��¼�û�ID
        private static int sh;                                                  //��½�û��Ƿ�������Ȩ��
        private static int theme;                                               //������
        private static int defaultTempID = 0;
        private static string password;
        private static string fullname = "";

        //Ĭ�����ʽ


        private static string openedProjectNo = "digipower";                             //ϵͳ�д򿪵Ĺ��̵ı��


        public static string Fullname
        {
            set { fullname = value; }
            get { return fullname; }
        }


        /// <summary>
        /// ��ȡ������Ӧ�ó������
        /// </summary>
        public static string AppTitle
        {
            get { return appTitle; }
            set { appTitle = value; }
        }


        /// <summary>
        /// ��ȡ������Ӧ�ó����̱��⣬������ʾ�Ի����С�
        /// </summary>
        public static string PromptTitle
        {
            get { return promptTitle; }
            set { promptTitle = value; }
        }

        /// <summary>
        /// ��ȡ���ݿ�����
        /// </summary>
        public static string DBType
        {
            get { return dbType; }
        }

        /// <summary>
        /// ��ȡ��������������������
        /// </summary>
        public static string UserTitle
        {
            get { return userTitle; }
            set { userTitle = value; }
        }

        /// <summary>
        /// ��ȡ���������ʹ�õ�λ
        /// </summary>
        public static string CompanyTitle
        {
            get { return companyTitle; }
            set { companyTitle = value; }
        }


        /// <summary>
        /// ��ȡ�����õ�¼�û��ľ�̬����
        /// </summary>
        public static string LoginUser
        {
            get { return loginUser; }
            set { loginUser = value; }
        }


        /// <summary>
        /// ��ȡ�����õ�¼�û�ID�ľ�̬����
        /// </summary>
        public static int UserID
        {
            get { return userID; }
            set { userID = value; }
        }

        /// <summary>
        /// ��ȡ�����õ�¼�û������Ȩ����1�� 0��
        /// </summary>
        public static int SH
        {
            get { return sh; }
            set { sh = value; }
        }

        /// <summary>
        /// Ĭ�����ʽ
        /// </summary>
        public static int DefaultTempID
        {
            get { return defaultTempID; }
            set { defaultTempID = value; }
        }

        /// <summary>
        /// ��ȡ�����õ�¼�û��Ľ�����1-xp;2-2003
        /// </summary>
        public static int Theme
        {
            get { return theme; }
            set { theme = value; }
        }


        /// <summary>
        /// �û�����
        /// </summary>
        public static string Password
        {
            set { password = value; }
            get { return password; }
        }

        /// <summary>
        /// ��ȡ����״̬�����ֱ���
        /// </summary>
        public static string NormalStatus
        {
            get { return normalStatus; }
        }

        /// <summary>
        /// ��ȡ������ϵͳ�д򿪵Ĺ��̵ı�ţ��ǹ��̵�Ψһ���
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
        /// ��ȡһ���ձ������ڽڵ�û�б�����ȱʧ��������Ҳ���ؼ��е���ʾ
        /// </summary>
        public static string BlankCell
        {
            get { return Application.StartupPath + "\\" + blankCell; }
        }

        /// <summary>
        /// ��ȡ���������±��ģ��
        /// </summary>
        public static string NewCell
        {
            get
            {
                return Application.StartupPath + "\\" + newCell;
            }
        }

        /// <summary>
        /// ��ȡ���ӱ��(ģ��)��·��
        /// </summary>
        public static string CellPath
        {
            get
            {
                return Application.StartupPath + "\\" + Properties.Settings.Default.CellPath;// System.Configuration.ConfigurationManager.AppSettings["CellPath"].ToString();
            }
        }

        /// <summary>
        /// ��ȡ���̱���ŵ�·��
        /// </summary>
        public static string ProjectPath
        {
            get
            {
                return Application.StartupPath + "\\" + Properties.Settings.Default.ProjectPath;
            }
        }
        /// <summary>
        /// ���˵��/�����ʾ
        /// </summary>
        public static string Descriptive
        {
            get
            {
                return Properties.Settings.Default.descriptive;

            }
        }
        /// <summary>
        /// ���ݿ�·��
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
