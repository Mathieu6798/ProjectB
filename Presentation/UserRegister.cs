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
        string password = Console.ReadLine();
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
            Thread.Sleep(3500);
            Menu.Start();
        }
        else
        {
            accountsLogic.AddAcount(name, email, password);
            Console.WriteLine("Youre account has been added");
            Thread.Sleep(3500);
            Menu.Start();
        }
    }
}