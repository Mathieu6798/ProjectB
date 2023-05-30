static class AdminPanel
{
    public static void AdminMenu()
    {
        Console.Clear();
        Console.Clear();
        Console.WriteLine("Welcome to the Admin panel");
        //Console.WriteLine("1. Add a movie\n2. Remove a movie\n3. Add a show\n4. Remove a show\nM. Back to the Menu\nQ. Quit program");

        string promptAdmin = "What would you like to do?";
        string[] optionsAdmin = { "Add a movie", "Add a show", "Remove a movie", "Remove a show", "Check booked seats", "Add a admin account", "Delete a admin account", "Logout" };
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
            MovieLogic.RemoveMovieChoice();
        }
        else if (selectedIndexAdmin == 3)
        {
            Console.WriteLine("Remove show");
            ShowLogic.RemoveShowChoice();
        }
        else if (selectedIndexAdmin == 4)
        {
            //booked seats shit moet hier//
            Console.WriteLine("Show ID:");
            int inp = int.Parse(Console.ReadLine());
            RoomLogic.AdminRoomCheck(inp);
        }
        else if (selectedIndexAdmin == 5)
        {
            AdminEdit.AddAdmin();
        }
        else if (selectedIndexAdmin == 6)
        {
            AdminEdit.DeleteAdmin();
        }
        else if (selectedIndexAdmin == 7)
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
