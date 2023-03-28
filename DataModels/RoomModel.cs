using System.Text.Json.Serialization;


class RoomModel
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("rows")]
    public int Rows { get; set; }

    [JsonPropertyName("columns")]
    public int Columns { get; set; }

    public RoomModel(int id, int rows, int columns)
    {
        Id = id;
        Rows = rows;
        Columns = columns;
    }

}




