using System.Linq;
using System;
using ReflectionDemo.IDB;
using ReflectionDemo.Models;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ReflectionDemo.ISqlServer
{
    public class SqlServerHelper:IDBHelper
    {
        private static string connStringCustomer = ConfigurationManager.ConnectionStrings["Customers"].ConnectionString;
        public SqlServerHelper()
        {
            //System.Console.WriteLine("{0}被构造", this.GetType().Name);
        }
        public void Query()
        {
            //System.Console.WriteLine("{0} query", this.GetType().Name);
        }

        /// <summary>
        /// Find Company, User, .etc
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public T Find<T>(int id)
        {
            //string sql = @"Select Id,Name, CreateTime,CreatorId,LastUpdatedById,LastUpdatedTime From Company Where Id="+id;
            Type type=typeof(T);
            string sql = $"SELECT {string.Join(",",type.GetProperties().Select(p=>$"[{p.Name}]"))} FROM [{type.Name}] WHERE ID={id}";
            object obj = Activator.CreateInstance(type);
            using(SqlConnection conn = new SqlConnection(connStringCustomer))
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();
                var reader = cmd.ExecuteReader();
                if(reader.Read())
                {
                    foreach(var prop in type.GetProperties())
                    {
                        prop.SetValue(obj, reader[prop.Name]);
                        //if(prop.Name.Equals("Id")){
                        //    prop.SetValue(obj, reader["Id"]);
                        //}else if(prop.Name.Equals("Name")){
                        //    prop.SetValue(obj, reader["Name"]);
                        //}
                    }
                }
            }
            return (T)obj;
        }
    }
}
