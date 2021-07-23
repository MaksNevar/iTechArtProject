using iTechArt.SurveysSite.DomainModel;
using Microsoft.EntityFrameworkCore;

namespace iTechArt.SurveysSite.Repositories.DbContexts
{
    public sealed class ButtonClicksCounterDbContext : DbContext
    {
        public DbSet<ButtonClicksCounter> ButtonClicks { get; set; }


        public ButtonClicksCounterDbContext(DbContextOptions<ButtonClicksCounterDbContext> options)
            : base(options)
        {

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ButtonClicksCounter>()
                .HasKey(buttonClicksCounter => buttonClicksCounter.Id);
        }
    }
}