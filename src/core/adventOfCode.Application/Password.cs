using System.Collections.Generic;
using System.Linq;
using adventOfCode.Domain;

namespace adventOfCode.Application
{
    public static class Password
    {
        public static int CountValidPasswords(List<string> input)
        {
            return input
                .Count(i => Validate(policy: i.Split(separator: ':')[0], password: i.Split(separator: ':')[1].Trim()));
        }

        public static bool Validate(string policy, string password) {
            PasswordPolicy p = ParsePolicy(policy);
            int charCount = password.Count(c => c == p.Character);

            return charCount >= p.MinOccurence && charCount <= p.MaxOccurence;
        }

        private static PasswordPolicy ParsePolicy(string policy){
            PasswordPolicy p = new PasswordPolicy
            {
                Character = char.Parse(policy.Split(separator: ' ')[1])
            };

            string occurrences = policy.Split(separator: ' ')[0];
            if (int.TryParse(occurrences.Split(separator: '-')[0], out int min))
                p.MinOccurence = min;

            if (int.TryParse(occurrences.Split(separator: '-')[1], out int max))
                p.MaxOccurence = max;

            return p;
        }
    }
}