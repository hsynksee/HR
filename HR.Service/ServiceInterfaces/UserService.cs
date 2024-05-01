using AutoMapper;
using HR.Data.Abstractions;
using HR.Data.Entities;
using HR.Service.Request.User;
using HR.Service.Request.UserJobPosition;
using HR.Service.Response.User;
using HR.Service.Response.UserJobPosition;
using HR.Service.ServiceInterfaces.Interfaces;
using SharedKernel.Abstractions;
using SharedKernel.Constants;
using SharedKernel.Helpers;

namespace HR.Service.ServiceInterfaces
{
    public class UserService : BaseAppService, IUserService
    {
        public UserService(IMapper mapper, IRepositoryWrapper repository, IAppSettings appSettings) : base(mapper, repository, appSettings)
        {
        }

        #region Role
        public async Task<BaseResponse<List<RoleResponse>>> GetRoles()
        {
            var roles = _mapper.Map<List<RoleResponse>>(await _repository.RoleRepository.GetAll());
            return new BaseResponse<List<RoleResponse>>(roles);
        }

        public async Task<BaseResponse<RoleResponse>> GetRoleById(int id)
        {
            var role = _mapper.Map<RoleResponse>(await _repository.RoleRepository.FindById(id));
            return new BaseResponse<RoleResponse>(role);
        }
        #endregion

        #region User
        public async Task<BaseResponse<int>> CreateUser(UserCreateRequest request)
        {
            var checkUserEmail = await _repository.UserRepository.GetByEmail(request.EmailBusiness);
            if (checkUserEmail != null)
                return new BaseResponse<int>(0, "Bu kullanıcı mail adresine sahip başka bir kullanıcı bulunmaktadır..");

            byte[] passwordHash, passwordSalt;
            string password = "123456";// RandomPasswordGenerator.GeneratePassword(true, true, true, true, 8);// Otomatik şifre oluşlturma
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);

            var user = new User().SetBaseInformation(
                    request.Name,
                    request.Surname,
                    request.EmailBusiness,
                    request.EmailPersonal,
                    request.PhoneBusiness,
                    request.PhonePersonal,
                    request.StartDate,
                    request.AccessType,
                    request.ContractType,
                    request.ContractEndDate,
                    passwordSalt,
                    passwordHash
                );
            user.AdjustRoles(request.Roles);

            await _repository.UserRepository.Create(user);
            await _repository.Save();

            return new BaseResponse<int>(user.Id);
        }

        public async Task<BaseResponse<int>> UpdateUser(UserUpdateRequest request)
        {
            var user = await _repository.UserRepository.FindById(request.Id);
            if (user == null)
                return new BaseResponse<int>(0, "Kullanıcı bulunmaktadır..");

            user.Update(
                request.Name,
                request.Surname,
                request.EmailBusiness,
                request.EmailPersonal,
                request.PhoneBusiness,
                request.PhonePersonal,
                request.StartDate,
                request.AccessType,
                request.ContractType,
                request.ContractEndDate);
            user.AdjustRoles(request.Roles);

            _repository.UserRepository.Update(user);
            await _repository.Save();

            return new BaseResponse<int>(user.Id);
        }

        public async Task<BaseResponse<List<UserResponse>>> GetUsers()
        {
            var list = _mapper.Map<List<UserResponse>>(await _repository.UserRepository.GetAll());

            return new BaseResponse<List<UserResponse>>(list);
        }

        public async Task<BaseResponse<UserResponse>> GetUserById(int id)
        {
            var user = _mapper.Map<UserResponse>(await _repository.UserRepository.FindById(id));
            return new BaseResponse<UserResponse>(user);
        }

        public async Task<BaseResponse<bool>> SetUserActive(int id)
        {
            var user = await _repository.UserRepository.FindById(id);
            if (user == null)
                return new BaseResponse<bool>(false, "Kullanıcı bulunmaktadır..");

            user.SetActive(!user.IsActive);
            _repository.UserRepository.Update(user);
            await _repository.Save();

            string message = "";
            if (!user.IsActive) message = "Kullanıcı pasif yapılmıştır.";
            else message = "Kullanıcı aktif yapılmıştır.";
            return new BaseResponse<bool>(true, message);
        }

        public async Task<BaseResponse<bool>> ChangePassword(ChangePasswordRequest request)
        {
            if (_appSettings.CurrentUser.Id != request.UserId)
                return new BaseResponse<bool>(false, "Sadece kendi şifrenizi değiştirebilirsiniz..");

            var user = await _repository.UserRepository.FindById(request.UserId);

            var verifyPassword = HashingHelper.VerifyPasswordHash(request.OldPassword, user.PasswordHash, user.PasswordSalt);
            if (verifyPassword == false)
                return new BaseResponse<bool>(false, "Eski şifre hatalı..");

            if (request.NewPassword != request.NewPasswordRepeat)
                return new BaseResponse<bool>(false, "Şifreler uyuşmamaktadır..");

            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(request.NewPassword, out passwordHash, out passwordSalt);

            user.SetChangePassword(passwordSalt, passwordHash);

            _repository.UserRepository.Update(user);
            await _repository.Save();

            return new BaseResponse<bool>(true, "Şifre değiştirilmiştir..");
        }

        public async Task<BaseResponse<Guid?>> ForgotPassword(ForgotRequest request)
        {
            var user = await _repository.UserRepository.GetByEmail(request.Email);
            if (user == null) 
                return new BaseResponse<Guid?>(null, "Kullanıcı bulunamamıştır..");

            Guid guidId = Guid.NewGuid();
            user.SetForgotPasswordKey(guidId);
            _repository.UserRepository.Update(user);
            await _repository.Save();

            #region Send Email
            //yazılacak
            #endregion

            return new BaseResponse<Guid?>(guidId, "Şifre değişikliği için mail gönderilmiştir..");
        }

        public async Task<BaseResponse<bool>> ForgotChangePassword(ForgotChangePassword request)
        {
            var user = await _repository.UserRepository.GetByAuthKey(request.AuthKey);

            if (user == null) 
                return new BaseResponse<bool>(false, "Kullanıcı bulunamamıştır..");

            if (request.NewPassword != request.NewPasswordRepeat)
                return new BaseResponse<bool>(false, "Şifreler uyuşmamaktadır..");

            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(request.NewPassword, out passwordHash, out passwordSalt);

            user.SetChangePassword(passwordSalt, passwordHash);

            _repository.UserRepository.Update(user);
            await _repository.Save();

            return new BaseResponse<bool>(true, "Şifre değiştirilmiştir..");
        }
        #endregion

        #region User Personel Information
        public async Task<BaseResponse<int>> SaveUserPersonelInformation(UserPersonelInformationSaveRequest request)
        {
            var checkUser = await _repository.UserRepository.FindById(request.UserId);
            if (checkUser == null)
                return new BaseResponse<int>(0, "Bu kullanıcı mevcut değildir..");

            var checkUserPersonelInformation = await _repository.UserPersonelInformationRepository.FindByUserId(request.UserId);
            if (checkUserPersonelInformation == null)
                return await this.CreateUserPersonelInformation(request);
            else
                return await this.UpdateUserPersonelInformation(request);
        }

        public async Task<BaseResponse<int>> CreateUserPersonelInformation(UserPersonelInformationSaveRequest request)
        {
            var checkUserPersonelInformation = await _repository.UserPersonelInformationRepository.FindByUserId(request.UserId);
            if (checkUserPersonelInformation != null)
                return new BaseResponse<int>(0, "Bu kullanıcı bilgileri mevcuttur..");

            var identityNumber = EncryptHelper.Encrypt(request.IdentityNumber, HttpContextKeys.IdentityNumberKey);
            var userPersonelInformation = new UserPersonelInformation().SetBaseInformation(
                request.UserId,
                request.DateOfBirth,
                identityNumber,
                request.MaritalStatus,
                request.SpousesEmploymentStatus,
                request.Gender,
                request.ObstacleDegree,
                request.NumberOfChildren,
                request.BloodType,
                request.MilitaryStatus,
                request.MilitaryPostponementDate,
                request.EducationStatus,
                request.HighestLevelOfEducationCompleted,
                request.LastCompletedEducationalInstitution);

            await _repository.UserPersonelInformationRepository.Create(userPersonelInformation);
            await _repository.Save();

            return new BaseResponse<int>(userPersonelInformation.Id);
        }

        public async Task<BaseResponse<int>> UpdateUserPersonelInformation(UserPersonelInformationSaveRequest request)
        {
            var userPersonelInformation = await _repository.UserPersonelInformationRepository.FindByUserId(request.UserId);
            if (userPersonelInformation == null)
                return new BaseResponse<int>(0, "Bu kullanıcı bilgileri mevcut değil..");

            var identityNumber = EncryptHelper.Encrypt(request.IdentityNumber, HttpContextKeys.IdentityNumberKey);
            userPersonelInformation.Update(
                request.DateOfBirth,
                identityNumber,
                request.MaritalStatus,
                request.SpousesEmploymentStatus,
                request.Gender,
                request.ObstacleDegree,
                request.NumberOfChildren,
                request.BloodType,
                request.MilitaryStatus,
                request.MilitaryPostponementDate,
                request.EducationStatus,
                request.HighestLevelOfEducationCompleted,
                request.LastCompletedEducationalInstitution);

            _repository.UserPersonelInformationRepository.Update(userPersonelInformation);
            await _repository.Save();

            return new BaseResponse<int>(userPersonelInformation.Id);
        }

        public async Task<BaseResponse<UserPersonelInformationResponse>> GetUserPersonelInformationByUserId(int userId)
        {
            var user = _mapper.Map<UserPersonelInformationResponse>(await _repository.UserPersonelInformationRepository.FindByUserId(userId));
            return new BaseResponse<UserPersonelInformationResponse>(user);
        }
        #endregion

        #region User Other Information
        public async Task<BaseResponse<int>> SaveUserOtherInformation(UserOtherInformationSaveRequest request)
        {
            var checkUser = await _repository.UserRepository.FindById(request.UserId);
            if (checkUser == null)
                return new BaseResponse<int>(0, "Bu kullanıcı mevcut değildir..");

            var checkUserOtherInformation = await _repository.UserOtherInformationRepository.FindByUserId(request.UserId);
            if (checkUserOtherInformation == null)
                return await this.CreateUserOtherInformation(request);
            else
                return await this.UpdateUserOtherInformation(request);
        }

        public async Task<BaseResponse<int>> CreateUserOtherInformation(UserOtherInformationSaveRequest request)
        {
            var checkUserOtherInformation = await _repository.UserOtherInformationRepository.FindByUserId(request.UserId);
            if (checkUserOtherInformation != null)
                return new BaseResponse<int>(0, "Bu kullanıcı bilgileri mevcuttur..");

            var userOtherInformation = new UserOtherInformation().SetBaseInformation(
                request.UserId,
                request.DistrictId,
                request.Address,
                request.PostCode,
                request.HomePhone,
                request.BankName,
                request.AccountType,
                request.AccountNumber,
                request.IBAN,
                request.EmergencyContactPerson,
                request.EmergencyContactDegree,
                request.EmergencyContactPhone,
                request.ConnectionName,
                request.ConnectionAddress);

            await _repository.UserOtherInformationRepository.Create(userOtherInformation);
            await _repository.Save();

            return new BaseResponse<int>(userOtherInformation.Id);
        }

        public async Task<BaseResponse<int>> UpdateUserOtherInformation(UserOtherInformationSaveRequest request)
        {
            var userOtherInformation = await _repository.UserOtherInformationRepository.FindByUserId(request.UserId);
            if (userOtherInformation == null)
                return new BaseResponse<int>(0, "Bu kullanıcı bilgileri mevcut değil..");

            userOtherInformation.Update(
                request.DistrictId,
                request.Address,
                request.PostCode,
                request.HomePhone,
                request.BankName,
                request.AccountType,
                request.AccountNumber,
                request.IBAN,
                request.EmergencyContactPerson,
                request.EmergencyContactDegree,
                request.EmergencyContactPhone,
                request.ConnectionName,
                request.ConnectionAddress);

            _repository.UserOtherInformationRepository.Update(userOtherInformation);
            await _repository.Save();

            return new BaseResponse<int>(userOtherInformation.Id);
        }

        public async Task<BaseResponse<UserOtherInformationResponse>> GetUserOtherInformationByUserId(int userId)
        {
            var user = _mapper.Map<UserOtherInformationResponse>(await _repository.UserOtherInformationRepository.FindByUserId(userId));
            return new BaseResponse<UserOtherInformationResponse>(user);
        }
        #endregion

        #region User Job
        public async Task<BaseResponse<int>> CreateUserJobPosition(UserJobPositionCreateRequest request)
        {
            var activeJobPosition = await _repository.UserJobPositionRepository.UserJobPositionActive(request.UserId, request.StartDate);
            if (activeJobPosition)
                return new BaseResponse<int>(0, "Bu kullanıcının aktif başka bir pozisyonu mevcuttur..");

            var userJobPosition = new UserJobPosition().SetBaseInformation(
                request.UserId,
                request.JobTitleId,
                request.ApprovalProcessUnitId,
                request.ManagerId,
                request.WorkingMethod,
                request.StartDate,
                request.EndDate);

            await _repository.UserJobPositionRepository.Create(userJobPosition);
            await _repository.Save();

            return new BaseResponse<int>(userJobPosition.Id);
        }

        public async Task<BaseResponse<int>> UpdateUserJobPosition(UserJobPositionUpdateRequest request)
        {
            var activeUserJobPosition = await _repository.UserJobPositionRepository.UserJobPositionActive(request.UserId, request.StartDate, request.Id);
            if (activeUserJobPosition)
                return new BaseResponse<int>(0, "Bu kullanıcının aktif başka bir pozisyonu mevcuttur..");

            var userJobPosition = await _repository.UserJobPositionRepository.FindById(request.Id);
            if (userJobPosition == null)
                return new BaseResponse<int>(0, "Kullanıcı İş Pozisyonu Bulunmaktadır..");

            userJobPosition.Update(
                request.JobTitleId,
                request.ApprovalProcessUnitId,
                request.ManagerId,
                request.WorkingMethod,
                request.StartDate,
                request.EndDate);

            _repository.UserJobPositionRepository.Update(userJobPosition);
            await _repository.Save();

            return new BaseResponse<int>(userJobPosition.Id);
        }

        public async Task<BaseResponse<bool>> DeleteUserJobPosition(int id)
        {
            var userJobPosition = await _repository.UserJobPositionRepository.FindById(id);
            if (userJobPosition == null) 
                return new BaseResponse<bool>(false, "Kullanıcı iş pozisyonu bulunamadı..");

            await _repository.UserJobPositionRepository.Delete(userJobPosition.Id);
            var result = await _repository.Save() > 0;

            return new BaseResponse<bool>(result);
        }

        public async Task<BaseResponse<UserJobPositionResponse>> GetUserJobPositionById(int id)
        {
            var userJobPostion = _mapper.Map<UserJobPositionResponse>(await _repository.UserJobPositionRepository.FindById(id));
            return new BaseResponse<UserJobPositionResponse>(userJobPostion);
        }

        public async Task<BaseResponse<List<UserJobPositionResponse>>> GetUserJobPositionByUserId(int userId)
        {
            var userJobPostions = _mapper.Map<List<UserJobPositionResponse>>(await _repository.UserJobPositionRepository.FindAllByUserId(userId));
            return new BaseResponse<List<UserJobPositionResponse>>(userJobPostions);
        }
        #endregion

        #region User Salary
        public async Task<BaseResponse<int>> CreateUserSalary(UserSalaryCreateRequest request)
        {
            var userSalary = new UserSalary().SetBaseInformation(
                request.UserId,
                request.Salary,
                request.CurrencyType,
                request.StartDate,
                request.Period,
                request.SalaryType);

            await _repository.UserSalaryRepository.Create(userSalary);
            await _repository.Save();

            return new BaseResponse<int>(userSalary.Id);
        }

        public async Task<BaseResponse<int>> UpdateUserSalary(UserSalaryUpdateRequest request)
        {
            var userSalary = await _repository.UserSalaryRepository.FindById(request.Id);
            if (userSalary == null)
                return new BaseResponse<int>(0, "Kullanıcı Maaş bilgisi bulunamadı.");

            userSalary.Update(
                request.Salary,
                request.CurrencyType,
                request.StartDate,
                request.Period,
                request.SalaryType);

            _repository.UserSalaryRepository.Update(userSalary);
            await _repository.Save();

            return new BaseResponse<int>(userSalary.Id);
        }

        public async Task<BaseResponse<bool>> DeleteUserSalary(int id)
        {
            var userSalary = await _repository.UserSalaryRepository.FindById(id);
            if (userSalary == null)
                return new BaseResponse<bool>(false, "Kullanıcı Maaş bilgisi bulunamadı.");

            await _repository.UserSalaryRepository.Delete(userSalary.Id);
            var result = await _repository.Save() > 0;

            return new BaseResponse<bool>(result);
        }

        public async Task<BaseResponse<UserSalaryResponse>> GetUserSalaryById(int id)
        {
            var userSalary = _mapper.Map<UserSalaryResponse>(await _repository.UserSalaryRepository.FindById(id));
            return new BaseResponse<UserSalaryResponse>(userSalary);
        }

        public async Task<BaseResponse<List<UserSalaryResponse>>> GetUserSalaryByUserId(int userId)
        {
            var userSalaries = _mapper.Map<List<UserSalaryResponse>>(await _repository.UserSalaryRepository.FindAllByUserId(userId));
            return new BaseResponse<List<UserSalaryResponse>>(userSalaries);
        }
        #endregion
    }
}
