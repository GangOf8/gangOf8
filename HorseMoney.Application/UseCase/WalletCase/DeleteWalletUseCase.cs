using HorseMoney.Domain.Common;
using HorseMoney.Domain.Dto.WalletDto;
using HorseMoney.Domain.Interfaces.Wallet;
using HorseMoney.Domain.Interfaces.WalletInterfaces;
using HorseMoney.Infrastructure.Repository.WalletRepository;

namespace HorseMoney.Application.UseCase.WalletCase
{
    public class DeleteWalletUseCase : IDeleteWalletUseCase
    {
        #region Properties 

        private readonly IWalletRepository _walletRepository;
        private readonly IGetByIdWalletUseCase _getByIdWalletUseCase;

        #endregion Properties

        #region Constructors  

        public DeleteWalletUseCase(IWalletRepository walletRepository, IGetByIdWalletUseCase getByIdWalletUseCase)
        {
            _walletRepository = walletRepository;
            _getByIdWalletUseCase = getByIdWalletUseCase;
        }

        #endregion Constructors

        public async Task<BasicResult> Execute(WalletIdDto input)
        {
            BasicResult<WalletDto> walletDto = await _getByIdWalletUseCase.Execute(input.Id);
            if (walletDto.IsFailure)
            {
                return walletDto;
            }

            await _walletRepository.DeleteById(input.Id);

            return BasicResult.Success();
        }
    }
}
