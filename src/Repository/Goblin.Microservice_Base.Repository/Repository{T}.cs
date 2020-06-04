using Elect.DI.Attributes;
using Goblin.Microservice_Base.Contract.Repository.Interfaces;
using Goblin.Microservice_Base.Contract.Repository.Models;

namespace Goblin.Microservice_Base.Repository
{
    [ScopedDependency(ServiceType = typeof(IRepository<>))]
    public class Repository<T> : Elect.Data.EF.Services.Repository.Repository<T>, IRepository<T> where T : GoblinEntity, new()
    {
        public Repository(Elect.Data.EF.Interfaces.DbContext.IDbContext dbContext) : base(dbContext)
        {
        }
    }
}