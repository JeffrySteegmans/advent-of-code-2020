using System;
using adventOfCode.Domain.Interfaces;

namespace adventOfCode.Domain
{
    public class BoardingPass : IComparable<BoardingPass>
    {
        private readonly string _seatCode;
        private readonly IParser<string, Seat> _parser;
        public Seat Seat { get; private set; }

        public BoardingPass(string seatCode, IParser<string, Seat> parser)
        {
            _seatCode = seatCode;
            _parser = parser;
            Seat = _parser.Parse(_seatCode);
        }

        public int CompareTo(BoardingPass other)
        {
            return Seat.Id.CompareTo(other.Seat.Id);
        }

        public override string ToString()
        {
            return $"SeatID: {Seat.Id}";
        }
    }
}
