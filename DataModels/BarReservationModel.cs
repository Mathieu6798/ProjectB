
using System.Text.Json.Serialization;
public class BarReservationModel
{
    [JsonPropertyName("ID")]
    public int ID { get; set; }
    [JsonPropertyName("Name")]
    public string Name { get; set; }

    [JsonPropertyName("AmountOfPeople")]
    public int AmountOfPeople { get; set; }

    [JsonPropertyName("ShowTime")]
    public string ShowTime { get; set; }

    public BarReservationModel(int id, string name, int amountOfPeople, string showTime)
    {
        ID = id;
        Name = name;
        AmountOfPeople = amountOfPeople;
        ShowTime = showTime;
    }

}




