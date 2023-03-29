public class MovieLogic
{
    public static int chooseMovie()
    {     // optionList is de lijst met opties. die moet één naam doorgeven naar chooseDate().
        List<string> optionList = new List<string> { "Back" };
        foreach (var item in MoviesAccess.LoadAll())
        {
            optionList.Add(item.Name);
        }
        int optionId;
        // optie lijst geeft 1 string terug hier beneden.
        // optie is hier de naam van de optie in string vorm.
        foreach (var item in MoviesAccess.LoadAll())
        {
            if (item.Name == optie)
            {
                optieId = item.MovieId;
            }
        }
        return optieId;
        // optie MovieName die je kiest
    }

    public static string chooseDate(int optieId)
    {
        List<string> optionList = new List<string> { "Back" };
        foreach (var item in ShowAccess.LoadAll())
        {
            if (optieId == item.MovieId)
            {
                optionList.Add(item.Date);
            }
        }
        return optie; // optie van de datum die je kiest in string
    }

    public static string chooseTime(int optieId, string Date)
    {
        List<string> optionList = new List<string> { "Back" };
        foreach (var item in ShowAccess.LoadAll())
        {
            if (optieId == item.MovieId && Date == item.Date)
            {
                optionList.Add(item.Time);
            }
        }
        return optie; //  optie van de tijd die je kiest in string 
    }

    public static List<string> code()
    {
        List<string> returnList = new List<string>(); // voor de stoelen code
        returnList.Add($"{chooseMovie()}"); // add movie id naar lijst
        returnList.Add($"{chooseDate(chooseMovie())}"); // add show date naar lijst
        returnList.Add($"{chooseTime(chooseMovie(), chooseDate(chooseMovie()))}"); // add show tijd
        foreach (var item in ShowAccess.LoadAll())
        {
            if (chooseMovie() == item.MovieId && (chooseDate(chooseMovie())) == item.Date)
            {
                if ((chooseTime(chooseMovie(), chooseDate(chooseMovie()))) == item.Time)
                {
                    returnList.Add($"{item.RoomId}"); // adds room id naar returnlist
                }
            }
        }
        return returnList; // LIST VOOR DAMI IN STRINGSS!!!!!!!
    }

}