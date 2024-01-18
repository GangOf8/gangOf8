using HorseMoney.Domain.Common;
using HorseMoney.Presentation.Abstractions;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using HorseMoney.Domain.Dto.WalletDto;
using HorseMoney.Domain.Interfaces.Wallet;

namespace HorseMoney.Presentation.Controllers
{
    [Route("api/[controller]")]
    public class WalletController : BaseController
    {
        private readonly ICreateWalletUseCase _createWallet;

        public WalletController(ICreateWalletUseCase createWalletUseCase)
        {
            _createWallet = createWalletUseCase;
        }

        [HttpPost]
        public async Task<ActionResult<BasicResult>> Create([FromBody] WalletDto walletCreateDto)
        {
            var result = await _createWallet.Execute(walletCreateDto);
            return ResponseBase(HttpStatusCode.Created, result, "Success");
        }
    }
}
