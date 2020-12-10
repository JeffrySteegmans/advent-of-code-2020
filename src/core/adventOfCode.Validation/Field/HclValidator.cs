using System.Text.RegularExpressions;
using adventOfCode.Domain.Interfaces.Validation;

namespace adventOfCode.Validation.Field
{
    public class HclValidator : IFieldValidator<string>
    {
        private const string PATTERN = @"^#(([0-9a-fA-F]{2}){3})$";

        public string FieldName => "hcl";
        private readonly Regex _regexValidator = new Regex(PATTERN);

        public bool IsValid(string hcl)
        {
            return _regexValidator.IsMatch(hcl);
        }

        
    }
}
