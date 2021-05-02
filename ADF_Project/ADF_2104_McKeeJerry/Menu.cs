using System;
using System.Collections.Generic;

/*
Jerry McKee Jr.
04/30/2021
ADF
Postmortem
*/

namespace ADF_2104_McKeeJerry
{
    public class Menu
    {
        //Fields
        private string _title;
        private List<string> _menuItems;

        // This method sets the fields "_title" and "_menuItems"
        public void Init(string title, List<string> menuItems)
        {
            _title = title;
            _menuItems = menuItems;
            
            Display(1);
        }
        // end Init()

        // This method displays the menu options available to the user
        private void Display(int menuOption)
        {
            
            Console.Clear();
            UI.Header(_title);
            // for() loop to cycle through each of the lists
            foreach (string item in _menuItems)
            {

                Console.WriteLine($"[{menuOption}] {item}");
                menuOption++;
            }
            Console.WriteLine();
            Console.WriteLine("[0] Exit");
        }
        // end Display()
    }
}
