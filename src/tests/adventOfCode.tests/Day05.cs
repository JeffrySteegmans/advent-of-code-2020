using adventOfCode.Application;
using adventOfCode.Domain;
using adventOfCode.Parsing;
using adventOfCode.tests.Data.Day05;
using FluentAssertions;
using Xunit;

namespace adventOfCode.tests
{
    public class Day05
    {
        [Theory]
        [ClassData(typeof(BoardingPassesData))]
        public void Seat_GivenBoardingPassWithBinarySpacePartitionParser_ShouldBeExpectedSeat(BoardingPass pass, Seat seat)
        {
            pass.Seat.Should().BeEquivalentTo(seat);
        }

        [Fact]
        public void SanityCheck_GivenBoardPassesAndBinarySpacePartitioningParser_ShouldBe820()
        {
            var boardingPasses = BoardingPassHandlerData.BoardingPasses;
            var handler = new BoardingHandler(boardingPasses);

            handler.SanityCheck().Should().Be(820);
        }
    }
}
