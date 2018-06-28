using System;
using System.Collections.Generic;
using System.Text;
using ERM.MDL;
namespace ERM.BLL
{
    public class T_FileListTemplate_BLL : IBLL
    {
        public int GetCount()
        {
            String stmtId = "T_FileListTemplate.GetCount";
            int result = MyISqlMap.QueryForObject<int>(stmtId, null);
            return result;
        }

        public T_FileListTemplate FindByProjectCategory(String projectCategory)
        {
            String stmtId = "T_FileListTemplate.FindByProjectCategory";
            T_FileListTemplate result = MyISqlMap.QueryForObject<T_FileListTemplate>(stmtId, projectCategory);
            return result;
        }

        public IList<T_FileListTemplate> Find(T_FileListTemplate obj)
        {
            String stmtId = "T_FileListTemplate.Find";
            IList<T_FileListTemplate> result = MyISqlMap.QueryForList<T_FileListTemplate>(stmtId, obj);
            return result;
        }
        public IList<T_FileListTemplate> GetFileTypeByCategory(string obj)
        {
            String stmtId = "T_FileListTemplate.GetFileTypeByCategory";
            IList<T_FileListTemplate> result = MyISqlMap.QueryForList<T_FileListTemplate>(stmtId, obj);
            return result;
        }
        
        public System.Data.DataSet GetList(T_FileListTemplate obj)
        {
            String stmtId = "T_FileListTemplate.GetList";
            System.Data.DataSet result = DAL.MyBatis.QueryForDataSet(stmtId, obj);
            return result;
        }
        public IList<T_FileListTemplate> GetChildList(T_FileListTemplate obj)
        {
            String stmtId = "T_FileListTemplate.GetChildList";
            IList<T_FileListTemplate> result = MyISqlMap.QueryForList<T_FileListTemplate>(stmtId, obj);
            return result;
        }
        public IList<T_FileListTemplate> GetFileByGDIDList(T_FileListTemplate obj)
        {
            String stmtId = "T_FileListTemplate.GetFileByGDIDList";
            IList<T_FileListTemplate> result = MyISqlMap.QueryForList<T_FileListTemplate>(stmtId, obj);
            return result;
        }
        public System.Data.DataSet GetChildDS(T_FileListTemplate obj)
        {
            String stmtId = "T_FileListTemplate.GetChildDS";
            System.Data.DataSet result = DAL.MyBatis.QueryForDataSet(stmtId, obj);
            return result;
        }
        public bool Exists(String fileID, String projectNO)
        {
            MDL.T_FileListTemplate obj = new T_FileListTemplate();
            obj.FileID = fileID;
            String stmtId = "T_FileListTemplate.Exists";
            bool result = MyISqlMap.QueryForObject<bool>(stmtId, obj);
            return result;
        }
        public IList<T_FileListTemplate> GetAll()
        {
            String stmtId = "T_FileListTemplate.GetAll";
            IList<T_FileListTemplate> result = MyISqlMap.QueryForList<T_FileListTemplate>(stmtId, null);
            return result;
        }
        public System.Data.DataTable GetAllDS(string ProjectNO)
        {
            String stmtId = "T_FileListTemplate.GetAllDS";
            System.Data.DataTable result = DAL.MyBatis.QueryForDataTable(stmtId, ProjectNO);
            return result;
        }
        public IList<T_FileListTemplate> FindByFileID(String fileID)
        {
            String stmtId = "T_FileListTemplate.FindByFileID";
            IList<T_FileListTemplate> result = MyISqlMap.QueryForList<T_FileListTemplate>(stmtId, fileID);
            return result;
        }
        public IList<T_FileListTemplate> FindByParentID(String parentID, string projectNO)
        {
            String stmtId = "T_FileListTemplate.FindByParentID";
            MDL.T_FileListTemplate obj = new T_FileListTemplate();
            obj.ParentID = parentID;
            IList<T_FileListTemplate> result = MyISqlMap.QueryForList<T_FileListTemplate>(stmtId, obj);
            return result;
        }
        public IList<T_FileListTemplate> FindByProjectNO(String projectNO)
        {
            String stmtId = "T_FileListTemplate.FindByProjectNO";
            IList<T_FileListTemplate> result = MyISqlMap.QueryForList<T_FileListTemplate>(stmtId, projectNO);
            return result;
        }
        public IList<T_FileListTemplate> FindByArchiveID(String archiveID, string projectNO)
        {
            String stmtId = "T_FileListTemplate.FindByArchiveID";
            MDL.T_FileListTemplate obj = new T_FileListTemplate();
            IList<T_FileListTemplate> result = MyISqlMap.QueryForList<T_FileListTemplate>(stmtId, obj);
            return result;
        }
        public IList<T_FileListTemplate> FindBywjtm(String wjtm)
        {
            String stmtId = "T_FileListTemplate.FindBywjtm";
            IList<T_FileListTemplate> result = MyISqlMap.QueryForList<T_FileListTemplate>(stmtId, wjtm);
            return result;
        }
        public IList<T_FileListTemplate> FindByselected(Int32? selected)
        {
            String stmtId = "T_FileListTemplate.FindByselected";
            IList<T_FileListTemplate> result = MyISqlMap.QueryForList<T_FileListTemplate>(stmtId, selected);
            return result;
        }
        public IList<T_FileListTemplate> FindByid(String id)
        {
            String stmtId = "T_FileListTemplate.FindByid";
            IList<T_FileListTemplate> result = MyISqlMap.QueryForList<T_FileListTemplate>(stmtId, id);
            return result;
        }
        public IList<T_FileListTemplate> FindBygdwj(String gdwj)
        {
            String stmtId = "T_FileListTemplate.FindBygdwj";
            IList<T_FileListTemplate> result = MyISqlMap.QueryForList<T_FileListTemplate>(stmtId, gdwj);
            return result;
        }
        public IList<T_FileListTemplate> FindByjsdw(String jsdw)
        {
            String stmtId = "T_FileListTemplate.FindByjsdw";
            IList<T_FileListTemplate> result = MyISqlMap.QueryForList<T_FileListTemplate>(stmtId, jsdw);
            return result;
        }
        public IList<T_FileListTemplate> FindBysgdw(String sgdw)
        {
            String stmtId = "T_FileListTemplate.FindBysgdw";
            IList<T_FileListTemplate> result = MyISqlMap.QueryForList<T_FileListTemplate>(stmtId, sgdw);
            return result;
        }
        public IList<T_FileListTemplate> FindBysjdw(String sjdw)
        {
            String stmtId = "T_FileListTemplate.FindBysjdw";
            IList<T_FileListTemplate> result = MyISqlMap.QueryForList<T_FileListTemplate>(stmtId, sjdw);
            return result;
        }
        public IList<T_FileListTemplate> FindByjldw(String jldw)
        {
            String stmtId = "T_FileListTemplate.FindByjldw";
            IList<T_FileListTemplate> result = MyISqlMap.QueryForList<T_FileListTemplate>(stmtId, jldw);
            return result;
        }
        public IList<T_FileListTemplate> FindBycjdag(String cjdag)
        {
            String stmtId = "T_FileListTemplate.FindBycjdag";
            IList<T_FileListTemplate> result = MyISqlMap.QueryForList<T_FileListTemplate>(stmtId, cjdag);
            return result;
        }
        public IList<T_FileListTemplate> FindBydatawindow_id(String datawindowId)
        {
            String stmtId = "T_FileListTemplate.FindBydatawindow_id";
            IList<T_FileListTemplate> result = MyISqlMap.QueryForList<T_FileListTemplate>(stmtId, datawindowId);
            return result;
        }
        public IList<T_FileListTemplate> FindBytable_name(String tableName)
        {
            String stmtId = "T_FileListTemplate.FindBytable_name";
            IList<T_FileListTemplate> result = MyISqlMap.QueryForList<T_FileListTemplate>(stmtId, tableName);
            return result;
        }
        public IList<T_FileListTemplate> FindBytable_standerd(String tableStanderd)
        {
            String stmtId = "T_FileListTemplate.FindBytable_standerd";
            IList<T_FileListTemplate> result = MyISqlMap.QueryForList<T_FileListTemplate>(stmtId, tableStanderd);
            return result;
        }
        public IList<T_FileListTemplate> FindByextension1(String extension1)
        {
            String stmtId = "T_FileListTemplate.FindByextension1";
            IList<T_FileListTemplate> result = MyISqlMap.QueryForList<T_FileListTemplate>(stmtId, extension1);
            return result;
        }
        public IList<T_FileListTemplate> FindByextension2(String extension2)
        {
            String stmtId = "T_FileListTemplate.FindByextension2";
            IList<T_FileListTemplate> result = MyISqlMap.QueryForList<T_FileListTemplate>(stmtId, extension2);
            return result;
        }
        public IList<T_FileListTemplate> FindByextension3(String extension3)
        {
            String stmtId = "T_FileListTemplate.FindByextension3";
            IList<T_FileListTemplate> result = MyISqlMap.QueryForList<T_FileListTemplate>(stmtId, extension3);
            return result;
        }
        public IList<T_FileListTemplate> FindBywjmj(String wjmj)
        {
            String stmtId = "T_FileListTemplate.FindBywjmj";
            IList<T_FileListTemplate> result = MyISqlMap.QueryForList<T_FileListTemplate>(stmtId, wjmj);
            return result;
        }
        public IList<T_FileListTemplate> FindByzrr(String zrr)
        {
            String stmtId = "T_FileListTemplate.FindByzrr";
            IList<T_FileListTemplate> result = MyISqlMap.QueryForList<T_FileListTemplate>(stmtId, zrr);
            return result;
        }
        public IList<T_FileListTemplate> FindBygclx(String gclx)
        {
            String stmtId = "T_FileListTemplate.FindBygclx";
            IList<T_FileListTemplate> result = MyISqlMap.QueryForList<T_FileListTemplate>(stmtId, gclx);
            return result;
        }
        public IList<T_FileListTemplate> FindByTreePath(String treePath)
        {
            String stmtId = "T_FileListTemplate.FindByTreePath";
            IList<T_FileListTemplate> result = MyISqlMap.QueryForList<T_FileListTemplate>(stmtId, treePath);
            return result;
        }
        public IList<T_FileListTemplate> FindByOrderIndex(Int32? orderIndex)
        {
            String stmtId = "T_FileListTemplate.FindByOrderIndex";
            IList<T_FileListTemplate> result = MyISqlMap.QueryForList<T_FileListTemplate>(stmtId, orderIndex);
            return result;
        }
        public IList<T_FileListTemplate> FindByisvisible(Int32? isvisible)
        {
            String stmtId = "T_FileListTemplate.FindByisvisible";
            IList<T_FileListTemplate> result = MyISqlMap.QueryForList<T_FileListTemplate>(stmtId, isvisible);
            return result;
        }
        public IList<T_FileListTemplate> FindBypTreePath(String pTreePath)
        {
            String stmtId = "T_FileListTemplate.FindBypTreePath";
            IList<T_FileListTemplate> result = MyISqlMap.QueryForList<T_FileListTemplate>(stmtId, pTreePath);
            return result;
        }
        public IList<T_FileListTemplate> FindBywjcj(String wjcj)
        {
            String stmtId = "T_FileListTemplate.FindBywjcj";
            IList<T_FileListTemplate> result = MyISqlMap.QueryForList<T_FileListTemplate>(stmtId, wjcj);
            return result;
        }
        public IList<T_FileListTemplate> FindBywjbsm(String wjbsm)
        {
            String stmtId = "T_FileListTemplate.FindBywjbsm";
            IList<T_FileListTemplate> result = MyISqlMap.QueryForList<T_FileListTemplate>(stmtId, wjbsm);
            return result;
        }
        public IList<T_FileListTemplate> FindBywjmc(String wjmc)
        {
            String stmtId = "T_FileListTemplate.FindBywjmc";
            IList<T_FileListTemplate> result = MyISqlMap.QueryForList<T_FileListTemplate>(stmtId, wjmc);
            return result;
        }
        public IList<T_FileListTemplate> FindBybzdw(String bzdw)
        {
            String stmtId = "T_FileListTemplate.FindBybzdw";
            IList<T_FileListTemplate> result = MyISqlMap.QueryForList<T_FileListTemplate>(stmtId, bzdw);
            return result;
        }
        public IList<T_FileListTemplate> FindBywh(String wh)
        {
            String stmtId = "T_FileListTemplate.FindBywh";
            IList<T_FileListTemplate> result = MyISqlMap.QueryForList<T_FileListTemplate>(stmtId, wh);
            return result;
        }
        public IList<T_FileListTemplate> FindBybgqx(String bgqx)
        {
            String stmtId = "T_FileListTemplate.FindBybgqx";
            IList<T_FileListTemplate> result = MyISqlMap.QueryForList<T_FileListTemplate>(stmtId, bgqx);
            return result;
        }
        public IList<T_FileListTemplate> FindBymj(String mj)
        {
            String stmtId = "T_FileListTemplate.FindBymj";
            IList<T_FileListTemplate> result = MyISqlMap.QueryForList<T_FileListTemplate>(stmtId, mj);
            return result;
        }
        public IList<T_FileListTemplate> FindByCreateDate(DateTime? createDate)
        {
            String stmtId = "T_FileListTemplate.FindByCreateDate";
            IList<T_FileListTemplate> result = MyISqlMap.QueryForList<T_FileListTemplate>(stmtId, createDate);
            return result;
        }
        public IList<T_FileListTemplate> FindByCreateDate2(DateTime? createDate2)
        {
            String stmtId = "T_FileListTemplate.FindByCreateDate2";
            IList<T_FileListTemplate> result = MyISqlMap.QueryForList<T_FileListTemplate>(stmtId, createDate2);
            return result;
        }
        public IList<T_FileListTemplate> FindByztlx(String ztlx)
        {
            String stmtId = "T_FileListTemplate.FindByztlx";
            IList<T_FileListTemplate> result = MyISqlMap.QueryForList<T_FileListTemplate>(stmtId, ztlx);
            return result;
        }
        public IList<T_FileListTemplate> FindBysl(Int32? sl)
        {
            String stmtId = "T_FileListTemplate.FindBysl";
            IList<T_FileListTemplate> result = MyISqlMap.QueryForList<T_FileListTemplate>(stmtId, sl);
            return result;
        }
        public IList<T_FileListTemplate> FindBydw(String dw)
        {
            String stmtId = "T_FileListTemplate.FindBydw";
            IList<T_FileListTemplate> result = MyISqlMap.QueryForList<T_FileListTemplate>(stmtId, dw);
            return result;
        }
        public IList<T_FileListTemplate> FindBygg(String gg)
        {
            String stmtId = "T_FileListTemplate.FindBygg";
            IList<T_FileListTemplate> result = MyISqlMap.QueryForList<T_FileListTemplate>(stmtId, gg);
            return result;
        }
        public IList<T_FileListTemplate> FindBywjgbdm(String wjgbdm)
        {
            String stmtId = "T_FileListTemplate.FindBywjgbdm";
            IList<T_FileListTemplate> result = MyISqlMap.QueryForList<T_FileListTemplate>(stmtId, wjgbdm);
            return result;
        }
        public IList<T_FileListTemplate> FindBywjlxdm(String wjlxdm)
        {
            String stmtId = "T_FileListTemplate.FindBywjlxdm";
            IList<T_FileListTemplate> result = MyISqlMap.QueryForList<T_FileListTemplate>(stmtId, wjlxdm);
            return result;
        }
        public IList<T_FileListTemplate> FindBywjgs(String wjgs)
        {
            String stmtId = "T_FileListTemplate.FindBywjgs";
            IList<T_FileListTemplate> result = MyISqlMap.QueryForList<T_FileListTemplate>(stmtId, wjgs);
            return result;
        }
        public IList<T_FileListTemplate> FindBywjdx(String wjdx)
        {
            String stmtId = "T_FileListTemplate.FindBywjdx";
            IList<T_FileListTemplate> result = MyISqlMap.QueryForList<T_FileListTemplate>(stmtId, wjdx);
            return result;
        }
        public IList<T_FileListTemplate> FindBypsdd(String psdd)
        {
            String stmtId = "T_FileListTemplate.FindBypsdd";
            IList<T_FileListTemplate> result = MyISqlMap.QueryForList<T_FileListTemplate>(stmtId, psdd);
            return result;
        }
        public IList<T_FileListTemplate> FindBypsz(String psz)
        {
            String stmtId = "T_FileListTemplate.FindBypsz";
            IList<T_FileListTemplate> result = MyISqlMap.QueryForList<T_FileListTemplate>(stmtId, psz);
            return result;
        }
        public IList<T_FileListTemplate> FindBypssj(DateTime? pssj)
        {
            String stmtId = "T_FileListTemplate.FindBypssj";
            IList<T_FileListTemplate> result = MyISqlMap.QueryForList<T_FileListTemplate>(stmtId, pssj);
            return result;
        }
        public IList<T_FileListTemplate> FindBysb(String sb)
        {
            String stmtId = "T_FileListTemplate.FindBysb";
            IList<T_FileListTemplate> result = MyISqlMap.QueryForList<T_FileListTemplate>(stmtId, sb);
            return result;
        }
        public IList<T_FileListTemplate> FindByfbl(String fbl)
        {
            String stmtId = "T_FileListTemplate.FindByfbl";
            IList<T_FileListTemplate> result = MyISqlMap.QueryForList<T_FileListTemplate>(stmtId, fbl);
            return result;
        }
        public IList<T_FileListTemplate> FindByxjpp(String xjpp)
        {
            String stmtId = "T_FileListTemplate.FindByxjpp";
            IList<T_FileListTemplate> result = MyISqlMap.QueryForList<T_FileListTemplate>(stmtId, xjpp);
            return result;
        }
        public IList<T_FileListTemplate> FindByxjxh(String xjxh)
        {
            String stmtId = "T_FileListTemplate.FindByxjxh";
            IList<T_FileListTemplate> result = MyISqlMap.QueryForList<T_FileListTemplate>(stmtId, xjxh);
            return result;
        }
        public IList<T_FileListTemplate> FindBybz(String bz)
        {
            String stmtId = "T_FileListTemplate.FindBybz";
            IList<T_FileListTemplate> result = MyISqlMap.QueryForList<T_FileListTemplate>(stmtId, bz);
            return result;
        }
        public IList<T_FileListTemplate> FindByfilepath(String filepath)
        {
            String stmtId = "T_FileListTemplate.FindByfilepath";
            IList<T_FileListTemplate> result = MyISqlMap.QueryForList<T_FileListTemplate>(stmtId, filepath);
            return result;
        }
        public IList<T_FileListTemplate> FindByfileStatus(String fileStatus)
        {
            String stmtId = "T_FileListTemplate.FindByfileStatus";
            IList<T_FileListTemplate> result = MyISqlMap.QueryForList<T_FileListTemplate>(stmtId, fileStatus);
            return result;
        }
        public IList<T_FileListTemplate> FindBywzz(String wzz)
        {
            String stmtId = "T_FileListTemplate.FindBywzz";
            IList<T_FileListTemplate> result = MyISqlMap.QueryForList<T_FileListTemplate>(stmtId, wzz);
            return result;
        }
        public IList<T_FileListTemplate> FindBytzz(String tzz)
        {
            String stmtId = "T_FileListTemplate.FindBytzz";
            IList<T_FileListTemplate> result = MyISqlMap.QueryForList<T_FileListTemplate>(stmtId, tzz);
            return result;
        }
        public IList<T_FileListTemplate> FindBydtz(String dtz)
        {
            String stmtId = "T_FileListTemplate.FindBydtz";
            IList<T_FileListTemplate> result = MyISqlMap.QueryForList<T_FileListTemplate>(stmtId, dtz);
            return result;
        }
        public IList<T_FileListTemplate> FindByzpz(String zpz)
        {
            String stmtId = "T_FileListTemplate.FindByzpz";
            IList<T_FileListTemplate> result = MyISqlMap.QueryForList<T_FileListTemplate>(stmtId, zpz);
            return result;
        }
        public IList<T_FileListTemplate> FindBydpz(String dpz)
        {
            String stmtId = "T_FileListTemplate.FindBydpz";
            IList<T_FileListTemplate> result = MyISqlMap.QueryForList<T_FileListTemplate>(stmtId, dpz);
            return result;
        }
        public IList<T_FileListTemplate> FindByisSign(Int32? isSign)
        {
            String stmtId = "T_FileListTemplate.FindByisSign";
            IList<T_FileListTemplate> result = MyISqlMap.QueryForList<T_FileListTemplate>(stmtId, isSign);
            return result;
        }
        public void Insert(T_FileListTemplate obj)
        {
            if (obj == null) throw new ArgumentNullException("obj");
            String stmtId = "T_FileListTemplate.Insert";
            MyISqlMap.Insert(stmtId, obj);
        }
        public void Add(T_FileListTemplate obj)
        {
            Insert(obj);
        }
        public int Update(T_FileListTemplate obj)
        {
            if (obj == null) throw new ArgumentNullException("obj");
            String stmtId = "T_FileListTemplate.Update";
            return MyISqlMap.Update(stmtId, obj);
        }
        public int UpdateFileListArchive(T_FileListTemplate obj, ref string sqltmp)
        {
            if (obj == null) throw new ArgumentNullException("obj");
            String stmtId = "T_FileListTemplate.UpdateFileListArchive";
            sqltmp = ERM.DAL.MyBatis.QueryForSql(stmtId, obj);
            return MyISqlMap.Update(stmtId, obj);
        }
        public void Delete(T_FileListTemplate obj)
        {
            if (obj == null) throw new ArgumentNullException("obj");
            String stmtId = "T_FileListTemplate.Delete";
            MyISqlMap.Delete(stmtId, obj);
        }
        public void Delete(String fileID)
        {
            if (fileID == null) throw new ArgumentNullException("obj");
            String stmtId = "T_FileListTemplate.Delete";
            MyISqlMap.Delete(stmtId, fileID);
        }

        public void DeleteGdList(String fileID)
        {
            String stmtId = "T_FileListTemplate.DeleteGdList";
            T_FileListTemplate obj = new T_FileListTemplate();
            obj.FileID = fileID;
            MyISqlMap.Delete(stmtId, obj);
        }

        public IList<T_FileListTemplate> FindByKeyString(T_FileListTemplate obj)
        {
            String stmtId = "T_FileListTemplate.FindByKeyString";
            IList<T_FileListTemplate> result = MyISqlMap.QueryForList<T_FileListTemplate>(stmtId, obj);
            return result;
        }
        public int GetMaxOrderIndex(string ParentFileID, string ProjectNO)
        {
            String stmtId = "T_FileListTemplate.GetMaxOrderIndex";
            MDL.T_FileListTemplate obj = new T_FileListTemplate();
            obj.ParentID = ParentFileID;
            object result = MyISqlMap.QueryForObject(stmtId, obj);
            if (result == null)
                result = "0";
            return int.Parse(result.ToString());
        }
        public int GetMaxGdFileOrderIndex(string GDID, string ProjectNO)
        {
            String stmtId = "T_FileListTemplate.GetMaxGdFileOrderIndex";
            MDL.T_FileListTemplate obj = new T_FileListTemplate();
            obj.GDID = GDID;
            object result = MyISqlMap.QueryForObject(stmtId, obj);
            if (result == null)
                result = "0";
            return int.Parse(result.ToString());
        }
        public System.Data.DataSet GetNoInputFile(string ProjectNO)
        {
            String stmtId = "T_FileListTemplate.GetNoInputFile";
            System.Data.DataSet result = DAL.MyBatis.QueryForDataSet(stmtId, ProjectNO);
            return result;
        }

        public void UpdateOrder(T_FileListTemplate obj)
        {
            String stmtId = "T_FileListTemplate.UpdateOrderIndex";
            MyISqlMap.QueryForObject(stmtId, obj);
        }
        public int GetArchiveOrderIndex(string archiveID, string ProjectNO)
        {
            MDL.T_FileListTemplate obj = new T_FileListTemplate();
            String stmtId = "T_FileListTemplate.GetMaxArchiveOrderIndex";
            object result = MyISqlMap.QueryForObject(stmtId, obj);
            if (result == null)
                result = "0";
            return int.Parse(result.ToString());
        }
        public IList<T_FileListTemplate> FindByArchiveID2(String archiveID, string projectNO)
        {
            T_Projects_BLL bll = new T_Projects_BLL();
            //T_Projects projects = bll.Find(projectNO);

            String stmtId = "T_FileListTemplate.FindByArchiveID2";
            MDL.T_FileListTemplate obj = new T_FileListTemplate();

            //obj.ProjectCategory = projects.ProjectCategory;

            IList<T_FileListTemplate> result = MyISqlMap.QueryForList<T_FileListTemplate>(stmtId, obj);
            return result;
        }
        public System.Data.DataTable GetAllFLDS(string ProjectNO, int FL)
        {
            String stmtId = "T_FileListTemplate.GetAllFLDS";
            MDL.T_FileListTemplate obj = new T_FileListTemplate();

            System.Data.DataTable result = DAL.MyBatis.QueryForDataTable(stmtId, obj);
            return result;
        }

        public System.Data.DataTable GetFileByGDID(string ProjectNO, string GDID)
        {
            String stmtId = "T_FileListTemplate.GetFileByGDID";
            MDL.T_FileListTemplate obj = new T_FileListTemplate();
            obj.GDID = GDID;
            System.Data.DataTable result = DAL.MyBatis.QueryForDataTable(stmtId, obj);
            return result;
        }
        public string GetMaxDate(string ProjectNO, string ArchiveID)
        {
            String stmtId = "T_FileListTemplate.GetMaxDate";
            MDL.T_FileListTemplate obj = new T_FileListTemplate();

            object result = MyISqlMap.QueryForObject(stmtId, obj);
            if (result == null)
                result = "";
            return result.ToString();
        }
        public string GetMixDate(string ProjectNO, string ArchiveID)
        {
            String stmtId = "T_FileListTemplate.GetMixDate";
            MDL.T_FileListTemplate obj = new T_FileListTemplate();

            object result = MyISqlMap.QueryForObject(stmtId, obj);
            if (result == null)
                result = "";
            return result.ToString();
        }
        public int GetWzCount(string archiveID, string ProjectNO)
        {
            MDL.T_FileListTemplate obj = new T_FileListTemplate();

            String stmtId = "T_FileListTemplate.GetWzCount";
            object result = MyISqlMap.QueryForObject(stmtId, obj);
            if (result == null)
                result = "0";
            return int.Parse(result.ToString());
        }
        public int CopyFileToFileTemplate(string FileID, int OrderIndex)
        {
            String stmtId = "T_FileListTemplate.CopyFileToFileTemplate";
            MDL.T_FileListTemplate obj = new T_FileListTemplate();
            obj.FileID = FileID;
            obj.OrderIndex = OrderIndex;
            object result = MyISqlMap.QueryForObject(stmtId, obj);
            if (result == null)
                result = "0";
            return int.Parse(result.ToString());
;
        }
        public int GetMaxTemplateOrderIndex()
        {
            MDL.T_FileListTemplate obj = new T_FileListTemplate();
            String stmtId = "T_FileListTemplate.GetMaxTemplateOrderIndex";
            object result = MyISqlMap.QueryForObject(stmtId, obj);
            if (result == null)
                result = "0";
            return int.Parse(result.ToString());
        }
    }
}
