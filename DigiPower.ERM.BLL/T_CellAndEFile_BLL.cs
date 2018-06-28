using System;
using System.Collections.Generic;
using System.Text;
using ERM.MDL;
namespace ERM.BLL
{
    public class T_CellAndEFile_BLL : IBLL
    {
        //public int GetCount()
        //{
        //    String stmtId = "T_CellAndEFile.GetCount";
        //    int result = MyISqlMap.QueryForObject<int>(stmtId, null);
        //    return result;
        //}
        //public T_CellAndEFile Find(String cellID,string ProjectNO)
        //{
        //    String stmtId = "T_CellAndEFile.Find";
        //    MDL.T_CellAndEFile obj = new T_CellAndEFile();
        //    obj.CellID = cellID;
        //    obj.ProjectNO = ProjectNO;
        //    T_CellAndEFile result = MyISqlMap.QueryForObject<T_CellAndEFile>(stmtId, obj);
        //    return result;
        //}
        //public System.Data.DataSet GetList(MDL.T_CellAndEFile obj)
        //{
        //    String stmtId = "T_CellAndEFile.GetList";
        //    System.Data.DataSet result = DAL.MyBatis.QueryForDataSet(stmtId, obj);
        //    return result;
        //}
        //public System.Data.DataSet GetList(String strWhere)
        //{
        //    String stmtId = "T_CellAndEFile.GetList";
        //    if (strWhere == null || strWhere == "" || strWhere == "1=1")
        //    {
        //        strWhere = null;
        //        stmtId = "T_CellAndEFile.GetAll";
        //    }
        //    System.Data.DataSet result = DAL.MyBatis.QueryForDataSet(stmtId, strWhere);
        //    return result;
        //}
        //public bool Exists(String cellID,String ProjectNO)
        //{
        //    String stmtId = "T_CellAndEFile.Exists";
        //    MDL.T_CellAndEFile obj = new T_CellAndEFile();
        //    obj.ProjectNO = ProjectNO;
        //    obj.CellID = cellID;

        //    bool result = MyISqlMap.QueryForObject<bool>(stmtId, obj);
        //    return result;
        //}
        //public IList<T_CellAndEFile> GetAll()
        //{
        //    String stmtId = "T_CellAndEFile.GetAll";
        //    IList<T_CellAndEFile> result = MyISqlMap.QueryForList<T_CellAndEFile>(stmtId, null);
        //    return result;
        //}
        public IList<T_CellAndEFile> FindByFileID(String fileID, string ProjectNO, int DoStatus)
        {
            String stmtId = "T_CellAndEFile.FindByFileID";
            MDL.T_CellAndEFile obj = new T_CellAndEFile();
            obj.FileID = fileID;
            obj.ProjectNO = ProjectNO;
            obj.DoStatus = DoStatus;
            IList<T_CellAndEFile> result = MyISqlMap.QueryForList<T_CellAndEFile>(stmtId, obj);
            return result;
        }
        public IList<T_CellAndEFile> FindByFileIDAndNOCell(String fileID, string ProjectNO)
        {
            String stmtId = "T_CellAndEFile.FindByFileIDAndNOCell";
            MDL.T_CellAndEFile obj = new T_CellAndEFile();
            obj.FileID = fileID;
            obj.ProjectNO = ProjectNO;
            IList<T_CellAndEFile> result = MyISqlMap.QueryForList<T_CellAndEFile>(stmtId, obj);
            return result;
        }
        //public IList<T_CellAndEFile> FindByid(String id)
        //{
        //    String stmtId = "T_CellAndEFile.FindByid";
        //    IList<T_CellAndEFile> result = MyISqlMap.QueryForList<T_CellAndEFile>(stmtId, id);
        //    return result;
        //}
        //public IList<T_CellAndEFile> FindByProjectNO(String projectNO)
        //{
        //    String stmtId = "T_CellAndEFile.FindByProjectNO";
        //    IList<T_CellAndEFile> result = MyISqlMap.QueryForList<T_CellAndEFile>(stmtId, projectNO);
        //    return result;
        //}
        //public IList<T_CellAndEFile> FindByTreePath(String treePath)
        //{
        //    String stmtId = "T_CellAndEFile.FindByTreePath";
        //    IList<T_CellAndEFile> result = MyISqlMap.QueryForList<T_CellAndEFile>(stmtId, treePath);
        //    return result;
        //}
        //public IList<T_CellAndEFile> FindByparentid(String parentid)
        //{
        //    String stmtId = "T_CellAndEFile.FindByparentid";
        //    IList<T_CellAndEFile> result = MyISqlMap.QueryForList<T_CellAndEFile>(stmtId, parentid);
        //    return result;
        //}
        //public IList<T_CellAndEFile> FindByPTreePath(String pTreePath)
        //{
        //    String stmtId = "T_CellAndEFile.FindByPTreePath";
        //    IList<T_CellAndEFile> result = MyISqlMap.QueryForList<T_CellAndEFile>(stmtId, pTreePath);
        //    return result;
        //}
        //public IList<T_CellAndEFile> FindBytitle(String title)
        //{
        //    String stmtId = "T_CellAndEFile.FindBytitle";
        //    IList<T_CellAndEFile> result = MyISqlMap.QueryForList<T_CellAndEFile>(stmtId, title);
        //    return result;
        //}
        //public IList<T_CellAndEFile> FindByfilepath(String filepath)
        //{
        //    String stmtId = "T_CellAndEFile.FindByfilepath";
        //    IList<T_CellAndEFile> result = MyISqlMap.QueryForList<T_CellAndEFile>(stmtId, filepath);
        //    return result;
        //}
        //public IList<T_CellAndEFile> FindByexamplepath(String examplepath)
        //{
        //    String stmtId = "T_CellAndEFile.FindByexamplepath";
        //    IList<T_CellAndEFile> result = MyISqlMap.QueryForList<T_CellAndEFile>(stmtId, examplepath);
        //    return result;
        //}
        //public IList<T_CellAndEFile> FindBycodeno(String codeno)
        //{
        //    String stmtId = "T_CellAndEFile.FindBycodeno";
        //    IList<T_CellAndEFile> result = MyISqlMap.QueryForList<T_CellAndEFile>(stmtId, codeno);
        //    return result;
        //}
        //public IList<T_CellAndEFile> FindBycustomdefine(Int32? customdefine)
        //{
        //    String stmtId = "T_CellAndEFile.FindBycustomdefine";
        //    IList<T_CellAndEFile> result = MyISqlMap.QueryForList<T_CellAndEFile>(stmtId, customdefine);
        //    return result;
        //}
        //public IList<T_CellAndEFile> FindByzrr(String zrr)
        //{
        //    String stmtId = "T_CellAndEFile.FindByzrr";
        //    IList<T_CellAndEFile> result = MyISqlMap.QueryForList<T_CellAndEFile>(stmtId, zrr);
        //    return result;
        //}
        //public IList<T_CellAndEFile> FindBycodetype(Int32? codetype)
        //{
        //    String stmtId = "T_CellAndEFile.FindBycodetype";
        //    IList<T_CellAndEFile> result = MyISqlMap.QueryForList<T_CellAndEFile>(stmtId, codetype);
        //    return result;
        //}
        //public IList<T_CellAndEFile> FindByfbmc(String fbmc)
        //{
        //    String stmtId = "T_CellAndEFile.FindByfbmc";
        //    IList<T_CellAndEFile> result = MyISqlMap.QueryForList<T_CellAndEFile>(stmtId, fbmc);
        //    return result;
        //}
        //public IList<T_CellAndEFile> FindByfxmc(String fxmc)
        //{
        //    String stmtId = "T_CellAndEFile.FindByfxmc";
        //    IList<T_CellAndEFile> result = MyISqlMap.QueryForList<T_CellAndEFile>(stmtId, fxmc);
        //    return result;
        //}
        //public IList<T_CellAndEFile> FindByzfbmc(String zfbmc)
        //{
        //    String stmtId = "T_CellAndEFile.FindByzfbmc";
        //    IList<T_CellAndEFile> result = MyISqlMap.QueryForList<T_CellAndEFile>(stmtId, zfbmc);
        //    return result;
        //}
        //public IList<T_CellAndEFile> FindByys(Int32? ys)
        //{
        //    String stmtId = "T_CellAndEFile.FindByys";
        //    IList<T_CellAndEFile> result = MyISqlMap.QueryForList<T_CellAndEFile>(stmtId, ys);
        //    return result;
        //}
        //public IList<T_CellAndEFile> FindByisvisible(Int32? isvisible)
        //{
        //    String stmtId = "T_CellAndEFile.FindByisvisible";
        //    IList<T_CellAndEFile> result = MyISqlMap.QueryForList<T_CellAndEFile>(stmtId, isvisible);
        //    return result;
        //}
        //public IList<T_CellAndEFile> FindByorderindex(Int32? orderindex)
        //{
        //    String stmtId = "T_CellAndEFile.FindByorderindex";
        //    IList<T_CellAndEFile> result = MyISqlMap.QueryForList<T_CellAndEFile>(stmtId, orderindex);
        //    return result;
        //}
        //public IList<T_CellAndEFile> FindByDoStatus(Int32? doStatus)
        //{
        //    String stmtId = "T_CellAndEFile.FindByDoStatus";
        //    IList<T_CellAndEFile> result = MyISqlMap.QueryForList<T_CellAndEFile>(stmtId, doStatus);
        //    return result;
        //}
        //public IList<T_CellAndEFile> FindByattachid(Int32? attachid)
        //{
        //    String stmtId = "T_CellAndEFile.FindByattachid";
        //    IList<T_CellAndEFile> result = MyISqlMap.QueryForList<T_CellAndEFile>(stmtId, attachid);
        //    return result;
        //}
        //public IList<T_CellAndEFile> FindByfileTreePath(String fileTreePath)
        //{
        //    String stmtId = "T_CellAndEFile.FindByfileTreePath";
        //    IList<T_CellAndEFile> result = MyISqlMap.QueryForList<T_CellAndEFile>(stmtId, fileTreePath);
        //    return result;
        //}
        //public IList<T_CellAndEFile> FindByzrzbsm(String zrzbsm)
        //{
        //    String stmtId = "T_CellAndEFile.FindByzrzbsm";
        //    IList<T_CellAndEFile> result = MyISqlMap.QueryForList<T_CellAndEFile>(stmtId, zrzbsm);
        //    return result;
        //}
        //public IList<T_CellAndEFile> FindByzrzlb(String zrzlb)
        //{
        //    String stmtId = "T_CellAndEFile.FindByzrzlb";
        //    IList<T_CellAndEFile> result = MyISqlMap.QueryForList<T_CellAndEFile>(stmtId, zrzlb);
        //    return result;
        //}
        //public IList<T_CellAndEFile> FindByzrzmc(String zrzmc)
        //{
        //    String stmtId = "T_CellAndEFile.FindByzrzmc";
        //    IList<T_CellAndEFile> result = MyISqlMap.QueryForList<T_CellAndEFile>(stmtId, zrzmc);
        //    return result;
        //}
        //public IList<T_CellAndEFile> FindByzezzzfw(String zezzzfw)
        //{
        //    String stmtId = "T_CellAndEFile.FindByzezzzfw";
        //    IList<T_CellAndEFile> result = MyISqlMap.QueryForList<T_CellAndEFile>(stmtId, zezzzfw);
        //    return result;
        //}
        //public IList<T_CellAndEFile> FindByext(String ext)
        //{
        //    String stmtId = "T_CellAndEFile.FindByext";
        //    IList<T_CellAndEFile> result = MyISqlMap.QueryForList<T_CellAndEFile>(stmtId, ext);
        //    return result;
        //}
        //public IList<T_CellAndEFile> FindBywjly(String wjly)
        //{
        //    String stmtId = "T_CellAndEFile.FindBywjly";
        //    IList<T_CellAndEFile> result = MyISqlMap.QueryForList<T_CellAndEFile>(stmtId, wjly);
        //    return result;
        //}
        //public IList<T_CellAndEFile> FindByDocYs(Int32? docYs)
        //{
        //    String stmtId = "T_CellAndEFile.FindByDocYs";
        //    IList<T_CellAndEFile> result = MyISqlMap.QueryForList<T_CellAndEFile>(stmtId, docYs);
        //    return result;
        //}
        //public IList<T_CellAndEFile> FindByyswjpath(String yswjpath)
        //{
        //    String stmtId = "T_CellAndEFile.FindByyswjpath";
        //    IList<T_CellAndEFile> result = MyISqlMap.QueryForList<T_CellAndEFile>(stmtId, yswjpath);
        //    return result;
        //}
        //public IList<T_CellAndEFile> FindBydocType(String docType)
        //{
        //    String stmtId = "T_CellAndEFile.FindBydocType";
        //    IList<T_CellAndEFile> result = MyISqlMap.QueryForList<T_CellAndEFile>(stmtId, docType);
        //    return result;
        //}
        //public IList<T_CellAndEFile> FindBydocFormat(String docFormat)
        //{
        //    String stmtId = "T_CellAndEFile.FindBydocFormat";
        //    IList<T_CellAndEFile> result = MyISqlMap.QueryForList<T_CellAndEFile>(stmtId, docFormat);
        //    return result;
        //}
        //public IList<T_CellAndEFile> FindByDraft(String draft)
        //{
        //    String stmtId = "T_CellAndEFile.FindByDraft";
        //    IList<T_CellAndEFile> result = MyISqlMap.QueryForList<T_CellAndEFile>(stmtId, draft);
        //    return result;
        //}
        //public IList<T_CellAndEFile> FindByOriOpenPro(String oriOpenPro)
        //{
        //    String stmtId = "T_CellAndEFile.FindByOriOpenPro";
        //    IList<T_CellAndEFile> result = MyISqlMap.QueryForList<T_CellAndEFile>(stmtId, oriOpenPro);
        //    return result;
        //}
        //public IList<T_CellAndEFile> FindByEFileType(Boolean? eFileType)
        //{
        //    String stmtId = "T_CellAndEFile.FindByEFileType";
        //    IList<T_CellAndEFile> result = MyISqlMap.QueryForList<T_CellAndEFile>(stmtId, eFileType);
        //    return result;
        //}
        //public IList<T_CellAndEFile> FindByFileType(String fileType)
        //{
        //    String stmtId = "T_CellAndEFile.FindByFileType";
        //    IList<T_CellAndEFile> result = MyISqlMap.QueryForList<T_CellAndEFile>(stmtId, fileType);
        //    return result;
        //}
        //public void Insert(T_CellAndEFile obj)
        //{
        //    if (obj == null) throw new ArgumentNullException("obj");
        //    String stmtId = "T_CellAndEFile.Insert";
        //    MyISqlMap.Insert(stmtId, obj);
        //}
        //public void Add(T_CellAndEFile obj)
        //{
        //    Insert(obj);
        //}
        //public void Update(T_CellAndEFile obj)
        //{
        //    if (obj == null) throw new ArgumentNullException("obj");
        //    String stmtId = "T_CellAndEFile.Update";
        //    MyISqlMap.Update(stmtId, obj);
        //}
        //public void Delete(T_CellAndEFile obj)
        //{
        //    if (obj == null) throw new ArgumentNullException("obj");
        //    String stmtId = "T_CellAndEFile.Delete";
        //    MyISqlMap.Delete(stmtId, obj);
        //}
        //public void Delete(String cellID)
        //{
        //    if (cellID == null) throw new ArgumentNullException("obj");
        //    String stmtId = "T_CellAndEFile.Delete";
        //    T_CellAndEFile obj = new T_CellAndEFile();
        //    obj.CellID = cellID;
        //    MyISqlMap.Delete(stmtId, obj);
        //}

        public int GetCount()
        {
            String stmtId = "T_CellAndEFile.GetCount";
            int result = MyISqlMap.QueryForObject<int>(stmtId, null);
            return result;
        }
        public T_CellAndEFile Find(String cellID, String projectNO)
        {
            String stmtId = "T_CellAndEFile.Find";
            MDL.T_CellAndEFile obj = new T_CellAndEFile();
            obj.CellID = cellID;
            obj.ProjectNO = projectNO;

            T_CellAndEFile result = MyISqlMap.QueryForObject<T_CellAndEFile>(stmtId, obj);
            return result;
        }


        public System.Data.DataSet GetList(T_CellAndEFile obj)
        {
            String stmtId = "T_CellAndEFile.GetList";
            System.Data.DataSet result = DAL.MyBatis.QueryForDataSet(stmtId, obj);
            return result;
        }


        public System.Data.DataSet GetList(String strWhere)
        {
            String stmtId = "T_CellAndEFile.GetList";
            if (strWhere == null || strWhere == "" || strWhere == "1=1")
            {
                strWhere = null;
                stmtId = "T_CellAndEFile.GetAll";
            }
            System.Data.DataSet result = DAL.MyBatis.QueryForDataSet(stmtId, strWhere);
            return result;
        }


        public bool Exists(String cellID, String projectNO)
        {
            String stmtId = "T_CellAndEFile.Exists";
            MDL.T_CellAndEFile obj = new T_CellAndEFile();
            obj.CellID = cellID;
            obj.ProjectNO = projectNO;

            bool result = MyISqlMap.QueryForObject<bool>(stmtId, obj);
            return result;
        }


        public IList<T_CellAndEFile> GetAll()
        {
            String stmtId = "T_CellAndEFile.GetAll";
            IList<T_CellAndEFile> result = MyISqlMap.QueryForList<T_CellAndEFile>(stmtId, null);
            return result;
        }


        public IList<T_CellAndEFile> FindByattachid(Int32? attachid)
        {
            String stmtId = "T_CellAndEFile.FindByattachid";
            IList<T_CellAndEFile> result = MyISqlMap.QueryForList<T_CellAndEFile>(stmtId, attachid);
            return result;
        }

        public IList<T_CellAndEFile> FindByCellID(String cellID)
        {
            String stmtId = "T_CellAndEFile.FindByCellID";
            IList<T_CellAndEFile> result = MyISqlMap.QueryForList<T_CellAndEFile>(stmtId, cellID);
            return result;
        }

        public IList<T_CellAndEFile> FindBycodeno(String codeno)
        {
            String stmtId = "T_CellAndEFile.FindBycodeno";
            IList<T_CellAndEFile> result = MyISqlMap.QueryForList<T_CellAndEFile>(stmtId, codeno);
            return result;
        }

        public IList<T_CellAndEFile> FindBycodetype(Int32? codetype)
        {
            String stmtId = "T_CellAndEFile.FindBycodetype";
            IList<T_CellAndEFile> result = MyISqlMap.QueryForList<T_CellAndEFile>(stmtId, codetype);
            return result;
        }

        public IList<T_CellAndEFile> FindBycustomdefine(Int32? customdefine)
        {
            String stmtId = "T_CellAndEFile.FindBycustomdefine";
            IList<T_CellAndEFile> result = MyISqlMap.QueryForList<T_CellAndEFile>(stmtId, customdefine);
            return result;
        }

        public IList<T_CellAndEFile> FindBydocFormat(String docFormat)
        {
            String stmtId = "T_CellAndEFile.FindBydocFormat";
            IList<T_CellAndEFile> result = MyISqlMap.QueryForList<T_CellAndEFile>(stmtId, docFormat);
            return result;
        }

        public IList<T_CellAndEFile> FindBydocType(String docType)
        {
            String stmtId = "T_CellAndEFile.FindBydocType";
            IList<T_CellAndEFile> result = MyISqlMap.QueryForList<T_CellAndEFile>(stmtId, docType);
            return result;
        }

        public IList<T_CellAndEFile> FindByDocYs(Int32? docYs)
        {
            String stmtId = "T_CellAndEFile.FindByDocYs";
            IList<T_CellAndEFile> result = MyISqlMap.QueryForList<T_CellAndEFile>(stmtId, docYs);
            return result;
        }

        public IList<T_CellAndEFile> FindByDoStatus(Int32? doStatus)
        {
            String stmtId = "T_CellAndEFile.FindByDoStatus";
            IList<T_CellAndEFile> result = MyISqlMap.QueryForList<T_CellAndEFile>(stmtId, doStatus);
            return result;
        }

        public IList<T_CellAndEFile> FindByDraft(String draft)
        {
            String stmtId = "T_CellAndEFile.FindByDraft";
            IList<T_CellAndEFile> result = MyISqlMap.QueryForList<T_CellAndEFile>(stmtId, draft);
            return result;
        }

        public IList<T_CellAndEFile> FindByEFileType(Boolean? eFileType)
        {
            String stmtId = "T_CellAndEFile.FindByEFileType";
            IList<T_CellAndEFile> result = MyISqlMap.QueryForList<T_CellAndEFile>(stmtId, eFileType);
            return result;
        }

        public IList<T_CellAndEFile> FindByexamplepath(String examplepath)
        {
            String stmtId = "T_CellAndEFile.FindByexamplepath";
            IList<T_CellAndEFile> result = MyISqlMap.QueryForList<T_CellAndEFile>(stmtId, examplepath);
            return result;
        }

        public IList<T_CellAndEFile> FindByext(String ext)
        {
            String stmtId = "T_CellAndEFile.FindByext";
            IList<T_CellAndEFile> result = MyISqlMap.QueryForList<T_CellAndEFile>(stmtId, ext);
            return result;
        }

        public IList<T_CellAndEFile> FindByfbmc(String fbmc)
        {
            String stmtId = "T_CellAndEFile.FindByfbmc";
            IList<T_CellAndEFile> result = MyISqlMap.QueryForList<T_CellAndEFile>(stmtId, fbmc);
            return result;
        }

        //public IList<T_CellAndEFile> FindByFileID(String fileID)
        //{
        //    String stmtId = "T_CellAndEFile.FindByFileID";
        //    IList<T_CellAndEFile> result = MyISqlMap.QueryForList<T_CellAndEFile>(stmtId, fileID);
        //    return result;
        //}

        public IList<T_CellAndEFile> FindByfilepath(String filepath)
        {
            String stmtId = "T_CellAndEFile.FindByfilepath";
            IList<T_CellAndEFile> result = MyISqlMap.QueryForList<T_CellAndEFile>(stmtId, filepath);
            return result;
        }

        public IList<T_CellAndEFile> FindByfileTreePath(String fileTreePath)
        {
            String stmtId = "T_CellAndEFile.FindByfileTreePath";
            IList<T_CellAndEFile> result = MyISqlMap.QueryForList<T_CellAndEFile>(stmtId, fileTreePath);
            return result;
        }

        public IList<T_CellAndEFile> FindByFileType(String fileType)
        {
            String stmtId = "T_CellAndEFile.FindByFileType";
            IList<T_CellAndEFile> result = MyISqlMap.QueryForList<T_CellAndEFile>(stmtId, fileType);
            return result;
        }

        public IList<T_CellAndEFile> FindByfxmc(String fxmc)
        {
            String stmtId = "T_CellAndEFile.FindByfxmc";
            IList<T_CellAndEFile> result = MyISqlMap.QueryForList<T_CellAndEFile>(stmtId, fxmc);
            return result;
        }

        public IList<T_CellAndEFile> FindByid(String id)
        {
            String stmtId = "T_CellAndEFile.FindByid";
            IList<T_CellAndEFile> result = MyISqlMap.QueryForList<T_CellAndEFile>(stmtId, id);
            return result;
        }

        public IList<T_CellAndEFile> FindByisvisible(Int32? isvisible)
        {
            String stmtId = "T_CellAndEFile.FindByisvisible";
            IList<T_CellAndEFile> result = MyISqlMap.QueryForList<T_CellAndEFile>(stmtId, isvisible);
            return result;
        }

        public IList<T_CellAndEFile> FindByorderindex(Int32? orderindex)
        {
            String stmtId = "T_CellAndEFile.FindByorderindex";
            IList<T_CellAndEFile> result = MyISqlMap.QueryForList<T_CellAndEFile>(stmtId, orderindex);
            return result;
        }

        public IList<T_CellAndEFile> FindByOriOpenPro(String oriOpenPro)
        {
            String stmtId = "T_CellAndEFile.FindByOriOpenPro";
            IList<T_CellAndEFile> result = MyISqlMap.QueryForList<T_CellAndEFile>(stmtId, oriOpenPro);
            return result;
        }

        public IList<T_CellAndEFile> FindByparentid(String parentid)
        {
            String stmtId = "T_CellAndEFile.FindByparentid";
            IList<T_CellAndEFile> result = MyISqlMap.QueryForList<T_CellAndEFile>(stmtId, parentid);
            return result;
        }

        public IList<T_CellAndEFile> FindByProjectNO(String projectNO)
        {
            String stmtId = "T_CellAndEFile.FindByProjectNO";
            IList<T_CellAndEFile> result = MyISqlMap.QueryForList<T_CellAndEFile>(stmtId, projectNO);
            return result;
        }

        public IList<T_CellAndEFile> FindByPTreePath(String pTreePath)
        {
            String stmtId = "T_CellAndEFile.FindByPTreePath";
            IList<T_CellAndEFile> result = MyISqlMap.QueryForList<T_CellAndEFile>(stmtId, pTreePath);
            return result;
        }

        public IList<T_CellAndEFile> FindBytitle(String title)
        {
            String stmtId = "T_CellAndEFile.FindBytitle";
            IList<T_CellAndEFile> result = MyISqlMap.QueryForList<T_CellAndEFile>(stmtId, title);
            return result;
        }

        public IList<T_CellAndEFile> FindByTreePath(String treePath)
        {
            String stmtId = "T_CellAndEFile.FindByTreePath";
            IList<T_CellAndEFile> result = MyISqlMap.QueryForList<T_CellAndEFile>(stmtId, treePath);
            return result;
        }

        public IList<T_CellAndEFile> FindBywjly(String wjly)
        {
            String stmtId = "T_CellAndEFile.FindBywjly";
            IList<T_CellAndEFile> result = MyISqlMap.QueryForList<T_CellAndEFile>(stmtId, wjly);
            return result;
        }

        public IList<T_CellAndEFile> FindByys(Int32? ys)
        {
            String stmtId = "T_CellAndEFile.FindByys";
            IList<T_CellAndEFile> result = MyISqlMap.QueryForList<T_CellAndEFile>(stmtId, ys);
            return result;
        }

        public IList<T_CellAndEFile> FindByyswjpath(String yswjpath)
        {
            String stmtId = "T_CellAndEFile.FindByyswjpath";
            IList<T_CellAndEFile> result = MyISqlMap.QueryForList<T_CellAndEFile>(stmtId, yswjpath);
            return result;
        }

        public IList<T_CellAndEFile> FindByzezzzfw(String zezzzfw)
        {
            String stmtId = "T_CellAndEFile.FindByzezzzfw";
            IList<T_CellAndEFile> result = MyISqlMap.QueryForList<T_CellAndEFile>(stmtId, zezzzfw);
            return result;
        }

        public IList<T_CellAndEFile> FindByzfbmc(String zfbmc)
        {
            String stmtId = "T_CellAndEFile.FindByzfbmc";
            IList<T_CellAndEFile> result = MyISqlMap.QueryForList<T_CellAndEFile>(stmtId, zfbmc);
            return result;
        }

        public IList<T_CellAndEFile> FindByzrr(String zrr)
        {
            String stmtId = "T_CellAndEFile.FindByzrr";
            IList<T_CellAndEFile> result = MyISqlMap.QueryForList<T_CellAndEFile>(stmtId, zrr);
            return result;
        }

        public IList<T_CellAndEFile> FindByzrzbsm(String zrzbsm)
        {
            String stmtId = "T_CellAndEFile.FindByzrzbsm";
            IList<T_CellAndEFile> result = MyISqlMap.QueryForList<T_CellAndEFile>(stmtId, zrzbsm);
            return result;
        }

        public IList<T_CellAndEFile> FindByzrzlb(String zrzlb)
        {
            String stmtId = "T_CellAndEFile.FindByzrzlb";
            IList<T_CellAndEFile> result = MyISqlMap.QueryForList<T_CellAndEFile>(stmtId, zrzlb);
            return result;
        }

        public IList<T_CellAndEFile> FindByzrzmc(String zrzmc)
        {
            String stmtId = "T_CellAndEFile.FindByzrzmc";
            IList<T_CellAndEFile> result = MyISqlMap.QueryForList<T_CellAndEFile>(stmtId, zrzmc);
            return result;
        }

        public void Insert(T_CellAndEFile obj)
        {
            if (obj == null) throw new ArgumentNullException("obj");
            String stmtId = "T_CellAndEFile.Insert";
            MyISqlMap.Insert(stmtId, obj);
        }


        public void Add(T_CellAndEFile obj)
        {
            Insert(obj);
        }


        public void Update(T_CellAndEFile obj)
        {
            if (obj == null) throw new ArgumentNullException("obj");
            String stmtId = "T_CellAndEFile.Update";
            MyISqlMap.Update(stmtId, obj);
        }

        public void Delete(T_CellAndEFile obj)
        {
            if (obj == null) throw new ArgumentNullException("obj");
            String stmtId = "T_CellAndEFile.Delete";
            MyISqlMap.Delete(stmtId, obj);
        }


        public void Delete(String cellID, String projectNO) {
			if (cellID==null || projectNO == null) throw new ArgumentNullException("obj");
			String stmtId = "T_CellAndEFile.Delete";
            
			T_CellAndEFile obj = new T_CellAndEFile();
			obj.CellID=cellID;
            obj.ProjectNO = projectNO;
            
			MyISqlMap.Delete(stmtId, obj);
		}

        public void DeleteByFileID(String FileID, String projectNO)
        {
            if (FileID == null || projectNO == null) throw new ArgumentNullException("obj");
            String stmtId = "T_CellAndEFile.DeleteByFileID";

            T_CellAndEFile obj = new T_CellAndEFile();
            obj.FileID = FileID;
            obj.ProjectNO = projectNO;

            MyISqlMap.Delete(stmtId, obj);
        }

        public int GetMaxOrderIndex(string FileID, string ProjectNO)
        {
            String stmtId = "T_CellAndEFile.GetMaxOrderIndex";
            MDL.T_CellAndEFile obj = new T_CellAndEFile();
            obj.FileID = FileID;
            obj.ProjectNO = ProjectNO;
            object result = MyISqlMap.QueryForObject(stmtId, obj);
            if (result == null)
                result = "0";
            return int.Parse(result.ToString());
        }

        //2011-04-06 导出错误 自定义的资源用表在文件导出时 没有导出
        public IList<T_CellAndEFile> FindByFileID(String fileID, string ProjectNO)
        {
            String stmtId = "T_CellAndEFile.FindByFileIDNoStatus";
            MDL.T_CellAndEFile obj = new T_CellAndEFile();
            obj.FileID = fileID;
            obj.ProjectNO = ProjectNO;
            IList<T_CellAndEFile> result = MyISqlMap.QueryForList<T_CellAndEFile>(stmtId, obj);
            return result;//
        }

        public IList<T_CellAndEFile> FindByGdFileID(String gdfileID, string ProjectNO)
        {
            String stmtId = "T_CellAndEFile.FindByGdFileID";
            MDL.T_CellAndEFile obj = new T_CellAndEFile();
            obj.GdFileID = gdfileID;
            obj.ProjectNO = ProjectNO;
            IList<T_CellAndEFile> result = MyISqlMap.QueryForList<T_CellAndEFile>(stmtId, obj);
            return result;
        }

        public System.Data.DataTable FindAllByProjectNO(string ProjectNO)
        {
            String stmtId = "T_CellAndEFile.GetListByProjectNo";
            System.Data.DataTable result = DAL.MyBatis.QueryForDataTable(stmtId, ProjectNO);
            return result;
        }
        public int GetMaxGdFileOrderIndex(string GdFileID, string ProjectNO)
        {
            String stmtId = "T_CellAndEFile.GetMaxGdFileOrderIndex";
            MDL.T_CellAndEFile obj = new T_CellAndEFile();
            obj.GdFileID = GdFileID;
            obj.ProjectNO = ProjectNO;
            object result = MyISqlMap.QueryForObject(stmtId, obj);
            if (result == null)
                result = "0";
            return int.Parse(result.ToString());
        }
    }
}
