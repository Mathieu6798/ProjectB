using System.Text.Json;
static class BarReservationAccess
{
    static string path = System.IO.Path.GetFullPath(System.IO.Path.Combine(Environment.CurrentDirectory, @"DataSources/barreservation.json"));


    public static List<BarReservationModel> LoadAll()
    {
        try
        {
            string json = File.ReadAllText(path);
            return JsonSerializer.Deserialize<List<BarReservationModel>>(json);
        }
        catch (Exception)
        {
            return new List<BarReservationModel>();
        }
    }


    public static void WriteAll(List<BarReservationModel> barReservations)
    {
        var options = new JsonSerializerOptions { WriteIndented = true };
        string json = JsonSerializer.Serialize(barReservations, options);
        File.WriteAllText(path, json);
    }
    public static void WriteAll(BarReservationModel barReservations)
    {
        var options = new JsonSerializerOptions { WriteIndented = true };
        string json = JsonSerializer.Serialize(barReservations, options);
        File.WriteAllText(path, json);
    }
    public static void WriteAll(AccountModel accounts)
    {
        var options = new JsonSerializerOptions { WriteIndented = true };
        string json = JsonSerializer.Serialize(accounts, options);
        File.WriteAllText(path, json);
    }
}