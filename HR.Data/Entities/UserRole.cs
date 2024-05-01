using SharedKernel.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Data.Entities
{
    public class UserRole : BaseEntity
    {
        public UserRole(int userId, int roleId)
        {
            UserId = userId;
            RoleId = roleId;
        }

        public int UserId { get; protected set; }
        public int RoleId { get; protected set; }

        #region Virtuals
        public virtual User User { get; protected set; }
        public virtual Role Role { get; protected set; }
        #endregion
    }
}
