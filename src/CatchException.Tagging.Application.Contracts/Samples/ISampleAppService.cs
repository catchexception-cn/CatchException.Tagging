using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace CatchException.Tagging.Samples;

public interface ISampleAppService : IApplicationService
{
    Task<SampleDto> GetAsync();

    Task<SampleDto> GetAuthorizedAsync();
}
