class ShowLogic
{
    private static List<ShowModel> _shows;

    public ShowLogic()
    {
        _shows = ShowAccess.LoadAll();
    }
    public ShowModel GetById(int id)
    {
        return _shows.Find(i => i.Id == id);
    }


    public static void AddShow(string date, string time, int roomId, int movieId)
    {
        Console.WriteLine(_shows);
        int count = 0;
        int showId;
        if (_shows == null)
        {
            _shows = ShowAccess.LoadAll();
            showId = 1;
        }

        else
        {
            foreach (ShowModel shows in _shows)
            {
                count++;
            }
            showId = count += 1;
        }
        var show = new ShowModel
        (
            date,
            time,
            roomId,
            movieId,
            showId
        );
        _shows.Add(show);
        ShowAccess.WriteAll(_shows);
    }
    public static void RemoveShow(int movieid, string date, string time)
    {
        if (_shows == null)
        {
            _shows = ShowAccess.LoadAll();
        }
        if (_shows.Find(i => i.MovieId == movieid) == null)
        {
            Console.WriteLine("No show found with that movie id");
        }
        if (_shows.Find(i => i.Date == date) == null)
        {
            Console.WriteLine("No show found with that date");
        }
        if (_shows.Find(i => i.Time == time) == null)
        {
            Console.WriteLine("No show found with that time");
        }
        else
        {
            _shows.Remove(_shows.Find(i => i.MovieId == movieid && i.Date == date && i.Time == time));
            ShowAccess.WriteAll(_shows);
            Console.WriteLine("Show is removed");
        }
    }
}
