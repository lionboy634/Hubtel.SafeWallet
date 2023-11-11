using Hubtel.SafeWallet.Core.Domain.Model;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hubtel.SafeWallet.Core.Services
{
    public interface IIdentityService
    {
        Task<IdentityResult> CreateUserAsync(WalletOwner user);
        Task AddUserRole(WalletOwner user, string Role);
        Task<WalletOwner> GetUserByEmail(string email);
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

        public async Task<IdentityResult> CreateUserAsync(WalletOwner user)
        {
            var result = await _userManager.CreateAsync(user);
            return result;
        }

        public async Task<WalletOwner> GetUserByEmail(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            return user;
        }
    }
}
