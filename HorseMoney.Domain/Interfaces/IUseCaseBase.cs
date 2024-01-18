namespace HorseMoney.Domain.UseCase
{
    /// <summary>
    /// dddd
    /// </summary>
    /// <typeparam name="TInput"></typeparam>
    /// <typeparam name="TOutput"></typeparam>
    public interface IUseCaseBase<TInput, TOutput>
    {
        Task<TOutput> Execute(TInput input);
       
    }
}
