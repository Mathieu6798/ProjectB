public class BuyTicket
{
    public BuyTicket(int showId, string accountID, List<ChairModel> chairs)
    {
        Overview(new ReservationModel(showId, accountID, chairs));
    }
    public void Overview(ReservationModel ticket)
    {
        string Ticket = $"Ticket: \nShow ID: {ticket.ShowId} \nAccount ID: {ticket.AccountID} \nSeat: {ticket.Chairs}";
        Console.WriteLine(Ticket);
        Console.WriteLine($"Do you want to buy this ticket? Yes or no");
        string choice = Console.ReadLine();
        if (choice.ToLower() == "yes")
        {
            AddToAccount(ticket);
        }
        else
        {
            Menu.Start();
        }
    }
    public void AddToAccount(ReservationModel ticket)
    {
        ReservationLogic logic = new ReservationLogic();
        logic.AddReservation(ticket);
    }
}