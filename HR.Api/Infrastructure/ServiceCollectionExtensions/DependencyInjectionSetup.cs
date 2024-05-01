using HR.Service.ServiceInterfaces.Interfaces;
using HR.Service.ServiceInterfaces;
using HR.Data.Abstractions;
using HR.Service.AppSettings;
using SharedKernel.Abstractions;
using SharedKernel.FileUploader.Models;
using HR.Data.Entities;

namespace HR.Api.Infrastructure.ServiceCollectionExtensions
{
    public static class DependencyInjectionSetup
    {
        public static void AddDependencyInjectionSetup(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
            services.AddScoped<IFileWriter, FileWriter>();
            services.AddSingleton<IAppSettings, AppSettings>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IUserDemandService, UserDemandService>();
            services.AddScoped<ISystemAppService, SystemAppService>();
            services.AddScoped<ICompanyService, CompanyService>();
            services.AddScoped<ILocationService, LocationService>();
            services.AddScoped<ILeaveSettingService, LeaveSettingService>();
            services.AddScoped<IPossessionCategoryService, PossessionCategoryService>();
            services.AddScoped<IUserPossessionService, UserPossessionService>();
        }
    }
}
