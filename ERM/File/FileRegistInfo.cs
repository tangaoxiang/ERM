using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using ERM.CBLL;
using ERM.MDL;
using ERM.Common;
using TX.Framework.WindowUI.Forms;
using ERM.UI.Controls;
namespace ERM.UI
{
    public partial class FileRegistInfo : UserControl
    {
        [DllImport("user32.dll")]
        public static extern void keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);
        ITreeFactory treeFactory;
        public bool flag1 = true;
        public bool flag2 = true;
        public FileRegistInfo()
        {
            InitializeComponent();
            SetControl();
            BindUnit();
        }
        public FileRegistInfo(bool siVisale, ITreeFactory Itree)
        {
            InitializeComponent();
            SetControls(siVisale);
            treeFactory = Itree;
            BindUnit();
        }
        /// <summary>
        /// ��λ��
        /// </summary>
        private void BindUnit()
        {
            IList<MDL.T_Units> dsbxdw = (new BLL.T_Units_BLL()).FindByProjectNO(Globals.ProjectNO);
            cmbzrz.Text = "";
            cmbzrz.Items.Clear();
            string zcb = "";
            if (dsbxdw.Count > 0)
            {
                for (int i = 0; i < dsbxdw.Count; i++)
                {
                    if (dsbxdw[i].unittype == "unit4")
                        zcb = dsbxdw[i].dwmc;
                    else
                        this.cmbzrz.Items.Add(dsbxdw[i].dwmc);
                }
            }
            this.cmbzrz.Items.Insert(0, zcb);
        }
        void SetControl()
        {
            //this.bgqx.Text = "����";
           // this.mj.Text = "�ڲ�";
            this.gg.Text = "A4";
            this.gb.Text = "����";
           // this.wjlx.Text = "�ı��ļ�(T)";
           // this.sb.Text = "��ɫ";
           // this.cmb_wjlx.Text = "ֽ��";
            this.ztlx.Text = "";
            this.cmbzrz.SelectedText = Globals.ZRR;
        }
        public void SetControls(bool isVisale)
        {
            //foreach (Control C in tableLayoutPanel1.Controls)
            //{
            //    setControls(C, isVisale);
            //}
            foreach (Control C in tableLayoutPanel2.Controls)
            {
                setControls(C, isVisale);
            }
            //foreach (Control C in tableLayoutPanel3.Controls)
            //{
            //    setControls(C, isVisale);
            //}
        }
        private static void setControls(Control C, bool isVisale)
        {
            if (!isVisale)
            {
                if (C.GetType() == typeof(TextBox))
                {
                    ((TextBox)C).ReadOnly = true;
                }
                if (C.GetType() == typeof(ComboBox))
                {
                    ((ComboBox)C).Enabled = false;
                }
                if (C.GetType() == typeof(DateTimePicker))
                {
                    ((DateTimePicker)C).Enabled = false;
                }
                if (C.GetType() == typeof(NumberTextBoxEX))
                {
                    ((NumberTextBoxEX)C).ReadOnly = true;
                }
            }
            else
            {
                if (C.GetType() == typeof(TextBox))
                {
                    ((TextBox)C).ReadOnly = false;
                }
                if (C.GetType() == typeof(ComboBox))
                {
                    ((ComboBox)C).Enabled = true;
                }
                if (C.GetType() == typeof(DateTimePicker))
                {
                    ((DateTimePicker)C).Enabled = true;
                }
                if (C.GetType() == typeof(NumberTextBoxEX))
                {
                    ((NumberTextBoxEX)C).ReadOnly = false;
                }
            }
        }
        
        public void ShowData(TreeNode obj)
        {
            TreeNodeEx newNode = new TreeNodeEx();
            newNode.Name = obj.Name;
            newNode.Tag = obj.Tag;
            ShowData(newNode);
        }
        public string getzrz()
        {
            IList<MDL.T_Units> dsbxdw = (new BLL.T_Units_BLL()).FindByProjectNO(Globals.ProjectNO);
            string zcbtmp = "";
            if (dsbxdw.Count > 0)
            {
                for (int i = 0; i < dsbxdw.Count; i++)
                {
                    if (dsbxdw[i].unittype == "unit4")
                        zcbtmp = dsbxdw[i].dwmc;
                }
            }
            return zcbtmp;
        }
        public void ShowData(TreeNodeEx NewNode)
        {
            BLL.T_FileList_BLL fileBLL = new ERM.BLL.T_FileList_BLL();
            MDL.T_FileList fileMDL = fileBLL.Find(NewNode.Name, Globals.ProjectNO);
            if (fileMDL == null)//û�еǼ��ļ�Ҳ����ʾ��|| fileMDL.fileStatus == "3"
                return;
            this.wjtm.Text = fileMDL.wjtm;
            if (fileMDL.zrr != null && fileMDL.zrr != "")
            {
                this.cmbzrz.Text = fileMDL.zrr;
            }
            else
            {
                this.cmbzrz.Text = getzrz();
            }
            this.wh.Text = fileMDL.wh;
           // this.bgqx.Text = fileMDL.bgqx;
          //  this.mj.Text = fileMDL.mj;
            this.ztlx.Text = fileMDL.ztlx;
            
            //if ((!String.IsNullOrEmpty(fileMDL.CreateDate)) && fileMDL.CreateDate != "")
            //{
            //    this.dptCreateDate.Text = DateTime.Parse(fileMDL.CreateDate).ToString("yyyy-MM-dd");
            //}
            //else
            //{
            //    this.dptCreateDate.Text = "";

            //}
            //if ((!String.IsNullOrEmpty(fileMDL.CreateDate2)) && fileMDL.CreateDate2 != "")
            //{
            //    this.dptCreateDate2.Text = DateTime.Parse(fileMDL.CreateDate2).ToString("yyyy-MM-dd");
            //}
            //else
            //{
            //    this.dptCreateDate2.Text = "";
            //}

            //if (this.dptCreateDate.Text == "" && this.dptCreateDate2.Text == "")
            //{
            //    MDL.T_Projects projectMDL = (new BLL.T_Projects_BLL()).Find(Globals.ProjectNO);
            //    if (projectMDL != null)
            //    {
            //        this.dptCreateDate.Text = (projectMDL.begindate == null || projectMDL.begindate=="") ? "" : DateTime.Parse      ((projectMDL.begindate)).ToString("yyyy-MM-dd"); //��������
            //        this.dptCreateDate2.Text = (projectMDL.enddate == null || projectMDL.enddate == "") ? "" : DateTime.Parse(projectMDL.enddate).ToString("yyyy-MM-dd");
            //    }
            //}
            this.gg.Text = fileMDL.gg;
            this.gb.Text = fileMDL.wjgbdm;
            //this.wjlx.Text = fileMDL.wjlxdm;
           // this.wjgs.Text = fileMDL.wjgs;
            //this.wjdx.Text = fileMDL.wjdx;
            this.txtstys.Text = fileMDL.stys.ToString();
            this.txtWzys.Text = fileMDL.wzys.ToString();
            //this.psdd.Text = fileMDL.psdd;
            //this.dptpssj.TextEx = fileMDL.pssj;
            //this.psz.Text = fileMDL.psz;
            //this.fbl.Text = fileMDL.fbl;
            //this.xjpp.Text = fileMDL.xjpp;
            //this.xjxh.Text = fileMDL.xjxh;
            this.wh.Text = fileMDL.wh;
            //this.sb.Text = fileMDL.sb;
            this.fz.Text = fileMDL.bz;
            //this.wjmc.Text = fileMDL.wjmc;
            //this.FileID.Text = fileMDL.FileID;
            //this.wjbsm.Text = fileMDL.wjbsm;

           // this.cmb_wjlx.Text = fileMDL.wjlx;

            this.sl.Text = MyCommon.ToInt(fileMDL.sl).ToString();

            //this.wzz.Text = MyCommon.ToInt(fileMDL.wzz).ToString();// ��Ƭ�� ע��ͼ����=ͼֽ��+��ͼ��
            this.tzz.Text = MyCommon.ToInt(fileMDL.tzz).ToString();//ͼֽ��
            this.dtz.Text = MyCommon.ToInt(fileMDL.dtz).ToString();//��ͼ��
            this.txtWzys.Text = fileMDL.wzys.ToString();
            //this.dw.Text = MyCommon.ToInt(fileMDL.dw).ToString(); //ע��ͼ����=��Ƭ��+��Ƭ��
            this.zpz.Text = MyCommon.ToInt(fileMDL.zpz).ToString();//��Ƭ��  
            this.dpz.Text = MyCommon.ToInt(fileMDL.dpz).ToString();//��Ƭ��

            this.dptCreateDate.Text = fileMDL.CreateDate;
            this.dptCreateDate2.Text = fileMDL.CreateDate2;

            if (fileMDL.fileStatus == "0")//û�еǼ��ļ�Ҳ����ʾ��
            {
              //  this.bgqx.Text = "����";
               // this.mj.Text = "�ڲ�";
                this.ztlx.Text = "ֽ��";
                this.gg.Text = "A4";
                this.gb.Text = "����";
               // this.wjlx.Text = "�ı��ļ�(T)";
               // this.cmb_wjlx.Text = "ֽ��";
            }
            else
            {
               // this.bgqx.Text =fileMDL.bgqx;
               // this.mj.Text = fileMDL.mj;
                this.ztlx.Text = fileMDL.ztlx;
                this.gg.Text = fileMDL.gg;
                this.gb.Text = fileMDL.wjgbdm;
               // this.wjlx.Text =fileMDL.wjlxdm;
            }
        }
        public void ReSetValue(TreeNodeEx node)
        {
            FileRegist cbll = new FileRegist();
            this.wjtm.Text = node.Text.Substring(node.Text.LastIndexOf("]") + 1);
            this.wh.Text = "";
           // this.bgqx.Text = null;
           // this.bgqx.Text = "����";
          //  this.mj.Text = null;
          //  this.mj.Text = "�ڲ�";
           // this.cmb_wjlx.Text = "ֽ��";
            this.ztlx.Text = "";
            //this.dptCreateDate.Value = DateTime.Now;
            this.dptCreateDate.TextEx = "";
            this.dptCreateDate2.TextEx = "";//.Value = DateTime.Now;
            this.sl.Text = "";
            this.gg.SelectedText = null;
            this.gg.Text = "A4";
            this.gb.Text = null;
            this.gb.Text = "����";
            //this.wjlx.Text = null;
            //this.wjlx.Text = "�ı��ļ�(T)";
            //this.wjgs.Text = cbll.GetWJGS(Globals.ProjectNO, OpeartPath(node));
            //this.wjdx.Text = "";
            //this.psdd.Text = "";
            //this.dptpssj.TextEx = DateTime.Now.ToString();//Value = DateTime.Now;
            //this.psz.Text = "";
            //this.fbl.Text = "";
            //this.xjpp.Text = "";
            //this.xjxh.Text = "";
            //this.sb.Text = "";
            //this.sb.Text = "��ɫ";
            //this.fz.Text = "";
            //this.wjmc.Text = node.Text;
            //this.dw.Text = "0";
            //this.wzz.Text = "0";
            this.tzz.Text = "0";
            this.dtz.Text = "0";
            this.zpz.Text = "0";
            this.dpz.Text = "0";
            
        }
        public string SetValue(TreeNodeEx node, int index, string FileID, ITreeFactory itf)
        {
            T_FileList model = new T_FileList();
            model.TreePath = OpeartPath(node);
            model.wjcj = node.Level.ToString();
           // model.wjbsm = this.wjbsm.Text;
            if (!String.IsNullOrEmpty(node.Text) && node.Text.LastIndexOf("]") > 0)
            {
                model.wjtm = node.Text.Substring(node.Text.LastIndexOf("]") + 1);
            }
            else
            {
                model.wjtm = node.Text;
            }
            model.wjmc = model.wjtm;
           // model.wjlx =cmb_wjlx.Text;
            //if (this.dptCreateDate.CustomFormat == "")
            //{
            //    if (index == 0)
            //    {
            //        model.CreateDate = DateTime.Now.ToString();
            //    }
            //    else
            //    {
            //        model.CreateDate = dptCreateDate.Value.ToString();
            //    }
            //}

            if (index == 0)
            {
                model.CreateDate = DateTime.Now.ToString();
            }
            else
            {
                model.CreateDate = dptCreateDate.TextEx;
            }

            //if (this.dptCreateDate2.CustomFormat == "")
            //{
            //    model.CreateDate2 = dptCreateDate2.Value.ToString();
            //}
            model.CreateDate2 = dptCreateDate2.TextEx;

            model.ztlx = ztlx.Text;
            if (!String.IsNullOrEmpty(this.sl.Text))
            {
                model.sl = MyCommon.ToInt(this.sl.Text);
            }
            else
            {
                model.sl = 0;
            }
            model.gg = gg.Text.ToString();
           // model.bgqx = this.bgqx.Text;
           // model.mj = this.mj.Text;
            model.wjgbdm = this.gb.Text.Trim();
           // model.wjlxdm = this.wjlx.Text.Trim();
            //model.wjdx = this.wjdx.Text.Trim();
            model.stys = Convert.ToInt32(this.txtstys.Text.Trim());
            model.wzys = Convert.ToInt32(this.txtWzys.Text.Trim());
            //model.psdd = this.psdd.Text.Trim();
            //model.pssj = this.dptpssj.TextEx;//Value.ToShortDateString();
            //model.psz = this.psz.Text.Trim();
            //model.fbl = this.fbl.Text.Trim();
            //model.xjpp = this.xjpp.Text.Trim();
            //model.xjxh = this.xjxh.Text.Trim();
            //model.sb = this.sb.Text.Trim();
            //model.wjgs = this.wjgs.Text;
            model.bz = this.fz.Text;
            model.zrr = this.cmbzrz.SelectedText;
            model.fileStatus = "1";
            model.ProjectNO = Globals.ProjectNO;
            model.CreateDate = this.dptCreateDate.Text;
            model.CreateDate2= this.dptCreateDate2.Text;
         
            int nTzz = 0;
            int nDtz = 0;
            if (!String.IsNullOrEmpty(this.tzz.GetText))
            {
                nTzz = MyCommon.ToInt(this.tzz.GetText);
            }
            if (!String.IsNullOrEmpty(this.dtz.GetText))
            {
                nDtz = MyCommon.ToInt(this.dtz.GetText);
            }
            int TzResult = nTzz + nDtz;
            model.dw = TzResult.ToString();
            int nZpz = 0;
            int nDpz = 0;
            if (!String.IsNullOrEmpty(this.zpz.GetText))
            {
                nZpz = MyCommon.ToInt(this.zpz.GetText);
            }
            if (!String.IsNullOrEmpty(this.dpz.GetText))
            {
                nDpz = MyCommon.ToInt(this.dpz.GetText);
            }
            int ZpResult = nZpz + nDpz;
            model.wzz = ZpResult.ToString();
            if (String.IsNullOrEmpty(this.tzz.GetText))
            {
                model.tzz = "0";
            }
            else
            {
                model.tzz = this.tzz.GetText;
            }
            if (String.IsNullOrEmpty(this.dtz.GetText))
            {
                model.dtz = "0";
            }
            else
            {
                model.dtz = this.dtz.GetText;
            }
            if (String.IsNullOrEmpty(this.zpz.GetText))
            {
                model.zpz = "0";
            }
            else
            {
                model.zpz = this.zpz.GetText;
            }
            if (String.IsNullOrEmpty(this.dpz.GetText))
            {
                model.dpz = "0";
            }
            else
            {
                model.dpz = this.dpz.GetText;
            }
            if (!String.IsNullOrEmpty(FileID))
            {
                model.FileID = FileID;
            }
            else
            {
                model.FileID = Guid.NewGuid().ToString();
            }
            try
            {
                BLL.T_FileList_BLL fileBLL = new ERM.BLL.T_FileList_BLL();
                fileBLL.Update(model);
                return model.FileID;
            }
            catch
            {
                return null;
            }
        }
        /// <summary>
        /// ����ļ��Ǽ���Ϣ
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        /// <summary>
        /// ȥ��·���е�[0],*
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        private string OpeartPath(TreeNodeEx node)
        {
            BLL.T_FileList_BLL fileBLL = new ERM.BLL.T_FileList_BLL();
            return fileBLL.Find(node.Name, Globals.ProjectNO).filepath;
        }
        /// <summary>
        /// �ı�ʱ����ʾ��ʽ
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public string MakeTimeFormat(DateTime date)
        {
            return date.ToString("yyyy.mm.dd");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dw_KeyPress(object sender, KeyPressEventArgs e)
        {
            OnlyInt(e);
        }
        private void wzz_KeyPress(object sender, KeyPressEventArgs e)
        {
            OnlyInt(e);
        }
        private void tzz_KeyPress(object sender, KeyPressEventArgs e)
        {
            OnlyInt(e);
        }
        private void dtz_KeyPress(object sender, KeyPressEventArgs e)
        {
            OnlyInt(e);
        }
        private void zpz_KeyPress(object sender, KeyPressEventArgs e)
        {
            OnlyInt(e);
        }
        private void dpz_KeyPress(object sender, KeyPressEventArgs e)
        {
            OnlyInt(e);
        }
        /// <summary>
        /// ֻ��������
        /// </summary>
        /// <param name="e"></param>
        private void OnlyInt(KeyPressEventArgs e)
        {
            int n = MyCommon.ToInt(e.KeyChar);
            if (n < 48 || n > 57)
            {
                e.Handled = true;
            }
        }
        /// <summary>
        /// ����������֤
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bgqx_Validating(object sender, CancelEventArgs e)
        {
            ComboBox com = (ComboBox)sender;
            if (com.Text.Length > 51)
            {
                TXMessageBoxExtensions.Info("�������������ַ�����!");
            }
        }
        /// <summary>
        /// �ܼ���֤
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mj_Validating(object sender, CancelEventArgs e)
        {
            ComboBox com = (ComboBox)sender;
            if (com.Text.Length > 51)
            {
                TXMessageBoxExtensions.Info("�ܼ������ַ�����!");
            }
        }
        /// <summary>
        /// �ļ��屾��֤
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gb_Validating(object sender, CancelEventArgs e)
        {
            ComboBox com = (ComboBox)sender;
            if (com.Text.Length > 51)
            {
                TXMessageBoxExtensions.Info("�ļ��屾���������ַ�����!");
            }
        }
        /// <summary>
        /// �ļ����ʹ�����֤
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void wjlx_Validating(object sender, CancelEventArgs e)
        {
            ComboBox com = (ComboBox)sender;
            if (com.Text.Length > 51)
            {
                TXMessageBoxExtensions.Info("�ļ����ʹ��������ַ�����!");
            }
        }
        /// <summary>
        /// ɫ����֤
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sb_Validating(object sender, CancelEventArgs e)
        {
            ComboBox com = (ComboBox)sender;
            if (com.Text.Length > 51)
            {
                TXMessageBoxExtensions.Info("ɫ����֤�����ַ�����!");
            }
        }
        private void dptCreateDate2_CloseUp(object sender, EventArgs e)
        {
            flag2 = false;
            //dptCreateDate2.CustomFormat = "";
        }
        private void dptCreateDate_CloseUp(object sender, EventArgs e)
        {
            flag1 = false;
            //dptCreateDate.CustomFormat = "";
        }
        public void EnabledEx(bool b1)
        {
            Enabled = b1;
        }


        #region
        /**********************************************************************************************
         * ˵���������ļ��Ǽ��У��޸���Ŀ¼��ʾ�Ƿ� ������Ϣ
         *****************************************************************************/

        public bool isUpdateInfo_flg = false;
        private void wjtm_TextChanged(object sender, EventArgs e)
        {
            isUpdateInfo_flg = true;
        }

        private void zrr_TextChanged(object sender, EventArgs e)
        {
            isUpdateInfo_flg = true;
        }

        private void wh_TextChanged(object sender, EventArgs e)
        {
            isUpdateInfo_flg = true;
        }

        private void bgqx_SelectedIndexChanged(object sender, EventArgs e)
        {
            isUpdateInfo_flg = true;
        }

        private void mj_SelectedIndexChanged(object sender, EventArgs e)
        {
            isUpdateInfo_flg = true;
        }

        private void dptCreateDate_TextChanged(object sender, EventArgs e)
        {
            isUpdateInfo_flg = true;
        }

        private void dptCreateDate2_TextChanged(object sender, EventArgs e)
        {
            isUpdateInfo_flg = true;
        }

        private void ztlx_SelectedIndexChanged(object sender, EventArgs e)
        {
            isUpdateInfo_flg = true;
            switch (ztlx.Text)
            {
                case "ֽ��":
                    setEnable(true, false, false, false, false);
                    break;
                case "ͼֽ":
                    setEnable(false, true, false, false, false);
                    break;
                case "��ͼ":
                    setEnable(false, false, true, false, false);
                    break;
                case "��Ƭ":
                    setEnable(false, false, false, true, false);
                    break;
                case "��Ƭ":
                    setEnable(false, false, false, false, true);
                    break;
                default:
                    setEnable(false, false, false, false, false);
                    break;
            }
        }

        /// <summary>
        /// ����ͼֽ���Ϳ���״̬
        /// </summary>
        /// <param name="zz"></param>
        /// <param name="tz"></param>
        /// <param name="dt"></param>
        /// <param name="zp"></param>
        /// <param name="dp"></param>
        private void setEnable(bool zz,bool tz,bool dt,bool zp,bool dp) {
            this.tzz.ReadOnly = !tz;
            this.dtz.ReadOnly = !dt;
            this.zpz.ReadOnly = !zp;
            this.dpz.ReadOnly = !dp;
            this.txtWzys.ReadOnly = !zz;
        }

        private void tzz_TextChanged(object sender, EventArgs e)
        {
            isUpdateInfo_flg = true;
        }

        private void dtz_TextChanged(object sender, EventArgs e)
        {
            isUpdateInfo_flg = true;
        }

        private void zpz_TextChanged(object sender, EventArgs e)
        {
            isUpdateInfo_flg = true;
        }

        private void dpz_TextChanged(object sender, EventArgs e)
        {
            isUpdateInfo_flg = true;
        }

        private void psdd_TextChanged(object sender, EventArgs e)
        {
            isUpdateInfo_flg = true;
        }

        private void psz_TextChanged(object sender, EventArgs e)
        {
            isUpdateInfo_flg = true;
        }

        private void dptpssj_TextChanged(object sender, EventArgs e)
        {
            isUpdateInfo_flg = true;
        }

        private void sb_SelectedIndexChanged(object sender, EventArgs e)
        {
            isUpdateInfo_flg = true;
        }

        private void fbl_TextChanged(object sender, EventArgs e)
        {
            isUpdateInfo_flg = true;
        }

        private void xjpp_TextChanged(object sender, EventArgs e)
        {
            isUpdateInfo_flg = true;
        }

        private void xjxh_TextChanged(object sender, EventArgs e)
        {
            isUpdateInfo_flg = true;
        }

        private void fz_TextChanged(object sender, EventArgs e)
        {
            isUpdateInfo_flg = true;
        }
        #endregion

        private void dptCreateDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                keybd_event((byte)Keys.Tab,0,0,0);
            }
        }

        private void wjtm_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            wjtm.SelectAll();
        }

        private void dptCreateDate_Leave(object sender, EventArgs e)
        {
            //if (!MyCommon.RegexDate(dptCreateDate.Text.Trim()) && dptCreateDate.Text.Trim() != "")
            //{
            //    TXMessageBoxExtensions.Info("��������ȷ�����ڸ�ʽ(��-��-��)");
            //    dptCreateDate.Text = "";
            //    dptCreateDate.Focus();
            //}
        }

        private void dptCreateDate2_Leave(object sender, EventArgs e)
        {
            //if (!MyCommon.RegexDate(dptCreateDate2.Text.Trim()) && dptCreateDate2.Text.Trim()!="")
            //{
            //    TXMessageBoxExtensions.Info("��������ȷ�����ڸ�ʽ(��-��-��)");
            //    dptCreateDate2.Text = "";
            //    dptCreateDate2.Focus();
            //}
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblwth_Click(object sender, EventArgs e)
        {

        }        
    }
}
