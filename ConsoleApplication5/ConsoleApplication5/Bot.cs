using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication5
{
    class Bot
    {
        private string name;
        private int health, maxHealth;
        private int strength;
        static Random random = new Random();
        static List<string> blacklist = new List<string>(2) {"",""};
        
        string[] firstNameArray = new string[] { "Skullcrusher", "John", "Wackbot", "Hammerteeth", "Metalscythe", "Megasmash", "Robro","Twisted Metal","Death-Metal","Humanbot","Rusty"};
        string[] secondNameArray = new string[] { "McGee", "Smasherson", "Wheelsmith", "Anvilwright", "Cogsworth", "the Wicked","the Metallic",};
        public Bot()
        {
            
            this.name = SetName();
            this.maxHealth = SetMaxHealth();
            this.health = maxHealth;
            this.strength = SetStrength();
        }

        private string SetName()
        {
            
            string firstName = firstNameArray[random.Next(0, firstNameArray.Length-1)];
            string secondName = secondNameArray[random.Next(0, secondNameArray.Length - 1)];
            

            if (firstName == blacklist.ElementAt(0) | secondName == blacklist.ElementAt(1)) 
            {             
                return SetName();           
            }

            blacklist.Insert(0, firstName);
            blacklist.Insert(1, secondName);    

            return (firstName + " " + secondName);
        }

        private int SetMaxHealth()
        {
            return random.Next(1,101) + 10;
        }
        private int SetStrength()
        {
            return random.Next(1, 31) + 5;
        }

        public string GetInfo(string parameter)
        {
            switch (parameter)
            {
                case "name":
                    return (this.name);
                case "health":
                    return (Convert.ToString(this.health));
                case "strength":
                    return (Convert.ToString(this.strength));
                default:
                    return null;
            }
       }

       private int MakeAttack(int strength)
        {
           
            return Convert.ToInt16((random.NextDouble() + .2 * strength));            
        }

       public int Battle(Bot bot1, Bot bot2, string decide)
        {
            //Returns 1 if bot1 wins, 2 if bot2 wins, 3 if they both die.
            while(bot1.health > 0 && bot2.health > 0)
            {                    
                bot1.health -= bot2.MakeAttack(bot2.strength);
                bot2.health -= bot1.MakeAttack(bot1.strength);
                if (bot1.health < 0) bot1.health = 0;
                if (bot2.health < 0) bot2.health = 0;
                
                if (decide.ToUpper() == "W")
                {
                    Console.WriteLine("\n" + bot1.GetInfo("name") + ": " + bot1.GetInfo("health") + " health");
                    Console.WriteLine(bot2.GetInfo("name") + ": " + bot2.GetInfo("health") + " health");
                    System.Threading.Thread.Sleep(250);
                }
            }
            Console.WriteLine("\n");
            if (bot1.health == 0)
            {
                //bot2 wins
                Console.WriteLine(bot2.GetInfo("name") + " wins!");
                regenerate(bot2);
                return 2;
            }
            else if (bot2.health == 0)
            {
                //bot1 wins
                Console.WriteLine(bot1.GetInfo("name") + " wins!");
                regenerate(bot1);
                return 1;
            }
            else
            {
                Console.WriteLine("They killed eachother!");
                return 3;
            }

        }

        private void regenerate(Bot bot)
        {
            bot.health = bot.maxHealth;
        }

    }
}
