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
            RuleFor(command => command.AccountScheme).NotEmpty();

            RuleFor(command => command.AccountNumber).NotEmpty();

            //RuleFor(command => command.Owner).NotEmpty();

            RuleFor(command => command.Type)
            .Must(type => type != null && type?.ToLower() == "momo" || type?.ToLower() == "card")
            .WithMessage("Type Should Contain Momo Or Card");

            RuleFor(command => command.AccountScheme)
                .NotEmpty()
                .When(c => c.Type.ToLower() == "momo")
                .Must(BeValidMomoAccountScheme).WithMessage("Invalid Momo Scheme").
                Unless(c => c.Type.ToLower() != "momo");

            RuleFor(command => command.AccountScheme)
                .NotEmpty()
                .When(c => c.Type.ToLower() == "card")
                .Must(BeValidCardAccountScheme).WithMessage("Invalid Card Scheme")
                .Unless(c => c.Type.ToLower() != "card");

            RuleFor(request => request.Owner)
            .NotEmpty().WithMessage("Phone number is required.")
            .Matches(@"^(0|\+233)[2-5]\d{8}$").WithMessage("Invalid phone number format."); 
        }

        private bool BeValidCardType(string cardType)
        {
            var card = cardType.Trim().ToLower();
            return card == "card" || card == "momo";
        }

        private bool BeValidCardAccountScheme(string accountScheme)
        {
            var scheme = accountScheme.Trim().ToLower();
            return scheme == "mastercard" || scheme == "visa";
        }

        private bool BeValidMomoAccountScheme(string accountScheme)
        {
            var scheme = accountScheme.Trim().ToLower();
            return scheme == "mtn" || scheme == "tigo" || scheme == "vodafone";
        }
    }
        
}

