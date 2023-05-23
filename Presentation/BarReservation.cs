public class BarReservation
{
    private static int MaxReservations = 40;
    private static int ActualReservations;
    private static List<BarReservationModel> _barreservations;
    public static void Start()
    {
        BarReservationLogic logic = new BarReservationLogic();
        var answer = logic.AddBarReservations();
        if (answer == true)
        {
            Console.WriteLine("Your bar reservation has been added.");
            System.Threading.Thread.Sleep(3000);
            UserLoggedIn.Start();
        }
        else if (answer == false)
        {
            Console.WriteLine("There are not enough seats left for this amount of people.");
            System.Threading.Thread.Sleep(3000);
            UserLoggedIn.Start();
        }
    }
}