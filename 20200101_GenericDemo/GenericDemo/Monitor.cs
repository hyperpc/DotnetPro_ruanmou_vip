using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericDemo
{
    public class Monitor
    {
        public static void Show()
        {
            int iVal=12345;
            long commonSecond=0;
            long objectSecond=0;
            long genericSecond=0;
            
            {
                Stopwatch watch=new Stopwatch();
                watch.Start();
                for(int i=0;i<100_000_100;i++)
                {
                    ShowInt(iVal);
                }
                watch.Stop();
                commonSecond=watch.ElapsedMilliseconds;
            }
            {
                Stopwatch watch=new Stopwatch();
                watch.Start();
                for(int i=0;i<100_000_100;i++)
                {
                    ShowInt(iVal);
                }
                watch.Stop();
                objectSecond=watch.ElapsedMilliseconds;
            }
            {
                Stopwatch watch=new Stopwatch();
                watch.Start();
                for(int i=0;i<100_000_100;i++)
                {
                    ShowInt(iVal);
                }
                watch.Stop();
                genericSecond=watch.ElapsedMilliseconds;
            }

            System.Console.WriteLine("commonSecond={0},objectSecond={1},genericSecond={2}",commonSecond,objectSecond,genericSecond);
        }

        private static void ShowInt(int iParam)
        {
            // do nothing
        }
        private static void ShowObject(object oParam)
        {
            // do nothing
        }
        private static void Show<T>(T tParam)
        {
            // do nothing
        }
    }
}