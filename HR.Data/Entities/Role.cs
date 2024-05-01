using SharedKernel.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Data.Entities
{
    public class Role : AuditableBaseEntity
    {
        public string Name { get; protected set; }

        public Role(string name)
        {
            Name = name;

            RolePermissions = new List<RolePermission>();
        }

        #region Virtuals
        public virtual ICollection<RolePermission> RolePermissions { get; protected set; }
        #endregion

        #region Methods

        public void UpdateName(string name)
        {
            Name = name;
        }

        public void AddPermissions(List<RolePermission> permissions)
        {
            foreach (var permission in permissions)
            {
                RolePermissions.Add(permission);
            }
        }

        public void RemoveAllPermissions()
        {
            RolePermissions = new List<RolePermission>();
        }
        #endregion
    }
}
