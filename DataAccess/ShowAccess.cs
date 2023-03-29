using System.Text.Json;
using System;
using System.Collections.Generic;
using System.IO;
static class ShowAccess
{
    static string path = System.IO.Path.GetFullPath(System.IO.Path.Combine(Environment.CurrentDirectory, @"DataSources/show.json"));


    public static List<ShowModel> LoadAll()
    {
        string json = File.ReadAllText(path);
        return JsonSerializer.Deserialize<List<ShowModel>>(json);
    }

    public static void WriteAll(List<ShowModel> shows)
    {
        var options = new JsonSerializerOptions { WriteIndented = true };
        string json = JsonSerializer.Serialize(shows, options);
        File.WriteAllText(path, json);
    }



}