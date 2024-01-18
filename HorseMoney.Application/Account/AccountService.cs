using CleanArchitecture.Infrastructure.Identity;
using HorseMoney.Application.Models;
using HorseMoney.Domain.Common;
using HorseMoney.Domain.Interfaces;
using HorseMoney.Infrastructure.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace HorseMoney.Application.Account;

public class AccountService : IAccountService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly IConfiguration _configuration;
    private readonly IEmailSender _emailSender;

    public AccountService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager,
        IConfiguration configuration, IEmailSender emailSender)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _configuration = configuration;
        _emailSender = emailSender;
    }

    public async Task<(Result Result, string UserId)> RegisterAsync(IRegisterModel model)
    {
        var user = new ApplicationUser
        {
            UserName = model.Email,
            Email = model.Email,
        };

        var result = await _userManager.CreateAsync(user, model.Password);


        // if (result.Succeeded)
        // {
        //     var emailConfirmationToken = await _userManager.GenerateEmailConfirmationTokenAsync(user);
        //     
        //     var baseUrl = _configuration["BaseUrl"]; 
        //     var confirmationLink = $"{baseUrl}/api/account/confirmEmail?userId={user.Id}&token={emailConfirmationToken}";
        //     
        //     await _emailSender.SendEmailAsync(user.Email, "Confirme seu e-mail", $"Por favor, confirme seu e-mail clicando neste link: {confirmationLink}");
        // }

        return (result.ToApplicationResult(), user.Id);
    }
}