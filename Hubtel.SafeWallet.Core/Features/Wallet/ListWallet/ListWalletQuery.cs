using FluentResults;
using Hubtel.SafeWallet.Core.Domain.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hubtel.SafeWallet.Core.Features.Wallet.ListWallet
{
    public class ListWalletQuery : IRequest<Result<IEnumerable<Domain.Model.Wallet>>>
    {
        public int Limit { get; set; }

        public ListWalletQuery(int limit)
        {
            Limit = limit;
        }

    }
}
