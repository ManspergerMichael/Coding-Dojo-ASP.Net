using System;
using System.Collections.Generic;

namespace Collections
{
    class Program
    {
        static void Main(string[] args)
        {
            //Arrays
           int[] nums = {0,1,2,3,4,5,6,7,8,9};
           string[] names = {"Tim","Martin","Nikki","Sara"};
           bool[] binary = {true,false,true,false,true,false,true,false,true,false};
           /*foreach (bool item in binary)
           {
               Console.WriteLine(item);
           }*/

           //Lists
            List<string> flavors = new List<string>();
            flavors.Add("Rocky Road");
            flavors.Add("Mint Chip");
            flavors.Add("Nepolatan");
            flavors.Add("Burbon");
            flavors.Add("Another one");

            Console.WriteLine(flavors.Count);
            Console.WriteLine(flavors[2]);
            flavors.RemoveAt(2);
            Console.WriteLine(flavors.Count);

            Dictionary<string,string> dict = new Dictionary<string,string>();
            int count = 0;
            foreach(string name in names){
                if(count > flavors.Count){
                    break;
                }
                dict.Add(name, flavors[count]);
                count ++;
            }
            //The var keyword takes the place of a type in type-inference
            foreach (var entry in dict)
            {
            Console.WriteLine(entry.Key + " - " + entry.Value);
            }

        }
    }
}
