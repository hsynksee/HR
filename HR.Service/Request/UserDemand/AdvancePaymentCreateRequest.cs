using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Service.Request.UserDemand
{
    public class AdvancePaymentCreateRequest
    {
        public int UserId { get; set; }
        public decimal Price { get; set; }
        public DateTime Date { get; set; }
        public int? Installment { get; set; }
        public string Description { get; set; }
    }
}
