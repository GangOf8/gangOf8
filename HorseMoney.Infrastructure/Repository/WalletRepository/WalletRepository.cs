using HorseMoney.Domain.Entities;
using HorseMoney.Infrastructure.Data;

namespace HorseMoney.Infrastructure.Repository.WalletRepository
{
    public class WalletRepository : BaseRepository<Wallet>, IWalletRepository
    {
        public WalletRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
