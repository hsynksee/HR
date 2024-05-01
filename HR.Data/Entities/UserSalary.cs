using HR.Data.Enums;
using SharedKernel.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Data.Entities
{
    public partial class UserSalary : AuditableBaseEntity
    {
        public int UserId { get; protected set; }
        public decimal Salary { get; protected set; }
        public CurrencyTypeEnum CurrencyType { get; protected set; }
        public DateTime StartDate { get; protected set; }
        public PeriodEnum? Period { get; protected set; }
        public SalaryTypeEnum? SalaryType { get; protected set; }

        #region Virtuals
        public virtual User User { get; protected set; }
        #endregion

        public UserSalary SetBaseInformation(int userId, decimal salary, CurrencyTypeEnum currencyType, DateTime startDate, PeriodEnum? period, SalaryTypeEnum? salaryType)
        {
            this.UserId = userId;
            this.Salary = salary;
            this.CurrencyType = currencyType;
            this.StartDate = startDate;
            this.Period = period;
            this.SalaryType = salaryType;

            return this;
        }

        public UserSalary Update(decimal salary, CurrencyTypeEnum currencyType, DateTime startDate, PeriodEnum? period, SalaryTypeEnum? salaryType)
        {
            this.Salary = salary;
            this.CurrencyType = currencyType;
            this.StartDate = startDate;
            this.Period = period;
            this.SalaryType = salaryType;

            return this;
        }

    }
}
