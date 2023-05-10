using System.Text.Json.Serialization;


class RoomModel
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("rows")]
    public int Rows { get; set; }

    [JsonPropertyName("columns")]
    public int Columns { get; set; }

    [JsonPropertyName("chairs")]
    public List<int> Chairs { get; set; }

    public RoomModel(int id, int rows, int columns, List<int> chairs)
    {
        Id = id;
        Rows = rows;
        Columns = columns;
        Chairs = chairs;
    }

}




