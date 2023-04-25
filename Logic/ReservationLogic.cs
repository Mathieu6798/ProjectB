using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;


//This class is not static so later on we can use inheritance and interfaces
class ReservationLogic
{
    private List<ReservationModel> _reservations;

    //Static properties are shared across all instances of the class
    //This can be used to get the current logged in account from anywhere in the program
    //private set, so this can only be set by the class itself

    public ReservationLogic()
    {
        _reservations = ReservationAccess.LoadAll();
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

    public static string GetShowMovieInfo(ReservationModel reservation)
    {
        ShowLogic showlogic = new ShowLogic();
        ShowModel show = showlogic.GetById(reservation.ShowId);
        MovieLogic movielogic = new MovieLogic();
        MovieModel movie = movielogic.GetById(show.MovieId);
        return $"Ticket: \nMovie Name: {movie.Name} \nDate: {show.Date} \nTime: {show.Time}";
    }
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
                options[index] = ReservationLogic.GetShowMovieInfo(i);
                index++;
            }
        }
        Array.Resize(ref options, index + 1);
        options[index] = "Back";
        index++;
        return options;
    }
    public void PrintInformation(List<ReservationModel> reservationlist, int counter)
    {
        ReservationModel reservation = _reservations.Find(i => i == reservationlist[counter]);
        ShowLogic showlogic = new ShowLogic();
        ShowModel show = showlogic.GetById(reservation.ShowId);
        MovieLogic movielogic = new MovieLogic();
        MovieModel movie = movielogic.GetById(show.MovieId);
        Console.WriteLine(ReservationLogic.GetShowMovieInfo(reservation) + $"\nGenre: {movie.Genre} \nInfo: {movie.Info}");
    }
}



