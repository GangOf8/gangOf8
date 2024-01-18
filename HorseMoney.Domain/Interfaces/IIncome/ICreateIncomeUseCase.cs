using HorseMoney.Domain.Common;
using HorseMoney.Domain.Dto.IncomeDto;
using HorseMoney.Domain.UseCase;

namespace HorseMoney.Domain.Interfaces.IIncome
{
    public interface ICreateIncomeUseCase : IUseCaseBase<IncomeCreateDto, BasicResult>
    {
    }
}