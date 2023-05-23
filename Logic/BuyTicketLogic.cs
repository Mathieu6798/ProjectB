public class BuyTicketLogic
{
    public static string GetTicket(ReservationModel ticket)
    {
        ShowModel show = (ShowAccess.LoadAll()).First(x => x.Id == ticket.ShowId);
        MovieModel movie = (MoviesAccess.LoadAll()).First(x => x.MovieId == show.MovieId);
        string Ticket = $"Ticket: \n Movie: {movie.Name} \n Time: {show.Time} \n Date: {show.Date} \n Seat: ";
        for (int i = 0; i < ticket.Chairs.Count; i++)
        {
            if (i + 1 == ticket.Chairs.Count)
            {
                Ticket += $" {ticket.Chairs[i]}";
            }
            else if (i == 0)
            {
                Ticket += $"{ticket.Chairs[i]},";
            }
            else
            {
                Ticket += $" {ticket.Chairs[i]},";
            }
        }
        return Ticket;
    }
}