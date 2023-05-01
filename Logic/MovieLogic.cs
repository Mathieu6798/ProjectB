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


    public static void Removemovie(string name)
    {
        if (_movies.Find(i => i.Name == name) == null)
        {
            Console.WriteLine("No movie found with that name");
            AdminEdit.RemoveMovie();
        }
        else
        {
            _movies.Remove(_movies.Find(i => i.Name == name));
            MoviesAccess.WriteAll(_movies);
            Console.WriteLine("The movie has been removed");
            // AdminPanel.AdminMenu();
        }
    }

    public static int chooseMovie()
    {
        List<string> optionList = new List<string> { "Back" };
        foreach (var item in _movies)
        {
            optionList.Add(item.Name);
        }
        ///////////////////////////////////////////////////////////////// geef optie 1
        string[] options1 = optionList.ToArray();
        KeyBoardLogic mainMenu = new KeyBoardLogic("Choose a movie", options1);
        int selectedIndex = mainMenu.Run();
        var optie1 = options1[selectedIndex];
        int optieId = 0;
        // optie lijst geeft 1 string terug hier beneden.
        // optie is hier de naam van de optie in string vorm.
        foreach (var item in _movies)
        {
            if (item.Name == optie1)
            {
                optieId = item.MovieId;
            }
        }

        List<string> optionList2 = new List<string> { "Back" };
        foreach (var show in ShowAccess.LoadAll())
        {
            if (optieId == show.MovieId)
            {
                optionList2.Add(show.Date);
            }
        }
        ////////////////////////////////////////////////////// optie 2
        string[] options2 = optionList2.ToArray();
        KeyBoardLogic mainMenu2 = new KeyBoardLogic("Choose a date", options2);
        int selectedIndex2 = mainMenu2.Run();
        var optie2 = options2[selectedIndex2];

        List<string> optionList3 = new List<string> { "Back" };
        foreach (var show in ShowAccess.LoadAll())
        {
            if (optieId == show.MovieId && optie2 == show.Date)
            {
                optionList3.Add(show.Time);
            }
        }
        ////////////////////////////////////// optie 3
        string[] options3 = optionList3.ToArray();
        KeyBoardLogic mainMenu3 = new KeyBoardLogic("Choose a time", options3);
        int selectedIndex3 = mainMenu3.Run();
        var optie3 = options3[selectedIndex3];

        int ShowId = 0;
        foreach (var show in ShowAccess.LoadAll())
        {
            if (optieId == show.MovieId && optie2 == show.Date && optie3 == show.Time)
            {
                ShowId = show.Id;
            }
        }


        return ShowId; // LIST VOOR DAMI IN STRINGSS!!!!!!!
    }
    public MovieModel GetById(int id)
    {
        return _movies.Find(i => i.MovieId == id);
    }


}