namespace adventOfCode.Domain
{
    public class Seat
    {
        public int Id => Row * 8 + Column;

        public int Row { get; set; }
        public int Column { get; set; }
    }
}
