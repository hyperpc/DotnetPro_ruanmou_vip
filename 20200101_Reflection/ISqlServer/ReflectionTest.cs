using System.Runtime.CompilerServices;
namespace ReflectionDemo.ISqlServer
{
    public class ReflectionTest
    {
        #region Identity
        public ReflectionTest()
        {
            System.Console.WriteLine("This is {0} constructor without parameter", this.GetType());
        }
        
        public ReflectionTest(string name)
        {
            System.Console.WriteLine("This is {0} constructor with parameter {1}", this.GetType(), name);
        }

        public ReflectionTest(int id)
        {
            System.Console.WriteLine("This is {0} constructor with parameter {1}", this.GetType(), id);
        }
        #endregion

        #region Method
        public void Show1()
        {
            System.Console.WriteLine("This is {0}'s Show1", this.GetType());
        }
        public void Show2(int id)
        {
            System.Console.WriteLine("This is {0}'s Show2 with parameter {1}", this.GetType(), id);
        }

        public void Show3()
        {
            System.Console.WriteLine("This is {0}'s Show3_0", this.GetType());
        }
        public void Show3(int id)
        {
            System.Console.WriteLine("This is {0}'s Show3_1 with parameter {1}", this.GetType(), id);
        }
        public void Show3(string name)
        {
            System.Console.WriteLine("This is {0}'s Show3_2 with parameter {1}", this.GetType(), name);
        }
        public void Show3(int id, string name)
        {
            System.Console.WriteLine("This is {0}'s Show3_3with parameter {1}, {2}", this.GetType(), id, name);
        }
        public void Show3(string name, int id)
        {
            System.Console.WriteLine("This is {0}'s Show3_4 with parameter {1}, {2}", this.GetType(), name, id);
        }

        private void Show4(string name)
        {
            System.Console.WriteLine("This is {0}'s Show4, private, with parameter {1}", this.GetType(), name);
        }

        public static void Show5(string name)
        {
            System.Console.WriteLine("This is {0}'s Show5, static, with parameter {1}", typeof(ReflectionTest), name);
        }
        #endregion
    }
}