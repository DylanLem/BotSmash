﻿using System;
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
        public Bot()
        {
            this.name = GetName();
            this.health = GetHealth();
            this.strength = GetStrength();
        }

        private string GetName()
        {
             

            string[] firstName = new string[6] {"Skullcrusher","John","Wackbot","Hammerteeth","Metalscythe","Megasmash"};
            string[] secondName = new string[6] { "McGee", "Smasherson","Wheelsmith","Anvilwright","Cogsworth","the Wicked"};
            
            return (firstName[random.Next(0, 6)] + " " + secondName[random.Next(0,6)]);
        }

        private int GetHealth()
        {
            return random.Next(1,101) + 10;
        }
        private int GetStrength()
        {
            return random.Next(1, 31) + 5;
        }

        public string DisplayInfo(string parameter)
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
                    Console.WriteLine("\n" + bot1.DisplayInfo("name") + ": " + bot1.DisplayInfo("health") + " health");
                    Console.WriteLine(bot2.DisplayInfo("name") + ": " + bot2.DisplayInfo("health") + " health");
                    System.Threading.Thread.Sleep(250);
                }
            }
            Console.WriteLine("\n");
            if (bot1.health == 0) Console.WriteLine(bot2.DisplayInfo("name") + " wins!");
            else if (bot2.health == 0) Console.WriteLine(bot1.DisplayInfo("name") + " wins!");
            else Console.WriteLine("They killed eachother!");


        }

    }
}