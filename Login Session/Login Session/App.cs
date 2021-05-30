using System;
using System.Collections.Generic;
using System.IO;

/*
Jerry McKee Jr.
05/01/2021
ADF
Postmortem
*/

namespace ADF_2104_McKeeJerry
{
    public class App
    {
        // Field
        private bool _loggedIn;
        private List<User> _users; 
        private string _activeUserName;
       
        

        // Properties
        public User Users { get; set; }
        public bool LoggedIn { get; set; }
        public Dictionary<string, string> _userLogin;
        public Dictionary<string, int> _userID;
        public Dictionary<string, string> _userLocation;


        // Constructor
        public App()
        {
            Menu menu = new Menu();
            menu.Init("Main menu", new List<string> { "Create New User", "Login", "About" });
            
        }

        public void LoadingUsers()
        {
            /* 
             The "If" Statement verifies if the file exists. If it does, then it will continue on to 
             the StreamReader to gather information from the designated text file. 
            */

            if (File.Exists("../../../UserInfoList.txt"))
            {
                using (StreamReader stream = new StreamReader("../../../UserInfoList.txt"))
                {

                    // This line of code reads and consumes the first line of data in the text file
                    _userLogin = new Dictionary<string, string>();
                    _userID = new Dictionary<string, int>();
                    _userLocation = new Dictionary<string, string>();

                    stream.ReadLine();
                    string line;
                    while ((line = stream.ReadLine()) != null)
                    {
                        // This block of code takes the data read from the StreamReader and adds it
                        // to the appropriate List and Dictionary that will be used to make use
                        // of the saved data.
                        string[] data = line.Split('|');
                        _userLogin.Add(data[0], data[2]);
                        _userID.Add(data[0], int.Parse(data[1]));
                        _userLocation.Add(data[0], data[3]);
                    }

                }
                // end "using" statement
            }
        }
        // end LoadingUsers()

          
        // This method allows the user to make a selection from the menu
        public void Selection()
        {
            
            UI.Separator();
            Console.WriteLine("Please choose from the menu...");
            int userChoice = Validation.RangeValidation(Console.ReadLine(), -1, 5);
            if (_loggedIn == true)
            {
                switch (userChoice)
                {
                    case 1:
                        About();
                        break;
                    case 2:
                        Profile();
                        Continue();
                        break;
                    case 3:
                        ViewUsers();
                        break;
                    case 4:
                        LogOut();
                        break;
                    case 0:
                        Exit();
                        break;
                }
                // end switch statement (logged in state)
            }
            else
            {
                switch (userChoice)
                {
                    case 1:
                        CreateUser();
                        break;
                    case 2:
                        LogIn();
                        break;
                    case 3:
                        About();
                        break;
                    case 0:
                        Exit();
                        break;

                }
                // end switch statement (logged out state)
            }
        }
        // end Selection()

        // This method calls the Login() from the User class and validates a user
        // logging in to the program
        public void LogIn()
        {
            //User user = new User("Jerry", 0001, "Admin", "Tolland, CT");
            Console.Clear();
            SignIn();
        }
        // end LogIn()

        // This method is a placeholder for a future feature in this program
        private void About()
        {
            Console.Clear();
            Console.WriteLine("This section will display information when a user fills it out.");
            Continue();
        }
        // end About()

        // This method allows the user to exit the program
        private void Exit()
        {
            Console.Clear();
            UI.Animation("Exiting");
            _loggedIn = false;
            Console.WriteLine();
            Console.WriteLine("Have a great day!");
        }
        // end Exit()

        // This method allows continuation of use in the program
        // after a selection has been made.
        public void Continue()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            
            Menu menu = new Menu();
            if (_loggedIn == true)
            {

                menu.Init($"Welcome {_activeUserName}", new List<string> { "About", "Profile", "Users", "Logout" });
                Selection();
            }
            else
            {
                menu.Init("Main Menu", new List<string> { "Create New User", "Login", "About" });
                Selection();
            }
        }
        // end Continue()

        // This method is used to create a new user for the program
        private void CreateUser()
        {
            Console.Clear();
            UI.Header("Create User");
            Console.WriteLine("Please enter your name.");
            string userName = Validation.StringValidation(Console.ReadLine().ToUpper());
            UI.Separator();
            Console.WriteLine("Please Enter your ID number.");
            int ID = Validation.IntegerValidation(Console.ReadLine());
            UI.Separator();
            Console.WriteLine("Please enter in a password.");
            string passWord = Validation.StringValidation(Console.ReadLine().ToUpper());
            UI.Separator();
            Console.WriteLine("Where are you from?");
            string location = Validation.StringValidation(Console.ReadLine().ToUpper());
            Console.WriteLine("Here is what you have entered...");
            Console.WriteLine(userName);
            Console.WriteLine(ID);
            Console.WriteLine(passWord);
            Console.WriteLine(location);
            Console.WriteLine();
            UI.Separator();
            //_activeUser = new User(userName, ID, passWord, location);
            using (StreamWriter stream = File.AppendText("../../../UserInfoList.txt"))
            {
                stream.WriteLine($"{userName}|{ID}|{passWord}|{location}");
            }
            Continue();
        }
        // end CreateUser()

        // This method allows a user to sign in to the program
        public string SignIn()
        {
            Menu menu = new Menu();
            Console.Clear();
            _loggedIn = false;
            Console.WriteLine("Please enter your username");
            string userName = Validation.StringValidation(Console.ReadLine().ToUpper());
            Console.WriteLine("Please enter your password");
            string passWord = Validation.StringValidation(Console.ReadLine());
            if (_userLogin.ContainsKey(userName) && _userLogin.ContainsValue(passWord))
            {
                _activeUserName = userName;
                _loggedIn = true;
                menu.Init($"Welcome {_activeUserName}", new List<string> { "About", "Profile", "Users", "Logout" });
                Selection();
            }
            else
            {
                Console.WriteLine("Invalid Username or Password.");
                Console.WriteLine("Please enter your Username");
                userName = Validation.StringValidation(Console.ReadLine().ToUpper());
                Console.WriteLine("Please enter your password");
                passWord = Validation.StringValidation(Console.ReadLine());
                Continue();
            }
            return userName;
        }
        // end SignIn()


        // This method allows a user to log out of the program and displays a default
        // Main Menu upon logging out
        private void LogOut()
        {
            UI.Animation("Logging Out");
            _loggedIn = false;
            Console.Clear();
            Menu menu = new Menu();
            menu.Init("Main Menu", new List<string> { "Create New User", "Login", "About" });
            Selection();
        }
        // end LogOut()

        // This list will allow the user to see a list of all users
        // that have access to the program
        private void ViewUsers()
        {
            Console.Clear();
            UI.Header("View All Users");
            Dictionary<string, string> userInfo = new Dictionary<string, string>();

            userInfo.Add("Jerry", "Tolland, CT");
            userInfo.Add("Adam", "Boston, MA");
            userInfo.Add("Allison", "New York City, NY");
            userInfo.Add("Erik", "Salt Lake City, UT");
            userInfo.Add("Tom", "Boston, MA");
            userInfo.Add("Justin", "Orlando, FL");
            userInfo.Add("Jessica", "Burlington, VT");
            userInfo.Add("Sara", "Los Angelos, CA");
            userInfo.Add("Loki", "Austin, TX");

            foreach (KeyValuePair<string, string> kvp in userInfo)
            {
                Console.WriteLine($"Name: {kvp.Key}");
                Console.WriteLine($"Location: {kvp.Value}");
                UI.Separator();
            }
            UI.Separator();
            Console.WriteLine("Press RETURN to continue");
            Console.ReadKey();
            Continue();

        }
        // end ViewUsers()

        //This method allows for viewing information about a user
        public void Profile()
        {
            
            Console.Clear();
            UI.Header($"Profile: {_activeUserName}");
            Console.WriteLine($"Lacation: Work From Home");
            UI.Separator();
        }
        //end profile()
    }
}