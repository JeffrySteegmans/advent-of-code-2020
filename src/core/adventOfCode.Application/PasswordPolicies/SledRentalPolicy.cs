using System.Linq;
using adventOfCode.Domain;

namespace adventOfCode.Application.PasswordPolicies
{
    public class SledRentalPolicy : IPasswordPolicy
    {
        private int _min = 0;
        private int _max = 0;
        private char _char;

        public void Parse(string policy)
        {
            _char = char.Parse(policy.Split(separator: ' ')[1]);

            string occurrences = policy.Split(separator: ' ')[0];
            int.TryParse(occurrences.Split(separator: '-')[0], out _min);
            int.TryParse(occurrences.Split(separator: '-')[1], out _max);
        }

        public bool Validate(string password)
        {
            int charCount = password.Count(c => c == _char);

            return charCount >= _min && charCount <= _max;
        }
    }
}