using HR.Service.Response.User;
using Microsoft.AspNetCore.Http;
using SharedKernel.Abstractions;
using SharedKernel.Constants;
using SharedKernel.Helpers;
using SharedKernel.Models;

namespace HR.Service.AppSettings
{
    public sealed class AppSettings : IAppSettings
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AppSettings(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;

        }

        public CurrentUser CurrentUser => GetValueFromContext<CurrentUser>(HttpContextKeys.CurrentUser);
        public JwtSettings JwtSettings => GetValueFromContext<JwtSettings>(HttpContextKeys.JwtSettings);

        public bool IsExists => CurrentUser != null;

        private T GetValueFromContext<T>(string contextKey)
        {
            if (_httpContextAccessor.HttpContext != null && _httpContextAccessor.HttpContext.Items.TryGetValue(contextKey, out object contextObject) && contextObject is T typedObject)
                return typedObject;

            return default;
        }
    }
}
