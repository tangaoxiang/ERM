using System;
using System.Collections.Generic;
using System.Text;
namespace ERM.MDL
{
    [Serializable]
    public partial class T_Users
    {
        private Int32 m_userid;
        public Int32 userid { set; get; }
        public String login { set; get; }
        public String password { set; get; }
        public String fullname { set; get; }
        public String title { set; get; }
        public String phone { set; get; }
        public Int32 sh { set; get; }
        public Int32 theme { set; get; }
        public String units { set; get; }
        public String unitstype { set; get; }
    }
}
