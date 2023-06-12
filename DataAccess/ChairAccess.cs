using System.Text.Json;

static class ChairAccess
{
    static string path = System.IO.Path.GetFullPath(System.IO.Path.Combine(Environment.CurrentDirectory, @"DataSources/Chairs.json"));


    public static List<ChairModel> LoadAll()
    {
        try
        {
            string json = File.ReadAllText(path);
            return JsonSerializer.Deserialize<List<ChairModel>>(json);
        }
        catch (Exception)
        {
            return new List<ChairModel>();
        }
    }


    public static void WriteAll(List<ChairModel> chairs)
    {
        var options = new JsonSerializerOptions { WriteIndented = true };
        string json = JsonSerializer.Serialize(chairs, options);
        File.WriteAllText(path, json);
    }



}