using FluentResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hubtel.SafeWallet.Core.Features.Wallet.RemoveWallet
{
    public class RemoveWalletCommand : IRequest<Result>
    {
        public int WalletId { get; private set; }
        public string? Owner { get; private set; }

        public RemoveWalletCommand(int walletId, string? owner)
        {
            WalletId = walletId;
            Owner = owner;
        }

    }
}
