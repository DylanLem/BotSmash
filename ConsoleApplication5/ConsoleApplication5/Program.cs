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
                Console.WriteLine(bot1.DisplayInfo("name") + " vs. " + bot2.DisplayInfo("name") + "!");
                Console.WriteLine("\n" + bot1.DisplayInfo("name") + ": " + "HEALTH " + bot1.DisplayInfo("health") + " / ATTACK " + bot1.DisplayInfo("strength"));
                Console.WriteLine(bot2.DisplayInfo("name") + ": " + "HEALTH " + bot2.DisplayInfo("health") + " / ATTACK " + bot2.DisplayInfo("strength") + "\n");
                Console.ReadKey(true);
                Console.WriteLine("(W)atch battle, or (S)kip to results?");
                bot1.Battle(bot1, bot2, Convert.ToString(Console.ReadKey(true).KeyChar));
                break;
            }

            Console.ReadKey();
        }
    }
}
