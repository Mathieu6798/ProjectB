class MovieLogic
{
    private static List<MovieModel> _movies;

    public MovieLogic()
    {
        _movies = MoviesAccess.LoadAll();
    }



    public static void AddMovie(string title, string genre, int age, string info)
    {
        int count = 0;
        int id;
        if (_movies == null)
        {
            _movies = MoviesAccess.LoadAll();
        }
        foreach (MovieModel _movies in _movies)
        {
            count++;
        }
        id = count += 1;

        var movie = new MovieModel
        (
            id,
            title,
            genre,
            age,
            info
        );

        _movies.Add(movie);
        MoviesAccess.WriteAll(_movies);
    }


    public static void Removemovie(int id)
    {
        if (_movies.Find(i => i.MovieId == id) == null)
        {
            Console.WriteLine("No movie found with that name");
            // AdminPanel.AdminMenu();
        }
        else
        {
            _movies.Remove(_movies.Find(i => i.MovieId == id));
            MoviesAccess.WriteAll(_movies);
            Console.WriteLine("The movie has been removed");
            // AdminPanel.AdminMenu();
        }
    }

    public static int chooseMovie()
    {     // optionList is de lijst met opties. die moet één naam doorgeven naar chooseDate().
        List<string> optionList = new List<string> { "Back" };
        foreach (var item in MoviesAccess.LoadAll())
        {
            optionList.Add(item.Name);
        }
        string[] ListMovies = optionList.ToArray();
        KeyBoardLogic mainMenu = new KeyBoardLogic("Choose a movie", ListMovies);
        int selectedIndex = mainMenu.Run();
        var optie = ListMovies[selectedIndex];
        int optionId = 0;
        // optie lijst geeft 1 string terug hier beneden.
        // optie is hier de naam van de optie in string vorm.
        foreach (var item in MoviesAccess.LoadAll())
        {
            if (item.Name == optie)
            {
                optionId = item.MovieId;
            }
        }
        return optionId;
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
        string[] ListDates = optionList.ToArray();
        KeyBoardLogic mainMenu = new KeyBoardLogic("Choose a date", ListDates);
        int selectedIndex = mainMenu.Run();
        var optie = ListDates[selectedIndex];
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
        string[] ListTimes = optionList.ToArray();
        KeyBoardLogic mainMenu = new KeyBoardLogic("Choose a time", ListTimes);
        int selectedIndex = mainMenu.Run();
        var optie = ListTimes[selectedIndex];
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