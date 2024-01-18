using HorseMoney.Application.Dto.WalletDto;
using HorseMoney.Domain.Common;
using HorseMoney.Domain.Entities;
using HorseMoney.Infrastructure.Repository.WalletRepository;
using Mapster;

namespace HorseMoney.Application.UseCase.WalletCase
{
    public class CreateWalletUseCase : ICreateWalletUseCase
    {
        #region Properties

        private readonly IWalletRepository _walletRepository;

        #endregion Properties

        #region Constructors

        public CreateWalletUseCase(IWalletRepository walletRepository)
        {
            _walletRepository = walletRepository;
        }
        
        #endregion Constructors

        public async Task<BasicResult> Execute(WalletDto input)
        {
            Wallet walletMapped = input.Adapt<Wallet>();
            await _walletRepository.Add(walletMapped);

            return BasicResult.Success();
        }
    }
}
