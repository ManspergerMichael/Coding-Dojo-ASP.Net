using System;
using System.Collections.Generic;

namespace DeckOfCards{
    class Deck{
        List<Card> cards = new List<Card>();

        public Deck(){
            this.cards = create();
        }
        public List<Card> create(){
            List<Card> deck = new List<Card>();
            string[] suits = {"Hearts", "Diamonds", "Clubs","Spades"};
            foreach (string suit in suits)
            {
                for(int i = 1; i < 14; i ++){
                    Card newCard = new Card(suit, i);
                    deck.Add(newCard);
                }
                
            }
            return deck;
        }
        public Card deal(){
            Card deal = cards[0];
            this.cards.RemoveAt(0);
            return deal;
        }
        public void reset(){
            this.cards = create();
        }

        public void shuffle(){
            Random rand = new Random();
            for (int i = 0; i < cards.Count; i++)
            {
                int card = rand.Next(0,52);
                Card temp = this.cards[card];
                this.cards[card] = this.cards[i];
                this.cards[i] = temp;
            }
        }

        public void display(){
            foreach (Card card in cards)
            {
                System.Console.WriteLine(card.stringVal);
            }
        }
    }

    
}