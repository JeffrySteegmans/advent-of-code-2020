using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using adventOfCode.Application;
using adventOfCode.Application.Validators;
using adventOfCode.Domain;
using adventOfCode.Serialization;
using Moq;
using Xunit;

namespace adventOfCode.tests
{
    public class Day04
    {
        PassportSerializer serializer = new PassportSerializer();
        string passportsInput = @"ecl:gry pid:860033327 eyr:2020 hcl:#fffffd
byr:1937 iyr:2017 cid:147 hgt:183cm

iyr:2013 ecl:amb cid:350 eyr:2023 pid:028048884
hcl:#cfa07d byr:1929

hcl:#ae17e1 iyr:2013
eyr:2024
ecl:brn pid:760753108 byr:1931
hgt:179cm

hcl:#cfa07d eyr:2025 pid:166559648
iyr:2011 ecl:brn hgt:59in";

        [Fact]
        public void PassportHandlerWithMoqValidator_ShouldHave_ValidPassportCountFour()
        {
            int expected = 4;

            Mock<IValidator<Passport>> validator = new Mock<IValidator<Passport>>();
            validator.Setup(v => v.IsValid(It.IsAny<Passport>())).Returns(() => true);

            List<Passport> passports = serializer.Deserialize<Passport>(passportsInput).ToList();
            var handler = new PassportHandler(passports, validator.Object);
            int actual = handler.ValidPassportsCount();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void PassportHandler_ShouldHave_ValidPassportCountTwo()
        {
            int expected = 2;

            List<Passport> passports = serializer.Deserialize<Passport>(passportsInput).ToList();
            var handler = new PassportHandler(passports, new PassportValidator());
            int actual = handler.ValidPassportsCount();

            Assert.Equal(expected, actual);
        }
    }
}
