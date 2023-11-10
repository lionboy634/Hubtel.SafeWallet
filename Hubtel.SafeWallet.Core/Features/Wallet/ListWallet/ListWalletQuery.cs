using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hubtel.SafeWallet.Core.Features.Wallet.ListWallet
{
    public class ListWalletQuery : IRequest<IEnumerable<Domain.Model.Wallet>>
    {
        public int Limit { get; set; }

        public ListWalletQuery(int limit)
        {
            Limit = limit;
        }

    }
}
