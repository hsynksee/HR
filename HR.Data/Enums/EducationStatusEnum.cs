using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Data.Enums
{
    public enum EducationStatusEnum : int
    {
        [Description("İlköğretim")]
        PrimaryEducation = 1,

        [Description("Ortaöğretim")]
        SecondaryEducation = 2,

        [Description("Lise")]
        HighSchool = 3,

        [Description("Ön Lisans")]
        AssociateDegree = 4,

        [Description("Lisans")]
        Licence = 5,

        [Description("Yüksek Lisans")]
        Degree = 6,

        [Description("Doktora")]
        Doctorate = 7
    }
}
