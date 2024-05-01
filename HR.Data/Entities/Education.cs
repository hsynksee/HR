using SharedKernel.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Data.Entities
{
    public partial class Education : BaseEntity
    {
        public int UserId { get; protected set; }
        public string Name { get; protected set; }
        public int? Status { get; protected set; }
        public int? Level { get; protected set; }
    }
}
