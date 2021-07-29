using System.Threading.Tasks;
using iTechArt.SurveysSite.Repositories.DbContexts;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace iTechArt.SurveysSite.WebApp
{
    public static class Program
    {
        public static async Task Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .WriteTo.File(@"../iTechArt/logs/logs.txt")
                .MinimumLevel.Debug()
                .CreateLogger();

            var hostBuilder = CreateHostBuilder(args);
            var host = hostBuilder.Build();

            using (var serviceScope = host
                .Services
                .GetRequiredService<IServiceScopeFactory>()
                .CreateScope())
            {
                await using var dbContext = serviceScope
                    .ServiceProvider
                    .GetRequiredService<SurveysSiteDbContext>();
                await dbContext.Database.MigrateAsync();
            }

            await host.RunAsync();
        }

        private static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}