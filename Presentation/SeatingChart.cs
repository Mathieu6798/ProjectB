using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

public class SeatingChart
{
    // private static List<RoomModel> _rooms;
    // private static List<ChairModel> _chairs;
    // private static List<ReservationModel> _reservations;



    public static void Start(int roomId, int showid)
    {
        // _rooms = RoomAccess.LoadAll();
        // _chairs = ChairAccess.LoadAll();
        // _reservations = ReservationAccess.LoadAll();
        var roomModel = RoomLogic.GetRoomById(roomId);

        if (roomModel == null)
        {
            Console.WriteLine($"Room with ID {roomId} not found.");
            return;
        }

        var seatingChart = RoomLogic.CreateSeatingChart(roomModel);

        int selectedRow = 0;
        int selectedColumn = 0;
        List<int> bookedChairs = new List<int>();

        while (true)
        {
            Console.SetCursorPosition(0, 2);
            Console.Write(new string(' ', Console.WindowWidth));

            var key = Console.ReadKey(true).Key;
            if (key == ConsoleKey.UpArrow && selectedRow > 0)
            {
                selectedRow--;
            }
            else if (key == ConsoleKey.DownArrow && selectedRow < roomModel.Rows - 1)
            {
                selectedRow++;
            }
            else if (key == ConsoleKey.LeftArrow && selectedColumn > 0)
            {
                selectedColumn--;
            }
            else if (key == ConsoleKey.RightArrow && selectedColumn < roomModel.Columns - 1)
            {
                selectedColumn++;
            }
            else if (key == ConsoleKey.Enter)
            {
                var selectedSeat = seatingChart[selectedRow, selectedColumn];
                if (bookedChairs.Contains(selectedSeat.Id) || RoomLogic.IsSeatBooked(showid, selectedSeat.Id))
                {
                    Console.WriteLine($"Seat {selectedSeat.Chairnumber} at row {selectedSeat.Rownumber} is already booked.");
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine($"You've successfully booked seat {selectedSeat.Chairnumber} at row {selectedSeat.Rownumber}");
                    bookedChairs.Add(selectedSeat.Id);

                    if (PromptForAnotherSeat())
                    {
                        continue;
                    }
                    else
                    {
                        if (Menu.loggedaccount == null)
                        {
                            // int accid = Menu.loggedaccount.Id;
                            int Showid = showid;
                            double Price = RoomLogic.GetPrices(selectedSeat);
                            BuyTicket ticket = new BuyTicket(Showid, 0, bookedChairs);
                            Thread.Sleep(3500);
                            ticket.Overview();
                        }
                        else
                        {
                            int accid = Menu.loggedaccount.Id;
                            int Showid = showid;
                            double Price = RoomLogic.GetPrices(selectedSeat);
                            BuyTicket ticket = new BuyTicket(Showid, accid, bookedChairs);
                            Thread.Sleep(3500);
                            ticket.Overview();
                        }
                    }
                }
            }

            DisplaySeatingChart(seatingChart, roomModel, selectedRow, selectedColumn, bookedChairs, showid);
        }
    }

    public static int GetShows()
    {
        List<string> shows = new List<string>();


        foreach (var item in ShowAccess.LoadAll())
        {
            foreach (var movie in MoviesAccess.LoadAll())
            {
                if (movie.Id.ToString() == item.MovieId.ToString())
                {
                    shows.Add($"{item.Id}---{movie.Name}---{item.Date}---{item.Time}---{item.RoomId}");
                }
            }
        }


        KeyBoardLogic mainMenu = new KeyBoardLogic("Choose a ShowID", shows.ToArray());
        int selectedIndex = mainMenu.Run();
        return Convert.ToInt32(shows[selectedIndex].Split("---")[0]);
        // return Convert.ToInt32(shows[selectedIndex]);
    }




    public static Tuple<ChairModel[,], RoomModel, int> AdminRoomCheck(int showId)
    {
        ShowLogic showLogic = new ShowLogic();
        ShowModel show = showLogic.GetById(showId);

        if (show == null)
        {
            Console.WriteLine($"Show with ID {showId} not found.");
            return null;
        }

        var roomId = show.RoomId;
        var roomModel = RoomLogic.GetRoomById(roomId);

        if (roomModel == null)
        {
            Console.WriteLine($"Room with ID {roomId} not found.");
            return null;
        }


        ChairModel[,] seatingChart = RoomLogic.CreateSeatingChart(roomModel);
        Tuple<ChairModel[,], RoomModel, int> tuple = Tuple.Create(seatingChart, roomModel, showId);
        return tuple;
        // DisplaySeatingChart(seatingChart, roomModel, showId);
    }






    private static void DisplaySeatingChart(ChairModel[,] seatingChart, RoomModel roomModel, int selectedRow, int selectedColumn, List<int> bookedChairs, int showId)
    {
        Console.Clear();

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Green = 8");
        Console.ResetColor();
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine("Orange = 10");
        Console.ResetColor();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("Cyan = 12");
        Console.ResetColor();

        for (int i = 0; i < roomModel.Rows; i++)
        {
            if (i > 8)
            {
                Console.Write($"{i + 1}  ");
            }
            else
            {
                Console.Write($"0{i + 1}  ");
            }
            for (int j = 0; j < roomModel.Columns; j++)
            {
                var seat = seatingChart[i, j];

                if (seat != null)
                {
                    bool isBookedInReservation = RoomLogic.IsSeatBooked(showId, seat.Id);
                    bool isBookedInBookedChairs = bookedChairs.Contains(seat.Id);

                    char displayChar = isBookedInReservation || isBookedInBookedChairs ? 'X' : 'O';
                    if (i == selectedRow && j == selectedColumn)
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write($"{displayChar} ");
                    }
                    else
                    {
                        Console.ResetColor();
                        if (seat.Rank == "B")
                        {
                            Console.ForegroundColor = isBookedInReservation || isBookedInBookedChairs ? ConsoleColor.Red : ConsoleColor.DarkYellow;
                        }
                        else if (seat.Rank == "C")
                        {
                            Console.ForegroundColor = isBookedInReservation || isBookedInBookedChairs ? ConsoleColor.Red : ConsoleColor.Cyan;
                        }
                        else
                        {
                            Console.ForegroundColor = isBookedInReservation || isBookedInBookedChairs ? ConsoleColor.Red : ConsoleColor.Green;
                        }
                        Console.Write($"{displayChar} ");
                    }
                }
                else if (i == selectedRow && j == selectedColumn)
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write("X ");
                }
                else
                {
                    Console.ResetColor();
                    Console.Write("  ");
                }
            }
            Console.ResetColor();
            Console.WriteLine();
        }

        Console.ResetColor();
    }




    public static void DisplaySeatingChart(ChairModel[,] seatingChart, RoomModel roomModel, int showId)
    {
        Console.Clear();
        Console.WriteLine($"Seating chart for room {roomModel.Id}:");
        Console.WriteLine();

        for (int i = 0; i < roomModel.Rows; i++)
        {
            Console.Write($"{i + 1}  ");
            for (int j = 0; j < roomModel.Columns; j++)
            {
                var seat = seatingChart[i, j];

                if (seat != null)
                {
                    bool isBooked = RoomLogic.IsSeatBooked(showId, seat.Id);
                    char displayChar = isBooked ? 'X' : 'O';

                    Console.ResetColor();
                    Console.ForegroundColor = isBooked ? ConsoleColor.Red : ConsoleColor.White;
                    Console.Write($"{displayChar} ");
                }
                else
                {
                    Console.ResetColor();
                    Console.Write("  ");
                }
            }
            Console.ResetColor();
            Console.WriteLine();
        }

        Console.WriteLine();
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
        // AdminPanel.AdminMenu();
    }







    private static bool PromptForAnotherSeat()
    {
        string promptAdmin = "Do you want to book another seat?";
        string[] optionsAdmin = { "Yes", "No" };
        KeyBoardLogic adminMenu = new KeyBoardLogic(promptAdmin, optionsAdmin);
        int selectedIndexAdmin = adminMenu.Run();

        return selectedIndexAdmin == 0;
    }





}