using System.Text.Json;

static class AdminAccountsAccess
{
    static string path = System.IO.Path.GetFullPath(System.IO.Path.Combine(Environment.CurrentDirectory, @"DataSources/AdminAccounts.json"));


    public static List<AdminAccountModel> LoadAll()
    {
        string json = File.ReadAllText(path);
        return JsonSerializer.Deserialize<List<AdminAccountModel>>(json);
    }


    public static void WriteAll(List<AdminAccountModel> AdminAccounts)
    {
        var options = new JsonSerializerOptions { WriteIndented = true };
        string json = JsonSerializer.Serialize(AdminAccounts, options);
        File.WriteAllText(path, json);
    }



}