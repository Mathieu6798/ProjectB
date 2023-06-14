using System.Globalization;

public class ShowLogic : BasicLogic<ShowModel>
{
    public ShowLogic()
    {
        _items = ShowAccess.LoadAll();

    }

    public override void UpdateList(ShowModel acc)
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
        ShowAccess.WriteAll(_items);
    }

    public static void ControlDate_Time(string date, string time, int roomId, int movieId)
    {
        ShowPresentation.ControlDate_Time(date, time, roomId, movieId);
    }


    public static void AddShow(string date, string time, int roomId, int movieId)
    {
        _items = ShowAccess.LoadAll();
        int showId = 0;

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
                    showId = _items.LastOrDefault().Id + 1;
                }
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
    public void Removeshow(int movieId)
    {
        ReservationLogic logic = new();
        foreach (var i in _items)
        {
            if (i.MovieId == movieId)
            {
                logic.RemoveReservation(i.Id);
                // _items.Remove(i);
            }
        }
        var removeItems = _items.Where(x => x.MovieId == movieId);
        _items.RemoveAll(x => removeItems.Contains(x));
        ShowAccess.WriteAll(_items);
    }

    public static string RemoveShow(int id, string date, string time)
    {
        if (_items == null)
        {
            _items = ShowAccess.LoadAll();
        }
        if (_items.Find(i => i.MovieId == id) == null)
        {
            return "No show found with that movie id";
        }
        if (_items.Find(i => i.Date == date) == null)
        {
            return "No show found with that date";
        }
        if (_items.Find(i => i.Time == time) == null)
        {
            return "No show found with that time";
        }
        else
        {
            ReservationLogic logic = new();
            foreach (var i in _items)
            {
                if (i.Id == id)
                {
                    logic.RemoveReservation(i.Id);
                }
            }
            var item = _items.Find(i => i.MovieId == id && i.Date == date && i.Time == time);
            _items.Remove(item);
            ShowAccess.WriteAll(_items);
            return "Show is removed";
        }
    }
}
