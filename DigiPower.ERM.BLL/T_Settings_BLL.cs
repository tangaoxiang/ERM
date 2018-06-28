using System;
using System.Collections.Generic;
using System.Text;
using ERM.MDL;
namespace ERM.BLL
{
    public class T_Settings_BLL : IBLL
    {
        public int GetCount()
        {
            String stmtId = "T_Settings.GetCount";
            int result = MyISqlMap.QueryForObject<int>(stmtId, null);
            return result;
        }
        public T_Settings Find(String iD)
        {
            String stmtId = "T_Settings.Find";
            T_Settings result = MyISqlMap.QueryForObject<T_Settings>(stmtId, iD);
            return result;
        }
        public System.Data.DataSet GetList(T_Settings obj)
        {
            String stmtId = "T_Settings.GetList";
            System.Data.DataSet result = DAL.MyBatis.QueryForDataSet(stmtId, obj);
            return result;
        }
        public System.Data.DataSet GetList(String strWhere)
        {
            String stmtId = "T_Settings.GetList";
            if (strWhere == null || strWhere == "" || strWhere == "1=1")
            {
                strWhere = null;
                stmtId = "T_Settings.GetAll";
            }
            System.Data.DataSet result = DAL.MyBatis.QueryForDataSet(stmtId, strWhere);
            return result;
        }
        public bool Exists(String iD)
        {
            String stmtId = "T_Settings.Exists";
            bool result = MyISqlMap.QueryForObject<bool>(stmtId, iD);
            return result;
        }
        public IList<T_Settings> GetAll()
        {
            String stmtId = "T_Settings.GetAll";
            IList<T_Settings> result = MyISqlMap.QueryForList<T_Settings>(stmtId, null);
            return result;
        }
        public IList<T_Settings> FindByAppTitle(String appTitle)
        {
            String stmtId = "T_Settings.FindByAppTitle";
            IList<T_Settings> result = MyISqlMap.QueryForList<T_Settings>(stmtId, appTitle);
            return result;
        }
        public IList<T_Settings> FindByPromptTitle(String promptTitle)
        {
            String stmtId = "T_Settings.FindByPromptTitle";
            IList<T_Settings> result = MyISqlMap.QueryForList<T_Settings>(stmtId, promptTitle);
            return result;
        }
        public IList<T_Settings> FindByUserTitle(String userTitle)
        {
            String stmtId = "T_Settings.FindByUserTitle";
            IList<T_Settings> result = MyISqlMap.QueryForList<T_Settings>(stmtId, userTitle);
            return result;
        }
        public IList<T_Settings> FindByUserTitle2(String userTitle2)
        {
            String stmtId = "T_Settings.FindByUserTitle2";
            IList<T_Settings> result = MyISqlMap.QueryForList<T_Settings>(stmtId, userTitle2);
            return result;
        }
        public IList<T_Settings> FindByVer(String ver)
        {
            String stmtId = "T_Settings.FindByVer";
            IList<T_Settings> result = MyISqlMap.QueryForList<T_Settings>(stmtId, ver);
            return result;
        }
        public IList<T_Settings> FindBydefaultTempID(Int32? defaultTempID)
        {
            String stmtId = "T_Settings.FindBydefaultTempID";
            IList<T_Settings> result = MyISqlMap.QueryForList<T_Settings>(stmtId, defaultTempID);
            return result;
        }
        public IList<T_Settings> FindByServerAddr(String serverAddr)
        {
            String stmtId = "T_Settings.FindByServerAddr";
            IList<T_Settings> result = MyISqlMap.QueryForList<T_Settings>(stmtId, serverAddr);
            return result;
        }
        public IList<T_Settings> FindByport(String port)
        {
            String stmtId = "T_Settings.FindByport";
            IList<T_Settings> result = MyISqlMap.QueryForList<T_Settings>(stmtId, port);
            return result;
        }
        public IList<T_Settings> FindBytimeout(Int32? timeout)
        {
            String stmtId = "T_Settings.FindBytimeout";
            IList<T_Settings> result = MyISqlMap.QueryForList<T_Settings>(stmtId, timeout);
            return result;
        }
        public void Insert(T_Settings obj)
        {
            if (obj == null) throw new ArgumentNullException("obj");
            String stmtId = "T_Settings.Insert";
            MyISqlMap.Insert(stmtId, obj);
        }
        public void Add(T_Settings obj)
        {
            Insert(obj);
        }
        public void Update(T_Settings obj)
        {
            if (obj == null) throw new ArgumentNullException("obj");
            String stmtId = "T_Settings.Update";
            MyISqlMap.Update(stmtId, obj);
        }
        public void Delete(T_Settings obj)
        {
            if (obj == null) throw new ArgumentNullException("obj");
            String stmtId = "T_Settings.Delete";
            MyISqlMap.Delete(stmtId, obj);
        }
        public void Delete(String iD)
        {
            if (iD == null) throw new ArgumentNullException("obj");
            String stmtId = "T_Settings.Delete";
            T_Settings obj = new T_Settings();
            obj.ID = iD;
            MyISqlMap.Delete(stmtId, obj);
        }
    }
}
