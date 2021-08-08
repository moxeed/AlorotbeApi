using Alorotbe.Core.BasicInfo;
using Alorotbe.Persistence.Planning.Views;
using Core.BasicInfo;
using Core.Identity;
using Core.Planing;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Linq;
using System.Reflection;

namespace Alorotbe.Persistence
{
    public class ApplicationDbContext : IdentityDbContext<User, IdentityRole<int>, int>
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        #region BasicInfo
        public DbSet<Course> Courses { get; set; }
        public DbSet<Major> Majors { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<State> States { get; set; }

        #endregion

        #region Identity
        public DbSet<Student> Students { get; set; }
        public DbSet<Supporter> Supporters { get; set; }
        #endregion

        #region Planning
        public DbSet<DailyStudy> DailyStudies { get; set; }
        public DbSet<CourseStudy> CourseStudeies { get; set; }

        public DbSet<StudentScore> StudentScores { get; set;}
        #endregion

        protected override void OnModelCreating(ModelBuilder builder)
        {
            foreach (var entity in builder.Model.GetEntityTypes())
                builder.Entity(entity.ClrType).ToTable(entity.ClrType.Name);

            var fkeys = builder.Model
                .GetEntityTypes()
                .SelectMany(c => c.GetForeignKeys())
                .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);
            foreach (var fkey in fkeys) fkey.DeleteBehavior = DeleteBehavior.Restrict;

            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
