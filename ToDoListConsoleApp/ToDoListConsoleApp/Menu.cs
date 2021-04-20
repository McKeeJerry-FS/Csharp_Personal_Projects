using System;
using System.Collections.Generic;

/*
Jerry McKee Jr. 
04/19/2021
Personal App
To Do List Console App
*/

namespace ToDoListConsoleApp
{
    public class Menu
    {
        private List<string> _menuItems;
        private string _title;

        public Menu()
        {
            _menuItems = new List<string>() { "Login", "Create New User", "About" };
        }

        public void Init()
        {
            UI.Animation("Loading");
            Console.Clear();
            UI.Header("  Welcome to ToDo Today  ");
            DisplayMenu(1);
        }

        private void DisplayMenu(int menuOption)
        {
            Console.Clear();
            UI.Header("  What would you like to do today?");
            // for() loop to cycle through each of the lists
            foreach (string item in _menuItems)
            {

                Console.WriteLine($"[{menuOption}] {item}");
                menuOption++;
            }
            Console.WriteLine();
            Console.WriteLine("[0] Exit");
        }
    }
}
