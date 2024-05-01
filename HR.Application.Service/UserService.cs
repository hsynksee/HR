using AutoMapper;
using HR.Application.Service.Interfaces;
using HR.Application.Service.Request;
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
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<BaseResponse<int>> CreateUser(UserCreateRequest request)
        {
            return new BaseResponse<int>(1);
        }
    }
}
