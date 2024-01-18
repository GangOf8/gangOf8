using HorseMoney.Domain.Common;
using HorseMoney.Domain.Dto.WalletDto;
using HorseMoney.Domain.Entities;
using HorseMoney.Domain.Interfaces.Wallet;
using HorseMoney.Domain.Interfaces.WalletInterfaces;
using HorseMoney.Domain;
using HorseMoney.Infrastructure.Repository.WalletRepository;
using Mapster;
using System.Net;

namespace HorseMoney.Application.UseCase.WalletCase
{
    public class UpdateWalletUseCase : IUpdateWalletUseCase
    {
        #region Properties

        private readonly IWalletRepository _walletRepository;
        private readonly IGetByIdWalletUseCase _getByIdWalletUseCase;

        #endregion Properties

        #region Constructor

        public UpdateWalletUseCase( IWalletRepository walletRepository,
                                    IGetByIdWalletUseCase getByIdWalletUseCase)
        {
            _walletRepository = walletRepository;
            _getByIdWalletUseCase = getByIdWalletUseCase;
        }
        
        #endregion Constructors

        public async Task<BasicResult<WalletDto>> Execute(WalletUpdateDto input)
        {
            BasicResult<WalletDto> walletDto = await _getByIdWalletUseCase.Execute(input.Id);
            if (walletDto.IsFailure)
            {
                return walletDto;
            }

            Wallet wallet = walletDto.Value.Adapt<Wallet>();
            Update(input, wallet);

            await _walletRepository.Update(wallet);

            return wallet.Adapt<WalletDto>();
        }

        private BasicResult Update(WalletUpdateDto walletDto, Wallet wallet)
        {
            if (string.IsNullOrWhiteSpace(walletDto.Name))
            {
                return BasicResult.Failure(new Error(HttpStatusCode.BadRequest, "Name is null or empty"));
            }

            wallet.Name = walletDto.Name;
            return BasicResult.Success();
        }
    }
}
