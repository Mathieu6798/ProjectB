using System.Globalization;

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

    public static void ControlDate_Time(string date, string time, int roomId, int movieId)
    {
        try
        {
            DateTime dateTime = DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture);
            DateTime Time = DateTime.ParseExact(time, "HH:mm", CultureInfo.InvariantCulture);
            ShowLogic.AddShow(date, time, roomId, movieId);
        }
        catch (FormatException)
        {
            Console.WriteLine($"\nIncorrect date or time format");
            Console.WriteLine($"The correct format for the date is: dd/mm/yyyy and for time it is: HH:mm\n ");
            AdminEdit.AddShow();
        }

    }


    public static void AddShow(string date, string time, int roomId, int movieId)
    {
        //Console.WriteLine(_shows);
        _shows = ShowAccess.LoadAll();
        int showId = 0;
        int count = 0;

        if (_shows != null)
        {
            try
            {
                count = _shows.Count();
                showId = count += 1;
                _shows.Add(new ShowModel
            (
                date,
                time,
                roomId,
                movieId,
                showId
            ));
                ShowAccess.WriteAll(_shows);
            }
            catch (ArgumentNullException)
            {
                showId = 1;
                _shows.Add(new ShowModel
            (
                date,
                time,
                roomId,
                movieId,
                showId
            ));
                ShowAccess.WriteAll(_shows);
            }
        }
    }
    public static void RemoveShow(int id, string date, string time)
    {
        if (_shows == null)
        {
            _shows = ShowAccess.LoadAll();
        }
        if (_shows.Find(i => i.Id == id) == null)
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
        if (_shows.Find(i => i.Id == id) == null || _shows.Find(i => i.Date == date) == null || _shows.Find(i => i.Time == time) == null)
        {
            AdminEdit.RemoveShow();
        }
        else
        {
            _shows.Remove(_shows.Find(i => i.Id == id && i.Date == date && i.Time == time));
            ShowAccess.WriteAll(_shows);
            Console.WriteLine("Show is removed");
        }
    }
}
