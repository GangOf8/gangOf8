namespace HorseMoney.Domain.Interfaces
{
    /// <summary>
    /// Codigo gerado para ser implementado nas interfaces dos UseCase, sendo assim uma abstração geral do codigo 
    /// </summary>
    /// <typeparam name="TInput"></typeparam>
    /// <typeparam name="TOutput"></typeparam>
    public interface IUseCaseBase<TInput, TOutput>
    {
        /// <summary>
        /// Isso é o inicio de tudo
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<TOutput> Execute(TInput input);
    }
}
