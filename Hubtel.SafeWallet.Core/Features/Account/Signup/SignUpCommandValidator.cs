using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hubtel.SafeWallet.Core.Features.Account.Signup
{
    public class SignUpCommandValidator : AbstractValidator<SignUpCommand>
    {
        public SignUpCommandValidator()
        {
            RuleFor(c=> c.FirstName).NotEmpty();
            RuleFor(c=> c.LastName).NotEmpty();
            RuleFor(c=> c.Email).NotEmpty();
            RuleFor(c=> c.PhoneNumber).NotEmpty();
            RuleFor(c=> c.Password).NotEmpty();
        }
    }
}
