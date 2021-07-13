using Microsoft.EntityFrameworkCore;

namespace iTechArt.SurveysSite.Repositories
{
    public sealed class ButtonClicksCounterContext : DbContext
    {
        public DbSet<DomainModel.ButtonClicksCounter> ButtonClicks { get; set; }

        public ButtonClicksCounterContext(DbContextOptions<ButtonClicksCounterContext> options)
            : base(options)
        {

        }
    }
}