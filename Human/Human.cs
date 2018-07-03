namespace Human{
   class Human{
       public string name;
       public int strength {get;set;} //creates accessor and setter methods
       public int intelligence {get;set;}
       public int dexterity {get;set;}
       public int health {get;set;}

       public Human(string name){
           this.name = name;
           strength = 3;
           intelligence = 3;
           dexterity = 3;
           health = 100;
       }
       public Human(string name, int strength, int intelligence, int dexterity, int health){
           this.name = name;
           this.strength = strength;
           this.intelligence = intelligence;
           this.dexterity = dexterity;
           this.health = health;
       }

       public void attack(object guy){
            int damage = this.strength * 5;
            
            Human enemy = guy as Human;
            if(enemy == null){
                System.Console.WriteLine("Failed Attack");
            }
            else{
                enemy.health = enemy.health - damage;
            }
       }
   }
}