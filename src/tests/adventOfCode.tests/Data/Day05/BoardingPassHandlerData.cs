using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using adventOfCode.Domain;
using adventOfCode.Parsing;

namespace adventOfCode.tests.Data.Day05
{
    public static class BoardingPassHandlerData
    {
        private static readonly BinarySpacePartitioningParser parser = new BinarySpacePartitioningParser();
        public static List<BoardingPass> BoardingPasses => new List<BoardingPass>()
        {
            new BoardingPass(seatCode: "FBFBBFFRLR", parser),
            new BoardingPass(seatCode: "BFFFBBFRRR", parser),
            new BoardingPass(seatCode: "FFFBBBFRRR", parser),
            new BoardingPass(seatCode: "BBFFBBFRLL", parser)
        };
    }
}
