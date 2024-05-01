using SharedKernel.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Data.Entities
{
    public partial class LeaveType : BaseEntity
    {
        public string Name { get; protected set; }
        public string Description { get; protected set; }
        public bool? IsFree { get; protected set; }
        public int Order { get; protected set; }

        #region Virtuals
        
        #endregion
    }
}
