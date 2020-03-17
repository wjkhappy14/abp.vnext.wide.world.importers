using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Wide.World.Importers.Purchasing.EntityFrameworkCore
{
    [ConnectionStringName(PurchasingDbProperties.ConnectionStringName)]
    public class PurchasingDbContext : AbpDbContext<PurchasingDbContext>, IPurchasingDbContext
    {
        /* Add DbSet for each Aggregate Root here. Example:
         * public DbSet<Question> Questions { get; set; }
         */

        public PurchasingDbContext(DbContextOptions<PurchasingDbContext> options) 
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ConfigurePurchasing();
        }
    }
}