using System;
using System.Collections.Generic;

public static class RoomLogic
{
    private static readonly List<RoomModel> _rooms;

    static RoomLogic()
    {
        _rooms = RoomAccess.LoadAll();
    }

    public static void GetSeatingChart(int roomId)
    {
        var room = FindRoomById(roomId);

        if (room == null)
        {
            Console.WriteLine($"Room with id {roomId} not found.");
            return;
        }

        Console.WriteLine($"Seating chart for {room.Id}:");
        for (int row = 1; row <= room.Rows; row++)
        {
            var seatStatuses = new List<string>();
            for (int col = 1; col <= room.Columns; col++)
            {
                seatStatuses.Add(GetSeatStatus(room, row, col));
            }
            Console.WriteLine(string.Join(" ", seatStatuses));
        }
    }

    private static RoomModel FindRoomById(int roomId)
    {
        foreach (var room in _rooms)
        {
            if (room.Id == roomId)
            {
                return room;
            }
        }

        return null;
    }

    private static string GetSeatStatus(RoomModel room, int row, int col)
    {
        foreach (var seat in room.Chairs)
        {
            if (seat.Rownumber == row && seat.Chairnumber == col)
            {
                return seat.IsBooked ? "X" : "O";
            }
        }

        return "-";
    }
}
