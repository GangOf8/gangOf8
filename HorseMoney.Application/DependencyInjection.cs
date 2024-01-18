using System.Reflection;
using HorseMoney.Application.Account;
using HorseMoney.Application.UseCase.WalletCase;
using HorseMoney.Domain.Interfaces;
using HorseMoney.Domain.Interfaces.Wallet;
using HorseMoney.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection.Email;
using IEmailSender = Microsoft.AspNetCore.Identity.UI.Services.IEmailSender;


namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {


        services.AddScoped<ICreateWalletUseCase, CreateWalletUseCase>();

        return services;

    }
}