using System;
using System.Collections.Generic;
using System.Linq;
using adventOfCode.Domain;

namespace adventOfCode.Application
{
    public static class Password
    {
        public static int CountValidPasswords(IPasswordPolicy policy, List<string> input)
        {
            return input
                .Count(i =>
                {
                    var policyString = i.Split(':')[0];
                    var password = i.Split(separator: ':')[1].Trim();

                    policy.Parse(policyString);

                    return policy.Validate(password);
                });
        }
    }
}