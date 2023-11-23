using FluentResults;
using Hubtel.SafeWallet.Core.Domain.Repository;
using Hubtel.SafeWallet.Core.Services;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hubtel.SafeWallet.Core.Features.Wallet.GetUserWallet
{
    public class GetUserWalletQueryHandler : IRequestHandler<GetUserWalletQuery, Result<IEnumerable<Domain.Model.Wallet>>>
    {
        private readonly IWalletRepository _walletRepository;
        private readonly IIdentityService _identityService;
        public GetUserWalletQueryHandler(
            IWalletRepository walletRepository, 
            IIdentityService identityService)
        {
            _walletRepository = walletRepository ?? throw new ArgumentNullException(nameof(walletRepository));
            _identityService  = identityService ?? throw new ArgumentNullException(nameof(identityService));
        }
        public async Task<Result<IEnumerable<Domain.Model.Wallet>>> Handle(GetUserWalletQuery request, CancellationToken cancellationToken)
        {

            var userWallets = await _walletRepository.GetUserWallets(request.PhoneNumber);
            return Result.Ok(userWallets);

        }
    }
}
