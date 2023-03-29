// using System;

// namespace SeatingChart
// {
//     class Program
//     {
//         static void Main()
//         {
//             const int rows = 10;
//             const int columns = 15;

//             var seatingChart = new SeatModel[rows, columns];

//             for (int i = 0; i < rows; i++)
//             {
//                 for (int j = 0; j < columns; j++)
//                 {
//                     seatingChart[i, j] = new SeatModel(i + 1, j + 1);
//                 }
//             }

//             int selectedRow = 0;
//             int selectedColumn = 0;

//             Console.WriteLine("   " + string.Join("  ", Enumerable.Range(1, columns)));

//             while (true)
//             {
//                 Console.SetCursorPosition(0, 1);

//                 // Hier wordt de seat selection geupdate met de arrow keys
//                 var key = Console.ReadKey(true).Key;
//                 if (key == ConsoleKey.UpArrow && selectedRow > 0)
//                 {
//                     selectedRow--;
//                 }
//                 else if (key == ConsoleKey.DownArrow && selectedRow < rows - 1)
//                 {
//                     selectedRow++;
//                 }
//                 else if (key == ConsoleKey.LeftArrow && selectedColumn > 0)
//                 {
//                     selectedColumn--;
//                 }
//                 else if (key == ConsoleKey.RightArrow && selectedColumn < columns - 1)
//                 {
//                     selectedColumn++;
//                 }
//                 else if (key == ConsoleKey.Enter)
//                 {
//                     var selectedSeat = seatingChart[selectedRow, selectedColumn];
//                     if (selectedSeat.Status == SeatStatus.Available)
//                     {
//                         selectedSeat.Status = SeatStatus.Booked;
//                         Console.WriteLine($"Seat {selectedSeat.Row}{selectedSeat.Column} booked!");
//                         break;
//                     }
//                     else
//                     {
//                         Console.WriteLine("That seat is not available. Please select another seat.");
//                     }
//                 }

//                 // Hier worden de geupdate seating chart displayed met kleuren
//                 Console.WriteLine("   " + string.Join("  ", Enumerable.Range(1, columns)));

//                 for (int i = 0; i < rows; i++)
//                 {
//                     Console.Write($"{(char)(i + 65)}  ");
//                     for (int j = 0; j < columns; j++)
//                     {
//                         var seat = seatingChart[i, j];

//                         if (i == selectedRow && j == selectedColumn)
//                         {
//                             Console.BackgroundColor = ConsoleColor.White;
//                         }
//                         else if (seat.Status == SeatStatus.Available)
//                         {
//                             Console.ForegroundColor = ConsoleColor.Green;
//                         }
//                         else
//                         {
//                             Console.ForegroundColor = ConsoleColor.Red;
//                         }

//                         Console.Write(seat.Status == SeatStatus.Available ? "O" : "X");
//                         Console.ResetColor();
//                         Console.Write("  ");
//                     }

//                     Console.WriteLine();
//                 }
//             }
//         }
//     }
// }
