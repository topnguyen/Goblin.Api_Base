using Goblin.Microservice_Base.Contract.Repository.Models;

namespace Goblin.Microservice_Base.Contract.Repository.Interfaces
{
    public interface IUnitOfWork : Elect.Data.EF.Interfaces.UnitOfWork.IUnitOfWork
    {
        IRepository<T> GetRepository<T>() where T : GoblinEntity, new();
    }
}