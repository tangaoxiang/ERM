using ERM.MDL;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERM.BLL
{
    public class T_Users_BLL : IBLL 
    {
		public int GetCount() 
        {
			String stmtId = "T_Users.GetCount";
			int result = MyISqlMap.QueryForObject<int>(stmtId, null);
			return result;
		}
		public T_Users Find(Int32 userid) {
			String stmtId = "T_Users.Find";
			T_Users result = MyISqlMap.QueryForObject<T_Users>(stmtId, userid);
			return result;
		}
        public System.Data.DataSet GetList(String strWhere)
        {
			String stmtId = "T_Users.GetList";            
            if (strWhere == null || strWhere == "" || strWhere == "1=1")
            {
                strWhere = null;
                stmtId = "T_Users.GetAll";
            }
            System.Data.DataSet result = DAL.MyBatis.QueryForDataSet(stmtId, strWhere);            
			return result;
		}
		public bool Exists(Int32 userid) {
			String stmtId = "T_Users.Exists";
			bool result = MyISqlMap.QueryForObject<bool>(stmtId, userid);
			return result;
		}
		public IList<T_Users> GetAll() {
			String stmtId = "T_Users.GetAll";
			IList<T_Users> result = MyISqlMap.QueryForList<T_Users>(stmtId, null);
			return result;
		}
		public IList<T_Users> FindBylogin(String login) {
			String stmtId = "T_Users.FindBylogin";
			IList<T_Users> result = MyISqlMap.QueryForList<T_Users>(stmtId, login);
			return result;
		}
		public IList<T_Users> FindBypassword(String password) {
			String stmtId = "T_Users.FindBypassword";
			IList<T_Users> result = MyISqlMap.QueryForList<T_Users>(stmtId, password);
			return result;
		}
		public IList<T_Users> FindByfullname(String fullname) {
			String stmtId = "T_Users.FindByfullname";
			IList<T_Users> result = MyISqlMap.QueryForList<T_Users>(stmtId, fullname);
			return result;
		}
		public IList<T_Users> FindBytitle(String title) {
			String stmtId = "T_Users.FindBytitle";
			IList<T_Users> result = MyISqlMap.QueryForList<T_Users>(stmtId, title);
			return result;
		}
		public IList<T_Users> FindByphone(String phone) {
			String stmtId = "T_Users.FindByphone";
			IList<T_Users> result = MyISqlMap.QueryForList<T_Users>(stmtId, phone);
			return result;
		}
		public IList<T_Users> FindBysh(Int32? sh) {
			String stmtId = "T_Users.FindBysh";
			IList<T_Users> result = MyISqlMap.QueryForList<T_Users>(stmtId, sh);
			return result;
		}
		public IList<T_Users> FindBytheme(Int32? theme) {
			String stmtId = "T_Users.FindBytheme";
			IList<T_Users> result = MyISqlMap.QueryForList<T_Users>(stmtId, theme);
			return result;
		}
		public IList<T_Users> FindByunits(String units) {
			String stmtId = "T_Users.FindByunits";
			IList<T_Users> result = MyISqlMap.QueryForList<T_Users>(stmtId, units);
			return result;
		}
		public IList<T_Users> FindByunitstype(String unitstype) {
			String stmtId = "T_Users.FindByunitstype";
			IList<T_Users> result = MyISqlMap.QueryForList<T_Users>(stmtId, unitstype);
			return result;
		}
		public void Insert(T_Users obj) {
			if (obj == null) throw new ArgumentNullException("obj");
			String stmtId = "T_Users.Insert";
			MyISqlMap.Insert(stmtId, obj);
		}
		public void Add(T_Users obj) {
			Insert(obj);
		}
		public void Update(T_Users obj) {
			if (obj == null) throw new ArgumentNullException("obj");
			String stmtId = "T_Users.Update";
			MyISqlMap.Update(stmtId, obj);
		}
		public void Delete(T_Users obj) {
			if (obj == null) throw new ArgumentNullException("obj");
			String stmtId = "T_Users.Delete";
			MyISqlMap.Delete(stmtId, obj);
		}
		public void Delete(Int32 userid) {
			if (userid == null) throw new ArgumentNullException("obj");
			String stmtId = "T_Users.Delete";
			T_Users obj = new T_Users();
			obj.userid = userid;
			MyISqlMap.Delete(stmtId, obj);
		}	
    }
}
