using FluentResults;
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
    internal class GetWalletQueryHandler : IRequestHandler<GetWalletQuery, Result<Domain.Model.Wallet>>
    {
        private readonly IWalletRepository _walletRepository;
        public GetWalletQueryHandler(IWalletRepository walletRepository)
        {
            _walletRepository = walletRepository;
        }
        public async  Task<Result<Domain.Model.Wallet>> Handle(GetWalletQuery request, CancellationToken cancellationToken)
        {
            var wallet = await _walletRepository.GetWalletByWalletId(request.walletId);
            if(wallet == null)
            {

                return Result.Fail<Domain.Model.Wallet>(new Error("Wallet Not Found"));
            }

            return wallet;
           
        }
    }
}
