using HR.Service.Response.User;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using SharedKernel.Constants;
using SharedKernel.Helpers;
using SharedKernel.Models;
using System.Text;

namespace HR.Api.Infrastructure.ServiceCollectionExtensions
{
    public static class AuthenticationExtensions
    {
        public static void BuildAuthentication(this IServiceCollection services, IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));

            var jwtSettingsSection = configuration.GetSection("JwtSettings");
            //var customSettingsSection = configuration.GetSection("CustomSettings");

            services.Configure<JwtSettings>(jwtSettingsSection);
            //services.Configure<CustomSettings>(customSettingsSection);

            var jwtSettings = jwtSettingsSection.Get<JwtSettings>();
            //var customSettings = customSettingsSection.Get<CustomSettings>();

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = true;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Secret)),
                    ValidateIssuer = true,
                    ValidateAudience = false,
                    ValidIssuer = jwtSettings.Issuer
                };
                options.Events = new JwtBearerEvents
                {
                    OnTokenValidated = tokenContext =>
                    {
                        var user = JsonConvert.DeserializeObject<CurrentUser>(tokenContext.Principal.FindFirst("user")?.Value);

                        httpContextAccessor.HttpContext.Items.Add(HttpContextKeys.CurrentUser, user);

                        return Task.CompletedTask;
                    },
                    OnAuthenticationFailed = async tokenContext =>
                    {


                    },
                    OnMessageReceived = tokenContext =>
                    {
                        httpContextAccessor.HttpContext.Items.Add(HttpContextKeys.JwtSettings, jwtSettings);
                        //httpContextAccessor.HttpContext.Items.Add(HttpContextKeys.CustomSettings, customSettings);
                        return Task.CompletedTask;
                    }
                };
            });
        }
    }
}
