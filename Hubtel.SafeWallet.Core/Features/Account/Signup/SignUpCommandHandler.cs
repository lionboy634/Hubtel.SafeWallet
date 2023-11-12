using FluentResults;
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
    public class SignUpCommandHandler : IRequestHandler<SignUpCommand, Result>
    {
        private readonly IIdentityService _identityService;
        public SignUpCommandHandler(IIdentityService identityService)
        {
            _identityService = identityService;
        }
        public async Task<Result> Handle(SignUpCommand request, CancellationToken cancellationToken)
        {
            var user = new WalletOwner()
            {
                FirstName = request.FirstName,
                LastName= request.LastName,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
                UserName = request.Email,
            };
            //phone number must be unique
            var userExist = await _identityService.CheckUserByEmailOrPhone(request.Email, request.PhoneNumber);
            if(userExist)
            {
                return Result.Fail("User Already Exists");
            }
            var result = await _identityService.CreateUserAsync(user, request.Password );
            if (!result.Succeeded)
            {
                var errorMessages = result.Errors.Select(error => error.Description);
                var errorMessage = string.Join(", ", errorMessages);
                return Result.Fail($"{errorMessage}").WithError("Failed To Create User Account");
            }
            await _identityService.AddUserRole(user, "Member");

            return Result.Ok().WithSuccess(new Success("User Has Been Created Successfully"));

        }
    }
}
