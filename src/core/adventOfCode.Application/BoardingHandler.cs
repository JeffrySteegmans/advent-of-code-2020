using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using adventOfCode.Domain;
using adventOfCode.Domain.Interfaces;

namespace adventOfCode.Application
{
    public class BoardingHandler
    {
        public readonly List<BoardingPass> BoardingPasses;
        public int HighestSeatId { get; private set; }
        public int LowestSeatId { get; private set; }

        public BoardingHandler(List<BoardingPass> boardingPasses)
        {
            BoardingPasses = boardingPasses;
            CalculateLowestAndHightestSeatId();
        }

        private void CalculateLowestAndHightestSeatId()
        {
            HighestSeatId = BoardingPasses[0].Seat.Id;
            LowestSeatId = HighestSeatId;

            foreach (BoardingPass boardingPass in BoardingPasses)
            {
                if (boardingPass.Seat.Id > HighestSeatId)
                    HighestSeatId = boardingPass.Seat.Id;

                if (boardingPass.Seat.Id < LowestSeatId)
                    LowestSeatId = boardingPass.Seat.Id;
            }
        }

        public int SanityCheck()
        {
            return HighestSeatId;
        }

        public int FindMissingSeatId()
        {
            BoardingPasses.Sort((a, b) => a.CompareTo(b));
            int seatId = BoardingPasses[0].Seat.Id;

            foreach (BoardingPass boardingPass in BoardingPasses)
            {
                if (boardingPass.Seat.Id - seatId > 1)
                    return ++seatId;

                seatId = boardingPass.Seat.Id;
            }

            return -1;
        }
    }
}
