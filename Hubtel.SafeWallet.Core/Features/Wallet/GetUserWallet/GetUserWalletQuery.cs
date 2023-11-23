using FluentResults;
using Hubtel.SafeWallet.Core.Domain.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hubtel.SafeWallet.Core.Features.Wallet.GetUserWallet
{
    public class GetUserWalletQuery : IRequest<Result<IEnumerable<Domain.Model.Wallet>>>
    {
        public string? PhoneNumber { get; private set; }

        public GetUserWalletQuery(string? phoneNumber)
        {
            PhoneNumber = phoneNumber;
        }
    }
}
