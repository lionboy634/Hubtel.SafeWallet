using FluentResults;
using Hubtel.SafeWallet.Core.Domain.Model;
using Hubtel.SafeWallet.Core.Domain.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hubtel.SafeWallet.Core.Features.Wallet.ListWallet
{
    public class ListWalletQueryHandler : IRequestHandler<ListWalletQuery, Result<IEnumerable<Domain.Model.Wallet>>>
    {
        private readonly IWalletRepository _walletRepository;
        public ListWalletQueryHandler(IWalletRepository walletRepository)
        {
            _walletRepository = walletRepository;
        }
        public async Task<Result<IEnumerable<Domain.Model.Wallet>>> Handle(ListWalletQuery request, CancellationToken cancellationToken)
        {
            var wallets = await _walletRepository.ListWallets();

            return Result.Ok<IEnumerable<Domain.Model.Wallet>>(wallets);
        }
    }
}
