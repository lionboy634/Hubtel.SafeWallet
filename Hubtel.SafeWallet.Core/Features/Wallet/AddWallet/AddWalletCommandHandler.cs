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
        private readonly IValidator<AddWalletCommand> _validator;
        private IDataHasher _dataHasher;
        public AddWalletCommandHandler(
            IWalletRepository walletRepository,
            ILogger<AddWalletCommandHandler> logger,
            IValidator<AddWalletCommand> validator,
            IDataHasher dataHasher)
        {
            _walletRepository = walletRepository;
            _logger = logger;
            _validator = validator;
            _dataHasher = dataHasher;
        }
        public async Task<Result> Handle(AddWalletCommand request, CancellationToken cancellationToken)
        {
            var existingWallet = await _walletRepository.CheckExistingUserWallet(request.AccountNumber, request.Owner);
            if (existingWallet)
            {
                return await Task.FromResult(Result.Fail("Wallet With AccountNumber Exists"));
            }
            var walletCount = await _walletRepository.GetUserWalletCount(request.Owner);
            if (walletCount == 5)
            {
                return await Task.FromResult(Result.Fail("User Cannot Have More Than 5 Wallets").WithError("User Cannot Have More Than 5 Wallets"));
            }
            else
            {
                
                var accountNumber =  request.Type.ToLower() == "momo" ? request.AccountNumber.Trim() : request.AccountNumber.Trim().Substring(0,6);
                var hashedAccountNumber = request.Type.ToLower() == "momo" ? accountNumber : _dataHasher.HashAccountNumber(accountNumber);
                await _walletRepository.AddWallet(new Domain.Model.Wallet()
                {
                    AccountNumber = accountNumber,
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
