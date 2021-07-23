using Alorotbe.Persistence.Planning.Views;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Alorotbe.Persistence.Planning
{
    class StudentScoreAllConfiguration : IEntityTypeConfiguration<StudentScoreAll>
    {
        public void Configure(EntityTypeBuilder<StudentScoreAll> builder)
        {
            builder.HasNoKey().ToView(nameof(StudentScoreAll), "apialoro");
        }
    }
}
