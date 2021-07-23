using Alorotbe.Persistence.Planning.Views;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Alorotbe.Persistence.Planning
{
    class StudentScoreDailyConfiguration : IEntityTypeConfiguration<StudentScoreDaily>
    {
        public void Configure(EntityTypeBuilder<StudentScoreDaily> builder)
        {
            builder.HasNoKey().ToView(nameof(StudentScoreDaily), "apialoro");
        }
    }
}
