using HorseMoney.Application.Dto.WalletDto;
using HorseMoney.Application.UseCase.WalletCase;
using HorseMoney.Domain.Common;
using HorseMoney.Presentation.Abstractions;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace HorseMoney.Presentation.Controllers
{
    [Route("api/v1/[controller]")]
    public class WalletController : BaseController
    {
        private readonly ICreateWalletUseCase _createWallet;

        public WalletController(ICreateWalletUseCase createWalletUseCase)
        {
            _createWallet = createWalletUseCase;
        }

        [HttpPost]
        public async Task<ActionResult<BasicResult>> Create([FromBody] WalletCreateDto walletCreateDto)
        {
            var result = await _createWallet.Execute(walletCreateDto);
            return ResponseBase(HttpStatusCode.Created, result, "Success");
        }
    }
}
