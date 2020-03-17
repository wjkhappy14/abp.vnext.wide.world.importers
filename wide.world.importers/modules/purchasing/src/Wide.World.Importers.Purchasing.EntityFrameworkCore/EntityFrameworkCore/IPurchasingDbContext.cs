using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Wide.World.Importers.Purchasing.EntityFrameworkCore
{
    [ConnectionStringName(PurchasingDbProperties.ConnectionStringName)]
    public interface IPurchasingDbContext : IEfCoreDbContext
    {
        /* Add DbSet for each Aggregate Root here. Example:
         * DbSet<Question> Questions { get; }
         */
    }
}