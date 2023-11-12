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
            return result.IsSuccess ?  Ok(result.Value) : BadRequest(result.Errors[0]);
        }

        [HttpPost("signup")]
        public async Task<IActionResult> SignUp([FromForm]string email, [FromForm]string phoneNumber, [FromForm] string password)
        {
            var command = new SignUpCommand(email, phoneNumber, password);
            var result = await _mediator.Send(command);
            return result.IsSuccess ? Ok() : BadRequest(result.Errors[0]);
        }
    }
}
