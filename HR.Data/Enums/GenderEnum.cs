using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Data.Enums
{
    public enum GenderEnum : int
    {
        [Description("Erkek")]
        Male = 1,

        [Description("Kadın")]
        Female = 2
    }
}
