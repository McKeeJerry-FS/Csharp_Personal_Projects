using System;

namespace RockPaperScissors
{
    class Program
    {
        static void Main(string[] args)
        {
            // Preparations
            Random randomNumbers = new Random();

            double playerPoints = 0;
            double computerPoints = 0;

            int rock = 1, paper = 2, scisssors = 3;

            // Inputs
            Console.WriteLine("Please enter your name ");
            string playersName = Console.ReadLine();

            Console.WriteLine("Please enter number of game rounds ");
            string input = Console.ReadLine();
            int totalRounds = Convert.ToInt32(input);

            Console.WriteLine();

            // Individual Rounds
            for (int roundNumber = 0; roundNumber < totalRounds; roundNumber++)
            {
                //Computer Chooses
                int computerChoice = randomNumbers.Next(1, 3+1);

                // Player Chooses
                Console.WriteLine("Enter R or S or P: ");
                string playerInput = Console.ReadLine();
                string playerInputUppercase = playerInput.ToUpper();
                int playerChoice = playerInputUppercase == "R" ? rock : playerInputUppercase == "S" ? scisssors : paper;

                // Round Evaluation
                string message = "";
                if (computerChoice == rock && playerChoice == scisssors ||
                    computerChoice == scisssors && playerChoice == paper ||
                    computerChoice == paper && playerChoice == rock)
                {
                    // Computer won
                    computerPoints += 1;
                    message = "I Won!";
                }
                else
                {
                    // Tie or Player Wins
                    if (computerChoice == playerChoice)
                    {
                        // Tie
                        computerPoints += 0.5;
                        playerPoints += 0.5;
                        message = "Tie";
                    }
                    else
                    {
                        // Player Won
                        playerPoints += 1;
                        message = "You Won!";
                    }
                }

                // Round Output
                string playerChoiceInText = playerChoice == rock ? "Rock" : (playerChoice == scisssors ? "Scissors" : "Paper");
                string computerChoiceInText = computerChoice == rock ? "Rock" : (computerChoice == scisssors ? "Scissors" : "Paper");

                Console.WriteLine(playersName + " :Computer - " + playerChoiceInText + " : " + computerChoiceInText);
                Console.WriteLine(message);
                Console.WriteLine();
            }
            // end of ForLoop() for Round

            // Game Evaluation
            Console.WriteLine("Game Over - Overall Result ");
            Console.WriteLine(playerPoints.ToString() + " : " + computerPoints.ToString());

            // Waiting for enter
            Console.ReadLine();
        }
    }
}
