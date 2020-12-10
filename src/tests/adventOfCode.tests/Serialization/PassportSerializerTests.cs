using System.Collections.Generic;
using System.Linq;
using adventOfCode.Domain;
using adventOfCode.Serialization;
using Xunit;

namespace adventOfCode.tests.Serialization
{
    public class PassportSerializerTests
    {
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
        public void DeserializationOfString_ShouldGiveObjectOfType_ListOfPassport()
        {
            var serializer = new PassportSerializer();
            var deserializedPassport = serializer.Deserialize<Passport>(passportsInput);

            Assert.IsType<List<Passport>>(deserializedPassport);
        }

        [Fact]
        public void CountOfPassports_ShouldBe_Four()
        {
            var expected = 4;

            var serializer = new PassportSerializer();
            List<Passport> passports = serializer.Deserialize<Passport>(passportsInput).ToList();

            Assert.Equal(expected, actual: passports.Count);
        }

        [Fact]
        public void IssueYearOfSecondPassport_ShouldBe_2013()
        {
            var expected = "2013";

            var serializer = new PassportSerializer();
            List<Passport> passports = serializer.Deserialize<Passport>(passportsInput).ToList();

            Assert.Equal(expected, actual: passports[1].iyr);
        }

        [Fact]
        public void CountryIdOfThirdPassport_ShouldBe_Null()
        {
            var serializer = new PassportSerializer();
            List<Passport> passports = serializer.Deserialize<Passport>(passportsInput).ToList();

            Assert.Null(passports[2].cid);
        }
    }
}
