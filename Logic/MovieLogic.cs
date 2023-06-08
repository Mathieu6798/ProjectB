class MovieLogic : BasicLogic<MovieModel>
{
    // private static List<MovieModel> _items;


    public MovieLogic()
    {
        _items = MoviesAccess.LoadAll();
    }
    public override void UpdateList(MovieModel acc)
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
        MoviesAccess.WriteAll(_items);
    }

    public MovieModel GetById(int id)
    {
        return _items.Find(i => i.Id == id);
    }


    public static bool AddMovie(string title, string genre, int age, string info)
    {
        try
        {
            int count = 0;
            int id;
            if (_items == null)
            {
                _items = MoviesAccess.LoadAll();
            }
            foreach (MovieModel _items in _items)
            {
                count++;
            }
            id = count += 1;

            var movie = new MovieModel
            (
                id,
                title,
                genre,
                age,
                info
            );

            _items.Add(movie);
            MoviesAccess.WriteAll(_items);
            return true;
        }
        catch (FormatException)
        {
            return false;
        }
    }


    public static void RemoveMovieChoice()
    {
        System.Console.WriteLine("Make a choice: \n1: See list of movies \n2: Remove movie by name");
        int input = Convert.ToInt32(Console.ReadLine());
        if (input == 1)
        {
            int totalLength = 30;
            char paddingChar = '-';
            foreach (var item in MoviesAccess.LoadAll())
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


    public static bool Removemovie(string name)

    {
        if (_items.Find(i => i.Name == name) == null)
        {
            //Console.WriteLine("No movie found with that name");
            return false;


        }
        else
        {
            _items.Remove(_items.Find(i => i.Name == name));
            MoviesAccess.WriteAll(_items);
            return true;
            //Console.WriteLine("The movie has been removed");
            // AdminPanel.AdminMenu();
        }
    }

    public static void chooseMovie()
    {
        // while (optie1 == null)
        //     List<string> optionList = new List<string> { "Back" };
        //     foreach (var item in MoviesAccess.LoadAll())
        //     {
        //         optionList.Add(item.Name);
        //     }
        //     int input1 = -2;
        //     while (input1 < 0 || input1 >= optionList.Count)
        //     {
        //         Console.Clear();
        //         System.Console.WriteLine("Choose a option by typing the number");
        //         System.Console.WriteLine($"0: {optionList[0]}");
        //         for (int i = 1; i < optionList.Count; i++)
        //         {
        //             System.Console.WriteLine($"{i}: {optionList[i]}");
        //         }
        //         input1 = Convert.ToInt32(System.Console.ReadLine());
        //     }
        //     if (input1 == 0)
        //     {
        //         Menu.Start();
        //     }
        //     else
        //     {
        //         chooseDateTime(input1);
        //     }
        // }
        string prompt = @"choose a movie: ";
        List<string> optionList = new List<string> { "Back" };
        foreach (var item in MoviesAccess.LoadAll())
        {
            optionList.Add(item.Name);
        }
        string[] options = optionList.ToArray();
        KeyBoardLogic MovieMenu = new KeyBoardLogic(prompt, options);
        int selectedIndex = MovieMenu.Run();
        int counter = 0;
        if (selectedIndex == 0)
        {
            Menu.Start();
        }
        else if (selectedIndex > 0)
        {
            foreach (var movie in optionList)
            {
                if (counter == selectedIndex)
                {
                    chooseDateTime(counter);
                }
                counter++;
            }
        }


        static void chooseDateTime(int input1)
        {
            string prompt = "Choose a show time:";
            List<string> optionList2 = new List<string> { "Back" };
            foreach (var show in ShowAccess.LoadAll())
            {
                if (input1 == show.MovieId)
                {
                    optionList2.Add($"{show.Date}-----{show.Time}-----Room {show.RoomId}");
                }
            }
            string[] options = optionList2.ToArray();
            KeyBoardLogic MovieMenu = new KeyBoardLogic(prompt, options);
            int selectedIndex = MovieMenu.Run();
            if (selectedIndex == 0)
            {
                chooseMovie();
            }
            else if (selectedIndex > 0)
            {
                foreach (var show in ShowAccess.LoadAll())
                {
                    if (show.Id == selectedIndex)
                    {
                        RoomLogic.Start(show.RoomId, selectedIndex);
                    }
                }
            }
        }

        ////////////////////////////////////////////////////// optie 2      
        // int input2 = -3;
        // while (input2 < 0 || input2 >= optionList2.Count)
        // {
        //     Console.Clear();
        //     System.Console.WriteLine("Choose a option by typing the number");
        //     System.Console.WriteLine($"0: {optionList2[0]}");
        //     for (int i = 1; i < optionList2.Count; i++)
        //     {
        //         System.Console.WriteLine($"{i}: {optionList2[i]}");
        //     }
        //     input2 = Convert.ToInt32(System.Console.ReadLine());
        // }
        // if (input2 == 0)
        // {
        //     chooseMovie();
        // }
        // else
        // {
        // System.Console.WriteLine("OK");
        // Menu.Start();
        // string[] split = optionList2[input2].Split("-----");
        // ShowModel show1 = (ShowAccess.LoadAll()).First(x => x.Date == split[0] || x.Time == split[1]);
        // ShowLogic logic = new ShowLogic();

        // // ShowModel show1 = logic.GetById(input2);
        // RoomLogic.Start(show1.RoomId, show1.Id);
        // // ShowModel show1 = logic.GetById(input2);
        // // RoomLogic.Start(show1.RoomId, input2);




        //functieDami(ShowId);////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    }
}