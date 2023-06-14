public class MovieLogic : BasicLogic<MovieModel>
{


    public MovieLogic()
    {
        _items = MoviesAccess.LoadAll();
    }
    public override void UpdateList(MovieModel acc)
    {
        int index = _items.FindIndex(s => s.Id == acc.Id);

        if (index != -1)
        {
            _items[index] = acc;
        }
        else
        {
            _items.Add(acc);
        }
        MoviesAccess.WriteAll(_items);
    }

    public MovieModel GetById(int id)
    {
        return _items.Find(i => i.Id == id);
    }


    public static string AddMovie(string title, string genre, int age, double duration, string info)
    {
        try
        {

            int id = 0;
            if (_items.LastOrDefault() == null)
            {
                id = 1;
            }
            else
            {
                id = _items.LastOrDefault().Id + 1;
            }

            var movie = new MovieModel
            (
                id,
                title,
                genre,
                age,
                duration,
                info
            );

            _items.Add(movie);
            MoviesAccess.WriteAll(_items);
            return $"The movie {title} has been added";
        }
        catch (FormatException)
        {
            return $"The movie {title} was not added";
        }
    }


    public static void RemoveMovieChoice()
    {
        MoviePresentation.RemoveMovieChoice(MoviesAccess.LoadAll());
    }


    public static bool Removemovie(string name)

    {
        if (_items.Find(i => i.Name == name) == null)
        {
            return false;


        }
        else
        {
            ShowLogic logic = new();
            foreach (var i in _items)
            {
                if (i.Name == name)
                {
                    logic.Removeshow(i.Id);
                }
            }
            _items.Remove(_items.Find(i => i.Name == name));
            MoviesAccess.WriteAll(_items);
            return true;
        }
    }

    public static void chooseMovie()
    {
        string prompt = @"choose a movie: ";
        List<string> optionList = new List<string> { "Back" };

        List<MovieModel> movielist = new();

        foreach (var item in MoviesAccess.LoadAll())
        {
            optionList.Add(item.Name);
            movielist.Add(item);
        }
        string[] options = optionList.ToArray();
        KeyBoardLogic MovieMenu = new KeyBoardLogic(prompt, options);
        int selectedIndex = MovieMenu.Run();
        int counter = 0;
        if (selectedIndex == 0)
        {
            if (Menu.loggedaccount == null)
            {
                Menu.Start();
            }
            else
            {
                UserLoggedIn.Start();
            }
        }
        else if (selectedIndex > 0)
        {
            foreach (var movie in optionList)
            {
                if (counter == selectedIndex)
                {
                    chooseDateTime(movielist[counter - 1].Id);
                }
                counter++;
            }
        }
    }


    public static void chooseDateTime(int input1)
    {
        string prompt = "Choose a show time:";
        List<string> optionList2 = new List<string> { "Back" };

        List<ShowModel> showlist = new();

        foreach (var show in ShowAccess.LoadAll())
        {
            if (input1 == show.MovieId)
            {
                optionList2.Add($"{show.Date}-----{show.Time}-----Room {show.RoomId}");
                showlist.Add(show);
            }
        }
        string[] options = optionList2.ToArray();
        KeyBoardLogic MovieMenu = new KeyBoardLogic(prompt, options);
        int counter = 0;
        int selectedIndex = MovieMenu.Run();
        if (selectedIndex == 0)
        {
            chooseMovie();
        }
        else if (selectedIndex > 0)
        {
            SeatingChart.Start(showlist[selectedIndex - 1].RoomId, showlist[selectedIndex - 1].Id);
        }
    }
}
