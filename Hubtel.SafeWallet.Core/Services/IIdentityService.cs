using Hubtel.SafeWallet.Core.Domain.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hubtel.SafeWallet.Core.Services
{
    public interface IIdentityService
    {
        Task<IdentityResult> CreateUserAsync(WalletOwner user, string password);
        Task AddUserRole(WalletOwner user, string Role);
        Task<WalletOwner> GetUserByEmail(string? email);
        Task<bool> CheckUserByPhone(string phone);
        Task<bool> CheckUserByEmailOrPhone(string email, string phone);
    }


    public class IdentityService : IIdentityService
    {
        private UserManager<WalletOwner> _userManager;
        public IdentityService(UserManager<WalletOwner> userManager)
        {
            _userManager = userManager;
        }

        public async Task AddUserRole(WalletOwner user, string role)
        {
            await _userManager.AddToRoleAsync(user, role);
        }

        public async Task<bool> CheckUserByPhone(string phone)
        {
            var user = await _userManager.Users.Where(c => c.PhoneNumber == phone).ToListAsync();
            if (user.Any())
            {
                return true;
            }
            return false;
           
        }

        public async Task<IdentityResult> CreateUserAsync(WalletOwner user, string password)
        {
            var result = await _userManager.CreateAsync(user, password);
            return result;
        }

        public async Task<WalletOwner> GetUserByEmail(string? email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            return user;
        }

        public async Task<bool> CheckUserByEmailOrPhone(string email, string phone)
        {
            var user = await _userManager.Users.Where(c => c.Email == email || c.PhoneNumber == phone).FirstOrDefaultAsync();
            return user != null;
        }
    }
}
