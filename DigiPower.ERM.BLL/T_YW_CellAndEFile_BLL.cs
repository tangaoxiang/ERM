using System;
using System.Collections.Generic;
using System.Text;
using ERM.MDL;
using System.Collections;
namespace ERM.BLL
{
    /// <summary>
    /// 原文表信息
    /// </summary>
    public class T_YW_CellAndEFile_BLL : IBLL
    {

        public IList<T_YW_CellAndEFile> FindByCellID(String cellID, string ProjectNO)
        {  
            String stmtId = "T_YW_CellAndEFile.FindByCellID";
            MDL.T_YW_CellAndEFile obj = new T_YW_CellAndEFile();
            obj.CellID = cellID;
            obj.ProjectNO = ProjectNO;
            IList<T_YW_CellAndEFile> result = MyISqlMap.QueryForList<T_YW_CellAndEFile>(stmtId, obj);
            return result;
        }

        public IList<T_YW_CellAndEFile> FindByID(String ID)
        {
            String stmtId = "T_YW_CellAndEFile.FindByID";
            IList<T_YW_CellAndEFile> result = MyISqlMap.QueryForList<T_YW_CellAndEFile>(stmtId, ID);
            return result;
        }

        public void Insert(T_YW_CellAndEFile obj)
        {
            if (obj == null) throw new ArgumentNullException("obj");
            obj.ID = Guid.NewGuid().ToString();
            String stmtId = "T_YW_CellAndEFile.Insert";
            MyISqlMap.Insert(stmtId, obj);
        }
         
        public void Update(T_YW_CellAndEFile obj)
        {
            if (obj == null) throw new ArgumentNullException("obj");
            String stmtId = "T_YW_CellAndEFile.Update";
            MyISqlMap.Update(stmtId, obj);
        }

        public void Delete(T_YW_CellAndEFile obj)
        {
            if (obj == null) throw new ArgumentNullException("obj");
            String stmtId = "T_YW_CellAndEFile.Delete";
            MyISqlMap.Delete(stmtId, obj);
        }
    }
}
