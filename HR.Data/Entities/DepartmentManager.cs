using SharedKernel.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Data.Entities
{
    public partial class DepartmentManager : AuditableBaseEntity
    {
        public int DepartmentId { get; protected set; }
        public int UserId { get; protected set; }

        #region Virtuals
        public virtual Department Department { get; protected set; }
        public virtual User User { get; protected set; }
        #endregion

        public DepartmentManager SetBaseInformation(int departmentId, int userId)
        {
            this.DepartmentId = departmentId; 
            this.UserId = userId;

            return this;
        }

    }
}
