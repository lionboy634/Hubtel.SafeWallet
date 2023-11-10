using Hubtel.SafeWallet.Core.Domain.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hubtel.SafeWallet.Core.Features.Wallet.GetWallet
{
    public class GetWalletQuery : IRequest<Domain.Model.Wallet>
    {
        public int walletId { get; set; }
    }
}
