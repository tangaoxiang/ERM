using System;
using System.Collections.Generic;
using System.Text;
using ERM.MDL;
namespace ERM.BLL
{
    public class T_Traffic_BLL : IBLL
    {
        /// <summary>
        /// 根据项目ID获取相应市政交通工程明细
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public T_Traffic QueryTraffic_ByProjID(string ID)
        {
            String stmtId = "T_Traffic.QueryTraffic_ByProjID";
            T_Traffic result = MyISqlMap.QueryForObject<T_Traffic>(stmtId, ID);
            return result;
        }
        public void Insert(T_Traffic obj)
        {
            if (obj == null) throw new ArgumentNullException("obj");
            String stmtId = "T_Traffic.InsertT_Traffic";
            MyISqlMap.Insert(stmtId, obj);
        }

        public bool Add(T_Projects model_Projects, T_Item model_Item, T_Traffic model_Traffic, IList<T_Traffic_Detail> detailMDL)
        {
            BLL.T_Projects_BLL proj_bll = new T_Projects_BLL();
            bool flag = proj_bll.Add(model_Projects, model_Item);

            if (flag)
            {
                this.Insert(model_Traffic);
                BLL.T_Traffic_Detail_BLL detailBLL = new ERM.BLL.T_Traffic_Detail_BLL();
                for (int i = 0; i < detailMDL.Count; i++)
                {
                    detailMDL[i].TrafficID = model_Traffic.ID.ToString();
                    detailBLL.Add(detailMDL[i]);
                }
                return true;
            }
            return false;
        }
        public bool Update(T_Projects model_Projects, T_Item model_Item, T_Traffic model_Traffic, IList<T_Traffic_Detail> detailMDL)
        {
            BLL.T_Projects_BLL proj_bll = new T_Projects_BLL();
            bool flag = proj_bll.Update(model_Projects, model_Item);

            if (flag)
            {
                BLL.T_Traffic_Detail_BLL detailBLL = new ERM.BLL.T_Traffic_Detail_BLL();
                for (int i = 0; i < detailMDL.Count; i++)
                {
                    detailBLL.Update(detailMDL[i]);
                }
                this.Update(model_Traffic);
                return true;
            }
            return false;
        }

        public void Update(T_Traffic obj)
        {
            if (obj == null) throw new ArgumentNullException("obj");
            String stmtId = "T_Traffic.UpdateT_Traffic";
            MyISqlMap.Update(stmtId, obj);
        }
        public void Delete(String ID)
        {
            if (ID == null) throw new ArgumentNullException("ID");
            String stmtId = "T_Traffic.DeleteT_Traffic";
            T_Traffic obj = new T_Traffic();
            obj.ID = ID;
            MyISqlMap.Delete(stmtId, obj);
        }
    }
}
