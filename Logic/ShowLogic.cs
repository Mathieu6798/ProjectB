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
    public static void RemoveShow(string name, string date, string time)
    {
        if (_shows == null)
        {
            _shows = ShowAccess.LoadAll();
        }
        if (_shows.Find(i => i.movieName == name) == null)
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
        if (_shows.Find(i => i.movieName == name) == null || _shows.Find(i => i.Date == date) == null || _shows.Find(i => i.Time == time) == null)
        {
            AdminEdit.RemoveShow();
        }
        else
        {
            _shows.Remove(_shows.Find(i => i.movieName == name && i.Date == date && i.Time == time));
            ShowAccess.WriteAll(_shows);
            Console.WriteLine("Show is removed");
        }
    }
    public static void ControlDate_Time(string date, string time, int roomId, int movieId)
    {
        try
        {
            DateTime dateTime = DateTime.Parse(date);
            DateTime Time = DateTime.ParseExact(time, "HH:mm", CultureInfo.InvariantCulture);
            Console.WriteLine($"TEST FOR SUCCES");
            ShowLogic.AddShow(date, time, roomId, movieId);
        }
        catch (FormatException)
        {
            Console.WriteLine($"Incorrect date or time format");
            Console.WriteLine($"The correct format for the date is: dd/mm/yyyy and for time it is: HH:mm\n ");
            AdminEdit.AddShow();
        }

    }
}
