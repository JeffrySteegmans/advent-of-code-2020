using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using adventOfCode.Domain;

namespace adventOfCode.Application.PasswordPolicies
{
    public class TobogganPolicy : IPasswordPolicy
    {
        private int _position1;
        private int _position2;
        private char _char;

        public void Parse(string policy)
        {
            _char = char.Parse(policy.Split(separator: ' ')[1]);

            string occurrences = policy.Split(separator: ' ')[0];
            int.TryParse(occurrences.Split(separator: '-')[0], out _position1);
            int.TryParse(occurrences.Split(separator: '-')[1], out _position2);
        }

        public bool Validate(string password)
        {
            return (password[_position1 - 1] == _char) ^ (password[_position2 - 1] == _char);
        }
    }
}
