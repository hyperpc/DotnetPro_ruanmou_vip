using System;

namespace GenericDemo
{
    public class GenericTest
    {
        public void Show<T>(T tParam)
        {

        }

        // 泛型参数尽量不要和class重名，它只是占位符，不要引起混淆
        public T Get<T, S, Model, Eleven, Null>(Model model)
        {
            throw new Exception();
        }
    }

    public class ChildCalss : GenericClass<int>, IGenericInterface<string>
    {}
    public class GenericChildCalss<T, Eleven> : GenericClass<T>, IGenericInterface<Eleven>
    {}

    public class GenericClass<T>
    {

    } 
    public interface IGenericInterface<S>
    {

    }

    public delegate void Do<T>();
}