static class Menu
{
    static public AccountModel loggedaccount;

    //This shows the menu. You can call back to this method to show the menu again
    //after another presentation method is completed.
    //You could edit this to show different menus depending on the user's role
    static public void Start()
    {
        string prompt = @"
   ___           _           _     ___ 
  / _ \_ __ ___ (_) ___  ___| |_  / __\
 / /_)/ '__/ _ \| |/ _ \/ __| __|/__\//
/ ___/| | | (_) | |  __/ (__| |_/ \/  \
\/    |_|  \___// |\___|\___|\__\_____/
              |__/                     

        Welcome to the Cinema";
        string[] options = { "Login", "Register Account", "Select a movie", "Do Someting else" };
        KeyBoardLogic mainMenu = new KeyBoardLogic(prompt, options);
        int selectedIndex = mainMenu.Run();


        while (loggedaccount == null)
        {
            if (selectedIndex == 0)
            {
                UserLogin.Start();
            }
            else if (selectedIndex == 1)
            {
                UserRegister.Start();
            }
            else if (selectedIndex == 2)
            {
                Console.WriteLine("Select movie");
            }
            else if (selectedIndex == 3)
            {
                Console.WriteLine("This feature is not yet implemented");
            }
            else
            {
                Console.WriteLine("Invalid input");
                Start();
            }


        }
        if (loggedaccount.EmailAddress == "admin@admin678.nl")
        {
            string promptAdmin = "Welcome Admin";
            string[] optionsAdmin = { "Add a movie", "Add a show", "Remove a movie", "Remove a show", "Do Something else" };
            KeyBoardLogic adminMenu = new KeyBoardLogic(promptAdmin, optionsAdmin);
            int selectedIndexAdmin = adminMenu.Run();
            if (selectedIndexAdmin == 0)
            {
                Console.WriteLine("What is the title?");
                string title = Console.ReadLine();
                Console.WriteLine("What is the genre?");
                string genre = Console.ReadLine();
                Console.WriteLine("What is the minimum age?");
                string input_age = Console.ReadLine();
                int age = Convert.ToInt32(input_age);
                Console.WriteLine("What is the description?");
                string info = Console.ReadLine();
                MovieLogic.AddMovie(title, genre, age, info);

            }
            else if (selectedIndexAdmin == 1)
            {
                Console.WriteLine("What is the date?");
                string date = Console.ReadLine();
                Console.WriteLine("What is the genre?");
                string time = Console.ReadLine();
                Console.WriteLine("What is the minimum age?");
                string input_roomid = Console.ReadLine();
                int roomId = Convert.ToInt32(input_roomid);
                Console.WriteLine("What is the description?");
                string movie_id = Console.ReadLine();
                int movieId = Convert.ToInt32(movie_id);
                ShowLogic.AddShow(date, time, roomId, movieId);
            }
            else if (selectedIndexAdmin == 2)
            {
                Console.WriteLine("Remove movie");
            }
            else if (selectedIndexAdmin == 3)
            {
                Console.WriteLine("Remove show");
            }
            else if (selectedIndexAdmin == 4)
            {
                Console.WriteLine("This feature is not yet implemented");
            }
            else
            {
                Console.WriteLine("Invalid input");
                Start();
            }
        }
        else
        {
            if (selectedIndex == 0)
            {
                UserLogin.Start();
            }
            else if (selectedIndex == 1)
            {
                UserRegister.Start();
            }
            else if (selectedIndex == 2)
            {
                Console.WriteLine("Select movie");
            }
            else if (selectedIndex == 3)
            {
                Console.WriteLine("This feature is not yet implemented");
            }
            else
            {
                Console.WriteLine("Invalid input");
                Start();
            }
        }

    }
}
