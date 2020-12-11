using System.Collections;
using System.Collections.Generic;
using adventOfCode.Domain;

namespace adventOfCode.tests.Data
{
    public class SeatData : IEnumerable<object[]>
    {
        private readonly List<object[]> _seats = new List<object[]>()
        {
            new object[] { "FBFBBFFRLR", new Seat() { Row = 44, Column = 5 } },
            new object[] { "BFFFBBFRRR", new Seat() { Row = 70, Column = 7 } },
            new object[] { "FFFBBBFRRR", new Seat() { Row = 14, Column = 7 } },
            new object[] { "BBFFBBFRLL", new Seat() { Row = 102, Column = 4 } }
        };

        public IEnumerator<object[]> GetEnumerator()
        {
            return _seats.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
