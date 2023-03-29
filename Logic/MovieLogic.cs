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
    {
        // optionList is de lijst met opties. die moet één naam doorgeven naar chooseDate().
        string[] optionMovies = { "Back" };
        foreach (var item in MoviesAccess.LoadAll())
        {
            optionMovies.Append(item.Name);
        }
        KeyBoardLogic mainMenu = new KeyBoardLogic("Choose a movie", optionMovies);
        int selectedIndex = mainMenu.Run();
        string movieName = optionMovies[selectedIndex];
        int optionId = 0;
        // optie lijst geeft 1 string terug hier beneden.
        // optie is hier de naam van de optie in string vorm.
        foreach (var item in MoviesAccess.LoadAll())
        {
            if (item.Name == movieName)
            {
                optionId = item.MovieId;
                break;
            }
        }
        // optie MovieName die je kiest
        return optionId;
    }


    public static string chooseDate(int optionId)
    {
        string[] optionList = { "Back" };
        foreach (var item in ShowAccess.LoadAll())
        {
            if (optionId == item.MovieId)
            {
                optionList.Append(item.Date);
            }
        }
        KeyBoardLogic mainMenu = new KeyBoardLogic("Choose a movie", optionList);
        int selectedIndex = mainMenu.Run();
        string Date = optionList[selectedIndex];
        return Date; // optie van de datum die je kiest in string
    }

    public static string chooseTime(int optionId, string Date)
    {
        string[] optionList = { "Back" };
        foreach (var item in ShowAccess.LoadAll())
        {
            if (optionId == item.MovieId && Date == item.Date)
            {
                optionList.Append(item.Time);
            }
        }
        KeyBoardLogic mainMenu = new KeyBoardLogic("Choose a movie", optionList);
        int selectedIndex = mainMenu.Run();
        var optie = optionList[selectedIndex];
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