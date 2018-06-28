using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using System.Diagnostics;
using System.Net;
using System.Xml;
using System.Reflection;
using ERM.Common;
using System.Collections;
using System.Runtime.InteropServices;
using Microsoft.Win32;
using TX.Framework.WindowUI.Forms;

namespace ERM.UI
{
    public partial class frmMDIMain : ERM.UI.Controls.Skin_DevEX
    {
        #region ������ʼ��
        public delegate void setComBoxDel(bool value);
        #endregion
        public void setComBox(bool value) {
            if (value)
            {
                ToolStripComboBox c1 = (ToolStripComboBox)myToolStrip1.Items["toolProjCombox"];
                c1.Items.Clear();
                c1.Text = "";
                this.btnProjectSelect.Enabled = true;
                this.btnExit.Enabled = true;
            }
        }
        #region ���庯��

        public frmMDIMain()
        {
            InitializeComponent();
            this.Text = Globals.AppTitle;                       //�������
            tssLabel1.Text = Globals.NormalStatus;              //����
            tssLabel2.Text = Globals.AppTitle;                  //Ӧ�ó������
            tssLabel3.Text = "��ǰ�û���" + Globals.LoginUser;  //��ǰ�û�
            this.CheckRights();
        }
        private void frmWelcome_Load(object sender, EventArgs e)
        {
            if (!MyCommon.IsCheckFD())
                this.Ukey_timer.Tick -= new System.EventHandler(this.Ukey_timer_Tick);
            else
                this.Ukey_timer.Tick += new System.EventHandler(this.Ukey_timer_Tick);

            ToolStripComboBox c1 = (ToolStripComboBox)myToolStrip1.Items["toolProjCombox"];
            BLL.T_Projects_BLL projBLL = new ERM.BLL.T_Projects_BLL();
            IList<MDL.T_Projects> projList = projBLL.GetAll();
            if (projList.Count <= 0)
            {
                tsmiProjectSelect.PerformClick();
            }
            else
            {
                ArrayList projname_list = new ArrayList();
                foreach (MDL.T_Projects obj in projList)
                {
                    //c1.Items.Add(obj.ProjectNO);
                    projname_list.Add(obj.ProjectNO + "|" + obj.projectname + "|" + obj.ajdh);
                    c1.Items.Add(obj.projectname);
                }
                c1.Tag = projname_list;

                if (Globals.ProjectNO == string.Empty)
                {
                    //Common.OptRegisterTable optRegTable = new OptRegisterTable();
                    //Globals.ProjectNO = optRegTable.ReadRegistData("Digipower_Current_Project");
                    ReadWriteAppConfig config = new ReadWriteAppConfig();
                    Globals.ProjectNO = config.Read("Current_Project");//Properties.Settings.Default.Current_Project;
                    Globals.Ajdh = config.Read("Current_ProjectAjdh");
                    if (Globals.ProjectNO != null && Globals.ProjectNO != "")
                    {
                        foreach (string proj in projname_list)
                        {
                            string[] projString = proj.Split(new char[] { '|' });
                            if (projString != null && projString[0] == Globals.ProjectNO)
                            {
                                Globals.Ajdh = projString[2];
                                Globals.Projectname = projString[1];
                                Globals.ProjectNO = projString[0];
                                break;
                            }
                        }
                    }
                    //MDL.T_Projects projMDL = projBLL.Find(Globals.ProjectNO);
                    //if (projMDL != null)
                    //{
                    //    Globals.Projectname = projMDL.projectname;
                    //}
                }
                //c1.Text = Globals.ProjectNO;
                c1.Text = Globals.Projectname;
                if (c1.SelectedItem == null)
                {
                    tsmiProjectSelect.PerformClick();
                }
            }
            FromBind();
            Globals.SystemDocxOffice = CheckSystemOffice();
        }

        /// <summary>
        ///  �رմ����������¼�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmWelcome_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (TXMessageBoxExtensions.Question("��ȷ��Ҫ�˳�ϵͳ��") == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
            else
            {
                //ShengJi();//�ж��Ƿ�����
                System.Diagnostics.Process.GetCurrentProcess().Kill();//ɱ��Ӧ�ó������
            }
        }

        private void tsmiExit_Click(object sender, EventArgs e)
        {
            
            Application.Exit();
        }
        private void tsmiChangePass_Click(object sender, EventArgs e)
        {
            frmChangeUserPasswd frm = new frmChangeUserPasswd();
            DialogResult ret = frm.ShowDialog();
            if (ret == DialogResult.OK)
            {
                TXMessageBoxExtensions.Info(SystemTips.MSG_EDIT_PW_SUCC, SystemTips.MSG_TITLE);
            }
        }
        /// <summary>
        /// ���µ�¼
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiReLogin_Click(object sender, EventArgs e)
        {
            frmLogin frm = new frmLogin();
            this.Hide();
            DialogResult ret = frm.ShowDialog();
            if (ret == DialogResult.OK)
            {
                this.Show();
                tssLabel3.Text = "��ǰ�û���" + Globals.LoginUser;  //��ǰ�û�
                CheckRights();
                this.Activate();
            }
            else
            {
                this.FormClosing -= new FormClosingEventHandler(this.frmWelcome_FormClosing);
                this.Close();
            }
        }

        private void tsmiUsers_Click(object sender, EventArgs e)
        {
            frmUsersList frm = new frmUsersList();
            frm.ShowDialog();
        }
        private void tsmiPageSize_Click(object sender, EventArgs e)
        {
            frmPageSizeList frm = new frmPageSizeList();
            frm.ShowDialog();
        }
        private void tsmiDistrict_Click(object sender, EventArgs e)
        {
            frmDistrictList frm = new frmDistrictList();
            frm.ShowDialog();
        }
        private void tsmiAbout_Click(object sender, EventArgs e)
        {
            (new frmAbout()).ShowDialog();
        }
        private void tsmiHelpMain_Click(object sender, EventArgs e)
        {
            MyCommon.OpenDocument(Application.StartupPath + "\\���蹤�̵����ļ��鵵�����ϵͳ����˵��.chm");
        }
        private void tsmiSReport_Click(object sender, EventArgs e)
        {
            MyCommon.OpenDocument(Application.StartupPath + "\\SReport.exe");
        }
        private void tsmiRegister_Click(object sender, EventArgs e)
        {
        }
        /// <summary>
        /// ���̹���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnProjectMaint_Click(object sender, EventArgs e)
        {
            tsmiProjectMaint.PerformClick();
        }
        /// <summary>
        /// �޸�����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnChangePass_Click(object sender, EventArgs e)
        {
            tsmiChangePass.PerformClick();
        }
        /// <summary>
        /// ������Ϣ չʾ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiNew_Click(object sender, EventArgs e)
        {
            string ProjectNO = Globals.ProjectNO;//����ֵ
            frmProjectInfo frmProjectInfo = new frmProjectInfo(ProjectNO, false);
            frmProjectInfo.ShowDialog();
        }
        /// <summary>
        /// ���������ñ�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiFileLoe_Click(object sender, EventArgs e)
        {
            frmCellMain frm = new frmCellMain(this);
            frm.Show();
            this.Hide();
        }
        /// <summary>
        /// �ļ��Ǽ�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiProjectMaint_Click(object sender, EventArgs e)
        {
            try
            {
                frmFileMain Skin_DevExpress = new frmFileMain(this);
                Skin_DevExpress.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                TXMessageBoxExtensions.Info(ex.Message.ToString());
            }
        }
        /// <summary>
        ///���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiArichive_Click(object sender, EventArgs e)
        {
            try
            {
                frmYJ Skin_DevExpress = new frmYJ(this);
                Skin_DevExpress.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                 TXMessageBoxExtensions.Info(ex.Message.ToString());
            }
        }
        /// <summary>
        /// ���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnProjectArchive_Click(object sender, EventArgs e)
        {
            try
            {
                tsmiArichive_Click(null, null);
            }
            catch (Exception ex)
            {
                TXMessageBoxExtensions.Info(ex.Message.ToString());
            }
        }
        /// <summary>
        /// ���µ�¼
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            tsmiReLogin_Click(null, null);
        }
        /// <summary>
        /// ���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            frmZJ Skin_DevExpress = new frmZJ(this);  //��ʼ������������� ���븸����
            this.Hide();
            Skin_DevExpress.ShowDialog();
        }
        /// <summary>
        /// �˳�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExit_Click(object sender, EventArgs e)
        {
            tsmiExit_Click(null, null);
        }
        /// <summary>
        /// �޸�����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnChangePass_Click_1(object sender, EventArgs e)
        {
            btnChangePass_Click(null, null);
        }
        /// <summary>
        /// �����ñ�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFileCreate_Click(object sender, EventArgs e)
        {
            tsmiFileLoe_Click(null, null);
        }
        /// <summary>
        /// ���̹���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiProjectSelect_Click(object sender, EventArgs e)
        {
            this.btnProjectSelect.Enabled = false;
            this.btnFileCreate.Enabled = false;
            this.toolStripButton2.Enabled = false;
            this.btnProjectMaint.Enabled = false;
            this.btnProjectArchive.Enabled = false;
            this.btnChangePass.Enabled = false;
            this.myMenuStrip1.Enabled = false;
            this.toolProjCombox.Enabled = false;
            this.btnExit.Enabled = false;
            frmProjectList frm = new frmProjectList(setComBox);
            DialogResult drs = frm.ShowDialog();

            this.Text = Globals.AppTitle + " - " + Globals.Projectname;//Globals.ProjectNO;
            if (drs != DialogResult.OK)
            {
                ToolStripComboBox c1 = (ToolStripComboBox)myToolStrip1.Items["toolProjCombox"];
                c1.Items.Clear();
                this.btnExit.Enabled = true;
            }
            else
            {
                ToolStripComboBox c1 = (ToolStripComboBox)myToolStrip1.Items["toolProjCombox"];
                c1.Items.Clear();

                BLL.T_Projects_BLL projBLL = new ERM.BLL.T_Projects_BLL();
                IList<MDL.T_Projects> projList =
                    projBLL.GetAll();

                ArrayList projname_list =
                    new ArrayList();

                foreach (MDL.T_Projects obj in projList)
                {
                    //c1.Items.Add(obj.ProjectNO);
                    projname_list.Add(obj.ProjectNO + "|" + obj.projectname + "|" + obj.ajdh);
                    c1.Items.Add(obj.projectname);
                }
                c1.Tag = projname_list;
                c1.Text = Globals.Projectname;
                ReadWriteAppConfig config = new ReadWriteAppConfig();
                config.Write("Current_Project", Globals.ProjectNO);
                config.Write("Current_ProjectAjdh", Globals.Ajdh);
            }
        }
        /// <summary>
        /// ���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            tsmiArichive_Click(sender, e);
        }
        /// <summary>
        /// �������� �ı��¼�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolProjCombox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ToolStripComboBox c1 = (ToolStripComboBox)myToolStrip1.Items["toolProjCombox"];

            ArrayList projName_list = c1.Tag as ArrayList;
            if (projName_list != null && projName_list.Count > 0)
            {
                foreach (string proj in projName_list)
                {
                    string[] projString = proj.Split(new char[] { '|' });
                    if (projString != null && projString[1] == c1.Text.Trim())
                    {
                        Globals.Ajdh = projString[2];
                        Globals.Projectname = projString[1];
                        Globals.ProjectNO = projString[0];
                        break;
                    }
                }
                this.btnFileCreate.Enabled = true;
                this.toolStripButton2.Enabled = true;
                this.btnProjectMaint.Enabled = true;
                this.btnProjectArchive.Enabled = true;
                this.btnChangePass.Enabled = true;
                this.myMenuStrip1.Enabled = true;
                this.btnProjectSelect.Enabled = true;
                this.toolProjCombox.Enabled = true;
                this.btnExit.Enabled = true;

                this.Text = Globals.AppTitle + " - " + Globals.Projectname;
                ReadWriteAppConfig config = new ReadWriteAppConfig();
                config.Write("Current_Project", Globals.ProjectNO);
                config.Write("Current_ProjectAjdh", Globals.Ajdh);

                Globals.CreateProjectPath();
            }
            else
            {
                this.btnFileCreate.Enabled = false;
                this.toolStripButton2.Enabled = false;
                this.btnProjectMaint.Enabled = false;
                this.btnProjectArchive.Enabled = false;
                this.btnChangePass.Enabled = false;
                this.myMenuStrip1.Enabled = false;
                this.btnProjectSelect.Enabled = true;
                this.toolProjCombox.Enabled = false;
                this.btnExit.Enabled = false;
            }
        }
        /// <summary>
        /// ��ʱ��֤Key
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Ukey_timer_Tick(object sender, EventArgs e)
        {
            //if (MyCommon.IsCheckFD())
            //{
            //    string DoResult = ERM.UI.WriteDog.DoReader();//������ǰ��Key
            //    if (DoResult != "")
            //    {
            //        if (!ERM.UI.FDKey.CheckUserKey(Ukey_timer))
            //        {
            //            frmLogin frm = new frmLogin();
            //            this.Hide();
            //            DialogResult ret = frm.ShowDialog();
            //            if (ret == DialogResult.OK)
            //            {
            //                this.Show();
            //                tssLabel3.Text = "��ǰ�û���" + Globals.LoginUser;  //��ǰ�û�
            //                CheckRights();
            //                this.Activate();
            //                Ukey_timer.Start();
            //            }
            //            else
            //            {
            //                this.FormClosing -= new FormClosingEventHandler(this.frmWelcome_FormClosing);
            //                this.Close();
            //            }
            //        }
            //    }
            //}
        }
        /// <summary>
        /// �ط��淶
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenu_Click(object sender, EventArgs e)
        {
            MyCommon.OpenDocument(Application.StartupPath + "\\�ط��淶\\" + ((System.Windows.Forms.ToolStripDropDownItem)(sender)).Text);
        }
        /// <summary>
        /// ���ҹ淶
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenu2_Click(object sender, EventArgs e)
        {
            MyCommon.OpenDocument(Application.StartupPath + "\\���ҹ淶\\" + ((System.Windows.Forms.ToolStripDropDownItem)(sender)).Text);
        }
        /// <summary>
        /// ģ�����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ts_SReportHelp_Click(object sender, EventArgs e)
        {
            MyCommon.OpenDocument(Application.StartupPath + "\\Cell.chm");
        }
        #endregion

        #region �Զ��庯��
        /// <summary>
        /// ҳ��Ȩ�ް�
        /// </summary>
        private void FromBind()
        {
            //��Դ�ñ�
            if (!MyCommon.CheckMenuState("1"))
            {
                btnFileCreate.Visible = false;
                tsmiFileLoe.Visible = false;
            }
            //�ļ��Ǽ�
            if (!MyCommon.CheckMenuState("2"))
            {
                btnProjectMaint.Visible = false;
                tsmiProjectMaint.Visible = false;
            }
            //���
            if (!MyCommon.CheckMenuState("3"))
            {
                toolStripButton2.Visible = false;
                tsmiArichive.Visible = false;
            }
            //�����ƽ�
            if (!MyCommon.CheckMenuState("4"))
            {
                btnProjectArchive.Visible = false;
                toolStripMenuItem2.Visible = false;
            }
        }
        private void CheckRights()
        {
            if (Globals.LoginUser.ToLower() == "admin" || Globals.LoginUser.ToLower() == "����Ա")
            {
                tsmiUsers.Enabled = true;
            }
            else
            {
                tsmiUsers.Enabled = false;
            }
        }
        /// <summary>
        /// ��鱾����װOffiec�汾 
        /// ��תdocxʱ�����밲װ2007���ϰ汾
        /// </summary>
        /// <returns>bool</returns>
        private bool CheckSystemOffice()
        {
            bool ifused = false;
            RegistryKey rk = Registry.LocalMachine;
            RegistryKey office2010 = rk.OpenSubKey(@"SOFTWARE\\Microsoft\\Office\\14.0");//\\Word\\InstallRoot\\
            //office2007
            RegistryKey office2007 = rk.OpenSubKey(@"SOFTWARE\\Microsoft\\Office\\12F.0");//\\Word\\InstallRoot\\
            ////office 2003
            //RegistryKey office2003 = rk.OpenSubKey(@"SOFTWARE\\Microsoft\\Office\\11.0\\Word\\InstallRoot\\");
            ////office 97
            //RegistryKey office97 = rk.OpenSubKey(@"SOFTWARE\\Microsoft\\Office\\8.0\\Word\\InstallRoot\\");
            ////office 2000
            //RegistryKey office2000 = rk.OpenSubKey(@"SOFTWARE\\Microsoft\\Office\\9.0\\Word\\InstallRoot\\");
            ////office xp
            //RegistryKey officexp = rk.OpenSubKey(@"SOFTWARE\\Microsoft\\Office\\10.0\\Word\\InstallRoot\\");
            //��鱾���Ƿ�װOffice2010
            if (office2010 != null)
            {
                //string file03 = office2010.GetValue("Path").ToString();
                //if (File.Exists(file03 + "Excel.exe"))
                {
                    ifused = true;
                }
            }
            if (office2007 != null)
            {
                //string file2007 = officexp.GetValue("Path").ToString();
                //if (File.Exists(file2007 + "Excel.exe"))
                {
                    ifused = false;
                }
            }
            //if (officexp != null)
            //{
            //    string filexp = officexp.GetValue("Path").ToString();
            //    if (File.Exists(filexp + "Excel.exe"))
            //    {
            //        istrue = false;
            //    }
            //}
            //if (office2000 != null)
            //{
            //    string file2000 = officexp.GetValue("Path").ToString();
            //    if (File.Exists(file2000 + "Excel.exe"))
            //    {
            //        istrue = false;
            //    }
            //}
            //if (office97 != null)
            //{
            //    string file97 = officexp.GetValue("Path").ToString();
            //    if (File.Exists(file97 + "Excel.exe"))
            //    {
            //        istrue = false;
            //    }
            //}
            return ifused;
        }
        #endregion

        private void myToolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void miniToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void lbCurrentProj_Click(object sender, EventArgs e)
        {

        }

        private void frmMDIMain_MdiChildActivate(object sender, EventArgs e)
        {
           
        }

        private void frmMDIMain_Deactivate(object sender, EventArgs e)
        {
           
        }

       
        private void tsmiGdGd_Click(object sender, EventArgs e)
        {
            
        }

        /// <summary>
        /// �鵵Ŀ¼����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiGdml_Click(object sender, EventArgs e)
        {
           
        }

        /// <summary>
        /// �鵵�ļ�����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiFileGd_Click(object sender, EventArgs e)
        {
            frmGdList gd = new frmGdList();
            gd.ShowDialog();
        }

        /// <summary>
        /// �鵵Ŀ¼����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmimlgd_Click(object sender, EventArgs e)
        {
            frmGdmlList ml = new frmGdmlList();
            ml.ShowDialog();
        }
    }
}