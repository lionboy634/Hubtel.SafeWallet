using FluentValidation;
using Hubtel.SafeWallet.Core.Domain.Model;
using Hubtel.SafeWallet.Core.Domain.Repository;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hubtel.SafeWallet.Core.Features.Wallet.AddWallet
{
    public class AddWalletCommandHandler : IRequestHandler<AddWalletCommand, Unit>
    {
        private readonly IWalletRepository _walletRepository;
        private readonly ILogger<AddWalletCommandHandler> _logger;
        private readonly IValidator<AddWalletCommand> _validator;
        public AddWalletCommandHandler(
            IWalletRepository walletRepository,
            ILogger<AddWalletCommandHandler> logger,
            IValidator<AddWalletCommand> validator)
        {
            _walletRepository = walletRepository;
            _logger = logger;
            _validator = validator;
        }
        public async Task<Unit> Handle(AddWalletCommand request, CancellationToken cancellationToken)
        {
            var existingWallet = await _walletRepository.CheckExistingUserWallet(request.AccountNumber, request.Owner);
            if (existingWallet)
            {
                throw new CustomHttpException("Wallet Not Found", 404);
            }
            var walletCount = await _walletRepository.GetUserWalletCount(request.Owner);
            if (walletCount >= 0 && walletCount <= 5)
            {

                await _walletRepository.AddWallet(new Domain.Model.Wallet()
                {
                    AccountNumber = request.AccountNumber,
                    AccountScheme = request.AccountName,
                    Owner = request.Owner,
                    Name = request.Name,
                    CreatedAt = DateTimeOffset.UtcNow,
                    Type = request.Type,
                });
            }
            else
            {
                throw new CustomHttpException("User Cannot Have More Than 5 Wallets", 400);
            }

        return Unit.Value;

        }
           
    }
}
