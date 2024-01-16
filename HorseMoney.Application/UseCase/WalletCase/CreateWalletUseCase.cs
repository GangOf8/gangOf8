using HorseMoney.Application.Dto.WalletDto;
using HorseMoney.Domain.Common;
using HorseMoney.Domain.Entities;
using HorseMoney.Infrastructure.Repository.WalletRepository;
using Mapster;

namespace HorseMoney.Application.UseCase.WalletCase
{
    public class CreateWalletUseCase : ICreateWalletUseCase
    {
        private readonly IWalletRepository _walletRepository;

        public CreateWalletUseCase(IWalletRepository walletRepository)
        {
            _walletRepository = walletRepository;
        }

        public async Task<BasicResult> Execute(WalletCreateDto input)
        {
            Wallet walletMapped = input.Adapt<Wallet>();
            await _walletRepository.Add(walletMapped);
            return BasicResult.Success();
        }
    }
}
