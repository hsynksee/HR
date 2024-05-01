using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Data.Enums
{
    public enum MaritalStatusEnum : int
    {
        [Description("Evli")]
        Married = 1,

        [Description("Bekar")]
        Single = 2
    }
}
