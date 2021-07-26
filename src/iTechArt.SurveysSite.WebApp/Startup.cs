using Microsoft.AspNetCore.Builder;
using iTechArt.Common;
using iTechArt.SurveysSite.Foundation;
using iTechArt.SurveysSite.Repositories.DbContexts;
using iTechArt.SurveysSite.Repositories.UnitOfWorks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace iTechArt.SurveysSite.WebApp
{
    public class Startup
    {
        public IConfiguration Configuration { get; }


        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.AddDbContext<ButtonClicksCounterDbContext>(optionsAction
                => optionsAction.UseInMemoryDatabase("TestDb"));

            services.AddSingleton<ILog, Logger>();

            services.AddSingleton(Log.Logger);

            services.AddScoped<IButtonClickUnitOfWork, ButtonClickUnitOfWork>();

            services.AddScoped<IButtonClicksService, ButtonClicksService>();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}