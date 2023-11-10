using Hubtel.SafeWallet.Core.Domain.Model;
using Hubtel.SafeWallet.Core.Domain.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hubtel.SafeWallet.Core.Features.Wallet.GetWallet
{
    internal class GetWalletQueryHandler : IRequestHandler<GetWalletQuery, Domain.Model.Wallet>
    {
        private readonly IWalletRepository _walletRepository;
        public GetWalletQueryHandler(IWalletRepository walletRepository)
        {
            _walletRepository = walletRepository;
        }
        public async  Task<Domain.Model.Wallet> Handle(GetWalletQuery request, CancellationToken cancellationToken)
        {
            var wallet = await _walletRepository.GetWalletByWalletId(request.walletId);
            if(wallet == null)
            {
                throw new CustomHttpException("Wallet Not Found", 404, "Wallet Not Found");
            }
            return wallet;
        }
    }
}
