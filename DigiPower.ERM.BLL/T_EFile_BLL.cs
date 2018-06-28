using System;
using System.Collections.Generic;
using System.Text;
using ERM.MDL;
namespace ERM.BLL
{
    public class T_EFile_BLL : IBLL
    {
        public int GetCount()
        {
            String stmtId = "T_EFile.GetCount";
            int result = MyISqlMap.QueryForObject<int>(stmtId, null);
            return result;
        }
        public T_EFile Find(String eFileID)
        {
            String stmtId = "T_EFile.Find";
            T_EFile result = MyISqlMap.QueryForObject<T_EFile>(stmtId, eFileID);
            return result;
        }
        public System.Data.DataSet GetList(String strWhere)
        {
            String stmtId = "T_EFile.GetList";
            if (strWhere == null || strWhere == "" || strWhere == "1=1")
            {
                strWhere = null;
                stmtId = "T_EFile.GetAll";
            }
            System.Data.DataSet result = DAL.MyBatis.QueryForDataSet(stmtId, strWhere);
            return result;
        }
        public bool Exists(String eFileID)
        {
            String stmtId = "T_EFile.Exists";
            bool result = MyISqlMap.QueryForObject<bool>(stmtId, eFileID);
            return result;
        }
        public IList<T_EFile> GetAll()
        {
            String stmtId = "T_EFile.GetAll";
            IList<T_EFile> result = MyISqlMap.QueryForList<T_EFile>(stmtId, null);
            return result;
        }
        public IList<T_EFile> FindByFileID(String fileID)
        {
            String stmtId = "T_EFile.FindByFileID";
            IList<T_EFile> result = MyISqlMap.QueryForList<T_EFile>(stmtId, fileID);
            return result;
        }
        public IList<T_EFile> FindByattachid(Int32 attachid)
        {
            String stmtId = "T_EFile.FindByattachid";
            IList<T_EFile> result = MyISqlMap.QueryForList<T_EFile>(stmtId, attachid);
            return result;
        }
        public IList<T_EFile> FindByprojectno(String projectno)
        {
            String stmtId = "T_EFile.FindByprojectno";
            IList<T_EFile> result = MyISqlMap.QueryForList<T_EFile>(stmtId, projectno);
            return result;
        }
        public IList<T_EFile> FindBytitle(String title)
        {
            String stmtId = "T_EFile.FindBytitle";
            IList<T_EFile> result = MyISqlMap.QueryForList<T_EFile>(stmtId, title);
            return result;
        }
        public IList<T_EFile> FindByfilepath(String filepath)
        {
            String stmtId = "T_EFile.FindByfilepath";
            IList<T_EFile> result = MyISqlMap.QueryForList<T_EFile>(stmtId, filepath);
            return result;
        }
        public IList<T_EFile> FindByfileTreePath(String fileTreePath)
        {
            String stmtId = "T_EFile.FindByfileTreePath";
            IList<T_EFile> result = MyISqlMap.QueryForList<T_EFile>(stmtId, fileTreePath);
            return result;
        }
        public IList<T_EFile> FindByFileOrderIndex(Int32? fileOrderIndex)
        {
            String stmtId = "T_EFile.FindByFileOrderIndex";
            IList<T_EFile> result = MyISqlMap.QueryForList<T_EFile>(stmtId, fileOrderIndex);
            return result;
        }
        public IList<T_EFile> FindByArchiveID(String archiveID)
        {
            String stmtId = "T_EFile.FindByArchiveID";
            IList<T_EFile> result = MyISqlMap.QueryForList<T_EFile>(stmtId, archiveID);
            return result;
        }
        public IList<T_EFile> FindByOrderIndex2(Int32? orderIndex2)
        {
            String stmtId = "T_EFile.FindByOrderIndex2";
            IList<T_EFile> result = MyISqlMap.QueryForList<T_EFile>(stmtId, orderIndex2);
            return result;
        }
        public IList<T_EFile> FindByzrzbsm(String zrzbsm)
        {
            String stmtId = "T_EFile.FindByzrzbsm";
            IList<T_EFile> result = MyISqlMap.QueryForList<T_EFile>(stmtId, zrzbsm);
            return result;
        }
        public IList<T_EFile> FindByzrzlb(String zrzlb)
        {
            String stmtId = "T_EFile.FindByzrzlb";
            IList<T_EFile> result = MyISqlMap.QueryForList<T_EFile>(stmtId, zrzlb);
            return result;
        }
        public IList<T_EFile> FindByzrzmc(String zrzmc)
        {
            String stmtId = "T_EFile.FindByzrzmc";
            IList<T_EFile> result = MyISqlMap.QueryForList<T_EFile>(stmtId, zrzmc);
            return result;
        }
        public IList<T_EFile> FindByzezzzfw(String zezzzfw)
        {
            String stmtId = "T_EFile.FindByzezzzfw";
            IList<T_EFile> result = MyISqlMap.QueryForList<T_EFile>(stmtId, zezzzfw);
            return result;
        }
        public IList<T_EFile> FindByext(String ext)
        {
            String stmtId = "T_EFile.FindByext";
            IList<T_EFile> result = MyISqlMap.QueryForList<T_EFile>(stmtId, ext);
            return result;
        }
        public IList<T_EFile> FindBywjly(String wjly)
        {
            String stmtId = "T_EFile.FindBywjly";
            IList<T_EFile> result = MyISqlMap.QueryForList<T_EFile>(stmtId, wjly);
            return result;
        }
        public IList<T_EFile> FindByDocYs(Int32? docYs)
        {
            String stmtId = "T_EFile.FindByDocYs";
            IList<T_EFile> result = MyISqlMap.QueryForList<T_EFile>(stmtId, docYs);
            return result;
        }
        public IList<T_EFile> FindByyswjpath(String yswjpath)
        {
            String stmtId = "T_EFile.FindByyswjpath";
            IList<T_EFile> result = MyISqlMap.QueryForList<T_EFile>(stmtId, yswjpath);
            return result;
        }
        public IList<T_EFile> FindBydocType(String docType)
        {
            String stmtId = "T_EFile.FindBydocType";
            IList<T_EFile> result = MyISqlMap.QueryForList<T_EFile>(stmtId, docType);
            return result;
        }
        public IList<T_EFile> FindBydocFormat(String docFormat)
        {
            String stmtId = "T_EFile.FindBydocFormat";
            IList<T_EFile> result = MyISqlMap.QueryForList<T_EFile>(stmtId, docFormat);
            return result;
        }
        public IList<T_EFile> FindByDraft(String draft)
        {
            String stmtId = "T_EFile.FindByDraft";
            IList<T_EFile> result = MyISqlMap.QueryForList<T_EFile>(stmtId, draft);
            return result;
        }
        public IList<T_EFile> FindByOriOpenPro(String oriOpenPro)
        {
            String stmtId = "T_EFile.FindByOriOpenPro";
            IList<T_EFile> result = MyISqlMap.QueryForList<T_EFile>(stmtId, oriOpenPro);
            return result;
        }
        public IList<T_EFile> FindByOrderIndex(Int32? orderIndex)
        {
            String stmtId = "T_EFile.FindByOrderIndex";
            IList<T_EFile> result = MyISqlMap.QueryForList<T_EFile>(stmtId, orderIndex);
            return result;
        }
        public void Insert(T_EFile obj)
        {
            if (obj == null) throw new ArgumentNullException("obj");
            String stmtId = "T_EFile.Insert";
            MyISqlMap.Insert(stmtId, obj);
        }
        public void Add(T_EFile obj)
        {
            Insert(obj);
        }
        public void Update(T_EFile obj)
        {
            if (obj == null) throw new ArgumentNullException("obj");
            String stmtId = "T_EFile.Update";
            MyISqlMap.Update(stmtId, obj);
        }
        public void Delete(T_EFile obj)
        {
            if (obj == null) throw new ArgumentNullException("obj");
            String stmtId = "T_EFile.Delete";
            MyISqlMap.Delete(stmtId, obj);
        }
        public void Delete(String eFileID)
        {
            if (eFileID == null) throw new ArgumentNullException("obj");
            String stmtId = "T_EFile.Delete";
            T_EFile obj = new T_EFile();
            obj.EFileID = eFileID;
            MyISqlMap.Delete(stmtId, obj);
        }
    }
}
