using System;

namespace Human
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Wizard wiz = new Wizard("Tim");
            System.Console.WriteLine(wiz.name);
            Samurai mus = new Samurai("Jin");
            mus.attack(wiz);
            mus.death_blow(wiz);
            System.Console.WriteLine(wiz.health);
        }
    }
}
