public class BarReservationLogic : ReservationLogic
{
    private static int MaxReservations = 40;
    private static int ActualReservations;
    private static List<BarReservationModel> _barreservations;
    public BarReservationLogic()
    {
        _barreservations = BarReservationAccess.LoadAll();
    }
    public bool AddBarReservations()
    {
        ReservationModel lastReservation = (_reservations).Last();
        ShowModel show = (ShowAccess.LoadAll()).First(x => x.Id == lastReservation.ShowId);
        MovieModel movie = (MoviesAccess.LoadAll()).First(x => x.MovieId == show.MovieId);
        foreach (var i in _barreservations)
        {
            ActualReservations += i.AmountOfPeople;
        }
        if (ActualReservations + lastReservation.Chairs.Count <= MaxReservations)
        {
            _barreservations.Add(new BarReservationModel(Menu.loggedaccount.FullName, lastReservation.Chairs.Count, show.Time));
            BarReservationAccess.WriteAll(_barreservations);
            return true;
        }
        else
        {
            return false;
        }
    }
}