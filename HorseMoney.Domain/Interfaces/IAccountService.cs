using HorseMoney.Domain.Common;

namespace HorseMoney.Domain.Interfaces;

public interface IAccountService
{
    Task<(Result Result, string UserId)> RegisterAsync(IRegisterModel model);
}