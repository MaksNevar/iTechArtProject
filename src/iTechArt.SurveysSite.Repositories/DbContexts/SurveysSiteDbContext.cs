using iTechArt.Common;
using iTechArt.SurveysSite.DomainModel;
using Microsoft.EntityFrameworkCore;

namespace iTechArt.SurveysSite.Repositories.DbContexts
{
    public class SurveysSiteDbContext : DbContext
    {
        [UsedImplicitly]
        public DbSet<User> User { get; set; }

        public SurveysSiteDbContext(DbContextOptions<SurveysSiteDbContext> options)
            : base(options)
        {

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .Property(user => user.FullName)
                .IsRequired();
        }
    }
}