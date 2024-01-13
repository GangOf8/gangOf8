using System.Reflection;
using HorseMoney.Application.Account;
using HorseMoney.Domain.Interfaces;
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
 
       
     

        return services;
    }
}