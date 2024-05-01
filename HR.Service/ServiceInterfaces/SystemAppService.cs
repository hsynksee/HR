using AutoMapper;
using HR.Data.Abstractions;
using HR.Data.Entities;
using HR.Service.ServiceInterfaces.Interfaces;
using SharedKernel.Abstractions;

namespace HR.Service.ServiceInterfaces
{
    public class SystemAppService : BaseAppService, ISystemAppService
    {
        public SystemAppService(IMapper mapper, IRepositoryWrapper repository, IAppSettings appSettings) : base(mapper, repository, appSettings)
        {
        }

        public async Task SetUserPermissionsAsync()
        {
            if (_appSettings.IsExists)
            {
                User currentUser = await _repository.UserRepository.FindById(_appSettings.CurrentUser.Id);

                List<string> permissionCodes = new List<string>();

                foreach (var item in currentUser.UserRoles)
                {
                    permissionCodes.AddRange(item.Role.RolePermissions.Select(a => a.Permission.Code).ToList());
                }

                _appSettings.CurrentUser.Permissions = permissionCodes;

            }
        }
    }
}
