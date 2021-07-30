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
            builder.Property(s => s.PhoneNumber).HasMaxLength(11);
            builder.Property(s => s.NationalCode).HasMaxLength(10);
            builder.Property(s => s.CourseUniversity).HasMaxLength(255);
            builder.Property(s => s.Sheba).HasMaxLength(50);
            builder.Property(s => s.TelegramId).HasMaxLength(50);
            builder.Property(s => s.Experience).HasMaxLength(50);
            builder.Property(s => s.Experience).HasMaxLength(255);
            builder.Property(s => s.CardNumber).HasMaxLength(20);
        }
    }
}
