using System.ComponentModel;

namespace HR.Data.Enums
{
    public enum SalaryTypeEnum : int
    {
        [Description("Brüt")]
        Gross = 1,

        [Description("Net")]
        Net = 2,

    }
}
