using System.Text.Json.Serialization;

public class ChairModel
{
    [JsonPropertyName("id")]
    public int ChairId { get; set; }
    [JsonPropertyName("rank")]
    public string Rank { get; set; }
    [JsonPropertyName("rownumber")]
    public int Rownumber { get; set; }
    [JsonPropertyName("chairnumber")]
    public int Chairnumber { get; set; }
    public bool IsBooked { get; set; }

    public ChairModel(int chairid, string rank, int rownumber, int chairnumber)
    {
        ChairId = chairid;
        Rank = rank;
        Rownumber = rownumber;
        Chairnumber = chairnumber;
    }
}