using HR.Data.Enums;
using SharedKernel.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Data.Entities
{
    public partial class Expense : AuditableBaseEntity
    {
        public int UserId { get; protected set; }
        public string ReceiptDocumentPath { get; protected set; }
        public string ReceiptDocumentExtension { get; protected set; }
        public ExpenseCategoryEnum? CategoryId { get; protected set; }
        public decimal?  Price { get; protected set; }
        public DateTime? ReceiptDate { get; protected set; }
        public int? TaxRate { get; protected set; }
        public string Description { get; protected set; }
        public string Message { get; protected set; }

        #region Virtuals
        public virtual User User { get; protected set; }
        #endregion

        public Expense SetBaseInformation(int userId, string receiptDocumentPath, string receiptDocumentExtension, ExpenseCategoryEnum? categoryId, decimal? price, DateTime? receiptDate, int? taxRate, string description, string message)
        {
            this.UserId= userId;
            this.ReceiptDocumentPath = receiptDocumentPath;
            this.ReceiptDocumentExtension= receiptDocumentExtension;
            this.CategoryId= categoryId;
            this.Price= price;
            this.ReceiptDate= receiptDate;
            this.TaxRate= taxRate;
            this.Description= description;
            this.Message= message;

            return this;
        }
    }
}
