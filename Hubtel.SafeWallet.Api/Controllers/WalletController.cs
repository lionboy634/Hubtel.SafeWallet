using Hubtel.SafeWallet.Core.Domain.Model;
using Hubtel.SafeWallet.Core.Features.Wallet.AddWallet;
using Hubtel.SafeWallet.Core.Features.Wallet.GetWallet;
using Hubtel.SafeWallet.Core.Features.Wallet.ListWallet;
using Hubtel.SafeWallet.Core.Features.Wallet.RemoveWallet;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hubtel.SafeWallet.Api.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/v1/wallet")]
    public class WalletController : ControllerBase
    {
        private readonly IMediator _mediator;
        public WalletController(IMediator mediator)
        {
            _mediator = mediator;
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
        public async Task<IActionResult> AddWallet([FromBody] Wallet wallet )
        {
            var command = new AddWalletCommand() { AccountName = wallet.AccountScheme, AccountNumber = wallet.AccountNumber };
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
