using System;

// Name: McKee, Jerry
// Date: 02/03/2021
// Course: APD
// Synopsis: Game development code excercise, TicTacToe

namespace Game
{
    class Program
    {

        // Application entry point
        static void Main(string[] args)
        {
            bool play = true;
            while (play)
            {
                //instantiate
                TicTacToe.Play();

                //Play Againg
                play = PlayAgain();
            }

            //Create an exit message
            Console.WriteLine("OK! This was fun");
            Console.WriteLine("Can't wait to play again!");
            Console.WriteLine("Have a great day!!");
        }
        //Allow the user to play again
        private static bool PlayAgain()
        {
            Console.WriteLine("---------------------");
            Console.Write("Would you like to play again? [Y/N]");

            string response = Console.ReadLine().ToUpper();
            return (response == "Y") ? true : false;
        }



    // End class
    }
}
