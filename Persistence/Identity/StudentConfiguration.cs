using Core.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Identity
{
    class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.Property(s => s.Name).HasMaxLength(50);
            builder.Property(s => s.LastName).HasMaxLength(50);
            builder.Property(s => s.GPA).HasColumnType("decimal(4, 2)");
        }
    }
}
