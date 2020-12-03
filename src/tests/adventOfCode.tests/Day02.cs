using System;
using System.Collections.Generic;
using Xunit;

using adventOfCode.Application;

namespace adventOfCode.tests
{
    public class Day02
    {
        private List<string> input = new List<string>()
        {
            "1-3 a: abcde",
            "1-3 b: cdefg",
            "2-9 c: ccccccccc"
        };

        [Fact]
        public void ValidPasswordCount_ShouldBe_2()
        {
            Assert.Equal(expected: 2, actual: Password.CountValidPasswords(input));
        }
    }
}
