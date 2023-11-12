using FluentValidation;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hubtel.SafeWallet.Core.Features.Wallet.AddWallet
{
    public class AddWalletValidator : AbstractValidator<AddWalletCommand>
    {
        public AddWalletValidator()
        {
            RuleFor(command => command.AccountName).NotEmpty();
            RuleFor(command => command.AccountNumber).NotEmpty();
            RuleFor(command => command.Owner).NotEmpty();
            RuleFor(command => command.Type)
            .Must(type => type != null && type?.ToLower() == "momo" || type?.ToLower() == "card")
            .WithMessage("Type Should Contain Momo Or Card");
            RuleFor(request => request.Owner)
            .NotEmpty().WithMessage("Phone number is required.")
            .Matches(@"^(0|\+233)[2-5]\d{8}$").WithMessage("Invalid phone number format."); 
        }
    }
        
}

