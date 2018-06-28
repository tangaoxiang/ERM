using System;
using System.Collections.Generic;
using System.Text;
using ERM.BLL;
namespace ERM.CBLL
{
    public class BLLMore : IBLL
    {
        public void CopyFileList(string _projectNO)
        {
            String stmtId = "T_FileList.CopyFileList";
            MyISqlMap.QueryForObject<int>(stmtId, _projectNO);            
        }
    }
}
