using System.Text.Json.Serialization;

public class ReservationModel : IModel
{
    public int Id { get; set; }
    public int ShowId { get; set; }

    public int AccountID { get; set; }

    public List<int> Chairs { get; set; }
    public int BarReservationID { get; set; }


    public ReservationModel(int id, int showId, int accountID, List<int> chairs, int barreservationid)
    {
        Id = id;
        ShowId = showId;
        AccountID = accountID;
        Chairs = chairs;
        BarReservationID = barreservationid;
    }
}