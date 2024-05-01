using HR.Data.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Service.Request.UserDemand
{
    public class ExpenseCreateRequest
    {
        public int UserId { get; set; }
        public IFormFile ReceiptDocument { get; set; }
        public ExpenseCategoryEnum CategoryId { get; set; }
        public decimal Price { get; set; }
        public DateTime ReceiptDate { get; set; }
        public int? TaxRate { get; set; }
        public string Description { get; set; }
        public string Message { get; set; }

    }
}
