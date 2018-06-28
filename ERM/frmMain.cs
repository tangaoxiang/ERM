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
using DigiPower.ERM.Common;
namespace DigiPower.ERM
{
    public partial class frmWelcome : Form
    {
        public frmWelcome()
        {
            InitializeComponent();
            this.Text = Globals.AppTitle;                       //窗体标题
            tssLabel1.Text = Globals.NormalStatus;              //就绪
            tssLabel2.Text = Globals.AppTitle;                  //应用程序标题
            tssLabel3.Text = "当前用户：" + Globals.LoginUser;  //当前用户
            this.CheckRights();
        }
        private void CheckRights()
        {
            if (Globals.LoginUser.ToLower() == "admin")
            {
                btnUser.Enabled = true;
                tsmiUsers.Enabled = true;
            }
            else
            {
                btnUser.Enabled=false;
                tsmiUsers.Enabled = false;
            }
        }
        private void frmWelcome_Load(object sender, EventArgs e)
        {
            tsmiProjectSelect.PerformClick();
        }
        /// <summary>
        ///  关闭窗体引发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmWelcome_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DigiPower.ERM.Common.Functions.ShowQuestion("您确定要退出系统吗？") == DialogResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                System.Diagnostics.Process.GetCurrentProcess().Kill();//杀死应用程序进程
            }
        }
        private void tsmiExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void tsmiProjectArchive_Click(object sender, EventArgs e)
        { }
        private void tsmiChangePass_Click(object sender, EventArgs e)
        {
            frmChangeUserPasswd frm = new frmChangeUserPasswd();
            DialogResult ret = frm.ShowDialog();
            if (ret == DialogResult.OK)
            {
                MessageBox.Show(SystemTips.MSG_EDIT_PW_SUCC, SystemTips.MSG_TITLE);
            }
        }
        private void tsmiReLogin_Click(object sender, EventArgs e)
        {
            frmLogin frm = new frmLogin();
            this.Hide();
            DialogResult ret = frm.ShowDialog();
            if (ret == DialogResult.OK)
            {
                this.Show();
                tssLabel3.Text = "当前用户：" + Globals.LoginUser;  //当前用户
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
            if (1==2)
            {
                MessageBox.Show("未找到加密锁,请插入加密锁后,再进行操作！");
                return;
            }
            this.Cursor = Cursors.WaitCursor;
            frmUsersList frm = new frmUsersList();
            this.Cursor = Cursors.Default;
            frm.ShowDialog();
        }
        private void tsmiRef_Click(object sender, EventArgs e)
        {
        }
        private void tsmiPageSize_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            frmPageSizeList frm = new frmPageSizeList();
            this.Cursor = Cursors.Default;
            frm.ShowDialog();
        }
        private void tsmiNetSetup_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            frmNetSet frm = new frmNetSet();
            this.Cursor = Cursors.Default;
            frm.ShowDialog();
        }
        private void tsmiCategory_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            frmCategory frm = new frmCategory(false);
            this.Cursor = Cursors.Default;
            frm.ShowDialog();
        }
        private void tsmiDistrict_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            frmDistrictList frm = new frmDistrictList();
            this.Cursor = Cursors.Default;
            frm.ShowDialog();
        }
        private void tsmiAbout_Click(object sender, EventArgs e)
        {
            (new frmAbout()).ShowDialog();
        }
        private void tsmiHelpMain_Click(object sender, EventArgs e)
        {
            Functions.OpenDocument(Application.StartupPath + "\\help.chm");
        }
        private void tsmiSReport_Click(object sender, EventArgs e)
        {
            Functions.OpenDocument(Application.StartupPath + "\\SReport.exe");
        }
        private void tsmiRegister_Click(object sender, EventArgs e)
        {
        }
        private void tsmiUpgrade_Click(object sender, EventArgs e)
        {
            Process.Start(Application.StartupPath + "\\AutoUpdate.exe");
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            tsmiNew_Click(null, null);
        }
        private void btnProjectMaint_Click(object sender, EventArgs e)
        {
            if (1==2)
            {
                MessageBox.Show("未找到加密锁,请插入加密锁后,再进行操作！");
                return;
            }
            tsmiProjectMaint.PerformClick();
        }
        private void btnChangePass_Click(object sender, EventArgs e)
        {
            if (1==2)
            {
                MessageBox.Show("未找到加密锁,请插入加密锁后,再进行操作！");
                return;
            }
            tsmiChangePass.PerformClick();
        }
        private void btnSetup_Click(object sender, EventArgs e)
        {
            tsmiUsers.PerformClick();
        }
        private void btnHelp_Click(object sender, EventArgs e)
        {
            tsmiHelpMain.PerformClick();
        }
        private void tsmiNew_Click(object sender, EventArgs e)
        {
            if (1==2)
            {
                MessageBox.Show("未找到加密锁,请插入加密锁后,再进行操作！");
                return;
            }
            this.Cursor = Cursors.WaitCursor;
            string projectno = Globals.OpenedProjectNo;//主键值
            frmProject frmProject = new frmProject(projectno,true);
            frmProject.ShowDialog();
            this.Cursor = Cursors.Default;
            if (frmProject.HasChange)
            { 
            }
        }
        /// <summary>
        /// 施工用表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiFileLoe_Click(object sender, EventArgs e)
        {
            if (1==2)
            {
                MessageBox.Show("未找到加密锁,请插入加密锁后,再进行操作！");
                return;
            }
            this.Cursor = Cursors.WaitCursor;
            frmMain frm = new frmMain(this);
            frm.Show();
            this.Cursor = Cursors.Default;
            this.Hide();
        }
        /// <summary>
        /// 文件登记
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiProjectMaint_Click(object sender, EventArgs e)
        {
            if (1==2)
            {
                MessageBox.Show("未找到加密锁,请插入加密锁后,再进行操作！");
                return;
            }
            this.Cursor = Cursors.WaitCursor;
            frmFileAdd mainForm = new frmFileAdd(this);
            mainForm.Show();
            this.Cursor = Cursors.Default;
            this.Hide();
        }
        /// <summary>
        ///组卷
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiArichive_Click(object sender, EventArgs e)
        {
            if (1==2)
            {
                MessageBox.Show("未找到加密锁,请插入加密锁后,再进行操作！");
                return;
            }
            this.Cursor = Cursors.WaitCursor;
            frmArchive mainForm = new frmArchive(this);  //初始化资料组卷主窗 传入父窗体
            mainForm.Show();
            this.Cursor = Cursors.Default;
            this.Hide();
        }
        DigiPower.ERM.CBLL.Users usersDBC = new DigiPower.ERM.CBLL.Users();
        /// <summary>
        /// XP界面风格
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiThemeXP_Click(object sender, EventArgs e)
        {
            if (!tsmiThemeXP.Checked)
            {
                tsmiThemeXP.Checked = true;
                tsmiThemeOffice2003.Checked = false;
                usersDBC.SetTheme(Globals.LoginUser, Themes.XP);//更新用户的风格
                Functions.ApplyTheme(Themes.XP); //1 表示XP
            }
        }
        /// <summary>
        /// Office2003界面风格
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiThemeOffice2003_Click(object sender, EventArgs e)
        {
            if (!tsmiThemeOffice2003.Checked)
            {
                tsmiThemeOffice2003.Checked = true;
                tsmiThemeXP.Checked = false;
                usersDBC.SetTheme(Globals.LoginUser, Themes.Office2003);//更新用户的风格
                Functions.ApplyTheme(Themes.Office2003);//2 表示Office2003
            }
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            tsmiExit_Click(null, null);
        }
        private void btnChangePass_Click_1(object sender, EventArgs e)
        {
            btnChangePass_Click(null, null);
        }
        private void btnUser_Click(object sender, EventArgs e)
        {
            tsmiUsers_Click(null, null);
        }
        private void btnProjectMange_Click(object sender, EventArgs e)
        {
            btnNew_Click(null, null);
        }
        private void btnFileCreate_Click(object sender, EventArgs e)
        {
            tsmiFileLoe_Click(null, null);
        }
        /// <summary>
        /// 组卷
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnProjectArchive_Click(object sender, EventArgs e)
        {
            tsmiArichive_Click(null, null);
        }
        /// <summary>
        /// 重新登录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            tsmiReLogin_Click(null, null);
        }
        private void tsmiGB_Click(object sender, EventArgs e)
        {
            Functions.OpenDocument(Application.StartupPath + "\\整理规范.chm");
        }
        private void tsmiShengShenB_Click(object sender, EventArgs e)
        {
            Functions.OpenDocument(Application.StartupPath + "\\著录规范.chm");
        }
        private void tsmiJianArchB_Click(object sender, EventArgs e)
        {
            Functions.OpenDocument(Application.StartupPath + "\\建设电子文件与电子档案管理规范.chm");
        }
        private void tsmiDagDh_Click(object sender, EventArgs e)
        {
            frmDagdm frm = new frmDagdm();
            frm.ShowDialog();
        }
        private void tsmiProjectSelect_Click(object sender, EventArgs e)
        {
            if (1==2)
            {
                MessageBox.Show("未找到加密锁,请插入加密锁后,再进行操作！");
                return;
            }
            this.Cursor = Cursors.WaitCursor;
            frmProjectSelect frm = new frmProjectSelect();
             DialogResult drs= frm.ShowDialog();
            this.Text= Globals.AppTitle + " - " + Globals.OpenedProjectNo;
             if (drs != DialogResult.OK)
             {
                 this.btnProjectMange.Enabled = false;
                 this.btnFileCreate.Enabled = false;
                 this.btnProjectMaint.Enabled = false;
                 this.btnProjectArchive.Enabled = false;
                 this.btnUser.Enabled = false;
                 this.btnChangePass.Enabled = false;
                 this.myMenuStrip1.Enabled = false;
                 this.btnProjectSelect.Enabled = true;
             }
             else
             {
                 this.btnProjectMange.Enabled = true;
                 this.btnFileCreate.Enabled = true;
                 this.btnProjectMaint.Enabled = true;
                 this.btnProjectArchive.Enabled = true;
                 this.btnUser.Enabled = true;
                 this.btnChangePass.Enabled = true;
                 this.myMenuStrip1.Enabled = true;
             }
             this.Cursor = Cursors.Default;
        }
        private void tsmiSingtrueSet_Click(object sender, EventArgs e)
        {
            frmAddSignature frm = new frmAddSignature();
            frm.ShowDialog();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            tsmiProjectSelect.PerformClick();
        }
        private  XmlDoc xmlDoc;
        string xmlFile = "Update.xml";
        string serverUrl = "";
        string lastUpdate = "";
        string lastUpdateInServer = "";
        private string tempUpdatePath = "";
        private void trmCheckVer_Tick(object sender, EventArgs e)
        {
        }
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            if (!this.ReadLocalXML())
                return;
            if (!this.DownLoadServerXML())
                return;
            if (!this.ReadServerXML())
                return;
            if (!this.CheckNewVersion())
                return;
        }
        private bool ReadLocalXML()
        {
            try
            {
                xmlDoc = new XmlDoc(Application.StartupPath + "\\" + xmlFile);
                serverUrl = xmlDoc.GetNodeValue("/autoupdater/url");
                if (!serverUrl.EndsWith("/")) serverUrl += "/";
                lastUpdate = xmlDoc.GetNodeValue("/autoupdater/lastupdate");
                return true;
            }
            catch
            {
                return false;
            }
        }
        private bool DownLoadServerXML()
        {
            try
            {
                tempUpdatePath = Environment.GetEnvironmentVariable("Temp") + "\\" + "_ERM";
                if (!Directory.Exists(tempUpdatePath))
                    Directory.CreateDirectory(tempUpdatePath);
                WebRequest req;
                WebResponse res;
                try
                {
                    req = WebRequest.Create(serverUrl + xmlFile);
                    req.Timeout = 10000;
                    res = req.GetResponse();
                }
                catch (Exception ex)
                {
                    return false;
                }
                if (res.ContentLength > 0)
                {
                    WebClient wClient = new WebClient();
                    wClient.DownloadFile(serverUrl + xmlFile, tempUpdatePath + "\\" + xmlFile);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        private bool ReadServerXML()
        {
            try
            {
                xmlDoc = new XmlDoc(tempUpdatePath + "\\" + xmlFile);
                lastUpdateInServer = xmlDoc.GetNodeValue("/autoupdater/lastupdate");
                Directory.Delete(tempUpdatePath, true);
                return true;
            }
            catch
            {
                return false;
            }
        }
        private bool CheckNewVersion()
        {
            try
            {
                DateTime d1 = DateTime.Parse(lastUpdate);
                DateTime d2 = DateTime.Parse(lastUpdateInServer);
                if (d2 > d1)
                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }
        private void tsMenuItemRef1_Click(object sender, EventArgs e)
        {
            Functions.OpenDocument(Application.StartupPath + "\\整理规范.chm");
        }
        private void tsMenuItemRef2_Click(object sender, EventArgs e)
        {
            Functions.OpenDocument(Application.StartupPath + "\\著录规范.chm");
        }
        private void tsMenuItemRef3_Click(object sender, EventArgs e)
        {
            Functions.OpenDocument(Application.StartupPath + "\\建设电子文件与电子档案管理规范.chm");
        }
        /// <summary>
        /// 数据备份
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsMemuBackup_Click(object sender, EventArgs e)
        {
            Data.frmBackup frmbackup = new DigiPower.ERM.Data.frmBackup();
            frmbackup.ShowDialog();
        }
        /// <summary>
        /// 数据恢复
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsMenuRecover_Click(object sender, EventArgs e)
        {
            Data.frmRecover frmrecover = new DigiPower.ERM.Data.frmRecover();
            frmrecover.ShowDialog();
        }
    }
}
