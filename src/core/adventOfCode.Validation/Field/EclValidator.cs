using System;
using System.Linq;
using adventOfCode.Domain.Interfaces.Validation;

namespace adventOfCode.Validation.Field
{
    public class EclValidator : IFieldValidator<string>
    {
        private static readonly string[] colors = { "amb", "blu", "brn", "gry", "grn", "hzl", "oth" };
        
        public string FieldName => "ecl";

        public bool IsValid(string ecl)
        {
            return colors.Contains(ecl);
        }

    }
}
