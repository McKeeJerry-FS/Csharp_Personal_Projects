using System;
using System.Collections.Generic;

/*
 * Jerry McKee Jr
 * 02/07/2021
 * APD
 * HighLow - In this game a user will choose a maximum number to guess 
 * from. The lower number of guesses, the higher the points. The more 
 * difficult the game, the higher the points.
 */


namespace Game
{
    class Program
    {
        static void Main(string[] args)
        {
            bool play = true;
            while (play)
            {
                Console.Clear();
                // instantiate
                HighLow.Play();
                // Play Again
                play = PlayAgain();
            }
            // end while(play)
            

            
            // Create an exit message
            Console.WriteLine("\r\n===============================");
            Console.WriteLine(" OK! This was fun!");
            Console.WriteLine(" Can't wait to play again!\r\n");
            Console.WriteLine(" Have a great day!!");
            Console.WriteLine("===============================\r\n");
        }
        // end Main()

            
        // Allow the usser to play again
        private static bool PlayAgain()
        {
            Console.WriteLine("\r\n======================================");
            Console.Write("Would you like to play again? [Y/N]");
            Console.WriteLine("\r\n======================================");
            string response = Console.ReadLine().ToUpper();
            return (response == "Y") ? true : false;
        }
        // end PlayAgain()

    }
    // end class
            
} 
// end namespace



