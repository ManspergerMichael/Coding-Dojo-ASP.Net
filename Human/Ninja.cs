namespace Human {
    class Ninja : Human{
        public Ninja(string name) : base(name){
            this.dexterity = 175;
        }

        public void steal(Human enemy){
            enemy.health = enemy.health - 10;
            this.health = this.health + 10;
        }

        public void get_away(){
            this.health = this.health - 15;
        }
    }
}