using System;

namespace GenericDemo
{
    // 5 type generic constraint
    // class, 
    // interface, 
    // reference type constraint,
    // value type constraint,
    // none parameter constructor
    // (type parameter)
    public class GenericConstraint
    {
        public static void ShowObject(object oParam)
        {
            Console.WriteLine("This is {0}, parameter={1},type={2}", typeof(CommonMethod).Name, oParam.GetType().Name, oParam);

            // oParam have to be child class of people, so Japanese will cause exception
            //People people = (People)oParam;
            //System.Console.WriteLine($"{people.Id}, {people.Name}");
        }

        public static void Show<T>(T tParam)
        where T : People
            //where T : ISports
        {
            System.Console.WriteLine("This is {0}, parameter={1}, type={2}",
            typeof(GenericConstraint), tParam.GetType().Name, tParam);

            System.Console.WriteLine($"{tParam.Id} {tParam.Name}");
            tParam.Hi();

            //tParam.PingPang();
        }

        public static void ShowTS<T, S>(T tParam, S sParam)
        where T : People
        where S : T // type parameter constraint
        {

        }

        public void ShowPeople(People people)
        {
            System.Console.WriteLine($"{people.Id} {people.Name}");
            people.Hi();
        }

        public T GetT<T, S>()
        //where T : string // wrong, sealed type not illeagle
        //where T : class//reference type constraint
        where T : struct // value type constraint
        where S : new() // none parameter constructor
        {
            //throw new Exception();
            //return null;   
            return default(T);// default: key world, will return default vaule baded on T
            //return new T();
        }
    }
}