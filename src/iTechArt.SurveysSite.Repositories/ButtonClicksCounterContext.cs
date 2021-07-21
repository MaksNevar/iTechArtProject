using iTechArt.SurveysSite.DomainModel;
using Microsoft.EntityFrameworkCore;

namespace iTechArt.SurveysSite.Repositories
{
    public sealed class ButtonClicksCounterContext : DbContext
    {
        public DbSet<ButtonClicksCounter> ButtonClicks { get; set; }

        public ButtonClicksCounterContext(DbContextOptions<ButtonClicksCounterContext> options)
            : base(options)
        {

        }
    }
}