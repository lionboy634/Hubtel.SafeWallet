using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hubtel.SafeWallet.Core.Features.Wallet.ListWallet
{
    public class ListWalletQueryHandler : IRequestHandler<ListWalletQuery, IEnumerable<Domain.Model.Wallet>>
    {
        public ListWalletQueryHandler()
        {

        }
        public async Task<IEnumerable<Domain.Model.Wallet>> Handle(ListWalletQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
