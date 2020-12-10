using adventOfCode.Application.Extensions;
using adventOfCode.Domain.Interfaces.Validation;

namespace adventOfCode.Validation.Field
{
    public class HgtValidator : IFieldValidator<string>
    {
        public string FieldName => "hgt";

        public bool IsValid(string hgt)
        {
            if (hgt.Length < 3)
                return false;

            var unit = hgt.Last(2);
            if (unit != "in" && unit != "cm")
                return false;

            var hgtValue = hgt.Substring(0, hgt.Length - 2);
            if (!int.TryParse(hgtValue, out int value))
                return false;

            return IsValidHeight(value, unit);
        }

        private bool IsValidHeight(int value, string unit)
        {
            switch (unit)
            {
                case "in":
                    return value >= 59 && value <= 76;
                case "cm":
                    return value >= 150 && value <= 193;
            }

            return false;
        }
    }
}
