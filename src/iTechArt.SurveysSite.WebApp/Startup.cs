using iTechArt.SurveysSite.Repositories;
using Microsoft.AspNetCore.Builder;
using iTechArt.Common;
using iTechArt.SurveysSite.Foundation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace iTechArt.SurveysSite.WebApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
                
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.AddDbContext<ButtonClicksCounterContext>(opt 
                => opt.UseInMemoryDatabase("TestDb"));

            services.AddSingleton<ILog, Logger>();

            services.AddSingleton(Log.Logger);

            services.AddScoped<IButtonClickRepository, ButtonClickRepository>();

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