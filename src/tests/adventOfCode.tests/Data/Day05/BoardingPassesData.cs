using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using adventOfCode.Domain;
using adventOfCode.Parsing;

namespace adventOfCode.tests.Data.Day05
{
    class BoardingPassesData : IEnumerable<object[]>
    {
        private static readonly BinarySpacePartitioningParser parser = new BinarySpacePartitioningParser();

        private readonly List<object[]> _boardingPasses = new List<object[]>()
        {
            new object[] {new BoardingPass(seatCode: "FBFBBFFRLR", parser), new Seat() {Row = 44, Column = 5}},
            new object[] {new BoardingPass(seatCode: "BFFFBBFRRR", parser), new Seat() {Row = 70, Column = 7}},
            new object[] {new BoardingPass(seatCode: "FFFBBBFRRR", parser), new Seat() {Row = 14, Column = 7}},
            new object[] {new BoardingPass(seatCode: "BBFFBBFRLL", parser), new Seat() {Row = 102, Column = 4}}
        };

        public IEnumerator<object[]> GetEnumerator()
        {
            return _boardingPasses.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
