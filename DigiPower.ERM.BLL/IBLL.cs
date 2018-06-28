using System.IO;
using System.Reflection;
using IBatisNet.DataMapper;
using IBatisNet.DataMapper.Configuration;
using ERM.DAL;
namespace ERM.BLL
{
    public class IBLL
    {
        protected static ISqlMapper MyISqlMap = MyBatis.SqlMapInterface;
    }
}
