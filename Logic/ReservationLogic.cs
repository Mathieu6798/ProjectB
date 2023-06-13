using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Globalization;


//This class is not static so later on we can use inheritance and interfaces
public class ReservationLogic : BasicLogic<ReservationModel>
{
    // protected List<ReservationModel> _items;
    private int MaxReservations = 40;
    private int ActualReservations;

    //Static properties are shared across all instances of the class
    //This can be used to get the current logged in account from anywhere in the program
    //private set, so this can only be set by the class itself

    public ReservationLogic()
    {
        try
        {
            _items = ReservationAccess.LoadAll();
        }
        catch (Exception)
        {
            _items = new List<ReservationModel>();
        }

    }

    public int GetLastId()
    {
        int id = 0;
        if (_items.LastOrDefault() == null)
        {
            id = 1;
        }
        else
        {
            id = _items.LastOrDefault().Id;
        }
        return id;
    }
    public override void UpdateList(ReservationModel acc)
    {
        //Find if there is already an model with the same id
        int index = _items.FindIndex(s => s.ShowId == acc.ShowId);

        if (index != -1)
        {
            //update existing model
            _items[index] = acc;
        }
        else
        {
            //add new model
            _items.Add(acc);
        }
        ReservationAccess.WriteAll(_items);
    }

    // public ReservationModel GetAccountId(int id)
    // {
    //     return _items.Find(i => i.AccountID == id);
    // }
    // public ReservationModel GetShowId(int id)
    // {
    //     return _items.Find(i => i.ShowId == id);
    // }
    public void AddReservation(ReservationModel ticket)
    {
        _items.Add(ticket);
        ReservationAccess.WriteAll(_items);
    }
    public void RemoveReservation(List<ReservationModel> reservationlist, int counter)
    {
        ReservationModel reservation = _items.Find(i => i == reservationlist[counter]);
        _items.Remove(reservation);
        ReservationAccess.WriteAll(_items);
    }
    // public static string GetShowMovieInfo(ReservationModel reservation)
    // {
    //     ShowLogic showlogic = new ShowLogic();
    //     ShowModel show = showlogic.GetById(reservation.ShowId);
    //     MovieLogic movielogic = new MovieLogic();
    //     MovieModel movie = movielogic.GetById(show.MovieId);
    //     return $"Ticket: \nMovie: {movie.Name} \nTime: {show.Time} \nDate: {show.Date}";
    // }
    public string[] MenuOptions(List<ReservationModel> reservationlist, AccountModel currentaccount)
    {
        string[] options = new string[10];
        // AccountModel CurrentAccount = Menu.loggedaccount;
        int index = 0;
        foreach (var i in _items)
        {
            if (i.AccountID == currentaccount.Id)
            {
                Array.Resize(ref options, index + 1);
                reservationlist.Add(i);
                options[index] = BuyTicketLogic.GetTicket(i);
                index++;
            }
        }
        Array.Resize(ref options, index + 1);
        options[index] = "Back";
        index++;
        return options;
    }

    public string GetInformation(List<ReservationModel> reservationlist, int counter)
    {
        ReservationModel reservation = _items.Find(i => i == reservationlist[counter]);
        ShowLogic showlogic = new ShowLogic();
        ShowModel show = showlogic.GetById(reservation.ShowId);
        MovieLogic movielogic = new MovieLogic();
        MovieModel movie = movielogic.GetById(show.MovieId);
        string chairs = "";
        for (int i = 0; i < reservation.Chairs.Count; i++)
        {
            if (i + 1 == reservation.Chairs.Count)
            {
                chairs += $" {reservation.Chairs[i]}";
            }
            else if (i == 0)
            {
                chairs += $"{reservation.Chairs[i]},";
            }
            else
            {
                chairs += $" {reservation.Chairs[i]},";
            }
        }
        if (reservation.BarReservationID == 0)
        {
            return $"{BuyTicketLogic.GetTicket(reservation)} \n Bar reservation: You don't have a reservation for the bar \n Genre: {movie.Genre} \n Info: {movie.Info}";
        }
        else
        {
            // show.Time.Split(":");
            int additionalMinutes = (int)movie.Duration;
            // string timeString = "13:50";
            DateTime dateTime = DateTime.ParseExact(show.Time, "HH:mm", CultureInfo.InvariantCulture);
            DateTime newDateTime = dateTime.AddMinutes(additionalMinutes);
            return $"{BuyTicketLogic.GetTicket(reservation)} \n Bar reservation: You have a reservation for the bar at {newDateTime.ToString("HH:mm")}. Your reservation expires at {newDateTime.AddMinutes(120).ToString("HH:mm")}. \n Genre: {movie.Genre} \n Info: {movie.Info}";
        }
    }
    public bool AddBarReservations(ReservationModel ticket)
    {
        // ReservationModel lastReservation = (_items).Last();

        // ShowModel show = (ShowAccess.LoadAll()).First(x => x.Id == lastReservation.ShowId);
        // MovieModel movie = (MoviesAccess.LoadAll()).First(x => x.Id == show.MovieId);
        // ShowLogic showlogic = new ShowLogic();
        // ShowModel show = showlogic.GetById(lastReservation.ShowId);
        // MovieLogic movielogic = new MovieLogic();
        // MovieModel movie = movielogic.GetById(show.MovieId);
        foreach (var i in _items)
        {
            if (i.BarReservationID != 0)
            {
                ActualReservations += i.Chairs.Count;
            }
        }
        if (ActualReservations + ticket.Chairs.Count <= MaxReservations)
        {
            _items.Remove(ticket);
            ticket.BarReservationID = 1;
            _items.Add(ticket);
            ReservationAccess.WriteAll(_items);
            return true;
        }
        else
        {
            return false;
        }
    }
}





