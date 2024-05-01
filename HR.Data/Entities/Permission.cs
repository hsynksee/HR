using SharedKernel.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Data.Entities
{
    public class Permission : BaseEntity
    {
        public int? ParentId { get; protected set; }
        public string Name { get; protected set; }
        public string Code { get; protected set; }
        public int Order { get; protected set; }

        #region Virtuals
        public virtual Permission Parent { get; protected set; }
        public virtual ICollection<Permission> Children { get; protected set; }
        public virtual ICollection<RolePermission> RolePermissions { get; protected set; }
        #endregion

    }
}
