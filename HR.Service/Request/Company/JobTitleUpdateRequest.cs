﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Service.Request.User
{
    public class JobTitleUpdateRequest : IdNameRequest
    {
        public int DepartmentId { get; set; }
    }
}
