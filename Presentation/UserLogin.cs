static class UserLogin
{
    static private AccountsLogic accountsLogic = new AccountsLogic();
    static private AdminLogic adminLogic = new AdminLogic();
    public static bool isMakingAReservation = false;

    public static void Start()
    {
        Console.Clear();
        Console.CursorVisible = true;
        if (Menu.loggedaccount != null)
        {
            Console.WriteLine($"You are already logged in with this account: Fullname: {Menu.loggedaccount.FullName}, Email: {Menu.loggedaccount.EmailAddress}");
            string prompt = "Would you like to login with another account? Yes or no.";
            string[] options = { "Yes", "No" };
            KeyBoardLogic mainMenu = new KeyBoardLogic(prompt, options);
            int choice = mainMenu.Run();
            if (choice == 1)
            {
                Menu.Start();
            }
            else if (choice == 0)
            {
            }
            else
            {
                Console.WriteLine("Invalid input");
                Menu.Start();
            }
        }
        Console.WriteLine("Welcome to the login page");
        Console.WriteLine("Please enter your email address");
        string email = Console.ReadLine();
        Console.WriteLine("Please enter your password");
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
        AccountModel acc = accountsLogic.CheckLogin(email, password);
        AdminAccountModel acc2 = adminLogic.CheckLogin(email, password);
        if (acc == null && acc2 == null)
        {
            Console.WriteLine("\nNo account found with that email and password");
            Thread.Sleep(3500);
            Menu.Start();
        }





        /////////////////////////////////////////////////

        else if (acc != null && acc.EmailAddress != null)
        {
            Console.Clear();
            if (isMakingAReservation == true)
            {
                Console.WriteLine("You can now continue with your reservation");
                Menu.loggedaccount = acc;
                Thread.Sleep(3500);
                return;
            }
            else
            {
                Console.WriteLine("\nWelcome back " + acc.FullName + "!");
                // Console.WriteLine("Your email is " + acc.EmailAddress);
                Menu.loggedaccount = acc;
                Thread.Sleep(3500);
                UserLoggedIn.Start();
            }
        }
        else if (acc2 != null && acc2.EmailAddress != null)
        {
            Console.Clear();
            Console.WriteLine("Welcome back " + acc2.FullName + "!");
            // Console.WriteLine("Your email is " + acc2.EmailAddress);
            Menu.loggedaccount2 = acc2;
            // UserLoggedIn.Start();
            Thread.Sleep(3500);
            AdminPanel.AdminMenu();
        }
        else
        {
            Console.Clear();
            Console.WriteLine("\nNo account found with that email and password");
            Thread.Sleep(3500);
            Menu.Start();
        }
        //////////////////////////////////////////////////////


    }
}