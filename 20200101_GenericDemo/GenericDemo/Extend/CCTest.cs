using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GenericDemo.Extend
{

    /// <summary>
    /// 跟泛型相关，专门用于接口和委托
    /// covariant : 协变
    /// Contravariant : 逆变
    /// 让泛型更方便使用
    /// </summary>
    public class CCTest
    {
        public static void Show()
        {
            //Func<int, string>
            {
                Bird bird1 = new Bird();
                Bird bird2 = new Sparrow();
                Sparrow sparrow = new Sparrow();
                //Sparrow sparrow2=new Bird();
            }

            {
                List<Bird> birdList1 = new List<Bird>();

                //List<Bird> 和 List<Sparrow>没有继承关系
                //List<Bird> birdList2 = new List<Sparrow>();
                List<Bird> birdList3 = new List<Sparrow>().Select(c=>(Bird)c).ToList();
            }

            {
                //covariant: the right side can be child class, make generic easy to use
                IEnumerable<Bird> birdList1 = new List<Bird>();
                IEnumerable<Bird> birdList2 = new List<Sparrow>();

                Func<Bird> func = new Func<Sparrow>(()=>null);
                //out修饰，协变后，T只能作为返回值，不能当参数
                ICustormerListOut<Bird> custmList1 = new CustormerListOut<Bird>();
                ICustormerListOut<Bird> custmList2 = new CustormerListOut<Sparrow>();
                custmList2.Get();
            }

            {
                //Contravariant: the right side can be parent class, make generic easy to use
                ICustormerListIn<Sparrow> custmList1 = new CustomerListIn<Sparrow>();
                ICustormerListIn<Sparrow> custmList2 = new CustomerListIn<Bird>();
                custmList2.Show(new Sparrow());

                ICustormerListIn<Bird> birdList1=new CustomerListIn<Bird>();
                birdList1.Show(new Bird());
                birdList1.Show(new Sparrow());

                Action<Sparrow> action=new Action<Bird>((Bird i)=>{});
            }

            {
                IMyList<Sparrow, Bird> myList1=new MyList<Sparrow, Bird>();
                IMyList<Sparrow, Bird> myList2=new MyList<Sparrow, Sparrow>();// out - covariant
                IMyList<Sparrow, Bird> myList3=new MyList<Bird, Bird>();// in - Contravariant
                IMyList<Sparrow, Bird> myList4=new MyList<Bird, Sparrow>();// in + out
            }
        }
    }

    public class Bird
    {
        public int Id {get;set;}
    }

    public class Sparrow:Bird
    {
        public string Name{get;set;}
    }

    /// <summary>
    /// in 逆变：
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ICustormerListIn<in T>
    {
        //T Get();
        void Show(T t);
    }

    public class CustomerListIn<T>:ICustormerListIn<T>
    {
        //public T Get()
        //{
        //    return default(T);
        //}

        public void Show(T t)
        {}
    }
    
    /// <summary>
    /// out 协变， T只能做返回结果，不能做参数
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ICustormerListOut<out T>
    {
        T Get();
        //void Show(T t);
    }
    
    public class CustormerListOut<T>:ICustormerListOut<T>
    {
        public T Get()
        {
            return default(T);
        }

        //public void Show(T t)
        //{
        //}
    }

    public interface IMyList<in inT, out outT>
    {
        void Show(inT t);
        outT Get();
        outT Do(inT t);

        //void Show(outT t);
        //inT Get1();
    }

    public class MyList<T1,T2>:IMyList<T1,T2>
    {
        public void Show(T1 t)
        {
            System.Console.WriteLine(t.GetType().Name);
        }

        public T2 Get()
        {
            System.Console.WriteLine(typeof(T2).Name);
            return default(T2);
        }

        public T2 Do(T1 t)
        {
            System.Console.WriteLine(t.GetType().Name);
            System.Console.WriteLine(typeof(T2).Name);
            return default(T2);
        }
    }


}