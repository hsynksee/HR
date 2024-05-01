using AutoMapper;
using HR.Application.Service.Interfaces;
using HR.Application.Service.Request;
using HR.Data.Entities;
using HR.Data.RepositoryInterfaces.Interfaces;
using Microsoft.AspNetCore.Http;
using SharedKernel.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Application.Service
{
    public class UserRoleService : IUserRoleService
    {
        private readonly IUserRoleRepository _userRoleRepository;
        private readonly IMapper _mapper;
        public UserRoleService(IUserRoleRepository userRoleRepository, IMapper mapper)
        {
            _userRoleRepository = userRoleRepository;
            _mapper = mapper;
        }

        public async Task<BaseResponse<List<UserRole>>> GetUsers()
        {
            var users = await _userRoleRepository.GetAll();


            return new BaseResponse<List<UserRole>>(users.ToList());
        }

    }
}
