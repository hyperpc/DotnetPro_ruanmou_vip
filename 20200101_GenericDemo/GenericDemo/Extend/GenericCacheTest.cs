using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GenericDemo.Extend
{
    //generic cache is hundreds times faster than dictionary cache
    public class GenericCacheTest
    {
        public static void Show()
        {
            for(int i=0;i<5;i++)
            {
                System.Console.WriteLine(GenericCache<int>.GetCache());
                Thread.Sleep(10);
                System.Console.WriteLine(GenericCache<long>.GetCache());
                Thread.Sleep(10);
                System.Console.WriteLine(GenericCache<DateTime>.GetCache());
                Thread.Sleep(10);
                System.Console.WriteLine(GenericCache<string>.GetCache());
                Thread.Sleep(10);
                System.Console.WriteLine(GenericCache<GenericCacheTest>.GetCache());
                Thread.Sleep(10);
            }
        }
    }

    public class DictionaryCache
    {
        private static Dictionary<Type, string> _TypeTimeDict=null;
        static DictionaryCache()
        {
            System.Console.WriteLine("This is DictionaryCache static constructure");
            _TypeTimeDict=new Dictionary<Type, string>();
        }

        public static string GetCache<T>()
        {
            Type type = typeof(Type);
            if(!_TypeTimeDict.ContainsKey(type))
            {
                _TypeTimeDict[type]=string.Format("{0}_{1}",typeof(T).FullName, DateTime.Now.ToString("yyyyMMddHHmmss.ffftt"));
            }
            return _TypeTimeDict[type];
        }
    }

    public class GenericCache<T>
    {
        private static string _TypeTime=null;
        static GenericCache()
        {
            System.Console.WriteLine("This is GenericCache static constructure");
            _TypeTime=string.Format("{0}_{1}",typeof(T).FullName, DateTime.Now.ToString("yyyyMMddHHmmss.ffftt"));
        }
        public static string GetCache()
        {
            return _TypeTime;
        }
    }
}