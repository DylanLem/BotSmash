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
                bot1.Battle(bot1, bot2, Convert.ToString(Console.ReadKey(true).KeyChar));
                Console.WriteLine("\n Play again?");

                break;
            }

            Console.ReadKey();
        }
    }
}
