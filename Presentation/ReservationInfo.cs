public class ReservationInfo
{
    public void CancelTicket()
    {
        string prompt = @"  
 ________  ________  ________   ________  _______   ___        _________  ___  ________  ___  __    _______  _________   
|\   ____\|\   __  \|\   ___  \|\   ____\|\  ___ \ |\  \      |\___   ___\\  \|\   ____\|\  \|\  \ |\  ___ \|\___   ___\ 
\ \  \___|\ \  \|\  \ \  \\ \  \ \  \___|\ \   __/|\ \  \     \|___ \  \_\ \  \ \  \___|\ \  \/  /|\ \   __/\|___ \  \_| 
 \ \  \    \ \   __  \ \  \\ \  \ \  \    \ \  \_|/_\ \  \         \ \  \ \ \  \ \  \    \ \   ___  \ \  \_|/__  \ \  \  
  \ \  \____\ \  \ \  \ \  \\ \  \ \  \____\ \  \_|\ \ \  \____     \ \  \ \ \  \ \  \____\ \  \\ \  \ \  \_|\ \  \ \  \ 
   \ \_______\ \__\ \__\ \__\\ \__\ \_______\ \_______\ \_______\    \ \__\ \ \__\ \_______\ \__\\ \__\ \_______\  \ \__\
    \|_______|\|__|\|__|\|__| \|__|\|_______|\|_______|\|_______|     \|__|  \|__|\|_______|\|__| \|__|\|_______|   \|__|
                                                                                                                                                                                               
        Click on a ticket below to cancel it.";
        List<ReservationModel> reservationlist = new List<ReservationModel>();

        ReservationLogic logic = new ReservationLogic();
        string[] options = logic.MenuOptions(reservationlist);
        KeyBoardLogic mainMenu = new KeyBoardLogic(prompt, options);
        int selectedIndex = mainMenu.Run();
        int counter = 0;
        if (selectedIndex == options.Length - 1)
        {
            // AccountInfo.Start();
            TicketOptions();
        }
        foreach (var i in options)
        {
            if (selectedIndex == counter)
            {
                logic.RemoveReservation(reservationlist, counter);
                Console.WriteLine("Ticket has been removed");
                System.Threading.Thread.Sleep(3000);
                Menu.Start();
            }
            counter++;
        }
    }
    public void ShowTickets()
    {
        string prompt = @"  
 _________  ___  ________  ___  __    _______  _________  ________      
|\___   ___\\  \|\   ____\|\  \|\  \ |\  ___ \|\___   ___\\   ____\     
\|___ \  \_\ \  \ \  \___|\ \  \/  /|\ \   __/\|___ \  \_\ \  \___|_    
     \ \  \ \ \  \ \  \    \ \   ___  \ \  \_|/__  \ \  \ \ \_____  \   
      \ \  \ \ \  \ \  \____\ \  \\ \  \ \  \_|\ \  \ \  \ \|____|\  \  
       \ \__\ \ \__\ \_______\ \__\\ \__\ \_______\  \ \__\  ____\_\  \ 
        \|__|  \|__|\|_______|\|__| \|__|\|_______|   \|__| |\_________\
                                                            \|_________|
                                                                                                                                                                                               
        Click on a ticket below to get their information.";

        List<ReservationModel> reservationlist = new List<ReservationModel>();
        ReservationLogic logic = new ReservationLogic();
        string[] options = logic.MenuOptions(reservationlist);
        KeyBoardLogic mainMenu = new KeyBoardLogic(prompt, options);
        int selectedIndex = mainMenu.Run();
        int counter = 0;
        if (selectedIndex == options.Length - 1)
        {
            // AccountInfo.Start();
            TicketOptions();
        }
        foreach (var i in options)
        {
            if (selectedIndex == counter)
            {
                logic.PrintInformation(reservationlist, counter);
            }
            counter++;
        }
    }
    public void TicketOptions()
    {
        string prompt = @"
 _________  ___  ________  ___  __    _______  _________        ___  ________   ________ ________     
|\___   ___\\  \|\   ____\|\  \|\  \ |\  ___ \|\___   ___\     |\  \|\   ___  \|\  _____\\   __  \    
\|___ \  \_\ \  \ \  \___|\ \  \/  /|\ \   __/\|___ \  \_|     \ \  \ \  \\ \  \ \  \__/\ \  \|\  \   
     \ \  \ \ \  \ \  \    \ \   ___  \ \  \_|/__  \ \  \       \ \  \ \  \\ \  \ \   __\\ \  \\\  \  
      \ \  \ \ \  \ \  \____\ \  \\ \  \ \  \_|\ \  \ \  \       \ \  \ \  \\ \  \ \  \_| \ \  \\\  \ 
       \ \__\ \ \__\ \_______\ \__\\ \__\ \_______\  \ \__\       \ \__\ \__\\ \__\ \__\   \ \_______\
        \|__|  \|__|\|_______|\|__| \|__|\|_______|   \|__|        \|__|\|__| \|__|\|__|    \|_______|
                                                                                                                                                                                       
        Would you like to see you're tickets or remove a ticket?";
        string[] options = { "Tickets", "Cancel Ticket", "Back" };
        KeyBoardLogic mainMenu = new KeyBoardLogic(prompt, options);
        int selectedIndex = mainMenu.Run();
        if (selectedIndex == 0)
        {
            ShowTickets();
        }
        else if (selectedIndex == 1)
        {
            CancelTicket();
        }
        else if (selectedIndex == 2)
        {
            AccountInfo.Start();
        }
        else
        {
            Console.WriteLine("Invalid input");
            Menu.Start();
        }
    }
}