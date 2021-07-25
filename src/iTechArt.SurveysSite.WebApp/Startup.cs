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
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
                
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.AddDbContext<UserDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddSingleton<ILog, Logger>();

            services.AddSingleton(Log.Logger);

            services.AddScoped<IUserUnitOfWork, UserUnitOfWork>();

            services.AddScoped<IUserService, UserService>();
        }

        public void Configure(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices
                .GetRequiredService<IServiceScopeFactory>()
                .CreateScope())
            {
                using var context = serviceScope.ServiceProvider.GetService<UserDbContext>();
                context.Database.Migrate();
            }

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