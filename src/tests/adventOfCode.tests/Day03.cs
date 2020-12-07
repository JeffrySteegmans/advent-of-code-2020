using System;
using System.Collections.Generic;
using adventOfCode.Application;
using adventOfCode.Domain;
using Xunit;

namespace adventOfCode.tests
{
    public class Day03
    {
        private List<string> input = new List<string>()
        {
            "..##.......",
            "#...#...#..",
            ".#....#..#.",
            "..#.#...#.#",
            ".#...##..#.",
            "..#.##.....",
            ".#.#.#....#",
            ".#........#",
            "#.##...#...",
            "#...##....#",
            ".#..#...#.#",
        };
        private Slope slope = new Slope(3, 1); 
        private List<Slope> slopes = new List<Slope>()
        {
            new Slope(right: 1, down: 1),
            new Slope(right: 3, down: 1),
            new Slope(right: 5, down: 1),
            new Slope(right: 7, down: 1),
            new Slope(right: 1, down: 2)
        };
        
        [Fact]
        public void PositionOfNewMap_ShouldBe_Dot()
        {
            char expected = '.';
            var map = new Map(input);

            Assert.Equal(expected, actual: map.Value);
        }

        [Fact]
        public void PositionValueAfterTwoMoves_ShouldBe_Hash()
        {
            char expected = '#';
            var map = new Map(input);

            map
                .Move(slope)
                .Move(slope);

            Assert.Equal(expected, actual: map.Value);
        }

        [Fact]
        public void PositionValueAfterTenMoves_ShouldBe_Hash()
        {
            char expected = '#';
            var map = new Map(input);

            for (int i = 0; i < 10; i++)
                map.Move(slope);

            Assert.Equal(expected, actual: map.Value);
        }

        [Fact]
        public void PositionCoordinatesAfterTenMoves_ShouldBe_RowTenColEight()
        {
            int[] expected = {8, 10};
            var map = new Map(input);

            for (int i = 0; i < 10; i++)
                map.Move(slope);

            int[] actual = {map.Position.X, map.Position.Y};

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TreeCountAfterTenMoves_ShouldBe_Seven()
        {
            int expected = 7;
            var map = new Map(input);

            for (int i = 0; i < 10; i++)
                map.Move(slope);

            int actual = map.TreeCount;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TreeCountAfterTraverseDown_ShouldBe_Seven()
        {
            int expected = 7;
            Map map = new Map(input);

            map.TraverseDown(slope);
            int actual = map.TreeCount;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void BenchmarkScore_ShouldBe_336()
        {
            int expected = 336;
            Map map = new Map(input);

            var actual = map.Benchmark(slopes);

            Assert.Equal(expected, actual);
        }
    }
}