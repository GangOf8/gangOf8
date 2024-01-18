using HorseMoney.Domain.Common;
using HorseMoney.Domain.Entities;
using HorseMoney.Domain.Interfaces.Wallet;
using HorseMoney.Infrastructure.Repository.WalletRepository;
using Mapster;
using System.Net;
using HorseMoney.Domain.Dto.WalletDto;
using HorseMoney.Domain.Interfaces.WalletInterfaces;

namespace HorseMoney.Application.UseCase.WalletCase
{
    public class GetByIdWalletUseCase : IGetByIdWalletUseCase
    {
        #region Properties   

        private readonly IWalletRepository _walletRepository;

        #endregion Properties

        #region Constructors   

        public GetByIdWalletUseCase(IWalletRepository walletRepository)
        {
            _walletRepository = walletRepository;
        } 

        #endregion Constructors

        public async Task<BasicResult<WalletDto>> Execute(Guid input)
        {
            Wallet? walletEntity = await _walletRepository.GetById(input);
            if(walletEntity is null)
            {
                return BasicResult.Failure<WalletDto>(new Error(HttpStatusCode.NotFound, "Id not found"));
            }

            return walletEntity.Adapt<WalletDto>();            
        }
    }
}
