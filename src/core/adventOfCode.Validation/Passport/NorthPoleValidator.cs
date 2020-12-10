using System.Collections.Generic;
using System.Reflection;
using adventOfCode.Domain;
using adventOfCode.Domain.Interfaces.Validation;

namespace adventOfCode.Validation
{
    public class NorthPoleValidator : IValidator<Passport>
    {
        private readonly Dictionary<string, IFieldValidator<string>> _fieldValidators;

        public NorthPoleValidator(Dictionary<string, IFieldValidator<string>> fieldValidators)
        {
            _fieldValidators = fieldValidators;
        }

        public bool IsValid(Passport passport)
        {
            return FieldsPresent(passport, new List<string>(){"cid"});
        }

        private bool FieldsPresent(Passport passport, List<string> ignoreList)
        {
            foreach (PropertyInfo prop in passport.GetType().GetProperties())
            {
                if (ignoreList.Contains(prop.Name))
                    continue;
                
                if (prop.GetValue(passport, null) == null)
                    return false;
;
                if (IsPropertyInvalid(passport, prop))
                    return false;
            }

            return true;
        }

        private bool IsPropertyInvalid(Passport passport, PropertyInfo prop)
        {
            if (!IsFieldValidatorPresent(prop.Name))
                return false;

            var value = prop.GetValue(passport, null).ToString() ?? "";
            return !_fieldValidators[prop.Name].IsValid(value);
        }

        private bool IsFieldValidatorPresent(string name)
        {
            return _fieldValidators.ContainsKey(name);
        }
    }
}
