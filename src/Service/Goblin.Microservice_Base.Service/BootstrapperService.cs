using Elect.DI.Attributes;
using Goblin.Microservice_Base.Contract.Repository.Interfaces;
using Goblin.Microservice_Base.Contract.Service;
using System.Threading;
using System.Threading.Tasks;

namespace Goblin.Microservice_Base.Service
{
    [ScopedDependency(ServiceType = typeof(IBootstrapperService))]
    public class BootstrapperService : Base.Service, IBootstrapperService
    {
        private readonly IBootstrapper _bootstrapper;

        public BootstrapperService(IUnitOfWork unitOfWork, IBootstrapper bootstrapper) : base(unitOfWork)
        {
            _bootstrapper = bootstrapper;
        }

        public async Task InitialAsync(CancellationToken cancellationToken = default)
        {
            await _bootstrapper.InitialAsync(cancellationToken).ConfigureAwait(true);
        }

        public Task RebuildAsync(CancellationToken cancellationToken = default)
        {
            _bootstrapper.RebuildAsync(cancellationToken).Wait(cancellationToken);

            return Task.CompletedTask;
        }
    }
}