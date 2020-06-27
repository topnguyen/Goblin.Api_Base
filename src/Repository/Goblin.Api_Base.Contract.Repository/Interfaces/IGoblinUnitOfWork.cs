using Goblin.Api_Base.Contract.Repository.Models;

namespace Goblin.Api_Base.Contract.Repository.Interfaces
{
    public interface IGoblinUnitOfWork : Elect.Data.EF.Interfaces.UnitOfWork.IUnitOfWork
    {
        IGoblinRepository<T> GetRepository<T>() where T : GoblinEntity, new();
    }
}