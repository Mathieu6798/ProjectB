static class AdminPanel
{
    public static void AdminMenu()
    {
        Console.Clear();
        Console.Clear();
        Console.CursorVisible = false;
        Console.WriteLine("Welcome to the Admin panel");
        string promptAdmin = "What would you like to do?";
        string[] optionsAdmin = { "Movie Tools", "Show Tools", "Seat Tools", "Account Tools", "See map of showroom", "Logout" };
        KeyBoardLogic adminMenu = new KeyBoardLogic(promptAdmin, optionsAdmin);
        int selectedIndexAdmin = adminMenu.Run();
        if (selectedIndexAdmin == 0)
        {
            AdminPanelOptions.MovieOptions();
        }
        else if (selectedIndexAdmin == 1)
        {
            AdminPanelOptions.ShowOptions();
        }
        else if (selectedIndexAdmin == 2)
        {
            AdminPanelOptions.SeatOptions();
        }
        else if (selectedIndexAdmin == 3)
        {
            AdminPanelOptions.AccountOptions();
        }
        else if (selectedIndexAdmin == 4)
        {
            RoomLogic.AdminRoomCheck(RoomLogic.GetShows());
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
