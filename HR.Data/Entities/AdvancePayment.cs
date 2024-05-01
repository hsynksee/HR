using SharedKernel.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Data.Entities
{
    public partial class AdvancePayment : AuditableBaseEntity
    {
        public int UserId { get; protected set; }
        public decimal  Price { get; protected set; }
        public DateTime Date { get; protected set; }
        public int? Installment { get; protected set; }
        public string Description { get; protected set; }

        #region Virtuals
        public virtual User User { get;  protected set; }
        #endregion

        public AdvancePayment SetBaseInformation(int userId, decimal price, DateTime date, int? installment, string description)
        {
            UserId= userId;
            Price= price;
            Date= date;
            Installment= installment;
            Description= description;

            return this;
        }
    }
}
