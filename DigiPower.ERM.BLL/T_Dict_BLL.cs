using System;
using System.Collections.Generic;
using System.Text;
using ERM.MDL;
namespace ERM.BLL
{
    public class T_Dict_BLL : IBLL
    {
        public int GetCount()
        {
            String stmtId = "T_Dict.GetCount";
            int result = MyISqlMap.QueryForObject<int>(stmtId, null);
            return result;
        }
        public T_Dict Find(Int32 iD)
        {
            String stmtId = "T_Dict.Find";
            T_Dict result = MyISqlMap.QueryForObject<T_Dict>(stmtId, iD);
            return result;
        }
        public System.Data.DataSet GetList(String strWhere)
        {
            String stmtId = "T_Dict.GetList";
            if (strWhere == null || strWhere == "" || strWhere == "1=1")
            {
                strWhere = null;
                stmtId = "T_Dict.GetAll";
            }
            System.Data.DataSet result = DAL.MyBatis.QueryForDataSet(stmtId, strWhere);
            return result;
        }
        public bool Exists(Int32 iD)
        {
            String stmtId = "T_Dict.Exists";
            bool result = MyISqlMap.QueryForObject<bool>(stmtId, iD);
            return result;
        }
        public IList<T_Dict> GetAll()
        {
            String stmtId = "T_Dict.GetAll";
            IList<T_Dict> result = MyISqlMap.QueryForList<T_Dict>(stmtId, null);
            return result;
        }
        public IList<T_Dict> FindByKeyWord(String keyWord)
        {
            String stmtId = "T_Dict.FindByKeyWord";
            IList<T_Dict> result = MyISqlMap.QueryForList<T_Dict>(stmtId, keyWord);
            return result;
        }
        public IList<T_Dict> FindByDisplayName(String displayName)
        {
            String stmtId = "T_Dict.FindByDisplayName";
            IList<T_Dict> result = MyISqlMap.QueryForList<T_Dict>(stmtId, displayName);
            return result;
        }
        public IList<T_Dict> FindByValueName(String valueName)
        {
            String stmtId = "T_Dict.FindByValueName";
            IList<T_Dict> result = MyISqlMap.QueryForList<T_Dict>(stmtId, valueName);
            return result;
        }
        public IList<T_Dict> FindByOrderIndex(Int32? orderIndex)
        {
            String stmtId = "T_Dict.FindByOrderIndex";
            IList<T_Dict> result = MyISqlMap.QueryForList<T_Dict>(stmtId, orderIndex);
            return result;
        }
        public void Insert(T_Dict obj)
        {
            if (obj == null) throw new ArgumentNullException("obj");
            String stmtId = "T_Dict.Insert";
            MyISqlMap.Insert(stmtId, obj);
        }
        public void Add(T_Dict obj)
        {
            Insert(obj);
        }
        public void Update(T_Dict obj)
        {
            if (obj == null) throw new ArgumentNullException("obj");
            String stmtId = "T_Dict.Update";
            MyISqlMap.Update(stmtId, obj);
        }
        public void Delete(T_Dict obj)
        {
            if (obj == null) throw new ArgumentNullException("obj");
            String stmtId = "T_Dict.Delete";
            MyISqlMap.Delete(stmtId, obj);
        }
        public void Delete(Int32 iD)
        {
            if (iD == null) throw new ArgumentNullException("obj");
            String stmtId = "T_Dict.Delete";
            T_Dict obj = new T_Dict();
            obj.ID = iD;
            MyISqlMap.Delete(stmtId, obj);
        }


        public IList<T_Dict> FindByKeyWordBoxtype(String keyWord)
        {
            String stmtId = "T_Dict.FindByKeyWordBoxtype";
            IList<T_Dict> result = MyISqlMap.QueryForList<T_Dict>(stmtId, keyWord);
            return result;
        }
    }
}
