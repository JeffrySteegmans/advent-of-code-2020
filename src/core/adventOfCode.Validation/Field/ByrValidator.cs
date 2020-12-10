using adventOfCode.Domain.Interfaces.Validation;

namespace adventOfCode.Validation.Field
{
    public class ByrValidator : IFieldValidator<string>
    {
        public string FieldName => "byr";
        private static readonly int _atLeast = 1920;
        private static readonly int _atMost = 2002;

        public bool IsValid(string byr)
        {
            if (!int.TryParse(byr, out int value))
                return false;

            return value >= _atLeast && value <= _atMost;
        }
    }
}
