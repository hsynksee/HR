using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Data.Enums
{
    public enum StatusTypeEnum:int
    {
        [Description("Onaylandı")]
        Approved = 1,

        [Description("Onay Bekleniyor")]
        WaitingApproved = 2,

        [Description("Reddedildi")]
        Cancelled = 3
    }
}

