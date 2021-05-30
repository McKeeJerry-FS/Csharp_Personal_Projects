using System;

/*
Jerry McKee Jr.
04/30/2021
ADF
Postmortem
*/


namespace ADF_2104_McKeeJerry
{
    class Program
    {
        // This is the main entry point into the program.
        static void Main(string[] args)
        {
            
            // Instantiating an app object
            App project = new App();
            project.LoadingUsers();
            project.LogIn();
        }
    }
}
