using System;

namespace Group
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine(Sigma(5));
        }
        public static int Sigma(int num){
                int sum = 0;
                for(int i = 1; i < num; i++){
                    sum += i;
                }
                return sum;
            }
    }
}
