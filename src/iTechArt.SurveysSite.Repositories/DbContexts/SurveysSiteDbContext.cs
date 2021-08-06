using iTechArt.SurveysSite.DomainModel;
using Microsoft.EntityFrameworkCore;

namespace iTechArt.SurveysSite.Repositories.DbContexts
{
    public class SurveysSiteDbContext : DbContext
    {
        public SurveysSiteDbContext(DbContextOptions<SurveysSiteDbContext> options)
            : base(options)
        {

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<User>()
                .Property(user => user.UserName)
                .IsRequired();

            modelBuilder.Entity<User>()
                .ToTable("User");

            modelBuilder.Entity<User>()
                .Property(user => user.PasswordHash)
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(user => user.NormalizedUserName)
                .IsRequired();
        }
    }
}