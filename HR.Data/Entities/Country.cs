using SharedKernel.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Data.Entities
{
    public partial class Country : BaseEntity
    {
        public string Name { get; protected set; }
        public string Code { get; protected set; }
        public string PhoneCode { get; protected set; }

        #region Virtuals
        public virtual ICollection<City> Cities { get; protected set; }
        #endregion
    }
}
