namespace HorseMoney.Domain.Interfaces
{
    public interface IBaseRepository<T>
    {
        Task<T?> GetById(Guid id);
        Task DeleteById(Guid id);
        Task Add(T entity);
        Task<T> Update(T entity);
    }
}
