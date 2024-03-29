public class AdminEdit
{
    public static bool check = true;

    public static void AddMovie()
    {
        Console.Clear();
        Console.WriteLine("Enter the title: ");
        string title = Console.ReadLine();
        Console.WriteLine("Enter the genre: ");
        string genre = Console.ReadLine();
        int age = 1;
        while (check)
        {
            Console.WriteLine("Enter the recommended age ");
            try
            {
                age = Convert.ToInt32(Console.ReadLine());
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
        double duration = 301;
        while (duration > 300)
        {
            Console.WriteLine("Enter the duration in minutes.");
            try
            {
                duration = Convert.ToDouble(Console.ReadLine());
                if (duration > 300 || duration < 0)
                {
                    Console.WriteLine("The duration was invalid. A movie cannot be shorter than 0 minutes and not longer than 300 minutes.");
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid number");
            }
        }
        Console.WriteLine("Enter the description: ");
        string info = Console.ReadLine();
        MovieLogic logic = new MovieLogic();
        Console.WriteLine(MovieLogic.AddMovie(title, genre, age, duration, info));
        Thread.Sleep(3000);
        AdminPanel.AdminMenu();
    }




    public static void AddShow()
    {
        Console.Clear();
        Console.WriteLine("Add Show\n");
        Console.WriteLine("Enter the date: (dd-mm-yyyy)");
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
        Thread.Sleep(3000);
        AdminPanelOptions.MovieOptions();
    }
    public static void RemoveShow()
    {
        Console.Clear();
        Console.WriteLine("Enter Show id: ");
        int id = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine(ShowLogic.RemoveShow(id));
        Thread.Sleep(3200);
        // }
    }


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
                password = password.Substring(0, password.Length - 1);
                Console.Write("\b \b");
            }
            else if (Char.IsLetterOrDigit(key.KeyChar))
            {
                password += key.KeyChar;
                Console.Write(key.KeyChar);
                System.Threading.Thread.Sleep(100);
                Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                Console.Write("*");
            }
        }


        AdminLogic logic = new AdminLogic();
        AdminAccountModel acc = logic.CheckExistingEmail(accEmail);
        if (acc != null)
        {
            Console.WriteLine("This email adress already exists on another account.");
            Thread.Sleep(3500);
            AdminPanel.AdminMenu();
        }
        else
        {
            logic.AddAccount(accName, accEmail, password);
            Console.WriteLine("\nYour account has been added");
            Thread.Sleep(3500);
            AdminPanel.AdminMenu();
        }
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
