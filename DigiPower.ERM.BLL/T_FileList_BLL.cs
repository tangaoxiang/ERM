using System;
using System.Collections.Generic;
using System.Text;
using ERM.MDL;
namespace ERM.BLL
{
    public class T_FileList_BLL : IBLL
    {
        public int GetCount()
        {
            String stmtId = "T_FileList.GetCount";
            int result = MyISqlMap.QueryForObject<int>(stmtId, null);
            return result;
        }
        public T_FileList Find(String fileID, String projectNO)
        {
            MDL.T_FileList obj = new T_FileList();
            obj.FileID = fileID;
            obj.ProjectNO = projectNO;
            String stmtId = "T_FileList.Find";
            T_FileList result = MyISqlMap.QueryForObject<T_FileList>(stmtId, obj);
            return result;
        }
        public System.Data.DataSet GetList(T_FileList obj)
        {
            String stmtId = "T_FileList.GetList";
            System.Data.DataSet result = DAL.MyBatis.QueryForDataSet(stmtId, obj);
            return result;
        }
        public IList<T_FileList> GetChildList(T_FileList obj)
        {
            String stmtId = "T_FileList.GetChildList";
            IList<T_FileList> result = MyISqlMap.QueryForList<T_FileList>(stmtId, obj);
            return result;
        }
        public IList<T_FileList> GetFileByGDIDList(T_FileList obj)
        {
            String stmtId = "T_FileList.GetFileByGDIDList";
            IList<T_FileList> result = MyISqlMap.QueryForList<T_FileList>(stmtId, obj);
            return result;
        }
        public System.Data.DataSet GetChildDS(T_FileList obj)
        {
            String stmtId = "T_FileList.GetChildDS";
            System.Data.DataSet result = DAL.MyBatis.QueryForDataSet(stmtId, obj);
            return result;
        }
        public bool Exists(String fileID, String projectNO)
        {
            MDL.T_FileList obj = new T_FileList();
            obj.FileID = fileID;
            obj.ProjectNO = projectNO;
            String stmtId = "T_FileList.Exists";
            bool result = MyISqlMap.QueryForObject<bool>(stmtId, obj);
            return result;
        }
        public IList<T_FileList> GetAll()
        {
            String stmtId = "T_FileList.GetAll";
            IList<T_FileList> result = MyISqlMap.QueryForList<T_FileList>(stmtId, null);
            return result;
        }
        public System.Data.DataTable GetAllDS(string ProjectNO)
        {
            String stmtId = "T_FileList.GetAllDS";
            System.Data.DataTable result = DAL.MyBatis.QueryForDataTable(stmtId, ProjectNO);
            return result;
        }
        public IList<T_FileList> FindByFileID(String fileID)
        {
            String stmtId = "T_FileList.FindByFileID";
            IList<T_FileList> result = MyISqlMap.QueryForList<T_FileList>(stmtId, fileID);
            return result;
        }
        public IList<T_FileList> FindByParentID(String parentID, string projectNO)
        {
            String stmtId = "T_FileList.FindByParentID";
            MDL.T_FileList obj = new T_FileList();
            obj.ParentID = parentID;
            obj.ProjectNO = projectNO;
            IList<T_FileList> result = MyISqlMap.QueryForList<T_FileList>(stmtId, obj);
            return result;
        }
        public IList<T_FileList> FindByProjectNO(String projectNO)
        {
            String stmtId = "T_FileList.FindByProjectNO";
            IList<T_FileList> result = MyISqlMap.QueryForList<T_FileList>(stmtId, projectNO);
            return result;
        }
        public IList<T_FileList> FindByArchiveID(String archiveID, string projectNO)
        {
            String stmtId = "T_FileList.FindByArchiveID";
            MDL.T_FileList obj = new T_FileList();
            obj.ArchiveID = archiveID;
            obj.ProjectNO = projectNO;
            IList<T_FileList> result = MyISqlMap.QueryForList<T_FileList>(stmtId, obj);
            return result;
        }
        public IList<T_FileList> FindBywjtm(String wjtm)
        {
            String stmtId = "T_FileList.FindBywjtm";
            IList<T_FileList> result = MyISqlMap.QueryForList<T_FileList>(stmtId, wjtm);
            return result;
        }
        public IList<T_FileList> FindByselected(Int32? selected)
        {
            String stmtId = "T_FileList.FindByselected";
            IList<T_FileList> result = MyISqlMap.QueryForList<T_FileList>(stmtId, selected);
            return result;
        }
        public IList<T_FileList> FindByid(String id)
        {
            String stmtId = "T_FileList.FindByid";
            IList<T_FileList> result = MyISqlMap.QueryForList<T_FileList>(stmtId, id);
            return result;
        }
        public IList<T_FileList> FindBygdwj(String gdwj)
        {
            String stmtId = "T_FileList.FindBygdwj";
            IList<T_FileList> result = MyISqlMap.QueryForList<T_FileList>(stmtId, gdwj);
            return result;
        }
        public IList<T_FileList> FindByjsdw(String jsdw)
        {
            String stmtId = "T_FileList.FindByjsdw";
            IList<T_FileList> result = MyISqlMap.QueryForList<T_FileList>(stmtId, jsdw);
            return result;
        }
        public IList<T_FileList> FindBysgdw(String sgdw)
        {
            String stmtId = "T_FileList.FindBysgdw";
            IList<T_FileList> result = MyISqlMap.QueryForList<T_FileList>(stmtId, sgdw);
            return result;
        }
        public IList<T_FileList> FindBysjdw(String sjdw)
        {
            String stmtId = "T_FileList.FindBysjdw";
            IList<T_FileList> result = MyISqlMap.QueryForList<T_FileList>(stmtId, sjdw);
            return result;
        }
        public IList<T_FileList> FindByjldw(String jldw)
        {
            String stmtId = "T_FileList.FindByjldw";
            IList<T_FileList> result = MyISqlMap.QueryForList<T_FileList>(stmtId, jldw);
            return result;
        }
        public IList<T_FileList> FindBycjdag(String cjdag)
        {
            String stmtId = "T_FileList.FindBycjdag";
            IList<T_FileList> result = MyISqlMap.QueryForList<T_FileList>(stmtId, cjdag);
            return result;
        }
        public IList<T_FileList> FindBydatawindow_id(String datawindowId)
        {
            String stmtId = "T_FileList.FindBydatawindow_id";
            IList<T_FileList> result = MyISqlMap.QueryForList<T_FileList>(stmtId, datawindowId);
            return result;
        }
        public IList<T_FileList> FindBytable_name(String tableName)
        {
            String stmtId = "T_FileList.FindBytable_name";
            IList<T_FileList> result = MyISqlMap.QueryForList<T_FileList>(stmtId, tableName);
            return result;
        }
        public IList<T_FileList> FindBytable_standerd(String tableStanderd)
        {
            String stmtId = "T_FileList.FindBytable_standerd";
            IList<T_FileList> result = MyISqlMap.QueryForList<T_FileList>(stmtId, tableStanderd);
            return result;
        }
        public IList<T_FileList> FindByextension1(String extension1)
        {
            String stmtId = "T_FileList.FindByextension1";
            IList<T_FileList> result = MyISqlMap.QueryForList<T_FileList>(stmtId, extension1);
            return result;
        }
        public IList<T_FileList> FindByextension2(String extension2)
        {
            String stmtId = "T_FileList.FindByextension2";
            IList<T_FileList> result = MyISqlMap.QueryForList<T_FileList>(stmtId, extension2);
            return result;
        }
        public IList<T_FileList> FindByextension3(String extension3)
        {
            String stmtId = "T_FileList.FindByextension3";
            IList<T_FileList> result = MyISqlMap.QueryForList<T_FileList>(stmtId, extension3);
            return result;
        }
        public IList<T_FileList> FindBywjmj(String wjmj)
        {
            String stmtId = "T_FileList.FindBywjmj";
            IList<T_FileList> result = MyISqlMap.QueryForList<T_FileList>(stmtId, wjmj);
            return result;
        }
        public IList<T_FileList> FindByzrr(String zrr)
        {
            String stmtId = "T_FileList.FindByzrr";
            IList<T_FileList> result = MyISqlMap.QueryForList<T_FileList>(stmtId, zrr);
            return result;
        }
        public IList<T_FileList> FindBygclx(String gclx)
        {
            String stmtId = "T_FileList.FindBygclx";
            IList<T_FileList> result = MyISqlMap.QueryForList<T_FileList>(stmtId, gclx);
            return result;
        }
        public IList<T_FileList> FindByTreePath(String treePath)
        {
            String stmtId = "T_FileList.FindByTreePath";
            IList<T_FileList> result = MyISqlMap.QueryForList<T_FileList>(stmtId, treePath);
            return result;
        }
        public IList<T_FileList> FindByOrderIndex(Int32? orderIndex)
        {
            String stmtId = "T_FileList.FindByOrderIndex";
            IList<T_FileList> result = MyISqlMap.QueryForList<T_FileList>(stmtId, orderIndex);
            return result;
        }
        public IList<T_FileList> FindByisvisible(Int32? isvisible)
        {
            String stmtId = "T_FileList.FindByisvisible";
            IList<T_FileList> result = MyISqlMap.QueryForList<T_FileList>(stmtId, isvisible);
            return result;
        }
        public IList<T_FileList> FindBypTreePath(String pTreePath)
        {
            String stmtId = "T_FileList.FindBypTreePath";
            IList<T_FileList> result = MyISqlMap.QueryForList<T_FileList>(stmtId, pTreePath);
            return result;
        }
        public IList<T_FileList> FindBywjcj(String wjcj)
        {
            String stmtId = "T_FileList.FindBywjcj";
            IList<T_FileList> result = MyISqlMap.QueryForList<T_FileList>(stmtId, wjcj);
            return result;
        }
        public IList<T_FileList> FindBywjbsm(String wjbsm)
        {
            String stmtId = "T_FileList.FindBywjbsm";
            IList<T_FileList> result = MyISqlMap.QueryForList<T_FileList>(stmtId, wjbsm);
            return result;
        }
        public IList<T_FileList> FindBywjmc(String wjmc)
        {
            String stmtId = "T_FileList.FindBywjmc";
            IList<T_FileList> result = MyISqlMap.QueryForList<T_FileList>(stmtId, wjmc);
            return result;
        }
        public IList<T_FileList> FindBybzdw(String bzdw)
        {
            String stmtId = "T_FileList.FindBybzdw";
            IList<T_FileList> result = MyISqlMap.QueryForList<T_FileList>(stmtId, bzdw);
            return result;
        }
        public IList<T_FileList> FindBywh(String wh)
        {
            String stmtId = "T_FileList.FindBywh";
            IList<T_FileList> result = MyISqlMap.QueryForList<T_FileList>(stmtId, wh);
            return result;
        }
        public IList<T_FileList> FindBybgqx(String bgqx)
        {
            String stmtId = "T_FileList.FindBybgqx";
            IList<T_FileList> result = MyISqlMap.QueryForList<T_FileList>(stmtId, bgqx);
            return result;
        }
        public IList<T_FileList> FindBymj(String mj)
        {
            String stmtId = "T_FileList.FindBymj";
            IList<T_FileList> result = MyISqlMap.QueryForList<T_FileList>(stmtId, mj);
            return result;
        }
        public IList<T_FileList> FindByCreateDate(DateTime? createDate)
        {
            String stmtId = "T_FileList.FindByCreateDate";
            IList<T_FileList> result = MyISqlMap.QueryForList<T_FileList>(stmtId, createDate);
            return result;
        }
        public IList<T_FileList> FindByCreateDate2(DateTime? createDate2)
        {
            String stmtId = "T_FileList.FindByCreateDate2";
            IList<T_FileList> result = MyISqlMap.QueryForList<T_FileList>(stmtId, createDate2);
            return result;
        }
        public IList<T_FileList> FindByztlx(String ztlx)
        {
            String stmtId = "T_FileList.FindByztlx";
            IList<T_FileList> result = MyISqlMap.QueryForList<T_FileList>(stmtId, ztlx);
            return result;
        }
        public IList<T_FileList> FindBysl(Int32? sl)
        {
            String stmtId = "T_FileList.FindBysl";
            IList<T_FileList> result = MyISqlMap.QueryForList<T_FileList>(stmtId, sl);
            return result;
        }
        public IList<T_FileList> FindBydw(String dw)
        {
            String stmtId = "T_FileList.FindBydw";
            IList<T_FileList> result = MyISqlMap.QueryForList<T_FileList>(stmtId, dw);
            return result;
        }
        public IList<T_FileList> FindBygg(String gg)
        {
            String stmtId = "T_FileList.FindBygg";
            IList<T_FileList> result = MyISqlMap.QueryForList<T_FileList>(stmtId, gg);
            return result;
        }
        public IList<T_FileList> FindBywjgbdm(String wjgbdm)
        {
            String stmtId = "T_FileList.FindBywjgbdm";
            IList<T_FileList> result = MyISqlMap.QueryForList<T_FileList>(stmtId, wjgbdm);
            return result;
        }
        public IList<T_FileList> FindBywjlxdm(String wjlxdm)
        {
            String stmtId = "T_FileList.FindBywjlxdm";
            IList<T_FileList> result = MyISqlMap.QueryForList<T_FileList>(stmtId, wjlxdm);
            return result;
        }
        public IList<T_FileList> FindBywjgs(String wjgs)
        {
            String stmtId = "T_FileList.FindBywjgs";
            IList<T_FileList> result = MyISqlMap.QueryForList<T_FileList>(stmtId, wjgs);
            return result;
        }
        public IList<T_FileList> FindBywjdx(String wjdx)
        {
            String stmtId = "T_FileList.FindBywjdx";
            IList<T_FileList> result = MyISqlMap.QueryForList<T_FileList>(stmtId, wjdx);
            return result;
        }
        public IList<T_FileList> FindBypsdd(String psdd)
        {
            String stmtId = "T_FileList.FindBypsdd";
            IList<T_FileList> result = MyISqlMap.QueryForList<T_FileList>(stmtId, psdd);
            return result;
        }
        public IList<T_FileList> FindBypsz(String psz)
        {
            String stmtId = "T_FileList.FindBypsz";
            IList<T_FileList> result = MyISqlMap.QueryForList<T_FileList>(stmtId, psz);
            return result;
        }
        public IList<T_FileList> FindBypssj(DateTime? pssj)
        {
            String stmtId = "T_FileList.FindBypssj";
            IList<T_FileList> result = MyISqlMap.QueryForList<T_FileList>(stmtId, pssj);
            return result;
        }
        public IList<T_FileList> FindBysb(String sb)
        {
            String stmtId = "T_FileList.FindBysb";
            IList<T_FileList> result = MyISqlMap.QueryForList<T_FileList>(stmtId, sb);
            return result;
        }
        public IList<T_FileList> FindByfbl(String fbl)
        {
            String stmtId = "T_FileList.FindByfbl";
            IList<T_FileList> result = MyISqlMap.QueryForList<T_FileList>(stmtId, fbl);
            return result;
        }
        public IList<T_FileList> FindByxjpp(String xjpp)
        {
            String stmtId = "T_FileList.FindByxjpp";
            IList<T_FileList> result = MyISqlMap.QueryForList<T_FileList>(stmtId, xjpp);
            return result;
        }
        public IList<T_FileList> FindByxjxh(String xjxh)
        {
            String stmtId = "T_FileList.FindByxjxh";
            IList<T_FileList> result = MyISqlMap.QueryForList<T_FileList>(stmtId, xjxh);
            return result;
        }
        public IList<T_FileList> FindBybz(String bz)
        {
            String stmtId = "T_FileList.FindBybz";
            IList<T_FileList> result = MyISqlMap.QueryForList<T_FileList>(stmtId, bz);
            return result;
        }
        public IList<T_FileList> FindByfilepath(String filepath)
        {
            String stmtId = "T_FileList.FindByfilepath";
            IList<T_FileList> result = MyISqlMap.QueryForList<T_FileList>(stmtId, filepath);
            return result;
        }
        public IList<T_FileList> FindByfileStatus(String fileStatus)
        {
            String stmtId = "T_FileList.FindByfileStatus";
            IList<T_FileList> result = MyISqlMap.QueryForList<T_FileList>(stmtId, fileStatus);
            return result;
        }
        public IList<T_FileList> FindBywzz(String wzz)
        {
            String stmtId = "T_FileList.FindBywzz";
            IList<T_FileList> result = MyISqlMap.QueryForList<T_FileList>(stmtId, wzz);
            return result;
        }
        public IList<T_FileList> FindBytzz(String tzz)
        {
            String stmtId = "T_FileList.FindBytzz";
            IList<T_FileList> result = MyISqlMap.QueryForList<T_FileList>(stmtId, tzz);
            return result;
        }
        public IList<T_FileList> FindBydtz(String dtz)
        {
            String stmtId = "T_FileList.FindBydtz";
            IList<T_FileList> result = MyISqlMap.QueryForList<T_FileList>(stmtId, dtz);
            return result;
        }
        public IList<T_FileList> FindByzpz(String zpz)
        {
            String stmtId = "T_FileList.FindByzpz";
            IList<T_FileList> result = MyISqlMap.QueryForList<T_FileList>(stmtId, zpz);
            return result;
        }
        public IList<T_FileList> FindBydpz(String dpz)
        {
            String stmtId = "T_FileList.FindBydpz";
            IList<T_FileList> result = MyISqlMap.QueryForList<T_FileList>(stmtId, dpz);
            return result;
        }
        public IList<T_FileList> FindByisSign(Int32? isSign)
        {
            String stmtId = "T_FileList.FindByisSign";
            IList<T_FileList> result = MyISqlMap.QueryForList<T_FileList>(stmtId, isSign);
            return result;
        }
        public void Insert(T_FileList obj)
        {
            if (obj == null) throw new ArgumentNullException("obj");
            String stmtId = "T_FileList.Insert";
            MyISqlMap.Insert(stmtId, obj);
        }
        public void Add(T_FileList obj)
        {
            Insert(obj);
        }
        public int Update(T_FileList obj)
        {
            if (obj == null) throw new ArgumentNullException("obj");
            String stmtId = "T_FileList.Update";
            return MyISqlMap.Update(stmtId, obj);
        }
        public int UpdateFileListArchive(T_FileList obj, ref string sqltmp)
        {
            if (obj == null) throw new ArgumentNullException("obj");
            String stmtId = "T_FileList.UpdateFileListArchive";
            sqltmp = ERM.DAL.MyBatis.QueryForSql(stmtId, obj);
            return MyISqlMap.Update(stmtId, obj);
        }
        public void Delete(T_FileList obj)
        {
            if (obj == null) throw new ArgumentNullException("obj");
            String stmtId = "T_FileList.Delete";
            MyISqlMap.Delete(stmtId, obj);
        }
        public void Delete(String fileID, String projectNO)
        {
            if (fileID == null || projectNO == null) throw new ArgumentNullException("obj");
            String stmtId = "T_FileList.Delete";
            T_FileList obj = new T_FileList();
            obj.FileID = fileID;
            obj.ProjectNO = projectNO;
            MyISqlMap.Delete(stmtId, obj);
        }
        //public void DeleteFileListTemplate(String fileID)
        //{
        //    String stmtId = "T_FileList.DeleteFileListTemplate";
        //    T_FileList obj = new T_FileList();
        //    obj.FileID = fileID;
        //    MyISqlMap.Delete(stmtId, obj);
        //}
        public void DeleteGdList(String fileID)
        {
            String stmtId = "T_FileList.DeleteGdList";
            T_FileList obj = new T_FileList();
            obj.FileID = fileID;
            MyISqlMap.Delete(stmtId, obj);
        }
        //public void DeleteGdTemplate(String fileID)
        //{
        //    String stmtId = "T_FileList.DeleteGdTemplate";
        //    T_FileList obj = new T_FileList();
        //    obj.FileID = fileID;
        //    MyISqlMap.Delete(stmtId, obj);
        //}
        public IList<T_FileList> FindByKeyString(T_FileList obj)
        {
            String stmtId = "T_FileList.FindByKeyString";
            IList<T_FileList> result = MyISqlMap.QueryForList<T_FileList>(stmtId, obj);
            return result;
        }
        public int GetMaxOrderIndex(string ParentFileID, string ProjectNO)
        {
            String stmtId = "T_FileList.GetMaxOrderIndex";
            MDL.T_FileList obj = new T_FileList();
            obj.ParentID = ParentFileID;
            obj.ProjectNO = ProjectNO;
            object result = MyISqlMap.QueryForObject(stmtId, obj);
            if (result == null)
                result = "0";
            return int.Parse(result.ToString());
        }
        public int GetMaxGdFileOrderIndex(string GDID, string ProjectNO)
        {
            String stmtId = "T_FileList.GetMaxGdFileOrderIndex";
            MDL.T_FileList obj = new T_FileList();
            obj.GDID = GDID;
            obj.ProjectNO = ProjectNO;
            object result = MyISqlMap.QueryForObject(stmtId, obj);
            if (result == null)
                result = "0";
            return int.Parse(result.ToString());
        }
        public System.Data.DataSet GetNoInputFile(string ProjectNO)
        {
            String stmtId = "T_FileList.GetNoInputFile";
            System.Data.DataSet result = DAL.MyBatis.QueryForDataSet(stmtId, ProjectNO);
            return result;
        }

        public void UpdateOrder(T_FileList obj)
        {
            String stmtId = "T_FileList.UpdateOrderIndex";
            MyISqlMap.QueryForObject(stmtId, obj);
        }
        public int GetArchiveOrderIndex(string archiveID, string ProjectNO)
        {
            MDL.T_FileList obj = new T_FileList();
            obj.ArchiveID = archiveID;
            obj.ProjectNO = ProjectNO;
            String stmtId = "T_FileList.GetMaxArchiveOrderIndex";
            object result = MyISqlMap.QueryForObject(stmtId, obj);
            if (result == null)
                result = "0";
            return int.Parse(result.ToString());
        }
        public IList<T_FileList> FindByArchiveID2(String archiveID, string projectNO)
        {
            T_Projects_BLL bll = new T_Projects_BLL();
            //T_Projects projects = bll.Find(projectNO);

            String stmtId = "T_FileList.FindByArchiveID2";
            MDL.T_FileList obj = new T_FileList();
            obj.ArchiveID = archiveID;
            obj.ProjectNO = projectNO;
            //obj.ProjectCategory = projects.ProjectCategory;

            IList<T_FileList> result = MyISqlMap.QueryForList<T_FileList>(stmtId, obj);
            return result;
        }
        public System.Data.DataTable GetAllFLDS(string ProjectNO, int FL)
        {
            String stmtId = "T_FileList.GetAllFLDS";
            MDL.T_FileList obj = new T_FileList();
            obj.FL = FL;
            obj.ProjectNO = ProjectNO;
            System.Data.DataTable result = DAL.MyBatis.QueryForDataTable(stmtId, obj);
            return result;
        }

        public System.Data.DataTable GetFileByGDID(string ProjectNO, string GDID)
        {
            String stmtId = "T_FileList.GetFileByGDID";
            MDL.T_FileList obj = new T_FileList();
            obj.GDID = GDID;
            obj.ProjectNO = ProjectNO;
            System.Data.DataTable result = DAL.MyBatis.QueryForDataTable(stmtId, obj);
            return result;
        }
        public string GetMaxDate(string ProjectNO, string ArchiveID)
        {
            String stmtId = "T_FileList.GetMaxDate";
            MDL.T_FileList obj = new T_FileList();
            obj.ArchiveID = ArchiveID;
            obj.ProjectNO = ProjectNO;
            object result = MyISqlMap.QueryForObject(stmtId, obj);
            if (result == null)
                result = "";
            return result.ToString();
        }
        public string GetMixDate(string ProjectNO, string ArchiveID)
        {
            String stmtId = "T_FileList.GetMixDate";
            MDL.T_FileList obj = new T_FileList();
            obj.ArchiveID = ArchiveID;
            obj.ProjectNO = ProjectNO;
            object result = MyISqlMap.QueryForObject(stmtId, obj);
            if (result == null)
                result = "";
            return result.ToString();
        }
        public int GetWzCount(string archiveID, string ProjectNO)
        {
            MDL.T_FileList obj = new T_FileList();
            obj.ArchiveID = archiveID;
            obj.ProjectNO = ProjectNO;
            String stmtId = "T_FileList.GetWzCount";
            object result = MyISqlMap.QueryForObject(stmtId, obj);
            if (result == null)
                result = "0";
            return int.Parse(result.ToString());
        }
        public int CopyFileToFileTemplate(string FileID, int OrderIndex)
        {
            String stmtId = "T_FileList.CopyFileToFileTemplate";
            MDL.T_FileList obj = new T_FileList();
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
            MDL.T_FileList obj = new T_FileList();
            String stmtId = "T_FileList.GetMaxTemplateOrderIndex";
            object result = MyISqlMap.QueryForObject(stmtId, obj);
            if (result == null)
                result = "0";
            return int.Parse(result.ToString());
        }
    }
}
