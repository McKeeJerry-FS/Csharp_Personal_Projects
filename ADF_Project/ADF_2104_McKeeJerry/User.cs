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
    public class User
    {
        // Fields
        private List<User> _users;
        private int _id;
        private string _passWord;
        private string _location;
        private string _userName;

        // Properties
        public string Name { get; set; }
        public User Users { get; set; }
        
        // Constructor
        public User(string userName, int userID, string userPassWord, string userLocation)
        {
            Name = userName;
            _id = userID;
            _location = userLocation;
            _passWord = userPassWord;
        }
        
        
        public void LoadingUsersList()
        {
            /* 
             The "If" Statement verifies if the file exists. If it does, then it will continue on to 
             the StreamReader to gather information from the designated text file. 
            */

            if (File.Exists("../../../UserInfoList.txt"))
            {
                using (StreamReader stream = new StreamReader("../../../UserInfoList.txt"))
                {

                    _users = new List<User>();
                    // This line of code reads and consumes the first line of data in the text file
                    stream.ReadLine();
                    string line;
                    while ((line = stream.ReadLine()) != null)
                    {
                        // This block of code takes the data read from the StreamReader and adds it
                        // to the appropriate List and Dictionary that will be used to make use
                        // of the saved data.
                        string[] data = line.Split('|');
                        User user = new User(data[0], int.Parse(data[1]), data[2], data[3]);
                        _users.Add(user);
                    }

                }
            }
        }
        // end LoadingUsersList()
    }
}

            

