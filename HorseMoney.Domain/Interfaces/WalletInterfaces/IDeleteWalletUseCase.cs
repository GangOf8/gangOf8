using HorseMoney.Domain.Common;
using HorseMoney.Domain.Dto.WalletDto;
using HorseMoney.Domain.UseCase;

namespace HorseMoney.Domain.Interfaces.WalletInterfaces
{
    public interface IDeleteWalletUseCase : IUseCaseBase<WalletIdDto, BasicResult>
    {
    }
}
