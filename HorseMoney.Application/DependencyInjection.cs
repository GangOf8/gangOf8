using HorseMoney.Application.UseCase.WalletCase;
using HorseMoney.Domain.Interfaces.Wallet;
using HorseMoney.Domain.Interfaces.WalletInterfaces;


namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<ICreateWalletUseCase, CreateWalletUseCase>();
        services.AddScoped<IDeleteWalletUseCase, DeleteWalletUseCase>();
        services.AddScoped<IGetByIdWalletUseCase, GetByIdWalletUseCase>();
        services.AddScoped<IUpdateWalletUseCase, UpdateWalletUseCase>();

        return services;
    }
}