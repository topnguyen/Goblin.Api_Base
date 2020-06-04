using Goblin.Microservice_Base.Contract.Repository.Interfaces;

namespace Goblin.Microservice_Base.Service.Base
{
    public abstract class Service
    {
        protected readonly IUnitOfWork UnitOfWork;

        protected Service(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }
    }
}