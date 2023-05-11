public class AdminEdit
{
    public static void AddMovie()
    {
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
        AdminPanel.AdminMenu();
    }


    public static void AddShow()
    {
        Console.WriteLine("Enter the date: ");
        string date = Console.ReadLine();
        Console.WriteLine("Enter Time: ");
        string time = Console.ReadLine();
        Console.WriteLine("Enter Room number: ");
        int roomId = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter MovieID: ");
        int movieId = Convert.ToInt32(Console.ReadLine());
        ShowLogic.ControlDate_Time(date, time, roomId, movieId);
    }
    public static void RemoveMovieChoice()
    {
        System.Console.WriteLine("Make a choice: \n1: See list of movies \n2: Remove movie by name");
        int input = Convert.ToInt32(Console.ReadLine());
        if (input == 1)
        {
            int totalLength = 30;
            char paddingChar = '-';
            foreach (var item in MoviesAccess.LoadAll())
            {
                string formattedString = $"{item.Name}: {item.Genre}".PadLeft(totalLength, paddingChar);
                System.Console.WriteLine(formattedString);
            }
            string input2 = System.Console.ReadLine();
            AdminEdit.RemoveMovieChoice();
        }
        else if (input == 2)
        {
            AdminEdit.RemoveMovie();
        }
        else
        {
            AdminEdit.RemoveMovieChoice();
        }
    }

    public static void RemoveShowChoice()
    {
        System.Console.WriteLine("Make a choice: \n1: See list of shows \n2: Remove show by id");
        int input = Convert.ToInt32(Console.ReadLine());
        if (input == 1)
        {
            int totalLength = 30;
            char paddingChar = '-';
            foreach (var show in ShowAccess.LoadAll())
            {
                System.Console.WriteLine($"Show Id:{show.Id}-----------------{show.Date}-----{show.Time}-----Room {show.RoomId}");
            }
            string input2 = System.Console.ReadLine();
            AdminEdit.RemoveShowChoice();
        }
        else if (input == 2)
        {
            AdminEdit.RemoveShow();
        }
        else
        {
            AdminEdit.RemoveShowChoice();
        }
    }
    public static void RemoveMovie()
    {
        Console.WriteLine("Enter Movie Name To Remove: ");
        string input = Console.ReadLine();
        MovieLogic logic = new MovieLogic();
        MovieLogic.Removemovie(input);
    }
    public static void RemoveShow()
    {
        Console.WriteLine("Enter Movie id: ");
        int id = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter date (year-month-day): ");
        string date = Console.ReadLine();
        Console.WriteLine("Enter time: ");
        string time = Console.ReadLine();
        ShowLogic.RemoveShow(id, date, time);
    }

}