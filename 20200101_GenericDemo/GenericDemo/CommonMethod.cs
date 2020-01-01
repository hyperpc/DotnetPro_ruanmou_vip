using System;

namespace GenericDemo
{
    public class CommonMethod
    {
       public static void ShowInt(int iParam) 
       {
           Console.WriteLine("This is {0}, parameter={1},type={2}",typeof(CommonMethod).Name, iParam.GetType().Name,iParam);
       }
       public static void ShowString(string sParam) 
       {
           Console.WriteLine("This is {0}, parameter={1},type={2}",typeof(CommonMethod).Name, sParam.GetType().Name,sParam);
       }
       public static void ShowDatetime(DateTime dtParam) 
       {
           Console.WriteLine("This is {0}, parameter={1},type={2}",typeof(CommonMethod).Name, dtParam.GetType().Name,dtParam);
       }
       //
       //1 child class can replace parent class
       //2 object is all class's parent
       //***************************
       //1 zhuangxiang chaixiang(heap, stack)
       //2 type secrity
       // 
       public static void ShowObject(object oParam) 
       {
           Console.WriteLine("This is {0}, parameter={1},type={2}",typeof(CommonMethod).Name, oParam.GetType().Name,oParam);
       }

       public static void Show<T>(T tParam) // , T t = default(T)
       {
            Console.WriteLine("This is {0}, parameter={1},type={2}",typeof(CommonMethod).Name, tParam.GetType().Name,tParam);
       }
    }
}