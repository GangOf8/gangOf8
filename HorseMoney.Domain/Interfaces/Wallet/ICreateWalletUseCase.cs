using HorseMoney.Application.Dto.WalletDto;
using HorseMoney.Domain.Common;
using HorseMoney.Domain.UseCase;

namespace HorseMoney.Application.UseCase.WalletCase
{
    public interface ICreateWalletUseCase : IUseCaseBase<WalletCreateDto, BasicResult>
    {
    }

}
