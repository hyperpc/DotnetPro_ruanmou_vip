using System.Linq;
using System.Collections.Generic;
using System;
using Model;
using IDAL;
using System.Data.SqlClient;
using System.Reflection;
//using System.Configuration;
using Framework;

namespace DAL
{
    public class BaseDAL : IBaseDAL
    {
        private static string connStringCustomer = StaticConstraint.IBaseDALConfig;
        //private static string connStringCustomer = ConfigurationManager.ConnectionStrings["Customers"].ConnectionString;
        public T Find<T>(int Id) where T : BaseModel
        {
            Type type=typeof(T);
            string sql = $"SELECT {string.Join(",",type.GetProperties().Select(p=>$"[{p.Name}]"))} FROM [{type.Name}] WHERE ID={Id}";
            using(SqlConnection conn = new SqlConnection(connStringCustomer))
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();
                var reader = cmd.ExecuteReader();
                if(reader.Read())
                {
                    return Trans<T>(type, reader);
                }
                else
                {
                    return null;
                }
            }
        }
        public List<T> FindAll<T>() where T : BaseModel
        {
            Type type=typeof(T);
            //string sql = $"SELECT {string.Join(",",type.GetProperties().Select(p=>$"[{p.Name}]"))} FROM [{type.Name}]";
            string sql=SqlBuilder<T>.FindAllSql;
            using(SqlConnection conn = new SqlConnection(connStringCustomer))
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();
                var reader = cmd.ExecuteReader();
                List<T> list = new List<T>();
                while(reader.Read())
                {
                    list.Add(Trans<T>(type, reader));
                }
                return list;
            }
        }
        public bool Add<T>(T t) where T : BaseModel
        {
            Type type = typeof(T);
            //string columns = string.Join(",", type.GetProperties().Select(p=>$"[{p.Name}]"));
            //string columns = string.Join(",", type.GetProperties()
            //                    .Where(p=>!p.Name.Equals("Id"))
            //                    .Select(p=>$"[{p.Name}]"));
            string columns = string.Join(",", type.GetProperties(BindingFlags.DeclaredOnly|BindingFlags.Instance|BindingFlags.Public)
                                .Select(p=>$"[{p.Name}]"));
            string values= string.Join(",", type.GetProperties(BindingFlags.DeclaredOnly|BindingFlags.Instance|BindingFlags.Public)
                                .Select(p=>$"@{p.Name}"));
            //List<SqlParameter> parameters = type.GetProperties(BindingFlags.DeclaredOnly|BindingFlags.Instance|BindingFlags.Public)
            //                    .Select(p=>new SqlParameter($"@{p.Name}", p.GetValue(t)??DBNull.Value));
            var parameters = type.GetProperties(BindingFlags.DeclaredOnly|BindingFlags.Instance|BindingFlags.Public)
                                .Select(p=>new SqlParameter($"@{p.Name}", p.GetValue(t)??DBNull.Value));
            string sql = $"Insert Into [{type.Name}] (columns) Values(values)";

            using(SqlConnection conn = new SqlConnection(connStringCustomer))
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();
                cmd.Parameters.AddRange(parameters.ToArray());
                return cmd.ExecuteNonQuery()==1;
                //if return new Id? Select SCOPE_IDENTITY/@@Identity; ExecuteScalar()
            }
        }
        public bool Update<T>(T t) where T : BaseModel
        {
            throw new NotImplementedException();
        }
        public bool Delete<T>(T t) where T : BaseModel
        {            
            // t.Id
            throw new NotImplementedException();
        }

        #region Utils
        private T Trans<T>(Type type, SqlDataReader reader)
        {
            object obj = Activator.CreateInstance(type);
            foreach(var prop in type.GetProperties())
            {
                //nullable fields, if null in db, then setvalue will error
                prop.SetValue(obj, reader[prop.Name] is DBNull? null:reader[prop.Name]);
            }
            return (T)obj;
        }
        #endregion
    }
}
