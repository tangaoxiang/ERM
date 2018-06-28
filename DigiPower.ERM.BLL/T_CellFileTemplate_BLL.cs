using System;
using System.Collections.Generic;
using System.Text;
using ERM.MDL;
namespace ERM.BLL
{
    public class T_CellFileTemplate_BLL : IBLL
    {
        public int GetCount()
        {
            String stmtId = "T_CellFileTemplate.GetCount";
            int result = MyISqlMap.QueryForObject<int>(stmtId, null);
            return result;
        }
        public T_CellFileTemplate Find(String cellID)
        {
            String stmtId = "T_CellFileTemplate.Find";
            T_CellFileTemplate result = MyISqlMap.QueryForObject<T_CellFileTemplate>(stmtId, cellID);
            return result;
        }
        public System.Data.DataSet GetList(T_CellFileTemplate obj)
        {
            String stmtId = "T_CellFileTemplate.GetList";
            System.Data.DataSet result = DAL.MyBatis.QueryForDataSet(stmtId, obj);
            return result;
        }
        public System.Data.DataSet GetList(String strWhere)
        {
            String stmtId = "T_CellFileTemplate.GetList";
            if (strWhere == null || strWhere == "" || strWhere == "1=1")
            {
                strWhere = null;
                stmtId = "T_CellFileTemplate.GetAll";
            }
            System.Data.DataSet result = DAL.MyBatis.QueryForDataSet(stmtId, strWhere);
            return result;
        }
        public bool Exists(String cellID)
        {
            String stmtId = "T_CellFileTemplate.Exists";
            bool result = MyISqlMap.QueryForObject<bool>(stmtId, cellID);
            return result;
        }
        public IList<T_CellFileTemplate> GetAll()
        {
            String stmtId = "T_CellFileTemplate.GetAll";
            IList<T_CellFileTemplate> result = MyISqlMap.QueryForList<T_CellFileTemplate>(stmtId, null);
            return result;
        }
        public IList<T_CellFileTemplate> FindByFileID(String fileID)
        {
            String stmtId = "T_CellFileTemplate.FindByFileID";
            IList<T_CellFileTemplate> result = MyISqlMap.QueryForList<T_CellFileTemplate>(stmtId, fileID);
            return result;
        }



        public IList<T_CellFileTemplate> FindByMyID(String myID)
        {
            String stmtId = "T_CellFileTemplate.FindByMyID";
            IList<T_CellFileTemplate> result = MyISqlMap.QueryForList<T_CellFileTemplate>(stmtId, myID);
            return result;
        }
        public IList<T_CellFileTemplate> FindByparentid(String parentid)
        {
            String stmtId = "T_CellFileTemplate.FindByparentid";
            IList<T_CellFileTemplate> result = MyISqlMap.QueryForList<T_CellFileTemplate>(stmtId, parentid);
            return result;
        }
        public IList<T_CellFileTemplate> FindBycodeno(String codeno)
        {
            String stmtId = "T_CellFileTemplate.FindBycodeno";
            IList<T_CellFileTemplate> result = MyISqlMap.QueryForList<T_CellFileTemplate>(stmtId, codeno);
            return result;
        }
        public IList<T_CellFileTemplate> FindBytitle(String title)
        {
            String stmtId = "T_CellFileTemplate.FindBytitle";
            IList<T_CellFileTemplate> result = MyISqlMap.QueryForList<T_CellFileTemplate>(stmtId, title);
            return result;
        }
        public IList<T_CellFileTemplate> FindByfilepath(String filepath)
        {
            String stmtId = "T_CellFileTemplate.FindByfilepath";
            IList<T_CellFileTemplate> result = MyISqlMap.QueryForList<T_CellFileTemplate>(stmtId, filepath);
            return result;
        }
        public IList<T_CellFileTemplate> FindByisvisible(Int32? isvisible)
        {
            String stmtId = "T_CellFileTemplate.FindByisvisible";
            IList<T_CellFileTemplate> result = MyISqlMap.QueryForList<T_CellFileTemplate>(stmtId, isvisible);
            return result;
        }
        public IList<T_CellFileTemplate> FindByorderindex(Int32? orderindex)
        {
            String stmtId = "T_CellFileTemplate.FindByorderindex";
            IList<T_CellFileTemplate> result = MyISqlMap.QueryForList<T_CellFileTemplate>(stmtId, orderindex);
            return result;
        }
        public void Insert(T_CellFileTemplate obj)
        {
            if (obj == null) throw new ArgumentNullException("obj");
            String stmtId = "T_CellFileTemplate.Insert";
            MyISqlMap.Insert(stmtId, obj);
        }
        public void Add(T_CellFileTemplate obj)
        {
            Insert(obj);
        }
        public void Update(T_CellFileTemplate obj)
        {
            if (obj == null) throw new ArgumentNullException("obj");
            String stmtId = "T_CellFileTemplate.Update";
            MyISqlMap.Update(stmtId, obj);
        }
        public void Delete(T_CellFileTemplate obj)
        {
            if (obj == null) throw new ArgumentNullException("obj");
            String stmtId = "T_CellFileTemplate.Delete";
            MyISqlMap.Delete(stmtId, obj);
        }
        public void Delete(String cellID)
        {
            if (cellID == null) throw new ArgumentNullException("obj");
            String stmtId = "T_CellFileTemplate.Delete";
            T_CellFileTemplate obj = new T_CellFileTemplate();
            obj.CellID = cellID;
            MyISqlMap.Delete(stmtId, obj);
        }
    }
}
