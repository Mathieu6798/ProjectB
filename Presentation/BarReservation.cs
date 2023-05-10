public class BarReservation
{
    private static int MaxReservations = 40;
    private static int ActualReservations;
    private static List<BarReservationModel> _barreservations;
    public static void Start()
    {
        ReservationModel lastReservation = (ReservationAccess.LoadAll()).LastOrDefault();
        ShowModel show = (ShowAccess.LoadAll()).FirstOrDefault(x => x.Id == lastReservation.ShowId);
        try
        {
            _barreservations = BarReservationAccess.LoadAll();
        }
        catch (Exception)
        {
            _barreservations = new List<BarReservationModel>();
        }
        foreach (var i in _barreservations)
        {
            ActualReservations += i.AmountOfPeople;
        }
        if (MaxReservations - ActualReservations == 0 || MaxReservations - ActualReservations < 0)
        {
            Console.WriteLine("There no more available seats left.");
            System.Threading.Thread.Sleep(3000);
            Menu.Start();
        }
        Console.WriteLine("What name do you want to reserve for");
        string name = Console.ReadLine();
        while (name == null || name.Length < 1)
        {
            Console.WriteLine("Put in a name");
            name = Console.ReadLine();
        }
        Console.WriteLine("For how many people do you want to make a reservation?");
        Console.WriteLine($"There are {MaxReservations - ActualReservations} seats left.");
        int people = Convert.ToInt32(Console.ReadLine());
        if (ActualReservations + people <= MaxReservations)
        {
            _barreservations.Add(new BarReservationModel(name, people, show.Time));
            BarReservationAccess.WriteAll(_barreservations);
            Console.WriteLine("Your reservation has been added.");
            System.Threading.Thread.Sleep(3000);
            Menu.Start();
        }
        else
        {
            while (ActualReservations + people > MaxReservations)
            {
                Console.WriteLine("There are not enough seats left for this amount of people.");
                Console.WriteLine($"There are {MaxReservations - ActualReservations} seats left.");
                people = Convert.ToInt32(Console.ReadLine());
            }
            _barreservations.Add(new BarReservationModel(name, people, show.Time));
            BarReservationAccess.WriteAll(_barreservations);
            Console.WriteLine("Your reservation has been added.");
            System.Threading.Thread.Sleep(3000);
            UserLoggedIn.Start();
        }
    }
}