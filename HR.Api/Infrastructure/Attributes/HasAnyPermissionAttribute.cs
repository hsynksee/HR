using HR.Service.AppSettings;
using Microsoft.AspNetCore.Mvc.Filters;
using SharedKernel.Abstractions;
using SharedKernel.Exceptions;

namespace HR.Api.Infrastructure.Attributes
{
    [AttributeUsage(AttributeTargets.Method, Inherited = false)]
    public class HasAnyPermissionAttribute : ActionFilterAttribute
    {
        private readonly string[] _permissions;

        public HasAnyPermissionAttribute(string[] permissions)
        {
            _permissions = permissions;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var svc = filterContext.HttpContext.RequestServices;
            var appSettings = (IAppSettings)svc.GetService(typeof(IAppSettings));

            if (appSettings.CurrentUser?.Permissions == null |
                !appSettings.CurrentUser.Permissions.Intersect(_permissions).Any())
                throw new ForbiddenAccessException();

            base.OnActionExecuting(filterContext);
        }
    }
}
