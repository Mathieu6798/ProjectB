
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

public class RoomLogic
{
    private static List<RoomModel> _rooms = RoomAccess.LoadAll();
    private static List<ChairModel> _chairs = ChairAccess.LoadAll();
    // private static List<ReservationModel> _reservations = ReservationAccess.LoadAll();
    private static List<ReservationModel> _reservations;


    public static void Start(int roomId, int showid)
    {
        _reservations = ReservationAccess.LoadAll();
        var roomModel = GetRoomById(roomId);

        if (roomModel == null)
        {
            Console.WriteLine($"Room with ID {roomId} not found.");
            return;
        }

        var seatingChart = CreateSeatingChart(roomModel);

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
                if (bookedChairs.Contains(selectedSeat.Id) || IsSeatBooked(showid, selectedSeat.Id))
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
                            double Price = GetPrices(selectedSeat);
                            BuyTicket ticket = new BuyTicket(Showid, 0, bookedChairs);
                            Thread.Sleep(3500);
                            ticket.Overview();
                        }
                        else
                        {
                            int accid = Menu.loggedaccount.Id;
                            int Showid = showid;
                            double Price = GetPrices(selectedSeat);
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
    public static double GetPrices(ChairModel selectedSeat)
    {
        double Price = 0;
        if (selectedSeat.Rank == "A")
        {
            Price = 8;
            return Price;
        }
        else if (selectedSeat.Rank == "B")
        {
            Price = 10;
            return Price;
        }
        else if (selectedSeat.Rank == "C")
        {
            Price = 12;
            return Price;
        }
        else
        {
            return 0;
        }
    }
    public static int GetShows()
    {

        var options = _reservations.Select(reservation => reservation.ShowId.ToString()).Distinct().ToArray();
        KeyBoardLogic mainMenu = new KeyBoardLogic("Choose a ShowID", options);
        int selectedIndex = mainMenu.Run();
        return selectedIndex;

    }

    public static void AdminRoomCheck(int showId)
    {
        ShowLogic showlogic = new ShowLogic();
        ShowModel show = showlogic.GetById(showId);

        if (show == null)
        {
            Console.WriteLine($"Show with ID {showId} not found.");
            return;
        }

        var roomId = show.RoomId;
        var roomModel = GetRoomById(roomId);

        if (roomModel == null)
        {
            Console.WriteLine($"Room with ID {roomId} not found.");
            return;
        }

        DisplaySeatingChart(roomModel, showId);
    }

    private static RoomModel GetRoomById(int roomId)
    {
        return _rooms.FirstOrDefault(r => r.Id == roomId);
    }
    public static ChairModel GetChairById(int chairId)
    {
        return _chairs.FirstOrDefault(x => x.Id == chairId);
    }

    private static ChairModel[,] CreateSeatingChart(RoomModel roomModel)
    {
        var seatingChart = new ChairModel[roomModel.Rows, roomModel.Columns];

        var roomChairIds = new List<int>(roomModel.Chairs);
        var chairs = _chairs.Where(c => roomChairIds.Contains(c.Id));

        foreach (var chairId in roomModel.Chairs)
        {
            var chair = chairs.FirstOrDefault(c => c.Id == chairId);

            if (chair != null)
            {
                seatingChart[chair.Rownumber - 1, chair.Chairnumber - 1] = chair;
            }
        }

        return seatingChart;
    }

    private static void DisplaySeatingChart(ChairModel[,] seatingChart, RoomModel roomModel, int selectedRow, int selectedColumn, List<int> bookedChairs, int showId)
    {
        Console.Clear();

        for (int i = 0; i < roomModel.Rows; i++)
        {
            Console.Write($"{i + 1}  ");
            for (int j = 0; j < roomModel.Columns; j++)
            {
                var seat = seatingChart[i, j];

                if (seat != null)
                {
                    bool isBooked = IsSeatBooked(showId, seat.Id);

                    char displayChar = isBooked ? 'X' : 'O';
                    if (i == selectedRow && j == selectedColumn)
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write($"{displayChar} ");
                    }
                    else
                    {
                        Console.ResetColor();
                        Console.ForegroundColor = isBooked ? ConsoleColor.Red : ConsoleColor.Green;
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



    private static void DisplaySeatingChart(RoomModel roomModel, int showId)
    {
        Console.WriteLine($"Seating chart for room {roomModel.Id}:");

        for (int i = 1; i <= roomModel.Rows; i++)
        {
            Console.Write($"{i}  ");
            for (int j = 1; j <= roomModel.Columns; j++)
            {
                var chairId = (i - 1) * roomModel.Columns + j;
                if (roomModel.Chairs.Contains(chairId))
                {
                    bool isBooked = IsSeatBooked(showId, chairId);
                    char displayChar = isBooked ? 'X' : 'O';

                    Console.ForegroundColor = isBooked ? ConsoleColor.Red : ConsoleColor.White;
                    Console.Write($"{displayChar} ");
                }
                else
                {
                    Console.Write("  ");
                }
            }
            Console.WriteLine();
        }

        Console.ResetColor();
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
        AdminPanel.AdminMenu();
    }





    private static bool PromptForAnotherSeat()
    {
        string promptAdmin = "Do you want to book another seat?";
        string[] optionsAdmin = { "Yes", "No" };
        KeyBoardLogic adminMenu = new KeyBoardLogic(promptAdmin, optionsAdmin);
        int selectedIndexAdmin = adminMenu.Run();

        return selectedIndexAdmin == 0;
    }




    private static bool IsSeatBooked(int showId, int chairId)
    {
        var reservationModels = _reservations;

        foreach (var reservation in reservationModels)
        {
            if (reservation.ShowId == showId && reservation.Chairs.Contains(chairId))
            {
                return true;
            }
        }

        return false;
    }
}