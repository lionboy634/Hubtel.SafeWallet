using Hubtel.SafeWallet.Core.Domain.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hubtel.SafeWallet.Core.Features.Wallet.AddWallet
{
    public class AddWalletCommandHandler : IRequestHandler<AddWalletCommand>
    {
        private readonly IWalletRepository _walletRepository;
        public AddWalletCommandHandler(IWalletRepository walletRepository)
        {
            _walletRepository = walletRepository;
        }
        public async  Task Handle(AddWalletCommand request, CancellationToken cancellationToken)
        {
            var accountNumber = request.AccountNumber;




        }
    }
}
