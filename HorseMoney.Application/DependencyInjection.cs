using HorseMoney.Application.UseCase.WalletCase;
using HorseMoney.Domain.Interfaces.Wallet;

namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<ICreateWalletUseCase, CreateWalletUseCase>();

        return services;
    }
}