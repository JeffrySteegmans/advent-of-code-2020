using adventOfCode.Domain.Interfaces.Validation;

namespace adventOfCode.Validation.Field
{
    public class IyrValidator : IFieldValidator<string>
    {
        public string FieldName => "iyr";
        private static readonly int _atLeast = 2010;
        private static readonly int _atMost = 2020;

        public bool IsValid(string iyr)
        {
            if (!int.TryParse(iyr, out int value))
                return false;

            return value >= _atLeast && value <= _atMost;
        }
    }
}
