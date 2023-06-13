using System.Globalization;

public class ShowLogic : BasicLogic<ShowModel>
{
    // private static List<ShowModel> _shows;

    public ShowLogic()
    {
        _items = ShowAccess.LoadAll();

    }
    // public ShowModel GetById(int id)
    // {
    //     return _shows.Find(i => i.Id == id);
    // }
    public override void UpdateList(ShowModel acc)
    {
        //Find if there is already an model with the same id
        int index = _items.FindIndex(s => s.Id == acc.Id);

        if (index != -1)
        {
            //update existing model
            _items[index] = acc;
        }
        else
        {
            //add new model
            _items.Add(acc);
        }
        ShowAccess.WriteAll(_items);
    }

    public static void ControlDate_Time(string date, string time, int roomId, int movieId)
    {
        try
        {
            DateTime dateTime = DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture);
            DateTime Time = DateTime.ParseExact(time, "HH:mm", CultureInfo.InvariantCulture);
            bool timeIsOccupied = true;
            foreach (var show in _items)
            {
                if (DateTime.Parse(show.Time) <= Time.AddHours(4))
                {
                    if (DateTime.Parse(show.Time).AddHours(4) >= Time)
                    {
                        if (date == show.Date)
                        {
                            if (show.RoomId == roomId)
                            {
                                System.Console.WriteLine("Already a show in that room. Choose a different room or time");
                                Thread.Sleep(3000);
                                timeIsOccupied = false;
                                AdminEdit.AddShow();
                                break;
                            }
                        }
                    }
                }

            }
            if (timeIsOccupied)
            {
                ShowLogic.AddShow(date, time, roomId, movieId);
            }
        }
        catch (FormatException)
        {
            Console.WriteLine($"\nIncorrect date or time format");
            Console.WriteLine($"The correct format for the date is: dd/mm/yyyy and for time it is: HH:mm\n ");
            Thread.Sleep(3500);
            AdminEdit.AddShow();
        }

    }


    public static void AddShow(string date, string time, int roomId, int movieId)
    {
        //Console.WriteLine(_shows);
        _items = ShowAccess.LoadAll();
        int showId = 0;
        // int count = 0;

        if (_items != null)
        {
            try
            {
                if (_items.LastOrDefault() == null)
                {
                    showId = 1;
                }
                else
                {
                    showId = _items.LastOrDefault().Id;
                }
                // count = _items.Count();
                // showId = count += 1;
                _items.Add(new ShowModel
            (
                date,
                time,
                roomId,
                movieId,
                showId
            ));
                ShowAccess.WriteAll(_items);
            }
            catch (ArgumentNullException)
            {
                showId = 1;
                _items.Add(new ShowModel
            (
                date,
                time,
                roomId,
                movieId,
                showId
            ));
                ShowAccess.WriteAll(_items);
            }
        }
    }
    public static void RemoveShowChoice()
    {
        ShowPresentation.Removeshow(ShowAccess.LoadAll());
    }

    public static string RemoveShow(int id, string date, string time)
    {
        if (_items == null)
        {
            _items = ShowAccess.LoadAll();
        }
        if (_items.Find(i => i.Id == id) == null)
        {
            // Console.WriteLine("No show found with that movie id");
            return "No show found with that movie id";
        }
        if (_items.Find(i => i.Date == date) == null)
        {
            // Console.WriteLine("No show found with that date");
            return "No show found with that date";
        }
        if (_items.Find(i => i.Time == time) == null)
        {
            // Console.WriteLine("No show found with that time");
            return "No show found with that time";
        }
        if (_items.Find(i => i.Id == id) == null || _items.Find(i => i.Date == date) == null || _items.Find(i => i.Time == time) == null)
        {
            // AdminEdit.RemoveShow();
            return null;
        }
        else
        {
            _items.Remove(_items.Find(i => i.Id == id && i.Date == date && i.Time == time));
            ShowAccess.WriteAll(_items);
            // Console.WriteLine("Show is removed");
            return "Show is removed";
        }
    }
}
