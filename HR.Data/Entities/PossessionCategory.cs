using SharedKernel.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Data.Entities
{
    public partial class PossessionCategory: AuditableBaseEntity
    {
        public string Name { get;protected set; }
        public PossessionCategory SetBaseInformation(string name)
        {
            Name = name;
            return this;
        }
    }
}
