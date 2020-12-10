using System.Collections.Generic;
using System.Linq;
using adventOfCode.Application;
using adventOfCode.Validation;
using adventOfCode.Domain;
using adventOfCode.Domain.Interfaces.Validation;
using adventOfCode.Serialization;
using adventOfCode.Validation.Field;
using Moq;
using Xunit;

namespace adventOfCode.tests
{
    public class Day04
    {
        private PassportSerializer serializer = new PassportSerializer();
        private readonly Dictionary<string, IFieldValidator<string>> fieldValidators = new Dictionary<string, IFieldValidator<string>>()
        {
            {"byr", new ByrValidator()},
            {"eyr", new EyrValidator()},
            {"iyr", new IyrValidator()},
            {"hgt", new HgtValidator()},
            {"hcl", new HclValidator()},
            {"ecl", new EclValidator()},
            {"pid", new PidValidator()}
        };
        private string passportsInputPart1 = @"ecl:gry pid:860033327 eyr:2020 hcl:#fffffd
byr:1937 iyr:2017 cid:147 hgt:183cm

iyr:2013 ecl:amb cid:350 eyr:2023 pid:028048884
hcl:#cfa07d byr:1929

hcl:#ae17e1 iyr:2013
eyr:2024
ecl:brn pid:760753108 byr:1931
hgt:179cm

hcl:#cfa07d eyr:2025 pid:166559648
iyr:2011 ecl:brn hgt:59in";
        private string invalidPassports = @"eyr:1972 cid:100
hcl:#18171d ecl:amb hgt:170 pid:186cm iyr:2018 byr:1926

iyr:2019
hcl:#602927 eyr:1967 hgt:170cm
ecl:grn pid:012533040 byr:1946

hcl:dab227 iyr:2012
ecl:brn hgt:182cm pid:021572410 eyr:2020 byr:1992 cid:277

hgt:59cm ecl:zzz
eyr:2038 hcl:74454a iyr:2023
pid:3556412378 byr:2007";
        private string validPassports = @"pid:087499704 hgt:74in ecl:grn iyr:2012 eyr:2030 byr:1980
hcl:#623a2f

eyr:2029 ecl:blu cid:129 byr:1989
iyr:2014 pid:896056539 hcl:#a97842 hgt:165cm

hcl:#888785
hgt:164cm byr:2001 iyr:2015 cid:88
pid:545766238 ecl:hzl
eyr:2022

iyr:2010 hgt:158cm hcl:#b6652a ecl:blu byr:1944 eyr:2021 pid:093154719";

        [Fact]
        public void PassportHandlerWithMoqValidator_ShouldHave_ValidPassportCountFour()
        {
            int expected = 4;

            Mock<IValidator<Passport>> validator = new Mock<IValidator<Passport>>();
            validator.Setup(v => v.IsValid(It.IsAny<Passport>())).Returns(() => true);

            List<Passport> passports = serializer.Deserialize<Passport>(passportsInputPart1).ToList();
            var handler = new PassportHandler(passports, validator.Object);
            int actual = handler.ValidPassportsCount();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void PassportHandler_ShouldHave_ValidPassportCountTwo()
        {
            int expected = 2;

            List<Passport> passports = serializer.Deserialize<Passport>(passportsInputPart1).ToList();
            var handler = new PassportHandler(passports, new NorthPoleValidator(new Dictionary<string, IFieldValidator<string>>()));
            int actual = handler.ValidPassportsCount();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void PasportHandler_ShouldHave_ValidPassportCountZero()
        {
            int expected = 0;

            List<Passport> passports = serializer.Deserialize<Passport>(invalidPassports).ToList();
            var handler = new PassportHandler(passports, new NorthPoleValidator(fieldValidators));
            int actual = handler.ValidPassportsCount();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void PasportHandler_ShouldHave_ValidPassportCountFour()
        {
            int expected = 4;

            List<Passport> passports = serializer.Deserialize<Passport>(validPassports).ToList();
            var handler = new PassportHandler(passports, new NorthPoleValidator(fieldValidators));
            int actual = handler.ValidPassportsCount();

            Assert.Equal(expected, actual);
        }
    }
}
