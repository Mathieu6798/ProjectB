// using System;
// using System.Collections.Generic;

// public static class RoomLogic
// {
//     private static readonly List<RoomModel> _rooms;

//     static RoomLogic()
//     {
//         _rooms = RoomAccess.LoadAll();
//     }

//     public static void GetSeatingChart(int roomId)
//     {
//         var room = FindRoomById(roomId);

//         if (room == null)
//         {
//             Console.WriteLine($"Room with id {roomId} not found.");
//             return;
//         }

//         Console.WriteLine($"Seating chart for {room.Id}:");
//         Console.CursorVisible = false;

//         int selectedRow = 1;
//         int selectedCol = 1;
//         bool isBookingMode = false;

//         while (true)
//         {
//             Console.Clear();

//             for (int row = 1; row <= room.Rows; row++)
//             {
//                 for (int col = 1; col <= room.Columns; col++)
//                 {
//                     Console.ForegroundColor = ConsoleColor.White;

//                     if (row == selectedRow && col == selectedCol)
//                     {
//                         Console.BackgroundColor = isBookingMode ? ConsoleColor.Yellow : ConsoleColor.Green;
//                         Console.Write("S ");
//                     }
//                     else
//                     {
//                         Console.BackgroundColor = GetSeatStatus(room, row, col) == "X" ? ConsoleColor.Red : ConsoleColor.Black;
//                         Console.Write($"{GetSeatStatus(room, row, col)} ");
//                     }
//                 }
//                 Console.WriteLine();
//             }

//             Console.ResetColor();

//             ConsoleKeyInfo key = Console.ReadKey(true);

//             if (key.Key == ConsoleKey.Enter)
//             {
//                 if (isBookingMode)
//                 {
//                     var seatStatus = GetSeatStatus(room, selectedRow, selectedCol);
//                     if (seatStatus == "O")
//                     {
//                         var chair = room.Chairs.Find(c => c.Rownumber == selectedRow && c.Chairnumber == selectedCol);
//                         chair.IsBooked = true;
//                         RoomAccess.Save(room);
//                         Console.WriteLine($"Seat {selectedRow},{selectedCol} has been booked.");
//                     }
//                     else
//                     {
//                         Console.WriteLine($"Seat {selectedRow},{selectedCol} is not available.");
//                     }
//                     isBookingMode = false;
//                     Console.ReadKey(true);
//                 }
//                 else
//                 {
//                     isBookingMode = true;
//                     Console.WriteLine("Please select a seat to book.");
//                 }
//             }
//             else
//             {
//                 switch (key.Key)
//                 {
//                     case ConsoleKey.UpArrow:
//                         if (selectedRow > 1)
//                         {
//                             selectedRow--;
//                         }
//                         break;
//                     case ConsoleKey.DownArrow:
//                         if (selectedRow < room.Rows)
//                         {
//                             selectedRow++;
//                         }
//                         break;
//                     case ConsoleKey.LeftArrow:
//                         if (selectedCol > 1)
//                         {
//                             selectedCol--;
//                         }
//                         break;
//                     case ConsoleKey.RightArrow:
//                         if (selectedCol < room.Columns)
//                         {
//                             selectedCol++;
//                         }
//                         break;
//                 }
//             }
//         }
//     }
//     private static RoomModel FindRoomById(int roomId)
//     {
//         foreach (var room in _rooms)
//         {
//             if (room.Id == roomId)
//             {
//                 return room;
//             }
//         }

//         return null;
//     }

//     private static string GetSeatStatus(RoomModel room, int row, int col)
//     {
//         foreach (var seat in room.Chairs)
//         {
//             if (seat.Rownumber == row && seat.Chairnumber == col)
//             {
//                 return seat.IsBooked ? "X" : "O";
//             }
//         }

//         return "-";
//     }
// }
