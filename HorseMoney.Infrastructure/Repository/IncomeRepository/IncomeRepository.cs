using HorseMoney.Domain.Entities;
using HorseMoney.Domain.Interfaces.IIncome;
using HorseMoney.Infrastructure.Data;

namespace HorseMoney.Infrastructure.Repository.IncomeRepository
{
    
    public class IncomeRepository : BaseRepository<Income>, IIncomeRepository
    {
        public IncomeRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

    }
}