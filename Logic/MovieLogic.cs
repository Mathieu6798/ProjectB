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

    public static void chooseMovie()
    {
        // while (optie1 == null)
        List<string> optionList = new List<string> { "Back" };
        foreach (var item in MoviesAccess.LoadAll())
        {
            optionList.Add(item.Name);
        }
        int input1 = -2;
        while (input1 < 0 || input1 >= optionList.Count)
        {
            Console.Clear();
            System.Console.WriteLine("Choose a option by typing the number");
            System.Console.WriteLine($"0: {optionList[0]}");
            for (int i = 1; i < optionList.Count; i++)
            {
                System.Console.WriteLine($"{i}: {optionList[i]}");
            }
            input1 = Convert.ToInt32(System.Console.ReadLine());
        }
        if (input1 == 0)
        {
            Menu.Start();
        }
        else
        {
            chooseDateTime(input1);
        }
    }
    ///////////////////////////////////////////////////////////////// geeft optie 1
    public static void chooseDateTime(int input1)
    {
        List<string> optionList2 = new List<string> { "Back" };
        foreach (var show in ShowAccess.LoadAll())
        {
            if (input1 == show.MovieId)
            {
                optionList2.Add($"{show.Date}-----{show.Time}-----Room {show.RoomId}");
            }
        }
        ////////////////////////////////////////////////////// optie 2      
        int input2 = -3;
        while (input2 < 0 || input2 >= optionList2.Count)
        {
            Console.Clear();
            System.Console.WriteLine("Choose a option by typing the number");
            System.Console.WriteLine($"0: {optionList2[0]}");
            for (int i = 1; i < optionList2.Count; i++)
            {
                System.Console.WriteLine($"{i}: {optionList2[i]}");
            }
            input2 = Convert.ToInt32(System.Console.ReadLine());
        }
        if (input2 == 0)
        {
            chooseMovie();
        }
        else
        {
            System.Console.WriteLine("OK");
            Menu.Start();
            RoomLogic.Start(input2);
            //functieDami(ShowId);////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        }
    }
}