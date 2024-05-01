using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Data.Enums
{
    public enum BloodTypeEnum : int
    {
        [Description("A Rh+")]
        APozitif = 1,

        [Description("B Rh+")]
        BPozitif = 2,

        [Description("0 Rh+")]
        ZeroPozitif = 2,

        [Description("AB Rh+")]
        ABPozitif = 4,

        [Description("A Rh-")]
        ANegatif = 5,

        [Description("B Rh-")]
        BNegatif = 6,

        [Description("0 Rh-")]
        ZeroNegatif = 7,

        [Description("AB Rh-")]
        ABNegatif = 8,
    }
}
