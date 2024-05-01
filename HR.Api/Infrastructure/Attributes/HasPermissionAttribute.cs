using Microsoft.AspNetCore.Mvc.Filters;
using SharedKernel.Abstractions;
using SharedKernel.Exceptions;

namespace HR.Api.Infrastructure.Attributes
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = false)]
    public class HasPermissionAttribute : ActionFilterAttribute
    {
        private readonly string _permission;

        public HasPermissionAttribute(string permission)
        {
            _permission = permission;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var svc = filterContext.HttpContext.RequestServices;
            var appSettings = (IAppSettings)svc.GetService(typeof(IAppSettings));

            if (appSettings.CurrentUser?.Permissions == null || !appSettings.CurrentUser.Permissions.Any(p => p == _permission))
                throw new ForbiddenAccessException();

            base.OnActionExecuting(filterContext);
        }

    }
}
