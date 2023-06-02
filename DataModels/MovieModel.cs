using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Text.Json;
class MovieModel : IModel
{
    [JsonPropertyName("MovieId")]
    public int Id { get; set; }

    [JsonPropertyName("Name")]
    public string Name { get; set; }

    [JsonPropertyName("Genre")]
    public string Genre { get; set; }

    [JsonPropertyName("Age")]
    public int Age { get; set; }

    [JsonPropertyName("Info")]
    public string Info { get; set; }

    public MovieModel(int id, string name, string genre, int age, string info)
    {
        Id = id;
        Name = name;
        Genre = genre;
        Age = age;
        Info = info;
    }

}
