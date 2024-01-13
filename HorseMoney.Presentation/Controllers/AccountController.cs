using HorseMoney.Application.Models;
using HorseMoney.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HorseMoney.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    { 
       
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var (result, userId) = await _accountService.RegisterAsync(model);

            if (result.Succeeded)
            {
                return Ok(new { UserId = userId });
            }

            return BadRequest(result.Errors);
        }
        
        [HttpPost("login")]
        public async Task<IActionResult> Login()
        {
            return Ok();
        }
        
        [HttpPost("forgotpassword")]
        public async Task<IActionResult> ForgotPassword()
        {
           
            return Ok();
        }
        
        [HttpPost("resetpassword")]
        public async Task<IActionResult> ResetPassword()
        {
          
            return Ok();
        }
        
        
    }
}
