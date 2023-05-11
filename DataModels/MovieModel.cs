using System.Text.Json.Serialization;

class MovieModel
{
    // [JsonPropertyName("id")]
    public int MovieId { get; set; }

    // [JsonPropertyName("movieName")]
    public string Name { get; set; }

    // [JsonPropertyName("genre")]
    public string Genre { get; set; }

    // [JsonPropertyName("dateTimeRoom")]
    public int Age { get; set; }

    // [JsonPropertyName("info")]
    public string Info { get; set; }


    public MovieModel(int movieId, string name, string genre, int age, string info)
    {
        MovieId = movieId;
        Name = name;
        Genre = genre;
        Age = age;
        Info = info;
    }

}