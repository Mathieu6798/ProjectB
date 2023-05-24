public class AdminEdit
{
    public static void AddMovie()
    {
        Console.Clear();
        Console.WriteLine("Enter the title: ");
        string title = Console.ReadLine();
        Console.WriteLine("Enter the genre: ");
        string genre = Console.ReadLine();
        Console.WriteLine("Enter the recommended age ");
        int age = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter the discription: ");
        string info = Console.ReadLine();
        MovieLogic logic = new MovieLogic();
        MovieLogic.AddMovie(title, genre, age, info);
        if (MovieLogic.AddMovie(title, genre, age, info))
        {
            Console.WriteLine("Your movie has been added");
            Thread.Sleep(3000);
        }
        else
        {
            Console.WriteLine("The move was not added");
        }
        AdminPanel.AdminMenu();
    }


    public static void AddShow()
    {
        Console.Clear();
        Console.WriteLine("Add Show\n");
        Console.WriteLine("Enter the date: (dd/mm/yyyy)");
        string date = Console.ReadLine();
        Console.WriteLine("Enter Time: (HH:mm)");
        string time = Console.ReadLine();
        Console.WriteLine("Enter Room number: ");
        int roomId = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter MovieID: ");
        int movieId = Convert.ToInt32(Console.ReadLine());
        ShowLogic.ControlDate_Time(date, time, roomId, movieId);
    }
    public static void RemoveMovie()
    {
        Console.Clear();
        Console.WriteLine("Enter Movie Name To Remove: ");
        string input = Console.ReadLine();
        MovieLogic logic = new MovieLogic();
        MovieLogic.Removemovie(input);
    }
    public static void RemoveShow()
    {
        Console.Clear();
        Console.WriteLine("Enter Movie id: ");
        int id = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter date (year-month-day): ");
        string date = Console.ReadLine();
        Console.WriteLine("Enter time: ");
        string time = Console.ReadLine();
        if (ShowLogic.RemoveShow(id, date, time) == null)
        {
            RemoveShow();
        }
        else
        {
            Console.WriteLine(ShowLogic.RemoveShow(id, date, time));
        }
    }

    public static void AddAdmin()
    {
        Console.Clear();
        Console.WriteLine("Enter the name of the account: ");
        string accName = Console.ReadLine();
        Console.WriteLine("Enter the email of the account: ");
        string accEmail = Console.ReadLine();
        Console.WriteLine("Enter the password of the new account: ");
        string accPassword = Console.ReadLine();
        AdminLogic logic = new AdminLogic();
        logic.AddAccount(accName, accEmail, accPassword);
        Console.WriteLine(logic.AddAccount(accName, accEmail, accPassword));
        Thread.Sleep(3000);
        AdminPanel.AdminMenu();
    }

}