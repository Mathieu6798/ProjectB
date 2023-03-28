static class Menu
{
    static public AccountModel loggedaccount;

    //This shows the menu. You can call back to this method to show the menu again
    //after another presentation method is completed.
    //You could edit this to show different menus depending on the user's role
    static public void Start()
    {
        string prompt = @"
  ______                    
 / ___(_)__  ___ __ _  ___ _
/ /__/ / _ \/ -_)  ' \/ _ `/
\___/_/_//_/\__/_/_/_/\_,_/ 
                            

        Welcome to the Cinema";
        string[] options = { "Login", "Register Account", "Select a movie", "Do Someting else" };

        // Show the regular menu if no user is logged in or if the logged-in user is not an admin
        if (loggedaccount == null || loggedaccount.EmailAddress != "admin@admin678.nl")
        {
            KeyBoardLogic mainMenu = new KeyBoardLogic(prompt, options);
            int selectedIndex = mainMenu.Run();

            while (loggedaccount == null)
            {
                if (selectedIndex == 0)
                {
                    UserLogin.Start();
                }
                else if (selectedIndex == 1)
                {
                    UserRegister.Start();
                }
                else if (selectedIndex == 2)
                {
                    Console.WriteLine("Select movie");
                }
                else if (selectedIndex == 3)
                {
                    Console.WriteLine("This feature is not yet implemented");
                }
                else
                {
                    Console.WriteLine("Invalid input");
                }

                // Show the menu again and get the user's input
                mainMenu = new KeyBoardLogic(prompt, options);
                selectedIndex = mainMenu.Run();
            }
        }
        else
        {
            // Show the admin menu if the logged-in user is an admin
            string promptAdmin = "Welcome Admin";
            string[] optionsAdmin = { "Add a movie", "Add a show", "Remove a movie", "Remove a show", "Do Something else" };
            KeyBoardLogic adminMenu = new KeyBoardLogic(promptAdmin, optionsAdmin);
            int selectedIndexAdmin = adminMenu.Run();

            while (loggedaccount != null && loggedaccount.EmailAddress == "admin@admin678.nl")
            {
                if (selectedIndexAdmin == 0)
                {
                    Console.WriteLine("Add poep");
                }
                else if (selectedIndexAdmin == 1)
                {
                    Console.WriteLine("Add show");
                }
                else if (selectedIndexAdmin == 2)
                {
                    Console.WriteLine("Remove movie");
                }
                else if (selectedIndexAdmin == 3)
                {
                    Console.WriteLine("Remove show");
                }
                else if (selectedIndexAdmin == 4)
                {
                    Console.WriteLine("This feature is not yet implemented");
                }
                else
                {
                    Console.WriteLine("Invalid input");
                }

                // Show the menu again and get the user's input
                adminMenu = new KeyBoardLogic(promptAdmin, optionsAdmin);
                selectedIndexAdmin = adminMenu.Run();
            }
        }
    }
}
