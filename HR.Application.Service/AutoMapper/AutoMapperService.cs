using AutoMapper;
using HR.Application.Service.Request;
using HR.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Application.Service.AutoMapper
{
    public class AutoMapperService : Profile
    {
        public AutoMapperService()
        {
            #region Request
            CreateMap<UserCreateRequest, User>();
            #endregion

            #region Response
            
            #endregion
        }
    }
}
