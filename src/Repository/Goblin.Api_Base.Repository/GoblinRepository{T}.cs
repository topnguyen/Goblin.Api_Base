using Elect.DI.Attributes;
using Goblin.Api_Base.Contract.Repository.Interfaces;
using Goblin.Api_Base.Contract.Repository.Models;

namespace Goblin.Api_Base.Repository
{
    [ScopedDependency(ServiceType = typeof(IGoblinRepository<>))]
    public class GoblinRepository<T> : Elect.Data.EF.Services.Repository.BaseEntityRepository<T>, IGoblinRepository<T> where T : GoblinEntity, new()
    {
        public GoblinRepository(Elect.Data.EF.Interfaces.DbContext.IDbContext dbContext) : base(dbContext)
        {
        }
    }
}