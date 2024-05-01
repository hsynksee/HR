using SharedKernel.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Data.Entities
{
    public partial class BranchOffice : AuditableBaseEntity
    {
        public string Name { get; protected set; }
        public int CompanyId { get; protected set; }

        #region Virtuals
        public virtual Company Company { get; protected set; }
        public virtual ICollection<Department> Departments { get; protected set; }
        #endregion

        public BranchOffice SetBaseInformation(string name, int companyId)
        {
            this.Name = name;
            this.CompanyId = companyId;

            return this;
        }
    }
}
