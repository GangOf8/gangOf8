using HorseMoney.Domain.Entities;
using HorseMoney.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace HorseMoney.Infrastructure.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {

        private readonly ApplicationDbContext _dbContext;

        public BaseRepository(ApplicationDbContext dbContext) {
            _dbContext = dbContext;
        }

        public async Task Add(T entity)
        {
             _dbContext
                .Set<T>()
                .Add(entity);

            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteById(Guid id)
        {
            var entity = await _dbContext
                .Set<T>()
                .FindAsync(id);

            if (entity == null) return;

            entity.IsDeleted = true;

            await _dbContext.SaveChangesAsync();
        }

        public async Task<T?> GetById(Guid id)
        {
            return await _dbContext
                .Set<T>()
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<T> Update(T entity)
        {
             _dbContext
                .Set<T>()
                .Update(entity);

            await _dbContext.SaveChangesAsync();
            return entity;
        }
    }
}
