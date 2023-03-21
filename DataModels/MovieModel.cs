using System.Text.Json.Serialization;


class MovieModel
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("movieName")]
    public string MovieName { get; set; }

    [JsonPropertyName("discription")]
    public string discription { get; set; }

    [JsonPropertyName("room")]
    public int Room { get; set; }

    [JsonPropertyName("genre")]
    public string Genre { get; set; }

    [JsonPropertyName("date")]
    public string Date { get; set; }

    [JsonPropertyName("time")]
    public string Time { get; set; }

    public MovieModel(int id, string movieName, int room, string genre, string date, string time)
    {
        Id = id;
        MovieName = movieName;
        Room = room;
        Genre = genre;
        Date = date;
        Time = time;
    }

}