using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Data.Enums
{
    public enum LeaveTypeEnum:int
    {
        [Description("Askerlik")]
        MilitaryLeave = 1,

        [Description("Babalık")]
        ParentalLeave = 2,

        [Description("Doğum")]
        MaternityLeave = 3,

        [Description("Doğum Sonrası")]
        PostpartumLeave = 4,

        [Description("Evlilik")]
        MarriageLeave = 5,

        [Description("Hastalık")]
        SickLeave = 6,
        [Description("İş Arama")]
        jobseekersLeave = 7,

        [Description("Mazeret")]
        ExcuseLeave = 8,

        [Description("Süt")]
        BreastfeedingBabyLeave = 9,

        [Description("Uzaktan Çalışma")]
        RemoteWorkingLeave = 10,

        [Description("Ücretsiz")]
        UnpaidLeave = 11,

        [Description("Vefat")]
        BereavementLeave = 12,

        [Description("Yıllık")]
        VacationLeave = 11,

        [Description("Yol")]
        RoadLeave = 12,
    }
}
