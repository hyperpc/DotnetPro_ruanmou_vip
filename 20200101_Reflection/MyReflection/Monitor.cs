using System;
using System.Diagnostics;
using ReflectionDemo.IDB;
using ReflectionDemo.ISqlServer;
using System.Reflection;

namespace ReflectionDemo.MyReflection
{
    public class Monitor
    {
        public static void Show()
        {
            System.Console.WriteLine("********************Monitor*******************");
            long commonTime=0;
            long reflectionTime=0;
            {
                Stopwatch watch = new Stopwatch();
                watch.Start();
                for (int i = 0; i < 1_000_000; i++)
                {
                    IDBHelper iDBHelper = new SqlServerHelper();
                    iDBHelper.Query();
                }
                watch.Stop();
                commonTime=watch.ElapsedMilliseconds;
            }
            {
                Stopwatch watch = new Stopwatch();
                watch.Start();

                Assembly assembly = Assembly.Load("ISqlServer");
                Type type = assembly.GetType("ReflectionDemo.ISqlServer.SqlServerHelper");

                for (int i = 0; i < 1_000_000; i++)
                {

                    //Assembly assembly = Assembly.Load("ISqlServer");
                    //Type type = assembly.GetType("ReflectionDemo.ISqlServer.SqlServerHelper");
                    
                    object oDBHelper = Activator.CreateInstance(type);
                    IDBHelper dbHelper=(IDBHelper)oDBHelper;
                    dbHelper.Query();

                }
                watch.Stop();
                reflectionTime=watch.ElapsedMilliseconds;
            }
            System.Console.WriteLine("commonTime={0}, reflectionTime={1}", commonTime, reflectionTime);
        }
    }
}