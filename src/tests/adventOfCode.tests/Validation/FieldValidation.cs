using System.Collections.Generic;
using adventOfCode.Domain.Interfaces.Validation;
using adventOfCode.Validation.Field;
using Xunit;

namespace adventOfCode.tests.Validation
{
    public class FieldValidation
    {
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

        [Theory]
        [InlineData("byr")]
        [InlineData("iyr")]
        [InlineData("eyr")]
        [InlineData("hgt")]
        [InlineData("hcl")]
        [InlineData("ecl")]
        [InlineData("pid")]
        public void FieldValidator_IsValid_ShouldReturnTypeOfBool(string fieldName)
        {
            IValidator<string> validator = fieldValidators[fieldName];
            var actual = validator.IsValid("");

            Assert.IsType<bool>(actual);
        }

        [Theory]
        [InlineData("byr", "2002", true)]
        [InlineData("byr", "2003", false)]
        [InlineData("hgt", "1", false)]
        [InlineData("hgt", "12", false)]
        [InlineData("hgt", "60in", true)]
        [InlineData("hgt", "190cm", true)]
        [InlineData("hgt", "190in", false)]
        [InlineData("hgt", "190", false)]
        [InlineData("hcl", "#123abc", true)]
        [InlineData("hcl", "#123abz", false)]
        [InlineData("hcl", "123abc", false)]
        [InlineData("ecl", "brn", true)]
        [InlineData("ecl", "wat", false)]
        [InlineData("pid", "000000001", true)]
        [InlineData("pid", "0123456789", false)]
        [InlineData("pid", "01234567", false)]
        [InlineData("iyr", "2012", true)]
        [InlineData("iyr", "2003", false)]
        [InlineData("eyr", "2025", true)]
        [InlineData("eyr", "2003", false)]
        public void Validator_ShouldValidate(string fieldName, string value, bool expected)
        {
            var validator = fieldValidators[fieldName];

            var actual = validator.IsValid(value);

            Assert.Equal(expected, actual);
        }
    }
}
