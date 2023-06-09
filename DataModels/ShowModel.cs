using System.Text.Json.Serialization;

public class ShowModel : IModel
{
    // [JsonPropertyName("Date")]
    public string Date { get; set; }

    // [JsonPropertyName("Time")]
    public string Time { get; set; }

    // [JsonPropertyName("RoomId")]
    public int RoomId { get; set; }

    // [JsonPropertyName("MovieId")]
    public int MovieId { get; set; }
    // [JsonPropertyName("id")]
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