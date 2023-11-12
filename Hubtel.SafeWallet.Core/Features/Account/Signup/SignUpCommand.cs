using FluentResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hubtel.SafeWallet.Core.Features.Account.Signup
{
    public class SignUpCommand : IRequest<Result>
    {
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public SignUpCommand(string email, string phoneNumber, string password)
        {
            Email = email;
            PhoneNumber = phoneNumber;
            Password = password;
        }
    }
}
