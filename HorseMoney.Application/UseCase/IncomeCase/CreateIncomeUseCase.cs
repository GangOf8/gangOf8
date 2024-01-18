using HorseMoney.Domain.Common;
using HorseMoney.Domain.Dto.IncomeDto;
using HorseMoney.Domain.Entities;
using HorseMoney.Domain.Interfaces.IIncome;
using Mapster;

namespace HorseMoney.Application.UseCase.IncomeCase
{
    public class CreateIncomeUseCase : ICreateIncomeUseCase
    {
        #region Properties

        private readonly IIncomeRepository _incomeRepository;

        #endregion Properties

        #region Constructors

        public CreateIncomeUseCase(IIncomeRepository incomeRepository)
        {
            _incomeRepository = incomeRepository;
        }

        #endregion Constructors
        
        public async Task<BasicResult> Execute(IncomeCreateDto input)
        {
            Income incomeMapped = input.Adapt<Income>();
            await _incomeRepository.Add(incomeMapped);
            
            
            return BasicResult.Success();
        }
    }
}