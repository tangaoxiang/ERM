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
    public partial class frmUnit : ERM.UI.Controls.Skin_DevEX
    {
        private string unitType = "";
        private string ProjectNO = "";
        private string unitID = "";
        /// <summary>
        /// ���캯��
        /// </summary>
        /// <param name="unittype">��ǰ�ĵ�λ���</param>
        /// <param name="dv">�༭�������ύ���������</param>
        public frmUnit(string _unittype, string _ProjectNO, string _unitID)
        {
            InitializeComponent();
            this.unitType = _unittype;
            ProjectNO = _ProjectNO;
            this.unitID = _unitID;
        }
        private void frmUnit_Load(object sender, EventArgs e)
        {
            this.Init();
        }
        private void Init()
        {
            ERM.BLL.T_Dict_BLL dicData = new ERM.BLL.T_Dict_BLL();
            IList<MDL.T_Dict> ds = dicData.FindByKeyWord("unittype");
            List<MDL.T_Dict> dictList = new List<MDL.T_Dict>();
            string[] unitList = new string[] { "unit1", "unit6", "unit4", "unit3", "unit2", "unit15" };

            for (int i = 0; i < ds.Count; i++)
            {
                for (int j = 0; j < unitList.Length; j++)
                {
                    if (ds[i].ValueName==unitList[j])
                    {
                        dictList.Add(ds[i]);
                    }
                }
            }
           
            cboUnittype.DisplayMember = "displayname";
            cboUnittype.ValueMember = "valuename";
            cboUnittype.DataSource = dictList;
            if (this.unitType != null)
            {
                cboUnittype.SelectedValue = unitType;
            }
            if (unitID != "")
            {
                BLL.T_Units_BLL unitBLL = new ERM.BLL.T_Units_BLL();
                MDL.T_Units unitMDL = unitBLL.Find(unitID);
                txtUnitid.Text = unitMDL.UnitID;
                if (string.Compare(cboUnittype.SelectedValue.ToString(), "unit12", true) == 0 || string.Compare(cboUnittype.SelectedValue.ToString(), "unit13", true) == 0)
                {
                    txtOther.Text = unitMDL.fzr;
                }
                else
                {
                    txtDwmc.Text = unitMDL.dwmc;
                    txtFzr.Text = unitMDL.fzr;
                    txtFzrzs.Text = unitMDL.fzrzs;
                    txtXmjl.Text = unitMDL.xmjl;
                    txtZzdj.Text = unitMDL.zzdj;
                    txtZzzh.Text = unitMDL.zzzh;
                    txtAddr.Text = unitMDL.addr;
                    txtTel.Text = unitMDL.tel;
                    txtFax.Text = unitMDL.fax;
                    txtRemark.Text = unitMDL.remark;

                    txtXmzyzljcy.Text = unitMDL.xmzyzljcy;
                    txtZlfzr.Text = unitMDL.zlfzr;
                    txtJccsfzr.Text = unitMDL.jccsfzr;
                    txtSyxfzr.Text = unitMDL.syxfzr;
                    txtTsfzr.Text = unitMDL.tsfzr;
                    txtOther.Text = unitMDL.xcjl;
                }
            }
        }
        private void ChangeForm(string unittypeValue)
        {
            if (string.Compare(unittypeValue, "unit12", true) == 0 || string.Compare(unittypeValue, "unit13", true) == 0)
            {
                tableLayoutPanel1.Visible = false;
                txtOther.Visible = true;
                label5.Visible = true;
                if (string.Compare(unittypeValue, "unit12", true) == 0)
                {
                    label5.Text = "ʩ�����鳤";
                }
                else
                {
                    label5.Text = "רҵ����";
                }
            }
            else
            {
                tableLayoutPanel1.Visible = true;
                txtOther.Visible = false;
                label5.Visible = false;
            }

            lblJccsfzr.Visible = false;
            txtJccsfzr.Visible = false;
            lblSyxfzr.Visible = false;
            txtSyxfzr.Visible = false;
            lblTsfzr.Visible = false;
            txtTsfzr.Visible = false;

            switch (unittypeValue)
            {
                case "unit1":   //���赥λ
                    lblXmjl.Visible = false;
                    txtXmjl.Visible = false;
                    lblFzr.Text = "��Ŀ������";
                    lblFzrzh.Text = "��Ŀ�������ʸ�֤��";
                    lblPrompt.Text = "��λ���ơ���Ŀ�����˵������ʱ���Զ����������û�ѡ��";
                    lblZlfzr.Visible = true;
                    txtZlfzr.Visible = true;
                    break;
                case "unit2":   //���쵥λ
                    lblXmjl.Text = "��λ����������";
                    lblXmjl.Visible = true;
                    txtXmjl.Visible = true;
                    lblFzr.Text = "��Ŀ������";
                    lblFzrzh.Text = "��Ŀ�������ʸ�֤��";
                    lblPrompt.Text = "��λ���ơ���Ŀ�����ˡ���λ���������˵������ʱ���Զ����������û�ѡ��";
                    break;
                case "unit3":   //��Ƶ�λ
                    lblXmjl.Text = "��λ����������";
                    lblXmjl.Visible = true;
                    txtXmjl.Visible = true;
                    lblFzr.Text = "��Ŀ������";
                    lblFzrzh.Text = "��Ŀ�������ʸ�֤��";
                    lblPrompt.Text = "��λ���ơ���Ŀ�����ˡ���λ���������˵������ʱ���Զ����������û�ѡ��";
                    break;
                case "unit4":   //ʩ����λ
                    lblXmjl.Text = "��Ŀ����";
                    lblXmjl.Visible = true;
                    txtXmjl.Visible = true;
                    lblFzr.Text = "����������";
                    lblFzrzh.Text = "�����������ʸ�֤��";
                    lblPrompt.Text = "��λ���ơ����������ˡ���Ŀ����������ʱ���Զ����������û�ѡ��";

                    lblXmjl.Visible = true;
                    txtXmjl.Visible = true;
                    lblXmzyzljcy.Visible = true;
                    txtXmzyzljcy.Visible = true;

                    lblJccsfzr.Visible = true;
                    txtJccsfzr.Visible = true;
                    lblSyxfzr.Visible = true;
                    txtSyxfzr.Visible = true;
                    lblTsfzr.Visible = true;
                    txtTsfzr.Visible = true;

                    break;
                case "unit5":   //ʩ��ͼ��鵥λ
                    lblXmjl.Visible = false;
                    txtXmjl.Visible = false;
                    lblFzr.Text = "��Ŀ������";
                    lblFzrzh.Text = "��Ŀ�������ʸ�֤��";
                    lblPrompt.Text = "��λ���ơ���Ŀ�����˵������ʱ���Զ����������û�ѡ��";
                    break;
                case "unit6":   //����λ
                    lblXmjl.Text = "��Ŀ�ܼ�";
                    lblXmjl.Visible = true;
                    txtXmjl.Visible = true;
                    label5.Visible = true;
                    txtOther.Visible = true;
                    //lbljl.Visible = true;
                    //txtxcjl.Visible = true;
                    label5.Text = "�ֳ�����";
                    lblFzrzh.Text = "������ʦ�ʸ�֤��";
                    lblPrompt.Text = "��λ���ơ�������ʦ���ܼ�����ʦ�������ʱ���Զ����������û�ѡ��";
                    break;
                case "unit7":   //�ල��λ
                    lblXmjl.Visible = false;
                    txtXmjl.Visible = false;
                    lblFzr.Text = "�ලԱ";
                    lblFzrzh.Text = "�ලԱ�ʸ�֤��";
                    lblPrompt.Text = "��λ���ơ��ලԱ�������ʱ���Զ����������û�ѡ��";
                    break;
                case "unit8":   //�ְ���λ
                    lblXmjl.Text = "��Ŀ����";
                    lblXmjl.Visible = true;
                    txtXmjl.Visible = true;
                    lblFzr.Text = "����������";
                    lblFzrzh.Text = "�����������ʸ�֤��";
                    lblPrompt.Text = "��λ���ơ����������ˡ���Ŀ����������ʱ���Զ����������û�ѡ��";
                    break;
                case "unit9":   //�ܳа���λ
                    lblXmjl.Text = "��Ŀ����";
                    lblXmjl.Visible = true;
                    txtXmjl.Visible = true;
                    lblFzr.Text = "�ܳа�������";
                    lblFzrzh.Text = "�ܳа��������ʸ�֤��";
                    lblPrompt.Text = "��λ���ơ��ܳа������ˡ���Ŀ����������ʱ���Զ����������û�ѡ��";

                    lblXmjl.Visible = true;
                    txtXmjl.Visible = true;
                    lblXmzyzljcy.Visible = true;
                    txtXmzyzljcy.Visible = true;

                    break;
                case "unit10":   //��װ��λ
                    lblXmjl.Text = "��Ŀ����";
                    lblXmjl.Visible = true;
                    txtXmjl.Visible = true;
                    lblFzr.Text = "��װ������";
                    lblFzrzh.Text = "��װ�������ʸ�֤��";
                    lblPrompt.Text = "��λ���ơ���װ�����ˡ���Ŀ����������ʱ���Զ����������û�ѡ��";
                    break;
                case "unit11":   //������λ
                    lblXmjl.Text = "��Ŀ����";
                    lblXmjl.Visible = true;
                    txtXmjl.Visible = true;
                    lblFzr.Text = "������";
                    lblFzrzh.Text = "�������ʸ�֤��";
                    lblPrompt.Text = "��λ���ơ������ˡ���Ŀ����������ʱ���Զ����������û�ѡ��";
                    break;
                case "unit14":   //������λ
                    lblXmjl.Text = "��Ŀ����";
                    lblXmjl.Visible = true;
                    txtXmjl.Visible = true;
                    lblFzr.Text = "������Ա";
                    lblFzrzh.Text = "������Ա�ʸ�֤��";
                    lblPrompt.Text = "��λ���ơ������ˡ���Ŀ����������ʱ���Զ����������û�ѡ��";
                    break;
            }
        }
        /// <summary>
        /// �ı䵥λ���ʱ�������¼�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboUnittype_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboUnittype.SelectedValue == null)
                cboUnittype.SelectedIndex = 0;
            this.ChangeForm(cboUnittype.SelectedValue.ToString());
        }
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (string.Compare(cboUnittype.SelectedValue.ToString(), "unit12", true) == 0 || string.Compare(cboUnittype.SelectedValue.ToString(), "unit13", true) == 0)
            {
                if (txtOther.Text.Trim() == "")
                {
                    TXMessageBoxExtensions.Info("����д������");
                    txtOther.Focus();
                    return;
                }
            }
            else
            {
                if (txtDwmc.Text.Trim() == "")
                {
                    TXMessageBoxExtensions.Info("��λ���Ʊ�����д��");
                    txtDwmc.Focus();
                    return;
                }
            }


            T_Units_BLL unitBLL = new T_Units_BLL();
            T_Units unitsList = new T_Units();
            unitsList.ProjectNO = ProjectNO;
            unitsList.unittype = this.cboUnittype.SelectedValue.ToString();
            DataSet ds = unitBLL.GetList(unitsList);
            if (ds.Tables.Count>0)
            {
                if (ds.Tables[0].Rows.Count>0)
                {
                    TXMessageBoxExtensions.Info("�ù����Ѿ�������ͬ���͵�λ�������ظ���ӣ�");
                    return; 
                }
            }

            this.DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtOther_Load(object sender, EventArgs e)
        {

        }

        private void txtXmjl_Load(object sender, EventArgs e)
        {

        }

        private void txtZzdj_Load(object sender, EventArgs e)
        {

        }

        private void txtZzzh_Load(object sender, EventArgs e)
        {

        }

        private void txtFzr_Load(object sender, EventArgs e)
        {

        }

        private void txtFzrzs_Load(object sender, EventArgs e)
        {

        }

        private void txtTel_Load(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnConfirm_Click_1(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {

        }
    }
}
