
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

public class RoomLogic
{
    private static List<RoomModel> _rooms;
    private static List<ChairModel> _chairs;

    public RoomLogic()
    {
        _rooms = RoomAccess.LoadAll();
        _chairs = ChairAccess.LoadAll();
    }

    public static void Start(int roomId, int showid)
    {
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
                if (bookedChairs.Contains(selectedSeat.ChairId))
                {
                    Console.WriteLine($"Seat {selectedSeat.Chairnumber} at row {selectedSeat.Rownumber} is already booked.");
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine($"You've successfully booked seat {selectedSeat.Chairnumber} at row {selectedSeat.Rownumber}");
                    bookedChairs.Add(selectedSeat.ChairId);

                    if (PromptForAnotherSeat())
                    {
                        continue;
                    }
                    else
                    {
                        int accid = Menu.loggedaccount.Id;
                        int Showid = showid;
                        BuyTicket ticket = new BuyTicket(Showid, accid, bookedChairs);
                        Thread.Sleep(3500);
                        ticket.Overview();
                    }
                }
            }

            DisplaySeatingChart(seatingChart, roomModel, selectedRow, selectedColumn, bookedChairs);
        }
    }

    public static void AdminRoomCheck(int showId)
    {
        ShowLogic showlogic = new ShowLogic();
        ShowModel show = showlogic.GetById(showId);

        var roomId = show.RoomId;
        var roomModel = GetRoomById(roomId);

        if (roomModel == null)
        {
            Console.WriteLine($"Room with ID {roomId} not found.");
            return;
        }

        CreateSeatingChart(roomModel, showId);
        // Display seating chart and allow seat selection
        DisplaySeatingChart(roomModel, showId);
    }

    private static RoomModel GetRoomById(int roomId)
    {
        var pathroom = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, @"DataSources/Rooms.json"));
        var json = File.ReadAllText(pathroom);
        var roomModels = JsonSerializer.Deserialize<List<RoomModel>>(json);

        return roomModels.FirstOrDefault(r => r.Id == roomId);
    }

    private static ChairModel[,] CreateSeatingChart(RoomModel roomModel)
    {
        var seatingChart = new ChairModel[roomModel.Rows, roomModel.Columns];

        var pathchair = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, @"DataSources/Chairs.json"));
        var json = File.ReadAllText(pathchair);
        var chairModels = JsonSerializer.Deserialize<List<ChairModel>>(json);

        var roomChairIds = new List<int>(roomModel.Chairs);
        var chairs = chairModels.Where(c => roomChairIds.Contains(c.ChairId));

        foreach (var chairId in roomModel.Chairs)
        {
            var chair = chairs.FirstOrDefault(c => c.ChairId == chairId);

            if (chair != null)
            {
                seatingChart[chair.Rownumber - 1, chair.Chairnumber - 1] = chair;
            }
        }

        return seatingChart;
    }

    private static void DisplaySeatingChart(ChairModel[,] seatingChart, RoomModel roomModel, int selectedRow, int selectedColumn, List<int> bookedChairs)
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
                    char displayChar = bookedChairs.Contains(seat.ChairId) ? 'X' : 'O';
                    if (i == selectedRow && j == selectedColumn)
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write($"{displayChar} ");
                    }
                    else
                    {
                        Console.ResetColor();
                        Console.ForegroundColor = ConsoleColor.Green;
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
                    Console.Write("X ");
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

        var path = System.IO.Path.GetFullPath(System.IO.Path.Combine(Environment.CurrentDirectory, @"DataSources/reservation.json"));
        var json = File.ReadAllText(path);
        var reservationModels = JsonSerializer.Deserialize<List<ReservationModel>>(json);

        foreach (var reservation in reservationModels)
        {
            if (reservation.ShowId == showId)
            {
                foreach (var chairId in reservation.Chairs)
                {
                    var row = (chairId - 1) / roomModel.Columns;
                    var column = (chairId - 1) % roomModel.Columns;

                    if (row < roomModel.Rows && column < roomModel.Columns)
                    {
                        Console.SetCursorPosition((column * 2) + 3, row + 2);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("X");
                    }
                }
            }
        }

        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine();

        for (int i = 1; i <= roomModel.Rows; i++)
        {
            Console.Write($"{i + 1}  ");
            for (int j = 1; j <= roomModel.Columns; j++)
            {
                var chairId = (i - 1) * roomModel.Columns + j;
                if (roomModel.Chairs.Contains(chairId))
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    if (IsSeatBooked(showId, chairId))
                    {
                        Console.Write("X ");
                    }
                    else
                    {
                        Console.Write("O ");
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write("- ");
                }
            }
            Console.WriteLine();
        }
    }

    private static bool PromptForAnotherSeat()
    {
        string promptAdmin = "Do you want to book another seat?";
        string[] optionsAdmin = { "Yes", "No" };
        KeyBoardLogic adminMenu = new KeyBoardLogic(promptAdmin, optionsAdmin);
        int selectedIndexAdmin = adminMenu.Run();

        return selectedIndexAdmin == 0;
    }

    private static void CreateSeatingChart(RoomModel roomModel, int showId)
    {
        Console.WriteLine($"Seating chart for room {roomModel.Id}:");
        // Console.WriteLine("   " + string.Join("  ", Enumerable.Range(1, roomModel.Columns)));

        var path = System.IO.Path.GetFullPath(System.IO.Path.Combine(Environment.CurrentDirectory, @"DataSources/reservation.json"));
        var json = File.ReadAllText(path);
        var reservationModels = JsonSerializer.Deserialize<List<ReservationModel>>(json);

        foreach (var reservation in reservationModels)
        {
            if (reservation.ShowId == showId)
            {
                foreach (var chairId in reservation.Chairs)
                {
                    var row = (chairId - 1) / roomModel.Columns;
                    var column = (chairId - 1) % roomModel.Columns;

                    if (row < roomModel.Rows && column < roomModel.Columns)
                    {
                        Console.SetCursorPosition((column * 2) + 3, row + 2);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("X");
                    }
                }
            }
        }

        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine();

        for (int i = 1; i <= roomModel.Rows; i++)
        {
            Console.Write($"{i + 1}  ");
            for (int j = 1; j <= roomModel.Columns; j++)
            {
                var chairId = (i - 1) * roomModel.Columns + j;
                if (roomModel.Chairs.Contains(chairId))
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    if (IsSeatBooked(showId, chairId))
                    {
                        Console.Write("X ");
                    }
                    else
                    {
                        Console.Write("O ");
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write("- ");
                }
            }
            Console.WriteLine();
        }
    }


    private static bool IsSeatBooked(int showId, int chairId)
    {
        var path = System.IO.Path.GetFullPath(System.IO.Path.Combine(Environment.CurrentDirectory, @"DataSources/reservation.json"));
        var json = File.ReadAllText(path);
        var reservationModels = JsonSerializer.Deserialize<List<ReservationModel>>(json);

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
//gg