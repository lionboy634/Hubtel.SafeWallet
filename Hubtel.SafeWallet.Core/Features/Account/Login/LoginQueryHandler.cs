using Hubtel.SafeWallet.Core.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hubtel.SafeWallet.Core.Features.Account.Login
{
    public class LoginQueryHandler : IRequestHandler<LoginQuery, string>
    {
        private readonly IAuthenticator _authenticator;
        public LoginQueryHandler(IAuthenticator authenticator)
        {
            _authenticator = authenticator;
        }
        public async Task<string> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            
            var email = request.Email;
            var password = request.Password;
            var userAuthenticated = await _authenticator.ValidateUser(email, password);
            if (!userAuthenticated)
            {
                
            }
            string token = await _authenticator.GenerateToken();
            return token;
        }
    }
}
