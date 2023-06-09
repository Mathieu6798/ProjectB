using System.Text.Json;

static class AccountsAccess
{
    static string path = System.IO.Path.GetFullPath(System.IO.Path.Combine(Environment.CurrentDirectory, @"DataSources/accounts.json"));
    // static string path = System.IO.Path.GetFullPath(@"C:\Users\Mathieu\Documents\GitHub\ProjectB\DataSources\accounts.json");
    public static List<AccountModel> LoadAll()
    {
        try
        {
            string json = File.ReadAllText(path);
            return JsonSerializer.Deserialize<List<AccountModel>>(json);
        }
        catch (Exception)
        {
            return new List<AccountModel>();
        }
    }


    public static void WriteAll(List<AccountModel> accounts)
    {
        var options = new JsonSerializerOptions { WriteIndented = true };
        string json = JsonSerializer.Serialize(accounts, options);
        File.WriteAllText(path, json);
    }



}