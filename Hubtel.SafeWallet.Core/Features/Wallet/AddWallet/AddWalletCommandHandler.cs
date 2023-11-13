using FluentResults;
using FluentValidation;
using Hubtel.SafeWallet.Core.Domain.Model;
using Hubtel.SafeWallet.Core.Domain.Repository;
using Hubtel.SafeWallet.Core.Services;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hubtel.SafeWallet.Core.Features.Wallet.AddWallet
{
    public class AddWalletCommandHandler : IRequestHandler<AddWalletCommand, Result>
    {
        private readonly IWalletRepository _walletRepository;
        private readonly ILogger<AddWalletCommandHandler> _logger;
        public AddWalletCommandHandler(
            IWalletRepository walletRepository,
            ILogger<AddWalletCommandHandler> logger)
        {
            _walletRepository = walletRepository;
            _logger = logger;
        }
        public async Task<Result> Handle(AddWalletCommand request, CancellationToken cancellationToken)
        {
            var accountNumber = request.AccountNumber.Trim();
            var accountExist = await _walletRepository.CheckDuplicateAccount(request.Owner, request.AccountNumber);
            if (accountExist)
            {
                return await Task.FromResult(Result.Fail("Wallet With AccountNumber Exists"));
            }
           
            var walletCount = await _walletRepository.GetUserWalletCount(request.Owner);
            if (walletCount >= 5)
            {
                return await Task.FromResult(Result.Fail("User Cannot Have More Than 5 Wallets").WithError("User Cannot Have More Than 5 Wallets"));
            }
            else
            {
                
                var storedAccountNumber =  request.Type.ToLower() == "momo" ? accountNumber : accountNumber.Substring(0,6);
                var hashedAccountNumber = DataHash.HashValue(accountNumber);
                await _walletRepository.AddWallet(new Domain.Model.Wallet()
                {
                    AccountNumber = storedAccountNumber,
                    AccountScheme = request.AccountScheme.Trim(),
                    Owner = request.Owner.Trim(),
                    Name = request.Name.Trim(),
                    CreatedAt = DateTimeOffset.UtcNow,
                    Type = request.Type.Trim(),
                    HashedAccountNumber = hashedAccountNumber
                });
               
            }
            return await Task.FromResult(Result.Ok().WithSuccess("Wallet Added Successfully"));
        }
           
    }
}
