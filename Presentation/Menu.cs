static class Menu
{
    static public AccountModel loggedaccount;
    public static AdminAccountModel loggedaccount2;

    //This shows the menu. You can call back to this method to show the menu again
    //after another presentation method is completed.
    //You could edit this to show different menus depending on the user's role
    static public void Start()
    {
        string prompt = @"
   ___           _           _     ___ 
  / _ \_ __ ___ (_) ___  ___| |_  / __\
 / /_)/ '__/ _ \| |/ _ \/ __| __|/__\//
/ ___/| | | (_) | |  __/ (__| |_/ \/  \
\/    |_|  \___// |\___|\___|\__\_____/
              |__/                     

        Welcome to the Cinema";
        string[] options = { "Login", "Register Account", "Select a movie", "Quit" };
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
                MovieLogic.chooseMovie();
            }
            else if (selectedIndex == 3)
            {
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("Invalid input");
                Start();
            }


        }
        // if (loggedaccount.EmailAddress == "admin@admin678.nl")
        // {
        //     string promptAdmin = "Welcome Admin";
        //     string[] optionsAdmin = { "Add a movie", "Add a show", "Remove a movie", "Remove a show", "Do Something else" };
        //     KeyBoardLogic adminMenu = new KeyBoardLogic(promptAdmin, optionsAdmin);
        //     int selectedIndexAdmin = adminMenu.Run();
        //     if (selectedIndexAdmin == 0)
        //     {
        //         AdminEdit.AddMovie();

        //     }
        //     else if (selectedIndexAdmin == 1)
        //     {
        //         AdminEdit.AddShow();
        //     }
        //     else if (selectedIndexAdmin == 2)
        //     {
        //         Console.WriteLine("Remove movie");
        //         AdminEdit.RemoveMovie();
        //     }
        //     else if (selectedIndexAdmin == 3)
        //     {
        //         Console.WriteLine("Remove show");
        //         AdminEdit.RemoveShow();
        //     }
        //     else if (selectedIndexAdmin == 4)
        //     {
        //         Start();
        //     }
        //     else
        //     {
        //         Console.WriteLine("Invalid input");
        //         Start();
        //     }
        // }
        //     if (selectedIndex == 0)
        //     {
        //         UserLogin.Start();
        //     }
        //     else if (selectedIndex == 1)
        //     {
        //         UserRegister.Start();
        //     }
        //     else if (selectedIndex == 2)
        //     {
        //         MovieLogic.chooseMovie();
        //     }
        //     else if (selectedIndex == 3)
        //     {
        //         Console.WriteLine("This feature is not yet implemented");
        //     }
        //     else
        //     {
        //         Console.WriteLine("Invalid input");
        //         Start();
        //     }
        // }

    }
}
