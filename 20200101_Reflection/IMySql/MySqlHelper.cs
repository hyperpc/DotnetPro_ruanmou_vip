using System;
using ReflectionDemo.IDB;

namespace ReflectionDemo.IMySql
{
    public class MySqlHelper : IDBHelper
    {
        public MySqlHelper()
        {
            System.Console.WriteLine("{0}被构造", this.GetType().Name);
        }

        public void Query()
        {
            System.Console.WriteLine("{0} query", this.GetType().Name);
        }
    }
}
