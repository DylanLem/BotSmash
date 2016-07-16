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
        private int health;
        private int strength;
        static Random random = new Random();
        static List<string> blacklist = new List<string>(2) {"",""};
        
        string[] firstNameArray = new string[] { "Skullcrusher", "John", "Wackbot", "Hammerteeth", "Metalscythe", "Megasmash", "Robro","Twisted Metal","Death-Metal","Humanbot",};
        string[] secondNameArray = new string[] { "McGee", "Smasherson", "Wheelsmith", "Anvilwright", "Cogsworth", "the Wicked",};
        public Bot()
        {
            
            this.name = SetName();
            this.health = SetHealth();
            this.strength = SetStrength();
        }

        private string SetName()
        {
            //FIX THIS SHIT YOU SHITTY PERSON
            
            string firstName = firstNameArray[random.Next(0, firstNameArray.Length-1)];
            string secondName = secondNameArray[random.Next(0, secondNameArray.Length - 1)];
            

            if (firstName == blacklist.ElementAt(0) | secondName == blacklist.ElementAt(1)) 
            {
                //this is dum i think, but mayb good recursion? :)?
                name = SetName();
                return name;               
            }

            blacklist.Insert(0, firstName);
            blacklist.Insert(1, secondName);    

            return (firstName + " " + secondName);
        }

        private int SetHealth()
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

       public void Battle(Bot bot1, Bot bot2, string decide)
        {
            
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
            if (bot1.health == 0) Console.WriteLine(bot2.GetInfo("name") + " wins!");
            else if (bot2.health == 0) Console.WriteLine(bot1.GetInfo("name") + " wins!");
            else Console.WriteLine("They killed eachother!");


        }

    }
}
