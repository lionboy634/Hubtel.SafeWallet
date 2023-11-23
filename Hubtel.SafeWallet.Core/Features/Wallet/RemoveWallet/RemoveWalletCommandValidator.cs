using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hubtel.SafeWallet.Core.Features.Wallet.RemoveWallet
{
    public class RemoveWalletCommandValidator : AbstractValidator<RemoveWalletCommand>
    {
        public RemoveWalletCommandValidator()
        {
            RuleFor(command=> command.WalletId).NotEmpty();
            RuleFor(command=> command.Owner).NotEmpty();
        }
    }
}
