using System.ComponentModel;

namespace HR.Data.Enums
{
    public enum PeriodEnum : int
    {
        [Description("Aylık")]
        Monthly = 1,

        [Description("Haftalık")]
        Weekly = 2,

        [Description("Günlük")]
        Daily = 3,

    }
}
