using HR.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Service.Request.User
{
    public class UserSalaryCreateRequest
    {
        public int UserId { get; set; }
        public decimal Salary { get; set; }
        public CurrencyTypeEnum CurrencyType { get; set; }
        public DateTime StartDate { get; set; }
        public PeriodEnum? Period { get; set; }
        public SalaryTypeEnum? SalaryType { get; set; }
    }
}
