using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Data.Enums
{
    public enum SpousesEmploymentStatusEnum : int
    {
        [Description("Çalışıyor")]
        Working = 1,

        [Description("Çalışmıyor")]
        NotWorking = 2,

        [Description("Emekli")]
        Retired = 3
    }
}
