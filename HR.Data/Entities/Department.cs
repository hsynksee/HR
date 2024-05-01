using SharedKernel.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Data.Entities
{
    public partial class Department : AuditableBaseEntity
    {
        public int? BranchOfficeId { get; protected set; }
        public string Name { get; protected set; }

        #region Virtuals
        public virtual BranchOffice BranchOffice { get; protected set; }
        public virtual ICollection<JobTitle> JobTitles { get; protected set; }
        public virtual ICollection<DepartmentManager> DepartmentManagers { get; protected set; }
        #endregion

        public Department SetBaseInformation(string name, int branchOfficeId)
        {
            this.Name = name;
            this.BranchOfficeId = branchOfficeId;

            return this;
        }

        public void AdjusDepartmentManagers(List<int> managers)
        {
            if (DepartmentManagers == null)
                DepartmentManagers = new List<DepartmentManager>();
            else
                DepartmentManagers.Clear();

            managers.ForEach(p => DepartmentManagers.Add(new DepartmentManager().SetBaseInformation(Id, p)));
        }

    }
}
