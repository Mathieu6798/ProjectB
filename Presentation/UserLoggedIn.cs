static class UserLoggedIn
{
    static public AccountModel loggedaccount;


    public static void Start()
    {

        string prompt = @"HOME PAGE";
        string[] options = { "Select a movie", "Account info", "Logout" };
        KeyBoardLogic mainMenu = new KeyBoardLogic(prompt, options);
        int selectedIndex = mainMenu.Run();


        while (loggedaccount == null)
        {
            if (selectedIndex == 0)
            {
                MovieLogic.chooseMovie();
            }
            else if (selectedIndex == 1)
            {
                AccountInfo.Start();
            }
            else if (selectedIndex == 2)
            {
      
                Menu.loggedaccount = null;
                Menu.Start();
            }
            else
            {
                Console.WriteLine("Invalid input");
                Start();
            }
        }
    }
}