using HR.Service.AppSettings;
using Microsoft.AspNetCore.Mvc.Filters;
using SharedKernel.Abstractions;
using SharedKernel.Exceptions;

namespace HR.Api.Infrastructure.Attributes
{
    [AttributeUsage(AttributeTargets.Method, Inherited = false)]
    public class HasAllPermissionsAttribute : ActionFilterAttribute
    {
        private readonly string[] _permissions;

        public HasAllPermissionsAttribute(string[] permissions)
        {
            _permissions = permissions;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var svc = filterContext.HttpContext.RequestServices;
            var appSettings = (IAppSettings)svc.GetService(typeof(IAppSettings));

            if (appSettings.CurrentUser?.Permissions == null |
                !_permissions.ToList().TrueForAll(reqPerm => appSettings.CurrentUser.Permissions.Any(curPerm => curPerm == reqPerm)))
                throw new ForbiddenAccessException();

            base.OnActionExecuting(filterContext);
        }
    }
}
