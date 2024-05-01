using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Data.Enums
{
    public enum MilitaryStatusEnum : int
    {
        [Description("Muaf")]
        Exempt = 1,

        [Description("Yapıldı")]
        Done = 2,

        [Description("Tecilli")]
        Delayed = 3,

        [Description("Yapılmadı")]
        NotDone = 4
    }
}
