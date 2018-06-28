using System;
using System.Collections.Generic;
using System.Text;
using ERM.MDL;
namespace ERM.BLL
{
    public class T_CellFile_BLL : IBLL
    {
        public int GetCount()
        {
            String stmtId = "T_CellFile.GetCount";
            int result = MyISqlMap.QueryForObject<int>(stmtId, null);
            return result;
        }
        public T_CellFile Find(String cellID)
        {
            String stmtId = "T_CellFile.Find";
            T_CellFile result = MyISqlMap.QueryForObject<T_CellFile>(stmtId, cellID);
            return result;
        }
        public System.Data.DataSet GetList(MDL.T_CellFile obj)
        {
            String stmtId = "T_CellFile.GetList";
            System.Data.DataSet result = DAL.MyBatis.QueryForDataSet(stmtId, obj);
            return result;
        }
        public System.Data.DataSet GetList(String strWhere)
        {
            String stmtId = "T_CellFile.GetList";
            if (strWhere == null || strWhere == "" || strWhere == "1=1")
            {
                strWhere = null;
                stmtId = "T_CellFile.GetAll";
            }
            System.Data.DataSet result = DAL.MyBatis.QueryForDataSet(stmtId, strWhere);
            return result;
        }
        public bool Exists(String cellID)
        {
            String stmtId = "T_CellFile.Exists";
            bool result = MyISqlMap.QueryForObject<bool>(stmtId, cellID);
            return result;
        }
        public IList<T_CellFile> GetAll()
        {
            String stmtId = "T_CellFile.GetAll";
            IList<T_CellFile> result = MyISqlMap.QueryForList<T_CellFile>(stmtId, null);
            return result;
        }
        public IList<T_CellFile> FindByFileID(String fileID)
        {
            String stmtId = "T_CellFile.FindByFileID";
            IList<T_CellFile> result = MyISqlMap.QueryForList<T_CellFile>(stmtId, fileID);
            return result;
        }
        public IList<T_CellFile> FindByid(String id)
        {
            String stmtId = "T_CellFile.FindByid";
            IList<T_CellFile> result = MyISqlMap.QueryForList<T_CellFile>(stmtId, id);
            return result;
        }
        public IList<T_CellFile> FindByProjectNO(String projectNO)
        {
            String stmtId = "T_CellFile.FindByProjectNO";
            IList<T_CellFile> result = MyISqlMap.QueryForList<T_CellFile>(stmtId, projectNO);
            return result;
        }
        public IList<T_CellFile> FindByTreePath(String treePath)
        {
            String stmtId = "T_CellFile.FindByTreePath";
            IList<T_CellFile> result = MyISqlMap.QueryForList<T_CellFile>(stmtId, treePath);
            return result;
        }
        public IList<T_CellFile> FindByparentid(String parentid)
        {
            String stmtId = "T_CellFile.FindByparentid";
            IList<T_CellFile> result = MyISqlMap.QueryForList<T_CellFile>(stmtId, parentid);
            return result;
        }
        public IList<T_CellFile> FindByPTreePath(String pTreePath)
        {
            String stmtId = "T_CellFile.FindByPTreePath";
            IList<T_CellFile> result = MyISqlMap.QueryForList<T_CellFile>(stmtId, pTreePath);
            return result;
        }
        public IList<T_CellFile> FindBytitle(String title)
        {
            String stmtId = "T_CellFile.FindBytitle";
            IList<T_CellFile> result = MyISqlMap.QueryForList<T_CellFile>(stmtId, title);
            return result;
        }
        public IList<T_CellFile> FindByfilepath(String filepath)
        {
            String stmtId = "T_CellFile.FindByfilepath";
            IList<T_CellFile> result = MyISqlMap.QueryForList<T_CellFile>(stmtId, filepath);
            return result;
        }
        public IList<T_CellFile> FindByexamplepath(String examplepath)
        {
            String stmtId = "T_CellFile.FindByexamplepath";
            IList<T_CellFile> result = MyISqlMap.QueryForList<T_CellFile>(stmtId, examplepath);
            return result;
        }
        public IList<T_CellFile> FindBycodeno(String codeno)
        {
            String stmtId = "T_CellFile.FindBycodeno";
            IList<T_CellFile> result = MyISqlMap.QueryForList<T_CellFile>(stmtId, codeno);
            return result;
        }
        public IList<T_CellFile> FindBycustomdefine(Int32? customdefine)
        {
            String stmtId = "T_CellFile.FindBycustomdefine";
            IList<T_CellFile> result = MyISqlMap.QueryForList<T_CellFile>(stmtId, customdefine);
            return result;
        }
        public IList<T_CellFile> FindByzrr(String zrr)
        {
            String stmtId = "T_CellFile.FindByzrr";
            IList<T_CellFile> result = MyISqlMap.QueryForList<T_CellFile>(stmtId, zrr);
            return result;
        }
        public IList<T_CellFile> FindBycodetype(Int32? codetype)
        {
            String stmtId = "T_CellFile.FindBycodetype";
            IList<T_CellFile> result = MyISqlMap.QueryForList<T_CellFile>(stmtId, codetype);
            return result;
        }
        public IList<T_CellFile> FindByfbmc(String fbmc)
        {
            String stmtId = "T_CellFile.FindByfbmc";
            IList<T_CellFile> result = MyISqlMap.QueryForList<T_CellFile>(stmtId, fbmc);
            return result;
        }
        public IList<T_CellFile> FindByfxmc(String fxmc)
        {
            String stmtId = "T_CellFile.FindByfxmc";
            IList<T_CellFile> result = MyISqlMap.QueryForList<T_CellFile>(stmtId, fxmc);
            return result;
        }
        public IList<T_CellFile> FindByzfbmc(String zfbmc)
        {
            String stmtId = "T_CellFile.FindByzfbmc";
            IList<T_CellFile> result = MyISqlMap.QueryForList<T_CellFile>(stmtId, zfbmc);
            return result;
        }
        public IList<T_CellFile> FindByys(Int32? ys)
        {
            String stmtId = "T_CellFile.FindByys";
            IList<T_CellFile> result = MyISqlMap.QueryForList<T_CellFile>(stmtId, ys);
            return result;
        }
        public IList<T_CellFile> FindByisvisible(Int32? isvisible)
        {
            String stmtId = "T_CellFile.FindByisvisible";
            IList<T_CellFile> result = MyISqlMap.QueryForList<T_CellFile>(stmtId, isvisible);
            return result;
        }
        public IList<T_CellFile> FindByorderindex(Int32? orderindex)
        {
            String stmtId = "T_CellFile.FindByorderindex";
            IList<T_CellFile> result = MyISqlMap.QueryForList<T_CellFile>(stmtId, orderindex);
            return result;
        }
        public void Insert(T_CellFile obj)
        {
            if (obj == null) throw new ArgumentNullException("obj");
            String stmtId = "T_CellFile.Insert";
            MyISqlMap.Insert(stmtId, obj);
        }
        public void Add(T_CellFile obj)
        {
            Insert(obj);
        }
        public void Update(T_CellFile obj)
        {
            if (obj == null) throw new ArgumentNullException("obj");
            String stmtId = "T_CellFile.Update";
            MyISqlMap.Update(stmtId, obj);
        }
        public void Delete(T_CellFile obj)
        {
            if (obj == null) throw new ArgumentNullException("obj");
            String stmtId = "T_CellFile.Delete";
            MyISqlMap.Delete(stmtId, obj);
        }
        public void Delete(String cellID)
        {
            if (cellID == null) throw new ArgumentNullException("obj");
            String stmtId = "T_CellFile.Delete";
            T_CellFile obj = new T_CellFile();
            obj.CellID = cellID;
            MyISqlMap.Delete(stmtId, obj);
        }
    }
}
