static class Menu
{
    static public AccountModel loggedaccount;

    //This shows the menu. You can call back to this method to show the menu again
    //after another presentation method is completed.
    //You could edit this to show different menus depending on the user's role
    static public void Start()
    {
        Console.WriteLine("|-------------------------------------------------|");
        Console.WriteLine("|Enter 1 to login                                 |");
        Console.WriteLine("|Enter 2 to register account                      |");
        Console.WriteLine("|Enter 3 to select a movie                        |");
        Console.WriteLine("|Enter 4 to do something else in the future       |");
        Console.WriteLine("|-------------------------------------------------|");
        if (loggedaccount != null)
        {
            if (loggedaccount.EmailAddress == "admin@admin678.nl")
            {
                Console.WriteLine("|Admin functions:                                 |");
                Console.WriteLine("|Enter 5 to add a movie                           |");
                Console.WriteLine("|Enter 6 to add a show                            |");
                Console.WriteLine("|Enter 7 to remove a movie                        |");
                Console.WriteLine("|Enter 8 to remove a show                         |");
                Console.WriteLine("|Enter 9 to do something else in the future       |");
                Console.WriteLine("|-------------------------------------------------|");
            }
        }

        string input = Console.ReadLine();
        if (input == "1")
        {
            UserLogin.Start();
        }
        else if (input == "2")
        {
            UserRegister.Start();
        }
        else if (input == "3")
        {
            Console.WriteLine("Select movie");
        }
        else if (input == "4")
        {
            Console.WriteLine("This feature is not yet implemented");
        }
        if (loggedaccount != null)
        {
            if (input == "5" && loggedaccount.EmailAddress == "admin@admin678.nl")
            {
                Console.WriteLine("Add movie");
            }
            else if (input == "6" && loggedaccount.EmailAddress == "admin@admin678.nl")
            {
                Console.WriteLine("Add show");
            }
            else if (input == "7" && loggedaccount.EmailAddress == "admin@admin678.nl")
            {
                Console.WriteLine("Remove movie");
            }
            else if (input == "8" && loggedaccount.EmailAddress == "admin@admin678.nl")
            {
                Console.WriteLine("Remove show");
            }
            else if (input == "9" && loggedaccount.EmailAddress == "admin@admin678.nl")
            {
                Console.WriteLine("This feature is not yet implemented");
            }
            else
            {
                Console.WriteLine("Invalid input");
                Start();
            }
        }
        else
        {
            Console.WriteLine("Invalid input");
            Start();
        }
    }
}