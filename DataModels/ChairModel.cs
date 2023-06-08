using System.Text.Json.Serialization;

public class ChairModel : IModel
{
    [JsonPropertyName("id")]
    public int Id { get; set; }
    [JsonPropertyName("rank")]
    public string Rank { get; set; }
    [JsonPropertyName("rownumber")]
    public int Rownumber { get; set; }
    [JsonPropertyName("chairnumber")]
    public int Chairnumber { get; set; }

    public ChairModel(int id, string rank, int rownumber, int chairnumber)
    {
        Id = id;
        Rank = rank;
        Rownumber = rownumber;
        Chairnumber = chairnumber;
    }
}