using System.Reflection;
using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

using ReflectionDemo.IDB;
using ReflectionDemo.IMySql;
using ReflectionDemo.ISqlServer;
using ReflectionDemo.Models;

namespace ReflectionDemo.MyReflection
{
    /// <summary>
    /// 1 dll-IL-netadata-reflection
    /// 2 load dll, read module, class, method, and attribute
    /// 3 create object, reflection+simple factory+config,  (destory Singleton, create Generic type)
    /// 4 call instance method, static method, override method, (call private method, generic method)
    /// 5 field and property, get and set value
    /// 6 bebefit and limit
    /// 
    /// MVC ASP.NET ORM IOC AOP
    /// almost all framework using reflection
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            try
            {
                {
                    System.Console.WriteLine("********************Common*******************");
                    /*
                    IDBHelper idbhelper = new MySqlHelper();
                    idbhelper.Query();

                    IDBHelper idbhelper = new SqlServerHelper();
                    idbhelper.Query();
                    */
                }
                {
                    System.Console.WriteLine("********************Reflection1*******************");
                    /*
                    //动态加载一个完整dll/exe名称，不带后缀， 
                    //从当前路径(exe)加载（编译后）
                    Assembly assembly = Assembly.Load("IMySql");
                    //完整路径加载
                    //Assembly assembly1 = Assembly.LoadFile(@"D:\Workspace\dotnet\ruanmou\Adv_12\20200101_Reflection\MyReflection\bin\Debug\netcoreapp3.1\IMySql.dll");
                    //当前路径或完整路径加载
                    //Assembly assembly2 = Assembly.LoadFrom("IMySql.dll");
                    //Assembly assembly3 = Assembly.LoadFrom(@"D:\Workspace\dotnet\ruanmou\Adv_12\20200101_Reflection\MyReflection\bin\Debug\netcoreapp3.1\IMySql.dll");

                    foreach(var type in assembly.GetTypes())
                    {
                        //var isGenericType = type.IsGenericType();
                        System.Console.WriteLine(type.Name);
                        foreach(var method in type.GetMethods())
                        {
                            System.Console.WriteLine(method.Name);
                        }
                    }
                    */
                }
                {
                    System.Console.WriteLine("********************Reflection2*******************");
                    /*
                    Assembly assembly = Assembly.Load("IMySql");//load dynamic
                    Type type=assembly.GetType("ReflectionDemo.IMySql.MySqlHelper");//get type name based on name with namespace
                    //dynamic ddbhelper = Activator.CreateInstance(type);
                    //ddbhelper.Query();
                    object odbhelper = Activator.CreateInstance(type);// create object
                    //odbhelper.Query();
                    IDBHelper idbhelper = odbhelper as IDBHelper;//as : if wrong type, return null
                    idbhelper.Query();
                    */
                }
                {
                    // if code is complex, wrap it
                    System.Console.WriteLine("********************Reflection3 + Factory + Configuration*******************");
                    /*
                    // configurable:
                    //1 reflection create object via config file;
                    //2 the instance class must be know, and under current path
                    IDBHelper iDBHelper = SimpleFactory.CreateInstance();
                    iDBHelper.Query();
                    
                    // extensible
                    // copy library file, and update configuration, to support new funciton
                    // Net Framework work, dotnet core 3.1 not work
                    */
                }
                {
                    System.Console.WriteLine("********************Constructor + Parameter*******************");
                    /*
                    Assembly assembly = Assembly.Load("ISqlServer");
                    Type type = assembly.GetType("ReflectionDemo.ISqlServer.ReflectionTest");

                    foreach(var ctor in type.GetConstructors())
                    {
                        System.Console.WriteLine(ctor.Name);
                        foreach(var param in ctor.GetParameters())
                        {
                            System.Console.WriteLine(param.ParameterType);
                        }   
                    }

                    object otest1= Activator.CreateInstance(type);
                    object otest2= Activator.CreateInstance(type, new object[]{123});
                    object otest3= Activator.CreateInstance(type, new object[]{"八戒，你瘦了"});
                    */
                }
                {
                    System.Console.WriteLine("********************Singleton + Reflection*******************");
                    /*
                    Singleton singleton1 = Singleton.GetInstance();
                    Singleton singleton2 = Singleton.GetInstance();
                    Singleton singleton3 = Singleton.GetInstance();
                    Singleton singleton4 = Singleton.GetInstance();
                    Singleton singleton5 = Singleton.GetInstance();
                    System.Console.WriteLine($"{object.ReferenceEquals(singleton1, singleton5)}");

                    // reflection distroy singleton, to call private constructor
                    Assembly assembly = Assembly.Load("ISqlServer");
                    Type type = assembly.GetType("ReflectionDemo.ISqlServer.Singleton");
                    // generate exception: can not point which constructor
                    //Singleton singletonA = (Singleton)Activator.CreateInstance(type);
                    Singleton singletonA1 = (Singleton)Activator.CreateInstance(type, true);
                    Singleton singletonA2 = (Singleton)Activator.CreateInstance(type, true);
                    Singleton singletonA3 = (Singleton)Activator.CreateInstance(type, true);
                    Singleton singletonA4 = (Singleton)Activator.CreateInstance(type, true);
                    System.Console.WriteLine($"{object.ReferenceEquals(singletonA1, singletonA4)}");
                    */
                }
                {
                    System.Console.WriteLine("********************Generic Class + Reflection*******************");
                    /*
                    Assembly assembly = Assembly.Load("ISqlServer");
                    Type type = assembly.GetType("ReflectionDemo.ISqlServer.GenericClass`3");
                    //object oGeneric = Activator.CreateInstance(type);
                    //GenericClass<string, int, DateTime> genericClass = new GenericClass<string, int, DateTime>();
                    Type typeMake = type.MakeGenericType(new Type[]{typeof(string), typeof(int), typeof(DateTime)});
                    object oGeneric = Activator.CreateInstance(typeMake);
                    */
                }

                {
                    //Reflect, withour convert object, using its methods
                    //reflection create object instance, haveing method name, you can call method via reflection
                    // MVC, calling Action, like this
                    // routing--> congtroller-->action
                    // mvc scan and load all dlls when start, find all controllers and save; when request coming, search controllers: dll+type mame
                    // mvc limit:
                    // 1. overided action, reflection identify them only via httpmethod(httpget, httppost,...)
                    // 2. AOP--reflection call method, can insert logic before/after call method
                    System.Console.WriteLine("********************Object*******************");
                    /*
                    Assembly assembly = Assembly.Load("ISqlServer");
                    Type type = assembly.GetType("ReflectionDemo.ISqlServer.ReflectionTest");
                    object otest1= Activator.CreateInstance(type);
                    //foreach(var method in type.GetMethods())
                    //{
                    //    System.Console.WriteLine(method.Name);
                    //    foreach(var param in method.GetParameters())
                    //    {
                    //        System.Console.WriteLine($"{param.Name} {param.ParameterType}");
                    //    }
                    //}
                    MethodInfo mInfo1 = type.GetMethod("Show1");
                    var oreturn = mInfo1.Invoke(otest1, null);

                    MethodInfo mInfo2 = type.GetMethod("Show2");
                    mInfo2.Invoke(otest1, new object[]{123});

                    MethodInfo mInfo3_0 = type.GetMethod("Show3", new Type[]{});
                    mInfo3_0.Invoke(otest1, null);
                    
                    MethodInfo mInfo3_1 = type.GetMethod("Show3", new Type[]{typeof(int)});
                    mInfo3_1.Invoke(otest1, new object[]{123});
                    
                    MethodInfo mInfo3_2 = type.GetMethod("Show3", new Type[]{typeof(string)});
                    mInfo3_2.Invoke(otest1, new object[]{"八戒，你瘦了"});
                    
                    MethodInfo mInfo3_3 = type.GetMethod("Show3", new Type[]{typeof(int), typeof(string)});
                    mInfo3_3.Invoke(otest1, new object[]{123, "八戒，你瘦了"});
                    
                    MethodInfo mInfo3_4 = type.GetMethod("Show3", new Type[]{typeof(string), typeof(int)});
                    mInfo3_4.Invoke(otest1, new object[]{"八戒，你瘦了", 123});

                    MethodInfo mInfo5_1 = type.GetMethod("Show5");
                    //mInfo5_2.Invoke(otest1, new object[]{"八戒，你瘦了"});
                    mInfo5_1.Invoke(null, new object[]{"八戒，你瘦了"});

                    MethodInfo mInfo5_2 = type.GetMethod("Show5");
                    mInfo5_2.Invoke(otest1, new object[]{"八戒，你瘦了"});
                    */
                }
                {
                    //call private method, generic method
                    System.Console.WriteLine("********************private*******************");
                    /*
                    Assembly assembly = Assembly.Load("ISqlServer");
                    Type type = assembly.GetType("ReflectionDemo.ISqlServer.ReflectionTest");
                    object otest1= Activator.CreateInstance(type);
                    var method = type.GetMethod("Show4", BindingFlags.Instance|BindingFlags.NonPublic);
                    method.Invoke(otest1, new object[]{"八戒， 你瘦了"});
                    */
                }
                {
                    System.Console.WriteLine("********************Generic Method + Reflection*******************");
                    /*
                    Assembly assembly = Assembly.Load("ISqlServer");
                    Type type = assembly.GetType("ReflectionDemo.ISqlServer.GenericMethod");
                    object oGeneric = Activator.CreateInstance(type);
                    foreach(var item in type.GetMethods())
                    {
                        System.Console.WriteLine(item.Name);
                    }
                    MethodInfo methodInfo=type.GetMethod("Show");
                    var mInfo=methodInfo.MakeGenericMethod(new Type[]{typeof(int), typeof(string), typeof(DateTime)});
                    mInfo.Invoke(oGeneric,new object[]{123, "八戒，你瘦了", DateTime.Now});
                    */
                }
                {
                    System.Console.WriteLine("********************Generic Class + Generic Method + Reflection*******************");
                    /*
                    Assembly assembly = Assembly.Load("ISqlServer");
                    Type type = assembly.GetType("ReflectionDemo.ISqlServer.GenericDouble`1").MakeGenericType(typeof(int));
                    object oGeneric = Activator.CreateInstance(type);
                    MethodInfo mInfo=type.GetMethod("Show").MakeGenericMethod(typeof(string), typeof(DateTime));
                    mInfo.Invoke(oGeneric,new object[]{123, "八戒，你瘦了", DateTime.Now});
                    */
                }
                {                    
                    System.Console.WriteLine("********************Common + Reflection*******************");
                    //common
                    People people = new People();
                    people.Id=123;
                    people.Name="八戒，你瘦了";
                    people.Description="你是个吃货~";
                    System.Console.WriteLine($"people.Id={people.Id}");
                    System.Console.WriteLine($"people.Name={people.Name}");
                    System.Console.WriteLine($"people.Description={people.Description}");
                    //reflection
                }
                
                Console.Read();
            }
            catch(Exception exception)
            {
                System.Console.WriteLine(exception.Message);
            }
        }
    }
}
