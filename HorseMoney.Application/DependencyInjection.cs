using HorseMoney.Application.UseCase.IncomeCase;
using HorseMoney.Application.UseCase.WalletCase;
using HorseMoney.Domain.Interfaces.IIncome;
using Microsoft.Extensions.DependencyInjection;

namespace HorseMoney.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<ICreateWalletUseCase, CreateWalletUseCase>();
        services.AddScoped<ICreateIncomeUseCase, CreateIncomeUseCase>();
        
        return services;

    }
}