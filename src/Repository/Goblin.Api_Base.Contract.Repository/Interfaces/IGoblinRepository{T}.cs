using Goblin.Api_Base.Contract.Repository.Models;

namespace Goblin.Api_Base.Contract.Repository.Interfaces
{
    public interface IGoblinRepository<T> : Elect.Data.EF.Interfaces.Repository.IBaseEntityRepository<T> where T : GoblinEntity, new()
    {
    }
}