
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

public class RoomLogic
{
    // private static List<RoomModel> _rooms;
    // private static List<ChairModel> _chairs;
    // private static List<ReservationModel> _reservations;
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


    public static RoomModel GetRoomById(int roomId)
    {
        var _rooms = RoomAccess.LoadAll();
        return _rooms.FirstOrDefault(r => r.Id == roomId);
    }
    public static ChairModel GetChairById(int chairId)
    {
        var _chairs = ChairAccess.LoadAll();
        return _chairs.FirstOrDefault(x => x.Id == chairId);
    }

    public static ChairModel[,] CreateSeatingChart(RoomModel roomModel)
    {
        var seatingChart = new ChairModel[roomModel.Rows, roomModel.Columns];

        var roomChairIds = new List<int>(roomModel.Chairs);
        var chairs = ChairAccess.LoadAll().Where(c => roomChairIds.Contains(c.Id));

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

    public static bool IsSeatBooked(int showId, int chairId)
    {
        var reservationModels = ReservationAccess.LoadAll();
        //foreach om te kijken of movieide klopt met showid van reservation
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