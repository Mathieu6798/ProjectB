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
        Console.WriteLine("Please confirm password");
        string confirmpassword = Console.ReadLine();
        while (confirmpassword != password)
        {
            Console.WriteLine("Please confirm password");
            confirmpassword = Console.ReadLine();
        }

        AccountModel acc = accountsLogic.CheckExistingEmail(email);
        if (acc != null)
        {
            Console.WriteLine("This email adress already exists on another account.");
            Menu.Start();
        }
        else
        {
            accountsLogic.AddAcount(name, email, password);
            Console.WriteLine("Youre account has been added");
            Menu.Start();
        }
    }
}