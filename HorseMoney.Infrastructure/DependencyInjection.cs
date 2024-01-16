
using HorseMoney.Domain.Interfaces;
using HorseMoney.Infrastructure.Data;
using HorseMoney.Infrastructure.Identity;
using HorseMoney.Infrastructure.Repository.WalletRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection.Email;

namespace Microsoft.Extensions.DependencyInjection;
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        services.AddDbContext<ApplicationDbContext>((sp, options) =>
        {
            options.AddInterceptors(sp.GetServices<ISaveChangesInterceptor>());

            options.UseNpgsql(connectionString);

        });
        
        services.AddHttpContextAccessor();
        
        services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = IdentityConstants.BearerScheme;
                options.DefaultChallengeScheme = IdentityConstants.BearerScheme;
            })
            .AddBearerToken(IdentityConstants.BearerScheme, options =>
            {
               
            });

        services.AddAuthorizationBuilder();
        services.AddIdentity<ApplicationUser, IdentityRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders().AddApiEndpoints();;
        
        services.AddScoped<SignInManager<ApplicationUser>>();
        services.AddTransient<IEmailSender, EmailSender>();
        services.AddCascadingAuthenticationState();

        services.AddScoped<IWalletRepository, WalletRepository>();

        return services;
    }

}