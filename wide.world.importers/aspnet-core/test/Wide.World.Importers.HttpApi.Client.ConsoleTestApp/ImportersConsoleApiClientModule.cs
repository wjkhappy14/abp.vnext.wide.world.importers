using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace Wide.World.Importers.HttpApi.Client.ConsoleTestApp
{
    [DependsOn(
        typeof(ImportersHttpApiClientModule),
        typeof(AbpHttpClientIdentityModelModule)
        )]
    public class ImportersConsoleApiClientModule : AbpModule
    {
        
    }
}
