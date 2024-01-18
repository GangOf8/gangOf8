using HorseMoney.Application.Dto.WalletDto;
using HorseMoney.Domain.Common;

namespace HorseMoney.Domain.Interfaces.Wallet
{
    public interface ICreateWalletUseCase : IUseCaseBase<WalletCreateDto, BasicResult>
    {
    }
}
