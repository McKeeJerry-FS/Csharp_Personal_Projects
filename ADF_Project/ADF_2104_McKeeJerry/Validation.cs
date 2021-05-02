using System;

/*
Jerry McKee Jr.
04/30/2021
ADF
Postmortem
*/

namespace ADF_2104_McKeeJerry
{
    public static class Validation
    {
        // Integer Validation Method
        public static int IntegerValidation(string input)
        {
            int userInput;
            while (!(int.TryParse(input, out userInput)))
            {
                //Tell the user the error
                Console.WriteLine("\r\n Invalid Entry");
                //Reprompt
                Console.WriteLine("Please type in a valid number.");
                //Recapture
                input = Console.ReadLine();
            }
            return userInput;
        }
        // end IntegerValidation()

        // String Validation Method
        public static string StringValidation(string input)
        {
            // variable to store input
            string userInput = input;
            while (string.IsNullOrWhiteSpace(userInput))
            {
                // Tell user the error
                Console.WriteLine("\r\n Please do not leave this space blank.");
                // Reprompt
                Console.WriteLine(" Please type in a valid answer...");
                userInput = Console.ReadLine();
            }
            return userInput;

        }
        // end StringValidation()

        // Range Validation
        // This method validates that a user has provided input that falls within the range
        // that is predetermined by the programmer.
        public static int RangeValidation(string userInputString, int minVal, int maxVal)
        {
            int userinput;
            while (!(int.TryParse(userInputString, out userinput)) || userinput < minVal || userinput > maxVal)
            {
                //Tell user the error
                Console.WriteLine("\r\n Invalid Entry");
                Console.WriteLine($" PLease type in a valid number between {minVal + 1} and {maxVal - 1}");
                userInputString = Console.ReadLine();
            }
            return userinput;
        }
        //end Range Validation
    }
}
