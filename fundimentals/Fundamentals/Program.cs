using System;

namespace Fundamentals
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
            /*for (int i = 1; i < 256; i++)
            {
                Console.WriteLine(i);
            }*/

            for(int i = 0; i < 11; i++){
                int num = rand.Next(1,100);
                //Console.WriteLine(num);
                if(num % 3 == 0 && num % 5 == 0){
                    Console.WriteLine("FizzBuzz");
                }
                else if(num % 5 == 0){
                    Console.WriteLine("Buzz");
                }
                else if(num % 3 == 0){
                    Console.WriteLine("Fizz");
                }
            }
        }
    }
}
