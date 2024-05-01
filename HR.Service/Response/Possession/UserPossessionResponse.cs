using HR.Service.Request.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Service.Response.Possession
{
    public class UserPossessionResponse : IdRequest
    {
        public int PossessionCategoryId { get; set; }
        public string SerialNumber { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public string Descriptions { get; set; }
    }
}
