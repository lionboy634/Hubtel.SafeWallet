using Hubtel.SafeWallet.Core.Domain.Model;
using Hubtel.SafeWallet.Core.Features.Wallet.AddWallet;
using Hubtel.SafeWallet.Core.Features.Wallet.GetWallet;
using Hubtel.SafeWallet.Core.Features.Wallet.ListWallet;
using Hubtel.SafeWallet.Core.Features.Wallet.RemoveWallet;
using Hubtel.SafeWallet.Core.Services;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Hubtel.SafeWallet.Api.Controllers
{
    [ApiController]
    [Authorize(Roles ="Member")]
    [Route("api/v1/wallet")]
    public class WalletController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IIdentityService _identityService;
        public WalletController(IMediator mediator, IIdentityService identityService)
        {
            _mediator = mediator;
            _identityService = identityService;
        }
        [HttpGet]
        public async Task<IActionResult> ListWallet(int limit)
        {
            var command = new ListWalletQuery(limit);
            var result = await _mediator.Send(command);
            return Ok(result.Value);
        }

        [HttpGet("{walletId}")]
        public async Task<IActionResult> GetWallet([FromRoute] int walletId)
        {
            var command = new GetWalletQuery() { walletId = walletId };
            var result = await _mediator.Send(command);
            return result.IsSuccess ? Ok(result.Value) : NotFound(result.Errors[0]);
        }

        [HttpPost]
        public async Task<IActionResult> AddWallet([FromForm] string accountNumber, [FromForm] string accountScheme, [FromForm] string type)
        {
            var user = await _identityService.GetUserByEmail(User.FindFirst(ClaimTypes.Name)?.Value);
            var command = new AddWalletCommand(user.UserName, accountScheme, accountNumber, type, user.PhoneNumber);
            var result = await _mediator.Send(command);
            return result.IsSuccess ? Ok() : BadRequest(result.Errors[0]);
        }

        [HttpDelete("{walletId}")]
        public async Task<IActionResult> RemoveWallet([FromRoute] int walletId)
        {
            var command = new RemoveWalletCommand() { walletId = walletId};
            var result = await _mediator.Send(command);
            return result.IsSuccess ? NoContent() : BadRequest(result.Errors[0]);
        }
    }
}
