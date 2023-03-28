public class Seat
{
    public Seat(int row, int column)
    {
        Row = row;
        Column = column;
        Status = SeatStatus.Available;
    }

    public int Row { get; set; }
    public int Column { get; set; }
    public SeatStatus Status { get; set; }
}