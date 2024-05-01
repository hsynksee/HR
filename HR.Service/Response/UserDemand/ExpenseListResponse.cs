using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Service.Response.UserDemand
{
    public class ExpenseListResponse
    {
        public int Id { get; set; }
        public string User { get; set; }
        public string ReceiptDocumentPath { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
        public DateTime ReceiptDate { get; set; }
        public int? TaxRate { get; set; }
        public string Description { get; set; }
        public string Message { get; set; }
    }
}
