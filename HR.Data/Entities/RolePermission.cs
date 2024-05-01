using SharedKernel.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Data.Entities
{
    public class RolePermission : BaseEntity
    {
        public RolePermission(int roleId, int permissionId)
        {
            RoleId = roleId;
            PermissionId = permissionId;
        }

        public int RoleId { get; protected set; }
        public int PermissionId { get; protected set; }

        #region Virtuals
        public virtual Role Role { get; protected set; }
        public virtual Permission Permission { get; protected set; }
        #endregion
    }
}
