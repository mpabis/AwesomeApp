using AwesomeApp.Core.ProjectAggregate;
using AwesomeApp.Infrastructure.Data.Config;
using Microsoft.EntityFrameworkCore;

namespace AwesomeApp.Infrastructure.Data
{
    public class AuditDbContext : DbContext
    {
        public AuditDbContext(DbContextOptions<AuditDbContext> options)
            : base(options)
        {
        }

        public DbSet<AuditEntry> AuditEntries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new AuditConfiguration());
        }
    }
}