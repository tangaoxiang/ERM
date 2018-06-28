using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ERM.Common;
using ERM.BLL;
using ERM.UI.Controls;
using ERM.MDL;
using TX.Framework.WindowUI.Forms;
using CCWin.SkinControl;
using TX.Framework.WindowUI;

namespace ERM.UI
{
    /// <summary>
    /// ������ϸ��Ϣ
    /// </summary>
    public partial class frmProjectInfo : Skin_DevEX
    {
        #region ������ʼ��
        private bool Welcome;
    
        /// <summary>
        /// ���̱������
        /// </summary>
        private string ProjectNO;
        public string ProjectNo
        {
            set { this.ProjectNO = value; }
            get { return this.ProjectNO; }
        }

        MDL.T_Projects projectMDL;
        ERM.MDL.T_Item itemMDL;
        //�û��ؼ��ӿڣ����ڽ��ղ�ͬʵ�����ؼ�����
        IProject obj = null;
        //��������ֵ�
        IList<MDL.T_Dict> ds3 = null;
        T_Point_BLL point_bll = new T_Point_BLL();
        T_Point point = new T_Point();
        #endregion

        #region ���庯��
        public frmProjectInfo(string _projectNo, bool _welcome)
        {
            InitializeComponent();
            this.ProjectNo = _projectNo;
            cPanel2.Dock = DockStyle.Fill;
            Welcome = _welcome;
            this.toolTip1.SetToolTip(this.txtProjectNo._TextBox, "���̱���ʱ���ǽ���������׼����ı��");
            this.toolTip1.SetToolTip(this.txtProjectName._TextBox, "�����빤������");
            this.toolTip1.SetToolTip(this.dtpEndDate._TextBox, "�������ձ�������\r\n(��ʽ��1900.01.01)");
            this.toolTip1.SetToolTip(this.dtpBeginDate._TextBox, "ʩ�����֤����\r\n(��ʽ��1900.01.01)");
            this.toolTip1.SetToolTip(this.txtAddress._TextBox, "�����빤�̵�ַ");
            this.toolTip1.SetToolTip(this.txtGhcode._TextBox, "���̹滮���֤");
            this.toolTip1.SetToolTip(this.txtSgcode._TextBox, "����ʩ�����֤��");
            PointDataBind();
        }
        private void frmProject_Load(object sender, EventArgs e)
        {
            Init();
        }
        /// <summary>
        /// ��λ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LinkLabel link = (LinkLabel)sender;
            ClearLinkBackColor();  //�������ɫ
            link.BackColor = Color.FromArgb(197,225,247);  //���ñ�����ɫ
            link.LinkColor = Color.Black;
            if (link.Name == "lblProjectInfo")
            {
                cPanel2.Visible = false;
            }
            else
            {
                cPanel2.Visible = true;
                if (link.Name == "lblUnitAll")
                {
                    txtUnittype.Text = "";
                    LoadDataFromView(string.Empty);
                }
                else
                {
                    txtUnittype.Text = link.Name.Replace("lbl", "").ToLower();  //��ǰ�ĵ�λ���
                    LoadDataFromView(link.Name.Replace("lbl", "").ToLower());
                }
            }
        }
        /// <summary>
        /// ������ɫ
        /// </summary>
        private void ClearLinkBackColor()
        {
            lblUnit1.BackColor = tableLayoutPanel1.BackColor;
            lblUnit2.BackColor = tableLayoutPanel1.BackColor;
            lblUnit3.BackColor = tableLayoutPanel1.BackColor;
            lblUnit4.BackColor = tableLayoutPanel1.BackColor;
            lblUnit6.BackColor = tableLayoutPanel1.BackColor;
            lblUnit15.BackColor = tableLayoutPanel1.BackColor;
            lblUnitAll.BackColor = tableLayoutPanel1.BackColor;
            for (int i=0;i<tableLayoutPanel1.Controls.Count;i++)
            {
                if (tableLayoutPanel1.Controls[i] is LinkLabel)
                {
                    (tableLayoutPanel1.Controls[i] as LinkLabel).LinkColor = Color.FromArgb(0, 56, 95);
                }
            }
        }
        private void btnDel_Click(object sender, EventArgs e)
        {
            if (Dgv1.Rows.Count == 0) {
                TXMessageBoxExtensions.Info("û�п�ɾ�������ݣ�");
                return;
            }
            if (Dgv1.CurrentRow.Index < 0) {
                TXMessageBoxExtensions.Info("��ѡ��һ�����ݽ���ɾ����");
                return;
            }
            if (TXMessageBoxExtensions.Question("��ʾ��ȷ��ɾ����") != DialogResult.OK)
                return;
            string unitid = Dgv1.Rows[Dgv1.CurrentRow.Index].Cells[0].Value.ToString(); //��ǰunitid
            (new BLL.T_Units_BLL()).Delete(unitid);
            this.LoadDataFromView(txtUnittype.Text);
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtProjectNo.Text.Trim()))
            {
                TXMessageBoxExtensions.Info("������д���̱�ţ�");
                this.tabControl1.SelectedTab = tabPage1;
                this.txtProjectNo.Focus();
                return;
            }
            frmUnit frm = new frmUnit(txtUnittype.Text, txtProjectNo.Text, "");

            DialogResult ret = frm.ShowDialog();
            if (ret == DialogResult.OK)
            {
                string unittype = frm.cboUnittype.SelectedValue.ToString();
                MDL.T_Units unitMDL = new ERM.MDL.T_Units();
                unitMDL.UnitID = Guid.NewGuid().ToString();
                unitMDL.unittype = unittype;
                unitMDL.ProjectNO = txtProjectNo.Text;
                if (string.Compare(unittype, "unit12", true) == 0 || string.Compare(unittype, "unit13", true) == 0)
                {
                    unitMDL.dwmc = frm.label5.Text;
                    unitMDL.fzr = MyCommon.ToSqlString(frm.txtOther.Text.Trim());
                    unitMDL.fzrzs = string.Empty;
                    unitMDL.xmjl = string.Empty;
                    unitMDL.zzdj = string.Empty;
                    unitMDL.zzzh = string.Empty;
                    unitMDL.addr = string.Empty;
                    unitMDL.tel = string.Empty;
                    unitMDL.fax = string.Empty;
                    unitMDL.remark = string.Empty;
                }
                else
                {
                    unitMDL.dwmc = MyCommon.ToSqlString(frm.txtDwmc.Text.Trim());
                    unitMDL.fzr = MyCommon.ToSqlString(frm.txtFzr.Text.Trim());
                    unitMDL.fzrzs = MyCommon.ToSqlString(frm.txtFzrzs.Text.Trim());
                    unitMDL.xmjl = MyCommon.ToSqlString(frm.txtXmjl.Text.Trim());
                    unitMDL.zzdj = MyCommon.ToSqlString(frm.txtZzdj.Text.Trim());
                    unitMDL.zzzh = MyCommon.ToSqlString(frm.txtZzzh.Text.Trim());
                    unitMDL.addr = MyCommon.ToSqlString(frm.txtAddr.Text.Trim());
                    unitMDL.tel = MyCommon.ToSqlString(frm.txtTel.Text.Trim());
                    unitMDL.fax = MyCommon.ToSqlString(frm.txtFax.Text.Trim());
                    unitMDL.remark = MyCommon.ToSqlString(frm.txtRemark.Text.Trim());
                }
                (new BLL.T_Units_BLL()).Add(unitMDL);
                this.LoadDataFromView(txtUnittype.Text);
            }
        }

        /// <summary>
        /// �󶨵�λ��Ϣ
        /// TYX 20170824
        /// </summary>
        private void BindUnit()
        {
            if (!string.IsNullOrEmpty(txtProjectNo.Text))
            {
                IList<MDL.T_Units> unitList = (new BLL.T_Units_BLL()).FindByProjectNO(txtProjectNo.Text);
                foreach (var item in unitList)
                {
                    switch (item.unittype)
                    {
                        case "unit1":
                            this.txtJsdw.Text = item.dwmc;
                            break;
                        case "unit15":
                            this.txtLxpzdw.Text = item.dwmc;
                            break;
                        case "unit3":
                            this.txtSjdw.Text = item.dwmc;
                            break;
                        case "unit2":
                            this.txtKcdw.Text = item.dwmc;
                            break;
                        case "unit4":
                            this.txtSgdw.Text = item.dwmc;
                            break;
                        case "unit6":
                            this.txtJldw.Text = item.dwmc;
                            break;
                    }
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (Dgv1.Rows.Count == 0)
            {
                TXMessageBoxExtensions.Info("û�пɱ༭�����ݣ�");
                return;
            }
            if (Dgv1.CurrentRow.Index < 0)
            {
                TXMessageBoxExtensions.Info("��ѡ��һ�����ݽ��б༭��");
                return;
            }
            string unitid = Dgv1.Rows[Dgv1.CurrentRow.Index].Cells[0].Value.ToString(); //��ǰunitid
            string unitType = Dgv1.Rows[Dgv1.CurrentRow.Index].Cells[1].Value.ToString();//��ǰ��λ����
            //BUG�޸�20170420�������ѡ�����ĵ�λ���ͻᵼ�±༭����ȥ�ĵ�λ����Ϊ�գ���Ϊ���Ϊ���򴫵�ǰѡ���еĵ�λ����
            frmUnit frm = new frmUnit(txtUnittype.Text == "" ? unitType : txtUnittype.Text, txtProjectNo.Text, unitid);
            DialogResult ret = frm.ShowDialog();  //open
            if (ret == DialogResult.OK)
            {
                MDL.T_Units unitMDL = (new ERM.BLL.T_Units_BLL()).Find(unitid);
                string unittype = frm.cboUnittype.SelectedValue.ToString();
                unitMDL.unittype = unittype;
                if (string.Compare(unittype, "unit12", true) == 0 || string.Compare(unittype, "unit13", true) == 0)
                {
                    unitMDL.dwmc = frm.label5.Text;
                    unitMDL.fzr = MyCommon.ToSqlString(frm.txtOther.Text.Trim());
                    unitMDL.fzrzs = string.Empty;
                    unitMDL.xmjl = string.Empty;
                    unitMDL.zzdj = string.Empty;
                    unitMDL.zzzh = string.Empty;
                    unitMDL.addr = string.Empty;
                    unitMDL.tel = string.Empty;
                    unitMDL.fax = string.Empty;
                    unitMDL.remark = string.Empty;
                }
                else
                {
                    unitMDL.dwmc = MyCommon.ToSqlString(frm.txtDwmc.Text.Trim());
                    unitMDL.fzr = MyCommon.ToSqlString(frm.txtFzr.Text.Trim());
                    unitMDL.fzrzs = MyCommon.ToSqlString(frm.txtFzrzs.Text.Trim());
                    unitMDL.xmjl = MyCommon.ToSqlString(frm.txtXmjl.Text.Trim());
                    unitMDL.zzdj = MyCommon.ToSqlString(frm.txtZzdj.Text.Trim());
                    unitMDL.zzzh = MyCommon.ToSqlString(frm.txtZzzh.Text.Trim());
                    unitMDL.addr = MyCommon.ToSqlString(frm.txtAddr.Text.Trim());
                    unitMDL.tel = MyCommon.ToSqlString(frm.txtTel.Text.Trim());
                    unitMDL.fax = MyCommon.ToSqlString(frm.txtFax.Text.Trim());
                    unitMDL.remark = MyCommon.ToSqlString(frm.txtRemark.Text.Trim());
                }
                (new ERM.BLL.T_Units_BLL()).Update(unitMDL);
                this.LoadDataFromView(txtUnittype.Text);
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            btnSave.Enabled = false;
            if (SaveData())
            {
                if (Welcome)//����
                {
                    BLL.BLLMore bllMore = new ERM.BLL.BLLMore();
                    bllMore.CopyFileList(txtProjectNo.Text,projectMDL.ProjectCategory);

                    Globals.Projectname = txtProjectName.Text.Trim();
                    Globals.ProjectNO = txtProjectNo.Text.Trim();
                }
                TXMessageBoxExtensions.Info("����ɹ���");
                this.Close();
            }
            btnSave.Enabled = true;
        }
        /// <summary>
        /// ��DataView�ĵ�λ��Ϣ���ݼ��ص�Grid��
        /// </summary>
        /// <param name="unittype">��λ���Ϊ�ձ�ʾȫ��</param>
        private void LoadDataFromView(string unittype)
        {
            IList<MDL.T_Units> unitList = (new BLL.T_Units_BLL()).FindByProjectNO(txtProjectNo.Text);
            Dgv1.Rows.Clear();
            foreach (MDL.T_Units obj in unitList)
            {
                if (unittype != "")
                {
                    if (obj.unittype != unittype)
                    {
                        continue;
                    }
                }

                if (obj.ProjectNO=="")
                {
                    (new BLL.T_Units_BLL()).Delete(obj.UnitID);
                    continue;
                }

                Dgv1.Rows.Add();
                Dgv1.Rows[Dgv1.Rows.Count - 1].Cells[0].Value = obj.UnitID;
                Dgv1.Rows[Dgv1.Rows.Count - 1].Cells[1].Value = obj.unittype;
                Dgv1.Rows[Dgv1.Rows.Count - 1].Cells[2].Value = obj.dwmc;
                Dgv1.Rows[Dgv1.Rows.Count - 1].Cells[3].Value = obj.fzr;
                Dgv1.Rows[Dgv1.Rows.Count - 1].Cells[4].Value = obj.fzrzs;
                Dgv1.Rows[Dgv1.Rows.Count - 1].Cells[5].Value = obj.xmjl;
                Dgv1.Rows[Dgv1.Rows.Count - 1].Cells[6].Value = obj.zzdj;
                Dgv1.Rows[Dgv1.Rows.Count - 1].Cells[7].Value = obj.zzzh;
                Dgv1.Rows[Dgv1.Rows.Count - 1].Cells[8].Value = obj.addr;
                Dgv1.Rows[Dgv1.Rows.Count - 1].Cells[9].Value = obj.tel;
                Dgv1.Rows[Dgv1.Rows.Count - 1].Cells[10].Value = obj.fax;
                Dgv1.Rows[Dgv1.Rows.Count - 1].Cells[11].Value = obj.remark;
            }
        }
        private void cboDistrict_TextChanged(object sender, EventArgs e)
        {
            ComboBox cbo = (ComboBox)sender;
            if (cbo.Text.Length > 20)
            {
                cbo.Text = cbo.Text.Substring(0, 20);
                cbo.SelectionStart = cbo.Text.Length;
            }
        }
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 3)
            {
                if (itemMDL == null)
                    itemMDL = new ERM.BLL.T_Item_BLL().Find(projectMDL.ItemID);
                if (itemMDL == null)
                {
                    txtConStructionProjectName.Text = itemMDL.ConStructionProjectName;
                    txtRespective.Text = cboDistrict.Text;
                    return;
                }
                loadItemInfo();
            }
        }

        private void loadItemInfo()
        {
            if (string.IsNullOrEmpty(itemMDL.ConStructionProjectName))
            {
                itemMDL.ConStructionProjectName = txtProjectName.Text;
            }
            if (string.IsNullOrEmpty(itemMDL.ConstructionProjectAdd))
            {
                itemMDL.ConstructionProjectAdd = txtAddress.Text;
            }
            if (string.IsNullOrEmpty(itemMDL.Respective))
            {
                itemMDL.Respective = cboDistrict.Text;
            }

            if (txtConStructionProjectName.Text.Trim() == "")
                txtConStructionProjectName.Text = itemMDL.ConStructionProjectName;
            if (txtRespective.Text.Trim() == "")
                txtRespective.Text = itemMDL.Respective;
            if (txtConstructionProjectAdd.Text.Trim() == "")
                txtConstructionProjectAdd.Text = itemMDL.ConstructionProjectAdd;
            if (txtProjectType.Text.Trim() == "")
                txtProjectType.Text = itemMDL.ProjectType;
            if (txtUseSoiAreaSum.Text.Trim() == "")
                txtUseSoiAreaSum.Text = itemMDL.UseSoiAreaSum;
            if (txtConstructionAreaSum.Text.Trim() == "")
                txtConstructionAreaSum.Text = itemMDL.ConstructionAreaSum;
            if (txtProjectCost.Text.Trim() == "")
                txtProjectCost.Text = itemMDL.ProjectCost;
            if (txtProjectSettlement.Text.Trim() == "")
                txtProjectSettlement.Text = itemMDL.ProjectSettlement;

            if (txtCreateUnit.Text.Trim() == "")
            {
                if (string.IsNullOrWhiteSpace(itemMDL.CreateUnit))
                {
                    MDL.T_Units units_mdl = GetJSDW();
                    if (!string.IsNullOrWhiteSpace(units_mdl.dwmc))
                    {
                        txtCreateUnit.Text = units_mdl.dwmc;
                    }
                }
                else
                {
                    txtCreateUnit.Text = itemMDL.CreateUnit;
                }
            }
            if (txtItemFzr.Text.Trim() == "")
            {
                if (string.IsNullOrWhiteSpace(itemMDL.ItemFzr))
                {
                    MDL.T_Units units_mdl = GetJSDW();
                    if (!string.IsNullOrWhiteSpace(units_mdl.fzr))
                    {
                        txtItemFzr.Text = units_mdl.fzr;
                    }
                }
                else
                {
                    txtItemFzr.Text = itemMDL.ItemFzr;
                }
            }
            if (txtAllCost.Text.Trim() == "")
                txtAllCost.Text = itemMDL.AllCost;
            if (txtVolumeFar.Text.Trim() == "")
                txtVolumeFar.Text = itemMDL.VolumeFar;
            if (txtVolumeFar.Text == "0")
                txtVolumeFar.Text = "";
            if (txtGreenFar.Text.Trim() == "")
                txtGreenFar.Text = itemMDL.GreenFar;
            if (txtGreenFar.Text == "0")
                txtGreenFar.Text = "";
            if (txtBuildingDensity.Text.Trim() == "")
                txtBuildingDensity.Text = itemMDL.BuildingDensity;
            if (txtBuildingDensity.Text == "0")
                txtBuildingDensity.Text = "";
            if (txtds.Text == "")
                txtds.Text = itemMDL.ds;
            if (this.txtzcd.Text == "")
                txtzcd.Text = itemMDL.zcd;

            if (this.txtTlsyCode.Text == "")
            txtTlsyCode.Text = itemMDL.TlsyCode;
            if (this.txtXmCode.Text == "")
            txtXmCode.Text = itemMDL.XmCode;
            if (this.txtYdghxkCode.Text == "")
            txtYdghxkCode.Text = itemMDL.YdghxkCode;
            if (this.txtTlcrnx.Text == "")
            txtTlcrnx.Text = itemMDL.Tlcrnx;

            if (this.txtPZDW.Text.Trim() == "")
            {
                if (string.IsNullOrWhiteSpace(itemMDL.pzdw))
                {
                    MDL.T_Units units_mdl = GetJSDW();
                    if (!string.IsNullOrWhiteSpace(units_mdl.dwmc))
                    {
                        txtPZDW.Text = units_mdl.dwmc;
                    }
                }
                else
                {
                    txtPZDW.Text = itemMDL.pzdw;
                }
            }
            if (this.txtpzh.Text == "")
                txtpzh.Text = itemMDL.pzh;
        }
        #endregion

        #region �Զ��庯��
        /// <summary>
        /// ����ҳ���
        /// </summary>
        private void ProjectBind()
        {
            //���̱��
            MyCommon.ShowTextBind(lbl_ProjectNO, "0");
            MyCommon.ShowTextBind(lbl_wh1, "1");
            MyCommon.ShowTextBind(lbl_wh2, "2");
            MyCommon.ShowTextBind(lbl_wh3, "3");
            MyCommon.ShowTextBind(lbl_wh4, "4");
        }
        private void Init()
        {
            ProjectBind();//ҳ��󶨷���
            ERM.BLL.T_Dict_BLL dicData = new ERM.BLL.T_Dict_BLL();
            BLL.District bll1 = new ERM.BLL.District();
            DataSet ds = bll1.GetAllList();
            cboDistrict.DisplayMember = "DistrictName";
            cboDistrict.ValueMember = "DistrictName";
            cboDistrict.DataSource = ds.Tables[0];
            if (cboDistrict.Items.Count > 0)
            {
                cboDistrict.SelectedIndex = 0;
            }

            ds3 = dicData.FindByKeyWord("ProjectCategory");
            cboProjectType.DisplayMember = "displayname";
            cboProjectType.ValueMember = "valuename";
            cboProjectType.DataSource = ds3;

            if (ProjectNo != "")  //�༭ģʽ
            {
                txtProjectNo.Enabled = false;//�޸�ʱ���������޸���Ŀ��ţ���֤Ψһ��
                this.cboProjectType.Enabled = false;

                //�޸� �ж��Ƿ���Ȩ���޸Ĺ��̱��������
                if (!MyCommon.CheckProjectBind())
                {
                    txtProjectNo.Enabled = false;
                    txtProjectName.Enabled = false;
                }

                projectMDL = (new BLL.T_Projects_BLL()).Find(ProjectNo);
                if (projectMDL != null)
                {
                    itemMDL = (new ERM.BLL.T_Item_BLL()).Find(projectMDL.ItemID);
                    loadItemInfo();
                    txtProjectNo.Text = projectMDL.ProjectNO; //���̴���
                    cboDistrict.Text = projectMDL.district == null ? "" : projectMDL.district; //����
                    txtProjectName.Text = projectMDL.projectname;  //��������
                    txtAddress.Text = projectMDL.address == null ? "" : projectMDL.address;  //���̵�ַ                    
                    cboProjectType.SelectedValue = projectMDL.ProjectCategory;
                    //txtYdpzcode.Text = projectMDL.ydpzcode == null ? "" : projectMDL.ydpzcode; //�����õ���׼���
                    txtYdghxkCode.Text = projectMDL.ydxkcode == null ? "" : projectMDL.ydxkcode; //�õع滮���֤��
                    txtGhcode.Text = projectMDL.ghcode == null ? "" : projectMDL.ghcode;  //�滮���֤��
                    txtSgcode.Text = projectMDL.sgcode == null ? "" : projectMDL.sgcode; //����ʩ�����֤��
                    txtysbah.Text = projectMDL.ajdh==null?"":projectMDL.ajdh;//���ձ�����
                    dtpBeginDate.TextEx = projectMDL.begindate == null ? "" : (projectMDL.begindate); //��������
                    dtpEndDate.TextEx = projectMDL.enddate == null ? "" : projectMDL.enddate;

                    //this.txtajdh.Text = projectMDL.ajdh.ToString();
                    this.cboProjectType.SelectedValue = projectMDL.ProjectCategory;//���ݹ���������ʾ��չ��Ϣ
                }
            }
            else
            {
                this.cboProjectType.SelectedIndex = 0;
                projectMDL = new ERM.MDL.T_Projects();
                itemMDL = new ERM.MDL.T_Item();
            }
            LoadDataFromView("");
            BindUnit();
        }

        /// <summary>
        /// �������ݰ�
        /// </summary>
        private void PointDataBind()
        {
            dgvPoint.Rows.Clear();
            IList<T_Point> list = new T_Point_BLL().GetList(this.ProjectNO);
            foreach (var item in list)
            {
                dgvPoint.Rows.Add();

                DataGridViewRow dgv = dgvPoint.Rows[dgvPoint.Rows.Count - 1];
                dgv.Cells[0].Value = item.ID;
                dgv.Cells[1].Value = item.OrderIndex;
                dgv.Cells[2].Value = item.X;
                dgv.Cells[3].Value = item.Y;
            }
        }

        /// <summary>
        /// ��Ŀ��Ϣ
        /// </summary>
        /// <param name="ItemID"></param>
        private void SetItemInfo(string itemID,int type=0)
        {
            itemMDL.ConStructionProjectName = MyCommon.ToSqlString2(txtConStructionProjectName.Text == "" ? txtProjectNo.Text : txtConStructionProjectName.Text);//��Ŀ����
            itemMDL.Respective = MyCommon.ToSqlString2(txtRespective.Text);//��������
            if (itemMDL.Respective == "" && cboDistrict.Text != "")
            {
                itemMDL.Respective = cboDistrict.Text;
            }

            itemMDL.ConstructionProjectAdd = MyCommon.ToSqlString2(txtConstructionProjectAdd.Text == "" ? txtAddress.Text : txtConstructionProjectAdd.Text);//��Ŀ��ַ
            itemMDL.TlsyCode = txtTlsyCode.Text;
            itemMDL.XmCode = txtXmCode.Text;
            itemMDL.YdghxkCode = txtYdghxkCode.Text;
            itemMDL.Tlcrnx = txtTlcrnx.Text;
            itemMDL.ProjectType = MyCommon.ToSqlString2(txtProjectType.Text);//��������           
            itemMDL.UseSoiAreaSum = txtUseSoiAreaSum.GetText;//���õ����
            itemMDL.ConstructionAreaSum = txtConstructionAreaSum.GetText;//�ܽ������            
            itemMDL.ProjectCost = txtProjectCost.GetText;//�ܽ���
            itemMDL.ProjectSettlement = txtProjectSettlement.GetText;//��Ԥ��
          
            itemMDL.CreateUnit = MyCommon.ToSqlString2(txtCreateUnit.Text);//���赥λ
            itemMDL.ItemFzr = MyCommon.ToSqlString2(txtItemFzr.Text);//��Ŀ������
            itemMDL.AllCost = txtAllCost.GetText;//�ܵؼ�
            itemMDL.GreenFar = txtGreenFar.Text;//�̻���
            itemMDL.VolumeFar = txtVolumeFar.Text;//�ݻ���
            itemMDL.BuildingDensity = txtBuildingDensity.Text;//�����ܶ�
            itemMDL.ds = txtds.GetText;
            if (type==0)
            {
                itemMDL.ItemID = itemID;
            }
            
            //��������������Ŀ��Ϣ
            itemMDL.pzh = txtpzh.Text;//��׼��
            itemMDL.zcd = txtzcd.Text;//�ܳ���
            itemMDL.pzdw = txtPZDW.Text;//��׼��λ
           
           
            if (string.IsNullOrEmpty(txtConstructionProjectAdd.Text))
            {
                txtConstructionProjectAdd.Text = txtAddress.Text;
            }
        }

        /// <summary>
        /// ����
        /// </summary>
        /// <returns></returns>
        private bool SaveData()
        {

            if (string.IsNullOrEmpty(this.txtConStructionProjectName.Text))
            {
                TXMessageBoxExtensions.Info("��ʾ����Ŀ���Ʋ���Ϊ�գ�");
                this.tabControl1.SelectedTab = tabPage4;
                txtConStructionProjectName.Focus();
                return false;
            }


            if (string.IsNullOrEmpty(this.txtConstructionProjectAdd.Text))
            {
                TXMessageBoxExtensions.Info("��ʾ����Ŀ��ַ����Ϊ�գ�");
                this.tabControl1.SelectedTab = tabPage4;
                txtConstructionProjectAdd.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(this.txtCreateUnit.Text))
            {
                TXMessageBoxExtensions.Info("��ʾ����Ŀ���赥λ����Ϊ�գ�");
                this.tabControl1.SelectedTab = tabPage4;
                txtCreateUnit.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(this.txtPZDW.Text))
            {
                TXMessageBoxExtensions.Info("��ʾ��������׼��λ����Ϊ�գ�");
                this.tabControl1.SelectedTab = tabPage4;
                txtPZDW.Focus();
                return false;
            }

            if (this.cboProjectType.SelectedIndex == -1)
            {
                TXMessageBoxExtensions.Info("��ʾ���������ͱ���ѡ��");
                this.tabControl1.SelectedTab = tabPage4;
                return false;
            }
            if (txtProjectNo.Text.Trim() == "")
            {
                TXMessageBoxExtensions.Info("��ʾ�����̱�ű�����д��");
                this.tabControl1.SelectedTab = tabPage1;
                this.txtProjectNo.Focus();
                return false;
            }
            if (!MyCommon.isYesProjectNo(txtProjectNo.Text.Trim()))
            {
                TXMessageBoxExtensions.Info("��ʾ�����̱�Ÿ�ʽ����\n����ܰ��ʾ�����̱��ֻ�����������֣���ĸ���»��ߣ����ߡ�");
                this.tabControl1.SelectedTab = tabPage1;
                txtProjectNo.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtProjectName.Text))
            {
                TXMessageBoxExtensions.Info("��ʾ���������Ʋ���Ϊ�գ�");
                this.tabControl1.SelectedTab = tabPage1;
                txtProjectName.Focus();
                return false;
            }

            if (cboDistrict.SelectedValue.ToString()==""||string.IsNullOrEmpty(this.txtAddress.Text))
            { 
                TXMessageBoxExtensions.Info("��ʾ�����̵�ַ����Ϊ�գ�");
                this.tabControl1.SelectedTab = tabPage1;
                txtAddress.Focus();
                return false;
            }

            if (dtpBeginDate.TextEx=="")
            {
                TXMessageBoxExtensions.Info("��ʾ���������ڱ�����д��\n");
                this.tabControl1.SelectedTab = tabPage1;
                dtpBeginDate.Focus();
                return false; 
            }

            if (dtpEndDate.TextEx == "")
            {
                TXMessageBoxExtensions.Info("��ʾ���������ڱ�����д��\n");
                this.tabControl1.SelectedTab = tabPage1;
                dtpEndDate.Focus();
                return false;
            }

            //��֤��λ
            if (!isCheckUnit(new List<TXTextBoxEX>()
            {
                this.txtJsdw,this.txtLxpzdw,this.txtSjdw,this.txtKcdw,this.txtSgdw,this.txtJldw
            },
                new string[] { "����", "������׼", "���", "����", "ʩ��", "����" }))
            {
                return false;
            }

            if (txtGhcode.Text == "")
            {
                TXMessageBoxExtensions.Info("��ʾ�����̹滮���֤�ű�����д��\n");
                this.tabControl1.SelectedTab = tabPage1;
                txtGhcode.Focus();
                return false;
            }
            
            if (ProjectNO == "")//���Ǳ༭
            {
                ERM.BLL.T_Projects_BLL ProjectDB = new ERM.BLL.T_Projects_BLL();
                if (ProjectDB.Exists(txtProjectNo.Text.Trim()))
                {
                    TXMessageBoxExtensions.Info("��ʾ�����̱�����ظ�����������д��");
                    this.tabControl1.SelectedTab = tabPage1;
                    txtProjectNo.Focus();
                    return false;
                }
                if (txtProjectName.Text.Trim() != ""
                    && ProjectDB.ExistsName(txtProjectName.Text.Trim()))
                {
                    TXMessageBoxExtensions.Info("��ʾ�������������ظ�����������д��");
                    this.tabControl1.SelectedTab = tabPage1;
                    txtProjectName.Focus();
                    return false;
                }
            }

            if ((!String.IsNullOrEmpty(this.dtpBeginDate.TextEx)) && dtpBeginDate.TextEx != "")
            {
                if (this.dtpEndDate.TextEx != "" &&
                    (!this.dtpBeginDate.TextEx.Equals(this.dtpEndDate.TextEx)) &&
                            (MyCommon.ToDate(dtpBeginDate.TextEx) >
                            MyCommon.ToDate(dtpEndDate.TextEx)))
                {
                    TXMessageBoxExtensions.Info("��ʾ�����̻�����Ϣ���������� ����С�� �������ڣ�");
                    this.tabControl1.SelectedTab = tabPage1;
                    this.dtpEndDate.Focus();
                    return false;
                }
            }

            projectMDL = obj.GetInfo(ProjectNo, projectMDL, 1) as T_Projects;

            projectMDL.ProjectNO = MyCommon.ToSqlString(txtProjectNo.Text);     //���̱��
            projectMDL.district = MyCommon.ToSqlString(cboDistrict.Text);       //��������
            projectMDL.projectname = MyCommon.ToSqlString(txtProjectName.Text); //��������
            projectMDL.address = MyCommon.ToSqlString(txtAddress.Text);         //���̵�ַ
            projectMDL.ajdh = MyCommon.ToSqlString(txtysbah.Text);//���ձ�����
            projectMDL.ProjectCategory = cboProjectType.SelectedValue.ToString();
            projectMDL.begindate = dtpBeginDate.TextEx;//����ʱ��
            projectMDL.enddate = dtpEndDate.TextEx;//����ʱ��
            projectMDL.ghcode = MyCommon.ToSqlString(txtGhcode.Text);
            projectMDL.sgcode = MyCommon.ToSqlString(txtSgcode.Text);
            projectMDL.tbr = Globals.Fullname;
           
            //projectMDL.ydpzcode = MyCommon.ToSqlString(txtYdpzcode.Text);
            projectMDL.ydxkcode = MyCommon.ToSqlString(txtYdghxkCode.Text);
            SetItemInfo(itemMDL.ItemID, 1);

            if (this.ProjectNO == "")
            {
                projectMDL.createdate = DateTime.Now.ToString("yyyy.MM.dd");
                itemMDL.ItemID = Guid.NewGuid().ToString();
                projectMDL.ItemID = itemMDL.ItemID;
                SaveUnit();
                if (!obj.Add(projectMDL, itemMDL))
                {
                    TXMessageBoxExtensions.Info("����ʧ�ܣ�");
                    return false;
                }
                this.ProjectNO = txtProjectNo.Text;
                txtProjectNo.Enabled = false;
                try
                {
                    System.IO.Directory.CreateDirectory(Globals.ProjectPathParent + MyCommon.ToSqlString(txtProjectNo.Text));
                }
                catch
                {
                    TXMessageBoxExtensions.Info("�������������ŵ����ļ���Ŀ¼�Ƿ���ڼ���д��");
                }
            }
            else
            {
                SaveUnit();
                if (!obj.Updates(projectMDL, itemMDL))
                {
                    TXMessageBoxExtensions.Info("����ʧ�ܣ�");
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        ///  ���浥λ
        /// </summary>
        /// <returns></returns>
        private void SaveUnit() {
            List<T_Units> unitMDL = new List<T_Units>();
            T_Units_BLL units_bll = new T_Units_BLL();
            unitMDL.Add(new T_Units() { dwmc = this.txtJsdw.Text, ProjectNO = this.txtProjectNo.Text, unittype = "unit1", UnitID = Guid.NewGuid().ToString() });
            unitMDL.Add(new T_Units() { dwmc = this.txtSjdw.Text, ProjectNO = this.txtProjectNo.Text, unittype = "unit3", UnitID = Guid.NewGuid().ToString() });
            unitMDL.Add(new T_Units() { dwmc = this.txtSgdw.Text, ProjectNO = this.txtProjectNo.Text, unittype = "unit4", UnitID = Guid.NewGuid().ToString() });
            unitMDL.Add(new T_Units() { dwmc = this.txtJldw.Text, ProjectNO = this.txtProjectNo.Text, unittype = "unit6", UnitID = Guid.NewGuid().ToString() });
            unitMDL.Add(new T_Units() { dwmc = this.txtKcdw.Text, ProjectNO = this.txtProjectNo.Text, unittype = "unit2", UnitID = Guid.NewGuid().ToString() });
            unitMDL.Add(new T_Units() { dwmc = this.txtLxpzdw.Text, ProjectNO = this.txtProjectNo.Text, unittype = "unit15", UnitID = Guid.NewGuid().ToString() });

            foreach (var item in unitMDL)
            {
                if (units_bll.Exists1(item))
                {
                    units_bll.Updates(item);
                }
                else
                {
                    units_bll.Insert(item);
                }
            }
        }

        /// <summary>
        /// ��֤��λ�Ƿ���ȷ
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        private bool isCheckUnit(List<TXTextBoxEX>list,string[] dwmc)
        {
            int i = 0;
            int flag = 0;
            foreach (var item in list)
            {
                if (string.IsNullOrEmpty(item.Text))
                {
                    TXMessageBoxExtensions.Info("��ʾ��" + dwmc[i].ToString() + "��λ����Ϊ�գ�");
                    this.tabControl1.SelectedTab = tabPage1;
                    item.Focus();
                    flag = 1;
                    break;
                }
                i++;
            }
            if (flag>0)
            {
                return false;  
            }
            return true;
        }

        /// <summary>
        /// ��ȡ���̵Ľ��赥λ���ƺ͸�����
        /// ����ж����λ��Ĭ��ȡ��һ����¼
        /// </summary>
        /// <returns>MDL.T_Units</returns>
        private MDL.T_Units GetJSDW()
        {
            BLL.T_Units_BLL Units_BLL = new BLL.T_Units_BLL();
            MDL.T_Units mdl_unit = new ERM.MDL.T_Units();
            mdl_unit.ProjectNO = this.ProjectNO;
            mdl_unit.unittype = "unit1";
            DataSet tbl_units = Units_BLL.GetList(mdl_unit);
            if (tbl_units != null && tbl_units.Tables.Count > 0 &&
                tbl_units.Tables[0].Rows.Count > 0)
            {
                mdl_unit.dwmc = tbl_units.Tables[0].Rows[0]["dwmc"].ToString();
                mdl_unit.fzr = tbl_units.Tables[0].Rows[0]["fzr"].ToString();
            }
            return mdl_unit;
        }
        #endregion

        /// <summary>
        /// ѡ��ͬ����������ʾ��ͬ�Ĺ�����չ��Ϣ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboProjectType_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.gbjz.Controls.Clear();
            getInstance();

            this.gbjz.Text = this.cboProjectType.Text;

            this.tabPage2.AutoScroll = (this.gbjz.Height > this.tabPage2.Height) ? true : false;
        }

        /// <summary>
        /// ���ݹ������Ͷ�̬������Ӧ�û��ؼ�����
        /// </summary>
        /// <returns></returns>
        private void getInstance()
        {
            try
            {
                obj = Project_Factory.getInstance(ds3, this.cboProjectType.SelectedValue.ToString());
                obj.GetInfo(ProjectNo, projectMDL);
                UserControl uc = obj as UserControl;
                uc.Top = 15;
                uc.Left = 15;
                this.gbjz.Controls.Add(uc);
            }
            catch (Exception ex)
            {
                TXMessageBoxExtensions.Info(ex.Message);
            }
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {

        }

        private void txtProjectName_Load(object sender, EventArgs e)
        {

        }

        private void btnNew_Click_1(object sender, EventArgs e)
        {

        }

        private void btnEdit_Click_1(object sender, EventArgs e)
        {

        }

        private void btnDel_Click_1(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dtpEndDate_Click(object sender, EventArgs e)
        {
          
        }

        private void dtpEndDate_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void dtpEndDate_MouseClick(object sender, MouseEventArgs e)
        {
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
