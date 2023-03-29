using System.Text.Json.Serialization;

public class ChairModel
{
    [JsonPropertyName("id")]
    public int ChairId { get; set; }
    [JsonPropertyName("rank")]
    public int Rank { get; set; }
    [JsonPropertyName("rownumber")]
    public int Rownumber { get; set; }
    [JsonPropertyName("chairnumber")]
    public int Chairnumber { get; set; }

    public ChairModel(int chairid, int rank, int rownumber, int chairnumber)
    {
        ChairId = chairid;
        Rank = rank;
        Rownumber = rownumber;
        Chairnumber = chairnumber;
    }
}