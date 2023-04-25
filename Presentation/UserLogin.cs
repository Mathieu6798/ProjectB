static class UserLogin
{
    static private AccountsLogic accountsLogic = new AccountsLogic();


    public static void Start()
    {
        if (Menu.loggedaccount != null)
        {
            Console.WriteLine($"You are already logged in with this account: Fullname: {Menu.loggedaccount.FullName}, Email: {Menu.loggedaccount.EmailAddress}");
            Console.WriteLine("Would you like to login with another account? Yes or no.");
            string choice = Console.ReadLine();
            if (choice.ToLower() == "no")
            {
                Menu.Start();
            }
            else if (choice.ToLower() == "yes")
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
        string password = Console.ReadLine();
        AccountModel acc = accountsLogic.CheckLogin(email, password);
        if (acc.EmailAddress == "admin@admin678.nl")
        {
            AdminPanel.AdminMenu();
        }
        else if (acc != null && acc.EmailAddress != "admin@admin678.nl")
        {
            Console.WriteLine("Welcome back " + acc.FullName + "!");
            Console.WriteLine("Your email number is " + acc.EmailAddress);
            Menu.loggedaccount = acc;
            UserLoggedIn.Start();
        }
        else
        {
            Console.WriteLine("No account found with that email and password");
            Menu.Start();
        }
    }
}