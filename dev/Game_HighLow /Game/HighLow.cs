using System;
using System.Collections.Generic;

/*
 * Jerry McKee Jr
 * 02/07/2021
 * APD
 * HighLow - This class will contain all of the working files for the
 * game.
 */

namespace Game
{
    public class HighLow
    {
        public static void Play()
        {
            // Local variables
            string winner = null;
            int guess = 0;
            int currentPoints = 0;

            // Displays the header and instructions for the game
            GameLayout();
            DisplayInstructions();

            // Displays the current points
            Console.WriteLine("\r\n===========================");
            Console.Write($" Current Points: {currentPoints}");
            Console.WriteLine("\r\n===========================\r\n");


            // Ask the user for a number
            Console.WriteLine(" Please enter a Maximum number...");
            string maxNumString = Console.ReadLine();

            // validation and number retrieval
            int maxNumber = MaxNumberValidation(maxNumString);
            int randomNumber = RandomNumber(maxNumber);

            // This loop keeps the game in play until the correct guess is made
            while (winner == null)
            {
                // Ask the user to make a guess
                Console.WriteLine("\r\n==========================");
                Console.Write($" Guess the number chosen!");
                Console.WriteLine("\r\n==========================\r\n");
                string playerGuessString = Console.ReadLine();

                // validate
                int playerGuess = PlayerGuessValidation(playerGuessString);

                // Determining the winning guess
                if (playerGuess < randomNumber)
                {
                    Console.WriteLine($" {playerGuess} is too low... Please try again!");
                }
                else if (playerGuess > randomNumber)
                {
                    Console.WriteLine($" {playerGuess} is too high... Please try again!");
                }
                else if (playerGuess == randomNumber)
                {
                    Console.WriteLine($" {playerGuess} is correct!! You win!!!");
                    winner = playerGuessString;
                    int points = PlayerPoints(maxNumber);
                    // awarding of the points
                    int pointsAwarded = points - (guess * 10);
                    Console.WriteLine($" You win {pointsAwarded} points");
                    points += currentPoints;
                }
                // advances to the next guess if it was incorrect
                guess++;
            }
            // end while() loop for game play 

        }
        // end Play()
                    
                


        // Creating the base layout of the game
        private static void GameLayout()
        {
            // Header
            Console.WriteLine("\r\n=========================================");
            Console.WriteLine("                High/Low                     ");
            Console.WriteLine("=========================================\r\n");
        }
        // end GameLayout()




        // Provide Instructions for the game
        private static void DisplayInstructions()
        {
            Console.WriteLine("");
            Console.WriteLine(" • Choose a number that would be the maximum number that can randomly be chosen.");
            Console.WriteLine(" • Guess the number the was randomly chosen.");
            Console.WriteLine(" • If a wrong guess is made, there will be a hint provided.");
            Console.WriteLine(" • Win points for each correct guess.");
            Console.WriteLine(" • The higher the maximum number, the more points awarded!\r\n");
        } 
        // end DisplayInstructions()




        // Validating the maximum number chosen by the user
        private static int MaxNumberValidation(string maxNumString)
        {
            int maxNum;
            while (!(int.TryParse(maxNumString, out maxNum)))
            {
                // Tell the user the error
                Console.WriteLine("\r\n Please enter a valid number.");
                // Reprompt the user
                Console.WriteLine(" Please enter in a maximum number.");
                maxNumString = Console.ReadLine();
            }
            // Acknowledge user input
            Console.WriteLine("\r\n Got it! Let's Begin!");
            // returning the number chosen
            return maxNum;
        }
        // end MaxNumberValidation()





        // Create the Random Number
        private static int RandomNumber(int maxNum)
        {
            Random randomGenerator = new Random();
            // number has to be greater than or equal to 1 and
            // less than maximum number chosen
            int chosenNumber = randomGenerator.Next(1, maxNum++);
            return chosenNumber;
        }
        // end RandomNumber()




        private static int PlayerGuessValidation(string playerGuessString)
        {
            int playerGuess;
            while (!(int.TryParse(playerGuessString, out playerGuess)))
            {
                // Tell the user the error encountered
                Console.WriteLine($"\r\n Please enter a valid number.");
                // Reprompt the guess
                Console.WriteLine(" Please type in your guess...");
                // Recapture the player's response
                playerGuessString = Console.ReadLine();
            }
            // returning the number the player guessed
            return playerGuess;
        }
        // end PlayerGuessValidation()





        // create a scoring system for gaining points for each correct guess
        private static int PlayerPoints(int maxNumber)
        {
            int pointsawarded = 0;
            int maxNumberChosen = maxNumber;
            // determines how many points are awarded depending on the maximum
            // number chosen
            if (maxNumberChosen <= 10)
            {
                pointsawarded = 100;
            }
            else if (maxNumberChosen > 10 && maxNumberChosen <= 100)
            {
                pointsawarded = 1000;
            }
            else if (maxNumberChosen > 100 && maxNumberChosen <= 1000)
            {
                pointsawarded = 10000;
            }
            // returning the amoutn of points awarded
            return pointsawarded;
        }
        // end PlayerPoints()
    }
    // end class
}
// end namespace
         
       

