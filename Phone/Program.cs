using System;

namespace Phone
{
    class Program
    {
        static void Main(string[] args)
        {
            Nokia eleven = new Nokia("1100",60,"Metro PCS", "Ringgg ring ringgg");
            Galaxy s8 = new Galaxy("s8",100,"Metro PCS","Dooo do doo dooo");
            eleven.DisplayInfo();
            System.Console.WriteLine(eleven.Ring());
            System.Console.WriteLine(eleven.Unlock());
            s8.DisplayInfo();
            System.Console.WriteLine(s8.Ring());
            System.Console.WriteLine(s8.Unlock());
            
        }
    }
}
