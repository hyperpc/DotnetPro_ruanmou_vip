using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GenericDemo
{
    public interface ISports
    {
        void Pingpang();
    }

    public interface IWork
    {
        void Work();
    }

    public class People
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public void Hi() { }
    }

    public class Chinese : People, ISports, IWork
    {
        public void Tradition()
        {
            System.Console.WriteLine("仁义礼智信，温良恭俭让");
        }

        public void SayHi()
        {
            System.Console.WriteLine("吃了么？");
        }

        public void Pingpang()
        {
            System.Console.WriteLine("打乒乓球...");
        }

        public void Work()
        {
            //System.Console.WriteLine();
            throw new NotImplementedException();
        }
    }

    public class HuBei : Chinese
    {
        public string ChangJiang { get; set; }
        public void MaJiang()
        {
            System.Console.WriteLine("打麻将啦...");
        }
    }

    public class Japanese : ISports
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public void Pingpang()
        {
            System.Console.WriteLine("打乒乓球...");
        }
    }
}