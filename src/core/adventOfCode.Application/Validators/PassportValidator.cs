using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using adventOfCode.Domain;

namespace adventOfCode.Application.Validators
{
    public class PassportValidator : IValidator<Passport>
    {
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
            }

            return true;
        }
    }
}
