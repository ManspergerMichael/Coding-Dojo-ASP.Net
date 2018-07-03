using System;

namespace puzzles
{
    class Program
    {
        static void Main(string[] args)
        {
            /*int[] arr = RandomArray();
            for (int i = 0; i < arr.Length; i++)
            {
                System.Console.WriteLine(arr[i]);
            }*/
            string[] result = Names();
            foreach (string item in result)
            {
                System.Console.WriteLine(item);
            }
            
        }

        public static int[] RandomArray(){
            Random rand = new Random();
            int[] arr = new int[10];
            for (int i = 0; i < 10; i++)
            {
                arr[i] = rand.Next(5,25);
            }

            int max = arr[0];
            int min = arr[0];
            int sum = 0;
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
            System.Console.WriteLine("min: "+min+" max: "+max+" sum: "+sum);
            return arr;
        }

        public static string TossCoin(){
            Random rand = new Random();
            System.Console.WriteLine("Tossing a Coin!");
            int toss = rand.Next(1,3);
            string result = "";
            if(toss == 1){
                result = "Heads";
            }
            else if(toss == 2){
                result = "Tails";
            }
            return result;
        }

        public static Double TossMultipleCoins(int num){
            int heads = 0;
            int tails = 0;
            int total = 0;
            double ratio = 0.0;
            string result = "";
            for (int i = 0; i < num; i++)
            {
                result = TossCoin();
                if(result == "Heads"){
                    heads++;
                }
                if(result == "Tails"){
                    tails++;
                }
                total ++;
            }
            return ratio = (double)heads / (double)total;
        }

        public static string[] Names(){
            Random rand = new Random();
            string[] longNames = new string[5];
            string[] names = {"Todd", "Tiffany", "Charlie", "Geneva", "Sydney"};
            for(int i = 0; i < names.Length; i++){
                string temp = names[i];
                int r = rand.Next(i, names.Length);
                names[i] = names[r];
                names[r] = temp;
            }
            for(int i = 0; i < longNames.Length; i++){
                if(names[i].Length < 5){
                    continue;
                }
                else{
                    longNames[i] = names[i];
                }
            }
            return longNames;
        }
    }
}
