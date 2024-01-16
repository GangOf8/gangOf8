using HorseMoney.Domain.Common;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace HorseMoney.Presentation.Abstractions
{
    [ApiController]
    public abstract class BaseController : Controller
    {
        protected ActionResult ResponseBase(
            HttpStatusCode statusCode,
            BasicResult basicResult,
            string responseMessage,
            HttpStatusCode statusCodeError = HttpStatusCode.NotFound)
        {
            if(basicResult.IsFailure)
            {
                basicResult.Error.StatusCode = (int)statusCodeError;
                return StatusCode(basicResult.Error.StatusCode, basicResult.Error);
            }

            return StatusCode((int)statusCode, responseMessage);
        }

        protected ActionResult ResponseBase<T>(
            HttpStatusCode statusCode,
            BasicResult<T> basicResult,
            HttpStatusCode statusCodeError = HttpStatusCode.NotFound)
        {
            if (basicResult.IsFailure)
            {
                basicResult.Error.StatusCode = (int)statusCodeError;
                return StatusCode(basicResult.Error.StatusCode, basicResult.Error);
            }

            return StatusCode((int)statusCode, basicResult.Value);
        }

    }
}
