using Goblin.Microservice_Base.Contract.Repository.Models;

namespace Goblin.Microservice_Base.Contract.Repository.Interfaces
{
    public interface IRepository<T> : Elect.Data.EF.Interfaces.Repository.IRepository<T> where T : GoblinEntity, new()
    {
    }
}