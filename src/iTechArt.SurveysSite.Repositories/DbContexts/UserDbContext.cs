using iTechArt.SurveysSite.DomainModel;
using Microsoft.EntityFrameworkCore;

namespace iTechArt.SurveysSite.Repositories.DbContexts
{
    public class UserDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public UserDbContext(DbContextOptions<UserDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasKey(key => key.Id);
        }
    }
}