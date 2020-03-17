using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Wide.World.Importers.Purchasing.Samples
{
    public interface ISampleAppService : IApplicationService
    {
        Task<SampleDto> GetAsync();

        Task<SampleDto> GetAuthorizedAsync();
    }
}
