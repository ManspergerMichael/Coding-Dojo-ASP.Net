using System;

namespace BasicOneThree
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            object[] arr = {1,3,-5,7,-9,13};
            numToStr(arr);
        }

        public static void printAll(){
            for (int i = 0; i < 256; i++)
            {
                System.Console.WriteLine(i);
            }
        }
        public static void printOdd(){
            for (int i = 0; i < 256; i++)
            {
                if(i % 2 != 0){
                    System.Console.WriteLine(i);
                }
            }
        }

        public static void printSum(){
            int sum = 0;
            for (int i = 0; i < 256; i++)
            {
                sum += i;
                System.Console.WriteLine(i);
                System.Console.WriteLine("Sum: "+sum);
            }
        }
        public static void array(int[] arr){
            for (int i = 0; i < arr.Length; i++)
            {
                System.Console.WriteLine(arr[i]);
            }
        }

        public static void findMax(int[] arr){
            int max = arr[0];
            for (int i = 0; i < arr.Length; i++)
            {
                if(max < arr[i]){
                    max = arr[i];
                }
            }
            System.Console.WriteLine(max);
        }

        public static void Avg(int[] arr){
            int sum = 0;
            int avg = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                sum += arr[i];
            }
            avg = sum / arr.Length;
            System.Console.WriteLine(avg);
        }

        public static void createArr(){
            int[] Y = new int[130];
            int count = 0;
            for (int i = 0; i < 256; i++)
            {
                if(i % 2 != 0){
                    Y[count] = i;
                    count ++;
                }
            }
            foreach (int item in Y)
            {
                System.Console.WriteLine(item);
            }
        }
        public static int greaterThanY(int[] arr, int Y){
            int count = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if(arr[i] > Y){
                    count ++;
                }
            }
            return count;
        }

        public static void square(int[] arr){
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = arr[i] * arr[i];
            }
        }

        public static void negitive(int[] arr){
            for (int i = 0; i < arr.Length; i++)
            {
                if(arr[i] < 0){
                    arr[i] = 0;
                }
            }
        }

        public static void MinMaxAvg(int[] arr){
            int max = arr[0];
            int min = arr[0];
            int sum = 0;
            double avg = 0.0;

            for (int i = 0; i < arr.Length; i++)
            {
                sum += arr[i];
                if(max < arr[i]){
                    max = arr[i];
                }
                if(min > arr[i]){
                     min = arr[i];
                }
            }
            avg = sum / arr.Length;
            System.Console.WriteLine("Min: "+min+" Max: "+max+" Avg: "+avg);
        }

        public static void shift(int[] arr){
            for (int i = 0; i < arr.Length; i++)
            {
                if(i == arr.Length-1){
                    arr[i]=0;
                    break;
                }
                else{
                    arr[i] = arr[i+1];
                }
            }
            for (int i = 0; i < arr.Length; i++)
            {
                System.Console.WriteLine(arr[i]);
            }
        }

        public static object[] numToStr(object[] arr){
            for (int i = 0; i < arr.Length; i++)
            {
                if((int)arr[i] < 0){
                    arr[i] = "Dojo";
                }
            }
            for (int i = 0; i < arr.Length; i++){
                System.Console.WriteLine(arr[i]);
            }
            return arr;
        }

    }
}
