using HorseMoney.Application.Dto.WalletDto;
using HorseMoney.Application.UseCase.WalletCase;
using HorseMoney.Domain.Common;
using HorseMoney.Domain.Interfaces.Wallet;
using HorseMoney.Presentation.Abstractions;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace HorseMoney.Presentation.Controllers
{
    [Route("api/v1/[controller]")]
    public class WalletController : BaseController
    {
        private readonly ICreateWalletUseCase _createWallet;
        private readonly IGetByIdWalletUseCase _getByIdWallet;

        public WalletController(
            ICreateWalletUseCase createWalletUseCase,
            IGetByIdWalletUseCase getByIdWalletUseCase)
        {
            _createWallet = createWalletUseCase;
            _getByIdWallet = getByIdWalletUseCase;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(Error))]
        public async Task<ActionResult<BasicResult>> Create([FromBody] WalletDto walletCreateDto)
        {
            var result = await _createWallet.Execute(walletCreateDto);
            return ResponseBase(HttpStatusCode.Created, result, "Success");
        }

        [HttpGet, Route("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(WalletDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(Error))]
        public async Task<ActionResult<WalletDto>> Get([FromRoute] Guid id)
        {
            var result = await _getByIdWallet.Execute(id);
            return ResponseBase(HttpStatusCode.OK, result);
        }
    }
}
