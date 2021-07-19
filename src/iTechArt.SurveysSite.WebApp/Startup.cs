using iTechArt.SurveysSite.Repositories;
using Microsoft.AspNetCore.Builder;
using iTechArt.Common;
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

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            services.AddScoped(typeof(IUnitOfWork<>), typeof(UnitOfWork<>));
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