using System.ComponentModel;

namespace HR.Data.Enums
{
    public enum CurrencyTypeEnum : int
    {
        [Description("TL")]
        TL = 1,

        [Description("EURO")]
        EUR = 2,

        [Description("DOLAR")]
        USD = 3,

    }
}
