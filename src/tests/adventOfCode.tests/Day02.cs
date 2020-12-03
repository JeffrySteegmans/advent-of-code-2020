using System;
using System.Collections.Generic;
using adventOfCode.Application;
using Xunit;

using adventOfCode.Application.PasswordPolicies;

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

        [Theory]
        [InlineData("1-3 a", "abcde", true)]
        [InlineData("1-3 b", "cdefg", false)]
        [InlineData("2-9 c", "ccccccccc", true)]
        public void CanValidatePassword(string policy, string password, bool expected)
        {
            var p = new SledRentalPolicy();
            p.Parse(policy);

            Assert.Equal(expected: expected, p.Validate(password));
        }

        [Fact]
        public void GivenSledRentalPolicy_ValidPasswordCount_ShouldBe2()
        {
            var pwdPolicy = new SledRentalPolicy();
            var actual = Password.CountValidPasswords(pwdPolicy, input);

            Assert.Equal(expected: 2, actual);
        }

        [Fact]
        public void GivenTobogganPolicy_ValidPasswordCount_ShouldBe1()
        {
            var pwdPolicy = new TobogganPolicy();
            var actual = Password.CountValidPasswords(pwdPolicy, input);

            Assert.Equal(expected: 1, actual);
        }
    }
}
