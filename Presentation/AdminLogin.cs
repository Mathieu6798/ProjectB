static class AdminLogin
{
    static private AdminLogic adminLogic = new AdminLogic();


    public static void Start()
    {
        Console.WriteLine("Welcome to the Admin login page");
        Console.WriteLine("Please enter the admin email address");
        string email = Console.ReadLine();
        Console.WriteLine("Please enter the admin password");
        string password = Console.ReadLine();
        AdminAccountModel acc = adminLogic.CheckLogin(email, password);
        if (acc != null)
        {
            Console.WriteLine("Welcome back " + acc.FullName);
            Console.WriteLine("Your email number is " + acc.EmailAddress);
            AdminPanel.AdminMenu();
            //Write some code to go back to the menu
            //Menu.Start();
        }
        else
        {
            Console.WriteLine("No account found with that email and password\n");
            Menu.Start();
        }
    }
}