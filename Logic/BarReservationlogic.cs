public class BarReservationLogic : ReservationLogic
{
    private static int MaxReservations = 40;
    private static int ActualReservations;
    private static List<BarReservationModel> _barreservations;
    public BarReservationLogic()
    {
        _barreservations = BarReservationAccess.LoadAll();
    }
    public BarReservationModel GetById(int id)
    {
        return _barreservations.Find(i => i.ID == id);
    }
    public void UpdateShowReservation(BarReservationModel acc)
    {
        //Find if there is already an model with the same id
        int index = _barreservations.FindIndex(s => s.ID == acc.ID);

        if (index != -1)
        {
            //update existing model
            _barreservations[index] = acc;
        }
        else
        {
            //add new model
            _barreservations.Add(acc);
        }
        ReservationAccess.WriteAll(_reservations);
    }
    public void RemoveBarReservation(int barId)
    {
        BarReservationModel barreservation = _barreservations.FirstOrDefault(x => x.ID == barId);
        _barreservations.Remove(barreservation);
        BarReservationAccess.WriteAll(_barreservations);
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
            var lastbar = _barreservations.LastOrDefault();
            int newid = 0;
            if (lastbar == null)
            {
                newid = 1;
            }
            else
            {
                newid = lastbar.ID + 1;
            }
            BarReservationModel bar = new BarReservationModel(newid, Menu.loggedaccount.FullName, lastReservation.Chairs.Count, show.Time);
            _barreservations.Add(bar);
            BarReservationAccess.WriteAll(_barreservations);
            _reservations.Remove(lastReservation);
            lastReservation.BarReservationID = newid;
            _reservations.Add(lastReservation);
            ReservationAccess.WriteAll(_reservations);
            return true;
        }
        else
        {
            return false;
        }
    }
}