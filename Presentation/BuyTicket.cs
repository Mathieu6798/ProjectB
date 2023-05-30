public class BuyTicket
{
    public ReservationModel ticket;
    public BuyTicket(int showId, int accountID, List<int> chairs) //, int price
    {
        ticket = new ReservationModel(showId, accountID, chairs, 0);
        // Overview(new ReservationModel(showId, accountID, chairs));
    }
    public void Overview()
    {
        string Ticket = BuyTicketLogic.GetTicket(ticket);
        string prompt1 = $@" {Ticket}          
        Do you want to buy this ticket?";
        string[] options1 = { "Yes", "No" };
        KeyBoardLogic mainMenu1 = new KeyBoardLogic(prompt1, options1);
        int selectedIndex1 = mainMenu1.Run();
        if (selectedIndex1 == 0)
        {
            ReservationLogic logic = new ReservationLogic();
            logic.AddReservation(ticket);
            Console.WriteLine("You have succesfully bought the ticket.");
            Thread.Sleep(3000);
            string prompt2 = $@"Do you want to make a reservation at the bar for after the movie?";
            string[] options2 = { "Yes", "No" };
            KeyBoardLogic mainMenu2 = new KeyBoardLogic(prompt2, options2);
            int selectedIndex2 = mainMenu2.Run();
            if (selectedIndex2 == 0)
            {
                //bar cs file voor 40 plekken en tot 2 uur na de film vlgnsmij.
                // BarReservation.Start();
                Bar();
            }
            else
            {
                UserLoggedIn.Start();
            }
        }
        else
        {
            UserLoggedIn.Start();
        }
    }
    private void Bar()
    {
        ReservationLogic logic = new ReservationLogic();
        var answer = logic.AddBarReservations();
        if (answer == true)
        {
            Console.WriteLine("Your bar reservation has been added.");
            System.Threading.Thread.Sleep(3000);
            UserLoggedIn.Start();
        }
        else if (answer == false)
        {
            Console.WriteLine("There are not enough seats left for this amount of people.");
            System.Threading.Thread.Sleep(3000);
            UserLoggedIn.Start();
        }
    }
}