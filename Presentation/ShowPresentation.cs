using System.Globalization;
public class ShowPresentation{
    public static void Removeshow(List<ShowModel> showlist){
        Console.Clear();
        System.Console.WriteLine("Make a choice: \n1: See list of shows \n2: Remove show by id");
        int input = Convert.ToInt32(Console.ReadLine());
        if (input == 1)
        {
            foreach (var show in showlist)
            {
                System.Console.WriteLine($"Show Id:{show.Id}-----------------{show.Date}-----{show.Time}-----Room {show.RoomId}");
            }
            System.Console.WriteLine("\n Press enter to continue");
            string input2 = System.Console.ReadLine()!;
            ShowLogic.RemoveShowChoice();
        }
        else if (input == 2)
        {
            AdminEdit.RemoveShow();
        }
        else
        {
            ShowLogic.RemoveShowChoice();
        }
    }
    public static void ControlDate_Time(string date, string time, int roomId, int movieId)
    {
        Console.Clear();
        try
        {
            DateTime dateTime = DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture);
            DateTime Time = DateTime.ParseExact(time, "HH:mm", CultureInfo.InvariantCulture);
            bool timeIsOccupied = true;
            foreach (var show in ShowAccess.LoadAll())
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
                            }
                        }
                    }
                }

            }
            if (timeIsOccupied)
            {
                ShowLogic.AddShow(date, time, roomId, movieId);
                System.Console.WriteLine("Show has been added!");
                AdminPanel.AdminMenu();

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
}