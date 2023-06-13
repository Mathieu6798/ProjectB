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
";
        string[] options = { "Change Email", "Change Password", "Tickets Info", "Delete Account", "Back" };
        KeyBoardLogic mainMenu = new KeyBoardLogic(prompt, options);
        int selectedIndex = mainMenu.Run();
        switch (selectedIndex)
        {
            case 0:
                Console.WriteLine("What do you want the new email to be?");
                string email = Console.ReadLine();
                while (!email.Contains("@"))
                {
                    Console.WriteLine("Invalid Email");
                    Console.WriteLine("Please enter email adres");
                    email = Console.ReadLine();
                }
                AccountsLogic logic = new AccountsLogic();
                var account = logic.ChangeEmail(email, Menu.loggedaccount);
                if (account != null)
                {
                    Menu.loggedaccount = account;
                    Console.WriteLine("\nEmail has been changed.");
                    System.Threading.Thread.Sleep(3000);
                    Start();
                }
                else
                {
                    Console.WriteLine("\nThis email address already exists.");
                    System.Threading.Thread.Sleep(3000);
                    Start();
                }
                break;
            case 1:
                Console.WriteLine("Type in the old password");
                string oldpassword = "";
                while (true)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    if (key.Key == ConsoleKey.Enter)
                    {
                        break;
                    }
                    else if (key.Key == ConsoleKey.Backspace && oldpassword.Length > 0)
                    {
                        oldpassword = oldpassword.Substring(0, oldpassword.Length - 1);
                        Console.Write("\b \b");
                    }
                    else if (Char.IsLetterOrDigit(key.KeyChar))
                    {
                        oldpassword += key.KeyChar;
                        Console.Write(key.KeyChar);
                        System.Threading.Thread.Sleep(100);
                        Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                        Console.Write("*");
                    }
                }
                if (oldpassword != Menu.loggedaccount.Password)
                {
                    Console.WriteLine("Wrong password");
                    Thread.Sleep(3500);
                    Start();
                }
                Console.WriteLine("\nWhat do you want the new password to be?");
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
                logic = new AccountsLogic();
                var account2 = logic.ChangePassword(password, Menu.loggedaccount);
                if (account2 != null)
                {
                    Menu.loggedaccount = account2;
                    Console.WriteLine("\nPassword has been changed.");
                    System.Threading.Thread.Sleep(3000);
                    Start();
                }
                else
                {
                    Console.WriteLine("\nCan't change the password");
                    System.Threading.Thread.Sleep(3000);
                    Start();
                }
                break;

            case 2:
                ReservationInfo.TicketOptions();
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
                    Menu.loggedaccount = null;
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
                UserLoggedIn.Start();
                break;
        }
    }
}