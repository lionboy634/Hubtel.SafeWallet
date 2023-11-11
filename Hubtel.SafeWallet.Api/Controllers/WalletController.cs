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
    [Authorize]
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
        public async Task<IActionResult> ListWallet(int limit=0, int offset=0)
        {
            var command = new ListWalletQuery(limit);
            var result = _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("{walletId}")]
        public async Task<IActionResult> GetWallet([FromRoute] int walletId)
        {
            var command = new GetWalletQuery() { walletId = walletId };
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddWallet([FromForm] string accountNumber, [FromForm] string accountScheme, [FromForm] string type)
        {
            var user = await _identityService.GetUserByEmail(User.FindFirst(ClaimTypes.Name)?.Value);
            var command = new AddWalletCommand(user.UserName, accountNumber, accountScheme, type, user.PhoneNumber);
            await _mediator.Send(command);
            return Ok();
        }

        [HttpDelete("{walletId}")]
        public async Task<IActionResult> RemoveWallet([FromRoute] int walletId)
        {
            var command = new RemoveWalletCommand() { walletId = walletId};
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
