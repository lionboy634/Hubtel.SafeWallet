using Hubtel.SafeWallet.Core.Domain.Model;
using Hubtel.SafeWallet.Core.Features.Account.Login;
using Hubtel.SafeWallet.Core.Features.Account.Signup;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Hubtel.SafeWallet.Api.Controllers
{
    [ApiController]
    [Route("api/v1/account")]
    public class AccountController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AccountController(IMediator mediator)
        {
            _mediator = mediator;
        }
       
        [HttpPost("signin")]
        public async Task<IActionResult> SignIn([FromForm]string email, [FromForm] string password)
        {
            var command = new LoginQuery(email, password);
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPost("signup")]
        public async Task<IActionResult> SignUp(string email, string phoneNumber, string password)
        {
            var command = new SignUpCommand(email, phoneNumber, password);
            await _mediator.Send(command);
            return Ok();
        }
    }
}
