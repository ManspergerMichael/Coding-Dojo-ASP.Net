namespace DeckOfCards{
    class Card{
        public string stringVal;
        public string suit;
        public int val; 

        public Card(string suit, int val){
            this.suit = suit;
            this.val = val;
            this.stringVal = this.val+" of "+this.suit;
        }
    }
}
