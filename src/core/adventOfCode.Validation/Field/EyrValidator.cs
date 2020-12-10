using adventOfCode.Domain.Interfaces.Validation;

namespace adventOfCode.Validation.Field
{
    public class EyrValidator : IFieldValidator<string>
    {
        public string FieldName => "eyr";
        private static readonly int _atLeast = 2020;
        private static readonly int _atMost = 2030;

        public bool IsValid(string eyr)
        {
            if (!int.TryParse(eyr, out int value))
                return false;

            return value >= _atLeast && value <= _atMost;
        }
    }
}
