using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedKernel.Exceptions
{
    public class DuplicateRoleException : Exception
    {
        public DuplicateRoleException(string name) : base(message: $"{name} ismi daha önceden alınmış.")
        {

        }
    }
}
