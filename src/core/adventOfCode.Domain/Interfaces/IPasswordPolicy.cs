using System.Collections.Generic;

namespace adventOfCode.Domain.Interfaces
{
    public interface IPasswordPolicy
    {
        public void Parse(string policy);
        public bool Validate(string password);
    }
}
