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
            var userBuilder = modelBuilder.Entity<User>();
            userBuilder.Property(user => user.UserName)
                .IsRequired();

            userBuilder.Property(user => user.PasswordHash)
                .IsRequired();

            userBuilder.Property(user => user.NormalizedUserName)
                .IsRequired();

            userBuilder.Property(user => user.Email)
                .IsRequired();

            userBuilder.HasOne(user => user.Role)
                .WithMany(role => role.Users)
                .IsRequired();

            var roleBuilder = modelBuilder.Entity<Role>();
            roleBuilder.ToTable("UserRole");

            roleBuilder.Property(role => role.Name)
                .IsRequired();

            roleBuilder.Property(role => role.NormalizedName)
                .IsRequired();

            roleBuilder.HasData(new Role
                {
                    Id = 1,
                    Name = RoleNames.AdminRole,
                    NormalizedName = RoleNames.AdminRole
                },
                new Role
                {
                    Id = 2,
                    Name = RoleNames.UserRole,
                    NormalizedName = RoleNames.UserRole
                });
        }
    }
}