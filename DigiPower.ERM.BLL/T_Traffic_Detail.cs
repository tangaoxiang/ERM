using System;
using System.Collections.Generic;
using System.Text;
using ERM.MDL;

namespace ERM.BLL
{
    public class T_Traffic_Detail_BLL : IBLL
    {
        /// <summary>
        /// 根据项目ID获取相应市政交通工程明细
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public IList<T_Traffic_Detail> QueryTraffic_ByProjID(string ID)
        {
            String stmtId = "T_Traffic_Detail.Find_ByTrafficID";
            IList<T_Traffic_Detail> result = MyISqlMap.QueryForList<T_Traffic_Detail>(stmtId, ID);
            return result;
        }

        public void Update(T_Traffic_Detail obj)
        {
            if (obj == null) throw new ArgumentNullException("obj");
            String stmtId = "T_Traffic_Detail.UpdateT_Traffic_Detail";
            MyISqlMap.Update(stmtId, obj);
        }

        public void Add(T_Traffic_Detail obj)
        {
            Insert(obj);
        }

        public void Insert(T_Traffic_Detail obj)
        {
            if (obj == null) throw new ArgumentNullException("obj");
            String stmtId = "T_Traffic_Detail.InsertT_Traffic_Detail";
            MyISqlMap.Insert(stmtId, obj);
        }

        public void Delete(String T_TrafficID)
        {
            if (T_TrafficID == null) throw new ArgumentNullException("obj");
            String stmtId = "T_Traffic_Detail.DeleteT_Traffic_Detail";
            T_Traffic_Detail obj = new T_Traffic_Detail();
            obj.TrafficID = T_TrafficID;
            MyISqlMap.Delete(stmtId, obj);
        }
    }
}
