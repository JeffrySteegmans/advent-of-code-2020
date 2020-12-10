using System.Collections.Generic;
using adventOfCode.Domain;
using adventOfCode.Domain.Interfaces.Validation;

namespace adventOfCode.Application
{
    public class PassportHandler
    {
        private readonly List<Passport> _passports;
        private readonly IValidator<Passport> _passportValidator;

        public PassportHandler(List<Passport> passports, IValidator<Passport> passportValidator)
        {
            _passports = passports;
            _passportValidator = passportValidator;
        }

        public int ValidPassportsCount()
        {
            int count = 0;

            foreach (Passport passport in _passports)
                count += _passportValidator.IsValid(passport) ? 1 : 0;

            return count;
        }
    }
}
