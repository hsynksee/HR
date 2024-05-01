using System.ComponentModel;

namespace HR.Data.Enums
{
    public enum ExpenseCategoryEnum : int
    {
        [Description("Diğer")]
        Other = 1,

        [Description("İş Giderleri")]
        BusinessExpenses = 2,

        [Description("Fatura ve Giderler")]
        InvoicesExpenses = 3,

        [Description("Eğitim ve Kurslar")]
        TrainingCourses = 4,

        [Description("Yiyecek ve İçecek")]
        FoodDrink = 5,

        [Description("Yolculuk ve Ulaşım")]
        TravelTransportation = 6
    }
}
