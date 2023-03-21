static class AdminPanel
{
    public static void AdminMenu()
    {
        Console.WriteLine("Welcome to the Admin panel");
        Console.WriteLine("What would you like to do?: ");
        Console.WriteLine("1. Add a movie\n2. Remove a movie\n3. Add a show\n4. Remove a show\nM. Back to the Menu\nQ. Quit program");
        string choice = Console.ReadLine().ToUpper();
        if (choice != null)
        {
            switch (choice)
            {
                case "1":
                    Console.WriteLine("blahblah");
                    break;
                case "2":
                    Console.WriteLine();
                    break;
                case "3":
                    Console.WriteLine();
                    break;
                case "4":
                    Console.WriteLine();
                    break;
                case "M":
                    Menu.Start();
                    break;
                case "Q":
                    Environment.Exit(0);
                    break;
            }
        }
        else
        {
            Console.WriteLine("That was not a option");
            AdminMenu();
        }
    }
}