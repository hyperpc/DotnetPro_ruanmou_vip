using System;

namespace Framework
{
    public static class ConsoleExtend
    {
        public static void Show<T>(this T t)
        {
            Type type = typeof(T);
            System.Console.WriteLine("**********type.Name--Show--Start**********");
            foreach(var prop in type.GetProperties())
            {
                System.Console.WriteLine($"{type.Name}.{prop.Name}={prop.GetValue(t)}");
            }
            System.Console.WriteLine("**********type.Name--Show--End**********");
        }
    }
}
