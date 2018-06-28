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
    /// ȫ�ֱ����࣬��̬����
    /// </summary>
    public class Globals
    {
        private const bool unSignCanGroup = true;                  //ture����Ҫǩ��Ҳ����� false��Ҫ
        private const string dbType = "Access";                                 //���ݿ����� (Access,SQL)
        private const string normalStatus = "����";                             //����״̬�����ֱ���
        private const string waitStatus = "";                 //�ȴ�״̬
        private const string blankCell = "blank.cll";                           //�ձ�
        private const string newCell = "new.cll";                               //���������±��ģ��
        private static string appTitle = "";       //Ӧ�ó������
        private static string promptTitle = "";     //�Ի������
        private static string userTitle = "";                         //��������������
        private static string userTitle2 = "";                        //ʡ������
        private static string companyTitle = "";                      //���ʹ�õ�λ
        private static string loginUser = "";                                   //��¼�û�
        private static int userID;                                              //��¼�û�ID
        private static int sh;                                                  //��½�û��Ƿ�����ύȨ��
        private static int theme;                                               //������
        private static int defaultTempID = 0;
        private static string password;
        private static string fullname = "";
        private static string openedProjectNo = "";                             //ϵͳ�д򿪵Ĺ��̵ı��
        private static string openedAjdh = "";                             //ϵͳ�д򿪵Ĺ��̵İ�����
        private static string zrr;
        private static string signpassword = null;
        private static bool frmcancle = true;


        private static string isOkGuid = "28E6AC73-C17E-4568-AC9F-27FF92BBD43F";//Yes/���� Guid ����true
        private static string isNoGuid = "2542D895-C19D-423A-B2B6-D4B8B6115578";//No/���� Guid ����false

        public static bool SystemDocxOffice { set; get; }       //�ж�ϵͳ�Ƿ�װOffice2007 ���ϰ汾
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
        /// �Ƿ�ǩ��
        /// </summary>
        public static string IsSignature
        {
            get { return Properties.Settings.Default.IsSignature; }
        }
        /// <summary>
        /// �Ƿ�Ҫҳ��
        /// </summary>
        public static string IsPageNo
        {
            get { return Properties.Settings.Default.IsPageNo; }
        }
        /// <summary>
        /// ҳ��λ��X
        /// </summary>
        public static int PageNoLocationX
        {
            get { return MyCommon.ToInt(Properties.Settings.Default.PageNoLocationX); }
        }
        /// <summary>
        /// ҳ��λ��Y
        /// </summary>
        public static int PageNoLocationY
        {
            get { return MyCommon.ToInt(Properties.Settings.Default.PageNoLocationY); }
        }
        /// <summary>
        /// ҳ�������С
        /// </summary>
        public static int PageNoLocationSize
        {
            get { return MyCommon.ToInt(Properties.Settings.Default.PageNoLocationSize); }
        }
        /// <summary>
        /// esaypdf���к�
        /// </summary>
        public static string LicenseKey
        {
            //get {  return "7FDD-FE1D-94E8-C288-B306-A087"; }//6.0
            get { return "7FDD-7E1D-94E8-C288-ADB6-B45F"; }//6.2

            //get { return Properties.Settings.Default.LicenseKey; }
            //get { return "7FDD-7E1D-94E8-C288-ADB6-B45F"; }//6.2
        }
        /// <summary>
        /// �Ƿ����˳�
        /// </summary>
        public static bool FrmCancle
        {
            get { return frmcancle; }
            set { frmcancle = value; }
        }
        /// <summary>
        /// ǩ������
        /// </summary>
        public static string SignPassword
        {
            get { return signpassword; }
            set { signpassword = value; }
        }
        /// <summary>
        /// ǩ�·�ʽ
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
        /// ǩ��x����
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
        /// ǩ��y����
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
        /// �ļ��Ǽ�ѡ����
        /// </summary>
        /// <remarks>CJDAG�������ݡ�����DANWEI  ��λ</remarks>
        public static string TreeSelectView
        {
            get { return Properties.Settings.Default.TreeSelect; }
        }
        /// <summary>
        /// ������
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
        /// ����Ŀ¼
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
        /// ���빦���漰���ļ���ʱ���Ŀ¼
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
        /// ��ȡ������ʡ����������
        /// </summary>
        public static string UserTitle2
        {
            get { return userTitle2; }
            set { userTitle2 = value; }
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
        /// ��ȡ�����õ�¼�û����ύȨ����1�� 0��
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
        /// �ȴ�״̬ʱ������
        /// </summary>
        public static string WaitStatus
        {
            get { return waitStatus; }
        }
        /// <summary>
        /// ��ȡ������ϵͳ�д򿪵Ĺ��̵ı�ţ��ǹ��̵�Ψһ���
        /// </summary>
        public static string ProjectNO
        {
            get { return openedProjectNo; }
            set { openedProjectNo = value; }
        }
        /// <summary>
        /// ��ȡ������ϵͳ�д򿪵Ĺ��̵İ�����
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
                return Application.StartupPath + "\\" + Properties.Settings.Default.CellPath;
            }
        }
        /// <summary>
        /// ��ȡReports��·��
        /// </summary>
        public static string ReportsPath
        {
            get
            {
                return Application.StartupPath + "\\" + "Reports";
            }
        }
        /// <summary>
        /// ��ȡ���̱���ŵ�·��
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
        /// ture����Ҫǩ��Ҳ����� false��Ҫ
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
        /// �����ݴ���
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
        /// ��ȡ ���Ŀ��
        /// </summary>
        public static string TreeWidth
        {
            get
            {
                return Properties.Settings.Default.TreeWidth;
            }
        }
        /// <summary>
        /// ԭʼ�����ļ�·��
        /// </summary>
        public static string ODOCPath
        {
            get
            {
                return Application.StartupPath + "\\" + Properties.Settings.Default.ProjectPath + "\\" + openedProjectNo + "\\" + Properties.Settings.Default.ODOCPath;
            }
        }
        /// <summary>
        /// �ϲ����PDF�ļ�·��
        /// </summary>
        public static string MPDFPath
        {
            get
            {
                return Application.StartupPath + "\\" + Properties.Settings.Default.ProjectPath + "\\" + openedProjectNo + "\\" + Properties.Settings.Default.MPDFPath;
            }
        }
        /// <summary>
        /// ��ҳPDF�����ļ�·��
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
