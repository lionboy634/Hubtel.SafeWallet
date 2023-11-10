using Hubtel.SafeWallet.Core.Domain.Model;
using Hubtel.SafeWallet.Core.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hubtel.SafeWallet.Core.Features.Account.Signup
{
    public class SignUpCommandHandler : IRequestHandler<SignUpCommand>
    {
        private readonly IIdentityService _identityService;
        public SignUpCommandHandler(IIdentityService identityService)
        {
            _identityService = identityService;
        }
        public async Task Handle(SignUpCommand request, CancellationToken cancellationToken)
        {
            var user = new WalletOwner()
            {
                Email = "rex@gmail.com",
                PhoneNumber = "0244649655",
                UserName = "rex@gmail.com",
            };
            var result = await _identityService.CreateUserAsync(user);
            if (result.Succeeded)
            {
                await _identityService.AddUserRole(user, "Member");
            }
            
        }
    }
}
