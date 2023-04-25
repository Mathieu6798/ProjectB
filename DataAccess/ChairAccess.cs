using System.Text.Json;

static class ChairAccess
{
    static string path = System.IO.Path.GetFullPath(System.IO.Path.Combine(Environment.CurrentDirectory, @"DataSources/accounts.json"));


    public static List<ChairModel> LoadAll()
    {
        string json = File.ReadAllText(path);
        return JsonSerializer.Deserialize<List<ChairModel>>(json);
    }


    public static void WriteAll(List<ChairModel> chairs)
    {
        var options = new JsonSerializerOptions { WriteIndented = true };
        string json = JsonSerializer.Serialize(chairs, options);
        File.WriteAllText(path, json);
    }



}