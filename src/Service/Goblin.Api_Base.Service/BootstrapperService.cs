using Elect.DI.Attributes;
using Goblin.Api_Base.Contract.Repository.Interfaces;
using Goblin.Api_Base.Contract.Service;
using System.Threading;
using System.Threading.Tasks;

namespace Goblin.Api_Base.Service
{
    [ScopedDependency(ServiceType = typeof(IBootstrapperService))]
    public class BootstrapperService : Base.Service, IBootstrapperService
    {
        public BootstrapperService(IGoblinUnitOfWork goblinUnitOfWork) : base(goblinUnitOfWork)
        {
        }

        public Task InitialAsync(CancellationToken cancellationToken = default)
        {
            return Task.CompletedTask;
        }

        public Task RebuildAsync(CancellationToken cancellationToken = default)
        {
            return Task.CompletedTask;
        }
    }
}