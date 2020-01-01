using System;
using GenericDemo.Extend;

namespace GenericDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            try
            {
                int iVal = 123;
                string sVal = "s686";
                DateTime dtVal = DateTime.Now;
                object oVal = "kar98k";
                {
                    System.Console.WriteLine("********************Common*******************");
                    CommonMethod.ShowInt(iVal);
                    CommonMethod.ShowString(sVal);
                    CommonMethod.ShowDatetime(dtVal);
                }
                {
                    System.Console.WriteLine("********************Object*******************");
                    CommonMethod.ShowObject(iVal);
                    CommonMethod.ShowObject(sVal);
                    CommonMethod.ShowObject(dtVal);
                    CommonMethod.ShowObject(oVal);
                }
                {
                    System.Console.WriteLine("********************Generic*******************");
                    CommonMethod.Show(iVal);
                    CommonMethod.Show(sVal);
                    CommonMethod.Show(dtVal);
                    CommonMethod.Show(oVal);
                }
                {
                    System.Console.WriteLine("********************Monitor*******************");
                    Monitor.Show();
                }
                {
                    System.Console.WriteLine("********************GenericCache*******************");
                    GenericCacheTest.Show();
                }
                {
                    People people = new People
                    {
                        Id=123,
                        Name="Jon"
                    };
                    Chinese chinese = new Chinese
                    {
                        Id=234,
                        Name="八戒，你瘦了"
                    };
                    HuBei huBei=new HuBei
                    {
                        Id=345,
                        Name="木头"
                    };
                    Japanese japanese = new Japanese
                    {
                        Id=456,
                        Name="苍老师"
                    };
                    //GenericConstraint.ShowObject(people);
                    //GenericConstraint.ShowObject(chinese);
                    //GenericConstraint.ShowObject(huBei);
                    //GenericConstraint.ShowObject(japanese);

                    //GenericConstraint.ShowObject(iVal);
                    //GenericConstraint.ShowObject(sVal);
                    //GenericConstraint.ShowObject(dtVal);
                    //GenericConstraint.ShowObject(oVal);

                    GenericConstraint.Show<People>(people);
                    GenericConstraint.Show(chinese);
                    GenericConstraint.Show(huBei);
                    //GenericConstraint.Show(japanese);
                    //GenericConstraint.Show<int>(iVal);
                    
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }

            System.Console.ReadKey();
        }
    }
}
