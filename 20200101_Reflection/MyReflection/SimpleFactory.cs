using System;
using System.Reflection;
using System.Configuration;
//using System.Configuration.ConfigurationManager;
using ReflectionDemo.IDB;

namespace ReflectionDemo.MyReflection
{
    public class SimpleFactory
    {
        private static string IDBHelper = ConfigurationManager.AppSettings["IDBHelperConfig"];
        private static string DllName = IDBHelper.Split(',')[1];
        private static string TypeName = IDBHelper.Split(',')[0];
        public static IDBHelper CreateInstance()
        {
            System.Console.WriteLine("********************SimpleFactory*******************");
            //System.Console.WriteLine(DllName);
            //System.Console.WriteLine(TypeName);
            //Console.ReadKey();
            //load dynamic
            Assembly assembly = Assembly.Load(DllName);
            //get type name based on name with namespace
            Type type = assembly.GetType(TypeName);
            // create object
            object odbhelper = Activator.CreateInstance(type);
            //as : if wrong type, return null
            IDBHelper idbhelper = odbhelper as IDBHelper;
            return idbhelper;
        }
    }
}