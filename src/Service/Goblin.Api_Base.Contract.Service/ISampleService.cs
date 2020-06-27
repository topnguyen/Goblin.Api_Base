using System.Threading;
using System.Threading.Tasks;
using Goblin.Api_Base.Share.Models;

namespace Goblin.Api_Base.Contract.Service
{
    public interface ISampleService
    {
        Task<GoblinApi_BaseSampleModel> CreateAsync(GoblinApi_BaseCreateSampleModel model, CancellationToken cancellationToken = default);
        
        Task<GoblinApi_BaseSampleModel> GetAsync(long id, CancellationToken cancellationToken = default);
        
        Task DeleteAsync(long id, CancellationToken cancellationToken = default);
    }
}