
using System.Text.Json.Serialization;
class BarReservationModel
{
    [JsonPropertyName("Name")]
    public string Name { get; set; }

    [JsonPropertyName("AmountOfPeople")]
    public int AmountOfPeople { get; set; }

    [JsonPropertyName("ShowTime")]
    public string ShowTime { get; set; }

    public BarReservationModel(string name, int amountOfPeople, string showTime)
    {
        Name = name;
        AmountOfPeople = amountOfPeople;
        ShowTime = showTime;
    }

}




