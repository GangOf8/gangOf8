using Domain.UnitTests.IncomeTest.Common;
using HorseMoney.Application.UseCase.IncomeCase;
using HorseMoney.Domain.Entities;
using HorseMoney.Domain.Interfaces.IIncome;
using HorseMoney.Infrastructure.Repository.IncomeRepository;
using HorseMoney.Infrastructure.Repository.WalletRepository;
using Moq;

namespace Domain.UnitTests.IncomeTest.IcomeUseCaseTest;

public class CreateIncomeUseCaseTest
{
    [Test]

    public async Task Execute_ShouldCreateIncomeSuccessfully()
    {
        var incomeRepositoryMorck = new Mock<IIncomeRepository>();
        var createIncomeUseCase = new CreateIncomeUseCase(incomeRepositoryMorck.Object);

        var sut = await createIncomeUseCase.Execute(IncomeConstants.VALID_INCOME_CREATE_DTO);
        
        incomeRepositoryMorck.Verify(repo =>repo.Add(It.IsAny<Income>()), Times.Once);
        Assert.IsTrue(sut.IsSuccess);
    }


}