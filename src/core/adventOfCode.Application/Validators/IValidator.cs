using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adventOfCode.Application.Validators
{
    public interface IValidator<T>
    {
        public bool IsValid(T obj);
    }
}
