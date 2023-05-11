static class AdminPanel
{
    public static void AdminMenu()
    {
        Console.WriteLine("Welcome to the Admin panel");
        Console.WriteLine("What would you like to do?: ");
        Console.WriteLine("1. Add a movie\n2. Remove a movie\n3. Add a show\n4. Remove a show\nM. Back to the Menu\nQ. Quit program");

        string promptAdmin = "Welcome Admin";
        string[] optionsAdmin = { "Add a movie", "Add a show", "Remove a movie", "Remove a show", "Check booked seats", "Logout" };
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
            AdminEdit.RemoveMovieChoice();
        }
        else if (selectedIndexAdmin == 3)
        {
            Console.WriteLine("Remove show");
            AdminEdit.RemoveShowChoice();
        }
        else if (selectedIndexAdmin == 4){
          //
        }
        else if (selectedIndexAdmin == 5)
        {
            Menu.loggedaccount = null;
            Console.Clear();
            Console.WriteLine("You are now logged out");
            Thread.Sleep(3000);
            Menu.Start();

        }
        else
        {
            Console.WriteLine("Invalid input");
            //;
        }
    }
}
