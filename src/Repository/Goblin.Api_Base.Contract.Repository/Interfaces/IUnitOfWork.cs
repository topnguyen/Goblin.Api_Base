using Goblin.Api_Base.Contract.Repository.Models;

namespace Goblin.Api_Base.Contract.Repository.Interfaces
{
    public interface IUnitOfWork : Elect.Data.EF.Interfaces.UnitOfWork.IUnitOfWork
    {
        IRepository<T> GetRepository<T>() where T : GoblinEntity, new();
    }
}