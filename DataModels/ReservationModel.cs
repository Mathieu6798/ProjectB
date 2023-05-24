using System.Text.Json.Serialization;

public class ReservationModel
{
    public int ShowId { get; set; }

    public int AccountID { get; set; }

    public List<int> Chairs { get; set; }
    public int BarReservationID { get; set; }


    public ReservationModel(int showId, int accountID, List<int> chairs, int barreservationid)
    {
        ShowId = showId;
        AccountID = accountID;
        Chairs = chairs;
        BarReservationID = barreservationid;
    }
}