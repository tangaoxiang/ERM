using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ERM.Common;
using ERM.BLL;
using TX.Framework.WindowUI.Forms;
using CCWin;
namespace ERM.UI
{
    public partial class frmDistrictDetail : ERM.UI.Controls.Skin_DevEX
    {
        ERM.BLL.District DistrictDB = new ERM.BLL.District();//DistrictDB���ݿ������
        ERM.MDL.District District = new ERM.MDL.District();//Districtʵ����
        ERM.CBLL.District DistrictDBC = new ERM.CBLL.District();
        private string optype;
        public string OpType
        {
            get { return this.optype; }
            set { this.optype = value; }
        }
        /// <summary>
        /// ����ID����
        /// </summary>
        private int districtID;
        public int DistrictID
        {
            set { this.districtID = value; }
            get { return this.districtID; }
        }
        public frmDistrictDetail()
        {
            InitializeComponent();
        }
       /// <summary>
       /// ��������¼�
       /// </summary>
       /// <param name="sender"></param>
       /// <param name="e"></param>
        private void frmDistrictDetail_Load(object sender, EventArgs e)
        {
            if (this.OpType == "Add")
            {
                this.Text = "���������ϸ��Ϣ";
                 this.numOrderIndex.Value =  DistrictDBC.GetNextOrderIndex();
            }
            else
            {
                this.Text = "�༭������ϸ��Ϣ";
                SetData();
            }
        }
        /// <summary>
        /// ���ؼ���ֵ
        /// </summary>
        private void SetData()
        {
            District = DistrictDB.Find(this.districtID);
            this.txtDistrictName.Text = District.DistrictName;
            this.numOrderIndex.Value = District.OrderIndex;
        }
        /// <summary>
        /// ��������
        /// </summary>
        private void SaveData()
        {
            if (!ValidateData())
            {
                return;
            }
            GetData();
            if (this.OpType == "Add")//���
            {
                if (!DistrictDBC.Exists(District.DistrictName))  //�ж��Ƿ����ͬ����������
                {
                    District.DistrictID = District.OrderIndex;
                    DistrictDB.Add(District);//���
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    TXMessageBoxExtensions.Info("�Ѿ�����ͬ���������ƣ�");
                    this.txtDistrictName.Focus();
                    return;
                }
            }
            else//�༭
            {
                if (!DistrictDBC.Exists(District.DistrictName,District.DistrictID.Value))  //�ж��Ƿ����ͬ����������
                {
                    DistrictDBC.Update(District);//����
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    TXMessageBoxExtensions.Info("�Ѿ�����ͬ���������ƣ�");
                    this.txtDistrictName.Focus();
                    return;
                }
            }
        }
        /// <summary>
        /// ��֤���ݱ�����
        /// </summary>
        /// <returns></returns>
        private bool ValidateData()
        {
            if (this.txtDistrictName.Text.Trim() == "")
            {
                TXMessageBoxExtensions.Info("����������Ϊ�գ�");
                this.txtDistrictName.Focus();
                return false;
            }
            return true;
        }
        /// <summary>
        /// ��������
        /// </summary>
        private void GetData()
        {
             District.DistrictName=this.txtDistrictName.Text.Trim();
             District.OrderIndex = (int)this.numOrderIndex.Value ;
             District.TempID = 4;
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            SaveData();
        }

        private void btnConfirm_Click_1(object sender, EventArgs e)
        {

        }

        private void btnConfirm_Click_2(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {

        }
    }
}
