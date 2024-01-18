using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HorseMoney.Domain.Common
{
    public class BasicResult
    {
        #region Properties

        public bool IsSuccess { get; }
        public bool IsFailure => !IsSuccess;
        public Error Error { get; }

        #endregion Properties

        #region Constructors 

        protected BasicResult(bool isSuccess, Error error)
        {
            IsSuccess = isSuccess;
            Error = error;
        }
        
        #endregion Constructors

        public static BasicResult Success() => new(true, Error.None);

        public static BasicResult<TValue> Success<TValue>(TValue value) => new(value, true, Error.None);

        public static BasicResult Failure(Error error) => new(false, error);

        public static BasicResult<TValue> Failure<TValue>(Error error) => new(default, false, error);

        protected static BasicResult<TValue> Create<TValue>(TValue? value) =>
            value is not null ? Success(value) : Failure<TValue>(Error.None);

    }
}
