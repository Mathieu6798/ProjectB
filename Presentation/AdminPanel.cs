static class AdminPanel
{
    public static void AdminMenu()
    {
        Console.WriteLine("Welcome to the Admin panel");
        Console.WriteLine("What would you like to do?: ");
        Console.WriteLine("1. Add a movie\n2. Remove a movie\n3. Add a show\n4. Remove a show\nM. Back to the Menu\nQ. Quit program");
        // string choice = Console.ReadLine().ToUpper();
        // if (choice != null)
        // {
        //     switch (choice)
        //     {
        //         case "1":
        //             AdminEdit.AddMovie();
        //             break;
        //         case "2":
        //             AdminEdit.RemoveMovie();
        //             break;
        //         case "3":
        //             AdminEdit.AddShow();
        //             break;
        //         case "4":
        //             AdminEdit.RemoveShow();
        //             break;
        //         case "M":
        //             Menu.Start();
        //             break;
        //         case "Q":
        //             Environment.Exit(0);
        //             break;
        //     }
        // }
        // else
        // {
        //     Console.WriteLine("That was not an option");
        //     AdminMenu();
        // }

        string promptAdmin = "Welcome Admin";
        string[] optionsAdmin = { "Add a movie", "Add a show", "Remove a movie", "Remove a show", "Do Something else" };
        KeyBoardLogic adminMenu = new KeyBoardLogic(promptAdmin, optionsAdmin);
        int selectedIndexAdmin = adminMenu.Run();
        if (selectedIndexAdmin == 0)
        {
            AdminEdit.AddMovie();

        }
        else if (selectedIndexAdmin == 1)
        {
            AdminEdit.AddShow();
        }
        else if (selectedIndexAdmin == 2)
        {
            Console.WriteLine("Remove movie");
            AdminEdit.RemoveMovie();
        }
        else if (selectedIndexAdmin == 3)
        {
            Console.WriteLine("Remove show");
            AdminEdit.RemoveShow();
        }
        else if (selectedIndexAdmin == 4)
        {
            //
        }
        else
        {
            Console.WriteLine("Invalid input");
            //;
        }
    }
}