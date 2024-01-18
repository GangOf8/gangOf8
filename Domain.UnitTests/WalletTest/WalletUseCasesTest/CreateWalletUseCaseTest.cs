using HorseMoney.Infrastructure.Repository.WalletRepository;
using Moq;
using HorseMoney.Domain.Entities;
using HorseMoney.Application.UseCase.WalletCase;
using Domain.UnitTests.WalletTest.Common;

namespace Domain.UnitTests.WalletTest.WalletUseCasesTest
{
    public class CreateWalletUseCaseTest
    {
        [Test]
        public async Task Execute_ShouldCreateWalletSuccessfully()
        {
            var walletRepositoryMock = new Mock<IWalletRepository>();
            var createWalletUseCase = new CreateWalletUseCase(walletRepositoryMock.Object);

            var sut = await createWalletUseCase.Execute(WalletConstants.VALID_WALLET_CREATE_DTO);

            walletRepositoryMock.Verify(repo => repo.Add(It.IsAny<Wallet>()), Times.Once);
            Assert.IsTrue(sut.IsSuccess);
        }
    }
}