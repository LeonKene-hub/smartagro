using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SmartAgro.Services
{
    public static class JWTService
    {
        public static Guid GetUserIdFromToken(string token)
        {
            var handler = new JwtSecurityTokenHandler();
            var readedToken = handler.ReadJwtToken(token);

            var claim = readedToken.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Sub) ;

            return Guid.Parse(claim.Value);
        }
    }
}
