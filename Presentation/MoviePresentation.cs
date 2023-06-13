public static class MoviePresentation{
    public static void RemoveMovieChoice(List<MovieModel> movieList)
        {
            System.Console.WriteLine("Make a choice: \n1: See list of movies \n2: Remove movie by name");
            int input = Convert.ToInt32(Console.ReadLine());
            if (input == 1)
            {
                int totalLength = 30;
                char paddingChar = '-';
                foreach (var item in movieList)
                {
                    string formattedString = $"{item.Name}: {item.Genre}".PadLeft(totalLength, paddingChar);
                    System.Console.WriteLine(formattedString);
                }
                string input2 = System.Console.ReadLine();
                MovieLogic.RemoveMovieChoice();
            }
            else if (input == 2)
            {
                AdminEdit.RemoveMovie();
            }
            else
            {
                MovieLogic.RemoveMovieChoice();
            }
    }
    
}