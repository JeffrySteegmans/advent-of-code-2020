using adventOfCode.Domain;
using adventOfCode.Parsing;
using FluentAssertions;
using Xunit;

namespace adventOfCode.tests.Parsing
{
    public class BinarySpacePartitioningParserTests
    {
        [Theory]
        [ClassData(typeof(Data.SeatData))]
        public void Parse_GivenSeatCode_ShouldReturnParsedSeat(string code, Seat expectedSeat)
        {
            var parser = new BinarySpacePartitioningParser();
            Seat seat = parser.Parse(code);
            
            seat.Should().BeEquivalentTo(expectedSeat);
        }
    }
}
