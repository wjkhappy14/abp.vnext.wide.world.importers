using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Wide.World.Importers.Purchasing.EntityFrameworkCore
{
    [DependsOn(
        typeof(PurchasingDomainModule),
        typeof(AbpEntityFrameworkCoreModule)
    )]
    public class PurchasingEntityFrameworkCoreModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<PurchasingDbContext>(options =>
            {
                /* Add custom repositories here. Example:
                 * options.AddRepository<Question, EfCoreQuestionRepository>();
                 */
            });
        }
    }
}