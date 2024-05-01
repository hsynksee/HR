using SharedKernel.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Data.Entities
{
    public class JobTitle : AuditableBaseEntity
    {
        public int DepartmentId { get; protected set; }
        public string Name { get; protected set; }

        #region Virtuals
        public virtual Department Department { get; protected set; }
        #endregion

        public JobTitle SetBaseInformation(string name, int departmnetId)
        {
            this.Name = name;
            this.DepartmentId = departmnetId;

            return this;
        }
    }
}
