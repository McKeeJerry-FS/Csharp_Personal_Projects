using System;

// Application built along with a demo from YouTube called
// "Building C# Application in 60 Minutes" from Traversy Media

// Namespace
namespace NumberGuesser
{
    // Main Class
    class Program
    {
        // Entry Point Method
        public static void Main(string[] args)
        {
            GetAppInfo();
            
            GreetUser();

            while (true)
            {


                // Init correct number
                // Create Random Object
                Random rnd = new Random();
                int correctNumber = rnd.Next(1, 10);

                // Init guess var
                int guess = 0;

                // Ask user for number
                Console.WriteLine("Guess a number between 1 and 10");

                // Loop for guess
                while (guess != correctNumber)
                {
                    //get user's input
                    string input = Console.ReadLine();

                    // Make sure it is a number
                    if (!int.TryParse(input, out guess))
                    {
                        PrintColorMessage(ConsoleColor.DarkRed, "Please only type in numbers.");
                        continue;
                    }

                    // Cast to int and put in guess var.
                    guess = Int32.Parse(input);


                    // Match guess to correct number
                    if (guess != correctNumber)
                    {
                        // Print Error Message
                        PrintColorMessage(ConsoleColor.DarkRed, "Incorrect Guess. Please try again!");
                    }
                }

                // Output success message
                PrintColorMessage(ConsoleColor.Yellow, "CORRECT!!!");

                // Ask user to play again
                Console.WriteLine("Play Again? [Y/N]");

                // Get an answer
                string answer = Console.ReadLine().ToUpper();
                if (answer == "Y")
                {
                    continue;
                }
                else if (answer == "N")
                {
                    return; 
                }
                else
                {
                    return;
                }

            }
        }

        // Get and Display App Info
        static void GetAppInfo()
        {
            // set app vars
            string appName = "Number Guesser";
            string appVersion = "1.0.0";
            string appAuthor = "Jerry McKee Jr.";

            PrintColorMessage(ConsoleColor.DarkGreen, $"{appName}: Version {appVersion} by {appAuthor}");
        }

        // Ask User's name and Greet
        static void GreetUser()
        {
            // Ask user's name
            Console.WriteLine("What is your name?");

            // Get user's info
            string userName = Console.ReadLine();
            Console.WriteLine($"Hello {userName}. Let's play a game!");
        }

        // Print message to console in color
        static void PrintColorMessage(ConsoleColor color, string message)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}