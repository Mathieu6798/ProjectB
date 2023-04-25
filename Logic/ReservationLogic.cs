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
        if (_reservations == null)
        {
            _reservations = ReservationAccess.LoadAll();
        }
        _reservations.Add(ticket);
        ReservationAccess.WriteAll(_reservations);
    }
    public void RemoveReservation(ReservationModel ticket)
    {
        if (_reservations == null)
        {
            _reservations = ReservationAccess.LoadAll();
        }
        _reservations.Add(ticket);
        ReservationAccess.WriteAll(_reservations);
    }
}




