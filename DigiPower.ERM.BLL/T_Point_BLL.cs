using System;
using System.Collections.Generic;
using System.Text;
using ERM.MDL;
namespace ERM.BLL
{
    public class T_Point_BLL : IBLL
    {
        public IList<T_Point> GetList(string projectNo)
        {
            String stmtId = "T_Point.GetList";
            IList<T_Point> result = MyISqlMap.QueryForList<T_Point>(stmtId, projectNo);
            return result;
        }

        /// <summary>
        /// 新增顺序号是否重复验证
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Exists(T_Point obj)
        {
            String stmtId = "T_Point.Exists";
            IList<T_Point> result = MyISqlMap.QueryForList<T_Point>(stmtId, obj);
            if (result.Count == 0)
                return false;
            else
                return true;
        }

        /// <summary>
        /// 编辑顺序号是否重复验证
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool ExistsByEdit(T_Point obj)
        {
            String stmtId = "T_Point.Exists";
            IList<T_Point> result = MyISqlMap.QueryForList<T_Point>(stmtId, obj);
            if (result.Count == 0)
                return false;
            else if (result.Count > 1)
            {
                return true;
            }
            else {
                foreach (var item in result)
                {
                    if (item.ID==obj.ID)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public void Insert(T_Point obj)
        {
            if (obj == null) throw new ArgumentNullException("obj");
            String stmtId = "T_Point.Insert";
            MyISqlMap.Insert(stmtId, obj);
        }
        public void Add(T_Point obj)
        {
            Insert(obj);
        }
        public void Update(T_Point obj)
        {
            if (obj == null) throw new ArgumentNullException("obj");
            String stmtId = "T_Point.Update";
            MyISqlMap.Update(stmtId, obj);
        }
        public void Delete(T_Point obj)
        {
            if (obj == null) throw new ArgumentNullException("obj");
            String stmtId = "T_Point.Delete";
            MyISqlMap.Delete(stmtId, obj);
        }
    }
}
