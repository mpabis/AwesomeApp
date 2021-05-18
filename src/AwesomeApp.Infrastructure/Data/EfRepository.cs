using Ardalis.Specification.EntityFrameworkCore;
using AwesomeApp.SharedKernel.Interfaces;

namespace AwesomeApp.Infrastructure.Data
{
    public class EfRepository<T> : RepositoryBase<T>, IReadRepository<T>, IRepository<T> where T : class, IAggregateRoot
    {
        public EfRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
