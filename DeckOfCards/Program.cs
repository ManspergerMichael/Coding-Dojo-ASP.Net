using System;

namespace DeckOfCards
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Deck deck = new Deck();
            deck.shuffle();
            deck.display();
        }
    }
}
