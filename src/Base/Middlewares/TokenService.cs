using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using BackEndAPI.Models;
using BackEndAPI.Models.Data;
using BackEndAPI.src.Base.Utilities;
using Microsoft.IdentityModel.Tokens;

namespace BackEndAPI.src.Base.Middlewares
{
    public static class TokenService
    {
        public static AuthResponse GenerateToken(Usuario request)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(AppSettings.JwtKey);
            var expiresIn = DateTime.UtcNow.AddHours(5); // 5hors
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(
                    new Claim[]
                    {
                new Claim(JwtRegisteredClaimNames.Sid, request.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString()),
                new Claim(ClaimTypes.Email, request.Email),
                new Claim(ClaimTypes.Role, request.AccountType.ToString()),
                    }
                ),
                Expires = expiresIn,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            AuthResponse response = new AuthResponse()
            {
                Access_Token = tokenHandler.WriteToken(token),
                expires_in = (int)((expiresIn - DateTime.UtcNow).TotalHours * 3600000),
                Token_Type = "Bearer"
            };
            return response;
        }
    }
}