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
    public class RemoveWalletCommandHandler : IRequestHandler<RemoveWalletCommand>
    {
        private readonly IWalletRepository _walletRepository;
        private readonly ILogger<RemoveWalletCommandHandler> _logger;
        public RemoveWalletCommandHandler(IWalletRepository walletRepository, ILogger<RemoveWalletCommandHandler> logger)
        {
            _walletRepository = walletRepository;
            _logger = logger;
        }
        public async Task Handle(RemoveWalletCommand request, CancellationToken cancellationToken)
        {
            var wallet = await _walletRepository.GetWalletByWalletId(request.walletId);
            if(wallet == null)
            {
                _logger.LogError($"Failed To Find Wallet [{request.walletId}]");
                throw new CustomHttpException("Wallet Not Found", 404);
            }
            await _walletRepository.RemoveWallet(request.walletId);
        }
    }
}
