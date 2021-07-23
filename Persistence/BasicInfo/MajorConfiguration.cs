using Alorotbe.Core.BasicInfo;
using Core.BasicInfo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.BasicInfo
{
    class GroupConfiguration : IEntityTypeConfiguration<Grade>
    {
        public void Configure(EntityTypeBuilder<Grade> builder)
        {
            builder.Property(c => c.GradeName).HasMaxLength(100);
        }
    }
}
