using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;


//This class is not static so later on we can use inheritance and interfaces
public class ReservationLogic
{
    protected List<ReservationModel> _reservations;
    private int MaxReservations = 40;
    private int ActualReservations;

    //Static properties are shared across all instances of the class
    //This can be used to get the current logged in account from anywhere in the program
    //private set, so this can only be set by the class itself

    public ReservationLogic()
    {
        try
        {
            _reservations = ReservationAccess.LoadAll();
        }
        catch (Exception)
        {
            _reservations = new List<ReservationModel>();
        }

    }

    public int GetLastId()
    {
        int id = 0;
        if (_reservations.LastOrDefault() == null)
        {
            id = 1;
        }
        else
        {
            id = _reservations.LastOrDefault().Id;
        }
        return id;
    }
    public void UpdateShowReservation(ReservationModel acc)
    {
        //Find if there is already an model with the same id
        int index = _reservations.FindIndex(s => s.ShowId == acc.ShowId);

        if (index != -1)
        {
            //update existing model
            _reservations[index] = acc;
        }
        else
        {
            //add new model
            _reservations.Add(acc);
        }
        ReservationAccess.WriteAll(_reservations);
    }

    public ReservationModel GetAccountId(int id)
    {
        return _reservations.Find(i => i.ShowId == id);
    }
    public ReservationModel GetShowId(int id)
    {
        return _reservations.Find(i => i.ShowId == id);
    }
    public void AddReservation(ReservationModel ticket)
    {
        _reservations.Add(ticket);
        ReservationAccess.WriteAll(_reservations);
    }
    public void RemoveReservation(List<ReservationModel> reservationlist, int counter)
    {
        ReservationModel reservation = _reservations.Find(i => i == reservationlist[counter]);
        _reservations.Remove(reservation);
        ReservationAccess.WriteAll(_reservations);
    }
    // public static string GetShowMovieInfo(ReservationModel reservation)
    // {
    //     ShowLogic showlogic = new ShowLogic();
    //     ShowModel show = showlogic.GetById(reservation.ShowId);
    //     MovieLogic movielogic = new MovieLogic();
    //     MovieModel movie = movielogic.GetById(show.MovieId);
    //     return $"Ticket: \nMovie: {movie.Name} \nTime: {show.Time} \nDate: {show.Date}";
    // }
    public string[] MenuOptions(List<ReservationModel> reservationlist)
    {
        string[] options = new string[10];
        AccountModel CurrentAccount = Menu.loggedaccount;
        int index = 0;
        foreach (var i in _reservations)
        {
            if (i.AccountID == CurrentAccount.Id)
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
        ReservationModel reservation = _reservations.Find(i => i == reservationlist[counter]);
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
            return $"{BuyTicketLogic.GetTicket(reservation)} \n Bar reservation: You have a reservation for the bar \n Genre: {movie.Genre} \n Info: {movie.Info}";
        }
    }
    public bool AddBarReservations()
    {
        ReservationModel lastReservation = (_reservations).Last();
        ShowModel show = (ShowAccess.LoadAll()).First(x => x.Id == lastReservation.ShowId);
        MovieModel movie = (MoviesAccess.LoadAll()).First(x => x.Id == show.MovieId);
        foreach (var i in _reservations)
        {
            if (i.BarReservationID != 0)
            {
                ActualReservations += i.Chairs.Count;
            }
        }
        if (ActualReservations + lastReservation.Chairs.Count <= MaxReservations)
        {
            _reservations.Remove(lastReservation);
            lastReservation.BarReservationID = 1;
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





