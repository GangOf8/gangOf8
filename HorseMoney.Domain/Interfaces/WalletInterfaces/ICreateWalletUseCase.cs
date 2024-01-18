using HorseMoney.Domain.Common;
using HorseMoney.Domain.Dto.WalletDto;
using HorseMoney.Domain.UseCase;

namespace HorseMoney.Domain.Interfaces.Wallet
{
    public interface ICreateWalletUseCase : IUseCaseBase<WalletDto, BasicResult>
    {
    }
}
