using Goblin.Api_Base.Contract.Repository.Models;
using Microsoft.EntityFrameworkCore;

namespace Goblin.Api_Base.Repository
{
    public sealed partial class GoblinDbContext
    {
        public DbSet<SampleEntity> Samples { get; set; }
    }
}