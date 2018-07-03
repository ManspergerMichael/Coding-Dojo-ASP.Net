using System;
namespace Human{
    class Wizard : Human{

        public Wizard(string name) : base(name){
            this.health = 50;
            this.intelligence = 25;
        }
        public void heal(){
            this.health += this.intelligence * 10;
        }
        public void fireball(Human enemy){
            Random rand = new Random();
            int damage = rand.Next(20,51);
            enemy.health = health - damage;
        }
    }
}