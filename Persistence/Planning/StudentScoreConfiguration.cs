using Alorotbe.Persistence.Planning.Views;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Alorotbe.Persistence.Planning
{
    class StudentScoreConfiguration : IEntityTypeConfiguration<StudentScore>
    {
        public void Configure(EntityTypeBuilder<StudentScore> builder)
        {
            builder.HasNoKey().ToView(nameof(StudentScore), "apialoro");
        }
    }
}
