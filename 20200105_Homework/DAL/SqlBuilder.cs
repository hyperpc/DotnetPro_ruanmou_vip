using System;
using Model;
using System.Data.SqlClient;
using System.Reflection;
using System.Linq;

namespace DAL
{
    /// <summary>
    /// cache fix sql
    /// </summary>
    public class SqlBuilder<T> where T:BaseModel
    {
        public static string FindSql = null;
        public static string FindAllSql = null;
        public static string AddSql = null;

        static SqlBuilder()
        {
            Type type =typeof(T);

            FindSql=$"SELECT {string.Join(",",type.GetProperties().Select(p=>$"[{p.Name}]"))} FROM [{type.Name}] WHERE ID=@Id";

            FindAllSql = $"SELECT {string.Join(",",type.GetProperties().Select(p=>$"[{p.Name}]"))} FROM [{type.Name}]";

            string columns = string.Join(",", type.GetProperties(BindingFlags.DeclaredOnly|BindingFlags.Instance|BindingFlags.Public)
                                .Select(p=>$"[{p.Name}]"));
            string values= string.Join(",", type.GetProperties(BindingFlags.DeclaredOnly|BindingFlags.Instance|BindingFlags.Public)
                                .Select(p=>$"@{p.Name}"));
            //List<SqlParameter> parameters = type.GetProperties(BindingFlags.DeclaredOnly|BindingFlags.Instance|BindingFlags.Public)
            //                    .Select(p=>new SqlParameter($"@{p.Name}", p.GetValue(t)??DBNull.Value));
            AddSql = $"Insert Into [{type.Name}] (columns) Values(values)";

        }

    }
}