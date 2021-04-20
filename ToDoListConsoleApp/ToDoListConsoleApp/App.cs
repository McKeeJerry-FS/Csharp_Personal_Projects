using System;
namespace ToDoListConsoleApp
{
    public class App
    {
        public App()
        {
        }


        // App Initialization
        public void Welcome()
        {
            Console.Clear();
            Menu menu = new Menu();
            menu.Init();
        }
    }
}
