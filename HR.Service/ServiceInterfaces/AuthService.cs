using AutoMapper;
using HR.Data.Abstractions;
using HR.Service.Request.User;
using HR.Service.ServiceInterfaces.Interfaces;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Abstractions;
using SharedKernel.Helpers;
using SharedKernel.Models;

namespace HR.Service.ServiceInterfaces
{
    public class AuthService : BaseAppService, IAuthService
    {
        public AuthService(IMapper mapper, IRepositoryWrapper repository, IAppSettings appSettings) : base(mapper, repository, appSettings)
        {
        }

        public async Task<BaseResponse<CurrentUser>> Login([FromBody] AuthenticateRequest request)
        {
            var userToCheck = await _repository.UserRepository.GetByEmail(request.Email);
            if (userToCheck == null)
                return new BaseResponse<CurrentUser>(null, "Giriş Bilgileri Hatalı..");

            var verifyPassword = HashingHelper.VerifyPasswordHash(request.Password, userToCheck.PasswordHash, userToCheck.PasswordSalt);
            if (verifyPassword == false)
                return new BaseResponse<CurrentUser>(null, "Giriş Bilgileri Hatalı..");

            userToCheck.SetLoginDate();
            _repository.UserRepository.Update(userToCheck);
            await _repository.Save();

            var res = _mapper.Map<CurrentUser>(userToCheck);

            return new BaseResponse<CurrentUser>(res);
        }

        public async Task<BaseResponse<CurrentUser?>> CurrentUser()
        {
            return new BaseResponse<CurrentUser?>(_appSettings.CurrentUser);

        }
    }
}
