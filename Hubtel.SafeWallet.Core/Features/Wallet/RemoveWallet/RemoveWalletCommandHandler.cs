using FluentResults;
using Hubtel.SafeWallet.Core.Domain.Model;
using Hubtel.SafeWallet.Core.Domain.Repository;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hubtel.SafeWallet.Core.Features.Wallet.RemoveWallet
{
    public class RemoveWalletCommandHandler : IRequestHandler<RemoveWalletCommand, Result>
    {
        private readonly IWalletRepository _walletRepository;
        private readonly ILogger<RemoveWalletCommandHandler> _logger;
        public RemoveWalletCommandHandler(IWalletRepository walletRepository, ILogger<RemoveWalletCommandHandler> logger)
        {
            _walletRepository = walletRepository;
            _logger = logger;
        }
        public async Task<Result> Handle(RemoveWalletCommand request, CancellationToken cancellationToken)
        {
            var wallet = await _walletRepository.GetWalletByWalletId(request.walletId);
            if(wallet == null)
            {
                string message = $"Failed To Find Wallet [{request.walletId}]";
                _logger.LogError(message);
                return Result.Fail(message).WithError(new Error(message));
            }
            await _walletRepository.RemoveWallet(request.walletId);

            return Result.Ok().WithSuccess("Wallet Removed Successfully");
        }
    }
}
