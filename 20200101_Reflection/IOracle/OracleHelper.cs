using System;
using ReflectionDemo.IDB;

namespace ReflectionDemo.IOracle
{
    public class OracleHelper : IDBHelper
    {
        public OracleHelper()
        {
            System.Console.WriteLine("{0}被构造", this.GetType().Name);
        }
        public void Query()
        {
            System.Console.WriteLine("{0} query", this.GetType().Name);
        }
    }
}
