using SharedKernel.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Data.Entities
{
    public partial class District : BaseEntity
    {
        public string Name { get; protected set; }
        public int CityId { get; protected set; }

        #region Virtuals
        public virtual City City { get; protected set; }
        #endregion
    }
}
