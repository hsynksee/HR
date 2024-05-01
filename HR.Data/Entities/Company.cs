using SharedKernel.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Data.Entities
{
    public partial class Company : AuditableBaseEntity
    {
        public string Name { get; protected set; }

        public Company SetBaseInformation(string name)
        {
            this.Name = name;

            return this;
        }

        public virtual ICollection<BranchOffice> BranchOffices { get; protected set; }
    }
}
