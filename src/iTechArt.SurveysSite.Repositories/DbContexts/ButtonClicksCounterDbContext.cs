using iTechArt.SurveysSite.DomainModel;
using Microsoft.EntityFrameworkCore;

namespace iTechArt.SurveysSite.Repositories.DbContexts
{
    public sealed class ButtonClicksCounterDbContext : DbContext
    {
        public ButtonClicksCounterDbContext(DbContextOptions<ButtonClicksCounterDbContext> options)
            : base(options)
        {

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ButtonClicksCounter>()
                .HasData(new ButtonClicksCounter
                {
                    Id = 1,
                    Clicks = 0
                });
        }
    }
}