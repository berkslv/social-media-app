using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Core.Entity.Concrete;
using Core.Extensions;
using Core.Utilities.Security.Encyption;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Core.Utilities.Security.Jwt
{
    public class JwtHelper : ITokenHelper
    {
        private DateTime _accessTokenExpiration;
        public JwtHelper()
        {
            _accessTokenExpiration = DateTime.UtcNow.AddMinutes(Int32.Parse(Environment.GetEnvironmentVariable("TOKEN_ACCESS_TOKEN_EXPIRATION")));
        }
        
        public AccessToken CreateToken(UserBase user, List<OperationClaim> operationClaims)
        {
            var securityKey = SecurityKeyHelper.CreateSecurityKey(Environment.GetEnvironmentVariable("TOKEN_SECURITY_KEY"));
            var signingCredentials = SigningCredentialsHelper.CreateSigningCredentials(securityKey);
            var jwt = CreateJwtSecurityToken(user, signingCredentials, operationClaims);
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var token = jwtSecurityTokenHandler.WriteToken(jwt);

            return new AccessToken
            {
                Token = token,
                Expiration = _accessTokenExpiration
            };

        }

        public JwtSecurityToken CreateJwtSecurityToken(UserBase user, 
            SigningCredentials signingCredentials, List<OperationClaim> operationClaims)
        {
            var jwt = new JwtSecurityToken(
                issuer: Environment.GetEnvironmentVariable("TOKEN_ISSUER"),
                audience: Environment.GetEnvironmentVariable("TOKEN_AUDIENCE"),
                expires:_accessTokenExpiration,
                notBefore:DateTime.Now,
                claims: SetClaims(user,operationClaims),
                signingCredentials:signingCredentials
            );
            return jwt;
        }

        private IEnumerable<Claim> SetClaims(UserBase user, List<OperationClaim> operationClaims)
        {
            var claims = new List<Claim>();
            claims.AddNameIdentifier(user.Id.ToString());
            claims.AddEmail(user.Email);
            claims.AddName(user.Name);
            claims.AddRoles(operationClaims.Select(c=>c.Name).ToArray());
            
            return claims;
        }
    }
}
