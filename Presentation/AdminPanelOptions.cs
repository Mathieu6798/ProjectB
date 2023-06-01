public static class AdminPanelOptions
{
    public static void MovieOptions()
    {
        Console.Clear();
        Console.WriteLine("MovieOptions");
        string promptAdmin = "What would you like to do?";
        string[] optionsAdmin = { "Add a movie", "Remove a movie", "Back" };
        KeyBoardLogic adminMenu = new KeyBoardLogic(promptAdmin, optionsAdmin);
        int selectedIndexAdmin = adminMenu.Run();
        if (selectedIndexAdmin == 0)
        {
            AdminEdit.AddMovie();
        }
        else if (selectedIndexAdmin == 1)
        {
            AdminEdit.RemoveMovie();
        }
        else if (selectedIndexAdmin == 2)
        {
            AdminPanel.AdminMenu();
        }
    }
    public static void SeatOptions()
    {
        Console.Clear();
        Console.WriteLine("SeatOptions");
        string promptAdmin = "What would you like to do?";
        string[] optionsAdmin = { "Check booked seats", "Back" };
        KeyBoardLogic adminMenu = new KeyBoardLogic(promptAdmin, optionsAdmin);
        int selectedIndexAdmin = adminMenu.Run();
        if (selectedIndexAdmin == 0)
        {
            Console.CursorVisible = true;
            Console.WriteLine("Show ID:");
            int inp = int.Parse(Console.ReadLine());
            RoomLogic.AdminRoomCheck(inp);
        }
        else if (selectedIndexAdmin == 1)
        {
            AdminPanel.AdminMenu();
        }
    }
    public static void ShowOptions()
    {
        Console.Clear();
        Console.WriteLine("ShowOptions");
        string promptAdmin = "What would you like to do?";
        string[] optionsAdmin = { "Add a show", "Remove a show", "Back" };
        KeyBoardLogic adminMenu = new KeyBoardLogic(promptAdmin, optionsAdmin);
        int selectedIndexAdmin = adminMenu.Run();
        if (selectedIndexAdmin == 0)
        {
            AdminEdit.AddShow();
        }
        else if (selectedIndexAdmin == 1)
        {
            AdminEdit.RemoveShow();
        }
        else if (selectedIndexAdmin == 2)
        {
            AdminPanel.AdminMenu();
        }
    }
    public static void AccountOptions()
    {
        Console.Clear();
        Console.WriteLine("AccountOptions");
        string promptAdmin = "What would you like to do?";
        string[] optionsAdmin = { "Add a admin account", "Delete a admin account", "Back" };
        KeyBoardLogic adminMenu = new KeyBoardLogic(promptAdmin, optionsAdmin);
        int selectedIndexAdmin = adminMenu.Run();
        if (selectedIndexAdmin == 0)
        {
            AdminEdit.AddAdmin();
        }
        else if (selectedIndexAdmin == 1)
        {
            AdminEdit.DeleteAdmin();
        }
        else if (selectedIndexAdmin == 2)
        {
            AdminPanel.AdminMenu();
        }
    }
}