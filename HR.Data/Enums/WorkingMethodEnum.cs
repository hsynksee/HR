using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Data.Enums
{
    public enum WorkingMethodEnum : int
    {
        [Description("Tam Zamanlı")]
        FullTime = 1,

        [Description("Yarı Zamanlı")]
        PartTime = 2,

        [Description("Uzaktan Çalışma")]
        Remote = 3,

        [Description("Hibrit Çalışma")]
        Hybrid = 4,

        [Description("Serbest Zamanlı")]
        Freelance = 5
    }
}
