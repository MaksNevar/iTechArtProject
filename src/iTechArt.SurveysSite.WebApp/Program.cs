using System.Threading.Tasks;
using iTechArt.SurveysSite.DomainModel;
using iTechArt.SurveysSite.Repositories.DbContexts;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace iTechArt.SurveysSite.WebApp
{
    public static class Program
    {
        public static async Task Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .CreateLogger();

            var hostBuilder = CreateHostBuilder(args);
            var host = hostBuilder.Build();

            using (var serviceScope = host
                .Services
                .CreateScope())
            {
                await using var dbContext = serviceScope
                    .ServiceProvider
                    .GetRequiredService<SurveysSiteDbContext>();
                await dbContext.Database.MigrateAsync();

                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<User>>();
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<Role>>();
                await AddInitialDataAsync(userManager, roleManager);
            }

            await host.RunAsync();
        }


        private static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        private static async Task AddInitialDataAsync(UserManager<User> userManager, RoleManager<Role> roleManager)
        {
            var adminRole = await roleManager.FindByNameAsync(RoleNames.AdminRole);
            var admin = new User
            {
                UserName = "admin",
                Email = "admin123@mail.ru",
                Role = adminRole
            };

            await userManager.CreateAsync(admin);
        }
    }
}