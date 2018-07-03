using System;
using System.Collections.Generic;

namespace boxing
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            List<object> box = new List<object>();
            box.Add(7);
            box.Add(28);
            box.Add(-1);
            box.Add(true);
            box.Add("chair");

            foreach (var item in box)
            {
                System.Console.WriteLine(item);
            }
            System.Console.WriteLine("Sum of ints");
            int sum = 0;
            foreach (var item in box)
            {
                if(item is int){
                    int value = (int)item;
                    sum = sum + value;
                
                }
            }
            System.Console.WriteLine(sum);

        }
    }
}
