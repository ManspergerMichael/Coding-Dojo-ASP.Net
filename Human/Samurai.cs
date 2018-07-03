namespace Human{
    class Samurai : Human{
        public Samurai(string name) : base(name){
            this.health = 200;
        }

        public void death_blow(Human enemy){
            if(enemy.health < 50){
                enemy.health = enemy.health = 0;
            }
        }

        public void meditate(){
            this.health = 200;
        }
    }
}