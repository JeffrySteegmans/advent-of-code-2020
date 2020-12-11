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

        public BoardingHandler(List<BoardingPass> boardingPasses)
        {
            BoardingPasses = boardingPasses;
        }

        public int SanityCheck()
        {
            int highestId = 0;

            foreach (BoardingPass boardingPass in BoardingPasses)
            {
                if (boardingPass.Seat.Id > highestId)
                    highestId = boardingPass.Seat.Id;
            }

            return highestId;
        }
    }
}
