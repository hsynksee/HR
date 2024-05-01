using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Service.Response.UserDemand
{
    public class AdvancePaymentListResponse
    {
        public int Id { get; set; }
        public string User { get; set; }
        public decimal Price { get; set; }
        public DateTime Date { get; set; }
        public int? Installment { get; set; }
        public string Description { get; set; }
    }
}
