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
}