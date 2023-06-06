public class AdminEdit
{
    public static bool check = true;
    public static int age;
    public static void AddMovie()
    {
        Console.Clear();
        Console.WriteLine("Enter the title: ");
        string title = Console.ReadLine();
        Console.WriteLine("Enter the genre: ");
        string genre = Console.ReadLine();
        while (check)
        {
            Console.WriteLine("Enter the recommended age ");
            try
            {
                int age = Convert.ToInt32(Console.ReadLine());
                if (age > 21 || age < 12)
                {
                    Console.WriteLine($"The age was either too high or too low (12-21)");
                    check = true;
                }
                else
                {
                    check = false;
                }
                //age = Convert.ToInt32(strAge);
                // check = false;
            }
            catch (FormatException)
            {
                Console.WriteLine($"The age you entered was not a valid age");
                check = true;
            }
        }


        Console.WriteLine("Enter the discription: ");
        string info = Console.ReadLine();
        MovieLogic logic = new MovieLogic();
        Console.WriteLine(MovieLogic.AddMovie(title, genre, age, info));
        Thread.Sleep(3000);
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
        if (MovieLogic.Removemovie(input))
        {
            Console.WriteLine("The movie has been removed");
        }
        else
        {
            Console.WriteLine("No movie found with that name");
        }
        Console.WriteLine(MovieLogic.Removemovie(input));
        Thread.Sleep(3000);
        AdminPanelOptions.MovieOptions();
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


    /////////////accounts/////////////
    public static void AddAdmin()
    {
        Console.Clear();
        Console.WriteLine("Enter the name of the account: ");
        string accName = Console.ReadLine();
        Console.WriteLine("Enter the email of the account: ");
        string accEmail = Console.ReadLine();
        while (!accEmail.Contains("@"))
        {
            Console.WriteLine("Invalid Email");
            Console.WriteLine("Please enter email adress");
            accEmail = Console.ReadLine();
        }
        Console.WriteLine("Enter the password of the new account: ");

        string password = "";
        while (true)
        {
            ConsoleKeyInfo key = Console.ReadKey(true);
            if (key.Key == ConsoleKey.Enter)
            {
                break;
            }
            else if (key.Key == ConsoleKey.Backspace && password.Length > 0)
            {
                //removes latest letter if backspace is pressed
                password = password.Substring(0, password.Length - 1);
                Console.Write("\b \b");
            }
            else if (Char.IsLetterOrDigit(key.KeyChar))
            {
                //turn the letter into the star.
                password += key.KeyChar;
                Console.Write(key.KeyChar);
                System.Threading.Thread.Sleep(100);
                Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                Console.Write("*");
            }
        }
        AdminLogic logic = new AdminLogic();
        Console.WriteLine(logic.AddAccount(accName, accEmail, password));
        Thread.Sleep(3000);
        AdminPanel.AdminMenu();

    }
    public static void DeleteAdmin()
    {
        Console.Clear();
        Console.WriteLine("Enter the ID of the account: ");
        int accID = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter the email of the account: ");
        string accEmail = Console.ReadLine();
        AdminLogic logic = new AdminLogic();
        Console.WriteLine(logic.DeleteAdmin(accID, accEmail));
        Thread.Sleep(3000);
        AdminPanel.AdminMenu();
    }

}
