using System;
using PL;
namespace Pos_Terminal
{
    public class Program
    {
        public static void Main(String[] args)
        {
            Console.ForegroundColor= ConsoleColor.Blue;
            DateTime date = DateTime.Now;
            Console.WriteLine(format:"{0, -50} {1, 50}", arg0:$"Current DateTime : {date}", arg1: $"Welcome {Environment.UserName}");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("---------------------------------------------------------------------------");
            Console.WriteLine("|                                                                         |");
            Console.WriteLine("|                            POS_TERMINAL                                 |");
            Console.WriteLine("|                                                                         |");
            Console.WriteLine("---------------------------------------------------------------------------");
            Console.Write("\n\n\n                       Press Any Key to Start");
            Console.ReadKey();
            Console.Clear();
            while (true)
            {
                MainMenu.Menu();
            }
        }
    }
}