using System.Text.Json.Serialization;

public class ShowModel : IModel
{
    
    public string Date { get; set; }

    public string Time { get; set; }

    public int RoomId { get; set; }

    public int MovieId { get; set; }
    public int Id { get; set; }


    public ShowModel(string date, string time, int roomId, int movieId, int id)
    {
        Date = date;
        Time = time;
        MovieId = movieId;
        RoomId = roomId;
        Id = id;
    }

}