
namespace ReflectionDemo.ISqlServer
{
    /// <summary>
    /// promise that only one class is alive in one process
    /// </summary>
    public class Singleton
    {
        private static Singleton _Singleton=null;
        private Singleton()
        {
            System.Console.WriteLine("Singleton is constructed.");
        }

        static Singleton()
        {
            if(_Singleton==null)
            {
                _Singleton = new Singleton();
            }
        }

        public static Singleton GetInstance()
        {
            return _Singleton;
        }
    }
}