using Jambopay.Core.Domain.Customers;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Jambopay.Web.Framework.Authentication
{
    public class JsonWebTokenService : IJsonWebTokenService
    {
        #region Fields

        public IConfiguration Configuration { get; }

        #endregion

        #region Ctor

        public JsonWebTokenService(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        #endregion

        #region Methods

        public string GenerateJSONWebToken(Customer customer)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Configuration["Jwt:Key"]);

            var claims = new[] {
                new Claim(JwtRegisteredClaimNames.Sub, customer.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };
            var tokenDescriptor = new JwtSecurityToken(Configuration["Jwt:Issuer"],
            Configuration["Jwt:Issuer"],
            claims,
            expires: DateTime.Now.AddMinutes(120),
            signingCredentials: new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature));

            return tokenHandler.WriteToken(tokenDescriptor);
        }

        public static string GenerateRefreshTokenString()
        {
            var randomNumber = new byte[32];
            using var randomNumberGenerator = RandomNumberGenerator.Create();
            randomNumberGenerator.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }

        #endregion
    }
}
