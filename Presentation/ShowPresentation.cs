public class ShowPresentation{
    public static void Removeshow(List<ShowModel> showlist){
        System.Console.WriteLine("Make a choice: \n1: See list of shows \n2: Remove show by id");
        int input = Convert.ToInt32(Console.ReadLine());
        if (input == 1)
        {
            foreach (var show in showlist)
            {
                System.Console.WriteLine($"Show Id:{show.Id}-----------------{show.Date}-----{show.Time}-----Room {show.RoomId}");
            }
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
}