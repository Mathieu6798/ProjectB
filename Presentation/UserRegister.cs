static class UserRegister
{
    static private AccountsLogic accountsLogic = new AccountsLogic();


    public static void Start()
    {
        Console.WriteLine("Welcome to the register page");
        Console.WriteLine("Please enter your full name");
        string name = Console.ReadLine();
        Console.WriteLine("Please enter email adres");
        string email = Console.ReadLine();
        while (!email.Contains("@"))
        {
            Console.WriteLine("Invalid Email");
            Console.WriteLine("Please enter email adres");
            email = Console.ReadLine();
        }
        Console.WriteLine("Please enter password");
        // string password = Console.ReadLine();
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
        Console.WriteLine("\nPlease confirm password");
        string confirmpassword = "";
        while (true)
        {
            ConsoleKeyInfo key = Console.ReadKey(true);
            if (key.Key == ConsoleKey.Enter)
            {
                break;
            }
            else if (key.Key == ConsoleKey.Backspace && confirmpassword.Length > 0)
            {
                confirmpassword = confirmpassword.Substring(0, confirmpassword.Length - 1);
                Console.Write("\b \b");
            }
            else if (Char.IsLetterOrDigit(key.KeyChar))
            {
                confirmpassword += key.KeyChar;
                Console.Write(key.KeyChar);
                System.Threading.Thread.Sleep(100);
                Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                Console.Write("*");
            }
        }
        while (confirmpassword != password)
        {
            Console.WriteLine("\nPlease confirm password again");
            string confirmpassword2 = "";
            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.Enter)
                {
                    break;
                }
                else if (key.Key == ConsoleKey.Backspace && confirmpassword2.Length > 0)
                {
                    confirmpassword2 = confirmpassword2.Substring(0, confirmpassword2.Length - 1);
                    Console.Write("\b \b");
                }
                else if (Char.IsLetterOrDigit(key.KeyChar))
                {
                    confirmpassword2 += key.KeyChar;
                    Console.Write(key.KeyChar);
                    System.Threading.Thread.Sleep(100);
                    Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                    Console.Write("*");
                }
                confirmpassword = confirmpassword2;
            }
        }
        AccountModel acc = accountsLogic.CheckExistingEmail(email);
        if (acc != null)
        {
            Console.WriteLine("This email adress already exists on another account.");
            Thread.Sleep(3500);
            Menu.Start();
        }
        else
        {
            accountsLogic.AddAcount(name, email, password);
            Console.WriteLine("\nYour account has been added");
            Thread.Sleep(3500);
            Menu.Start();
        }
    }
}