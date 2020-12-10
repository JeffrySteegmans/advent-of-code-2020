using System;
using System.Text.RegularExpressions;
using adventOfCode.Domain.Interfaces.Validation;

namespace adventOfCode.Validation.Field
{
    public class PidValidator : IFieldValidator<string>
    {
        private static readonly string PATTERN = @"^[0-9]{9}$";
        private readonly Regex _regexValidator = new Regex(PATTERN);

        public string FieldName => "pid";

        public bool IsValid(string pid)
        {
            return _regexValidator.IsMatch(pid);
        }

    }
}
