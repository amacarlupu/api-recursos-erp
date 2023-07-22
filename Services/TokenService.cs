using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SupportPageApi.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SupportPageApi.Services
{
    public class TokenService
    {
        private TokenSetting _tokenKey;

        public TokenService(IOptions<TokenSetting> tokenSetting)
        {
            _tokenKey = tokenSetting.Value;
        }

        public dynamic GenerateToken(User usuario)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenKey.Key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            // crear claims
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, usuario.Username),
                new Claim(ClaimTypes.Email, usuario.Email),
                new Claim(ClaimTypes.MobilePhone, usuario.Phone),
                new Claim(ClaimTypes.Role, usuario.Deporte)
            };

            // crear token
            var token = new JwtSecurityToken(
                    _tokenKey.Issuer,
                    _tokenKey.Audience,
                    claims,
                    expires: DateTime.Now.AddMinutes(15),
                    signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }


    }
}
