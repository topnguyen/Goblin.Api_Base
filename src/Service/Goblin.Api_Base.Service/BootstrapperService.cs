﻿using Elect.DI.Attributes;
using Goblin.Api_Base.Contract.Repository.Interfaces;
using Goblin.Api_Base.Contract.Service;
using System.Threading;
using System.Threading.Tasks;

namespace Goblin.Api_Base.Service
{
    [ScopedDependency(ServiceType = typeof(IBootstrapperService))]
    public class BootstrapperService : Base.Service, IBootstrapperService
    {
        private readonly IBootstrapper _bootstrapper;

        public BootstrapperService(IGoblinUnitOfWork goblinUnitOfWork, IBootstrapper bootstrapper) : base(
            goblinUnitOfWork)
        {
            _bootstrapper = bootstrapper;
        }

        public async Task InitialAsync(CancellationToken cancellationToken = default)
        {
            await _bootstrapper.InitialAsync(cancellationToken).ConfigureAwait(true);
        }

        public async Task RebuildAsync(CancellationToken cancellationToken = default)
        {
            await _bootstrapper.RebuildAsync(cancellationToken).ConfigureAwait(true);
        }
    }
}