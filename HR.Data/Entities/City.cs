using SharedKernel.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Data.Entities
{
    public partial class City : BaseEntity
    {
        public string Name { get; protected set; }
        public int CountryId { get; protected set; }

        #region Virtuals
        public virtual Country Country { get; protected set; }
        public virtual ICollection<District> Districts { get; protected set; }
        #endregion
    }
}
