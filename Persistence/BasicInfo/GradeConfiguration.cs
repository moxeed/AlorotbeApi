using Alorotbe.Core.BasicInfo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.BasicInfo
{
    class MajorConfiguration : IEntityTypeConfiguration<Major>
    {
        public void Configure(EntityTypeBuilder<Major> builder)
        {
            builder.Property(c => c.MajorName).HasMaxLength(100);
        }
    }
}
