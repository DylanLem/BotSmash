using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication5
{
    class Program
    {
        static void Main(string[] args)
        {
            Game();
        }

        static void Game()
        {
            Bot bot1 = new Bot();
            Bot bot2 = new Bot();
            while (true)
            {
                Console.WriteLine(bot1.GetInfo("name") + " vs. " + bot2.GetInfo("name") + "!");
                Console.WriteLine("\n" + bot1.GetInfo("name") + ": " + "HEALTH " + bot1.GetInfo("health") + " / ATTACK " + bot1.GetInfo("strength"));
                Console.WriteLine(bot2.GetInfo("name") + ": " + "HEALTH " + bot2.GetInfo("health") + " / ATTACK " + bot2.GetInfo("strength") + "\n");
                Console.ReadKey(true);
                Console.WriteLine("(W)atch battle, or (S)kip to results?");
                int answer = bot1.Battle(bot1, bot2, Convert.ToString(Console.ReadKey(true).KeyChar));
                Console.ReadKey();
                switch(answer)
                {
                    //This rebuilds a new bot from the losing bots parts
                    case 1:
                        bot2 = new Bot();
                        break;
                    case 2:
                        bot1 = new Bot();
                        break;
                    case 3:
                        bot1 = new Bot();
                        bot2 = new Bot();
                        break;                    
                }

               // Console.WriteLine("\n Play again? (Y)");
                // if (Convert.ToString(Console.ReadKey(true)).ToUpper() != "Y") {
                //     break;
                //  }               
                Console.Clear();
            }


        }
    }
}
