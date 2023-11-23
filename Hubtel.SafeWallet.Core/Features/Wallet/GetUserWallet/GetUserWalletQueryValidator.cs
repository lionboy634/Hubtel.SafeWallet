using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hubtel.SafeWallet.Core.Features.Wallet.GetUserWallet
{
    public class GetUserWalletQueryValidator : AbstractValidator<GetUserWalletQuery>
    {
        public GetUserWalletQueryValidator()
        {
            RuleFor(c=> c.PhoneNumber)
                .NotEmpty().WithMessage("Phonenumber is required")
                .Matches(@"^(0|\+233)[2-5]\d{8}$").WithMessage("Invalid phone number format.");
        }
    }
}
