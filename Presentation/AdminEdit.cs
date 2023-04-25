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
        ShowLogic.AddShow(date, time, roomId, movieId);
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
        Console.WriteLine("Enter Movie Name: ");
        string name = Console.ReadLine();
        Console.WriteLine("Enter date (year-month-day): ");
        string date = Console.ReadLine();
        Console.WriteLine("Enter time: ");
        string time = Console.ReadLine();
        ShowLogic.RemoveShow(name, date, time);
    }

}