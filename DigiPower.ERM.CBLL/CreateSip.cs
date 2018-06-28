using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
namespace ERM.CBLL
{
    public class CreateSip
    {
        private string _openedProjectNo = "";
        private ERM.BLL.T_Projects_BLL projectsData = new ERM.BLL.T_Projects_BLL();
        private ERM.BLL.T_Units_BLL unitData = new ERM.BLL.T_Units_BLL();
        private ERM.BLL.T_Item_BLL itemData = new ERM.BLL.T_Item_BLL();
        private Hashtable _projectDetail;
        /// <summary>
        /// ��ȡ����������Ϣ���ڱ�ͷ���ʱ��
        /// </summary>
        public Hashtable ProjectDetail
        {
            get { return _projectDetail; }
        }
        private Hashtable _item;
        /// <summary>
        /// ��Ŀ��Ϣ
        /// </summary>
        public Hashtable Item
        {
            get { return _item; }
        }
        /// <summary>
        /// ����sip��
        /// </summary>
        /// <param name="openedProjectNo"></param>
        public CreateSip(string openedProjectNo)
        {
            this._openedProjectNo = openedProjectNo;
            ERM.MDL.T_Projects projectInfo = projectsData.Find(_openedProjectNo);

            Hashtable projectDetail = new Hashtable();
            CreatePaoject(projectInfo, projectDetail);
            Hashtable Item = new Hashtable();
            CreateItem(projectInfo, Item);
        }
        /// <summary>
        /// ��ȡ��Ŀ������Ϣ
        /// </summary>
        /// <param name="projectInfo"></param>
        /// <param name="projectDetail"></param>
        private void CreateItem(ERM.MDL.T_Projects projectInfo, Hashtable Item)
        {
            string strOut = "";
            ERM.MDL.T_Item ItemInfo = itemData.Find(projectInfo.ItemID);
            Item.Add("��Ŀ����", ItemInfo.ConStructionProjectName);
            Item.Add("��������", ItemInfo.Respective);
            Item.Add("���̵�ַ", ItemInfo.ConstructionProjectAdd);
            Item.Add("�������", ItemInfo.ProjectType);
            Item.Add("���õ����", ItemInfo.UseSoiAreaSum);
            Item.Add("�ܽ������", ItemInfo.ConstructionAreaSum);
            Item.Add("�����ģ", ItemInfo.ConstructionScale);
            Item.Add("�������", ItemInfo.ProjectCost);
            Item.Add("���̽���", ItemInfo.ProjectSettlement);
            strOut = "";
            try
            {
                strOut = DateTime.Parse(ItemInfo.StartDate).ToString("yyyy.MM.dd");
            }
            catch { strOut = ""; }
            Item.Add("����ʱ��", strOut);

            strOut = "";
            try
            {
                strOut = DateTime.Parse(ItemInfo.FinishDate).ToString("yyyy.MM.dd");
            }
            catch { strOut = ""; }
            Item.Add("����ʱ��", strOut);

            Item.Add("�õط���", ItemInfo.UseSoiType);
            Item.Add("��������", ItemInfo.CollectionType);
            Item.Add("ԭ���ط���", ItemInfo.OriginalSoiType);
            Item.Add("�õ����", ItemInfo.UseSoiArea);
            strOut = "";
            try
            {
                strOut = DateTime.Parse(ItemInfo.Approvedate).ToString("yyyy.MM.dd");
            }
            catch { strOut = ""; }
            Item.Add("��׼ʱ��", strOut);

            Item.Add("���赥λ", ItemInfo.CreateUnit);
            Item.Add("���赥λ��Ŀ������", ItemInfo.ItemFzr);
            Item.Add("�ܵؼ�", ItemInfo.AllCost);
            Item.Add("�ݻ���", ItemInfo.VolumeFar);
            Item.Add("�̻���", ItemInfo.GreenFar);
            Item.Add("�����ܶ�", ItemInfo.BuildingDensity);
            this._item = Item;
        }
        /// <summary>
        /// ���ɹ�����Ϣ Hashtable
        /// </summary>
        /// <param name="projectInfo"></param>
        /// <param name="projectDetail"></param>
        private void CreatePaoject(ERM.MDL.T_Projects projectInfo, Hashtable projectDetail)
        {
            string strOut = "";
            projectDetail.Add("���̴���", projectInfo.ProjectNO);
            projectDetail.Add("��������", projectInfo.projectname);
            projectDetail.Add("���̵�ַ", projectInfo.address);
            projectDetail.Add("��������", projectInfo.category);
            projectDetail.Add("�ṹ����", projectInfo.stru);
            projectDetail.Add("�������", projectInfo.projecttype);
            projectDetail.Add("�߶�", projectInfo.high);
            projectDetail.Add("���ϲ���", projectInfo.floors1);
            projectDetail.Add("���²���", projectInfo.floors2);
            projectDetail.Add("�������", projectInfo.area1);
            projectDetail.Add("�õ����", projectInfo.area2);
            projectDetail.Add("�����õ���׼���", projectInfo.ydpzcode);
            projectDetail.Add("�õع滮���֤��", projectInfo.ydxkcode);
            projectDetail.Add("�滮���֤��", projectInfo.ghcode);
            projectDetail.Add("����ʩ�����֤��", projectInfo.sgcode);
            projectDetail.Add("����Ԥ��", projectInfo.price1);
            projectDetail.Add("���̾���", projectInfo.price2);
            strOut = "";
            try
            {
                strOut = DateTime.Parse(projectInfo.begindate).ToString("yyyy.MM.dd");
            }
            catch { strOut = ""; }
            projectDetail.Add("��������", strOut);

            strOut = "";
            try
            {
                strOut = DateTime.Parse(projectInfo.bjdate).ToString("yyyy.MM.dd");
            }
            catch { strOut = ""; }
            projectDetail.Add("��������", strOut);

            strOut = "";
            try
            {
                strOut = DateTime.Parse(projectInfo.enddate).ToString("yyyy.MM.dd");
            }
            catch { strOut = ""; }
            projectDetail.Add("��������", strOut);

            projectDetail.Add("�����", projectInfo.hjqk);
            projectDetail.Add("סլ���", projectInfo.zzmj);
            projectDetail.Add("�칫�÷����", projectInfo.bgyfmj);
            projectDetail.Add("��ҵ�÷����", projectInfo.syyfmj);
            projectDetail.Add("�������", projectInfo.cfmj);
            projectDetail.Add("���������", projectInfo.dxsmj);
            projectDetail.Add("�����÷����", projectInfo.qtyfmj);
            projectDetail.Add("����Ԣ����", projectInfo.ts1);
            projectDetail.Add("С��������", projectInfo.ts2);
            projectDetail.Add("�л�������", projectInfo.ts3);
            projectDetail.Add("��������", projectInfo.ts4);
            projectDetail.Add("������", projectInfo.tstotal);
            projectDetail.Add("רҵ����", projectInfo.zygz);
            projectDetail.Add("��Ŀרҵ��������Ա", projectInfo.zjy);
            projectDetail.Add("ʩ�����鳤", projectInfo.sgbzz);
            projectDetail.Add("�����", projectInfo.tbr);
            projectDetail.Add("���赥λ�ύ��", projectInfo.jsdwshr);
            projectDetail.Add("����λ�ύ��", projectInfo.jldwshr);
            strOut = "";
            try
            {
                strOut = DateTime.Parse(projectInfo.createdate).ToString("yyyy.MM.dd");
            }
            catch { strOut = ""; }
            projectDetail.Add("���ʱ��", strOut);
            
            //dv = unitData.GetList("ProjectNO='" + this._openedProjectNo + "' and unittype='unit3'").Tables[0].DefaultView;
            UnitSetting(projectDetail);
            ////���赥λ��Ϣ
            ////ʩ��ͼ��鵥λ
            ////�ල��λ
            ////��װ��λ
            this._projectDetail = projectDetail;
        }

        public DataView UnitSetting(Hashtable projectDetail)
        {
            MDL.T_Units mdl_unit = new ERM.MDL.T_Units();
            mdl_unit.ProjectNO = this._openedProjectNo;
            DataView dv;
            mdl_unit.unittype = "unit3";
            dv = unitData.GetList(mdl_unit).Tables[0].DefaultView;
            if (dv.Count <= 1)
            {
                if (dv.Count == 0)
                {
                    projectDetail.Add("��Ƶ�λ", "");
                    projectDetail.Add("��Ƶ�λ��Ŀ������", "");
                }
                else
                {
                    projectDetail.Add("��Ƶ�λ", dv[0]["dwmc"].ToString());
                    projectDetail.Add("��Ƶ�λ��Ŀ������", dv[0]["fzr"].ToString());
                }
            }
            else
            {
                string[] sjdwmc = new string[dv.Count];  //��λ����
                string[] sjdwxmfzr = new string[dv.Count]; //��Ŀ������
                string[] sjdwjsfzr = new string[dv.Count]; //����������
                for (int i = 0; i < dv.Count; i++)
                {
                    sjdwmc[i] = dv[i]["dwmc"].ToString();
                    sjdwxmfzr[i] = dv[i]["fzr"].ToString();
                }
                projectDetail.Add("��Ƶ�λ", sjdwmc);
                projectDetail.Add("��Ƶ�λ��Ŀ������", sjdwxmfzr);
            }
            //dv = unitData.GetList("ProjectNO='" + this._openedProjectNo + "' and unittype='unit2'").Tables[0].DefaultView;
            mdl_unit.unittype = "unit2";
            dv = unitData.GetList(mdl_unit).Tables[0].DefaultView;
            if (dv.Count <= 1)
            {
                if (dv.Count == 0)
                {
                    projectDetail.Add("���쵥λ", "");
                    projectDetail.Add("���쵥λ��Ŀ������", "");
                }
                else
                {
                    projectDetail.Add("���쵥λ", dv[0]["dwmc"].ToString());
                    projectDetail.Add("���쵥λ��Ŀ������", dv[0]["fzr"].ToString());
                }
            }
            else
            {
                string[] kcdwmc = new string[dv.Count];  //��λ����
                string[] kcdwxmfzr = new string[dv.Count]; //��Ŀ������
                string[] kcdwjsfzr = new string[dv.Count]; //����������
                for (int i = 0; i < dv.Count; i++)
                {
                    kcdwmc[i] = dv[i]["dwmc"].ToString();
                    kcdwxmfzr[i] = dv[i]["fzr"].ToString();
                }
                projectDetail.Add("���쵥λ", kcdwmc);
                projectDetail.Add("���쵥λ��Ŀ������", kcdwxmfzr);
            }
            //dv = unitData.GetList("ProjectNO='" + this._openedProjectNo + "' and unittype='unit6'").Tables[0].DefaultView;
            mdl_unit.unittype = "unit6";
            dv = unitData.GetList(mdl_unit).Tables[0].DefaultView;
            if (dv.Count <= 1)
            {
                if (dv.Count == 0)
                {
                    projectDetail.Add("����λ", "");
                    projectDetail.Add("����λ��Ŀ������", "");
                    projectDetail.Add("��Ŀ�ܼ�", "");
                    projectDetail.Add("�ֳ�����", "");
                }
                else
                {
                    projectDetail.Add("����λ", dv[0]["dwmc"].ToString());
                    projectDetail.Add("����λ��Ŀ������", dv[0]["fzr"].ToString());
                    projectDetail.Add("��Ŀ�ܼ�", dv[0]["xmjl"].ToString());
                    projectDetail.Add("�ֳ�����", dv[0]["fzr"].ToString());
                }
            }
            else
            {
                string[] jldwmc = new string[dv.Count];  //��λ����
                string[] jldwjlgcs = new string[dv.Count]; //������ʦ
                string[] jldwzjlgcs = new string[dv.Count]; //�ܼ�����ʦ
                for (int i = 0; i < dv.Count; i++)
                {
                    jldwmc[i] = dv[i]["dwmc"].ToString();
                    jldwjlgcs[i] = dv[i]["fzr"].ToString();
                    jldwzjlgcs[i] = dv[i]["xmjl"].ToString();
                }
                projectDetail.Add("����λ", jldwmc);
                projectDetail.Add("����λ��Ŀ������", jldwjlgcs);
                projectDetail.Add("��Ŀ�ܼ�", jldwzjlgcs);
                projectDetail.Add("�ֳ�����", jldwjlgcs);
            }
            //dv = unitData.GetList("ProjectNO='" + this._openedProjectNo + "' and unittype='unit8'").Tables[0].DefaultView;
            mdl_unit.unittype = "unit8";
            dv = unitData.GetList(mdl_unit).Tables[0].DefaultView;
            if (dv.Count <= 1)
            {
                if (dv.Count == 0)
                {
                    projectDetail.Add("�ְ���λ", "");
                    projectDetail.Add("�ְ���λ��Ŀ����", "");
                }
                else
                {
                    projectDetail.Add("�ְ���λ", dv[0]["dwmc"].ToString());
                    projectDetail.Add("�ְ���λ��Ŀ����", dv[0]["xmjl"].ToString());
                }
            }
            else
            {
                string[] fbdwmc = new string[dv.Count];  //��λ����
                string[] fbdwxmjl = new string[dv.Count]; //��Ŀ����
                for (int i = 0; i < dv.Count; i++)
                {
                    fbdwmc[i] = dv[i]["dwmc"].ToString();
                    fbdwxmjl[i] = dv[i]["xmjl"].ToString();
                }
                projectDetail.Add("�ְ���λ", fbdwmc);
                projectDetail.Add("�ְ���λ��Ŀ����", fbdwxmjl);
            }
            //dv = unitData.GetList("ProjectNO='" + this._openedProjectNo + "' and unittype='unit4'").Tables[0].DefaultView;
            mdl_unit.unittype = "unit4";
            dv = unitData.GetList(mdl_unit).Tables[0].DefaultView;
            if (dv.Count <= 1)
            {
                if (dv.Count == 0)
                {
                    projectDetail.Add("ʩ����λ", "");
                    projectDetail.Add("ʩ����λ��Ŀ����", "");
                }
                else
                {
                    projectDetail.Add("ʩ����λ", dv[0]["dwmc"].ToString());
                    projectDetail.Add("ʩ����λ��Ŀ����", dv[0]["xmjl"].ToString());
                }
            }
            else
            {
                string[] sgdwmc = new string[dv.Count];  //��λ����
                string[] sgdwxmfzr = new string[dv.Count]; //��Ŀ����
                string[] sgdwjsfzr = new string[dv.Count]; //����������
                for (int i = 0; i < dv.Count; i++)
                {
                    sgdwmc[i] = dv[i]["dwmc"].ToString();
                    sgdwxmfzr[i] = dv[i]["xmjl"].ToString();
                }
                projectDetail.Add("ʩ����λ", sgdwmc);
                projectDetail.Add("ʩ����λ��Ŀ����", sgdwxmfzr);
            }
            return dv;
        }
        /// <summary>
        /// ��������б�
        /// </summary>
        public DataSet GetListArchive(string ProjectNO, string ArchiveID)
        {
            BLL.BLLMore bllMore = new ERM.BLL.BLLMore();
            return bllMore.GetListArchive(ProjectNO, ArchiveID);
        }
        /// <summary>
        /// ���ݵ����ļ���ȡ�� �����ļ��İ���ID���ļ��ǼǱ��������Ϣ
        /// </summary>
        /// <returns></returns>
        public DataSet GetListFile(string ProjectNO, string ArchiveID)
        {
            BLL.BLLMore bllMore = new ERM.BLL.BLLMore();
            return bllMore.GetListFile(ProjectNO, ArchiveID);
        }
    }
}
