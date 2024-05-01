using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Data.Enums
{
    public enum ObstacleDegreeEnum : int
    {
        [Description("1.Derece")]
        First = 1,

        [Description("2.Derece")]
        Second = 2
    }
}
