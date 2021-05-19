using AwesomeApp.Core.ProjectAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AwesomeApp.Infrastructure.Data.Config
{
    public class AuditConfiguration : IEntityTypeConfiguration<AuditEntry>
    {
        public void Configure(EntityTypeBuilder<AuditEntry> builder)
        {
            builder.Property(t => t.DateTime)
                .IsRequired();
        }
    }
}
