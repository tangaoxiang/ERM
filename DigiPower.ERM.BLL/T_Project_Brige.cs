using System;
using System.Collections.Generic;
using System.Text;
using ERM.MDL;
using System.Data;
namespace ERM.BLL
{
    public class T_Project_Brige_BLL : IBLL
    {
        /// <summary>
        /// 根据项目ID获取相应市政桥梁工程明细
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public T_Project_Brige QueryBrige_ByProjID(string ID)
        {
            String stmtId = "T_Project_Brige.QueryBrige_ByProjID";
            T_Project_Brige result = MyISqlMap.QueryForObject<T_Project_Brige>(stmtId, ID);
            return result;
        }

        public void Insert(T_Project_Brige obj)
        {
            if (obj == null) throw new ArgumentNullException("obj");
            String stmtId = "T_Project_Brige.InsertT_Brige";
            MyISqlMap.Insert(stmtId, obj);
        }

        public bool Add(T_Projects model_Projects, T_Item model_Item, T_Project_Brige model_Brige)
        {
            BLL.T_Projects_BLL proj_bll = new T_Projects_BLL();
            bool flag = proj_bll.Add(model_Projects, model_Item);

            if (flag)
            {
                this.Insert(model_Brige);
                return true;
            }
            return false;
        }
        public bool Update(T_Projects model_Projects, T_Item model_Item, T_Project_Brige model_Brige)
        {
            BLL.T_Projects_BLL proj_bll = new T_Projects_BLL();
            bool flag = proj_bll.Update(model_Projects, model_Item);

            if (flag)
            {
                this.Update(model_Brige);
                return true;
            }
            return false;
        }

        public void Update(T_Project_Brige obj)
        {
            if (obj == null) throw new ArgumentNullException("obj");
            String stmtId = "T_Project_Brige.UpdateT_Brige";
            MyISqlMap.Update(stmtId, obj);
        }

        public void Delete(String ID)
        {
            if (ID == null) throw new ArgumentNullException("ID");
            String stmtId = "T_Project_Brige.DeleteT_Brige";
            T_Project_Brige obj = new T_Project_Brige();
            obj.ID = ID;
            MyISqlMap.Delete(stmtId, obj);
        }
    }
}
