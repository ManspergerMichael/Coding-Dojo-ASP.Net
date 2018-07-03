using System.Collections.Generic;
namespace DeckOfCards{
    class Player{
        public string name;
        public List<Card> hand = new List<Card>();

        public Player(string name){
            this.name = name;
        }

        public void draw(Deck deck){
            this.hand.Add(deck.deal());
        }

        public Card discard(int idx){
            if(hand[idx] != null){
                Card discard = hand[idx];
                this.hand.RemoveAt(idx);
                return discard;
            }
            else{
                return null;
            } 
            
        }
    }

    
}