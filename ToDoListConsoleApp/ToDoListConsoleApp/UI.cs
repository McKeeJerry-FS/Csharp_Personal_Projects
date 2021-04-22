using System;

/*
Jerry McKee Jr. 
04/19/2021
Personal App
To Do List Console App
*/

namespace ToDoListConsoleApp
{
    public static class UI
    {
        // Header
        public static void Header(string text)
        {
            Console.WriteLine("=============================================");
            Console.ForegroundColor = ConsoleColor.DarkGreen;

            Console.Write($"{text.ToUpper()}\r\n");
            Console.ResetColor();
            Console.WriteLine("=============================================");
        }
        // end Header()


        // Separator
        public static void Separator()
        {
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("-----------------------");
            Console.ResetColor();
            Console.WriteLine("");
        }
        // end Seperator()

        // This method displays a small animation screen when
        // loading the menu.
        public static void Animation(string text)
        {

            // Creates a Loading animation on the Loading Screen
            Random rnd = new Random();
            for (int i = 0; i < rnd.Next(2, 5); i++)
            {
                Console.Clear();
                // Animation
                Console.Write($" {text} ");
                for (int dots = 0; dots < 7; dots++)
                {
                    Console.Write(".");
                    System.Threading.Thread.Sleep(300);
                }
                // end Loading Animation

            }
            // end Random()

        }
    }
}