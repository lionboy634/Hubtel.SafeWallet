﻿using FluentResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hubtel.SafeWallet.Core.Features.Account.Login
{
    public class LoginQuery : IRequest<Result<LoginResponse>>
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public LoginQuery(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }
}
