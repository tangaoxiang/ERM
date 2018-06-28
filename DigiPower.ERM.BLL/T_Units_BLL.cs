using System;
using System.Collections.Generic;
using System.Text;
using ERM.MDL;
namespace ERM.BLL
{
    public class T_Units_BLL : IBLL
    {
        public T_Units Find(String unitID)
        {
            String stmtId = "T_Units.Find";
            T_Units result = MyISqlMap.QueryForObject<T_Units>(stmtId, unitID);
            return result;
        }
        public System.Data.DataSet GetList(MDL.T_Units obj)
        {
            String stmtId = "T_Units.GetList";
            System.Data.DataSet result = DAL.MyBatis.QueryForDataSet(stmtId, obj);
            return result;
        }
        public System.Data.DataSet GetList(String strWhere)
        {
            String stmtId = "T_Units.GetList";
            if (strWhere == null || strWhere == "" || strWhere == "1=1")
            {
                strWhere = null;
                stmtId = "T_Units.GetAll";
            }
            System.Data.DataSet result = DAL.MyBatis.QueryForDataSet(stmtId, strWhere);
            return result;
        }
        
        public IList<T_Units> FindByProjectNO(String projectNO)
        {
            String stmtId = "T_Units.FindByProjectNO";
            IList<T_Units> result = MyISqlMap.QueryForList<T_Units>(stmtId, projectNO);
            return result;
        }
        public IList<T_Units> FindBydwmc(String dwmc)
        {
            String stmtId = "T_Units.FindBydwmc";
            IList<T_Units> result = MyISqlMap.QueryForList<T_Units>(stmtId, dwmc);
            return result;
        }       
        
        public void Insert(T_Units obj)
        {
            if (obj == null) throw new ArgumentNullException("obj");
            String stmtId = "T_Units.Insert";
            MyISqlMap.Insert(stmtId, obj);
        }
        public void Add(T_Units obj)
        {
            Insert(obj);
        }
        public void Update(T_Units obj)
        {
            if (obj == null) throw new ArgumentNullException("obj");
            String stmtId = "T_Units.Update";
            MyISqlMap.Update(stmtId, obj);
        }

        public void Updates(T_Units obj)
        {
            if (obj == null) throw new ArgumentNullException("obj");
            String stmtId = "T_Units.Updates";
            MyISqlMap.Update(stmtId, obj);
        }
        public bool Exists1(T_Units obj)
        {
            String stmtId = "T_Units.Exists1";
            bool result = MyISqlMap.QueryForObject<bool>(stmtId, obj);
            return result;
        }
        public void Delete(String unitID)
        {
            if (unitID == null) throw new ArgumentNullException("obj");
            String stmtId = "T_Units.Delete";
            T_Units obj = new T_Units();
            obj.UnitID = unitID;
            MyISqlMap.Delete(stmtId, obj);
        }
    }
}
