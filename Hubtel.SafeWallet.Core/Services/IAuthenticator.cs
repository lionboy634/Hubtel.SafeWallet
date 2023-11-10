using Hubtel.SafeWallet.Core.Domain.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Hubtel.SafeWallet.Core.Services
{
    public interface IAuthenticator
    {
        Task<bool> ValidateUser(string email, string password);
        Task<string> GenerateToken();
    }

    public class Authenticator : IAuthenticator
    {
        private readonly IConfiguration _configuration;
        private readonly UserManager<WalletOwner> _userManager;
        private WalletOwner _user;
        public Authenticator(IConfiguration configuration, UserManager<WalletOwner> userManager)
        {
            _configuration = configuration;
            _userManager = userManager;
        }
        public async Task<bool> ValidateUser(string email, string password)
        {
            _user = await _userManager.FindByEmailAsync(email);
            return _user != null;
                //&& await _userManager.CheckPasswordAsync(_user, password);
        }

        public async Task<string> GenerateToken()
        {
            var key = Encoding.UTF8.GetBytes("djdjks-djk2393-djksd-338932jds-vbkwjje-39393");
            var secret = new SymmetricSecurityKey(key);
            var signingCredentials = new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
            var claims = await ListClaims();
            var tokenOptions = GenerateTokenOptions(signingCredentials, claims);
            return new JwtSecurityTokenHandler().WriteToken(tokenOptions);
        }

        private JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, List<Claim> claims)
        {
            var jwtSettings = _configuration.GetSection("JwtSettings");
            var tokenOptions = new JwtSecurityToken
            (
            issuer: jwtSettings.GetSection("validIssuer").Value,
            audience: jwtSettings.GetSection("validAudience").Value,
            claims: claims,
            expires: DateTime.Now.AddMinutes(Convert.ToDouble(jwtSettings.GetSection("expires").Value)),
            signingCredentials: signingCredentials
            );
            return tokenOptions;
        }
        private async Task<List<Claim>> ListClaims()
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, _user.Email)
            };
            var roles = await _userManager.GetRolesAsync(_user);
            if (roles.Any())
            {
                foreach (var role in roles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, role));
                }
            }

            return claims;
        }
    }
}
