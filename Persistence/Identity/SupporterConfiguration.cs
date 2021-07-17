using Core.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Identity
{
    class SupporterConfiguration : IEntityTypeConfiguration<Supporter>
    {
        public void Configure(EntityTypeBuilder<Supporter> builder)
        {
            builder.Property(s => s.Name).HasMaxLength(50);
            builder.Property(s => s.LastName).HasMaxLength(50);
        }
    }
}
