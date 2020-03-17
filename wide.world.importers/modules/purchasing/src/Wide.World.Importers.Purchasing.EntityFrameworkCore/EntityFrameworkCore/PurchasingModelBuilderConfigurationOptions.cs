using JetBrains.Annotations;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Wide.World.Importers.Purchasing.EntityFrameworkCore
{
    public class PurchasingModelBuilderConfigurationOptions : AbpModelBuilderConfigurationOptions
    {
        public PurchasingModelBuilderConfigurationOptions(
            [NotNull] string tablePrefix = "",
            [CanBeNull] string schema = null)
            : base(
                tablePrefix,
                schema)
        {

        }
    }
}