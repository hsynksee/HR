using HR.Data.Enums;
using SharedKernel.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Data.Entities
{
    public partial class UserPossession:AuditableBaseEntity
    {
        public int PossessionCategoryId { get;protected set; }
        public int UserId { get;protected set; }
        public string SerialNumber { get;protected set; }
        public DateTime IssueDate { get;protected set; }
        public DateTime ReturnDate { get;protected set; }
        public string Descriptions { get; protected set; }
        public PossessionCategory PossessionCategory { get;protected set; }
        public User User { get;protected set; }
        public UserPossession SetBaseInformation(int possessionCategoryId,int userId, string serialNumber , DateTime ıssueDate , DateTime returnDate , string descriptions)
        {
            PossessionCategoryId= possessionCategoryId;
            UserId = userId;
            SerialNumber= serialNumber;
            IssueDate = ıssueDate;
            ReturnDate = returnDate;
            Descriptions = descriptions;   
            return this;
        }
    }
}
