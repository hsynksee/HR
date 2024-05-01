using System.ComponentModel;

namespace HR.Data.Enums
{
    public enum AccountTypeEnum : int
    {
        [Description("Diğer")]
        Other = 1,

        [Description("Vadeli")]
        Deposit = 2,

        [Description("Vadesiz")]
        NotDeposit = 3

    }
}
