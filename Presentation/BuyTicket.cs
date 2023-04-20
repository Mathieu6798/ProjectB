public class BuyTicket
{
    public ReservationModel ticket;
    public BuyTicket(int showId, int accountID, List<int> chairs)
    {
        ticket = new ReservationModel(showId, accountID, chairs);
        // Overview(new ReservationModel(showId, accountID, chairs));
    }
    public void Overview()
    {
        string Ticket = $"Ticket: \nShow ID: {ticket.ShowId} \nAccount ID: {ticket.AccountID} \nSeat: {ticket.Chairs}";
        Console.WriteLine(Ticket);
        Console.WriteLine($"Do you want to buy this ticket? Yes or no");
        string choice = Console.ReadLine();
        if (choice.ToLower() == "yes")
        {
            ReservationLogic logic = new ReservationLogic();
            logic.AddReservation(ticket);
            Console.WriteLine("You have succesfully bought a ticket.");
            Console.WriteLine("Do you want to reserve a ticket at the bar for after the movie? Yes or no");
            string reservebar = Console.ReadLine();
            if (reservebar.ToLower() == "yes")
            {
                //bar cs file voor 40 plekken en tot 2 uur na de film vlgnsmij.
                BarReservation.Start();
            }
            else
            {
                Menu.Start();
            }
        }
        else
        {
            Menu.Start();
        }
    }
}