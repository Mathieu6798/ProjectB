using System.Text.Json.Serialization;

public class ReservationModel
{
    public int ShowId { get; set; }

    public int AccountID { get; set; }

    public List<ChairModel> Chairs { get; set; }


    public ReservationModel(int showId, int accountID, List<ChairModel> chairs)
    {
        ShowId = showId;
        AccountID = accountID;
        Chairs = chairs;
    }
}