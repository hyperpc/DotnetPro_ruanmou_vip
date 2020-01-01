using System;
using ReflectionDemo.IDB;

namespace ReflectionDemo.ISqlServer
{
    public class SqlServerHelper:IDBHelper
    {
        public SqlServerHelper()
        {
            System.Console.WriteLine("{0}被构造", this.GetType().Name);
        }
        public void Query()
        {
            System.Console.WriteLine("{0} query", this.GetType().Name);
        }
    }
}
