public static class AccountInfo
{
    public static void Start()
    {
        string prompt = $@"

   _____                                   __    .___        _____       
  /  _  \   ____  ____  ____  __ __  _____/  |_  |   | _____/ ____\____  
 /  /_\  \_/ ___\/ ___\/  _ \|  |  \/    \   __\ |   |/    \   __\/  _ \ 
/    |    \  \__\  \__(  <_> )  |  /   |  \  |   |   |   |  \  | (  <_> )
\____|__  /\___  >___  >____/|____/|___|  /__|   |___|___|  /__|  \____/ 
        \/     \/    \/                 \/                \/                            

        Welcome {Menu.loggedaccount.FullName} to your account.";
        string[] options = { "Change Email", "Change Password", "Tickets Info", "Delete Account", "Back" };
        KeyBoardLogic mainMenu = new KeyBoardLogic(prompt, options);
        int selectedIndex = mainMenu.Run();
        switch (selectedIndex)
        {
            case 0:
                //change email
                Console.WriteLine("What would you like to change youre email to?");
                string email = Console.ReadLine();
                while (!email.Contains("@"))
                {
                    Console.WriteLine("Invalid Email");
                    Console.WriteLine("Please enter email adres");
                    email = Console.ReadLine();
                }
                AccountsLogic logic = new AccountsLogic();
                logic.ChangeEmail(email);
                break;
            case 1:
                //change password
                Console.WriteLine("What would you like to change youre password to?");
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
                logic = new AccountsLogic();
                logic.ChangePassword(password);
                break;

            case 2:
                //show tickets
                ReservationInfo info = new ReservationInfo();
                info.TicketOptions();
                break;
            case 3:
                string prompt2 = @"Are you sure you want to delete this account?";
                string[] options2 = { "Yes", "No" };
                KeyBoardLogic mainMenu2 = new KeyBoardLogic(prompt2, options2);
                int selectedIndex2 = mainMenu2.Run();
                if (selectedIndex2 == 0)
                {
                    Console.WriteLine("Type the password of the account in for comfirmation");
                    string choice = Console.ReadLine();
                    while (choice != Menu.loggedaccount.Password)
                    {
                        Console.WriteLine("Wrong password");
                        choice = Console.ReadLine();
                    }
                    AccountsLogic accountlogic = new AccountsLogic();
                    accountlogic.DeleteAccount(Menu.loggedaccount);
                    Console.WriteLine("The account has been deleted.");
                    Thread.Sleep(3500);
                    Menu.Start();
                }
                else
                {
                    UserLoggedIn.Start();
                }
                break;
            case 4:
                // go back
                UserLoggedIn.Start();
                break;
        }
    }
}