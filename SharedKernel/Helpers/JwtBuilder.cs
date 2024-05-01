using JWT.Algorithms;
using JWT.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedKernel.Helpers
{
    public static class JwtBuilder
    {
        public static object Build(Dictionary<string, object> claims, JwtSettings jwtSettings)
        {
            var expireDate = DateTime.UtcNow.AddSeconds(jwtSettings.Expires);

            var builder = new JWT.Builder.JwtBuilder()
              .WithAlgorithm(new HMACSHA256Algorithm())
              .WithSecret(jwtSettings.Secret)
              .AddClaim(ClaimName.AuthenticationTime, DateTime.UtcNow.ToString())
              .AddClaim("http://schemas.microsoft.com/ws/2008/06/identity/claims/role", new string[] { "User" })
              .IssuedAt(DateTime.Now)
              .ExpirationTime(expireDate)
              .Issuer(jwtSettings.Issuer)
              .Id(Guid.NewGuid().ToString("N"));

            builder.AddClaims(claims);
            string token = builder.Encode();

            return new
            {
                access_token = "Bearer " + token,
                expires_in = expireDate,
                token_type = "bearer"
            };
        }
    }
}
