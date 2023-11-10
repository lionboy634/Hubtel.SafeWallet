using Hubtel.SafeWallet.Core.Domain.Repository;
using MediatR;
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
        public RemoveWalletCommandHandler(IWalletRepository walletRepository)
        {
            _walletRepository = walletRepository;
        }
        public async Task Handle(RemoveWalletCommand request, CancellationToken cancellationToken)
        {
            var wallet = await _walletRepository.GetWalletByWalletId(request.walletId);
            if(wallet == null)
            {
                throw new Exception("Wallet Not Found");
            }
            await _walletRepository.RemoveWallet(request.walletId);
        }
    }
}
