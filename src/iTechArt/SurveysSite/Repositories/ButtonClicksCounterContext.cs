using Microsoft.EntityFrameworkCore;

namespace iTechArt.SurveysSite.Repositories
{
    public class ButtonClicksCounterContext : DbContext
    {
        public ButtonClicksCounterContext(DbContextOptions<ButtonClicksCounterContext> options)
            : base(options)
        {

        }

        public DbSet<DomainModel.ButtonClicksCounter> ButtonClicks { get; set; }
    }
}
